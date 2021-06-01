using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;

namespace taziYarisiYeniden
{
    public partial class Form1 : Form
    {
        Greyhound[] tazilar = new Greyhound[4];     //HER YERDEN ULAŞABİLELİM DİYE BUNLARI BURAYA YAZDIK
        Guy[] adamlar = new Guy[3];        

        public Form1()
        {
            InitializeComponent();
            YarisAlaniniKur();
        }

        public void YarisAlaniniKur() 
        { 
            //Adamları hazırlayalım
            adamlar[0] = new Guy("Joe",null, 45, joeBetsEtiket, joeRB);
            adamlar[1] = new Guy("Bob", null, 80, bobBetsEtiket, bobRB);
            adamlar[2] = new Guy("Al", null, 65, alBetsEtiket, alRB);

            foreach (Guy guy in adamlar)
            {
                guy.EtiketleriGuncelle();
            }

        }

        private void joeRB_CheckedChanged(object sender, EventArgs e)
        {
            iddiaciEtiketi.Text = "Joe bets:";
        }

        private void bobRB_CheckedChanged(object sender, EventArgs e)
        {
            iddiaciEtiketi.Text = "Bob bets:";
        }

        private void alRB_CheckedChanged(object sender, EventArgs e)
        {
            iddiaciEtiketi.Text = "Al bets:";
        }

        private void iddiaOynaBtn_Click(object sender, EventArgs e)
        {
            int i = 0;

            if (joeRB.Checked)
            {
                i = 0;
            }
            if (bobRB.Checked)
            {
                i = 1;
            }
            if (alRB.Checked)
            {
                i = 2;
            }

            // i numaralı adam seçiliyse aşağıdakiler yapılacak
           adamlar[i].IddialariOyna((int)numericUpDown1.Value, (int)numericUpDown2.Value);  //numericupdown1 iddiayı seçtiren, 2 de köpek seçtiren
           adamlar[i].EtiketleriGuncelle();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void kopek4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void raceBtn_Click(object sender, EventArgs e)
        {
           

            startEngeli.Visible = false;
            int yolUzunlugu = yarisSahasi.Size.Width;   //yaris sahası adlı picturebox'ın boyun bizim yol uzunluğumuz
            int baslamaNoktasi = kopek1.Right - yarisSahasi.Left; // 1.köpeğin sağ'a uzaklığından sola olan uzaklık sıfır noktamız.

            Random sayisalla = new Random();

            //Kopekleri hazırlayalım ////Race butonuna her bastığımda randomizer tekrar çalışsın ve kazanan değişsin diye buraya yazdım
            tazilar[0] = new Greyhound(kopek1, yolUzunlugu, baslamaNoktasi, sayisalla.Next(7,18));
            tazilar[1] = new Greyhound(kopek2, yolUzunlugu, baslamaNoktasi, sayisalla.Next(7,18));
            tazilar[2] = new Greyhound(kopek3, yolUzunlugu, baslamaNoktasi, sayisalla.Next(7,18));
            tazilar[3] = new Greyhound(kopek4, yolUzunlugu, baslamaNoktasi, sayisalla.Next(7,18));

            bool kazananYok = true;
            int kazananKopek;
            string kazananKopekAdi;
            raceBtn.Enabled = false;

            while (kazananYok)
            {
                Application.DoEvents();

                for (int i = 0; i < tazilar.Length; i++)
                {
                    if (tazilar[i].KosunKopekler())
                    {
                        kazananKopek = i + 1;
                        kazananYok = false;   //yani artık bi kazananımız var

                        if (kazananKopek == 1)
                        {
                            kazananKopekAdi = "SİVAS";
                        }
                        else if (kazananKopek == 2)
                        {
                            kazananKopekAdi = "KARABAŞ";
                        }
                        else if (kazananKopek == 3)
                        {
                            kazananKopekAdi = "LUCY";
                        }
                        else if (kazananKopek == 4)
                        {
                            kazananKopekAdi = "FİŞEK";
                        }
                        else
                            kazananKopekAdi = " ";
                        MessageBox.Show("The winner is " + kazananKopekAdi+"! The dog number #"+kazananKopek)  ;
                       
                        foreach (Guy guy in adamlar)
                        {
                            if (guy.iddia != null)
                            {
                                guy.Topla(kazananKopek);
                                guy.iddia = null;
                                guy.EtiketleriGuncelle();
                            }
                        }

                        foreach (Greyhound dog in tazilar)
                        {
                            dog.BasaDon();
                        }
                        break;
                    }
                }
            }
           
            startEngeli.Visible = true;
            raceBtn.Enabled = true;
        }

        private void startEngeli_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void kopek3_Click(object sender, EventArgs e)
        {

        }

        private void kopek1_Click(object sender, EventArgs e)
        {

        }

        private void yarisSahasi_Click(object sender, EventArgs e)
        {

        }
    }
}
