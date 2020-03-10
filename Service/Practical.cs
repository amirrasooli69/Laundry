using System.Windows.Forms;
using System.Globalization;
using System;

namespace Service
{
    public class Practical
    {
        public static string split_3Number(string input)//joda kardane 3ragham 3ragham
        {
            if (input != string.Empty)
            {
                input = Convert.ToInt64(input.Replace(",", "")).ToString("#,0");

            }
            return input;
        }
        public static string split_4Number(string input)//joda kardane 3ragham 3ragham
        {
            
            switch (input.Length)
            {
                // baraye ezafe kardane -
                case 4:
                    {
                        input += "-";
                        break;
                    }
                case 9:
                    {
                        input+= "-";
                        break;
                    }
                case 14:
                    {
                        input += "-";
                        break;
                    }

            }
            return input;
        }
        public static string Delete_Char(string input) //pak kardane karakterhaye shomare kart
        {
            string lastChar = "";
            if (input.Length > 4)
                lastChar = input.Substring(input.Length - 1, 1);
            if (lastChar == "-")
            {
                input = input.Substring(0, input.Length - 1);
            }
            return input;
        } 
        public static string Build_Eshterak_Number(string Number) // dorost kardane shomare eshterak 5 raghami
        {
            string eshterak = "";
            if(Number.Length==11)
            {
                eshterak = Number.Substring(Number.Length - 5,5);
                
            }
            return eshterak;

        }
        public static void Enter_Number(object sender, KeyPressEventArgs e) // kontorele inke karbar faghat betavanad adad vared konad
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }
        public static string Today_Date() // entekhab rooz ba estefade az kelase PersianCalendar windows
        {
            PersianCalendar pc = new PersianCalendar();
            string day;
            string month;
            string year;
            day = pc.GetDayOfMonth(System.DateTime.Now).ToString();
            month = pc.GetMonth(System.DateTime.Now).ToString();
            year = pc.GetYear(System.DateTime.Now).ToString();
            return year + "/" + month + "/" + day;

        }
    }
}
