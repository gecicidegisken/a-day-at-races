using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taziYarisiYeniden
{
   public class Bet
    {
        public  int miktar;
        public Guy iddiaci;
        public int kopek;

        public Bet(int miktar, Guy iddiaci, int kopek)
        {
            this.miktar = miktar;
            this.iddiaci = iddiaci;
            this.kopek = kopek;
        }

        public int OdemeYap(int kazanan)
        {
            if (kopek == kazanan)
            {
                return miktar;      // kazanırsa iddia miktarını ödüyoruz
            }
            else
                return -miktar;  //kaybederse iddia miktarının eksi katını geri ödüyoruz
        }

        public string IddialariGoster()
        {
            string aciklama=iddiaci.isim+ " hasn't placed any bets.";

            if(miktar != 0)  //eğer iddia oynandıysa; 
            {
                aciklama = iddiaci.isim + " placed " + miktar + " bucks on dog " + kopek;  //kime ne kadar oynandı??
            }
            
            return aciklama;
        }
    }
}
