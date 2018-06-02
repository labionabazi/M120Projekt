using System;
using System.Diagnostics;
using System.Windows;

namespace M120Projekt
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Darf nicht auskommentiert werden(der Initializer wurde erweitert.)
            DemoErstellen();
            DemoAbfragen();
            startAnsicht();
        }
        #region Demo
        private void DemoErstellen()
        {
            // Artikel (kurze Syntax)
            DAL.Artikel artikel1 = new DAL.Artikel { Bezeichnung = "iPhone 6s", Preis = 549.90, Bestand = 212, Lager = "4900 Langenthal", Lieferbar = false };
            Int64 artikel1Id = BLL.Artikel.Erstellen(artikel1);
            Debug.Print("Artikel erstellt mit Id:" + artikel1Id);
            DAL.Artikel artikel2 = new DAL.Artikel { Bezeichnung = "iPhone 7", Preis = 760, Bestand = 100, Lager = "3000 Bern", Lieferbar = false };
            Int64 artikel2Id = BLL.Artikel.Erstellen(artikel2);
            Debug.Print("Artikel erstellt mit Id:" + artikel2Id);
            DAL.Artikel artikel3 = new DAL.Artikel { Bezeichnung = "iPhone 8+", Preis = 849.90, Bestand = 456, Lager = "3000 Bern", Lieferbar = true};
            Int64 artikel3Id = BLL.Artikel.Erstellen(artikel3);
            Debug.Print("Artikel erstellt mit Id:" + artikel3Id);
            DAL.Artikel artikel4 = new DAL.Artikel { Bezeichnung = "iPhone X", Preis = 1120, Bestand = 600, Lager = "4900 Langenthal", Lieferbar = true };
            Int64 artikel4Id = BLL.Artikel.Erstellen(artikel4);
            DAL.Artikel artikel5 = new DAL.Artikel { Bezeichnung = "iPad Air", Preis = 870, Bestand = 752, Lager = "3048 Worblaufen", Lieferbar = true };
            Int64 artikel5Id = BLL.Artikel.Erstellen(artikel5);
            DAL.Artikel artikel6 = new DAL.Artikel { Bezeichnung = "iPdad Pro", Preis = 999, Bestand = 581, Lager = "3000 Bern", Lieferbar = true };
            Int64 artikel6Id = BLL.Artikel.Erstellen(artikel6);
            Debug.Print("Artikel erstellt mit Id:" + artikel6Id);
            
            // Bewegung (detaillierte Syntax)
            DAL.Bewegung bewegung1 = new DAL.Bewegung();
            bewegung1.Firma = "Swisscom AG";
            bewegung1.Datum = DateTime.Today;
            bewegung1.Menge = 10;
            bewegung1.Artikel = artikel1;
            bewegung1.Verrechenbar = true;
            Int64 bewegung1Id = BLL.Bewegung.Erstellen(bewegung1);
            Debug.Print("Bewegung erstellt mit Id:" + bewegung1Id);
            DAL.Bewegung bewegung2 = new DAL.Bewegung();
            bewegung2.Firma = "Apple";
            bewegung2.Datum = DateTime.Today;
            bewegung2.Menge = 35;
            bewegung2.Artikel = artikel4;
            bewegung2.Verrechenbar = true;
            Int64 bewegung4Id = BLL.Bewegung.Erstellen(bewegung2);
            Debug.Print("Bewegung erstellt mit Id:" + bewegung4Id);
        }
        private void DemoAbfragen()
        {
            String output = "";
            // Alle Records Bewegung mit Details zu verknüpftem Record aus Artikel
            output += Environment.NewLine + "Alle Records Bewegung";
            foreach (DAL.Bewegung bewegung in BLL.Bewegung.LesenAlle())
            {
                output += Environment.NewLine + "Bewegung Firma:" + bewegung.Firma;
                output += Environment.NewLine + "Bewegung Artikel:" + bewegung.Artikel.Bezeichnung;
                output += Environment.NewLine + "Bewegung Gesamtpreis:" + bewegung.Gesamtpreis;
            }
            output += Environment.NewLine + "------------------------------------------------------";
            // Alle Records Artikel
            output += Environment.NewLine + "Alle Records Artikel";
            foreach (DAL.Artikel artikel in BLL.Artikel.LesenAlle())
            {
                output += Environment.NewLine + "Artikel Bezeichnung:" + artikel.Bezeichnung;
            }
            output += Environment.NewLine + "------------------------------------------------------";
            Debug.Print(output);
        }
        #endregion

        private void btnArtikel_Click(object sender, RoutedEventArgs e)
        {
            startAnsicht();
        }

        private void btnBewegungen_Click(object sender, RoutedEventArgs e)
        {
            subGrid.Children.Clear();
            Bewegung_Liste bewegungListe = new Bewegung_Liste(subGrid);
            subGrid.Children.Add(bewegungListe);
        }

        private void btnEinzelansicht_Click(object sender, RoutedEventArgs e)
        {
            subGrid.Children.Clear();
            Bewegung_Einzelansicht bewegungEinzelansicht = new Bewegung_Einzelansicht();
            subGrid.Children.Add(bewegungEinzelansicht);
        }

        private void startAnsicht()
        {
            subGrid.Children.Clear();
            Artikel_Liste artikelListe = new Artikel_Liste(subGrid);
            subGrid.Children.Add(artikelListe);
        }
    }
}
