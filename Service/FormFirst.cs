using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Service
{
    public partial class FormFirst : Form
    {
        int adad = 0;
        public FormFirst()
        {
            InitializeComponent();

        }
        private void Enter_Number(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }

        }
        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            Enter_Number(sender, e);
        }

        private async void btnRegisterInternet_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                txtName.BackColor = Color.LightPink;
                txtName.Focus();
                return;
            }
            else
            {
                txtName.BackColor = Color.White;
            }
            //--------
            if (txtManageName.Text == "")
            {
                txtManageName.BackColor = Color.LightPink;
                txtManageName.Focus();
                return;
            }
            else
            {
                txtManageName.BackColor = Color.White;
            }
            //--------
            if (txtMobile.Text == "" || txtMobile.TextLength != 11 || txtMobile.Text.StartsWith("09") == false)
            {
                txtMobile.BackColor = Color.LightPink;
                txtMobile.Focus();
                MessageBox.Show("شماره موبایل اشتباه است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                txtMobile.BackColor = Color.White;
            }

            Random rnd =new Random();
             adad = rnd.Next(1000,9999);
            try
            {
                Ping ping = new Ping();
                PingReply pingStatus = ping.Send("papiloo.ir");

                if (pingStatus.Status == IPStatus.Success)
                {
                    //DataGridView DGV = new DataGridView();
                    //DGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    string managename = txtManageName.Text,
                    phone = txtMobile.Text,
                    Token = adad.ToString();
                    Data_Importer Data = new Data_Importer();
                    string data = await Data.GET("http://www.papiloo.ir/Papiloo/Register/Sms.php", managename,phone, Token);
                    MessageBox.Show("پیامک کد تایید ارسال شد", "پیامک تایید", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    groupBox1.Enabled = false;
                    btnAccept.Enabled = true;
                    txtAccept.Enabled = true;
                    txtAccept.Focus();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("اینترنت قطع است", "ارتباط", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

        }

        private void FormFirst_Load(object sender, EventArgs e)
        {
            
        }
        //public class Reg
        //{
        //    public string trans { get; set; }

        //}

        //public class RootObject
        //{
        //    public List<Reg> AllPerson { get; set; }
        //}
        //-------------
        public class Reg
        {
            public string Application { get; set; }
            public string Managename { get; set; }
            public string Cammersialname { get; set; }
            public string State { get; set; }
            public string trans { get; set; }
            public string Phone { get; set; }
            public string Tel { get; set; }
            public string Email { get; set; }
            public string Address { get; set; }
            public string Reagent { get; set; }
        }

        public class RootObject
        {
            public List<Reg> AllPerson { get; set; }
        }

        private async void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                if (adad.ToString() == txtAccept.Text)
                {
                    FormMain1 frmMain = new FormMain1();

                    using (var context = new StimulsoftEntities())
                    {
                        var save = context.Setting.FirstOrDefault();
                        //---------------bekhatere inke table faghat 1 record dashte bashad if gozashtam
                        if (save != null)
                        {
                            try
                            {
                                Ping ping = new Ping();
                                PingReply pingStatus = ping.Send("papiloo.ir");

                                if (pingStatus.Status == IPStatus.Success)
                                {
                                    var ser = context.Reg.FirstOrDefault();
                                    string application = "خشکشویی",
                                        managename = txtManageName.Text,
                                        serial = HDDSerialL.SerialNumber(),
                                        cammersialname = txtName.Text,
                                        state = "true",
                                        trans = "",
                                        phone = txtMobile.Text,
                                        tel = txtTel.Text,
                                        email = txtEmail.Text,
                                        address = txtAdress.Text,
                                        Reagent = txtReagent.Text;

                                    Data_Importer Data = new Data_Importer();
                                    string data = await Data.GET("http://www.papiloo.ir/Papiloo/Register/Insert.php", application, managename, serial, cammersialname, state, trans, phone, tel, email, address, Reagent);

                                    //MessageBox.Show("نسخه آزمایشی در دسترس شماست", " ثبت نام", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    //------------tarif etelaate foroshgah va modir
                                    
                                    save.CommercialName = txtName.Text;
                                    save.ManageName = txtManageName.Text;
                                    save.Mobile = txtMobile.Text;
                                    save.Tel = txtTel.Text;
                                    save.Email = txtEmail.Text;
                                    save.Address = txtAdress.Text;
                                    //-----------tanzimate sms
                                    save.GroupSms = "true";
                                    save.WelcomeSms = "true";
                                    save.AcceptSms = "true";
                                    save.ReadySms = "true";
                                    save.DeliverySms = "true";
                                    save.BirthDaySms = "true";
                                    save.InviteClubeSms = "true";
                                    //-----------------
                                    context.SaveChanges();
                                    //----
                                    frmMain.toolCreateServiceToolStripMenuItem.Enabled = true;
                                    frmMain.toolToolsToolStripMenuItem.Enabled = true;
                                    frmMain.toolSearchToolStripMenuItem.Enabled = true;
                                    frmMain.toolSmsToolStripMenuItem.Enabled = true;
                                    frmMain.toolReports.Enabled = true;
                                    frmMain.toolBackupRestore.Enabled = true;
                                    frmMain.toolManageToolStripMenuItem1.Visible = true;
                                    frmMain.toolManagePriceToolStripMenuItem.Visible = true;
                                    frmMain.tooSettingApplication.Visible = true;
                                    frmMain.toolManageToolStripMenuItem.Enabled = true;
                                    frmMain.strlblVersion.Text = "نسخه آزمایشی";
                                    //------ // BARAYE INKE IdPaye ra begirad
                                    MessageBox.Show("نسخه آزمایشی در دسترس شماست", " ثبت نام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    string strReq;
                                    string strData;
                                    Stream dataStream;
                                    StreamReader reader;
                                    WebRequest request;
                                    WebResponse response;
                                    strReq = "http://www.papiloo.ir/Papiloo/Register/Select_Serial.php?Serial=" + HDDSerialL.SerialNumber();
                                    request = WebRequest.Create(strReq);
                                    response = request.GetResponse();
                                    dataStream = response.GetResponseStream();
                                    reader = new StreamReader(dataStream);
                                    strData = reader.ReadToEnd();
                                    //MessageBox.Show(strData);
                                    reader.Close();
                                    response.Close();
                                    //--------
                                    var addReg = context.Reg.FirstOrDefault();
                                   string []a = strData.Split('*');
                                    addReg.IdPaye = a[0];
                                    context.SaveChanges();
                                    Application.Restart();
                                    //this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("اینترنت وصل نیست", "اینترنت", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                            }
                            catch (Exception)
                            {

                                MessageBox.Show("اینترنت قطع است", "ارتباط", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }


                        }
                        else
                        {
                            try
                            {
                                //---------
                                Ping ping = new Ping();
                                PingReply pingStatus = ping.Send("papiloo.ir");

                                if (pingStatus.Status == IPStatus.Success)
                                {
                                    var ser = context.Reg.FirstOrDefault();
                                    string application = "خشکشویی",
                                        managename = txtManageName.Text,
                                        serial = IDGenerator.GetCPUId(),
                                        cammersialname = txtName.Text,
                                        state = "false",
                                        trans = "",
                                        phone = txtMobile.Text,
                                        tel = txtTel.Text,
                                        email = txtEmail.Text,
                                        address = txtAdress.Text,
                                        Reagent = txtReagent.Text;


                                    Data_Importer Data = new Data_Importer();
                                    string data = await Data.GET("http://papiloo.ir/Laundry/Papiloo/Insert.php", application, managename, serial, cammersialname, state, trans, phone, tel, email, address, Reagent);
                                    //MessageBox.Show("نسخه آزمایشی در دسترس شماست", " ثبت نام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //--------
                                    Setting setting = new Setting();
                                    //------------tarif etelaate foroshgah va modir
                                    setting.CommercialName = txtName.Text;
                                    setting.ManageName = txtManageName.Text;
                                    setting.Mobile = txtMobile.Text;
                                    setting.Tel = txtTel.Text;
                                    setting.Email = txtEmail.Text;
                                    setting.Address = txtAdress.Text;
                                    //-----------tanzimate sms
                                    setting.GroupSms = "true";
                                    setting.WelcomeSms = "true";
                                    setting.AcceptSms = "true";
                                    setting.ReadySms = "true";
                                    setting.DeliverySms = "true";
                                    setting.BirthDaySms = "true";
                                    setting.InviteClubeSms = "true";
                                    //-----------------
                                    context.Setting.Add(setting);
                                    context.SaveChanges();
                                    frmMain.strlblVersion.Text = "نسخه آزمایشی";
                                    MessageBox.Show("نسخه آزمایشی در دسترس شماست", " ثبت نام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Application.Restart();
                                    //this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("اینترنت وصل نیست", "اینترنت", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }

                            }
                            catch (Exception)
                            {

                                MessageBox.Show("اینترنت قطع است", "ارتباط", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }


                        }
                    }
                }

                else
                {
                    MessageBox.Show("کد تایید اشتباه است", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void txtTel_KeyPress(object sender, KeyPressEventArgs e)
        {

            Enter_Number(sender, e);
        }
    }
}
