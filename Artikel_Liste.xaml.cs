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
    /// Interaktionslogik für Artikel_Liste.xaml
    /// </summary>
    public partial class Artikel_Liste : UserControl
    {
        private Grid grid;
        public Artikel_Liste(Grid g)
        {
            grid = g;
            InitializeComponent();

            List<DAL.Artikel> allArtikel = new List<DAL.Artikel>();
            allArtikel = BLL.Artikel.LesenAlle();

            artikelListe.ItemsSource = allArtikel;

            artikelListe.CanUserAddRows = false;
            artikelListe.CanUserDeleteRows = false;

            artikelListe.IsReadOnly = true;
        }

        private void artikelListe_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (artikelListe.SelectedItem != null)
            {
                DAL.Artikel auswahl = (DAL.Artikel)artikelListe.SelectedItem;
                
                Bewegung_Einzelansicht bwgEinzelansicht = new Bewegung_Einzelansicht();
                grid.Children.Clear();
                grid.Children.Add(bwgEinzelansicht);
                
                bwgEinzelansicht.bwgArtikel.Text = auswahl.ArtikelId.ToString();
                bwgEinzelansicht.bwgDatum.Text = DateTime.Now.ToString();
            }
        }
    }
}
