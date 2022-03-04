using System;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace Controllers
{
    public class AgendamentoController
    {
        public static Agendamento InserirAgendamento(
            int PacienteId,
            int DentistaId,
            int SalaId,
            DateTime Data,
            List<int> ProcedimentosId
        )
        {
            PacienteController.GetPaciente(PacienteId);
            DentistaController.GetDentista(DentistaId);
            SalaController.GetSala(SalaId);
            List<Procedimento> Procedimentos = new List<Procedimento>();

            foreach (int item in ProcedimentosId)
            {
                Procedimento procedimento = ProcedimentoController.GetProcedimento(item);
                Procedimentos.Add(procedimento);
            }

            if (Data == null || Data <= DateTime.Now)
            {
                throw new Exception("Data não pode ser inferior a data atual.");
            }

            if (GetConflito(
                0,
                DentistaId,
                Data
            ))
            {
                throw new Exception("Já existe um agendamento para este horário");
            }

            Agendamento agendamento = new Agendamento(PacienteId, DentistaId, SalaId, Data);

            foreach (Procedimento procedimento in Procedimentos) 
            {
                AgendamentoProcedimentoController.InserirAgendamentoProcedimento(agendamento.Id, procedimento.Id);
            }

            return agendamento;
        }

        private static bool GetConflito(
            int IdAtual,
            int DentistaId,
            DateTime Data
        )
        {
            IEnumerable<Agendamento> agendamentos =
                from Agendamento in Agendamento.GetAgendamentos()
                    where Agendamento.Data == Data 
                        && Agendamento.DentistaId == DentistaId
                        && Agendamento.Id != IdAtual
                    select Agendamento;

            return agendamentos.Count() > 0;
        }

        public static Agendamento AlterarAgendamento(
            int Id,
            int SalaId,
            DateTime Data,
            List<int> ProcedimentosId
        )
        {
            Agendamento agendamento = GetAgendamento(Id);
            SalaController.GetSala(SalaId);
            List<Procedimento> Procedimentos = new List<Procedimento>();

            if (Data == null || Data < DateTime.Now)
            {
                throw new Exception("Data inválida");
            }

            if (GetConflito(
                agendamento.Id,
                agendamento.DentistaId,
                Data
            ))
            {
                throw new Exception("Já existe um agendamento para este horário");
            }

            foreach (int item in ProcedimentosId)
            {
                Procedimento procedimento = ProcedimentoController.GetProcedimento(item);
                Procedimentos.Remove(procedimento);
            }

            agendamento.SalaId = SalaId;
            agendamento.Data = Data;

            return agendamento;
        }

        
        public static Agendamento ExcluirAgendamento(
            int Id
        )
        {
            Agendamento agendamento = GetAgendamento(Id);
            Agendamento.RemoverAgendamento(agendamento);
            return agendamento;
        }
        public static List<Agendamento> VisualizarAgendamentos()
        {
            return Agendamento.GetAgendamentos();
        }

        public static void RemoveAll<Procedimentos>(Procedimentos item,List<Procedimentos> list)
        {
            while(list.Contains(item)) list.Remove(item);
        }
        
        public static Agendamento GetAgendamento(
            int Id
        )
        {
            Agendamento agendamento = (
                from Agendamento in Agendamento.GetAgendamentos()
                    where Agendamento.Id == Id
                    select Agendamento
            ).First();

            if (agendamento == null)
            {
                throw new Exception("Agendamento não encontrado.");
            }

            return agendamento;
        }

        public static IEnumerable<Agendamento> GetAgendamentosPorPaciente(int PacienteId) //fazer assim pra procedimento??
        {
            return Agendamento.GetAgendamentos()
                .Where(Agendamento => Agendamento.PacienteId == PacienteId);
        }

        /*public static IEnumerable<Agendamento> GetProcedimentosPorAgendamento(int IdProcedimento) //fazer assim pra procedimento??
        {
            return Agendamento.GetAgendamentos()
                .Where(AgendamentoProcedimento => AgendamentoProcedimento.IdProcedimento == IdProcedimento);
        }*/

        public static Agendamento ConfirmarAgendamento(int Id)
        {
            Agendamento agendamento = GetAgendamento(Id);

            if (agendamento.PacienteId != Auth.Paciente.Id)
            {
                throw new Exception("Não é possível confirmar esse agendamento");
            }
            agendamento.Confirmado = true;
            return agendamento;
        }
    }
}