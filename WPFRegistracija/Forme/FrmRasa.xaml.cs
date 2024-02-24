using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
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

namespace WPFRegistracija.Forme
{
    /// <summary>
    /// Interaction logic for FrmModel.xaml
    /// </summary>
    public partial class FrmRasa : Window
    {
        Rasa selectedRasa;
        public FrmRasa()
        {
            InitializeComponent();
            BindDataToDataGrid();
        }

        public class Rasa
        {
            public int Id { get; set; } 
            public string Naziv { get; set; }

            public Rasa(int id, string naziv)
            {
                Id = id;
                Naziv = naziv;
            }
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

        public void BindDataToDataGrid()
        {
            List<Rasa> raseData = FetchRasaPasaData();
            rasePrikaz.ItemsSource = raseData;
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            string nazivRase = unosRase.Text;

            using (SqlConnection konekcija = new Konekcija().KreirajKonekciju())
            {
                try
                {
                    konekcija.Open();

                    // Provera da li rasa već postoji
                    string sqlProvera = "SELECT COUNT(1) FROM RasaPasa WHERE naziv_rase = @nazivRase";
                    using (SqlCommand cmdProvera = new SqlCommand(sqlProvera, konekcija))
                    {
                        cmdProvera.Parameters.AddWithValue("@nazivRase", nazivRase);
                        int exists = (int)cmdProvera.ExecuteScalar();

                        if (exists > 0)
                        {
                            MessageBox.Show("Rasa već postoji u bazi.");
                            return; // Prekini dalji upis
                        }
                    }

                    // Upis nove rase jer ne postoji
                    string sqlUpit = "INSERT INTO RasaPasa (naziv_rase) VALUES (@nazivRase)";
                    using (SqlCommand cmd = new SqlCommand(sqlUpit, konekcija))
                    {
                        cmd.Parameters.AddWithValue("@nazivRase", nazivRase);
                        cmd.ExecuteNonQuery();
                    }

                    unosRase.Text = "";
                    MessageBox.Show("Uspesno je dodata rasa");
                    BindDataToDataGrid();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    MessageBox.Show("Greška pri upisu rase");
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (konekcija.State == System.Data.ConnectionState.Open)
                    {
                        konekcija.Close(); 
                    }
                }
            }
        }

        private void btnOtkazi_Click(object sender, RoutedEventArgs e)
        {
            if (selectedRasa == null)
            {
                MessageBox.Show("Izaberi rasu za izmenu.");
                return;
            }

            if (unosRase.Text != selectedRasa.Naziv)
            {
                // The name has changed, perform the update
                using (SqlConnection konekcija = new Konekcija().KreirajKonekciju())
                {
                    konekcija.Open();
                    string sqlUpit = "UPDATE RasaPasa SET naziv_rase = @nazivRase WHERE id_rase = @idRase";

                    using (SqlCommand cmd = new SqlCommand(sqlUpit, konekcija))
                    {
                        cmd.Parameters.AddWithValue("@nazivRase", unosRase.Text);
                        cmd.Parameters.AddWithValue("@idRase", selectedRasa.Id);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Rasa je uspesno izmenjena.");
                            // Refresh DataGrid after update
                            BindDataToDataGrid();
                        }
                        else
                        {
                            MessageBox.Show("Greska pri izmeni rase.");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Nisu napravljene promene u imenu.");
            }

            selectedRasa = null;
        }

        private void rasePrikaz_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (rasePrikaz.SelectedItem is Rasa rasa)
            {
                unosRase.Text = rasa.Naziv;
                selectedRasa = rasa; 
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (rasePrikaz.SelectedItem is Rasa selectedRasa)
            {
                // Potvrda za brisanje
                MessageBoxResult messageBoxResult = MessageBox.Show($"Da li ste sigurni da zelite da izbrisete rasu: '{selectedRasa.Naziv}'?", "Potvrda brisanja", MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    using (SqlConnection konekcija = new Konekcija().KreirajKonekciju())
                    {
                        konekcija.Open();
                        string sqlUpit = "DELETE FROM RasaPasa WHERE id_rase = @id_rase";

                        using (SqlCommand cmd = new SqlCommand(sqlUpit, konekcija))
                        {
                            // obrisi po id
                            cmd.Parameters.AddWithValue("@id_rase", selectedRasa.Id);
                            int result = cmd.ExecuteNonQuery();

                            if (result > 0)
                            {
                                MessageBox.Show("Rasa je uspesno obrisana.");
                                // osvezi grid
                                BindDataToDataGrid();
                            }
                            else
                            {
                                MessageBox.Show("Greska pri brisanju rase.");
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an item to delete.");
            }

            selectedRasa = null;
        }
    }
}