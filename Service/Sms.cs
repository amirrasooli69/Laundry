using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Laundry
{
    public class Sms
    {
        public static string Send_Sms(string text, string phone, string emza, string smsNumber, double warning)
        {
            PARSGREEN.API.SMS.Profile.ProfileService p = new PARSGREEN.API.SMS.Profile.ProfileService();
            double creidet = p.GetCredit(emza);
            if (creidet == -64) // chek kardane dorost boodane emza digital
            {
                MessageBox.Show("امضا دیجیتال اشتباه است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "-64";
            }
            string pattern = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + smsNumber + "&to=" + phone + "&text=" + text + "&signature=" + emza;

            //MessageBox.Show(pattern);
            System.IO.Stream st = null;
            System.IO.StreamReader sr = null;

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(pattern);
            Encoding encode = System.Text.Encoding.UTF8;
            //MessageBox.Show(message2.Length.ToString());
            System.Net.WebResponse resp = req.GetResponse();

            st = resp.GetResponseStream();
            sr = new System.IO.StreamReader(st, Encoding.UTF8);
            string result = sr.ReadToEnd().Substring(12, 1);
            //MessageBox.Show(sr.ReadToEnd()); //Get_Return_Message_Sms(int.Parse(result);
            //lblError.Text = Get_Return_Message_Sms(int.Parse(result));
            sr.Close();
            resp.Close();
            //---------


            if (creidet < warning)
                MessageBox.Show("اعتبار پنل پیامک کمتر از" + warning + " ریال است", "پنل پیامک", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //-------
            if (result == "0")
            {
                MessageBox.Show(text, "پیام ارسال شده");
                return "0";
            }
            return result;
        } 
        public static string text_Service_Sms(string text,string Date,string CodeRahgiri,string Message,string Name,int RowCountDataGrideView) //ersale sms paziresh service
        {
            string Msg = text;
            Msg = Msg.Insert(Msg.LastIndexOf("%%"), Date);
            Msg = Msg.Remove(Msg.LastIndexOf("%%"), 2);
            // MessageBox.Show(message2);
            //---
            //MessageBox.Show(message2.LastIndexOf("%%").ToString());
            Msg = Msg.Insert(Msg.LastIndexOf("%%"), CodeRahgiri);
            Msg = Msg.Remove(Msg.LastIndexOf("%%"), 2);
            //MessageBox.Show(message2);
            //---
            //MessageBox.Show(message2.LastIndexOf("%%").ToString());
            Msg = Msg.Insert(Msg.LastIndexOf("%%"), Message.Replace(" ", "."));
            Msg = Msg.Remove(Msg.LastIndexOf("%%"), 2);
            //MessageBox.Show(message2);
            //---
            //MessageBox.Show(message2.LastIndexOf("%%").ToString());
            Msg = Msg.Insert(Msg.LastIndexOf("%%"), Name.Replace(" ", "."));
            Msg = Msg.Remove(Msg.LastIndexOf("%%"), 2);
            //MessageBox.Show(message2);
            if (text.Length > 132)
            {
                Msg = text;
                //MessageBox.Show(message2.LastIndexOf("%%").ToString());
                Msg = Msg.Insert(Msg.LastIndexOf("%%"), Date);
                Msg = Msg.Remove(Msg.LastIndexOf("%%"), 2);
                //MessageBox.Show(message2);
                //---
                //MessageBox.Show(message2.LastIndexOf("%%").ToString());
                Msg = Msg.Insert(Msg.LastIndexOf("%%"), CodeRahgiri);
                Msg = Msg.Remove(Msg.LastIndexOf("%%"), 2);
                //MessageBox.Show(message2);
                //---
                //MessageBox.Show(message2.LastIndexOf("%%").ToString());
                Msg = Msg.Insert(Msg.LastIndexOf("%%"), RowCountDataGrideView.ToString());
                Msg = Msg.Remove(Msg.LastIndexOf("%%"), 2);
                //MessageBox.Show(message2);
                //---
                //MessageBox.Show(message2.LastIndexOf("%%").ToString());
                Msg = Msg.Insert(Msg.LastIndexOf("%%"), Name.Replace(" ", "."));
                Msg = Msg.Remove(Msg.LastIndexOf("%%"), 2);
                //MessageBox.Show(message2);

                //MessageBox.Show("sefaresh " + message2.Length.ToString());
                //lblError.Text = "فرمت فشرده پیامک";

            }
            return Msg;
        }
        public static string text_Welcom_Sms(string text,string Date,string CodeEshterak,string Name)
        {
            text = text.Insert(text.LastIndexOf("%%"), Date);
            text = text.Remove(text.LastIndexOf("%%"), 2);
            //-----
            text = text.Insert(text.LastIndexOf("%%"), CodeEshterak);
            text = text.Remove(text.LastIndexOf("%%"), 2);
            //----
            text = text.Insert(text.LastIndexOf("%%"), Name.Replace(" ", "."));
            text = text.Remove(text.LastIndexOf("%%"), 2);
            return text;
        }
        public static string text_Ready_Sms(string text,string Date,string CodeEshterak,string CodeRahgiri,string Name)
        {
            text = text.Insert(text.IndexOf("%%"), Name.Replace(" ", "."));
            text = text.Remove(text.IndexOf("%%"), 2);
            //---------
            text = text.Insert(text.IndexOf("%%"), CodeEshterak);
            text = text.Remove(text.IndexOf("%%"), 2);
            //---------
            text = text.Insert(text.IndexOf("%%"), CodeRahgiri);
            text = text.Remove(text.IndexOf("%%"), 2);
            //---------
            text = text.Insert(text.IndexOf("%%"), Date);
            text = text.Remove(text.IndexOf("%%"), 2);
            return text;
        }
        public static string text_Delivery_Sms(string text,string Date,string CodeRahgiri,string CodeEshterak,string Name)
        {
            text = text.Insert(text.IndexOf("%%"), Name.Replace(" ", "."));
            text = text.Remove(text.IndexOf("%%"), 2);
            //---------
            text = text.Insert(text.IndexOf("%%"), CodeEshterak);
            text = text.Remove(text.IndexOf("%%"), 2);
            //---------
            text = text.Insert(text.IndexOf("%%"), CodeRahgiri);
            text = text.Remove(text.IndexOf("%%"), 2);
            //---------
            text = text.Insert(text.IndexOf("%%"), Date);
            text = text.Remove(text.IndexOf("%%"), 2);

            return text;

        }
    }
}
