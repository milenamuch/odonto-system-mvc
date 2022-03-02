using System;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace Controllers
{
    public class AgendamentoProcedimentoController
    {
        public static AgendamentoProcedimento InserirAgendamentoProcedimento(
            int IdAgendamento,
            int IdProcedimento
        )
        {
            AgendamentoController.GetAgendamento(IdAgendamento);
            ProcedimentoController.GetProcedimento(IdProcedimento);

            return new AgendamentoProcedimento(IdAgendamento, IdProcedimento);
        }

        public static AgendamentoProcedimento GetAgendamentoProcedimento(
            int Id
        )
        {
            AgendamentoProcedimento agendamento = (
                from AgendamentoProcedimento in AgendamentoProcedimento.GetAgendamentoProcedimentos()
                    where AgendamentoProcedimento.Id == Id
                    select AgendamentoProcedimento
            ).First();

            if (agendamento == null)
            {
                throw new Exception("Relação Agendamento Procedimento não encontrada.");
            }

            return agendamento;
        }

        public static AgendamentoProcedimento ExcluirAgendamentoProcedimento(
            int Id
        )
        {
            AgendamentoProcedimento agendamentoProcedimento = GetAgendamentoProcedimento(Id);
            AgendamentoProcedimento.RemoverAgendamentoProcedimento(agendamentoProcedimento);
            return agendamentoProcedimento;
        }
    }
}