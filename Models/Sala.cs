using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Repository;
namespace Models
{
    public class Sala
    {
        
        public int Id { set; get; }
        [Required]
        public string Numero { set; get; }
        [Required]
        public string Equipamentos { set; get; }

        public Sala () { }
        public Sala(
        string Numero,
        string Equipamentos
        )
        {
            this.Id = Id;
            this.Numero = Numero;
            this.Equipamentos = Equipamentos;
            Context db = new Context();
            db.Salas.Add(this);
            db.SaveChanges();
        }
        public override string ToString()
        {
            return $"ID: {this.Id}"
            + $"\nNúmero: {this.Numero}"
            + $"\nEquipamentos: {this.Equipamentos}";
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!Sala.ReferenceEquals(obj, this))
            {
                return false;
            }
            Sala it = (Sala)obj;
            return it.Id == this.Id;
        }
        public static List<Sala> GetSalas()
        {
            Context db = new Context();
            return (from Sala in db.Salas select Sala).ToList();
        }
        public static void RemoverSala(Sala sala)
        {
            Context db = new Context();
            db.Salas.Remove(sala);
        }
    }
}