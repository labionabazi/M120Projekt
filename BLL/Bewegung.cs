using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M120Projekt.BLL
{
    static class Bewegung
    {
        public static List<DAL.Bewegung> LesenAlle()
        {
            using (var context = new DAL.Context())
            {
                return (from record in context.Bewegung.Include("Artikel") select record).ToList();
            }
        }
        public static DAL.Bewegung LesenID(Int64 bewegungID)
        {
            using (var context = new DAL.Context())
            {
                return (from record in context.Bewegung.Include("Artikel") where record.BewegungId == bewegungID select record).FirstOrDefault();
            }
        }
        public static List<DAL.Bewegung> LesenAttributGleich(String suchbegriff)
        {
            using (var context = new DAL.Context())
            {
                return (from record in context.Bewegung.Include("Artikel") where record.Firma == suchbegriff select record).ToList();
            }
        }
        public static List<DAL.Bewegung> LesenAttributWie(String suchbegriff)
        {
            using (var context = new DAL.Context())
            {
                return (from record in context.Bewegung.Include("Artikel") where record.Firma.Contains(suchbegriff) select record).ToList();
            }
        }
        public static List<DAL.Bewegung> LesenFremdschluesselGleich(DAL.Artikel suchschluessel)
        {
            using (var context = new DAL.Context())
            {
                return (from record in context.Bewegung.Include("Artikel") where record.Artikel.ArtikelId == suchschluessel.ArtikelId select record).ToList();
            }
        }
        public static Int64 Erstellen(DAL.Bewegung bewegung)
        {
            if (bewegung.Firma == null || bewegung.Firma == "") bewegung.Firma = "leer";
            if (bewegung.Datum == null) bewegung.Datum = DateTime.MinValue;
            using (var context = new DAL.Context())
            {
                context.Bewegung.Add(bewegung);
                //TODO Check ob mit null möglich, sonst throw Ex
                if (bewegung.Artikel != null) context.Artikel.Attach(bewegung.Artikel);
                context.SaveChanges();
                return bewegung.BewegungId;
            }
        }
        public static void Aktualisieren(DAL.Bewegung bewegung)
        {
            using (var context = new DAL.Context())
            {
                //TODO null Checks?
                context.Entry(bewegung).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        public static void Loeschen(DAL.Bewegung bewegung)
        {
            using (var context = new DAL.Context())
            {
                context.Bewegung.Remove(bewegung);
                context.SaveChanges();
            }
        }
    }
}
