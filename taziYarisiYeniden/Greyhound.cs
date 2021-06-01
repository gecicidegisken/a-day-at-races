using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;   //point için gerekli
using System.Threading;   //delay etme için gerekli


namespace taziYarisiYeniden
{

    public class Greyhound
    {
        public int baslamaNoktasi;
        public int yolUzunlugu;
        public PictureBox kopekGorseli;
        public int konum = 0;
        int sonaUzaklık;

        public Greyhound (PictureBox kopekGorseli, int yolUzunlugu, int baslamaNoktasi,int sonaUzaklık)   //constructor
        {
            this.kopekGorseli = kopekGorseli;
            this.yolUzunlugu = yolUzunlugu;
            this.baslamaNoktasi = baslamaNoktasi;
            this.sonaUzaklık = sonaUzaklık;

        }
        public bool KosunKopekler()
        {
           
            GorseliHareketEttir(sonaUzaklık);

            konum= konum+sonaUzaklık;
            if (konum >= (yolUzunlugu - baslamaNoktasi))
            {
                return true;        //yani sona gelmedikçe koşmaya devam ediyor
            }
            return false;        //Sona gelince duruyor
        }

        public void BasaDon()
        {
            GorseliHareketEttir(-konum);
            konum = 0;
        }



        public void GorseliHareketEttir(int sonaUzaklık)
        {
            Thread.Sleep(20); // bilgisayarı uyutuyor ve köpekler yavaş yavaş koşuyor
            Point p =kopekGorseli.Location;   // p noktasi, picturebox'ın olduğu nokta.
            p.X += sonaUzaklık;    // p noktasinin x eksenini rastgele sayıyla arttırdık
           kopekGorseli.Location = p;  // yeni p noktasina, picturebox'ın yerini atadık
        }
    }
}
