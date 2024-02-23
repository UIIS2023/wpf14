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
    /// Interaction logic for FrmTermini.xaml
    /// </summary>
    public partial class FrmTermini : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        private bool azuriraj;
        private DataRowView red;

        public FrmTermini()
        {
            InitializeComponent();
            dpDatum.Focus();
            konekcija = kon.KreirajKonekciju();
            PopuniPadajuceListe();
        }

        public FrmTermini(bool azuriraj, DataRowView red)
        {
            this.azuriraj = azuriraj;
            this.red = red;
            InitializeComponent();
            dpDatum.Focus();
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

                string vratiPacijenta = @"SELECT pacijentID, JMBGPacijenta FROM Pacijent";
                SqlDataAdapter daPacijent = new SqlDataAdapter(vratiPacijenta, konekcija);
                DataTable dtPacijent = new DataTable();
                daPacijent.Fill(dtPacijent);
                cbPacijent.ItemsSource = dtPacijent.DefaultView;
                dtPacijent.Dispose();
                dtPacijent.Dispose();
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
                DateTime date = (DateTime)dpDatum.SelectedDate;
                string datum = date.ToString("yyyy-MM-dd");
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };

                cmd.Parameters.Add("@datum", SqlDbType.DateTime).Value = datum;
                cmd.Parameters.Add("@vreme", SqlDbType.Time).Value = txtVreme.Text;
                cmd.Parameters.Add("@tretman", SqlDbType.Int).Value = cbTretman.SelectedValue;
                cmd.Parameters.Add("@pacijent", SqlDbType.Int).Value = cbPacijent.SelectedValue;

                if (azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update Termin
                                       set datum=@datum, vreme=@vreme, tretmanID=@tretman, pacijentID = @pacijent
                                       where terminID  = @id";
                    red = null;
                }
                else
                {
                    cmd.CommandText = @"insert into Termin(datum, vreme,tretmanID, pacijentID)
                                        VALUES (@datum, @vreme, @tretman, @pacijent)";
                }
                cmd.ExecuteNonQuery(); //ova metoda pokrece izvrsenje nase komande gore
                cmd.Dispose();
                this.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Unos odredjenih vrednosti nije validan", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Odaberite datum", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (FormatException)
            {
                MessageBox.Show("Doslo je do greske prilikom konverzija podataka", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
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
