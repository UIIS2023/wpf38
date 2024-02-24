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
using static WPFRegistracija.Forme.FrmOcena;
using static WPFRegistracija.Forme.FrmPas;

namespace WPFRegistracija.Forme
{
    /// <summary>
    /// Interaction logic for FrmKomentar.xaml
    /// </summary>
    public partial class FrmKomentar : Window
    {
        public class Komentar
        {
            public int Id { get; set; }
            public string Sadrzaj { get; set; }
            public int IdSudije { get; set; }
            public int IdOcene { get; set; }
            public Komentar(int id, string sadrzaj, int idSudije, int idOcene)
            {
                Id = id;
                Sadrzaj = sadrzaj;
                IdSudije = idSudije;
                IdOcene = idOcene;
            }
        }
        public FrmKomentar()
        {
            InitializeComponent();
            PopuniComboBoxSudije();
            PopuniComboBoxOcene();
            BindDataToDataGrid();
        }

        private void PopuniComboBoxSudije()
        {
            odabirSudije.ItemsSource = FetchSudije();
            odabirSudije.DisplayMemberPath = "Ime";
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

        private void PopuniComboBoxOcene()
        {
            odabirOcene.ItemsSource = FetchOcene();
            odabirOcene.DisplayMemberPath = "Id";
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

        public List<Komentar> FetchKomentari()
        {
            List<Komentar> komentari = new List<Komentar>();

            using (SqlConnection konekcija = new Konekcija().KreirajKonekciju())
            {
                konekcija.Open();
                string sqlUpit = "SELECT id_komentara, sadrzaj, id_sudije, id_ocene FROM Komentar";

                using (SqlCommand cmd = new SqlCommand(sqlUpit, konekcija))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            komentari.Add(new Komentar
                            (
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetInt32(2),
                                reader.GetInt32(3)
                            ));
                        }
                    }
                }
            }

            return komentari;
        }

        private void BindDataToDataGrid()
        {
            List<Komentar> komentari = FetchKomentari();
            komentariPrikaz.ItemsSource = komentari;
        }

        private void vlasnici_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid grid = sender as DataGrid;

            if (grid != null && grid.SelectedItem is Komentar selektovanKomentar)
            {
                komentarUnos.Text = selektovanKomentar.Sadrzaj;

                odabirSudije.SelectedValue = selektovanKomentar.IdSudije;

                odabirOcene.SelectedValue = selektovanKomentar.IdOcene;
            }
        }

        private bool Validacija()
        {
            if (string.IsNullOrEmpty(komentarUnos.Text))
            {
                MessageBox.Show("Morate uneti sadrzaj komentara!");
                return false;
            }

            if (odabirSudije.SelectedItem == null)
            {
                MessageBox.Show("Morate odabrati sudiju!");
                return false;
            }

            if (odabirOcene.SelectedItem == null)
            {
                MessageBox.Show("Morate odabrati ocenu!");
                return false;
            }

            return true;
        }

        private void unesiBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!Validacija())
            {
                return;
            }
            string sadrzaj = komentarUnos.Text;
            int idSudije = (odabirSudije.SelectedItem as Sudija).Id;
            int idOcene = (odabirOcene.SelectedItem as OcenaClass).Id;

            using (SqlConnection konekcija = new Konekcija().KreirajKonekciju())
            {
                try
                {
                    konekcija.Open();
                    string sqlUpit = @"INSERT INTO Komentar (sadrzaj, id_sudije, id_ocene) VALUES (@sadrzaj, @id_sudije, @id_ocene)";

                    SqlCommand cmd = new SqlCommand(sqlUpit, konekcija);

                    cmd.Parameters.AddWithValue("@sadrzaj", sadrzaj);
                    cmd.Parameters.AddWithValue("@id_sudije", idSudije);
                    cmd.Parameters.AddWithValue("@id_ocene", idOcene);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Uspesno ste uneli komentar!");

                    BindDataToDataGrid();
                }
                catch (Exception)
                {
                    MessageBox.Show("Doslo je do greske!");
                }
            }
        }

        private void izmeniBtn_Click(object sender, RoutedEventArgs e)
        {
            // code to update Komentar, do validation and check if row is selected, update values, show success message, or error message, refresh data grid, reset form

            if (!Validacija())
            {
                return;
            }

            if (komentariPrikaz.SelectedItem == null)
            {
                MessageBox.Show("Morate odabrati komentar!");
                return;
            }

            string sadrzaj = komentarUnos.Text;
            int idSudije = (odabirSudije.SelectedItem as Sudija).Id;
            int idOcene = (odabirOcene.SelectedItem as OcenaClass).Id;

            Komentar selektovaniKomentar = komentariPrikaz.SelectedItem as Komentar;

            using (SqlConnection konekcija = new Konekcija().KreirajKonekciju())
            {
                try
                {
                    konekcija.Open();
                    string sqlUpit = @"UPDATE Komentar SET sadrzaj = @sadrzaj, id_sudije = @id_sudije, id_ocene = @id_ocene WHERE id_komentara = @id_komentara";

                    SqlCommand cmd = new SqlCommand(sqlUpit, konekcija);

                    cmd.Parameters.AddWithValue("@sadrzaj", sadrzaj);
                    cmd.Parameters.AddWithValue("@id_sudije", idSudije);
                    cmd.Parameters.AddWithValue("@id_ocene", idOcene);
                    cmd.Parameters.AddWithValue("@id_komentara", selektovaniKomentar.Id);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Uspesno ste izmenili komentar!");
                    BindDataToDataGrid();

                }
                catch (Exception)
                {
                    MessageBox.Show("Doslo je do greske!");
                }
            }
        }

        private void obrisiBtn_Click(object sender, RoutedEventArgs e)
        {
            // code to delete Komentar, do validation and check if row is selected, delete row, show success message, or error message, refresh data grid, reset form, ask for confirmation

            if (komentariPrikaz.SelectedItem == null)
            {
                MessageBox.Show("Morate odabrati komentar!");
                return;
            }

            Komentar selektovaniKomentar = komentariPrikaz.SelectedItem as Komentar;

            MessageBoxResult result = MessageBox.Show("Da li ste sigurni da zelite da obrisete komentar?", "Brisanje komentara", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                    using (SqlConnection konekcija = new Konekcija().KreirajKonekciju())
                    {
                        try
                        {
                            konekcija.Open();
                            string sqlUpit = @"DELETE FROM Komentar WHERE id_komentara = @id_komentara";

                            SqlCommand cmd = new SqlCommand(sqlUpit, konekcija);

                            cmd.Parameters.AddWithValue("@id_komentara", selektovaniKomentar.Id);

                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Uspesno ste obrisali komentar!");
                        BindDataToDataGrid();

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
