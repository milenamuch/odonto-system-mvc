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
            int IdPaciente;
            int IdDentista;
            int IdSala;
            DateTime Data = DateTime.Now;
            int opt = 0;
            List<int> IdProcedimentos = new List<int>();
            Console.WriteLine("Digite o ID do Paciente do Agendamento: ");
            try
            {
                IdPaciente = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("ID de paciente inválido.");
            }
            Console.WriteLine("Digite o Id do Dentista do Agendamento: ");
            try
            {
                IdDentista = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("ID de dentista inválido.");
            }
            Console.WriteLine("Digite o Id da Sala do Agendamento: ");
            try
            {
                IdSala = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("ID de sala inválido.");
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


            Console.WriteLine("Digite o Id do Procedimento que será executado: ");
            try
            {
                IdProcedimentos.Add(Convert.ToInt32(Console.ReadLine()));
            }
            catch
            {
                throw new Exception("Procedimento inválido.");
            }

            do
            {

                Console.WriteLine("Deseja informar outro procedimento? [1-Sim] [2- Não]");

                opt = Convert.ToInt32(Console.ReadLine());


                switch (opt)
                {
                    case 1:
                        Console.WriteLine("Digite o Id do procedimento que será adicionado: ");
                        try
                        {
                            IdProcedimentos.Add(Convert.ToInt32(Console.ReadLine()));
                        }
                        catch
                        {
                            throw new Exception("Procedimento inválido.");
                        }
                        break;

                    case 2:
                        Console.WriteLine("Você saiu");
                        break;

                    default:
                        Console.WriteLine("Operação inválida");
                        break;
                }
            } while (opt == 1);


            Console.WriteLine("\nAgendamento cadastrado com sucesso!");

            AgendamentoController.InserirAgendamento(
                IdPaciente,
                IdDentista,
                IdSala,
                Data,
                IdProcedimentos
            );

        }

        // ---------- ALTERAR AGENDAMENTO ----------
        public static void AlterarAgendamento()
        {
            int Id = 0;
            int IdSala;
            DateTime Data = DateTime.Now;
            int opt = 0;
            List<int> IdProcedimentos = new List<int>();
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

            do
            {
                Console.WriteLine(">> Alterar agendamento <<");
                Console.WriteLine("Alterar Procedimento [1] ");
                Console.WriteLine("Excluir Procedimento [2] ");
                Console.WriteLine("Digite a opção escolhida: ");
                try
                {
                    opt = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    opt = 99;
                }

                switch (opt)
                {
                    case 1:
                        Console.WriteLine("Digite o Id do procedimento que será adicionado: ");
                        try
                        {
                            IdProcedimentos.Add(Convert.ToInt32(Console.ReadLine()));
                        }
                        catch
                        {
                            throw new Exception("Procedimento inválido.");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Digite o Id do procedimento que será removido: ");
                        try
                        {
                            IdProcedimentos.Remove(Convert.ToInt32(Console.ReadLine()));
                        }
                        catch
                        {
                            throw new Exception("Procedimento inválido.");
                        }
                        break;
                    default:
                        Console.WriteLine("Operação inválida");
                        break;
                }

            } while (opt != 0);
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


            Console.WriteLine("\nAgendamento excluído com sucesso!");

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
        public static void GetAgendamentosPorPaciente(int IdPaciente)
        {

            foreach (Agendamento item in AgendamentoController.GetAgendamentosPorPaciente(IdPaciente))
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

            Console.WriteLine("Agendamento Confirmado ");
            Console.WriteLine(agendamento);
        }
    }
}