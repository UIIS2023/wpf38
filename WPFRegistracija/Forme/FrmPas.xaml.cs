using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Shapes;
using static WPFRegistracija.Forme.FrmRasa;
using static WPFRegistracija.Forme.FrmVlasnikCreate;

namespace WPFRegistracija.Forme
{
    /// <summary>
    /// Interaction logic for FrmPas.xaml
    /// </summary>
    public partial class FrmPas : Window
    {
        public class Pas
        {
            public int Id { get; set; }
            public string Ime { get; set; }
            public int Godine { get; set; }
            public string Pol { get; set; }
            public int RasaId { get; set; }
            public int IdVlasnika { get; set; }
            public Pas(int id, string ime, int rasaId, int godine, string pol, int idVlasnika)
            {
                Id = id;
                Ime = ime;
                Godine = godine;
                Pol = pol;
                RasaId = rasaId;
                IdVlasnika = idVlasnika;
            }
        }
        public FrmPas()
        {
            InitializeComponent();
            PopuniComboBoxVlasnici();
            PopuniComboBoxRase();
            BindDataToDataGrid();
        }

        private void PopuniComboBoxVlasnici()
        {
            vlasniOdabir.ItemsSource = FetchVlasnici();
            vlasniOdabir.DisplayMemberPath = "PunoIme"; 
        }

        public List<Vlasnik> FetchVlasnici()
        {
            List<Vlasnik> vlasnici = new List<Vlasnik>();

            using (SqlConnection konekcija = new Konekcija().KreirajKonekciju())
            {
                konekcija.Open();
                string sqlUpit = "SELECT id_vlasnika, ime, prezime, adresa, telefon, email, JMBG FROM Vlasnik";

                using (SqlCommand cmd = new SqlCommand(sqlUpit, konekcija))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            vlasnici.Add(new Vlasnik
                            (
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetString(2),
                                reader.GetString(3),
                                reader.GetString(4),
                                reader.GetString(5),
                                reader.GetString(6)
                            ));
                        }
                    }
                }
            }

            return vlasnici;
        }

        private void PopuniComboBoxRase()
        {
            rasaOdabir.ItemsSource = FetchRasaPasaData();
            rasaOdabir.DisplayMemberPath = "Naziv";
        }

        public List<Rasa> FetchRasaPasaData()
        {
            List<Rasa> rase = new List<Rasa>();

            using (SqlConnection konekcija = new Konekcija().KreirajKonekciju())
            {
                konekcija.Open();
                string sqlUpit = "SELECT id_rase, naziv_rase FROM RasaPasa";

                using (SqlCommand cmd = new SqlCommand(sqlUpit, konekcija))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            rase.Add(new Rasa
                            (
                                reader.GetInt32(0),
                                reader.GetString(1)
                            ));
                        }
                    }
                }
            }

            return rase;
        }

        public List<Pas> FetchPsi()
        {
            List<Pas> psi = new List<Pas>();

            using (SqlConnection konekcija = new Konekcija().KreirajKonekciju())
            {
                konekcija.Open();
                string sqlUpit = "SELECT id_psa, ime, rasa_id, godine, pol, id_vlasnika FROM Pas";

                using (SqlCommand cmd = new SqlCommand(sqlUpit, konekcija))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            psi.Add(new Pas
                            (
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetInt32(2),
                                reader.GetInt32(3),
                                reader.GetString(4),
                                reader.GetInt32(5)
                            ));
                        }
                    }
                }
            }

            return psi;
        }

        private void BindDataToDataGrid()
        {
            List<Pas> psi = FetchPsi();
            psiPrikaz.ItemsSource = psi;
        }

        private void vlasnici_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid grid = sender as DataGrid;

            if (grid != null && grid.SelectedItem is Pas selektovaniPas)
            {
                imeUnos.Text = selektovaniPas.Ime;
                gidineUnos.Text = selektovaniPas.Godine.ToString();
                polUnos.Text = selektovaniPas.Pol;

                vlasniOdabir.SelectedValue = selektovaniPas.IdVlasnika;

                rasaOdabir.SelectedValue = selektovaniPas.RasaId;
            }
        }

        private bool FormaValidacija()
        {
            if (imeUnos.Text == "" || gidineUnos.Text == "" || polUnos.Text == "" || vlasniOdabir.SelectedValue == null || rasaOdabir.SelectedValue == null)
            {
                return false;
            }

            if (imeUnos.Text.Length < 2 || imeUnos.Text.Length > 20)
            {
                return false;
            }
            else if (int.Parse(gidineUnos.Text) < 1 || int.Parse(gidineUnos.Text) > 20)
            {
                return false;
            }
            else if (polUnos.Text.Trim() != "M" && polUnos.Text.Trim() != "Z")
            {
                MessageBox.Show(polUnos.Text.Trim());

                return false;
            }
            else
            {
                return true;
            }
        }

        private void obrisiBtn_Click(object sender, RoutedEventArgs e)
        {
            Pas selektovaniPas = (Pas)psiPrikaz.SelectedItem;

            if (selektovaniPas == null)
            {
                MessageBox.Show("Molimo selektujte psa koji će biti obrisan.");
                return;
            }

            MessageBoxResult result = MessageBox.Show($"Da li ste sigurni da želite da obrišete psa '{selektovaniPas.Ime}'?", "Potvrda brisanja", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                using (SqlConnection konekcija = new Konekcija().KreirajKonekciju())
                {
                    konekcija.Open();
                    string sqlUpit = @"DELETE FROM Pas WHERE id_psa=@Id";
                    SqlCommand cmd = new SqlCommand(sqlUpit, konekcija);

                    cmd.Parameters.AddWithValue("@Id", selektovaniPas.Id);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Uspesno ste obrisali psa!", "Uspesno brisanje psa", MessageBoxButton.OK, MessageBoxImage.Information);

                imeUnos.Text = "";
                gidineUnos.Text = "";
                polUnos.Text = "";
                vlasniOdabir.SelectedValue = null;
                rasaOdabir.SelectedValue = null;

                BindDataToDataGrid();
            }
        }

        private void izmeniBtn_Click(object sender, RoutedEventArgs e)
        {
            Pas selektovaniPas = (Pas)psiPrikaz.SelectedItem;

            if (selektovaniPas == null)
            {
                MessageBox.Show("Molimo selektujte psa koji će biti izmenjen.");
                return;
            }

            if (FormaValidacija())
            {
                using (SqlConnection konekcija = new Konekcija().KreirajKonekciju())
                {
                    konekcija.Open();

                    string sqlUpit = @"UPDATE Pas SET ime=@Ime, rasa_id=@RasaId, godine=@Godine, pol=@Pol, id_vlasnika=@IdVlasnika WHERE id_psa=@Id";

                    SqlCommand cmd = new SqlCommand(sqlUpit, konekcija);

                    cmd.Parameters.AddWithValue("@Id", ((Pas)psiPrikaz.SelectedItem).Id);
                    cmd.Parameters.AddWithValue("@Ime", imeUnos.Text);
                    cmd.Parameters.AddWithValue("@RasaId", rasaOdabir.SelectedValue);
                    cmd.Parameters.AddWithValue("@Godine", gidineUnos.Text);
                    cmd.Parameters.AddWithValue("@Pol", polUnos.Text);
                    cmd.Parameters.AddWithValue("@IdVlasnika", vlasniOdabir.SelectedValue);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Uspesno ste izmenili psa!", "Uspesno izmenjen pas", MessageBoxButton.OK, MessageBoxImage.Information);

                imeUnos.Text = "";
                gidineUnos.Text = "";
                polUnos.Text = "";
                vlasniOdabir.SelectedValue = null;
                rasaOdabir.SelectedValue = null;

                BindDataToDataGrid();
            }
            else
            {
                MessageBox.Show("Morate popuniti sva polja!", "Greska pri izmeni psa", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void unesiBtn_Click(object sender, RoutedEventArgs e)
        {
            if (FormaValidacija())
            {
                using (SqlConnection konekcija = new Konekcija().KreirajKonekciju())
                {
                    konekcija.Open();

                    string sqlUpit = @"INSERT INTO Pas (ime, rasa_id, godine, pol, id_vlasnika) VALUES (@Ime, @RasaId, @Godine, @Pol, @IdVlasnika)";

                    SqlCommand cmd = new SqlCommand(sqlUpit, konekcija);

                    cmd.Parameters.AddWithValue("@Ime", imeUnos.Text);
                    cmd.Parameters.AddWithValue("@RasaId", rasaOdabir.SelectedValue);
                    cmd.Parameters.AddWithValue("@Godine", gidineUnos.Text);
                    cmd.Parameters.AddWithValue("@Pol", polUnos.Text);
                    cmd.Parameters.AddWithValue("@IdVlasnika", vlasniOdabir.SelectedValue);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Uspesno ste uneli psa!", "Uspesno unosenje psa", MessageBoxButton.OK, MessageBoxImage.Information);

                imeUnos.Text = "";
                gidineUnos.Text = "";
                polUnos.Text = "";
                vlasniOdabir.SelectedValue = null;
                rasaOdabir.SelectedValue = null;

                BindDataToDataGrid();
            }
            else
            {
                MessageBox.Show("Morate popuniti sva polja!", "Greska pri unosu psa", MessageBoxButton.OK, MessageBoxImage.Error);
            }   
        }
    }
}
