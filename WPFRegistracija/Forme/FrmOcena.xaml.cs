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
using static WPFRegistracija.Forme.FrmPas;
using static WPFRegistracija.Forme.FrmVlasnikCreate;

namespace WPFRegistracija.Forme
{
    /// <summary>
    /// Interaction logic for FrmOcena.xaml
    /// </summary>
    public partial class FrmOcena : Window
    {
        public class OcenaClass
        {
            public int Id { get; set; }
            public int Ocena { get; set; }
            public int IdPsa { get; set; }
            public int IdSudije { get; set; }
            public OcenaClass(int id, int ocena, int idPsa, int idSudije)
            {
                Id = id;
                Ocena = ocena;
                IdPsa = idPsa;
                IdSudije = idSudije;
            }
        }

        public class Sudija
        {
            public int Id { get; set; }
            public string Ime { get; set; }
            public string Prezime { get; set; }
            public string JMBG { get; set; }
            public Sudija(int id, string ime, string prezime, string jmbg)
            {
                Id = id;
                Ime = ime;
                Prezime = prezime;
                JMBG = jmbg;
            }
        }

        public FrmOcena()
        {
            InitializeComponent();
            PopuniComboBoxPsi();
            PopuniComboBoxSudije();
            BindDataToDataGrid();
        }

        private void PopuniComboBoxPsi()
        {
            pasOdabir.ItemsSource = FetchPsi();
            pasOdabir.DisplayMemberPath = "Ime";
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

        private void PopuniComboBoxSudije()
        {
            sudijaOdabir.ItemsSource = FetchSudije();
            sudijaOdabir.DisplayMemberPath = "Ime";
        }

        public List<Sudija> FetchSudije()
        {
            List<Sudija> sudije = new List<Sudija>();

            using (SqlConnection konekcija = new Konekcija().KreirajKonekciju())
            {
                konekcija.Open();
                string sqlUpit = "SELECT id_sudije, ime, prezime, JMBG FROM Sudija";

                using (SqlCommand cmd = new SqlCommand(sqlUpit, konekcija))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sudije.Add(new Sudija
                            (
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetString(2),
                                reader.GetString(3)
                            ));
                        }
                    }
                }
            }

            return sudije;
        }

        public List<OcenaClass> FetchOcene()
        {
            List<OcenaClass> ocene = new List<OcenaClass>();

            using (SqlConnection konekcija = new Konekcija().KreirajKonekciju())
            {
                konekcija.Open();
                string sqlUpit = "SELECT id_ocene, ocena, id_psa, id_sudije FROM Ocena";

                using (SqlCommand cmd = new SqlCommand(sqlUpit, konekcija))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ocene.Add(new OcenaClass
                            (
                                reader.GetInt32(0),
                                reader.GetInt32(1),
                                reader.GetInt32(2),
                                reader.GetInt32(3)        
                            ));
                        }
                    }
                }
            }

            return ocene;
        }       

        private void BindDataToDataGrid()
        {
            List<OcenaClass> ocene = FetchOcene();
            ocenePrikaz.ItemsSource = ocene;
        }

        private void vlasnici_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid grid = sender as DataGrid;

            if (grid != null && grid.SelectedItem is OcenaClass selektovanaOcena)
            {
                ocenaUnos.Text = selektovanaOcena.Ocena.ToString();

                pasOdabir.SelectedValue = selektovanaOcena.IdPsa;

                sudijaOdabir.SelectedValue = selektovanaOcena.IdSudije;
            }
        }

        private bool ValidateForm()
        {
            if (ocenaUnos.Text == "")
            {
                MessageBox.Show("Molimo unesite ocenu.");
                return false;
            }

            if (pasOdabir.SelectedValue == null)
            {
                MessageBox.Show("Molimo odaberite psa.");
                return false;
            }

            if (sudijaOdabir.SelectedValue == null)
            {
                MessageBox.Show("Molimo odaberite sudiju.");
                return false;
            }

            return true;
        }

        private void unosBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateForm())
            {
                return;
            }

            int ocena = int.Parse(ocenaUnos.Text);
            int idPsa = int.Parse(pasOdabir.SelectedValue.ToString());
            int idSudije = int.Parse(sudijaOdabir.SelectedValue.ToString());

            using (SqlConnection konekcija = new Konekcija().KreirajKonekciju())
            {
                try
                {
                    konekcija.Open();
                    string sqlUpit = @"INSERT INTO Ocena (ocena, id_psa, id_sudije) VALUES (@ocena, @id_psa, @id_sudije)";

                    SqlCommand cmd = new SqlCommand(sqlUpit, konekcija);

                    cmd.Parameters.AddWithValue("@ocena", ocena);
                    cmd.Parameters.AddWithValue("@id_psa", idPsa);
                    cmd.Parameters.AddWithValue("@id_sudije", idSudije);

                    cmd.ExecuteNonQuery();

                    BindDataToDataGrid();

                    ocenaUnos.Text = "";
                    pasOdabir.SelectedValue = null;
                    sudijaOdabir.SelectedValue = null;

                    MessageBox.Show("Uspesno ste uneli ocenu!");
                }
                catch (Exception)
                {
                    MessageBox.Show("Doslo je do greske!");
                }
            }
        }

        private void izmeniBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateForm())
            {
                return;
            }

            OcenaClass selektovanaOcena = (OcenaClass)ocenePrikaz.SelectedItem;

            if (selektovanaOcena == null)
            {
                MessageBox.Show("Molimo selektujte ocenu koja će biti izmenjena.");
                return;
            }

            int ocena = int.Parse(ocenaUnos.Text);
            int idPsa = (int)pasOdabir.SelectedValue;
            int idSudije = (int)sudijaOdabir.SelectedValue;

            using (SqlConnection konekcija = new Konekcija().KreirajKonekciju())
            {
                try
                {
                    konekcija.Open();
                    string sqlUpit = @"UPDATE Ocena SET ocena = @ocena, id_psa = @id_psa, id_sudije = @id_sudije WHERE id_ocene = @id_ocene";

                    SqlCommand cmd = new SqlCommand(sqlUpit, konekcija);

                    cmd.Parameters.AddWithValue("@ocena", ocena);
                    cmd.Parameters.AddWithValue("@id_psa", idPsa);
                    cmd.Parameters.AddWithValue("@id_sudije", idSudije);
                    cmd.Parameters.AddWithValue("@id_ocene", selektovanaOcena.Id);

                    cmd.ExecuteNonQuery();

                    BindDataToDataGrid();

                    ocenaUnos.Text = "";
                    pasOdabir.SelectedValue = null;
                    sudijaOdabir.SelectedValue = null;

                    MessageBox.Show("Uspesno ste izmenili ocenu!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Doslo je do greske!");
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void obrisiBtn_Click(object sender, RoutedEventArgs e)
        {

            OcenaClass selektovanaOcena = (OcenaClass)ocenePrikaz.SelectedItem;

            if (selektovanaOcena == null)
            {
                MessageBox.Show("Molimo selektujte ocenu koja će biti obrisana.");
                return;
            }

            MessageBoxResult result = MessageBox.Show($"Da li ste sigurni da želite da obrišete ocenu?", "Potvrda brisanja", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                using (SqlConnection konekcija = new Konekcija().KreirajKonekciju())
                {
                    try
                    {
                        konekcija.Open();
                        string sqlUpit = @"DELETE FROM Ocena WHERE id_ocene = @id_ocene";

                        SqlCommand cmd = new SqlCommand(sqlUpit, konekcija);

                        cmd.Parameters.AddWithValue("@id_ocene", selektovanaOcena.Id);

                        cmd.ExecuteNonQuery();

                        BindDataToDataGrid();

                        ocenaUnos.Text = "";
                        pasOdabir.SelectedValue = null;
                        sudijaOdabir.SelectedValue = null;

                        MessageBox.Show("Uspesno ste obrisali ocenu!");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Doslo je do greske!");
                    }
                }
            }
        }
    }
}
