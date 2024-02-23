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
    /// Interaction logic for FrmRacuni.xaml
    /// </summary>
    public partial class FrmRacuni : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        private bool azuriraj;
        private DataRowView red;

        public FrmRacuni()
        {
            InitializeComponent();
            txtNacinPlacanja.Focus();
            konekcija = kon.KreirajKonekciju();
            PopuniPadajuceListe();
        }

        public FrmRacuni(bool azuriraj, DataRowView red)
        {
            this.azuriraj = azuriraj;
            this.red = red;
            InitializeComponent();
            txtNacinPlacanja.Focus();
            konekcija = kon.KreirajKonekciju();
            PopuniPadajuceListe();
        }

        private void PopuniPadajuceListe()
        {
            try
            {
                konekcija.Open();

                string vratiOsiguranje = @"SELECT osiguranjeID, vrstaOsiguranja FROM Osiguranje";
                SqlDataAdapter daOsiguranje = new SqlDataAdapter(vratiOsiguranje, konekcija);
                DataTable dtOsiguranje = new DataTable();
                daOsiguranje.Fill(dtOsiguranje);
                cbOsiguranje.ItemsSource = dtOsiguranje.DefaultView;
                dtOsiguranje.Dispose();
                dtOsiguranje.Dispose();
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

                cmd.Parameters.Add("@nacinPlacanja", SqlDbType.NVarChar).Value = txtNacinPlacanja.Text;
                cmd.Parameters.Add("@ukupnaCena", SqlDbType.NVarChar).Value = txtUkupnaCena.Text;
                cmd.Parameters.Add("@osiguranjeID", SqlDbType.Int).Value = cbOsiguranje.SelectedValue;

                if (azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update Racun
                                       set nacinPlacanja = @nacinPlacanja, ukupnaCena = @ukupnaCena, osiguranjeID = @osiguranjeID
                                       where racunID  = @id";
                    red = null;
                }
                else
                {

                    cmd.CommandText = @"INSERT INTO Racun(nacinPlacanja, ukupnaCena, osiguranjeID)
                                    VALUES (@nacinPlacanja, @ukupnaCena, @osiguranjeID)";
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
