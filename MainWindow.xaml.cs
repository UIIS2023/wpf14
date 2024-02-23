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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO.Packaging;
using System.Windows.Xps.Serialization;
using Zubna_ordinacija.Forme;
using System.Windows.Media.Effects;

namespace Zubna_ordinacija
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string ucitanaTabela;
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        private bool azuriraj;
        private DataRowView red;

        #region Select upiti
        private static string osiguranjaSelect = @"select osiguranjeID as ID, vrstaOsiguranja  from Osiguranje";
        private static string racuniSelect = @"select racunID as ID, nacinPlacanja as 'Nacin placanja', ukupnaCena as 'Ukupna cena', osiguranjeID as 'Osiguranje ID'  from Racun";
        private static string korisniciSelect = @"select korisnikID as ID, ime + ' ' + prezime as 'Ime i prezime korisnika', JMBG, kontakt, adresa, grad from Korisnik";
        private static string tretmaniSelect = @"select tretmanID as ID, vrstaTretmana as 'Vrsta tretmana', cenaTretmana as 'Cena tretmana' from Tretman";
        private static string evidencijeSelect = @"select evidencijaID as ID, trenutnoStanjeTokaLecenja as 'Trenutno stanje lecenja', tretmanID as 'Tretman ID' from Evidencija";
        private static string pacijentiSelect = @"select pacijentID as ID, imePacijenta + ' ' + prezimePacijenta as 'Ime i prezime pacijenta', 
                                            JMBGPacijenta as 'JMBG', kontaktPacijenta as 'Kontakt', adresaPacijenta as 'Adresa', gradPacijenta as 'Grad', tretmanID as 'Tretman ID' from Pacijent";
        private static string terminiSelect = @"SELECT terminID as ID, FORMAT(datum, 'yyyy-MM-dd') as Datum,  CONVERT(VARCHAR, DATEADD(MINUTE, 
                                            DATEDIFF(MINUTE, 0, vreme) / 15 * 15, 0), 108) AS Vreme, tretmanID as 'Tretman ID', pacijentID as 'Pacijent ID' from Termin";
        private static string dijagnozeSelect = @"select dijagnozaID as ID, nazivDijagnoze as 'Dijagnoza', ime +' '+ prezime as 'Lekar',
                                                imePacijenta +' ' + prezimePacijenta as 'Pacijent',
                                                trenutnoStanjeTokaLecenja as 'Stanje lecenja', ukupnaCena as 'Cena lecenja', osiguranjeID as 'ID osiguranja'
                                                from Dijagnoza join Korisnik on Dijagnoza.korisnikID = Korisnik.korisnikID
			                                                join Pacijent on Dijagnoza.pacijentID = Pacijent.pacijentID
			                                                join Evidencija on Dijagnoza.evidencijaID = Evidencija.evidencijaID
			                                                join Racun on Dijagnoza.racunID = Racun.racunID";
        #endregion

        #region Select sa uslovom

        private static string selectUslovOsiguranja = @"select * from Osiguranje where osiguranjeID=";
        private static string selectUslovRacuni = @"select * from Racun where racunID=";
        private static string selectUslovKorisnici = @"select * from Korisnik where korisnikID=";
        private static string selectUslovTretmani = @"select * from Tretman where tretmanID=";
        private static string selectUslovEvidencije = @"select * from Evidencija where evidencijaID=";
        private static string selectUslovPacijenti = @"select * from Pacijent where pacijentID=";
        private static string selectUslovTermini = @"select * from Termin where terminID=";
        private static string selectUslovDijagnoze = @"select * from Dijagnoza where dijagnozaID=";

        #endregion

        #region Delete naredbe

        private static string deleteOsiguranja = @"delete from Osiguranje where osiguranjeID=";
        private static string deleteRacuni = @"delete from Racun where racunID=";
        private static string deleteKorisnici = @"delete from Korisnik where korisnikID=";
        private static string deleteTretmani = @"delete from Tretman where tretmanID=";
        private static string deleteEvidencije = @"delete from Evidencija where evidencijaID=";
        private static string deletePacijenti = @"delete from Pacijent where pacijentID=";
        private static string deleteTermini = @"delete from Termin where terminID=";
        private static string deleteDijagnoze = @"delete from Dijagnoza where dijagnozaID=";

        #endregion

        public MainWindow()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju(); //bitno
            UcitajPodatke(korisniciSelect);
            btnKorisnici.FontWeight = FontWeights.Bold;
        }

        private void UcitajPodatke(string selectUpit)
        {
            try
            {   
                konekcija.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(selectUpit, konekcija);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                if (dataGridCentralni != null)
                {
                    dataGridCentralni.ItemsSource = dataTable.DefaultView;
                }
                ucitanaTabela = selectUpit; 
                dataAdapter.Dispose();
                dataTable.Dispose();

            }
            catch (SqlException)
            {
                MessageBox.Show("Neuspesno ucitani podaci!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }

        private void btnOsiguranja_Click(object sender, RoutedEventArgs e)
        {
            btnOsiguranja.FontWeight = FontWeights.Bold;
            btnPacijenti.FontWeight = FontWeights.Regular;
            btnRacuni.FontWeight = FontWeights.Regular;
            btnDijagnoze.FontWeight = FontWeights.Regular;
            btnEvidencije.FontWeight = FontWeights.Regular;
            btnTretmani.FontWeight = FontWeights.Regular;
            btnTermini.FontWeight = FontWeights.Regular;
            btnKorisnici.FontWeight = FontWeights.Regular;

            UcitajPodatke(osiguranjaSelect);
        }

        private void btnRacuni_Click(object sender, RoutedEventArgs e)
        {
            btnOsiguranja.FontWeight = FontWeights.Regular;
            btnPacijenti.FontWeight = FontWeights.Regular;
            btnRacuni.FontWeight = FontWeights.Bold;
            btnDijagnoze.FontWeight = FontWeights.Regular;
            btnEvidencije.FontWeight = FontWeights.Regular;
            btnTretmani.FontWeight = FontWeights.Regular;
            btnTermini.FontWeight = FontWeights.Regular;
            btnKorisnici.FontWeight = FontWeights.Regular;

            UcitajPodatke(racuniSelect);
        }

        private void btnKorisnici_Click(object sender, RoutedEventArgs e)
        {
            btnKorisnici.FontWeight = FontWeights.Bold;
            btnOsiguranja.FontWeight = FontWeights.Regular;
            btnPacijenti.FontWeight = FontWeights.Regular;
            btnRacuni.FontWeight = FontWeights.Regular;
            btnDijagnoze.FontWeight = FontWeights.Regular;
            btnEvidencije.FontWeight = FontWeights.Regular;
            btnTretmani.FontWeight = FontWeights.Regular;
            btnTermini.FontWeight = FontWeights.Regular;

            UcitajPodatke(korisniciSelect);
        }

        private void btnPacijenti_Click(object sender, RoutedEventArgs e)
        {
            btnKorisnici.FontWeight = FontWeights.Regular;
            btnOsiguranja.FontWeight = FontWeights.Regular;
            btnPacijenti.FontWeight = FontWeights.Bold;
            btnRacuni.FontWeight = FontWeights.Regular;
            btnDijagnoze.FontWeight = FontWeights.Regular;
            btnEvidencije.FontWeight = FontWeights.Regular;
            btnTretmani.FontWeight = FontWeights.Regular;
            btnTermini.FontWeight = FontWeights.Regular;

            UcitajPodatke(pacijentiSelect);
        }

        private void btnTretmani_Click(object sender, RoutedEventArgs e)
        {
            btnKorisnici.FontWeight = FontWeights.Regular;
            btnOsiguranja.FontWeight = FontWeights.Regular;
            btnPacijenti.FontWeight = FontWeights.Regular;
            btnRacuni.FontWeight = FontWeights.Regular;
            btnDijagnoze.FontWeight = FontWeights.Regular;
            btnEvidencije.FontWeight = FontWeights.Regular;
            btnTretmani.FontWeight = FontWeights.Bold;
            btnTermini.FontWeight = FontWeights.Regular;

            UcitajPodatke(tretmaniSelect);
        }

        private void btnTermini_Click(object sender, RoutedEventArgs e)
        {
            btnKorisnici.FontWeight = FontWeights.Regular;
            btnOsiguranja.FontWeight = FontWeights.Regular;
            btnPacijenti.FontWeight = FontWeights.Regular;
            btnRacuni.FontWeight = FontWeights.Regular;
            btnDijagnoze.FontWeight = FontWeights.Regular;
            btnEvidencije.FontWeight = FontWeights.Regular;
            btnTretmani.FontWeight = FontWeights.Regular;
            btnTermini.FontWeight = FontWeights.Bold;

            UcitajPodatke(terminiSelect);
        }

        private void btnEvidencije_Click(object sender, RoutedEventArgs e)
        {
            btnKorisnici.FontWeight = FontWeights.Regular;
            btnOsiguranja.FontWeight = FontWeights.Regular;
            btnPacijenti.FontWeight = FontWeights.Regular;
            btnRacuni.FontWeight = FontWeights.Regular;
            btnDijagnoze.FontWeight = FontWeights.Regular;
            btnEvidencije.FontWeight = FontWeights.Bold;
            btnTretmani.FontWeight = FontWeights.Regular;
            btnTermini.FontWeight = FontWeights.Regular;

            UcitajPodatke(evidencijeSelect);
        }

        private void btnDijagnoze_Click(object sender, RoutedEventArgs e)
        {
            btnKorisnici.FontWeight = FontWeights.Regular;
            btnOsiguranja.FontWeight = FontWeights.Regular;
            btnPacijenti.FontWeight = FontWeights.Regular;
            btnRacuni.FontWeight = FontWeights.Regular;
            btnDijagnoze.FontWeight = FontWeights.Bold;
            btnEvidencije.FontWeight = FontWeights.Regular;
            btnTretmani.FontWeight = FontWeights.Regular;
            btnTermini.FontWeight = FontWeights.Regular;

            UcitajPodatke(dijagnozeSelect);
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            Window prozor;
            if (ucitanaTabela.Equals(osiguranjaSelect))
            {
                prozor = new FrmOsiguranja();
                prozor.ShowDialog();
                UcitajPodatke(osiguranjaSelect);
            }
            else if (ucitanaTabela.Equals(racuniSelect))
            {
                prozor = new FrmRacuni();
                prozor.ShowDialog();
                UcitajPodatke(racuniSelect);
            }
            else if (ucitanaTabela.Equals(korisniciSelect))
            {
                prozor = new FrmKorisnici();
                prozor.ShowDialog();
                UcitajPodatke(korisniciSelect);
            }
            else if (ucitanaTabela.Equals(tretmaniSelect))
            {
                prozor = new FrmTretmani();
                prozor.ShowDialog();
                UcitajPodatke(tretmaniSelect);
            }
            else if (ucitanaTabela.Equals(evidencijeSelect))
            {
                prozor = new FrmEvidencije();
                prozor.ShowDialog();
                UcitajPodatke(evidencijeSelect);
            }
            else if (ucitanaTabela.Equals(pacijentiSelect))
            {
                prozor = new FrmPacijenti();
                prozor.ShowDialog();
                UcitajPodatke(pacijentiSelect);
            }
            else if (ucitanaTabela.Equals(terminiSelect))
            {
                prozor = new FrmTermini();
                prozor.ShowDialog();
                UcitajPodatke(terminiSelect);
            }
            else if (ucitanaTabela.Equals(dijagnozeSelect))
            {
                prozor = new FrmDijagnoze();
                prozor.ShowDialog();
                UcitajPodatke(dijagnozeSelect);
            }

        }

        
        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            if (ucitanaTabela.Equals(osiguranjaSelect))
            {
                popuniFormu(selectUslovOsiguranja);
                UcitajPodatke(osiguranjaSelect);
            }
            else if (ucitanaTabela.Equals(racuniSelect))
            {
                popuniFormu(selectUslovRacuni);
                UcitajPodatke(racuniSelect);
            }
            else if (ucitanaTabela.Equals(evidencijeSelect))
            {
                popuniFormu(selectUslovEvidencije);
                UcitajPodatke(evidencijeSelect);
            }
            else if (ucitanaTabela.Equals(dijagnozeSelect))
            {
                popuniFormu(selectUslovDijagnoze);
                UcitajPodatke(dijagnozeSelect);
            }
            else if (ucitanaTabela.Equals(tretmaniSelect))
            {
                popuniFormu(selectUslovTretmani);
                UcitajPodatke(tretmaniSelect);
            }
            else if (ucitanaTabela.Equals(terminiSelect))
            {
                popuniFormu(selectUslovTermini);
                UcitajPodatke(terminiSelect);
            }
            else if (ucitanaTabela.Equals(korisniciSelect))
            {
                popuniFormu(selectUslovKorisnici);
                UcitajPodatke(korisniciSelect);
            }
            else if (ucitanaTabela.Equals(pacijentiSelect))
            {
                popuniFormu(selectUslovPacijenti);
                UcitajPodatke(pacijentiSelect);
            }
        }

        private void popuniFormu(string selectUslov)
        {
            try
            {
                konekcija.Open();
                azuriraj = true;
                red = (DataRowView)dataGridCentralni.SelectedItems[0];
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                cmd.CommandText = selectUslov + "@id";
                SqlDataReader citac = cmd.ExecuteReader();
                if (citac.Read())
                {
                    if (ucitanaTabela.Equals(pacijentiSelect))
                    {
                        FrmPacijenti prozorPacijenti = new FrmPacijenti(azuriraj, red);
                        prozorPacijenti.txtIme.Text = citac["imePacijenta"].ToString();
                        prozorPacijenti.txtPrezime.Text = citac["prezimePacijenta"].ToString();
                        prozorPacijenti.txtJmbg.Text = citac["JMBGPacijenta"].ToString();
                        prozorPacijenti.txtKontakt.Text = citac["kontaktPacijenta"].ToString();
                        prozorPacijenti.txtAdresa.Text = citac["adresaPacijenta"].ToString();
                        prozorPacijenti.txtGrad.Text = citac["gradPacijenta"].ToString();
                        prozorPacijenti.cbTretman.SelectedValue = citac["tretmanID"];
                        prozorPacijenti.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(osiguranjaSelect))
                    {
                        FrmOsiguranja prozorOsiguranja = new FrmOsiguranja(azuriraj, red);
                        prozorOsiguranja.txtVrstaOsiguranja.Text = citac["vrstaOsiguranja"].ToString();
                        prozorOsiguranja.ShowDialog();

                    }
                    else if (ucitanaTabela.Equals(racuniSelect))
                    {
                        FrmRacuni prozorRacuni = new FrmRacuni(azuriraj, red);
                        prozorRacuni.txtNacinPlacanja.Text = citac["nacinPlacanja"].ToString();
                        prozorRacuni.txtUkupnaCena.Text = citac["ukupnaCena"].ToString();
                        prozorRacuni.cbOsiguranje.SelectedValue = citac["osiguranjeID"];
                        prozorRacuni.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(dijagnozeSelect))
                    {
                        FrmDijagnoze prozorDijagnoze = new FrmDijagnoze(azuriraj, red);
                        prozorDijagnoze.txtNazivDijagnoze.Text = citac["nazivDijagnoze"].ToString();
                        prozorDijagnoze.txtPlan.Text = citac["planLecenja"].ToString();
                        prozorDijagnoze.cbKorisnik.SelectedValue = citac["korisnikID"];
                        prozorDijagnoze.cbPacijent.SelectedValue = citac["pacijentID"];
                        prozorDijagnoze.cbEvidencija.SelectedValue = citac["evidencijaID"];
                        prozorDijagnoze.cbRacun.SelectedValue = citac["racunID"];
                        prozorDijagnoze.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(evidencijeSelect))
                    {
                        FrmEvidencije prozorEvidencije = new FrmEvidencije(azuriraj, red);
                        prozorEvidencije.txtTokLecenja.Text = citac["trenutnoStanjeTokaLecenja"].ToString();
                        prozorEvidencije.cbTretman.SelectedValue = citac["tretmanID"];
                        prozorEvidencije.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(korisniciSelect))
                    {
                        FrmKorisnici prozorKorisnici = new FrmKorisnici(azuriraj, red);
                        prozorKorisnici.txtIme.Text = citac["ime"].ToString();
                        prozorKorisnici.txtPrezime.Text = citac["prezime"].ToString();
                        prozorKorisnici.txtJmbg.Text = citac["JMBG"].ToString();
                        prozorKorisnici.txtKontakt.Text = citac["kontakt"].ToString();
                        prozorKorisnici.txtAdresa.Text = citac["adresa"].ToString();
                        prozorKorisnici.txtGrad.Text = citac["grad"].ToString();
                        prozorKorisnici.ShowDialog();
                    }
          
                    else if (ucitanaTabela.Equals(terminiSelect))
                    {
                        FrmTermini prozorTermini = new FrmTermini(azuriraj, red);
                        prozorTermini.dpDatum.SelectedDate = (DateTime)citac["datum"];
                        prozorTermini.txtVreme.Text = citac["vreme"].ToString();
                        prozorTermini.cbTretman.SelectedValue = citac["tretmanID"];
                        prozorTermini.cbPacijent.SelectedValue = citac["pacijentID"];
                        prozorTermini.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(tretmaniSelect))
                    {
                        FrmTretmani prozorTretmani = new FrmTretmani(azuriraj, red);
                        prozorTretmani.txtVrstaTretmana.Text = citac["vrstaTretmana"].ToString();
                        prozorTretmani.txtCenaTretmana.Text = citac["cenaTretmana"].ToString();
                        prozorTretmani.ShowDialog();
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (ucitanaTabela.Equals(osiguranjaSelect))
            {
                Obrisi(deleteOsiguranja);
                UcitajPodatke(osiguranjaSelect);
            }
            else if (ucitanaTabela.Equals(racuniSelect))
            {
                Obrisi(deleteRacuni);
                UcitajPodatke(racuniSelect);
            }
            else if (ucitanaTabela.Equals(evidencijeSelect))
            {
                Obrisi(deleteEvidencije);
                UcitajPodatke(evidencijeSelect);
            }
            else if (ucitanaTabela.Equals(dijagnozeSelect))
            {
                Obrisi(deleteDijagnoze);
                UcitajPodatke(dijagnozeSelect);
            }
            else if (ucitanaTabela.Equals(tretmaniSelect))
            {
                Obrisi(deleteTretmani);
                UcitajPodatke(tretmaniSelect);
            }
            else if (ucitanaTabela.Equals(terminiSelect))
            {
                Obrisi(deleteTermini);
                UcitajPodatke(terminiSelect);
            }
            else if (ucitanaTabela.Equals(korisniciSelect))
            {
                Obrisi(deleteKorisnici);
                UcitajPodatke(korisniciSelect);
            }
            else if (ucitanaTabela.Equals(pacijentiSelect))
            {
                Obrisi(deletePacijenti);
                UcitajPodatke(pacijentiSelect);
            }
        }

        public void Obrisi(string deleteUpit)
        {
            try
            {
                konekcija.Open();
                red = (DataRowView)dataGridCentralni.SelectedItems[0];
                MessageBoxResult rez = MessageBox.Show("Da li ste sigurni?", "Upozorenje", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (rez == MessageBoxResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand
                    {
                        Connection = konekcija
                    };
                    cmd.Parameters.Add("id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = deleteUpit + "@id";
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                };
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (SqlException)
            {
                MessageBox.Show("Postoje povezani podaci u drugim tabelama!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }
    }
}
