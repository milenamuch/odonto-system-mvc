using System;
using Views;
using Controllers;
using Models;

namespace ConsultorioOdontologico
{
    public class Program
    {
        public static string ReadPassword()
        {
            string password = "";
            ConsoleKeyInfo info = Console.ReadKey(true);
            while (info.Key != ConsoleKey.Enter)
            {
                if (info.Key != ConsoleKey.Backspace)
                {
                    Console.Write("*");
                    password += info.KeyChar;
                }
                else if (info.Key == ConsoleKey.Backspace)
                {
                    if (!string.IsNullOrEmpty(password))
                    {
                        // remove one character from the list of password characters
                        password = password.Substring(0, password.Length - 1);
                        // get the location of the cursor
                        int pos = Console.CursorLeft;
                        // move the cursor to the left by one character
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                        // replace it with space
                        Console.Write(" ");
                        // move the cursor to the left by one character again
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                    }
                }
                info = Console.ReadKey(true);
            }
            // add a new line because user pressed enter at the end of their password
            Console.WriteLine();
            return password;
        }

        public static void Main(string[] args)
        {

            PrimeiroAcesso();
            
            do
            {
                Console.WriteLine("Informe o usuário: ");
                string Email = Console.ReadLine();
                Console.WriteLine("Informe a senha: ");
                string Senha = ReadPassword();
                
                try
                {
                    Auth.Login(Email, Senha);
                    if (Auth.Dentista != null) {
                        MenuPrincipal();
                    }
                    if (Auth.Paciente != null) {
                        MenuPaciente();
                    }
                    Auth.Logout();
                }
                catch (Exception err)
                {
                    Console.WriteLine(err);
                }
            } while (!Auth.isLogeed);
        }


        public static void PrimeiroAcesso ()
        {
            int PrimeiroAcesso = 0;
            do 
            {
                Console.WriteLine("Seja bem vindo ao OdontoSystem, insira os seus dados de primeiro acesso! ");
                Console.WriteLine("\n Primeiro será necessário inserir uma especialidade ");
                    EspecialidadeView.InserirEspecialidade();

                Console.WriteLine("Agora, deverá inserir os dados cadastrais com a especialidade criada. ");
                    DentistaView.InserirDentista();
                    PrimeiroAcesso = 1;

            } while (PrimeiroAcesso != 1);
        }
        public static void MenuPaciente()
        {
            Console.WriteLine($" ============= BEM VINDO PACIENTE {Auth.Paciente.Nome} ============ ");
            Console.WriteLine("+------------------------------------+");
            Console.WriteLine("| Operação | Descrição               |");
            Console.WriteLine("|----------|-------------------------|");
            Console.WriteLine("|    0     | Sair                    |");
            Console.WriteLine("|    1     | Visualizar Agendamentos |");
            Console.WriteLine("|    2     | Confirmar Agendamento   |");
            Console.WriteLine("|    3     | Cancelar Agendamento    |");
            Console.WriteLine("+------------------------------------+");
            int opt = 0;

            do
            {
                Console.WriteLine("Digite a operação: ");
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
                    case 0:
                        Console.WriteLine("Obrigado por utilizar o sistema");
                        break;
                    case 1:
                        AgendamentoView.GetAgendamentosPorPaciente(Auth.Paciente.Id);
                        break;

                    case 2:
                        AgendamentoView.ConfirmarAgendamento();
                        break;

                    case 3:
                        AgendamentoView.ExcluirAgendamento();
                        break;

                    default:
                        Console.WriteLine("Operação inválida");
                        break;
                }  
            } while(opt != 0);
        }

        public static void MenuPrincipal()
        {
            Console.WriteLine($" ============= BEM VINDO DR(A). {Auth.Dentista.Nome} ============ ");
            Console.WriteLine("+--------------------------------------+");
            Console.WriteLine("| Operação |        Descrição          |");
            Console.WriteLine("|----------|---------------------------|");
            Console.WriteLine("| 0        | Sair                      |");
            Console.WriteLine("| 1        | Incluir Dentista          |");
            Console.WriteLine("| 2        | Incluir Paciente          |");
            Console.WriteLine("| 3        | Incluir Sala              |");
            Console.WriteLine("| 4        | Incluir Especialidade     |");
            Console.WriteLine("| 5        | Incluir Procedimento      |");
            Console.WriteLine("| 6        | Incluir Agendamento       |");
            Console.WriteLine("| 7        | Alterar Paciente          |");
            Console.WriteLine("| 8        | Alterar Dentista          |");
            Console.WriteLine("| 9        | Alterar Sala              |");
            Console.WriteLine("| 10       | Alterar Agendamento       |");
            Console.WriteLine("| 11       | Alterar Procedimento      |");
            Console.WriteLine("| 12       | Alterar Especialidade     |");
            Console.WriteLine("| 13       | Excluir Dentista          |");
            Console.WriteLine("| 14       | Excluir Paciente          |");
            Console.WriteLine("| 15       | Excluir Sala              |");
            Console.WriteLine("| 16       | Excluir Agendamento       |");
            Console.WriteLine("| 17       | Excluir Procedimento      |");
            Console.WriteLine("| 18       | Excluir Especialidade     |");
            Console.WriteLine("| 19       | Visualizar Dentista       |");
            Console.WriteLine("| 20       | Visualizar Paciente       |");
            Console.WriteLine("| 21       | Visualizar Sala           |");
            Console.WriteLine("| 22       | Visualizar Agendamento    |");
            Console.WriteLine("| 23       | Visualizar Procedimento   |");
            Console.WriteLine("| 24       | Visualizar Especialidade  |");
            Console.WriteLine("+---------------------------------------+");

            int opt = 0;

            do
            {
                try
                {
                    Console.WriteLine("Digite a operação: ");
                    opt = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    opt = 99;
                }
                try{
                    switch (opt)
                    {
                        case 0:
                        {
                            Console.WriteLine("Obrigado por utilizar o sistema!");
                            break;
                        }
                        case 1:
                        {
                            DentistaView.InserirDentista();
                            break;
                        }
                        case 2:
                        {
                            PacienteView.InserirPaciente();
                            break;
                        }
                        case 3:
                        {
                            SalaView.InserirSala();
                            break;
                        }
                        case 4:
                        {
                            EspecialidadeView.InserirEspecialidade();
                            break;
                        }

                        case 5:
                        {
                            ProcedimentoView.InserirProcedimento();
                            break;
                        }

                        case 6:
                        {
                            AgendamentoView.InserirAgendamento();
                            break;
                        }

                        case 7:
                        {
                            PacienteView.AlterarPaciente();
                            break;
                        }

                        case 8:
                        {
                            DentistaView.AlterarDentista();
                            break;
                        }

                        case 9:
                        {
                            SalaView.AlterarSala();
                            break;
                        }
                        case 10:
                        {
                            AgendamentoView.AlterarAgendamento();
                            break;
                        }

                        case 11:
                        {
                            ProcedimentoView.AlterarProcedimento();
                            break;
                        }

                        case 12:
                        {
                            EspecialidadeView.AlterarEspecialidade();
                            break;
                        }
                        
                        case 13:
                        {
                            DentistaView.ExcluirDentista();
                            break;
                        }
                        case 14:
                        {
                            PacienteView.ExcluirPaciente();
                            break;
                        }
                        case 15:
                        {
                            SalaView.ExcluirSala();
                            break;
                        }
                        case 16:
                        {
                            AgendamentoView.ExcluirAgendamento();
                            break;
                        }

                        case 17:
                        {
                            ProcedimentoView.ExcluirProcedimento();
                            break;
                        }

                        case 18:
                        {
                            EspecialidadeView.ExcluirEspecialidade();
                            break;
                        }

                        case 19:
                        {
                            DentistaView.ListarDentistas();
                            break;
                        }

                        case 20:
                        {
                            PacienteView.ListarPacientes();
                            break;
                        }

                        case 21:
                        {
                            SalaView.ListarSalas();
                            break;
                        }

                        case 22:
                        {
                            AgendamentoView.ListarAgendamentos();
                            break;
                        }

                        case 23:
                        {
                            ProcedimentoView.ListarProcedimentos();
                            break;
                        }

                        case 24:
                        {
                            EspecialidadeView.ListarEspecialidades();
                            break;
                        }

                        default:
                        {
                            Console.WriteLine("Operação inválida");
                            break;
                        }
                    }
                } 
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                    opt = 99;
                }
            } while (opt != 0);
        }
    }
}
