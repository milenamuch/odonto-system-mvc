using System;
using Controllers;
using Models;

namespace Views
{
    public class SalaView
    {
        public static void InserirSala()
        {
            
            Console.WriteLine("Digite o Número da Sala: ");
            string Numero = Console.ReadLine();
            Console.WriteLine("Digite os Equipamentos da Sala: ");
            string Equipamentos = Console.ReadLine();

            SalaController.IncluirSala(
                Numero,
                Equipamentos
            );

             Console.WriteLine("\nA sala foi cadastrada com sucesso!");
        }

        public static void AlterarSala()
        {
            int Id = 0;
            Console.WriteLine("Digite o ID da Sala: ");
            try
            {
                Id = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("ID inválido.");
            }
            Console.WriteLine("Digite o Número da Sala: ");
            string Numero = Console.ReadLine();
            Console.WriteLine("Digite os Equipamentos da Sala: ");
            string Equipamentos = Console.ReadLine();

            SalaController.AlterarSala(
                Id,
                Numero,
                Equipamentos
            );

            Console.WriteLine("\nA sala foi alterada com sucesso!");

        }

        public static void ExcluirSala()
        {
            int Id = 0;
            Console.WriteLine("Digite o ID da Sala: ");
            try
            {
                Id = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("ID inválido.");
            }
            
            SalaController.ExcluirSala(
                Id
            );

        }

        public static void ListarSalas()
        {
            foreach (Sala item in SalaController.VisualizarSalas())
            {
                Console.WriteLine(item);
            }
        }
    }
}