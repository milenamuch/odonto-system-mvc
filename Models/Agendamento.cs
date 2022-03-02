using System;
using System.Collections.Generic;

namespace Models
{
    public class Agendamento
    {
        public static int ID = 0;
        private static List<Agendamento> Agendamentos = new List<Agendamento>();
        public int Id { set; get; }
        public int IdPaciente { set; get; }
        public Paciente Paciente { get; }
        public int IdDentista { set; get; }
        public Dentista Dentista { get; }
        public int IdSala { set; get; }
        public Sala Sala { get; }
        public DateTime Data { set; get; }
        public bool Confirmado { set; get; }

        // ---------- CONSTRUTOR AGENDAMENTO ----------
        public Agendamento(
            int IdPaciente,
            int IdDentista,
            int IdSala,
            DateTime Data
        ) : this(++ID, IdPaciente, IdDentista, IdSala, Data)
        {
            this.Id = Id;
            this.IdPaciente = IdPaciente;
            this.Paciente = Paciente.GetPacientes().Find(Paciente => Paciente.Id == IdPaciente);
            this.IdDentista = IdDentista;
            this.Dentista = Dentista.GetDentistas().Find(Dentista => Dentista.Id == IdDentista);
            this.IdSala = IdSala;
            this.Sala = Sala.GetSalas().Find(Sala => Sala.Id == IdSala);
            this.Data = Data;
        }

        // ---------- CONSTRUTOR AGENDAMENTO ----------
        private Agendamento(
            int Id,
            int IdPaciente,
            int IdDentista,
            int IdSala,
            DateTime Data
        )
        {
            this.Id = Id;
            this.IdPaciente = IdPaciente;
            this.Paciente = Paciente.GetPacientes().Find(Paciente => Paciente.Id == IdPaciente);
            this.IdDentista = IdDentista;
            this.Dentista = Dentista.GetDentistas().Find(Dentista => Dentista.Id == IdDentista);
            this.IdSala = IdSala;
            this.Sala = Sala.GetSalas().Find(Sala => Sala.Id == IdSala);
            this.Data = Data;
            Agendamentos.Add(this);
        }

        // ---------- TOSTRING DE AGENDAMENTO ----------
        public override string ToString()
        {
            return $"ID: {this.Id}"
                + $"\nPaciente: {this.Paciente.Nome}"
                + $"\nDentista: {this.Dentista.Nome}"
                + $"\nSala: {this.Sala.Numero}"
                + $"\nData: {this.Data}"
                + $"\nConfirmado: {(this.Confirmado ? "Sim" : "Não")}"
                + $"\nTotal: R$ {AgendamentoProcedimento.GetTotalPorAgendamento(this.Id)}"
                + $"\n{AgendamentoProcedimento.ImprimirPorAgendamento(this.Id)}";
        }


        // ---------- EQUALS DE AGENDAMENTO ----------
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!Agendamento.ReferenceEquals(obj, this))
            {
                return false;
            }
            Agendamento it = (Agendamento)obj;
            return it.Id == this.Id;
        }

        // ---------- LISTAR AGENDAMENTO ----------
        public static List<Agendamento> GetAgendamentos()
        {
            return Agendamentos;
        }

        // ---------- REMOVER AGENDAMENTO ----------    
        public static void RemoverAgendamento(
            Agendamento agendamento
        )
        {
            Agendamentos.Remove(agendamento);
        }
    }
}