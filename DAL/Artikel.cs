using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace M120Projekt.DAL
{
    public class Artikel
    {
        public Artikel() { }
        [Key]
        public Int64 ArtikelId { get; set; }
        public string Lager { get; set; }
        public int Bestand { get; set; }
        [Required]
        public String Bezeichnung { get; set; }
        [Required]
        public double Preis { get; set; }
        public Boolean Lieferbar { get; set; }
        public ICollection<Bewegung> Bewegung { get; set; }
        public override string ToString()
        {
            return ArtikelId.ToString(); // Für bessere Coded UI Test Erkennung
        }

    }
}
