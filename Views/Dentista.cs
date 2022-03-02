using System;
using Controllers;
using Models;

namespace Views
{
    public class DentistaView
    {
        public static void InserirDentista()
        {

            int IdEspecialidade;

            double Salario = 0;
            Console.WriteLine("Digite o Nome do Dentista: ");
            string Nome = Console.ReadLine();
            Console.WriteLine("Digite o C.P.F. do Dentista: ");
            string Cpf = Console.ReadLine();
            Console.WriteLine("Digite o Telefone do Dentista: ");
            string Fone = Console.ReadLine();
            Console.WriteLine("Digite o Email do Dentista: ");
            string Email = Console.ReadLine();
            Console.WriteLine("Digite o Senha do Dentista: ");
            string Senha = Console.ReadLine();
            Console.WriteLine("Digite o Número do C.R.O.: ");
            string Registro = Console.ReadLine();
            Console.WriteLine("Digite o Salário do Dentista: ");
            try
            {
                Salario = Convert.ToDouble(Console.ReadLine());
            }
            catch
            {
                throw new Exception("Salário inválido.");
            }
            Console.WriteLine("Digite o id da especialidade: ");

            try
            {
                IdEspecialidade = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("ID inválido.");
            }

            Console.WriteLine("\n Dentista cadastrado com sucesso!");
            DentistaController.InserirDentista(
                Nome,
                Cpf,
                Fone,
                Email,
                Senha,
                Registro,
                Salario,
                IdEspecialidade
            );
        }

        public static void AlterarDentista()
        {
            int Id = 0;
            double Salario = 0;
            Console.WriteLine("Digite o ID do Dentista: ");
            try
            {
                Id = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("ID inválido.");
            }
            Console.WriteLine("Digite o Nome do Dentista: ");
            string Nome = Console.ReadLine();
            Console.WriteLine("Digite o C.P.F. do Dentista: ");
            string Cpf = Console.ReadLine();
            Console.WriteLine("Digite o Telefone do Dentista: ");
            string Fone = Console.ReadLine();
            Console.WriteLine("Digite o Email do Dentista: ");
            string Email = Console.ReadLine();
            Console.WriteLine("Digite o Senha do Dentista: ");
            string Senha = Console.ReadLine();
            Console.WriteLine("Digite o Número do C.R.O.: ");
            string Registro = Console.ReadLine();
            Console.WriteLine("Digite o Salário do Dentista: ");
            try
            {
                Salario = Convert.ToDouble(Console.ReadLine());
            }
            catch
            {
                throw new Exception("Salário inválido.");
            }

            DentistaController.AlterarDentista(
                Id,
                Nome,
                Cpf,
                Fone,
                Email,
                Senha,
                Registro,
                Salario
            );
            Console.WriteLine("\n Dentista alterado com sucesso!");
        }

        public static void ExcluirDentista()
        {
            int Id = 0;
            Console.WriteLine("Digite o ID do Dentista: ");
            try
            {
                Id = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("ID inválido.");
            }

            DentistaController.ExcluirDentista(
                Id
            );

            Console.WriteLine("\n Dentista excluído com sucesso!");
        }
        public static void ListarDentistas()
        {
            foreach (Dentista item in DentistaController.VisualizarDentista())
            {
                Console.WriteLine(item);
            }
        }
    }
}