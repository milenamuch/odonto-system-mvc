using System;
using Controllers;
using Models;

namespace Views
{
    public class AgendamentoProcedimentoView
    {
        public static void InserirProcedimento()
        {
            Console.WriteLine("Informe a descrição do procedimento: ");
            string Descricao = Console.ReadLine();
            Console.WriteLine("Informe o preço do procedimento: ");
            double Preco = Convert.ToDouble(Console.ReadLine());

            ProcedimentoController.IncluirProcedimento(
                Descricao,
                Preco
            );

        }

        public static void AlterarProcedimento()
        {
            int Id = 0;
            Console.WriteLine("Digite o ID do Procedimento: ");
            try
            {
                Id = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("ID inválido.");
            }
            Console.WriteLine("Informe a descrição do procedimento: ");
            string Descricao = Console.ReadLine();
            Console.WriteLine("Informe o preço do procedimento: ");
            double Preco = Convert.ToDouble(Console.ReadLine());

            ProcedimentoController.AlterarProcedimento(
                Id,
                Descricao,
                Preco
            );
        }

        public static void ExcluirProcedimento()
        {
            int Id = 0;
            Console.WriteLine("Digite o ID do procedimento: ");
            try
            {
                Id = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("ID inválido.");
            }
            
            ProcedimentoController.ExcluirProcedimento(
                Id
            );

        }

        public static void ListarProcedimentos()
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

            /*foreach (Procedimento item in Procedimento.VisualizarProcedimentos())
            {
                Console.WriteLine(item);
            }*/
        }
    }
}