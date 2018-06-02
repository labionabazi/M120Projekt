using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace M120Projekt
{
    /// <summary>
    /// Interaktionslogik für Bewegung_Liste.xaml
    /// </summary>
    public partial class Bewegung_Liste : UserControl
    {
        private Grid grid;
        public Bewegung_Liste(Grid g)
        {
            grid = g;
            InitializeComponent();

            List<DAL.Bewegung> allBewegungen = new List<DAL.Bewegung>();
            allBewegungen = BLL.Bewegung.LesenAlle();

            bewegungListe.ItemsSource = allBewegungen;

            bewegungListe.CanUserAddRows = false;
            bewegungListe.CanUserDeleteRows = false;

            bewegungListe.IsReadOnly = true;
        }

        private void artikelListe_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (bewegungListe.SelectedItem != null)
            {
                DAL.Bewegung auswahl = (DAL.Bewegung)bewegungListe.SelectedItem;

                Bewegung_Einzelansicht bwgEinzelansicht = new Bewegung_Einzelansicht(auswahl);
                grid.Children.Clear();
                grid.Children.Add(bwgEinzelansicht);

                //bwgEinzelansicht.bwgArtikel.SelectedValue = auswahl.Artikel.ArtikelId;
                //bwgEinzelansicht.bwgDatum.Text = auswahl.Datum.ToString();
                //bwgEinzelansicht.bwgFirma.Text = auswahl.Firma;
                //bwgEinzelansicht.bwgMenge.Text = auswahl.Menge.ToString();

                //bwgEinzelansicht.bwgGesamtpreisLabel.Visibility = Visibility.Visible;
                //bwgEinzelansicht.bwgGesamtPreis.Visibility = Visibility.Visible;

                //bwgEinzelansicht.bwgGesamtPreis.Content = auswahl.Gesamtpreis;
                //bwgEinzelansicht.bwgId.Content = auswahl.BewegungId;
             }
        }
    }
}
