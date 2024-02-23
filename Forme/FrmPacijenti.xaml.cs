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
{ public partial class FrmPacijenti : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        private bool azuriraj;
        private DataRowView red;

        public FrmPacijenti()
        {
            InitializeComponent();
            txtIme.Focus();
            konekcija = kon.KreirajKonekciju();
            PopuniPadajuceListe();
        }
        public FrmPacijenti(bool azuriraj, DataRowView red)
        {
            this.azuriraj = azuriraj;
            this.red = red;
            InitializeComponent();
            txtIme.Focus();
            konekcija = kon.KreirajKonekciju();
            PopuniPadajuceListe();
        }
        private void PopuniPadajuceListe()
        {
            try
            {
                konekcija.Open();

                string vratiTretman = @"SELECT tretmanID, vrstaTretmana FROM Tretman";
                SqlDataAdapter daTretman = new SqlDataAdapter(vratiTretman, konekcija);
                DataTable dtTretman = new DataTable();
                daTretman.Fill(dtTretman);
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

                cmd.Parameters.Add("@ime", SqlDbType.NVarChar).Value = txtIme.Text;
                cmd.Parameters.Add("@prezime", SqlDbType.NVarChar).Value = txtPrezime.Text;
                cmd.Parameters.Add("@jmbg", SqlDbType.NChar).Value = txtJmbg.Text;
                cmd.Parameters.Add("@kontakt", SqlDbType.NChar).Value = txtKontakt.Text;
                cmd.Parameters.Add("@adresa", SqlDbType.NVarChar).Value = txtAdresa.Text;
                cmd.Parameters.Add("@grad", SqlDbType.NVarChar).Value = txtGrad.Text;
                cmd.Parameters.Add("@tretman", SqlDbType.Int).Value = cbTretman.SelectedValue;

                if (azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update Pacijent
                                       set imePacijenta = @ime, prezimePacijenta = @prezime, JMBGPacijenta = @jmbg,
                                        kontaktPacijenta = @kontakt, adresaPacijenta = @adresa, gradPacijenta = @grad, tretmanID = @tretman
                                       where pacijentID  = @id";
                    red = null;
                }
                else
                {

                    cmd.CommandText = @"insert into Pacijent(imePacijenta, prezimePacijenta, JMBGPacijenta, 
                                    kontaktPacijenta, adresaPacijenta, gradPacijenta, tretmanID)
                                    VALUES (@ime, @prezime, @jmbg, @kontakt, @adresa, @grad, @tretman)";
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
