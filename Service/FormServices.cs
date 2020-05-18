using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Stimulsoft.Report;
using Stimulsoft.Report.Components;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using BPersianCalender;
using System.Drawing.Printing;
using System.Threading;

namespace Service
{
    public partial class FormServices : Form
    {
        //long sumServices=0;
        public FormServices()
        {
            InitializeComponent();

        }
        string foodSelect = "";
        string categorySelect = "";
        string serviceSelect = "";
        public void Service_Register() // sabte ghaza 
        {
            //btnSave2.Enabled = true;
            StimulsoftEntities context = new StimulsoftEntities();
            lblError.Text = "";
            if (txtEshterak.Text == "" || txtName.Text == "" || txtPhone.Text == "")
            {
                lblError.Text = "مشتری انتخاب نشده است";
                return;
            }
            try
            {
                if (txtPrice.Text == "")
                {
                    //lblError.ForeColor = Color.Red;
                    lblError.Text = "قیمت خالی است";
                    return;

                }
                if (lblCodeRahgiri.Text == "")
                    lblCodeRahgiri.Text = Build_CodeRahgiri();
                double totalPrice = Convert.ToDouble(txtPrice.Text) * Convert.ToDouble(numSome.Text);

                //baraye mohasebe arzeshe afzoode
                double price = 0;
                var selectProdoct = context.Prodoct.Where(c => c.Name == foodSelect).FirstOrDefault();
                if (selectProdoct.ValueAdded == "0")
                {
                    var selectValueAdded = context.Setting.FirstOrDefault();

                    double ValueAdded = Convert.ToDouble(selectProdoct.ValueAddedPercent);
                    price = totalPrice * double.Parse(selectValueAdded.ValueAddedPercent.ToString());
                    price = price / 100;
                    if (txtValueAdded.Text == "")
                        txtValueAdded.Text = "0";
                    double beforeValueAdded = double.Parse(txtValueAdded.Text);
                    txtValueAdded.Text = (beforeValueAdded + price).ToString();
                }
                string stTotalPrice = totalPrice.ToString();
                dgShow.Rows.Add(categorySelect, foodSelect, serviceSelect, numSome.Text, txtPrice.Text, totalPrice.ToString(), lblCodeRahgiri.Text, "", price.ToString());

                numSome.Text = "1";
                double sum = 0;
                for (int i = 0; i < dgShow.RowCount; i++)
                {

                    sum = sum + Convert.ToInt64(dgShow.Rows[i].Cells[5].Value.ToString());
                }
                txtSumServices.Text = sum.ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show("مشکل در ثبت سفارش در لیست" + "\n" + ex.Message);
            }
        }
        private void select_price()
        {
            try
            {
                using (var context = new StimulsoftEntities())
                {
                    var price = context.ServicesPrice.Where(c => c.ServisKind == categorySelect && c.ServiceKala == foodSelect && c.ServiseName == serviceSelect).FirstOrDefault();
                    if (price != null)
                    {
                        if (price.ServicePrice.Value.ToString() == "" || price.ServicePrice.Value.ToString() == null)
                            txtPrice.Text = "0";
                        else
                        {
                            txtPrice.Text = price.ServicePrice.ToString();
                            //btnAddService.Enabled =false;
                        }
                    }
                    //else
                    //{
                    //    //btnAddService.Enabled = true;
                    //    //lblError.Text = "این قیمت تعریف نشده است.از قسمت مدیریت قیمت استفاده کنید";
                    //    //MessageBox.Show("این خدمت تعریف نشده است.از قسمت مدیریت قیمت استفاده کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //}


                    //var kindKala = context.KindKala.Where(c => c.NameService == comServiceKind.Text).ToList();
                    //comKindKala.DataSource = kindKala;
                    //comKindKala.DisplayMember = "Name";
                    //-----
                    //var service = context.ServicesPrice.Where(c => c.ServisKind == dgCategory.CurrentCell.Value.ToString() && c.ServiseName == selectFood && c.ServiceKala == dgServ.CurrentCell.Value.ToString()).FirstOrDefault();
                    //if (service != null)
                    //{
                    //    btnAddService.Enabled = false;
                    //    if (service.ServicePrice.Value.ToString() == "")
                    //        txtPrice.Text = "0";
                    //    else
                    //        txtPrice.Text = service.ServicePrice.Value.ToString();
                    //}
                    //else
                    //{
                    //    btnAddService.Enabled = true;

                    //    lblError.Text = "این خدمت تعریف نشده است.از قسمت مدیریت قیمت استفاده کنید";
                    //    //MessageBox.Show("این خدمت تعریف نشده است.از قسمت مدیریت قیمت استفاده کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //}
                }
                //}

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }
        public string Get_Return_Message_Sms(int state)
        {
            string message = "";
            if (state == 1)
            {
                message = "ارسال نشد";
                return message;
            }
            //-----
            if (state == -1)
            {
                message = "امضا دیجیتال معتبر تیست";
                return message;
            }
            //-----
            if (state == 0)
            {
                message = "ارسال شد";
                return message;
            }
            //-----
            if (state == 2)
            {
                message = "  پیامک معتبر نیست";
                return message;
            }
            //-----
            if (state == 3)
            {
                message = "شماره موبایلی وارد نشده";
                return message;
            }
            //-----
            if (state == 4)
            {
                message = "فیلتر می باشد";
                return message;
            }
            //-----
            if (state == 5)
            {
                message = "اپراتور قطع است";
                return message;
            }
            //-----
            if (state == 6)
            {
                message = "ارسال مجاز نیست";
                return message;
            }
            //-----
            if (state == 7)
            {
                message = "حساب کاریری شما فعال نیست";
                return message;
            }
            //-----
            if (state == 8)
            {
                message = "اعتبار کافی موجود تیست";
                return message;
            }
            //-----
            if (state == 9)
            {
                message = "محدودیت در تعداد درخواست";
                return message;
            }
            //-----
            if (state == 10)
            {
                message = "محدودیت ارسال روزانه";
                return message;
            }
            //-----
            if (state == 11)
            {
                message = "شماره پیامک معتبر نیست";
                return message;
            }
            //-----
            if (state == 12)
            {
                message = "خطا";
                return message;
            }
            //-----
            if (state == 13)
            {
                message = "حساب کاربری منقضی شده";
                return message;
            }
            //-----
            if (state == 14)
            {
                message = "باید به پنل لاگین کنید";
                return message;
            }
            //-----
            if (state == -64)
            {
                message = "اعتبار مالی کافی نیست";
                return message;
            }


            return message;
        }
        public void Some_Paye()
        {
            try
            {
                //----------beiane
                if (txtBeiane.Text == "")
                    txtBeiane.Text = "0";

                double beiane;
                if (txtBeiane.Text != "")
                    beiane = int.Parse(txtBeiane.Text.Replace(",", ""));
                else
                    beiane = 0;
                //-----beiane az ghabl
                double beforeBeiane;
                if (txtBeiane.Text != "")
                    beforeBeiane = int.Parse(txtBeforeBeiane.Text.Replace(",", ""));
                else
                    beforeBeiane = 0;
                if (txtPay.Text == "")
                    txtPay.Text = "0";
                //----------takhfif
                if (txtDarsadTakhfif.Text == "")
                    txtDarsadTakhfif.Text = "0";
                //---
                if (txtSumTakhfif.Text == "")
                    txtSumTakhfif.Text = "0";
                //-----------mande
                if (txtMande.Text == "")
                    txtMande.Text = "0";


                double darsad;
                if (txtDarsadTakhfif.Text != "")
                    darsad = int.Parse(txtDarsadTakhfif.Text);
                else
                    darsad = 0;

                if (darsad > 100)
                    txtDarsadTakhfif.Text = "100";
                if (darsad < 0)
                    txtDarsadTakhfif.Text = "0";
                if (txtSumServices.Text == "")
                    txtSumServices.Text = "0";
                double totalSome = double.Parse(txtSumServices.Text.Replace(",", ""));
                double sum = double.Parse(txtPay.Text.Replace(",", ""));
                double takhfif = 0;
                if (darsad != 0)
                {
                    takhfif = totalSome * darsad;
                    takhfif = takhfif / 100;
                    txtSumTakhfif.Text = takhfif.ToString();
                }
                else
                {
                    takhfif = double.Parse(txtSumTakhfif.Text);
                }
                //-------
                if (txtMande.Text == "")
                    txtMande.Text = "0";
                double mande = double.Parse(txtMande.Text.Replace(",", ""));
                //-------
                if (txtValueAdded.Text == "")
                    txtValueAdded.Text = "0";
                double valueAdded = double.Parse(txtValueAdded.Text.Replace(",", ""));
                //----------

                txtPay.Text = (((totalSome - beiane -beforeBeiane) - takhfif) + mande + valueAdded).ToString();

            }
            catch (Exception)
            {
                //lblError.Text = "مشکل در حساب ";
                lblError.Text = "";

            }
        }

        public string Seragham(string input)//joda kardane 3ragham 3ragham
        {
            if (input != string.Empty)
            {
                input = Convert.ToInt64(input.Replace(",", "")).ToString("#,0");

            }
            return input;
        }
        public void Calculate_Pardakhti(object sender, KeyPressEventArgs e) // bad az zadane space meghdare
        {
            if ((char.IsWhiteSpace(e.KeyChar)))
            {
                Some_Paye();
            }

        }
        private void Enter_Number(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }
        public int Find_BirthDay(string date, int x)
        {
            date = date.Replace("/", "");
            int year = int.Parse(date.Substring(0, 4));
            int month = int.Parse(date.Substring(4, 2));
            int day = int.Parse(date.Substring(6, 2));
            //------
            for (int i = 0; i < x; i++)
            {
                day++;
                if (month < 7)
                {
                    if (day == 32)
                    {
                        day = 1;
                        month++;
                    }
                }
                if (month >= 7)
                {
                    if (day == 31)
                    {
                        day = 1;
                        month++;

                    }
                }
                if (month >= 12 && day == 30)
                {
                    day = 1;
                    month = 1;
                    year++;
                }

            }
            ///-------------
            string d = day.ToString();
            string m = month.ToString();
            string y = year.ToString();
            if (d.Length == 1)
                d = "0" + d;
            if (m.Length == 1)
                m = "0" + m;
            //--------------
            string tarikh = y + m + d;
            //MessageBox.Show(tarikh);
            int tavalod = int.Parse(tarikh);
            return tavalod;



        }
        private void Save_Services()
        {
            try
            {

                using (var context = new StimulsoftEntities())
                {
                    var repeatRahgiri = context.Service.Where(c => c.CodeRahgiri == lblCodeRahgiri.Text).FirstOrDefault();
                    if (repeatRahgiri != null)
                    {
                        lblError.Text = "این کد رهگیری قبلا ثبت شده";
                        DialogResult result = MessageBox.Show("موارد ارسال نشده را میخواهید؟", "ارسال نشده", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (result == DialogResult.Yes)
                        {
                            FormErsalNashode frmErsalNashode = new FormErsalNashode();
                            frmErsalNashode.Show();
                        }
                        return;
                    }
                    bool isService = context.User.Where(check => check.Eshterak == txtEshterak.Text).Any();
                    if (isService)
                    {
                        if (dgShow.Rows.Count > 0)
                        {
                            Service service = new Service();
                            service.Eshterak = txtEshterak.Text;
                            service.Name = txtName.Text;
                            service.DateService = int.Parse(dtNewService.Text.Replace("/", ""));
                            service.Mobile = txtPhone.Text;
                            Int64 beiane = 0;
                            if (txtBeiane.Text != "")
                                beiane = Int64.Parse(txtBeiane.Text.Replace(",", ""));
                            else
                                beiane = 0;
                            service.Bestankar = beiane;

                            //---
                            Int64 takhfif;
                            if (txtSumTakhfif.Text != "")
                                takhfif = Int64.Parse(txtSumTakhfif.Text.Replace(",", ""));
                            else
                                takhfif = 0;
                            //string sumTakhfif = ((totalSum * takhfif) / 100).ToString();
                            //service.Takhfif = Int64.Parse(txtSumTakhfif.Text.Replace(",",""));
                            service.Takhfif = takhfif;

                            Int64 totalSum;
                            if (txtSumServices.Text != "")
                                totalSum = Int64.Parse(txtSumServices.Text.Replace(",", ""));
                            else
                                totalSum = 0;
                            if (totalSum < 0)
                            {
                                string x = totalSum.ToString().Remove(0, 1);
                                totalSum = Int64.Parse(x);
                            }
                            //---
                            //totalSum = totalSum - takhfif;
                            //txtsumAfterTakhfif.Text = totalSum.ToString();
                            //service.SumServices = (totalSum-(takhfif + beiane));
                            service.SumServices = totalSum;
                            if (txtBeiane.Text == "")
                                txtBeiane.Text = "0";

                            service.CodeRahgiri = lblCodeRahgiri.Text;
                            Int32 countServices = Convert.ToInt32(lblSomeService.Text);
                            countServices++;
                            service.NumberService = countServices.ToString();
                            if (txtPay.Text == "")
                                txtPay.Text = "0";
                            service.Pardakhti = Convert.ToInt64(txtPay.Text.Replace(",", ""));

                            service.ReadyDate = 0;
                            service.SendReadySms = 0;
                            service.Description = txtDescription.Text;
                            if (radOffline.Checked)
                            {
                                service.OrderState = "حضوری";
                            }
                            else
                            {
                                service.OrderState = "غیر حضوری";
                            }
                            //----
                            if (radKart.Checked)
                            {
                                service.PayeState = "کارت";
                            }
                            else
                            {
                                service.PayeState = "نقدی";
                            }
                            if (txtValueAdded.Text == "")
                                txtValueAdded.Text = "0";
                            service.ValueAdded = Convert.ToInt64(txtValueAdded.Text.Replace(",", ""));
                            context.Service.Add(service);
                        }
                        else
                        {
                            lblError.Text = "سفارشی ثبت نشده است";
                            return;
                        }

                        //******************
                        //******************
                        if (lblCodeRahgiri.Text != "")
                        {
                            for (int i = 0; i < dgShow.Rows.Count; i++)
                            {
                                ReportService repServ = new ReportService();
                                repServ.Eshterak = txtEshterak.Text;
                                repServ.Date = int.Parse(dtNewService.Text.Replace("/", ""));
                                repServ.Kind = dgShow.Rows[i].Cells[0].Value.ToString();
                                repServ.Kala = dgShow.Rows[i].Cells[1].Value.ToString();
                                repServ.Service = dgShow.Rows[i].Cells[2].Value.ToString();
                                repServ.Some = dgShow.Rows[i].Cells[3].Value.ToString();
                                repServ.Price = dgShow.Rows[i].Cells[5].Value.ToString();
                                repServ.CodeRahgiri = dgShow.Rows[i].Cells[6].Value.ToString();
                                repServ.NumberServise = lblSomeService.Text;
                                repServ.Ready = "1";
                                repServ.ValueAdded = Convert.ToInt64(dgShow.Rows[i].Cells[8].Value);
                                context.ReportService.Add(repServ);
                            }
                            context.SaveChanges();
                            //lblError.ForeColor = Color.Green;
                            lblError.Text = "اطلاعات با موفقیت ثیت شد";

                        }
                    }
                    else
                    {
                        //lblError.ForeColor = Color.Red;
                        lblError.Text = "کاربری بااین شماره اشتراک وجود ندارد";

                        txtEshterak.Focus();
                        return;
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("مشکل در ثبت نهایی" + "\n" + ex.Message);
            }





        }
        public void send_sms() // ersal sms paziresh service
        {
            try
            {
                int vaziyzt = 1;

                try
                {
                    StimulsoftEntities context = new StimulsoftEntities();
                    var sign = context.Setting.FirstOrDefault();
                    if (sign.AcceptSms == "true")
                    {
                        vaziyzt = 1;
                    }
                    else
                    {
                        vaziyzt = 0;
                    }
                    if (vaziyzt == 1)
                    {
                        if (txtPhone.TextLength > 11 || txtPhone.TextLength < 11 || txtPhone.Text.StartsWith("09") == false)
                        {
                            //lblError.ForeColor = Color.Red;
                            lblError.Text = "شماره موبایل اشتباه است";
                            //txtPhone.Text = "0";
                            txtPhone.Focus();
                            return;
                        }
                        var sms = context.WhiteSms.Where(c => c.S1 != null && c.S1 != "").FirstOrDefault();
                        string signature = sign.Signature;
                        string numberSms = sign.NumberSms;
                        if (signature != "" && signature != "null" && numberSms != "" && numberSms != "null" && int.Parse(sms.W2) < 100) // baraye esrasale sms test
                        {
                            signature = "407CA55D-B3C4-4502-ABC5-DB95F7FB2AB0";
                            numberSms = "10001000300076";
                        }
                        if (signature == "null" || signature == "" || numberSms == "null" || numberSms == "")
                        {
                            //lblError.ForeColor = Color.Red;
                            lblError.Text = "از قسمت تنظیمات امضا دیجیتال و شماره پیامک را ثبت کنید";
                            lblError.ForeColor = Color.Black;
                            return;
                        }

                        string message = "";
                        for (int i = 0; i < dgShow.RowCount; i++)
                        {
                            message += dgShow.Rows[i].Cells[1].Value.ToString() + dgShow.Rows[i].Cells[3].Value.ToString() + "،";
                        }
                        var setName = context.Setting.Where(c => c.CommercialName != "" || c.CommercialName != null).FirstOrDefault();
                        if (setName == null)
                        {
                            MessageBox.Show("از بخش تنظیمات پیامک نام تجاری را ثبت کنید", "تنظیمات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        string message2 = Sms.text_Service_Sms(sms.S1, dtNewService.Text, lblCodeRahgiri.Text, message, txtName.Text, dgShow.RowCount);

                        //*********
                        var check = context.WhiteSms.FirstOrDefault();
                        double warning = double.Parse(check.R10);
                        string result = "";
                        if (signature != "null" && signature != "" && numberSms != "null" && numberSms != "")
                            result=Sms.Send_Sms(message2, txtPhone.Text, signature, numberSms, warning); //farakhani metod send sms az kelase sms
                        if(signature== "407CA55D-B3C4-4502-ABC5-DB95F7FB2AB0" && result=="0" ) // kam kardane payamake ferestade shode
                        {
                            int countSmsTest = int.Parse(sms.W2);
                            countSmsTest++;
                            sms.W2 = countSmsTest.ToString();
                        }
                    }
                    context.SaveChanges();

                }
                catch (Exception)
                {

                    StimulsoftEntities context = new StimulsoftEntities();
                    var sms = context.WhiteSms.Where(c => c.S1 != null && c.S1 != "").FirstOrDefault();
                    var sign = context.Setting.FirstOrDefault();
                    var setName = context.Setting.Where(c => c.CommercialName != "" || c.CommercialName != null).FirstOrDefault();
                    if (setName == null)
                    {
                        MessageBox.Show("از بخش تنظیمات پیامک نام تجاری را ثبت کنید", "تنظیمات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    //*****
                    try
                    {
                        string msg2 = Sms.text_Service_Sms(sms.S1, dtNewService.Text, lblCodeRahgiri.Text, "", txtName.Text, dgShow.RowCount);
                        //---------
                        var check = context.WhiteSms.FirstOrDefault();
                        double warning = double.Parse(check.R10);
                        Sms.Send_Sms(msg2, txtPhone.Text, sign.Signature, sign.NumberSms, warning);

                    }
                    catch (Exception)
                    {


                    }
                    //*****

                    string message = "";
                    for (int i = 0; i < dgShow.RowCount; i++)
                    {
                        message += dgShow.Rows[i].Cells[1].Value.ToString() + dgShow.Rows[i].Cells[3].Value.ToString() + "،";
                    }

                    string message2 = Sms.text_Service_Sms(sms.S1, dtNewService.Text, lblCodeRahgiri.Text, message, txtName.Text, dgShow.RowCount);
                    ErsalNashode En = new ErsalNashode();
                    En.Name = txtName.Text;
                    En.Phone = txtPhone.Text;
                    En.Message = message2;
                    En.Date = int.Parse(dtNewService.Text.Replace("/", ""));
                    En.Time = DateTime.Now.ToLongTimeString();
                    En.CodeRahgiri = lblCodeRahgiri.Text;
                    context.ErsalNashode.Add(En);
                    context.SaveChanges();
                    MessageBox.Show("اینترنت وصل نیست،در موارد ارسال نشده ذخیره شد", " وصل نیست اینترنت", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                //***************
                //**************

                txtEshterak.Text = "";
                txtSumServices.Text = "";
                txtSumTakhfif.Text = "";
                txtPay.Text = "";
                txtPhone.Text = "";
                txtName.Text = "";
                txtMande.Text = "";
                txtBeiane.Text = "";
                txtDarsadTakhfif.Text = "";
                txtValueAdded.Text = "";
                //**************
                //***************

            }
            catch (Exception ex)
            {

                MessageBox.Show("مشکل در ثبت نهایی پیامک " + "\n" + ex.Message);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                Save_Services();
                send_sms();

            }
            catch (Exception)
            {


            }
        }
        //int run = 0;
        private void Change_Category(string category)
        {
            dgFood.Rows.Clear();
            dgFood2.Rows.Clear();
            dgFood3.Rows.Clear();
            try
            {
                using (var context = new StimulsoftEntities())
                {
                    //var kindServ = context.KindService.ToList();
                    //dgCategory.DataSource = kindServ;
                    //-----
                    //category = dgCategory.Rows[0].Cells[0].Value.ToString();

                    var kindKala = context.Prodoct.Where(c => c.NameService == category).ToList();
                    //DataGridView d = new DataGridView();

                    if (kindKala.Count > 0)
                    {

                        dgFoods.DataSource = kindKala;
                        for (int i = 0; i < dgFoods.RowCount; i++)
                        {
                            if (i <= 7)
                                dgFood.Rows.Add(dgFoods.Rows[i].Cells[0].Value);
                            if (i >= 8 && i <= 15)
                                dgFood2.Rows.Add(dgFoods.Rows[i].Cells[0].Value);
                            if (i >= 16)
                                dgFood3.Rows.Add(dgFoods.Rows[i].Cells[0].Value);

                        }
                        //-----
                        foodSelect = dgFood.Rows[0].Cells[0].Value.ToString();

                        //dgCategory.DataSource = kindServ;

                    }
                    if (dgServ.RowCount <= 0)
                    {
                        var nameServ = context.NameService.ToList();
                        if (nameServ.Count > 0)
                        {
                            dgServ.DataSource = nameServ;
                            dgServ.Columns[1].Visible = false;
                            dgServ.Columns[2].Visible = false;
                            dgServ.Columns[0].HeaderText = "سرویس";
                            dgServ.Columns[0].Width = 177;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("4:" + ex.Message);

            }

        }

        private void FormServices_Load(object sender, EventArgs e)
        {
            btnSave2.Enabled = false;
            //int run = 0;
            try
            {
                lblSomeService.Text = "0";
                using (var context = new StimulsoftEntities())
                {
                    var kindServ = context.Category.ToList();
                    if (kindServ.Count > 0)
                    {
                        dgCategory.DataSource = kindServ;
                        categorySelect = dgCategory.CurrentCell.Value.ToString();
                        Change_Category(categorySelect); // estefade az metode Change_Category baraye dorost kardane list mahsolat
                        //foodSelect = dgFood.CurrentCell.Value.ToString();
                        dgFood2.ClearSelection();
                        dgFood3.ClearSelection();
                        lblCategory.Text = dgCategory.CurrentCell.Value.ToString();

                        dgCategory.Columns[1].Visible = false;
                        dgCategory.Columns[0].HeaderText = "دسته";
                        dgCategory.Columns[0].Width = 177;
                        if (dgServ.RowCount > 0)
                            serviceSelect = dgServ.CurrentCell.Value.ToString();

                    }

                    //*******Auto Fill Eshterak - Name - Phone
                    if (chxNewCustomer.Checked == false)
                    {
                        if (context.User.Count() > 0)
                        {
                            var select = context.User.ToList();
                            //------

                            string[] eshterak = new string[select.Count];
                            for (int i = 0; i < select.Count; i++)
                            {
                                eshterak[i] = select[i].Eshterak.ToString();
                            }
                            //txtEshterak.AutoCompleteSource = AutoCompleteSource.CustomSource;
                            AutoCompleteStringCollection suggest = new AutoCompleteStringCollection();
                            txtEshterak.AutoCompleteCustomSource = suggest;
                            suggest.AddRange(eshterak);
                            //-----------
                            string[] Name = new string[select.Count];
                            for (int i = 0; i < select.Count; i++)
                            {
                                Name[i] = select[i].Name.ToString();
                            }
                            //txtName.AutoCompleteSource = AutoCompleteSource.CustomSource;
                            AutoCompleteStringCollection suggestName = new AutoCompleteStringCollection();
                            txtName.AutoCompleteCustomSource = suggestName;
                            suggestName.AddRange(Name);
                            //-------
                            string[] Phone = new string[select.Count];
                            for (int i = 0; i < select.Count; i++)
                            {
                                Phone[i] = select[i].Phone.ToString();
                            }
                            AutoCompleteStringCollection suggestPhone = new AutoCompleteStringCollection();
                            txtPhone.AutoCompleteCustomSource = suggestPhone;
                            suggestPhone.AddRange(Phone);
                        }
                    }
                    //var selectCodeRahgiri = context.Service.ToList();
                    //string[] CodeRahgiri = new string[selectCodeRahgiri.Count];
                    //for (int i = 0; i < selectCodeRahgiri.Count; i++)
                    //{
                    //    CodeRahgiri[i] = selectCodeRahgiri[i].CodeRahgiri.ToString();
                    //}
                    ////txtEshterak.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    //AutoCompleteStringCollection suggestCodeRahgiri = new AutoCompleteStringCollection();
                    //txtCodeRahgiri.AutoCompleteCustomSource = suggestCodeRahgiri;
                    //suggestCodeRahgiri.AddRange(CodeRahgiri);
                    //-----------

                    //******

                    dtNewService.Text=Practical.Today_Date();

                    if (txtPrice.Text == "")
                        btnAddService.Enabled = true;

                    dtNewService.Text=Practical.Today_Date();


                    ////var kindServ = context.KindService.ToList();
                    //comServiceKind.DataSource = kindServ;
                    //comServiceKind.DisplayMember = "Name";
                    ////----------
                    //var kindKalacom = context.KindKala.Where(c => c.NameService == comServiceKind.Text).ToList();
                    //comKindKala.DataSource = kindKalacom;
                    //comKindKala.DisplayMember = "Name";
                    ////---------
                    //var nameServcom = context.NameService.ToList();
                    //comServiceName.DataSource = nameServcom;
                    //comServiceName.DisplayMember = "Name";
                    //---------
                    //var selectService = context.NameService.Where(c => c.Name == comServiceName.Text).FirstOrDefault();

                }

                //-------


                //----

                radOffline.Checked = true;
                txtEshterak.Focus();
            }
            catch (Exception ex)
            {

                MessageBox.Show("1 " + ex.Message);

            }


        }


        private void txtEshterak_TextChanged(object sender, EventArgs e)
        {

        }

        private class servrvice
        {
            public string Name { get; set; }
            public string DateService { get; set; }
            public string Eshterak { get; set; }
            public string NumberService { get; set; }
            public string SumPrice { get; set; }
            public string khedmat { get; set; }
            public string Some { get; set; }
            public string Price { get; set; }
            public string Rahgiri { get; set; }
            public string serv { get; set; }


        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            if (txtValueAdded.Text == "")
                txtValueAdded.Text = "0";
            try
            {
                if (txtEshterak.Text == "")
                {
                    //lblError.ForeColor = Color.Red;
                    lblError.Text = "شماره اشتراک خالی است";
                }
                if (dgShow.Rows.Count == 0)
                {
                    lblError.Text = "هیچ خدمتی ثبت نشده";
                    return;
                }
                string nameshop="";
                using (var context = new StimulsoftEntities())
                {
                    var Name = context.Setting.Where(current => current.CommercialName != null).FirstOrDefault();
                    if (Name.CommercialName == "")
                    {
                        MessageBox.Show("نام تجاری را از بخش تنطیمات ثبت کنید", "نام تجاری", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    nameshop = Name.CommercialName;

                    List<servrvice> list = new List<servrvice>();
                    for (int i = 0; i < dgShow.Rows.Count; i++)
                    {
                        servrvice serv = new servrvice
                        {
                            Name = txtName.Text,
                            DateService = dtNewService.Text,
                            Eshterak = txtEshterak.Text,
                            NumberService = lblSomeService.Text,
                            Rahgiri = lblCodeRahgiri.Text,
                            khedmat = dgShow.Rows[i].Cells[1].Value.ToString(),
                            Some = dgShow.Rows[i].Cells[3].Value.ToString(),
                            Price = dgShow.Rows[i].Cells[5].Value.ToString(),
                            //-----
                            SumPrice = txtSumServices.Text,
                            serv = dgShow.Rows[i].Cells[2].Value.ToString(),

                        };

                        list.Add(serv);
                    }
                    StiReport report = new StiReport();
                    report.Load(Application.StartupPath + "\\RptService.mrt");

                    report.RegBusinessObject("Service", list);

                    (report.GetComponentByName("DataService_Name") as StiText).Enabled = txtName.Enabled;
                    (report.GetComponentByName("DataService_Eshterak") as StiText).Enabled = txtEshterak.Enabled;
                    (report.GetComponentByName("DataService_DateService") as StiText).Enabled = dtNewService.Enabled;

                    (report.GetComponentByName("DataService_Some") as StiText).Enabled = dgShow.Enabled;
                    (report.GetComponentByName("DataService_Price") as StiText).Enabled = dgShow.Enabled;
                    (report.GetComponentByName("DataService_khedmat") as StiText).Enabled = dgShow.Enabled;
                    txtSumServices.Enabled = true;
                    //(report.GetComponentByName("DataService_SumPrice") as StiText).Enabled = txtSumServices.Enabled;
                    (report.GetComponentByName("Text7") as StiText).Text = nameshop;
                    (report.GetComponentByName("Text10") as StiText).Text = txtSumTakhfif.Text;
                    (report.GetComponentByName("Text12") as StiText).Text = txtPay.Text;
                    (report.GetComponentByName("Text14") as StiText).Text = txtBeiane.Text;
                    (report.GetComponentByName("DataService_SumPrice") as StiText).Text = txtSumServices.Text;
                    (report.GetComponentByName("txtTime") as StiText).Text = DateTime.Now.ToShortTimeString();
                    (report.GetComponentByName("dataValueAdded") as StiText).Text = txtValueAdded.Text;
                    txtSumServices.Enabled = false;
                    //------ select printer
                    if (context.Device.Count() > 0)
                    {
                        var selectPrinter = context.Device.FirstOrDefault();
                            if (!string.IsNullOrEmpty(selectPrinter.Printer1))
                            {
                                report.PrinterSettings.PrinterName = selectPrinter.Printer1;
                                report.Print();
                            }
                            if (!string.IsNullOrEmpty(selectPrinter.Printer2))
                            {
                                report.Load(Application.StartupPath + "\\RptService.mrt");
                                (report.GetComponentByName("Text7") as StiText).Text = nameshop;
                                (report.GetComponentByName("Text10") as StiText).Text = txtSumTakhfif.Text;
                                (report.GetComponentByName("Text12") as StiText).Text = txtPay.Text;
                                (report.GetComponentByName("Text14") as StiText).Text = txtBeiane.Text;
                                (report.GetComponentByName("dataValueAdded") as StiText).Text = txtValueAdded.Text;
                                report.PrinterSettings.PrinterName = selectPrinter.Printer2;
                                report.Print();
                            }
                            if (!string.IsNullOrEmpty(selectPrinter.Printer3))
                            {
                                report.Load(Application.StartupPath + "\\RptService.mrt");
                                (report.GetComponentByName("Text7") as StiText).Text = nameshop;
                                (report.GetComponentByName("Text7") as StiText).Text = nameshop;
                                (report.GetComponentByName("Text10") as StiText).Text = txtSumTakhfif.Text;
                                (report.GetComponentByName("Text12") as StiText).Text = txtPay.Text;
                                (report.GetComponentByName("Text14") as StiText).Text = txtBeiane.Text;
                                (report.GetComponentByName("dataValueAdded") as StiText).Text = txtValueAdded.Text;
                                report.PrinterSettings.PrinterName = selectPrinter.Printer3;
                                report.Print();
                            }




                        //    report.PrinterSettings.PrinterName = selectPrinter.Printer1;
                        //    //report.Print(false);
                        //    report.Show();
                        //    //------------------
                        //    DialogResult = MessageBox.Show("پرینتر دوم پرینت بگیرد", "پرینتر", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        //    if (DialogResult == DialogResult.Yes)
                        //    {
                        //        report.Load(Application.StartupPath + "\\RptService.mrt");

                        //        report.PrinterSettings.PrinterName = selectPrinter.Printer2;
                        //        report.Print(false);
                        //    }
                        //}
                        //else
                        //    lblError.Text = "برینتر را از بخش تنظیمات انتخاب کنید";
                        ////-------------

                    }
                    else
                    {
                        lblError.Text = "برینتر را از بخش تنظیمات انتخاب کنید";
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //lblError.ForeColor = Color.Red;
                //lblError.Text = "کاربری بااین شماره اشتراک وجود ندارد,خطا";
                //txtEshterak.Focus();
            }
        }

        public void print_Sefaresh()
        {

        }

        private void btnServiceUpdate_Click(object sender, EventArgs e)
        {

        }
        //************
        // code rahgiri sade
        private string Build_CodeRahgiri()
        {
            Int64 code = 0;
            string code2 = "";
            try
            {
                using (var context = new StimulsoftEntities())
                {
                    var getCode = context.Setting.FirstOrDefault();
                    if (getCode.EndCreateCodeRahgiri != null)
                        code = Convert.ToInt64(getCode.EndCreateCodeRahgiri);
                    else
                        code = 0;

                    code++;
                    getCode.EndCreateCodeRahgiri = code;
                    context.SaveChanges();
                }

                code2 = code.ToString();
                //MessageBox.Show(code2);
                return code2;
            }
            catch (Exception ex)
            {

                MessageBox.Show("مشکل در کد رهگیری" + "\n" + ex.Message);
            }
            return code2;
        }
        //----------
        //dorost kardane adade randome gheire tekrari
        private string GreateUniqueNumbericID()
        {

            byte[] bytes = Guid.NewGuid().ToByteArray();

            string code = BitConverter.ToInt32(bytes, 0).ToString();
            string code2 = code.Substring(0, 1);
            //hazf kardane "-" az avale adad
            if (code2.IndexOf('-') == 0)
                code = code.Remove(0, 1);
            //dorost kardane adad 6 raghami va kamtar
            if (code.Length > 7)
                code = code.Substring(0, 6);
            return code;

        }
        //-------------

        private void txtEshterak_KeyPress(object sender, KeyPressEventArgs e)
        {
            Enter_Number(sender, e);
        }

        private void txtCarKm_KeyPress(object sender, KeyPressEventArgs e)
        {
            Enter_Number(sender, e);
        }

        private void txtNextServiceKm_KeyPress(object sender, KeyPressEventArgs e)
        {
            Enter_Number(sender, e);
        }

        private void txtNumberService_KeyPress(object sender, KeyPressEventArgs e)
        {
            Enter_Number(sender, e);
        }

        private void txtSomeMotorOil_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            Service_Register();
        }

        private void btnSaveUser_Click(object sender, EventArgs e)
        {
            StimulsoftEntities context = new StimulsoftEntities();
            string message = "";
            try
            {
                lblError.Text = "";
                if (txtPhone.TextLength > 11 || txtPhone.TextLength < 11 || txtPhone.Text.StartsWith("09") == false)
                {
                    //lblError.ForeColor = Color.Red;
                    lblError.Text = "شماره موبایل اشتباه است";
                    //txtPhone.Text = "0";
                    txtPhone.Focus();
                    return;
                }
                else
                    lblError.Text = "";

                if (txtEshterak.Text == "")
                {
                    MessageBox.Show("شماره اشتراک خالی است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtName.Text == "")
                {
                    lblError.Text = "نام را وارد کنید";
                    return;
                }
                if (txtPhone.Text == "")
                {
                    lblError.Text = "شماره تماس را وارد کنید";
                    return;
                }

                bool isContact = context.User.Where(check => check.Eshterak == txtEshterak.Text).Any();
                if (isContact)
                {
                    //MessageBox.Show("کاربری بااین شماره اشتراک وجود دارد", "اشتراک", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //lblError.ForeColor = Color.Red;
                    lblError.Text = "کاربری بااین شماره اشتراک وجود دارد";
                    txtPhone.Focus();
                    return;
                }
                bool isPhone = context.User.Where(check => check.Phone == txtPhone.Text).Any();
                if (isPhone)
                {
                    //MessageBox.Show("کاربری بااین شماره اشتراک وجود دارد", "اشتراک", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //lblError.ForeColor = Color.Red;
                    lblError.Text = "کاربری بااین شماره تماس وجود دارد";
                    txtPhone.Focus();
                    return;
                }
                else
                {

                    User user = new User();
                    user.Name = txtName.Text;
                    user.Phone = txtPhone.Text;
                    user.Eshterak = txtEshterak.Text;
                    user.Date = int.Parse(dtNewService.Text.Replace("/", ""));
                    user.Email = txtEmail.Text;
                    user.Address = txtAddress.Text;
                    user.PostiCode = txtPostiCode.Text;
                    if (dtBirthDay.Text == "")
                        user.BirthDayDate = 0;
                    else
                        user.BirthDayDate = int.Parse(dtBirthDay.Text.Replace("/", ""));
                    //************

                    context.User.Add(user);
                    context.SaveChanges();
                    //lblError.ForeColor = Color.Green;
                    lblError.Text = "اطلاعات با موفقیت ثبت شد";
                }


                //btnSave2.Enabled = true;
            }
            catch (Exception ex)
            {

                MessageBox.Show("مشکل در ثبت مشتری" + "\n" + ex.Message);
            }
            //********** Sms Part
            try
            {
                int vaziyzt = 1;
                var sign = context.Setting.FirstOrDefault();
                if (sign.WelcomeSms == "true")
                {
                    vaziyzt = 1;
                }
                else
                {
                    vaziyzt = 0;
                }
                if (vaziyzt == 0)
                    return;
                
                var sms = context.WhiteSms.Where(c => c.W1 != null || c.W1 != "").FirstOrDefault();
                //|| c.CommercialName != null
                var setName = context.Setting.Where(c => c.CommercialName != "").FirstOrDefault();
                if (setName == null)
                {
                    MessageBox.Show("برای ارسال پیامک ابتدااز بخش تنظیمات پیامک نام تجاری را ثبت کنید", "تنظیمات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                message = Sms.text_Welcom_Sms(sms.W1, dtNewService.Text, txtEshterak.Text, txtName.Text);
                //-----
                string signature = sign.Signature;
                string numberSms = sign.NumberSms;
                if (signature != "" && signature != "null" && numberSms != "" && numberSms != "null" && int.Parse(sms.W2) < 100) // baraye esrasale sms test
                {
                    signature = "407CA55D-B3C4-4502-ABC5-DB95F7FB2AB0";
                    numberSms = "10001000300076";
                }
                if (signature == null || signature == "" || numberSms == null || numberSms == "")
                {
                    //lblError.ForeColor = Color.Red;
                    lblError.Text = "از قسمت تنظیمات امضا دیجیتال و شماره پیامک را ثبت کنید";
                    lblError.ForeColor = Color.Black;
                    return;
                }
                //-------
                if (txtPhone.TextLength > 11 || txtPhone.TextLength < 11 || txtPhone.Text.StartsWith("09") == false)
                {
                    //lblError.ForeColor = Color.Red;
                    lblError.Text = "شماره موبایل اشتباه است";
                    txtPhone.Focus();
                    return;
                }
                // frestadane sms Welcom
                new Thread(() => //tread ferestadane sms
                {
                    if (vaziyzt == 1)
                    {
                        try
                        {
                            Ping ping = new Ping();
                            PingReply pingStatus = ping.Send("google.com");
                            if (pingStatus.Status == IPStatus.Success)
                            {
                                var check = context.WhiteSms.FirstOrDefault();
                                double warning = double.Parse(check.R10);
                                string result = "";
                                if (signature != "null" && signature != "" && numberSms != "null" && numberSms != "")
                                     result =Sms.Send_Sms(message, txtPhone.Text, signature, numberSms, warning);
                                if (signature == "407CA55D-B3C4-4502-ABC5-DB95F7FB2AB0" &&result=="0")
                                {
                                    int countSmsTest = int.Parse(sms.W2);
                                    countSmsTest++;
                                    sms.W2 = countSmsTest.ToString();
                                }

                            }
                            context.SaveChanges();
                        }

                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            ErsalNashode En = new ErsalNashode();
                            En.Name = txtName.Text;
                            En.Phone = txtPhone.Text;
                            En.Message = message;
                            En.Date = int.Parse(dtNewService.Text.Replace("/", ""));
                            En.Time = DateTime.Now.ToLongTimeString();
                            En.CodeRahgiri = lblCodeRahgiri.Text;
                            context.ErsalNashode.Add(En);
                            context.SaveChanges();
                            //MessageBox.Show("اینترنت وصل نیست", "اینترنت", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            MessageBox.Show("اینترنت وصل نیست،در موارد ارسال نشده ذخیره شد", " وصل نیست اینترنت", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }


                    }
                }).Start();
            }
            catch (Exception ex)
            {

                MessageBox.Show("مشکل در ارسال پیامک خوش آمدگویی" + "\n" + ex.Message);
            }
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            int vaziyat = 1;
            string codeRahgiri = "";
            if (txtEndRahgiri.Text != "")
                codeRahgiri = txtEndRahgiri.Text;
            else
                codeRahgiri = txtCodeRahgiri.Text;
            try
            {
                if (string.IsNullOrEmpty(txtEndRahgiri.Text) && string.IsNullOrEmpty(txtCodeRahgiri.Text))
                {
                    //lblError.ForeColor = Color.Red;
                    lblError.Text = "کد رهگیری را وارد کنید";
                    return;
                }
                using (var context = new StimulsoftEntities())
                {

                    var x = context.Setting.FirstOrDefault();
                    if (x.ReadySms == "true")
                    {
                        vaziyat = 1;
                    }
                    else
                    {
                        vaziyat = 0;
                    }
                    //------
                    if (txtEndRahgiri.Text != "")
                        codeRahgiri = txtEndRahgiri.Text;
                    else
                        codeRahgiri = txtCodeRahgiri.Text;
                    var select = context.ReportService.Where(c => c.CodeRahgiri == codeRahgiri).ToList();
                    for (int i = 0; i < select.Count; i++)
                    {
                        select[i].Ready = "0"; // 0 = anjam shode

                    }
                    context.SaveChanges();
                    //------
                }
            }
            catch (Exception)
            {
                lblError.Text = "ابتدا باید مشخصات مدیر را در بخش تنظیمات ثبت کنید";
                return;
                //MessageBox.Show(ex.Message);
            }

            if (vaziyat == 1)
            {
                string result = "";
                try
                {
                    if (txtPhone.TextLength > 11 || txtPhone.TextLength < 11 || txtPhone.Text.StartsWith("09") == false)
                    {
                        //lblError.ForeColor = Color.Red;
                        lblError.Text = "شماره موبایل اشتباه است";
                        //txtPhone.Text = "0";
                        txtPhone.Focus();
                        return;
                    }

                    using (var context = new StimulsoftEntities())
                    {
                        var x = context.ReportService.Where(c => c.CodeRahgiri == codeRahgiri).FirstOrDefault();

                        if (x == null)
                        {
                            //lblError.ForeColor = Color.Red;
                            lblError.Text = "شماره رهگیری اشتباه است";
                            return;
                        }
                        var selectphone = context.User.Where(c => c.Eshterak == x.Eshterak).FirstOrDefault();
                        string phone = selectphone.Phone;
                        string eshterak = selectphone.Eshterak;
                        string name = selectphone.Name;

                        var sign = context.Setting.FirstOrDefault();
                        var sms = context.WhiteSms.Where(c => c.R1 != null && c.R1 != "").FirstOrDefault();

                        //------
                        string signature = sign.Signature;
                        string numberSms = sign.NumberSms;
                        if (signature != "" && signature != "null" && numberSms != "" && numberSms != "null" && int.Parse(sms.W2) < 100) // baraye esrasale sms test
                        {
                            signature = "407CA55D-B3C4-4502-ABC5-DB95F7FB2AB0";
                            numberSms = "10001000300076";
                        }
                        if (signature == "null" || signature == "" || numberSms == "null" || numberSms == "")
                        {
                            //lblError.ForeColor = Color.Red;
                            lblError.Text = "از قسمت تنظیمات امضا دیجیتال و شماره پیامک را ثبت کنید";
                            //lblError.ForeColor = Color.Black;
                            return;
                        }
                        //-----
                        var setName = context.Setting.Where(c => c.CommercialName != "" || c.CommercialName != null).FirstOrDefault();
                        if (setName == null)
                        {
                            MessageBox.Show("از بخش تنظیمات پیامک نام تجاری را ثبت کنید", "تنظیمات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        string message = Sms.text_Ready_Sms(sms.R1, dtNewService.Text, eshterak, txtCodeRahgiri.Text, name);// dorost kardane matne sms
                        //------
                        var check = context.WhiteSms.FirstOrDefault();
                        double warning = double.Parse(check.R10);
                        //-----
                       
                        if(signature !="null" && signature !="" && numberSms !="null" && numberSms != "")
                            result = Sms.Send_Sms(message, phone, signature, numberSms, warning);
                        if (signature == "407CA55D-B3C4-4502-ABC5-DB95F7FB2AB0" && result=="0")
                        {
                            int countSmsTest = int.Parse(sms.W2);
                            countSmsTest++;
                            sms.W2 = countSmsTest.ToString();
                        }
                        //------
                        if (result == "0")
                        {
                            var sendSms = context.Service.Where(c => c.CodeRahgiri == codeRahgiri).FirstOrDefault();
                            if (sendSms.ReadyDate == null)
                                sendSms.ReadyDate = int.Parse(dtNewService.Text.Replace("/", ""));
                            sendSms.SendReadySms++;
                            //context.SaveChanges();
                        }
                        else
                        {
                            var sendSms = context.Service.Where(c => c.CodeRahgiri == codeRahgiri).FirstOrDefault();
                            if (sendSms.ReadyDate == null || sendSms.ReadyDate == 0)
                                sendSms.ReadyDate = int.Parse(dtNewService.Text.Replace("/", ""));
                            //-----
                            ErsalNashode En = new ErsalNashode();
                            En.Name = selectphone.Name;
                            En.Phone = selectphone.Phone;
                            En.Message = message;
                            En.Date = int.Parse(dtNewService.Text.Replace("/", ""));
                            En.Time = DateTime.Now.ToLongTimeString();
                            En.CodeRahgiri = txtCodeRahgiri.Text;
                            context.ErsalNashode.Add(En);
                            if (result != "-64")
                            {
                                MessageBox.Show("اینترنت وصل نیست،در موارد ارسال نشده ذخیره شد", " وصل نیست اینترنت", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        context.SaveChanges();
                    }
                }
                catch (Exception)
                {
                    try
                    {
                        StimulsoftEntities context = new StimulsoftEntities();
                        var sendSms = context.Service.Where(c => c.CodeRahgiri == codeRahgiri).FirstOrDefault();
                        if (sendSms.ReadyDate == null || sendSms.ReadyDate == 0)
                            sendSms.ReadyDate = int.Parse(dtNewService.Text.Replace("/", ""));
                        var sms = context.WhiteSms.Where(c => c.R1 != null && c.R1 != "").FirstOrDefault();
                        var setName = context.Setting.Where(c => c.CommercialName != "" || c.CommercialName != null).FirstOrDefault();
                        var serv = context.Service.Where(c => c.CodeRahgiri == codeRahgiri).FirstOrDefault();

                        //-----
                        string message = Sms.text_Ready_Sms(sms.R1, dtNewService.Text, serv.Eshterak, serv.CodeRahgiri, serv.Name);
                        ErsalNashode En = new ErsalNashode();
                        En.Name = serv.Name;
                        En.Phone = serv.Mobile;
                        En.Message = message;
                        En.Date = int.Parse(dtNewService.Text.Replace("/", ""));
                        En.Time = DateTime.Now.ToLongTimeString();
                        En.CodeRahgiri = txtCodeRahgiri.Text;
                        context.ErsalNashode.Add(En);
                        context.SaveChanges();
                        MessageBox.Show("اینترنت وصل نیست،در موارد ارسال نشده ذخیره شد", " وصل نیست اینترنت", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("1");
                    }
                }
            }
            else
            {
                try
                {
                    using (var context = new StimulsoftEntities())
                    {
                        var sendSms = context.Service.Where(c => c.CodeRahgiri == codeRahgiri).FirstOrDefault();
                        if (sendSms.ReadyDate == null || sendSms.ReadyDate == null)
                            sendSms.ReadyDate = int.Parse(dtNewService.Text.Replace("/", ""));
                        context.SaveChanges();
                        lblError.Text = "اطلاعات ثبت شد.پیامک ارسال نشد،به بخش تنظیمتات بروید";
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("2" + "\n" + ex.Message);
                }
            }
        }

        private void btnAddService_Click(object sender, EventArgs e)
        {

            lblError.Text = "";
            try
            {
                using (var context = new StimulsoftEntities())
                {
                    var name = context.ServicesPrice.Where(c => c.ServisKind == categorySelect && c.ServiceKala == foodSelect && c.ServiseName == serviceSelect).FirstOrDefault();
                    if (name == null)
                    {
                        ServicesPrice pri = new ServicesPrice();
                        pri.ServisKind = categorySelect;
                        pri.ServiceKala = foodSelect;
                        pri.ServiseName = serviceSelect;

                        //if (txtServisPrice.Text != "")
                        pri.ServicePrice = Convert.ToInt64(txtPrice.Text.Replace(",", ""));
                        // else
                        //pri.ServicePrice1 = 0;
                        //context.SaveChanges();

                        context.ServicesPrice.Add(pri);
                        //lblError.ForeColor = Color.Green;
                        lblError.Text = "قیمت ثبت شد";
                    }
                    else
                    {
                        name.ServicePrice = Convert.ToInt64(txtPrice.Text.Replace(",", ""));
                    }
                    context.SaveChanges();

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("مشکل در اضافه کردن قیمت" + "\n" + ex.Message);
            }
        }


        private void dgShow_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                dgShow.Rows.Remove(dgShow.CurrentRow);
                //-----
                Int64 sum = 0;
                Int64 valueAdded = 0;
                for (int i = 0; i < dgShow.RowCount; i++)
                {

                    sum = sum + Convert.ToInt64(dgShow.Rows[i].Cells[5].Value.ToString().Replace(",", ""));
                    valueAdded = valueAdded + Convert.ToInt64(dgShow.Rows[i].Cells[8].Value.ToString().Replace(",", ""));
                }
                txtValueAdded.Text = valueAdded.ToString();
                txtSumServices.Text = sum.ToString();

            }
        }


        private void button1_Click_2(object sender, EventArgs e)
        {
            lblError.Text = "";
            if (string.IsNullOrEmpty(txtEndRahgiri.Text) && string.IsNullOrEmpty(txtCodeRahgiri.Text))// check kardane code rahgiri
            {
                //lblError.ForeColor = Color.Red;
                lblError.Text = "کد رهگیری را وارد کنید";
                return;
            }
            // chrck kardane shomare mobile
            if (txtPhone.TextLength > 11 || txtPhone.TextLength < 11 || txtPhone.Text.StartsWith("09") == false)
            {
                //lblError.ForeColor = Color.Red;
                lblError.Text = "شماره موبایل اشتباه است";
                //txtPhone.Text = "0";
                txtPhone.Focus();
                return;
            }
            string codeRahgiri = "";
            if (txtEndRahgiri.Text != "")
                codeRahgiri = txtEndRahgiri.Text;
            else
                codeRahgiri = txtCodeRahgiri.Text;
            int vaziyat = 1;
            try
            {
                using (var context = new StimulsoftEntities())
                {


                    var x = context.Setting.FirstOrDefault();
                    if (x.DeliverySms == "true")
                    {
                        vaziyat = 1;
                    }
                    else
                    {
                        vaziyat = 0;
                    }
                }
            }
            catch (Exception)
            {
                lblError.Text = "ابتدا باید مشخصات مدیر را در بخش تنظیمات ثبت کنید";
                return;
                // MessageBox.Show(ex.Message);
            }
            try
            {
                StimulsoftEntities context = new StimulsoftEntities();
                var serv = context.Service.Where(c => c.CodeRahgiri == codeRahgiri).FirstOrDefault();
                var sms = context.WhiteSms.Where(c => c.D1 != null && c.D1 != "").FirstOrDefault();
                var x = context.ReportService.Where(c => c.CodeRahgiri == codeRahgiri).FirstOrDefault();
                var setName = context.Setting.Where(c => c.CommercialName != "" || c.CommercialName != null).FirstOrDefault();
                string message = Sms.text_Delivery_Sms(sms.D1, dtNewService.Text, serv.CodeRahgiri, serv.Eshterak, serv.Name);



                //-----ersal sms
                if (vaziyat == 1)
                {
                    if (setName == null) // check kardane name tejari
                    {
                        MessageBox.Show("از بخش تنظیمات نام تجاری را ثبت کنید", "تنظیمات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    var check = context.WhiteSms.FirstOrDefault();
                    double warning = double.Parse(check.R10);

                    var sign = context.Setting.FirstOrDefault();

                    //***********baraye check kardane ertebat
                    //HttpWebRequest reqCheack = (HttpWebRequest)WebRequest.Create("http://login.parsgreen.com/UrlService/sendSMS.ashx?from=");
                    //System.Net.WebResponse respCheack = reqCheack.GetResponse();
                    //***********
                    if (x == null)
                    {
                        //lblError.ForeColor = Color.Red;
                        lblError.Text = "شماره رهگیری اشتباه است";
                        return;
                    }
                    var selectphone = context.User.Where(c => c.Eshterak == x.Eshterak).FirstOrDefault();
                    txtPhone.Text = selectphone.Phone;
                    //-----
                    string signature = sign.Signature;
                    string numberSms = sign.NumberSms;
                    if (signature != "" && signature != "null" && numberSms != "" && numberSms != "null" && int.Parse(sms.W2) < 100) // baraye esrasale sms test
                    {
                        signature = "407CA55D-B3C4-4502-ABC5-DB95F7FB2AB0";
                        numberSms = "10001000300076";
                    }
                    if (signature == "" || signature == "null" || numberSms == "" || numberSms == "null" ) // baraye esrasale sms test
                    {
                        //lblError.ForeColor = Color.Red;
                        lblError.Text = "از قسمت تنظیمات امضا دیجیتال و شماره پیامک را ثبت کنید";
                        lblError.ForeColor = Color.Black;
                        return;
                    }
                    //-------
                    string result = "";            
                    if (signature != "null" && signature != "" && numberSms != "null" && numberSms != "")
                         result = Sms.Send_Sms(message, serv.Mobile, signature, numberSms, warning);
                    if (signature == "407CA55D-B3C4-4502-ABC5-DB95F7FB2AB0" && result == "0")
                    {
                        int countSmsTest = int.Parse(sms.W2);
                        countSmsTest++;
                        sms.W2 = countSmsTest.ToString();
                    }

                    //--------
                    //System.Web.HttpUtility.HtmlDecode(text);
                    //MessageBox.Show(message);
                    //return;

                    // Sms.Send_Sms(message, selectphone.Phone, sign.Signature, sign.NumberSms, warning);
                    context.SaveChanges();

                    //******
                    return;
                    //}

                }


            }
            catch (Exception)
            {
                try
                {
                    StimulsoftEntities context = new StimulsoftEntities();
                    var serv = context.Service.Where(c => c.CodeRahgiri == txtCodeRahgiri.Text).FirstOrDefault();
                    var sms = context.WhiteSms.Where(c => c.D1 != null && c.D1 != "").FirstOrDefault();
                    var x = context.ReportService.Where(c => c.CodeRahgiri == txtCodeRahgiri.Text).FirstOrDefault();
                    var setName = context.Setting.Where(c => c.CommercialName != "" || c.CommercialName != null).FirstOrDefault();

                    string message = Sms.text_Delivery_Sms(sms.D1, dtNewService.Text, serv.CodeRahgiri, serv.Eshterak, serv.Name);

                    ErsalNashode En = new ErsalNashode();
                    En.Name = serv.Name;
                    En.Phone = serv.Mobile;
                    En.Message = message;
                    En.Date = int.Parse(dtNewService.Text.Replace("/", ""));
                    En.Time = DateTime.Now.ToLongTimeString();
                    En.CodeRahgiri = txtCodeRahgiri.Text;

                    context.ErsalNashode.Add(En);
                    context.SaveChanges();
                    //------
                    MessageBox.Show("اینترنت وصل نیست،در موارد ارسال نشده ذخیره شد", " وصل نیست اینترنت", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                catch (Exception)
                {
                    lblError.Text = "";

                }



            }

        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            Enter_Number(sender, e);
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                if (string.IsNullOrEmpty(txtEndRahgiri.Text) && string.IsNullOrEmpty(txtCodeRahgiri.Text))
                {
                    //lblError.ForeColor = Color.Red;
                    lblError.Text = "کد رهگیری را وارد کنید";
                    return;
                }
                using (var context = new StimulsoftEntities())
                {
                    string codeRahgiri = "";
                    if (txtEndRahgiri.Text != "")
                        codeRahgiri = txtEndRahgiri.Text;
                    else
                        codeRahgiri = txtCodeRahgiri.Text;
                    var x = context.Service.Where(c => c.CodeRahgiri == codeRahgiri).FirstOrDefault();

                    if (x == null)
                    {
                        //lblError.ForeColor = Color.Red;
                        lblError.Text = "شماره رهگیری اشتباه است";
                        return;
                    }
                    else
                    {
                        lblError.Text = x.SumServices.ToString();
                        long sumService = long.Parse(lblError.Text);
                        lblError.Text = x.Bestankar.ToString();
                        long bestankar = long.Parse(lblError.Text);
                        lblError.Text = x.Takhfif.ToString();
                        long takhfif = long.Parse(lblError.Text);

                        lblError.Text = x.Pardakhti.ToString();
                        long pardkhti = long.Parse(lblError.Text);

                        long baghimande = (sumService - (pardkhti + takhfif + bestankar));
                        if (baghimande < 0)
                            baghimande = 0;
                        // baghimande kol
                        string[] retMande = (Kole_Mande(txtEshterak.Text)).Split(',');
                        lblError.Text = "" + "\n";
                        string typeReport = "";
                        if (sumService == 0 && bestankar > 0) // baraye tashkhise noe pardakhti
                            typeReport = "جهت تصفیه" + "\n";

                        string message = typeReport + "مبلغ بیعانه: " + Seragham(bestankar.ToString()) + "\n" + "تخفیف: " + Seragham(takhfif.ToString()) + "\n" + "مبلغ کل: " + Seragham(sumService.ToString()) + "\n" + "پرداختی: " + Seragham(pardkhti.ToString()) + "\n" + " مانده این کد رهگیری: " + Seragham(baghimande.ToString()) + "\n" + "کل مانده حساب: " + Seragham(retMande[0]);
                        MessageBox.Show(message, "گزارش", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    }
                }
            }
            catch (Exception)
            {

                lblCodeRahgiri.Text = "";
            }
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }


        private void txtPostiCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            Enter_Number(sender, e);

        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            txtPrice.Text = Seragham(txtPrice.Text);
            txtPrice.Select(txtPrice.TextLength, 0);
        }

        private void txtBeiane_TextChanged_1(object sender, EventArgs e)
        {

            lblError.Text = "";
            try
            {
                ////----------beiane
                //if (txtBeiane.Text == "")
                //    txtBeiane.Text = "0";

                //double beiane;
                //if (txtBeiane.Text != "")
                //    beiane = int.Parse(txtBeiane.Text.Replace(",", ""));
                //else
                //    beiane = 0;
                //if (txtPay.Text == "")
                //    txtPay.Text = "0";
                ////----------takhfif
                //if (txtDarsadTakhfif.Text == "")
                //    txtDarsadTakhfif.Text = "0";
                ////-----------mande
                //if (txtMande.Text == "0")
                //    txtMande.Text = "0";

                //double darsad;
                //if (txtDarsadTakhfif.Text != "")
                //    darsad = int.Parse(txtDarsadTakhfif.Text);
                //else
                //    darsad = 0;
                //if (darsad > 100)
                //    txtDarsadTakhfif.Text = "100";
                //if (darsad < 0)
                //    txtDarsadTakhfif.Text = "0";
                //double totalSome = double.Parse(txtSumServices.Text.Replace(",", ""));
                //double sum = double.Parse(txtPay.Text.Replace(",", ""));

                //double takhfif = totalSome * darsad;
                //takhfif = takhfif / 100;
                //txtSumTakhfif.Text = takhfif.ToString();

                //double mande = double.Parse(txtMande.Text.Replace(",", ""));

                ////----------

                //txtPay.Text = (((totalSome - beiane) - takhfif) + mande).ToString();
                //------
                //Some_Paye();
                txtBeiane.Text = Seragham(txtBeiane.Text);
                txtBeiane.Select(txtBeiane.TextLength, 0);

            }
            catch (Exception)
            {
                lblError.Text = "مشکل در حساب تخفیف";
            }
        }

        private void txtSumTakhfif_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                //Some_Paye();
                txtSumTakhfif.Text = Seragham(txtSumTakhfif.Text);
                txtSumTakhfif.Select(txtSumTakhfif.TextLength, 0);
            }
            catch (Exception)
            {
                lblError.Text = "مشکل در حساب تخفیف";
            }



        }

        private void txtSumServices_TextChanged_1(object sender, EventArgs e)
        {
            txtSumServices.Text = Seragham(txtSumServices.Text);
            txtSumServices.Select(txtSumServices.TextLength, 0);
            //Some_Paye();
        }

        private void txtBeiane_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            Enter_Number(sender, e);
        }

        private void txtSumServices_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            Enter_Number(sender, e);
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            Enter_Number(sender, e);
        }

        private void txtDarsadTakhfif_TextChanged_1(object sender, EventArgs e)
        {

            lblError.Text = "";
            //btnSave2.Enabled = true;
            try
            {
                //if (txtSumTakhfif.Text == "")
                //    txtSumTakhfif.Text = "0";
                ////----------beiane
                //if (txtBeiane.Text == "")
                //    txtBeiane.Text = "0";

                //double beiane;
                //if (txtBeiane.Text != "")
                //    beiane = int.Parse(txtBeiane.Text.Replace(",", ""));
                //else
                //    beiane = 0;
                //if (txtPay.Text == "")
                //    txtPay.Text = "0";
                ////----------takhfif
                //if (txtDarsadTakhfif.Text == "")
                //    txtDarsadTakhfif.Text = "0";
                ////-----------mande
                //if (txtMande.Text == "0")
                //    txtMande.Text = "0";
                //double darsad;
                //if (txtDarsadTakhfif.Text != "")
                //    darsad = int.Parse(txtDarsadTakhfif.Text);
                //else
                //    darsad = 0;
                //if (darsad > 100)
                //    txtDarsadTakhfif.Text = "100";
                //if (darsad < 0)
                //    txtDarsadTakhfif.Text = "0";
                //double totalSome = double.Parse(txtSumServices.Text.Replace(",", ""));
                //double sum = double.Parse(txtPay.Text.Replace(",", ""));

                //double takhfif = totalSome * darsad;
                //takhfif = takhfif / 100;
                //txtSumTakhfif.Text = takhfif.ToString();

                //double mande = double.Parse(txtMande.Text.Replace(",", ""));
                ////----------

                //txtPay.Text = (((totalSome - beiane) - takhfif)+mande).ToString();
                ////------
                //Some_Paye();
                txtBeiane.Text = Seragham(txtBeiane.Text);
                txtBeiane.Select(txtBeiane.TextLength, 0);
                Some_Paye();

            }
            catch (Exception)
            {
                lblError.Text = "مشکل در حساب تخفیف";
            }
        }

        private void txtDarsadTakhfif_KeyPress(object sender, KeyPressEventArgs e)
        {
            Enter_Number(sender, e);
        }

        private void txtEshterak_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            Enter_Number(sender, e);

        }

        private void txtEshterak_TextChanged_2(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                txtEndRahgiri.Text = "";
                //-----

                dgShow.Rows.Clear();
                txtSumServices.Text = "";
                txtEmail.Text = "";
                lblCodeRahgiri.Text = "";
                lblError.Text = "";
                txtBeiane.Text = "";
                txtBeforeBeiane.Text = "";
                txtPay.Text = "";
                txtDarsadTakhfif.Text = "0";
                txtSumTakhfif.Text = "0";
                txtMande.Text = "0";
                lblTotalPrice.Text = "";


                //-----
                if (chxNewCustomer.Checked == false)
                {
                    using (var context = new StimulsoftEntities())
                    {
                        var countService = context.Service.Where(c => c.Eshterak == txtEshterak.Text).ToList();
                        lblSomeService.Text = countService.Count.ToString();

                        var mobile = context.User.Where(serv => serv.Eshterak == txtEshterak.Text).FirstOrDefault();
                        if (mobile == null)
                        {
                            txtName.Text = "";
                            txtPhone.Text = "";
                            txtAddress.Text = "";
                            txtEmail.Text = "";
                            txtPostiCode.Text = "";
                            dtBirthDay.Text = "";
                            dtBirthDay.Enabled = true;
                            return;
                        }
                        else
                        {
                            txtName.Text = mobile.Name;
                            txtPhone.Text = mobile.Phone;
                            txtAddress.Text = mobile.Address;
                            txtEmail.Text = mobile.Email;
                            txtPostiCode.Text = mobile.PostiCode;
                            //BPersianCalenderTextBox cal = new BPersianCalenderTextBox();
                            string date = mobile.BirthDayDate.ToString();
                            //dtBirthDay.Shamsi = mobile.BirthDayDate.ToString();
                            if (date.Length > 5)
                            {
                                date = date.Insert(4, "/");
                                date = date.Insert(7, "/");
                                dtBirthDay.Text = date;
                            }
                            dtBirthDay.Enabled = false;

                            //dtBirthDay.Text = mobile.BirthDayDate.ToString();
                        }

                        //------akharin code rahgiri in shomare eshterak
                        var find = context.Service.Where(c => c.Eshterak == txtEshterak.Text).ToList();
                        if (find != null)
                        {
                            var end = find.LastOrDefault();
                            txtEndRahgiri.Text = end.CodeRahgiri;
                            //txtCodeRahgiri.Text = end.CodeRahgiri;
                        }

                    }
                    string[] ret = (Calculate.Remaining_Total(txtEshterak.Text)).Split(',');
                    txtMande.Text = ret[0];
                    txtBeiane.Text = "0";
                    txtBeforeBeiane.Text =Seragham(ret[1]);
                    lblTotalPrice.Text = Seragham(ret[2]);

                }
            }
            catch (Exception)
            {

                lblError.Text = "";
            }
        }

        public string Kole_Mande(string eshterak)
        {
            StimulsoftEntities context = new StimulsoftEntities();
            var price = context.Service.Where(c => c.Eshterak == txtEshterak.Text).ToList();
            //------mohasebe jame baghimande
            long bestankar = 0, takhfif = 0, pardakhti = 0, sumService = 0, sum = 0, totalSum = 0, valueAdded = 0;


            for (int i = 0; i < price.Count; i++)
            {
                pardakhti = 0; bestankar = 0; takhfif = 0; sumService = 0;
                takhfif = Int64.Parse(takhfif + price[i].Takhfif.Value.ToString());
                bestankar = price[i].Bestankar.Value;
                pardakhti = price[i].Pardakhti.Value;
                sumService = price[i].SumServices.Value;
                valueAdded = price[i].ValueAdded.Value;
                totalSum = totalSum + sumService;//kole mablaghe khadamat
                sum = sum + ((sumService + valueAdded) - (pardakhti + bestankar + takhfif));
            }
            return sum.ToString() + "," + totalSum.ToString();
        }
        private void sumAfterTakhfif_TextChanged(object sender, EventArgs e)
        {
            //somePaye();
            //txtsumAfterTakhfif.Text = Seragham(txtsumAfterTakhfif.Text);
            //txtsumAfterTakhfif.Select(txtsumAfterTakhfif.TextLength, 0);
        }

        private void txtsumAfterTakhfif_KeyPress(object sender, KeyPressEventArgs e)
        {
            Enter_Number(sender, e);

        }

        private void btnSearchCodeRahgiri_Click(object sender, EventArgs e)
        {

        }

        private void txtPay_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //Some_Paye();
                if (txtPay.Text == "")
                    txtPay.Text = "0";
                txtPay.Text = Seragham(txtPay.Text);
                txtPay.Select(txtPay.TextLength, 0);

            }
            catch (Exception)
            {
                lblError.Text = "مشکل در حساب تخفیف";
            }

        }

        private void txtEshterak_Leave(object sender, EventArgs e)
        {
            try
            {
                using (var context = new StimulsoftEntities())
                {
                    string today = dtNewService.Text.Replace("/", "").Substring(4, 4);
                    var Userbirthday = context.User.Where(c => c.Eshterak == txtEshterak.Text).First();
                    if (Userbirthday.BirthDayDate.ToString().Substring(4, 4) == today)
                    {
                        MessageBox.Show(" تولد " + Userbirthday.Name + " است ");
                    }
                }
            }
            catch (Exception)
            {

                lblError.Text = "";
            }
        }

        private void txtMande_TextChanged(object sender, EventArgs e)
        {
            txtMande.Text = Seragham(txtMande.Text);
            txtMande.Select(txtMande.TextLength, 0);
        }

        private void txtMande_KeyPress(object sender, KeyPressEventArgs e)
        {
            Enter_Number(sender, e);
        }

        private void txtPay_KeyPress(object sender, KeyPressEventArgs e)
        {
            Calculate_Pardakhti(sender, e);
            Enter_Number(sender, e);

        }

        private void txtBeiane_Leave(object sender, EventArgs e)
        {
            //Some_Paye();
        }

        private void txtDarsadTakhfif_Leave(object sender, EventArgs e)
        {
            //Some_Paye();
        }

        private void txtMande_Leave(object sender, EventArgs e)
        {
            //Some_Paye();
        }

        private void txtSumTakhfif_Leave(object sender, EventArgs e)
        {
            //Some_Paye();
        }

        private void btnErsalNashode_Click(object sender, EventArgs e)
        {
            FormErsalNashode frmErsalNashode = new FormErsalNashode();
            frmErsalNashode.Show();

        }
        private void txtValueAdded_Leave(object sender, EventArgs e)
        {
            //Some_Paye();
        }
        private void txtPhone_TextChanged_1(object sender, EventArgs e)
        {
            lblError.Text = "";
            StimulsoftEntities context = new StimulsoftEntities();
            var select = context.User.Where(serv => serv.Phone == txtPhone.Text).FirstOrDefault();
            if (chxNewCustomer.Checked == false)
            {

                if (select != null)
                {
                    txtEshterak.Text = select.Eshterak;
                    txtName.Text = select.Name;
                }
            }
            else
            {
                if (txtPhone.TextLength == 11)
                {
                    txtEshterak.Text = txtPhone.Text.Substring(6, 5);
                    txtName.Text = "";
                    txtName.Focus();
                    var check = context.User.Where(c => c.Eshterak == txtEshterak.Text).FirstOrDefault();
                    if (check != null)
                    {
                        lblError.Text = "این شماره اشتراک وجود دارد";
                        txtName.Text = check.Name;
                        txtPhone.Focus();
                    }
                }
            }
        }

        private void txtPhone_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            Enter_Number(sender, e);
        }

        private void btnEditSmallReport_Click(object sender, EventArgs e)
        {
            FormEditSmallReport frmSmallReport = new FormEditSmallReport();
            frmSmallReport.label1.Text = txtCodeRahgiri.Text;
            frmSmallReport.label2.Text = "edit"; //baraye inke data gride view edit sakhte shavad
            frmSmallReport.Show();
        }


        private void btnPay_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            try
            {
                if (txtEshterak.Text == "")
                {
                    lblError.Text = "شماره اشتراک راوارد کنید";
                    return;

                }
                if (txtPay.Text == "" || txtPay.Text == "0")
                {
                    lblError.Text = "مقدار پرداختی را وارد کنید";
                    return;
                }
                else
                {
                    StimulsoftEntities context = new StimulsoftEntities();
                    var selectUser = context.User.Where(c => c.Eshterak == txtEshterak.Text).FirstOrDefault();
                    if (selectUser != null)
                    {
                        Add_Service(txtEshterak.Text);
                        Add_Report_Service(txtEshterak.Text);
                    }
                    else
                    {

                        lblError.Text = "کد اشتراک اشتباه است";
                        return;
                    }

                }

            }
            catch (Exception)
            {

                lblError.Text = "خطا در پرداخت";
            }
        }
        public void Add_Report_Service(string eshterak)
        {
            try
            {
                StimulsoftEntities context = new StimulsoftEntities();
                ReportService repServ = new ReportService();
                repServ.Eshterak = eshterak;
                repServ.Date = int.Parse(dtNewService.Text.Replace("/", ""));
                repServ.Kind = "";
                repServ.Kala = "";
                repServ.Service = "";
                repServ.Some = "";
                repServ.Price = txtPay.Text.Replace(",","");
                repServ.CodeRahgiri = codeRahgiri;
                repServ.NumberServise = "";
                repServ.Ready = "1";
                repServ.ValueAdded =0;
                context.ReportService.Add(repServ);
                context.SaveChanges();
                lblError.Text = "ثبت شد";

            }
            catch (Exception ex) { MessageBox.Show("پرداخت" + "\n" + ex.Message); }
        }
        string codeRahgiri = "";
        public void Add_Service(string eshterak)
        {
            try
            {
                StimulsoftEntities context = new StimulsoftEntities();
                Service serv = new Service();
                var selectUser = context.User.Where(c => c.Eshterak == eshterak).FirstOrDefault();
                serv.Eshterak = selectUser.Eshterak;

                codeRahgiri = Build_CodeRahgiri();
                serv.CodeRahgiri = codeRahgiri;
                serv.Bestankar = int.Parse(txtPay.Text.Replace(",", ""));
                serv.DateService = int.Parse(dtNewService.Text.Replace("/", ""));
                serv.Description = txtDescription.Text;
                serv.Mobile = selectUser.Phone;
                serv.Name = selectUser.Name;
                serv.ValueAdded = 0;
                serv.Takhfif = 0;
                serv.SumServices = 0;
                serv.Pardakhti = 0;
                //------
                if (radKart.Checked)
                    serv.PayeState = "کارت";
                else
                    serv.PayeState = "نقدی";
                //-------
                Int32 countServices = Convert.ToInt32(lblSomeService.Text);
                countServices++;
                serv.NumberService = countServices.ToString();
                serv.ReadyDate = 0;
                serv.SendReadySms = 0;
                if (radOffline.Checked)
                {
                    serv.OrderState = "حضوری";
                }
                else
                {
                    serv.OrderState = "غیر حضوری";
                }

                context.Service.Add(serv);
                context.SaveChanges();
                lblError.Text = "ثبت شد";

            }
            catch (Exception ex) { MessageBox.Show("پرداخت" + "\n" + ex.Message); }
        }

        private void comCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (chxNewCustomer.Checked == false)
            {
                StimulsoftEntities context = new StimulsoftEntities();
                var select = context.User.Where(serv => serv.Name == txtName.Text).FirstOrDefault();
                if (select != null)
                {
                    txtEshterak.Text = select.Eshterak;
                    txtPhone.Text = select.Phone;
                }
            }
        }

        private void txtCodeRahgiri_TextChanged_1(object sender, EventArgs e)
        {
            lblError.Text = "";
            txtBeiane.Text = "0";
            txtSumTakhfif.Text = "0";
            txtDarsadTakhfif.Text = "0";
            txtSumServices.Text = "0";
            txtPay.Text = "0";
            txtMande.Text = "0";
            try
            {
                if (txtCodeRahgiri.Text == "")
                    return;

                StimulsoftEntities context = new StimulsoftEntities();
                var selectRahgiri = context.Service.Where(c => c.CodeRahgiri == txtCodeRahgiri.Text).FirstOrDefault();
                if (selectRahgiri == null)
                {
                    //btnSave2.Enabled = true;
                    //lblError.Text = "کد رهگیری اشتباه است";
                    return;
                }
                else
                {
                    txtName.Text = selectRahgiri.Name;
                    txtEshterak.Text = selectRahgiri.Eshterak;
                    txtPhone.Text = selectRahgiri.Mobile;
                    //txtBeiane.Text = selectRahgiri.Bestankar.ToString();
                    string beiane = selectRahgiri.Bestankar.ToString();
                    //txtSumTakhfif.Text = selectRahgiri.Takhfif.ToString();
                    string takhfif = selectRahgiri.Takhfif.ToString();
                    //txtSumServices.Text = selectRahgiri.SumServices.ToString();
                    string sumService = selectRahgiri.SumServices.ToString();
                    string Pay = selectRahgiri.Pardakhti.ToString();
                    string valueAdded = "0";
                    if (selectRahgiri.ValueAdded != null)
                    {
                        valueAdded = selectRahgiri.ValueAdded.ToString();

                    }


                    int b = int.Parse(beiane), t = int.Parse(takhfif), s = int.Parse(sumService), p = int.Parse(Pay), v = int.Parse(valueAdded);
                    Int64 cal = (s + v) - (b + t + p);
                    //txtPay.Text = cal.ToString();
                    if (cal < 0)
                        txtBeiane.Text = cal.ToString().Remove(0, 1);
                    if (cal >= 0)
                        txtMande.Text = cal.ToString();
                    //btnSave2.Enabled = false;
                }

            }
            catch (Exception)
            {

                lblError.Text = "خطا در پرداخت";
            }
        }

        private void chxNewCustomer_CheckedChanged(object sender, EventArgs e)
        {
            if (chxNewCustomer.Checked == false)
            {
                using (var context = new StimulsoftEntities())
                {
                    //*******Auto Fill Eshterak - Name - Phone
                    if (chxNewCustomer.Checked == false)
                    {
                        var select = context.User.ToList();
                        //------

                        string[] eshterak = new string[select.Count];
                        for (int i = 0; i < select.Count; i++)
                        {
                            eshterak[i] = select[i].Eshterak.ToString();
                        }
                        //txtEshterak.AutoCompleteSource = AutoCompleteSource.CustomSource;
                        AutoCompleteStringCollection suggest = new AutoCompleteStringCollection();
                        txtEshterak.AutoCompleteCustomSource = suggest;
                        suggest.AddRange(eshterak);
                        //-----------
                        string[] Name = new string[select.Count];
                        for (int i = 0; i < select.Count; i++)
                        {
                            Name[i] = select[i].Name.ToString();
                        }
                        //txtName.AutoCompleteSource = AutoCompleteSource.CustomSource;
                        AutoCompleteStringCollection suggestName = new AutoCompleteStringCollection();
                        txtName.AutoCompleteCustomSource = suggestName;
                        suggestName.AddRange(Name);
                        //-------
                        string[] Phone = new string[select.Count];
                        for (int i = 0; i < select.Count; i++)
                        {
                            Phone[i] = select[i].Phone.ToString();
                        }
                        AutoCompleteStringCollection suggestPhone = new AutoCompleteStringCollection();
                        txtPhone.AutoCompleteCustomSource = suggestPhone;
                        suggestPhone.AddRange(Phone);
                    }
                }
            }
            else
            {

                txtEshterak.AutoCompleteCustomSource = null;
                txtName.AutoCompleteCustomSource = null;
                txtPhone.AutoCompleteCustomSource = null;
                txtName.Text = "";
                txtPhone.Text = "";
                txtEshterak.Text = "";
                txtPhone.Focus();
                dtBirthDay.Enabled = true;
            }
        }

        private void txtEshterak_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            using (var context = new StimulsoftEntities())
            {
                var editUser = context.User.Where(c => c.Eshterak == txtEshterak.Text).FirstOrDefault();
                if (editUser != null)
                {
                    FormEditUser frmEditUser = new FormEditUser();
                    frmEditUser.txtEshterak.Text = editUser.Eshterak;
                    //---------------------
                    frmEditUser.txtName.Text = editUser.Name;
                    //---------------------
                    if (editUser.Date == 0)
                        frmEditUser.txtEnter.Text = "";
                    else
                        frmEditUser.txtEnter.Text = editUser.Date.ToString();
                    //---------------------
                    frmEditUser.txtPhone.Text = editUser.Phone;
                    //---------------------
                    frmEditUser.txtEmail.Text = editUser.Email;
                    //---------------------
                    if (editUser.BirthDayDate == 0)
                        frmEditUser.txtBirthDay.Text = "";
                    else
                        frmEditUser.txtBirthDay.Text = editUser.BirthDayDate.ToString();
                    //---------------------
                    frmEditUser.txtAddress.Text = editUser.Address;
                    //---------------------
                    frmEditUser.txtPostiCode.Text = editUser.PostiCode;
                    //---------------------
                    frmEditUser.phoneNumber = editUser.Phone;
                    frmEditUser.Show();
                }
            }
        }

        private void txtName_DoubleClick(object sender, EventArgs e)
        {
            using (var context = new StimulsoftEntities())
            {
                var editUser = context.User.Where(c => c.Name == txtName.Text).FirstOrDefault();
                if (editUser != null)
                {
                    FormEditUser frmEditUser = new FormEditUser();
                    frmEditUser.txtEshterak.Text = editUser.Eshterak;
                    //---------------------
                    frmEditUser.txtName.Text = editUser.Name;
                    //---------------------
                    frmEditUser.txtEnter.Text = editUser.Date.ToString();
                    //---------------------
                    frmEditUser.txtPhone.Text = editUser.Phone;
                    //---------------------
                    frmEditUser.txtEmail.Text = editUser.Email;
                    //---------------------
                    frmEditUser.txtBirthDay.Text = editUser.BirthDayDate.ToString();
                    //---------------------
                    frmEditUser.txtAddress.Text = editUser.Address;
                    //---------------------
                    frmEditUser.txtPostiCode.Text = editUser.PostiCode;
                    //---------------------
                    frmEditUser.Show();
                }
            }
        }

        private void txtPhone_DoubleClick(object sender, EventArgs e)
        {
            using (var context = new StimulsoftEntities())
            {
                var editUser = context.User.Where(c => c.Phone == txtPhone.Text).FirstOrDefault();
                if (editUser != null)
                {
                    FormEditUser frmEditUser = new FormEditUser();
                    frmEditUser.txtEshterak.Text = editUser.Eshterak;
                    //---------------------
                    frmEditUser.txtName.Text = editUser.Name;
                    //---------------------
                    frmEditUser.txtEnter.Text = editUser.Date.ToString();
                    //---------------------
                    frmEditUser.txtPhone.Text = editUser.Phone;
                    //---------------------
                    frmEditUser.txtEmail.Text = editUser.Email;
                    //---------------------
                    frmEditUser.txtBirthDay.Text = editUser.BirthDayDate.ToString();
                    //---------------------
                    frmEditUser.txtAddress.Text = editUser.Address;
                    //---------------------
                    frmEditUser.txtPostiCode.Text = editUser.PostiCode;
                    //---------------------
                    frmEditUser.Show();
                }
            }
        }

        private void txtCodeRahgiri_DoubleClick(object sender, EventArgs e)
        {
            using (var context = new StimulsoftEntities())
            {
                var editService = context.Service.Where(c => c.CodeRahgiri == txtCodeRahgiri.Text).FirstOrDefault();
                if (editService != null)
                {
                    FormEditService frmEditSer = new FormEditService();

                    frmEditSer.txtEshterak.Text = editService.Eshterak;
                    //-----------
                    frmEditSer.txtName.Text = editService.Name;
                    //-----------
                    frmEditSer.txtDateService.Text = editService.DateService.ToString();
                    //-----------
                    frmEditSer.txtPhone.Text = editService.Mobile;
                    //-----------
                    frmEditSer.txtBeiane.Text = editService.Bestankar.ToString();
                    //-----------
                    frmEditSer.txtPardakhti.Text = editService.Pardakhti.ToString();
                    //-----------
                    frmEditSer.txtTakhfif.Text = editService.Takhfif.ToString();
                    //-----------
                    frmEditSer.txtTotalSum.Text = editService.SumServices.ToString();
                    //-----------
                    frmEditSer.txtCodeRahgiri.Text = editService.CodeRahgiri;
                    //-----------
                    frmEditSer.txtSomeService.Text = editService.NumberService;
                    //-----------
                    frmEditSer.txtReadyDate.Text = editService.ReadyDate.ToString();
                    //-----------
                    frmEditSer.txtReadySms.Text = editService.SendReadySms.ToString();
                    //-----------
                    frmEditSer.txtDescription.Text = editService.Description;
                    //-----------

                    frmEditSer.Show();
                }
            }
        }
        private void dgCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            categorySelect = dgCategory.CurrentCell.Value.ToString();
            Change_Category(categorySelect);
            dgFood.ClearSelection();
            dgFood2.ClearSelection();
            dgFood3.ClearSelection();
        }

        private void dgFood_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foodSelect = dgFood.CurrentCell.Value.ToString();
            select_price();

            dgFood2.ClearSelection();

            dgFood3.ClearSelection();
        }

        private void dgServ_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            serviceSelect = dgServ.CurrentCell.Value.ToString();
            select_price();
        }

        private void dgFood2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foodSelect = dgFood2.CurrentCell.Value.ToString();
            select_price();
            dgFood.ClearSelection();
            dgFood3.ClearSelection();
        }

        private void dgFood3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foodSelect = dgFood3.CurrentCell.Value.ToString();
            select_price();

            dgFood.ClearSelection();
            dgFood2.ClearSelection();
        }

        private void dgFood_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Service_Register();
        }

        private void dgFood2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Service_Register();
        }

        private void dgFood3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Service_Register();
        }

        private void txtValueAdded_TextChanged(object sender, EventArgs e)
        {
            txtValueAdded.Text = Seragham(txtValueAdded.Text);
            txtValueAdded.Select(txtValueAdded.TextLength, 0);
        }



        private void txtValueAdded_KeyPress(object sender, KeyPressEventArgs e)
        {
            Enter_Number(sender, e);

        }

        private void txtSumTakhfif_KeyPress(object sender, KeyPressEventArgs e)
        {
            Enter_Number(sender, e);

        }

        private void dgShow_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            btnSave2.Enabled = true;
        }

        private void dgShow_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (dgShow.RowCount <= 0)
                btnSave2.Enabled = false;
        }

        private void btnViewService_Click(object sender, EventArgs e)
        {
            FormEditSmallReport frmSmallReport = new FormEditSmallReport();
            frmSmallReport.label1.Text = txtEndRahgiri.Text;
            frmSmallReport.label2.Text = "edit"; //baraye inke data gride view edit sakhte shavad
            frmSmallReport.Show();
        }

        private void txtEndRahgiri_KeyPress(object sender, KeyPressEventArgs e)
        {
            Enter_Number(sender, e);

        }

        private void numSome_KeyPress(object sender, KeyPressEventArgs e)
        {
            Enter_Number(sender, e);
        }

        private void txtPay_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData==Keys.Space)
            {
                Some_Paye();
            }
        }
    }
}