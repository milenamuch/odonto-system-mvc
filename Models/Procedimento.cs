using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Repository;

namespace Models
{
    public class Procedimento
    {
        
        public int Id { set; get; }
        [Required]
        public string Descricao { set; get; }
        [Required]
        public double Preco { set; get; }

        public Procedimento () { }

        public Procedimento(
            string Descricao,
            double Preco
        )
        {
            this.Id = Id;
            this.Descricao = Descricao;
            this.Preco = Preco;
            Context db = new Context();
            db.Procedimentos.Add(this);
            db.SaveChanges();
        }

        public override string ToString()
        {
            return $"ID: {this.Id}"
                + $"\n Descrição: {this.Descricao}"
                + $"\n Preço: {this.Preco}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!Procedimento.ReferenceEquals(obj, this))
            {
                return false;
            }
            Procedimento it = (Procedimento)obj;
            return it.Id == this.Id;
        }


        public static List<Procedimento> GetProcedimentos()
        {
            Context db = new Context();
            return (from Procedimento in db.Procedimentos select Procedimento).ToList();
        }

        public static void RemoverProcedimento(Procedimento procedimento)
        {
            Context db = new Context();
            db.Procedimentos.Remove(procedimento);
        }
    }
}