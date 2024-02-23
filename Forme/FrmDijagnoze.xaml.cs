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
    /// Interaction logic for FrmDijagnoze.xaml
    /// </summary>
    public partial class FrmDijagnoze : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        private bool azuriraj;
        private DataRowView red;

        public FrmDijagnoze()
        {
            InitializeComponent();
            txtNazivDijagnoze.Focus();
            konekcija = kon.KreirajKonekciju();
            PopuniPadajuceListe();
        }

        public FrmDijagnoze(bool azuriraj, DataRowView red)
        {
            this.azuriraj = azuriraj;
            this.red = red;
            InitializeComponent();
            txtNazivDijagnoze.Focus();
            konekcija = kon.KreirajKonekciju();
            PopuniPadajuceListe();
        }

        private void PopuniPadajuceListe()
        {
            try
            {
                konekcija.Open();

                string vratiKorisnika = @"SELECT korisnikID, JMBG FROM Korisnik";
                SqlDataAdapter daKorisnik = new SqlDataAdapter(vratiKorisnika, konekcija);
                DataTable dtKorisnik = new DataTable();
                daKorisnik.Fill(dtKorisnik);
                cbKorisnik.ItemsSource = dtKorisnik.DefaultView;
                dtKorisnik.Dispose();
                dtKorisnik.Dispose();

                string vratiPacijenta = @"SELECT pacijentID, JMBGPacijenta FROM Pacijent";
                SqlDataAdapter daPacijent = new SqlDataAdapter(vratiPacijenta, konekcija);
                DataTable dtPacijent = new DataTable();
                daPacijent.Fill(dtPacijent);
                cbPacijent.ItemsSource = dtPacijent.DefaultView;
                dtPacijent.Dispose();
                dtPacijent.Dispose();

                string vratiEvidenciju = @"SELECT trenutnoStanjeTokaLecenja, evidencijaID FROM Evidencija";
                SqlDataAdapter daEv = new SqlDataAdapter(vratiEvidenciju, konekcija);
                DataTable dtEv = new DataTable();
                daEv.Fill(dtEv);
                cbEvidencija.ItemsSource = dtEv.DefaultView;
                dtEv.Dispose();
                dtEv.Dispose();

                string vratiRacun = @"SELECT ukupnaCena, racunID FROM Racun";
                SqlDataAdapter daRacun = new SqlDataAdapter(vratiRacun, konekcija);
                DataTable dtRacun = new DataTable();
                daRacun.Fill(dtRacun);
                cbRacun.ItemsSource = dtRacun.DefaultView;
                dtRacun.Dispose();
                dtRacun.Dispose();
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

                cmd.Parameters.Add("@naziv", SqlDbType.NVarChar).Value = txtNazivDijagnoze.Text;
                cmd.Parameters.Add("@planLecenja", SqlDbType.NVarChar).Value = txtPlan.Text;
                cmd.Parameters.Add("@korisnik", SqlDbType.Int).Value = cbKorisnik.SelectedValue;
                cmd.Parameters.Add("@pacijent", SqlDbType.Int).Value = cbPacijent.SelectedValue;
                cmd.Parameters.Add("@evidencija", SqlDbType.Int).Value = cbEvidencija.SelectedValue;
                cmd.Parameters.Add("@racun", SqlDbType.Int).Value = cbRacun.SelectedValue;

                if (azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update Dijagnoza
                                       set nazivDijagnoze=@naziv, planLecenja=@planLecenja, korisnikID=@korisnik,
                                        pacijentID = @pacijent, evidencijaID = @evidencija, racunID = @racun
                                       where dijagnozaID  = @id";
                    red = null;
                }
                else
                {
                    cmd.CommandText = @"insert into Dijagnoza(nazivDijagnoze, planLecenja, korisnikID, pacijentID, evidencijaID, racunID)
                                        VALUES (@naziv, @planLecenja, @korisnik, @pacijent, @evidencija, @racun)";
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
