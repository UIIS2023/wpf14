﻿using System;
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
    /// Interaction logic for FrmKorisnici.xaml
    /// </summary>
    public partial class FrmOsiguranja : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        private bool azuriraj;
        private DataRowView red;

        public FrmOsiguranja()
        {
            InitializeComponent();
            txtVrstaOsiguranja.Focus();
            konekcija = kon.KreirajKonekciju();
        }

        public FrmOsiguranja(bool azuriraj, DataRowView red)
        {
            this.azuriraj = azuriraj;
            this.red = red;
            InitializeComponent();
            txtVrstaOsiguranja.Focus();
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

                cmd.Parameters.Add("@vrstaOsiguranja", SqlDbType.NVarChar).Value = txtVrstaOsiguranja.Text;

                if (azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update Osiguranje
                                       set vrstaOsiguranja = @vrstaOsiguranja
                                       where osiguranjeID  = @id";
                    red = null;
                }
                else
                {

                    cmd.CommandText = @"INSERT INTO Osiguranje(vrstaOsiguranja)
                                    VALUES (@vrstaOsiguranja)";
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
