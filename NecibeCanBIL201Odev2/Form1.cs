using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NecibeCanBIL201Odev2
{
    public partial class Form1 : Form
    {
        List<Fabrika> fabrikalar = new List<Fabrika>();
        public Form1()
        {
            InitializeComponent();
        }

        private void fabrikaEkleBtn_Click(object sender, EventArgs e)
        {
            Fabrika fabrika = new Fabrika();
            fabrika.FabrikaAdi = fabrikaAdiTxt.Text;
            fabrika.Adres = adresTxt.Text;
            fabrika.Calisanlar = new List<Calisan>();
            fabrikalar.Add(fabrika);
            fabSecCBox.Items.Add(fabrika.FabrikaAdi);
            fabrikaListeleCBox.Items.Add(fabrika.FabrikaAdi);
        }

        private void isciEkleBtn_Click(object sender, EventArgs e)
        {
            if (TxtKontrol())
            {
                if (TCKontrol())
                {
                    Kimlik kimlik = new Kimlik();
                    kimlik.Ad = adTxt.Text;
                    kimlik.Soyad = soyadTxt.Text;
                    kimlik.TCKNo = Convert.ToUInt64(tckNoTxt.Text);
                    Calisan calisan = new Calisan();
                    calisan.Kimlik = kimlik;
                    calisan.PersonelNo = Convert.ToInt32(personelNoTxt.Text);
                    calisan.Birim = birimTxt.Text;

                    fabrikalar[fabSecCBox.SelectedIndex].IseAl(calisan);
                    
                }
                else
                {
                    MessageBox.Show("Hatalı TCK No girdiniz!!");
                }
            }
            else
            {
                MessageBox.Show("Alanlar boş bırakılamaz!!");
            }
        }

        bool TCKontrol()
        {
            if (tckNoTxt.Text.Length == 11 && Convert.ToUInt64(tckNoTxt.Text) > 10000000000)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        bool TxtKontrol()
        {
            if (string.IsNullOrEmpty(personelNoTxt.Text) || string.IsNullOrEmpty(tckNoTxt.Text) || string.IsNullOrEmpty(adTxt.Text) || string.IsNullOrEmpty(soyadTxt.Text) || string.IsNullOrEmpty(birimTxt.Text))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void listeleBtn_Click(object sender, EventArgs e)
        {
            calisanListesi.Items.Clear();
            foreach (Calisan calisan in fabrikalar[fabrikaListeleCBox.SelectedIndex].Calisanlar)
            {
                ListViewItem item = new ListViewItem();
                item.Text = calisan.PersonelNo.ToString();
                item.SubItems.Add(calisan.Kimlik.TCKNo.ToString());
                item.SubItems.Add(calisan.Kimlik.Ad);
                item.SubItems.Add(calisan.Kimlik.Soyad);
                item.SubItems.Add(calisan.Birim);
                calisanListesi.Items.Add(item);
            }
            calisanListesi.Update();
        }

        private void istenCikarBtn_Click(object sender, EventArgs e)
        {
            fabrikalar[fabrikaListeleCBox.SelectedIndex].IstenCikar(calisanListesi.SelectedItems[0].Index);
        }
    }
}
