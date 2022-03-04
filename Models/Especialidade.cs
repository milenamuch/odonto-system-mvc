using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Repository;

namespace Models
{
    public class Especialidade
    {
        public int Id { set; get; }
        [Required]
        public string Descricao { set; get; }
        [Required]
        public string Detalhamento { set; get; }

        public Especialidade () { }
        public Especialidade(
            string Descricao,
            string Detalhamento
        )
        {
            this.Id = Id;
            this.Descricao = Descricao;
            this.Detalhamento = Detalhamento;
            Context db = new Context();
            db.Especialidades.Add(this);
            db.SaveChanges();
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
            Especialidade it = (Especialidade) obj;
            return it.Id == this.Id;
        }
       public static List<Especialidade> GetEspecialidades()
        {
            Context db = new Context();
            return (from Especialidade in db.Especialidades select Especialidade).ToList();
        }
        public static void RemoverEspecialidade(Especialidade especialidade)
        {
            Context db = new Context();
            db.Especialidades.Remove(especialidade);
        }
    }
}