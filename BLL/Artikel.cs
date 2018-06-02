using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M120Projekt.BLL
{
    static class Artikel
    {
        public static List<DAL.Artikel> LesenAlle()
        {
            using (var context = new DAL.Context())
            {
                return (from record in context.Artikel select record).ToList();
            }
        }
        public static DAL.Artikel LesenID(Int64 artikelId)
        {
            using (var context = new DAL.Context())
            {
                return (from record in context.Artikel where record.ArtikelId == artikelId select record).FirstOrDefault();
            }
        }
        public static List<DAL.Artikel> LesenAttributGleich(String suchbegriff)
        {
            using (var context = new DAL.Context())
            {
                return (from record in context.Artikel where record.Bezeichnung == suchbegriff select record).ToList();
            }
        }
        public static List<DAL.Artikel> LesenAttributWie(String suchbegriff)
        {
            using (var context = new DAL.Context())
            {
                return (from record in context.Artikel where record.Bezeichnung.Contains(suchbegriff) select record).ToList();
            }
        }
        public static Int64 Erstellen(DAL.Artikel artikel)
        {
            if (artikel.Bezeichnung == null || artikel.Bezeichnung == "") artikel.Bezeichnung = "leer";
            using (var context = new DAL.Context())
            {
                context.Artikel.Add(artikel);
                context.SaveChanges();
                return artikel.ArtikelId;
            }
        }
        public static void Aktualisieren(DAL.Artikel artikel)
        {
            using (var context = new DAL.Context())
            {
                //TODO null Checks?
                context.Entry(artikel).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        public static void Loeschen(DAL.Artikel artikel)
        {
            using (var context = new DAL.Context())
            {
                context.Artikel.Remove(artikel);
                context.SaveChanges();
            }
        }
    }
}
