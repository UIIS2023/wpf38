using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace WPFRegistracija.Forme
{
    /// <summary>
    /// Interaction logic for FrmVlasnikCreate.xaml
    /// </summary>
    public partial class FrmVlasnikCreate : Window
    {
        private Vlasnik selectedVlasnik = null;
        public class Vlasnik
        {
            public int Id { get; set; }
            public string Ime { get; set; }
            public string Prezime { get; set; }
            public string Adresa { get; set; }
            public string Telefon { get; set; }
            public string Email { get; set; }
            public string JMBG { get; set; }


            public Vlasnik(int id, string ime, string prezime, string adresa, string telefon, string email, string JMBG)
            {
                Id = id;
                Ime = ime;
                Prezime = prezime;
                Adresa = adresa;
                Telefon = telefon;
                Email = email;
                this.JMBG = JMBG;
            }

            public string PunoIme
            {
                get { return Ime + " " + Prezime; }
            }
        }
        public FrmVlasnikCreate()
        {
            InitializeComponent();
            BindDataToDataGrid();
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

        public void BindDataToDataGrid()
        {
            List<Vlasnik> vlasnici = FetchVlasnici();
            vlasniciPrikaz.ItemsSource = vlasnici;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string ime = imeUnos.Text.Trim();
            string prezime = prezimeUnos.Text.Trim();
            string adresa = adresaUnos.Text.Trim();
            string telefon = telefonUnos.Text.Trim();
            string email = emailUnos.Text.Trim();
            string jmbg = JMBGUnos.Text.Trim();

            if (!ValidirajFormu(ime, prezime, adresa, telefon, email, jmbg))
            {
                return;
            }

            using (SqlConnection konekcija = new Konekcija().KreirajKonekciju())
            {
                try
                {
                    konekcija.Open();
                    string sqlUpit = @"
                    INSERT INTO Vlasnik (ime, prezime, adresa, telefon, email, JMBG) 
                    VALUES (@Ime, @Prezime, @Adresa, @Telefon, @Email, @JMBG)";

                    using (SqlCommand cmd = new SqlCommand(sqlUpit, konekcija))
                    {
                        cmd.Parameters.AddWithValue("@Ime", ime);
                        cmd.Parameters.AddWithValue("@Prezime", prezime);
                        cmd.Parameters.AddWithValue("@Adresa", adresa);
                        cmd.Parameters.AddWithValue("@Telefon", telefon);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@JMBG", jmbg);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Vlasnik je uspešno dodat.");
                            BindDataToDataGrid();
                        }
                        else
                        {
                            MessageBox.Show("Došlo je do greške prilikom dodavanja vlasnika.");
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Greška u bazi podataka: {ex.Message}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Greška: {ex.Message}");
                }
            }

        }

        private void vlasnici_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var grid = sender as DataGrid;

            // Make sure there's a selected item
            if (grid != null && grid.SelectedItems.Count > 0)
            {
                // Get selected item
                Vlasnik vlasnik = grid.SelectedItem as Vlasnik;
                if (vlasnik != null)
                {
                    // Set values to the text boxes
                    imeUnos.Text = vlasnik.Ime;
                    prezimeUnos.Text = vlasnik.Prezime;
                    adresaUnos.Text = vlasnik.Adresa;
                    telefonUnos.Text = vlasnik.Telefon;
                    emailUnos.Text = vlasnik.Email;
                    JMBGUnos.Text = vlasnik.JMBG;

                    // Remember the selected Vlasnik
                    selectedVlasnik = vlasnik;
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (selectedVlasnik == null)
            {
                MessageBox.Show("Molimo selektujte vlasnika za ažuriranje.");
                return;
            }

            string novoIme = imeUnos.Text.Trim();
            string novoPrezime = prezimeUnos.Text.Trim();
            string novaAdresa = adresaUnos.Text.Trim();
            string noviTelefon = telefonUnos.Text.Trim();
            string noviEmail = emailUnos.Text.Trim();
            string noviJMBG = JMBGUnos.Text.Trim();


            // Validacija unetih podataka
            if (!ValidirajFormu(novoIme, novoPrezime, novaAdresa, noviTelefon, noviEmail, noviJMBG))
            {
                return;
            }

            if (novoIme == selectedVlasnik.Ime && novoPrezime == selectedVlasnik.Prezime &&
                novaAdresa == selectedVlasnik.Adresa && noviTelefon == selectedVlasnik.Telefon &&
                noviEmail == selectedVlasnik.Email && noviJMBG == selectedVlasnik.JMBG)
            {
                MessageBox.Show("Nema promenjenih podataka.");
                return;
            }

            // Ažuriranje podataka u bazi
            using (SqlConnection konekcija = new Konekcija().KreirajKonekciju())
            {
                try
                {
                    konekcija.Open();
                    string sqlUpit = @"
                UPDATE Vlasnik
                SET ime = @Ime, prezime = @Prezime, adresa = @Adresa, 
                    telefon = @Telefon, email = @Email, JMBG = @JMBG
                WHERE id_vlasnika = @Id";

                    using (SqlCommand cmd = new SqlCommand(sqlUpit, konekcija))
                    {
                        cmd.Parameters.AddWithValue("@Ime", novoIme);
                        cmd.Parameters.AddWithValue("@Prezime", novoPrezime);
                        cmd.Parameters.AddWithValue("@Adresa", novaAdresa);
                        cmd.Parameters.AddWithValue("@Telefon", noviTelefon);
                        cmd.Parameters.AddWithValue("@Email", noviEmail);
                        cmd.Parameters.AddWithValue("@JMBG", noviJMBG);
                        cmd.Parameters.AddWithValue("@Id", selectedVlasnik.Id);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Podaci o vlasniku su uspešno ažurirani.");
                            // Osvežite DataGrid da prikažete izmenjene podatke
                            BindDataToDataGrid();
                        }
                        else
                        {
                            MessageBox.Show("Došlo je do greške prilikom ažuriranja podataka.");
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Greška u bazi podataka: {ex.Message}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Greška: {ex.Message}");
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (vlasniciPrikaz.SelectedItem is Vlasnik selektovaniVlasnik)
            {
                MessageBoxResult dialogResult = MessageBox.Show("Da li ste sigurni da želite da obrišete selektovanog vlasnika?", "Potvrda brisanja", MessageBoxButton.YesNo);
                if (dialogResult == MessageBoxResult.Yes)
                {
                    using (SqlConnection konekcija = new Konekcija().KreirajKonekciju())
                    {
                        try
                        {
                            konekcija.Open();
                            string sqlUpit = "DELETE FROM Vlasnik WHERE id_vlasnika = @IdVlasnika";
                            using (SqlCommand cmd = new SqlCommand(sqlUpit, konekcija))
                            {
                                cmd.Parameters.AddWithValue("@IdVlasnika", selektovaniVlasnik.Id);

                                int result = cmd.ExecuteNonQuery();

                                if (result > 0)
                                {
                                    MessageBox.Show("Vlasnik je uspešno obrisan.");
                                    BindDataToDataGrid();
                                }
                                else
                                {
                                    MessageBox.Show("Došlo je do greške prilikom brisanja vlasnika.");
                                }
                            }
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show($"Greška u bazi podataka: {ex.Message}");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Greška: {ex.Message}");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Molimo selektujte vlasnika koji će biti obrisan.");
            }
        }

        private bool ValidirajFormu(string ime, string prezime, string adresa, string telefon, string email, string jmbg)
        {
            if (string.IsNullOrWhiteSpace(ime) || string.IsNullOrWhiteSpace(prezime) ||
                string.IsNullOrWhiteSpace(adresa) || string.IsNullOrWhiteSpace(telefon) ||
                string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(jmbg))
            {
                MessageBox.Show("Sva polja moraju biti popunjena.");
                return false;
            }

            string emailPattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
            string telefonPattern = @"^\+?\d{0,13}$"; 

            if (ime.Length < 2 || ime.Length > 10 || !ime.All(Char.IsLetter))
            {
                MessageBox.Show("Ime mora imati između 2 i 10 slova.");
                return false;
            }
            if (prezime.Length < 2 || prezime.Length > 10 || !prezime.All(Char.IsLetter))
            {
                MessageBox.Show("Prezime mora imati između 2 i 10 slova.");
                return false ;
            }

            if (adresa.Length < 5 || adresa.Length > 50)
            {
                MessageBox.Show("Adresa mora imati između 5 i 50 karaktera.");
                return false;
            }

            if (jmbg.Length != 13 || !jmbg.All(Char.IsDigit))
            {
                MessageBox.Show("JMBG mora imati tačno 13 cifara.");
                return false;
            }

            if (!Regex.IsMatch(email, emailPattern))
            {
                MessageBox.Show("Email nije u ispravnom formatu.");
                return false;
            }

            if (!Regex.IsMatch(telefon, telefonPattern))
            {
                MessageBox.Show("Telefon nije u ispravnom formatu.");
                return false;
            }

            return true;
        }
    }
}
