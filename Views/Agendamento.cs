using System;
using Controllers;
using Models;
using System.Collections.Generic;

namespace Views
{
    public class AgendamentoView
    {

        // ---------- INSERIR AGENDAMENTO ----------
        public static void InserirAgendamento()
        {
            int PacienteId;
            int DentistaId;
            int IdSala;
            DateTime Data = DateTime.Now;
            int optProcedimento = 0;
            List<int> ProcedimentosId = new List<int>();
            Console.WriteLine("Digite o ID do Paciente do Agendamento: ");
            try
            {
                PacienteId = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("ID inválido.");
            }
            Console.WriteLine("Digite o Id do Dentista do Agendamento: ");
            try
            {
                DentistaId = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("ID inválido.");
            }
            Console.WriteLine("Digite o Id da Sala do Agendamento: ");
            try
            {
                IdSala = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("ID inválido.");
            }
            Console.WriteLine("Digite o Data do Agendamento: ");
            try
            {
                Data = Convert.ToDateTime(Console.ReadLine());
            }
            catch
            {
                throw new Exception("Data inválida.");
            }

            do {
                Console.WriteLine("Digite o Id do Procedimento que será executado: ");
                try
                {
                    ProcedimentosId.Add(Convert.ToInt32(Console.ReadLine()));
                }
                catch
                {
                    throw new Exception("Procedimento inválido.");
                }
                Console.WriteLine("Deseja informar outro procedimento? [1-Sim] [2- Não]");
                try
                {
                    optProcedimento = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    optProcedimento = 99;
                }
            } while (optProcedimento != 1 );

            AgendamentoController.InserirAgendamento(
                PacienteId,
                DentistaId,
                IdSala,
                Data,
                ProcedimentosId
            );
        }

        // ---------- ALTERAR AGENDAMENTO ----------
        public static void AlterarAgendamento()
        {
            int Id = 0;
            int IdSala;
            DateTime Data = DateTime.Now;
            int optProcedimento = 0;
            List<int> ProcedimentosId = new List<int>();
            Console.WriteLine("Digite o ID do Agendamento: ");
            try
            {
                Id = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("ID inválido.");
            }            
            Console.WriteLine("Digite o Id da Sala do Agendamento: ");
            try
            {
                IdSala = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("ID inválido.");
            }
            Console.WriteLine("Digite o Data do Agendamento: ");
            try
            {
                Data = Convert.ToDateTime(Console.ReadLine());
            }
            catch
            {
                throw new Exception("Data inválida.");
            }

            do {
                Console.WriteLine("Digite o Id do procedimento que será adicionado: ");
                try
                {
                    ProcedimentosId.Add(Convert.ToInt32(Console.ReadLine()));
                }
                catch
                {
                    throw new Exception("Procedimento inválido.");
                }
                Console.WriteLine("Deseja adicionar outro procedimento? [1-Sim]");
                try
                {
                    optProcedimento = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    optProcedimento = 99;
                }
            } while (optProcedimento != 1);

            do {
                Console.WriteLine("Digite o Id do procedimento que será removido: ");
                try
                {
                    ProcedimentosId.Remove(Convert.ToInt32(Console.ReadLine()));
                }
                catch
                {
                    throw new Exception("Procedimento inválido.");
                }
                Console.WriteLine("Deseja remover outro procedimento? [1-Sim]");
                try
                {
                    optProcedimento = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    optProcedimento = 99;
                }
            } while (optProcedimento != 1);


            AgendamentoController.AlterarAgendamento(
                Id,
                IdSala,
                Data,
                ProcedimentosId
            );
        }

        // ---------- EXCLUIR AGENDAMENTO ----------
        public static void ExcluirAgendamento()
        {
            int Id = 0;
            Console.WriteLine("Digite o ID do Agendamento: ");
            try
            {
                Id = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("ID inválido.");
            }
            
            AgendamentoController.ExcluirAgendamento(
                Id
            );

        }

        // ---------- LISTAR AGENDAMENTO ----------
        public static void ListarAgendamentos()
        {
            foreach (Agendamento item in AgendamentoController.VisualizarAgendamentos())
            {
                Console.WriteLine(item);
            }
        }

        // ---------- MOSTRAR AGENDAMENTO POR PACIENTE ----------
        public static void GetAgendamentosPorPaciente(int PacienteId)
        {
            foreach (Agendamento item in AgendamentoController.GetAgendamentosPorPaciente(PacienteId))
            {
                Console.WriteLine(item);
            }
        }

        // ---------- CONFIRMAR AGENDAMENTO ----------
        public static void ConfirmarAgendamento()
        {
            int Id = 0;
            Console.WriteLine("Digite o ID do Agendamento: ");
            try
            {
                Id = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("ID inválido.");
            }
            Agendamento agendamento = AgendamentoController.ConfirmarAgendamento(Id);

            Console.WriteLine("Agendamento Confirmado: ");
            Console.WriteLine(agendamento);
        }
    }
}