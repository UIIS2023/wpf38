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

namespace WPFRegistracija
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        private SolidColorBrush activeBackgroundColor = new SolidColorBrush(Colors.Blue);
        private SolidColorBrush activeForegroundColor = new SolidColorBrush(Colors.White);
        private SolidColorBrush defaultBackgroundColor = new SolidColorBrush(Colors.LightGray);
        private SolidColorBrush defaultForegroundColor = new SolidColorBrush(Colors.Black);

        static string[] buttonXNames = new string[] { "btnRase", "btnVlasnici", "btnPsi", "btnKomentari", "btnOcene", "btnNagrade" };
        string activeTab = "";
             
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnRase_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            setActiveButton(clickedButton.Name);
            OpenForm();
        }

        private void setActiveButton(string btnXName)
        {
            // Reset all buttons to default style
            foreach (string buttonName in buttonXNames)
            {
                Button btn = this.FindName(buttonName) as Button;
                if (btn != null)
                {
                    btn.Background = defaultBackgroundColor;
                    btn.Foreground = defaultForegroundColor;
                }
            }

            // Set the active button style
            Button activeBtn = this.FindName(btnXName) as Button;
            if (activeBtn != null)
            {
                activeBtn.Background = activeBackgroundColor;
                activeBtn.Foreground = activeForegroundColor;
            }

            // Update the activeTab
            activeTab = btnXName;
        }

        private void btnVlasnici_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            setActiveButton(clickedButton.Name);
            OpenForm();
        }

        private void btnPsi_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            setActiveButton(clickedButton.Name);
            OpenForm();
        }

        private void btnKomentari_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            setActiveButton(clickedButton.Name);
            OpenForm();
        }

        private void btnOcene_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            setActiveButton(clickedButton.Name);
            OpenForm();
        }

        private void OpenForm()
        {
            switch (activeTab)
            {
                case "btnRase":
                    Forme.FrmRasa rasaForma = new Forme.FrmRasa();
                    rasaForma.Show();
                    break;
                case "btnVlasnici":
                    Forme.FrmVlasnikCreate vlasnikForma = new Forme.FrmVlasnikCreate();
                    vlasnikForma.Show();
                    break;
                case "btnPsi":
                    Forme.FrmPas pasForma = new Forme.FrmPas();
                    pasForma.Show();
                    break;
                case "btnKomentari":
                    Forme.FrmKomentar komentarForma = new Forme.FrmKomentar();
                    komentarForma.Show();
                    break;
                case "btnOcene":
                    Forme.FrmOcena ocenaForma = new Forme.FrmOcena();
                    ocenaForma.Show();
                    break;
                default:
                    break;
            }
        }
    }
}
