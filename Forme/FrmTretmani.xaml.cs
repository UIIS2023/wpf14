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
    /// Interaction logic for FrmTretmani.xaml
    /// </summary>
    public partial class FrmTretmani : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        private bool azuriraj;
        private DataRowView red;

        public FrmTretmani()
        {
            InitializeComponent();
            txtVrstaTretmana.Focus();
            konekcija = kon.KreirajKonekciju();
        }

        public FrmTretmani(bool azuriraj, DataRowView red)
        {
            this.azuriraj = azuriraj;
            this.red = red;
            InitializeComponent();
            txtVrstaTretmana.Focus();
            konekcija = kon.KreirajKonekciju();
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

                cmd.Parameters.Add("@vrstaTretmana", SqlDbType.NVarChar).Value = txtVrstaTretmana.Text;
                cmd.Parameters.Add("@cenaTretmana", SqlDbType.NVarChar).Value = txtCenaTretmana.Text;

                if (azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update tretman
                                       set vrstaTretmana = @vrstaTretmana, cenaTretmana = @cenaTretmana
                                       where tretmanID  = @id";
                    red = null;
                }
                else
                {

                    cmd.CommandText = @"INSERT INTO Tretman(vrstaTretmana, cenaTretmana)
                                    VALUES (@vrstaTretmana, @cenaTretmana)";
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
