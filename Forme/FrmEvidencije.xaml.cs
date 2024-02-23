using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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

namespace Zubna_ordinacija.Forme
{
    /// <summary>
    /// Interaction logic for FrmEvidencije.xaml
    /// </summary>
    public partial class FrmEvidencije : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        private bool azuriraj;
        private DataRowView red;

        public FrmEvidencije()
        {
            InitializeComponent();
            txtTokLecenja.Focus();
            konekcija = kon.KreirajKonekciju();
            PopuniPadajuceListe();
        }

        public FrmEvidencije(bool azuriraj, DataRowView red)
        {
            this.azuriraj = azuriraj;
            this.red = red;
            InitializeComponent();
            txtTokLecenja.Focus();
            konekcija = kon.KreirajKonekciju();
            PopuniPadajuceListe();
        }

        private void PopuniPadajuceListe()
        {
            try
            {
                konekcija.Open();

                string vratiTretman = @"SELECT tretmanID, vrstaTretmana FROM Tretman";
                SqlDataAdapter daMarka = new SqlDataAdapter(vratiTretman, konekcija);
                DataTable dtTretman = new DataTable();
                daMarka.Fill(dtTretman);
                cbTretman.ItemsSource = dtTretman.DefaultView;
                dtTretman.Dispose();
                dtTretman.Dispose();
            }
            catch (SqlException)
            {
                MessageBox.Show("Padajuce liste nisu popunjene", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };

                cmd.Parameters.Add("@tokLecenja", SqlDbType.NVarChar).Value = txtTokLecenja.Text;
                cmd.Parameters.Add("@tretman", SqlDbType.Int).Value = cbTretman.SelectedValue;

                if (azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update Evidencija
                                       set trenutnoStanjeTokaLecenja = @tokLecenja, tretmanID = @tretman
                                       where evidencijaID  = @id";
                    red = null;
                }
                else
                {

                    cmd.CommandText = @"INSERT INTO Evidencija(trenutnoStanjeTokaLecenja, tretmanID)
                                    VALUES (@tokLecenja, @tretman)";
                }
                cmd.ExecuteNonQuery(); //ova metoda pokrece izvrsenje nase komande gore
                cmd.Dispose();
                this.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Unos odredjenih vrednosti nije validan", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }

        private void btnOtkazi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
