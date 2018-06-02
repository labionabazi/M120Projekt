using System;
using System.Windows;
using System.Windows.Controls;

namespace M120Projekt
{
    /// <summary>
    /// Interaktionslogik für Einzelansicht_Bewegung.xaml
    /// </summary>
    public partial class Bewegung_Einzelansicht : UserControl
    {
        private DAL.Bewegung bewegung;
        private Enum Herkunft;
        public Bewegung_Einzelansicht()
        {
            InitializeComponent();
            
        }

        public Bewegung_Einzelansicht(DAL.Bewegung bewegung)
        {
            this.bewegung = bewegung;
            InitializeComponent();
            bwgArtikel.ItemsSource = BLL.Artikel.LesenAlle();
            bwgArtikel.DisplayMemberPath = "Bezeichnung";
            bwgArtikel.SelectedValuePath = "ArtikelId";
            fuelleAus();
        }

        private void btnSpeichern_Click(object sender, RoutedEventArgs e)
        {
            var bewegung = new DAL.Bewegung()
            {
                Artikel = BLL.Artikel.LesenID(Convert.ToInt32(bwgArtikel.Text)),
                Firma = bwgFirma.Text,
                Datum = Convert.ToDateTime(bwgDatum.Text),
                Menge = Convert.ToInt32(bwgMenge.Text),
                Verrechenbar = bwgVerrechenbar.IsEnabled
            };
            BLL.Bewegung.Erstellen(bewegung);
            bwgGesamtpreisLabel.Visibility = Visibility.Visible;
            bwgGesamtPreis.Visibility = Visibility.Visible;
            bwgGesamtPreis.Content = bewegung.Gesamtpreis.ToString();
            bwgId.Content = bewegung.BewegungId; 
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var zuLoeschendeBewegung = BLL.Bewegung.LesenID(Convert.ToInt64(bwgId.Content));
            BLL.Bewegung.Loeschen(zuLoeschendeBewegung);
        }
        
        private void fuelleAus()
        {
            bwgId.Content = bewegung.BewegungId;
            bwgArtikel.SelectedValue = bewegung.Artikel.ArtikelId;
            bwgDatum.Text = bewegung.Datum.ToString();
            bwgFirma.Text = bewegung.Firma;
            bwgMenge.Text = bewegung.Menge.ToString();

            bwgGesamtpreisLabel.Visibility = Visibility.Visible;
            bwgGesamtPreis.Visibility = Visibility.Visible;

            bwgGesamtPreis.Content = bewegung.Gesamtpreis;
        }
    }
}
