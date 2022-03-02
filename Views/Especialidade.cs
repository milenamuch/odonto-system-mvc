using System;
using Controllers;
using Models;

namespace Views
{
    public class EspecialidadeView
    {
        public static void InserirEspecialidade()
        {
            Console.WriteLine("Informe a descrição da Especialidade: ");
            string Descricao = Console.ReadLine();
            Console.WriteLine("Informe o detalhamento da Especialidade: ");
            string Detalhamento = Console.ReadLine();

            EspecialidadeController.IncluirEspecialidade(
                Descricao,
                Detalhamento
            );

            Console.WriteLine("\n Especialidade cadastrada com sucesso!");

        }

        public static void AlterarEspecialidade()
        {
            int Id = 0;
            Console.WriteLine("Digite o ID da Especialidade: ");
            try
            {
                Id = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("ID inválido.");
            }
            Console.WriteLine("Informe a descrição da Especialidade: ");
            string Descricao = Console.ReadLine();
            Console.WriteLine("Informe o detalhamento da Especialidade: ");
            string Detalhamento = Console.ReadLine();

            EspecialidadeController.AlterarEspecialidade(
                Id,
                Descricao,
                Detalhamento
            );
            Console.WriteLine("\n Especialidade alterada com sucesso!");
        }

        public static void ExcluirEspecialidade()
        {
            int Id = 0;
            Console.WriteLine("Digite o ID da Especialidade: ");
            try
            {
                Id = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("ID inválido.");
            }

            EspecialidadeController.ExcluirEspecialidade(
                Id
            );

            Console.WriteLine("\n Especialidade excluída com sucesso!");

        }

        public static void ListarEspecialidades()
        {
            foreach (Especialidade item in EspecialidadeController.VisualizarEspecialidades())
            {
                Console.WriteLine(item);
            }
        }
    }
}