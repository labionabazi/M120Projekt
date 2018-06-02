using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace M120Projekt.DAL
{
    public class Bewegung
    {
        public Bewegung() { }
        [Key]
        public Int64 BewegungId { get; set; }
        [Required]
        public String Firma { get; set; }
        [Required]
        public DateTime Datum { get; set; }
        [Required]
        public int Menge { get; set; }
        [Required]
        public Boolean Verrechenbar { get; set; }
        public Artikel Artikel { get; set; }
        [NotMapped]
        public double Gesamtpreis {
            get
            {
                if (Verrechenbar)
                {
                    return Artikel.Preis * Menge;
                } else
                {
                    return 0;
                }
            }
        }
        public override string ToString()
        {
            return BewegungId.ToString(); // Für bessere Coded UI Test Erkennung
        }
    }
}
