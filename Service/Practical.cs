using System.Windows.Forms;
using System.Globalization;
using System;

namespace Service
{
    public class Practical
    {
        public static string split_3Number(string input)//joda kardane 3ragham 3ragham
        {
            if (input != "")
            {
                input = Convert.ToInt64(input.Replace(",", "")).ToString("#,0");

            }
            else
            {
                input = "0";
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
                        input += "-";
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
        public static string Build_Eshterak_Number(string Number) // dorost kardane shomare eshterak 5 raghami
        {
            string eshterak = "";
            if (Number.Length == 11)
            {
                eshterak = Number.Substring(Number.Length - 5, 5);

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
            if (day.Length == 1)
            {
                day = "0" + day;
            }
            month = pc.GetMonth(System.DateTime.Now).ToString();
            if (month.Length == 1)
            {
                month = "0" + month;
            }
            year = pc.GetYear(System.DateTime.Now).ToString();
            return year + "/" + month + "/" + day;

        }
        public static void limited_Enter(Object sender, KeyPressEventArgs e) // baraye kontorole maghadire voroodi
        { // rooye Data Gride test shode

            if (!char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        public static string Sum_price_DataGrideView(DataGridView dg,int column)
        {
            long sum = 0;
            long value = 0;
            if(dg.RowCount>0)
            {
                for(int i=0;i<dg.RowCount;i++)
                {
                    value=long.Parse(dg.Rows[i].Cells[column].Value.ToString().Replace(",",""));
                    sum = sum + value;
                }
            }
            return split_3Number(sum.ToString());
        }
    }
}
