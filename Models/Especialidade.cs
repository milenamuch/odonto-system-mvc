using System.Collections.Generic;

namespace Models
{
    public class Especialidade
    {
        public static int ID = 0;
        private static List<Especialidade> Especialidades = new List<Especialidade>();
        public int Id { set; get; }
        public string Descricao { set; get; }
        public string Detalhamento { set; get; }

        public Especialidade(
            string Descricao,
            string Detalhamento
        ) : this(++ID, Descricao, Detalhamento)
        {
            this.Descricao = Descricao;
            this.Detalhamento = Detalhamento;
        }

        private Especialidade(
            int Id,
            string Descricao,
            string Detalhamento
        )
        {
            this.Id = Id;
            this.Descricao = Descricao;
            this.Detalhamento = Detalhamento;

            Especialidades.Add(this);
        }

        public override string ToString()
        {
            return $"ID: {this.Id}"
                + $"\nDescrição: {this.Descricao}"
                + $"\nDetalhamento: {this.Detalhamento}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!Especialidade.ReferenceEquals(obj, this))
            {
                return false;
            }
            Especialidade it = (Especialidade)obj;
            return it.Id == this.Id;
        }
        public static List<Especialidade> GetEspecialidades()
        {
            return Especialidades;
        }

        public static void RemoverEspecialidade(Especialidade especialidade)
        {
            Especialidades.Remove(especialidade);
        }
    }
}