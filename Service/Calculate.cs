using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laundry
{
    public class Calculate
    {
        public static string Calculet_total_Service_Mande(string eshterak)
        {
            kitchenEntities context = new kitchenEntities();
            var price = context.Service.Where(c => c.Eshterak == eshterak).ToList();
            //------mohasebe jame baghimande
            long bestankar = 0, takhfif = 0, pardakhti = 0, sumService = 0, sum = 0, totalSum = 0, valueAdded = 0,
                totalPardakhti=0,totalTakhfif=0;


            for (int i = 0; i < price.Count; i++)
            {
                pardakhti = 0; bestankar = 0; takhfif = 0; sumService = 0;
                takhfif = Int64.Parse(price[i].Takhfif.Value.ToString()); //kole takfif dade shode
                bestankar = price[i].Bestankar.Value;
                pardakhti = price[i].Pardakhti.Value; 
                sumService = price[i].SumServices.Value;
                valueAdded = price[i].ValueAdded.Value;
                totalTakhfif = totalTakhfif + takhfif;
                totalPardakhti = totalPardakhti + pardakhti + bestankar;// kole mablaghe pardakht shode
                totalSum = totalSum + sumService + valueAdded;//kole mablaghe khadamat
                sum = sum + ((sumService + valueAdded) - (pardakhti + bestankar + takhfif)); //kole mablaghe mande
            }
            return sum.ToString() + "," + totalSum.ToString() + "," + totalPardakhti.ToString() +","+totalTakhfif.ToString();
        }
        // barghashti metod(mande [0] va beiane [1] va sefareshat [2] va pardakhti [3] va takhfif [4] ke ba , joda shodan)
        public static string Remaining_Total(string eshterak) 
        {
            string []ret=Calculet_total_Service_Mande(eshterak).Split(',');
            
            long sum = long.Parse(ret[0]);

            string mande="", beiane="";
            //lblTotalPrice.Text = Seragham(ret[1]);
            if (sum < 0)
            {
                beiane = sum.ToString().Remove(0, 1);

                mande = "0";
                return mande + "," + beiane + "," + ret[1] + "," + ret[2] + "," + ret[3];
            }
            if (sum > 0)
            {
                beiane = "0";
                mande = sum.ToString();
                return mande + "," + beiane + "," + ret[1] + "," + ret[2] + "," + ret[3];
            }
            if (sum == 0)
            {
                beiane = "0";
                mande = "0";
                return mande + "," + beiane + "," + ret[1] + "," + ret[2] + "," + ret[3];
            }
            return ret[0] + "," + ret[1];
        }
        public static string total_Service(string eshterak)
        {
            string[] ret = Calculet_total_Service_Mande(eshterak).Split(',');
            return ret[1];
        }
    }
}
