using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace taziYarisiYeniden
{
    public class Guy
    {
        public string isim;
        public Bet iddia;
        public int bakiye;
        public Label iddiaciEtiketi;
        public RadioButton iddiaciRB;
    

         public Guy(string isim, Bet iddia, int bakiye, Label iddiaciEtiketi, RadioButton iddiaciRB)  //yapıcı fonksiyon
     {
               this.isim = isim;
               this.iddia = iddia;
               this.bakiye = bakiye;
               this.iddiaciEtiketi = iddiaciEtiketi;
               this.iddiaciRB = iddiaciRB;
     }


        public void EtiketleriGuncelle()
        {
            if (iddia == null)  //herhangi bi iddia oynamadıysa sağda yazacak olan şeyler
            {
                iddiaciEtiketi.Text = isim + " hasn't placed any bets.";
            }
            else //iddiayı oynadıysa
            {
                iddiaciEtiketi.Text = iddia.IddialariGoster();  //bet classındaki iddialariGoster fonksiyonunu kullandık.
            }
            iddiaciRB.Text = isim + " has " + bakiye + " bucks";
            if (bakiye==0)
            {
                iddiaciRB.Text = isim + " has lost all of his money. He can't play anymore.";
            }
        }

        public bool IddialariOyna(int miktar, int kopek)
        {
            if (miktar < bakiye)
            {
                iddia = new Bet(miktar, this, kopek);

                return true;
            }
            else if (miktar == bakiye && miktar !=0)
            {
                DialogResult result1 = MessageBox.Show("Are you sure betting ALL of your money?","BE CAREFUL!", MessageBoxButtons.YesNo);
                if (result1 == DialogResult.Yes)
                {
                    iddia = new Bet(miktar, this, kopek);
                    return true;
                }
                else return false;
                }

            else
            {
                MessageBox.Show("You don't have enough money..","SORRY");
                return false;
            } 
        }
   
        public void Topla(int kazanan)
        {
            bakiye += iddia.OdemeYap(kazanan);
        }
    }
} 
