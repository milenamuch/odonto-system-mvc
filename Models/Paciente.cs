using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Repository;
using System;

namespace Models
{
    public class Paciente : Pessoa
    {
        [Required]
        public DateTime DataNascimento { set; get; }

        public override string ToString()
        {
            return base.ToString()
                + $"\nData de Nascimento: {this.DataNascimento}";
        }

        public Paciente () { }
        public Paciente(
            string Nome,
            string Cpf,
            string Fone,
            string Email,
            string Senha,
            DateTime DataNascimento
        ) : base(Nome, Cpf, Fone, Email, Senha)
        {
            this.Id = Id;
            this.Nome = Nome;
            this.Cpf = Cpf;
            this.Fone = Fone;
            this.Email = Email;
            this.Senha = Senha;
            this.DataNascimento = DataNascimento;
            Context db = new Context();
            db.Pacientes.Add(this);
            db.SaveChanges();
        }

        public static List<Paciente> GetPacientes()
        {
            Context db = new Context();
            return (from Paciente in db.Pacientes select Paciente).ToList();
        }
        public static void RemoverPaciente(Paciente paciente)
        {
            Context db = new Context();
            db.Pacientes.Remove(paciente);
        }

    }
}