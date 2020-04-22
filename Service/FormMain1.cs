using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Timers;
using System.Data.SQLite;
using System.Data.Entity;

namespace Service
{
    public partial class FormMain1 : Form
    {
        private int childFormNumber = 0;
        public int forDelete;
        public string frmManage = "1";//meghdare avalie
        public FormMain1()
        {
            InitializeComponent();

        }
        public string calCount(string countOpen) // tabdilen dafate baz shodane barname horoof
        {
            string compelete = "";
            string adad = "";
            //int count = textBox1.TextLength;
            for (int i = 0; i < countOpen.Length; i++)
            {
                string spilit = countOpen.Substring(i, 1);

                switch (spilit)
                {
                    case "0":
                        {
                            adad = "z";
                            break;
                        }
                    case "1":
                        {
                            adad = "y";
                            break;
                        }
                    case "2":
                        {
                            adad = "x";
                            break;
                        }
                    case "3":
                        {
                            adad = "w";
                            break;
                        }
                    case "4":
                        {
                            adad = "v";
                            break;
                        }
                    case "5":
                        {
                            adad = "u";
                            break;
                        }
                    case "6":
                        {
                            adad = "t";
                            break;
                        }
                    case "7":
                        {
                            adad = "s";
                            break;
                        }
                    case "8":
                        {
                            adad = "r";
                            break;
                        }
                    case "9":
                        {
                            adad = "q";
                            break;
                        }

                }
                compelete += adad;

            }
            return compelete;
        }
        //--------
        public string reversCalCount(string horoof) // tabdilen dafate baz shodane barname be addad
        {
            string compelete = "";
            string adad = "";
            //int count = textBox1.TextLength;
            for (int i = 0; i < horoof.Length; i++)
            {
                string spilit = horoof.Substring(i, 1);

                switch (spilit)
                {
                    case "z":
                        {
                            adad = "0";
                            break;
                        }
                    case "y":
                        {
                            adad = "1";
                            break;
                        }
                    case "x":
                        {
                            adad = "2";
                            break;
                        }
                    case "w":
                        {
                            adad = "3";
                            break;
                        }
                    case "v":
                        {
                            adad = "4";
                            break;
                        }
                    case "u":
                        {
                            adad = "5";
                            break;
                        }
                    case "t":
                        {
                            adad = "6";
                            break;
                        }
                    case "s":
                        {
                            adad = "7";
                            break;
                        }
                    case "r":
                        {
                            adad = "8";
                            break;
                        }
                    case "q":
                        {
                            adad = "9";
                            break;
                        }

                }
                compelete += adad;

            }
            return compelete;
        }
        //------
        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void toolCreateServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormServices frmServ = new FormServices();
            frmServ.MdiParent = this;
            frmServ.Visible = true;
            splitContainer1.Panel1.Controls.Add(frmServ);
            frmServ.BringToFront();
            //frmServ.Width = splitContainer1.Panel1.Width - 17;
            //frmServ.Height = splitContainer1.Panel1.Height;
            //frmServ.TopLevel = false;
            //frmServ.Parent = this.splitContainer1.Panel1;
            //frmServ.Dock = DockStyle.Left;
            //frmServ.Dock = DockStyle.Fill;
            frmServ.Show();

        }

        private void toolCreateUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNewUser frmuser = new FormNewUser();
            frmuser.MdiParent = this;
            frmuser.Show();
        }

        private void toolDeleteUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDelete frmdelete = new FormDelete();
            frmdelete.MdiParent = this;
            frmdelete.Visible = true;
            splitContainer1.Panel1.Controls.Add(frmdelete);
            frmdelete.BringToFront();
            frmdelete.lbldel.Text = "1";
            frmdelete.Show();
        }

        private void toolDeleteServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDelete frmdelete = new FormDelete();
            frmdelete.lbldel.Text = "2";
            frmdelete.MdiParent = this;
            frmdelete.Visible = true;
            splitContainer1.Panel1.Controls.Add(frmdelete);
            frmdelete.BringToFront();
            frmdelete.Show();
        }

        private void toolSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSearch frmsearch = new FormSearch();
            frmsearch.MdiParent = this;
            frmsearch.Visible = true;
            splitContainer1.Panel1.Controls.Add(frmsearch);
            frmsearch.BringToFront();
            frmsearch.Show();
        }

        private void toolSmsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSms frmSms = new FormSms();
            frmSms.MdiParent = this;
            frmSms.Visible = true;
            splitContainer1.Panel1.Controls.Add(frmSms);
            frmSms.BringToFront();
            frmSms.Show();
        }

        private void toolManageToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormMange frmManage = new FormMange();
            frmManage.MdiParent = this;
            frmManage.label6.Text = stripLblLogin.Text;
            frmManage.Visible = true;
            splitContainer1.Panel1.Controls.Add(frmManage);
            frmManage.BringToFront();
            frmManage.Show();
        }

        private void toolManagePriceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManagePrice frmprice = new FormManagePrice();
            frmprice.MdiParent = this;
            frmprice.Visible = true;
            splitContainer1.Panel1.Controls.Add(frmprice);
            frmprice.BringToFront();
            frmprice.Show();
        }

        private void toolSoftwareEnabale_Click(object sender, EventArgs e)
        {

        }

        private void tooExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolManageToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        public string Get_Serial_Hard() // gereftan serial hard
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
            string hard = "1";
            foreach (ManagementObject info in searcher.Get())
            {

                hard = (info["SerialNumber"].ToString()).Trim();
            }
            return hard;
        }

        public void First_Enter() //vorod baraye avalin bar
        {
            try
            {
                using (var context = new StimulsoftEntities())
                {
                    if (context.Reg.Count() > 0)
                    {
                        var deleteReg = context.Reg.ToList();
                        context.Reg.RemoveRange(deleteReg);
                    }
                    //------
                    if (context.Setting.Count() > 0)
                    {
                        var deleteSet = context.Setting.ToList();
                        context.Setting.RemoveRange(deleteSet);
                    }
                    string date = DateTime.Now.ToShortDateString().Replace("/", "");
                    //string hard = Get_Serial_Hard();
                    Reg reg = new Reg();
                    reg.State = HDDSerialL.SerialNumber();
                    reg.Date = int.Parse(date);
                    //string version = "1";
                    //string s = hard + version + date;
                    //reg.Serial1 = s;
                    reg.CountOpen = 1;
                    //version = exsistSerial.CountOpen.ToString();

                    context.Reg.Add(reg);
                    //-----
                    Setting avlie = new Setting();
                    avlie.EndCreateCodeRahgiri = 0;
                    avlie.ValueAddedPercent = 1;
                    avlie.CalculateAnbar = "آخرین خرید";

                    context.Setting.Add(avlie);

                    //-----
                    bool exsist = context.Manage.Where(c => c.UserName == "admin").Any();
                    if (exsist == false)
                    {
                        Manage manage = new Manage();
                        manage.UserName = "admin";
                        manage.Password = "123";
                        manage.Access = "0";
                        manage.NewService = "0";
                        manage.Tools = "0";
                        manage.Search = "0";
                        manage.Sms = "0";
                        manage.Report = "0";
                        manage.Backup = "0";
                        manage.Setting = "0";
                        context.Manage.Add(manage);
                        context.SaveChanges();

                    }
                    //-----
                    var whhiteSms = context.WhiteSms.Where(c => c.Id == 1).FirstOrDefault();
                    whhiteSms.R11 = "8a1e98m"; //baraye register
                    whhiteSms.R10 = "0"; //baraye ersal code rigister ba panel sms papiloo                    
                    whhiteSms.D11 = "y";

                    context.SaveChanges();
                    strlblVersion.Text = "نسخه آزمایشی";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطا در ورود اولیه:\n" + ex.Message);
            }
        }

        public void Active() //Active kamel ba code hard barabar
        {
            try
            {
                using (var context = new StimulsoftEntities())
                {
                    strlblVersion.Text = "برنامه کامل";
                    Accsess();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(" خطا در برنامه کامل:\n" + ex.Message);
            }
        }

        public void Active_NotEcoal() //Active hast vali serial hard yeki nist
        {
            try
            {
                using (var context = new StimulsoftEntities())
                {
                    string date = DateTime.Now.ToShortDateString().Replace("/", "");
                    string hard = Get_Serial_Hard();

                    MessageBox.Show("نرم افزار کپی شده است.هر کد فعال سازی مخصوص یک دستگاه است", "نرم افزار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DialogResult result = MessageBox.Show("آیا همه اطلاعات پاک شود و نسخه آزمایشی استفاده شود؟", "نرم افزار", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        var deleteReg = context.Reg.FirstOrDefault();
                        if (deleteReg != null)
                            context.Reg.Remove(deleteReg);
                        //------
                        var del = context.Setting.FirstOrDefault();
                        if (del != null)
                            context.Setting.Remove(del);
                        //------
                        var delUser = context.User.ToList();
                        if (delUser != null)
                            context.User.RemoveRange(delUser);
                        //------
                        var delService = context.Service.ToList();
                        if (delService != null)
                            context.Service.RemoveRange(delService);
                        //------
                        var delReportService = context.ReportService.ToList();
                        if (delReportService != null)
                            context.ReportService.RemoveRange(delReportService);
                        //------
                        var delServicePrice = context.ServicesPrice.ToList();
                        if (delServicePrice != null)
                            context.ServicesPrice.RemoveRange(delServicePrice);
                        //------
                        //var delNameService = context.NameServices.ToList();
                        //if (delNameService != null)
                        //    context.NameServices.RemoveRange(delNameService);

                        //------
                        //var delKindService = context.KindServices.ToList();
                        //if (delKindService != null)
                        //    context.KindServices.RemoveRange(delKindService);
                        //------
                        //var delKindKala = context.KindKalas.ToList();
                        //if (delKindKala != null)
                        //    context.KindKalas.RemoveRange(delKindKala);
                        //------
                        var delErsalNashode = context.ErsalNashode.ToList();
                        if (delErsalNashode != null)
                            context.ErsalNashode.RemoveRange(delErsalNashode);
                        //-----
                        var delManege = context.Manage.ToList();
                        if (delManege != null)
                            context.Manage.RemoveRange(delManege);
                        //-----

                        context.SaveChanges();
                        //-----------
                        First_Enter();
                        //Application.Restart();
                    }
                    else
                    {
                        Application.Exit();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطا در بررسی سریال های نامساوی:\n" + ex.Message);
            }
        }

        public void End_Lablator()  //tamoom shodan mohlate test
        {
            try
            {
                MessageBox.Show("زمان نسخه ازمایشی به اتمام رسید.برای استفاده از نرم افزار نیاز به فعال سازی دارید", "فعال سازی", MessageBoxButtons.OK, MessageBoxIcon.Error);
                strlblVersion.Text = "زمان تست برنامه به اتمام رسید";
                toolCreateServiceToolStripMenuItem.Enabled = false;
                toolToolsToolStripMenuItem.Enabled = false;
                toolSearchToolStripMenuItem.Enabled = false;
                toolSmsToolStripMenuItem.Enabled = false;
                toolReports.Enabled = false;
                toolBackupRestore.Enabled = false;
                toolManageToolStripMenuItem1.Visible = false;
                toolManagePriceToolStripMenuItem.Visible = false;
                tooSettingApplication.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطا در نسخه آزماشی محلت تموم شده:\n" + ex.Message);
            }
        }

        public void Endnot_Lablator()  //noskhe azmayeshi
        {
            try
            {

                strlblVersion.Text = "نسخه آزمایشی";
                Accsess();

            }
            catch (Exception ex)
            {
                MessageBox.Show("خطا در نسخه آزماشی:\n" + ex.Message);
            }
        }

        public void Accsess()  //dastresiha
        {
            try
            {
                using (var context = new StimulsoftEntities())
                {
                    var Access = context.Manage.Where(current => current.UserName == stripLblLogin.Text).FirstOrDefault();
                    if (Access.NewService == "1")
                    {
                        toolCreateServiceToolStripMenuItem.Visible = false;
                    }
                    if (Access.Tools == "1")
                    {
                        toolToolsToolStripMenuItem.Visible = false;
                    }
                    if (Access.Search == "1")
                    {
                        toolSearchToolStripMenuItem.Visible = false;
                    }
                    if (Access.Sms == "1")
                    {
                        toolSmsToolStripMenuItem.Visible = false;
                    }
                    if (Access.Report == "1")
                    {
                        toolReports.Visible = false;
                    }
                    if (Access.Backup == "1")
                    {
                        toolBackupRestore.Visible = false;
                    }
                    if (Access.Setting == "1")
                    {
                        toolManageToolStripMenuItem.Visible = false;
                    }
                    //----

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطا در دسترسی:\n" + ex.Message);
            }
        }

        //public string Reg_Code()
        //{
        //    string code="";
        //    //------
        //    StringBuilder alph = new StringBuilder();
        //    StringBuilder num = new StringBuilder();
        //    string serial = Get_Serial_Hard();

        //    if (serial.Length > 14)
        //        serial = serial.Substring(0, 15);
        //    foreach (char c in serial)

        //        if (char.IsDigit(c))
        //            num.Append(c);
        //        else
        //            alph.Append(c);
        //    string alph1 = alph.ToString();
        //    string num1 = num.ToString();

        //    int[] reg = new int[num1.Length];
        //    for (int i = 0; i < num1.Length; i++)
        //    {
        //        reg[i] = Int16.Parse(num1.Substring(i, 1));
        //    }

        //    for (int i = 0; i < num1.Length; i++)
        //    {
        //        reg[i] = reg[i] + 7;

        //    }
        //    Array.Reverse(reg);

        //    //test namayesh
        //    string show, compelet = "";
        //    for (int i = 0; i < num1.Length; i++)
        //    {
        //        show = "";
        //        show = reg[i].ToString();
        //        compelet = compelet + show;

        //    }
        //    //------------------
        //    //------
        //    code = compelet;
        //    return code;
        //}



        private void tooSettingApplication_Click(object sender, EventArgs e)
        {
            FormSettings frmSetting2 = new FormSettings();
            frmSetting2.MdiParent = this;
            frmSetting2.Visible = true;
            splitContainer1.Panel1.Controls.Add(frmSetting2);
            frmSetting2.BringToFront();
            frmSetting2.Show();
            if (strlblVersion.Text == "برنامه کامل")
            {
                frmSetting2.txtRegister.Text = "نرم افزار فعال است";
                frmSetting2.txtSerial.Enabled = false;
                frmSetting2.txtRegister.Enabled = false;
                frmSetting2.btnCreate.Enabled = false;
                frmSetting2.btnSendRegisterCode.Enabled = false;
                frmSetting2.btnRegisterInternet.Enabled = false;
            }
        }

        private void toolSaveBackup_Click(object sender, EventArgs e)
        {

        }

        private void toolRecoverBackup_Click(object sender, EventArgs e)
        {

        }

        private void toolDate_Click(object sender, EventArgs e)
        {
            FormReports frmReports = new FormReports();
            frmReports.MdiParent = this;
            //**********
            frmReports.PanelDate.Visible = true;
            frmReports.PanelUser.Visible = false;
            frmReports.panelProdoct.Visible = false;

            //**********
            frmReports.Visible = true;
            splitContainer1.Panel1.Controls.Add(frmReports);
            frmReports.BringToFront();
            frmReports.Show();
        }

        private void toolReportUser_Click(object sender, EventArgs e)
        {
            FormReports frmReports = new FormReports();
            frmReports.MdiParent = this;
            //**********
            frmReports.label3.Text = "کل سفارشات:";
            frmReports.label4.Text = "کل پرداختی:";
            frmReports.PanelDate.Visible = false;
            frmReports.PanelUser.Visible = true;
            frmReports.panelProdoct.Visible = false;
            frmReports.txtEshterak.Focus();
            frmReports.PanelUser.Location = frmReports.PanelDate.Location;
            //**********
            frmReports.Visible = true;
            splitContainer1.Panel1.Controls.Add(frmReports);
            frmReports.BringToFront();
            frmReports.Show();
        }

        private void toolBackup_Click(object sender, EventArgs e)
        {
            FormBackup frmBackup = new FormBackup();
            frmBackup.MdiParent = this;
            frmBackup.Visible = true;
            splitContainer1.Panel1.Controls.Add(frmBackup);
            frmBackup.BringToFront();
            frmBackup.Show();
        }

        private void toolRestore_Click(object sender, EventArgs e)
        {
            FormRestore frmRestore = new FormRestore();
            frmRestore.MdiParent = this;
            frmRestore.Visible = true;
            splitContainer1.Panel1.Controls.Add(frmRestore);
            frmRestore.BringToFront();
            frmRestore.Show();
        }

        private void toolBirthDay_Click(object sender, EventArgs e)
        {
            FormBirthDay frmBirthday = new FormBirthDay();
            frmBirthday.Show();
        }

        private void toolToolsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void FormMain1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Application.Exit();
        }

        private void FormMain1_FormClosed(object sender, FormClosedEventArgs e)
        {
            log frmLog = new log();
            frmLog.Show();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void delToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //FormNewUser frmNewUser = new FormNewUser();
            //frmNewUser.Show();

            //using (var context = new StimulsoftEntities())
            //{
            //    if (context.Reg.Count() > 0)
            //    {
            //        var deleteReg = context.Reg.ToList();
            //        context.Reg.RemoveRange(deleteReg);
                    
            //        //context.Reg.SqlQuery("DBCC CHECKIDENT (Reg, RESEED, 0)");
            //    }
            //    context.SaveChanges();
            //}

            //------ // BARAYE INKE IdPaye ra begirad
            //string strReq;
            //string strData;
            //Stream dataStream;
            //StreamReader reader;
            //WebRequest request;
            //WebResponse response;
            //strReq = "http://www.papiloo.ir/Papiloo/Register/Update_Pay.php?Serial=" + HDDSerialL.SerialNumber();
            //request = WebRequest.Create(strReq);
            //response = request.GetResponse();
            //dataStream = response.GetResponseStream();
            //reader = new StreamReader(dataStream);
            //strData = reader.ReadToEnd();
            ////MessageBox.Show(strData);
            //reader.Close();
            //response.Close();
            //MessageBox.Show(strData);
            //string[] a = strData.Split('*');
            //StimulsoftEntities context = new StimulsoftEntities();
            //var paye = context.Reg.FirstOrDefault();
            //paye.IdPaye = a[0];
            //context.SaveChanges();
            //--------
            //StimulsoftEntities context = new StimulsoftEntities();
            //var test = context.Reg.FirstOrDefault();
            //test.IdPaye = "asghar11111";
            //context.SaveChanges();
            //Formtest frmTest = new Formtest();

            //FormNewUser frmServ = new FormNewUser();
            //frmServ.MdiParent = this;
            //frmServ.Visible = true;
            //splitContainer1.Panel1.Controls.Add(frmServ);
            ////frmServ.BringToFront();
            ////frmServ.MaximizeBox = false;
            ////frmServ.Dock = DockStyle.Fill;

            ////frmServ.Show();
            //string strReq;
            //string strData;
            //Stream dataStream;
            //StreamReader reader;
            //WebRequest request;
            //WebResponse response;
            //strReq = "http://www.papiloo.ir/Papiloo/Register/Select_Serial.php?Serial=" + HDDSerialL.SerialNumber();
            //request = WebRequest.Create(strReq);
            //response = request.GetResponse();
            //dataStream = response.GetResponseStream();
            //reader = new StreamReader(dataStream);
            //strData = reader.ReadToEnd();
            //MessageBox.Show(strData);
            //reader.Close();
            //response.Close();

        }
        public class Save
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
            public List<Save> AllPerson { get; set; }
        }
        //------
        public class Version
        {
            public int moduleId { get; set; }
            public string moduleName { get; set; }
            public string moduleFileName { get; set; }
            public string moduleType { get; set; }
            public int moduleStatus { get; set; }

        }

        public class RootVersion
        {
            public List<Version> AllPerson { get; set; }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        public void Detect_BirthDay() //tedad tavalod ke emrooz darim
        {
            try
            {
                using (var context = new StimulsoftEntities())
                {

                    string today = Practical.Today_Date().Replace("/", "").Substring(4, 4);
                    var tavalod = context.User.Where(c => c.BirthDayDate.ToString().Substring(4, 4) == today).ToList();
                    //PopupNotifier noti = new PopupNotifier();
                    if (tavalod.Count() > 0)
                    {
                        //MessageBox.Show("امروز تولد " + tavalod.Count.ToString() + " نفر از مشتری ها است", "یاداوری تولد", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        picbirthDayNoti.Visible = true;
                        lblContBirthDayNoti.Visible = true;
                        lblContBirthDayNoti.Text = tavalod.Count.ToString();
                        //noti.TitleText = "تولد";
                        //noti.ContentText = "امروز تولد " + count.ToString() + " نفر از مشتری ها است";
                        //noti.Popup();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "تعداد تولد");
            }
        }
        public void timer_Sms() // tedad SMShaye daryafti chek mikone
        {
            try
            {
                Ping ping = new Ping();
                PingReply pingStatus = ping.Send("papiloo.ir");

                if (pingStatus.Status == IPStatus.Success)
                {
                    StimulsoftEntities context = new StimulsoftEntities();
                    var sign = context.Setting.FirstOrDefault();
                    if (sign != null)
                    {
                        PARSGREEN.API.SMS.Message.MsgService message = new PARSGREEN.API.SMS.Message.MsgService();
                        int getCount = message.GetMsgCount(sign.Signature, 1, false);
                        // (emza,1=sandoghe daryafr.2=sandoghe ersali.3 sandoghe hazfi,true=khande shode.false=khande nashode
                        // null=hame,
                        lblCountSmsNoti.Text = getCount.ToString();
                        //-------
                    }
                }
            }
            catch (Exception)
            {


            }


        }
        public void version() // chek kardane version narmafzar
        {
            string version = "1";
            toolStripVersion.Text = "Version: " + version;
            try
            {
                Ping ping = new Ping();
                PingReply pingStatus = ping.Send("papiloo.ir");

                if (pingStatus.Status == IPStatus.Success)
                {
                    //------
                    //dgvVersion.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    //Data_Importer Data = new Data_Importer();

                    //string version = await Data.GET("http://papiloo.ir/Laundry/Papiloo/Select_Version.php", toolStripVersion.Text);
                    //RootVersion instance2 = JsonConvert.DeserializeObject<RootVersion>(version);
                    //List<Version> LAp = instance2.AllPerson;
                    //dgvVersion.DataSource = LAp;
                    //-------
                    string data = Data_Importer.Request("http://papiloo.ir/Papiloo/Register/Select_Version.php", toolStripVersion.Text);
                    //MessageBox.Show(data);

                    toolStripVersion.Text = "Version: " + version;
                    if (data != version)
                        toolStripVersion.Text = "نسخه جدید در سایت موجود است";

                    //MessageBox.Show("اینترنت وصل نیست","اینترنت",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            {


            }
        }
        public void First_Check_Internet() // check kardan ba saite ke ghablan sabte nam karde ya na
        {
            try
            {
                StimulsoftEntities context = new StimulsoftEntities();
                // baraye inke tashkhis dahad db por ast ya khali agar khali bashad true mishavad
                var set = context.Setting.FirstOrDefault();
                var countOpen = context.Reg.FirstOrDefault();
                if (countOpen == null || set == null)
                {
                    //First_Enter();
                    try
                    {

                        Ping ping = new Ping();
                        PingReply pingStatus = ping.Send("papiloo.ir");

                        if (pingStatus.Status == IPStatus.Success)
                        {
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
                            if (strData.Length > 10) // agar too site sabte nam karde
                            {
                                string[] a = strData.Split('*');
                                if (context.Reg.Count() <= 0)
                                {
                                    Reg reg = new Reg();
                                    reg.IdPaye = a[0];
                                    string date = DateTime.Now.ToShortDateString().Replace("/", "");
                                    reg.State = HDDSerialL.SerialNumber();
                                    reg.Date = int.Parse(date);
                                    reg.CountOpen = 1;
                                    if (a[4] == "1")// pardakht karde 
                                    {
                                        MessageBox.Show("شما قبلا پرداخت کرده اید،نسخه کامل در دسترس شماست", " ثبت نام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        strlblVersion.Text = "نسخه کامل";
                                        reg.Serial1 = IDGenerator.GetOpenLock(HDDSerialL.SerialNumber());
                                    }
                                    else //pardakht naharde
                                    {
                                        MessageBox.Show("شما قبلا ثبت نام کرده اید،نسخه آزمایشی در دسترس شماست", " ثبت نام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        strlblVersion.Text = "نسخه آزمایشی";
                                    }
                                    context.Reg.Add(reg);

                                }
                                if (context.Setting.Count() <= 0)
                                {
                                    Setting setting = new Setting();
                                    setting.ManageName = a[2];
                                    setting.CommercialName = a[3];
                                    setting.Mobile = a[6];
                                    setting.Tel = a[7];
                                    setting.Email = a[8];
                                    setting.Address = a[9];
                                    //-----------tanzimate sms
                                    setting.GroupSms = "true";
                                    setting.WelcomeSms = "true";
                                    setting.AcceptSms = "true";
                                    setting.ReadySms = "true";
                                    setting.DeliverySms = "true";
                                    setting.BirthDaySms = "true";
                                    setting.InviteClubeSms = "true";
                                    context.Setting.Add(setting);
                                    //-----------------
                                }
                                context.SaveChanges();
                                //}
                                //}
                                //else
                                //{
                                //    var save = context.Setting.FirstOrDefault();
                                //    //---------------bekhatere inke table faghat 1 record dashte bashad if gozashtam
                                //    if (save != null)
                                //    {
                                //        //------------tarif etelaate foroshgah va modir
                                //        paye.IdPaye = a[0];
                                //        save.CommercialName = a[3];
                                //        save.ManageName = a[2];
                                //        save.Mobile = a[6];
                                //        save.Tel = a[7];
                                //        save.Email = a[8];
                                //        save.Address = a[9];
                                //        //-----------tanzimate sms
                                //        save.GroupSms = "true";
                                //        save.WelcomeSms = "true";
                                //        save.AcceptSms = "true";
                                //        save.ReadySms = "true";
                                //        save.DeliverySms = "true";
                                //        save.BirthDaySms = "true";
                                //        save.InviteClubeSms = "true";
                                //        //-----------------
                                //        context.SaveChanges();
                                //        MessageBox.Show("شما قبلا پرداخت کرده اید،نسخه کامل در دسترس شماست", " ثبت نام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //        strlblVersion.Text = "نسخه کامل";
                                //    }
                                //    else
                                //    {
                                //        if (context.Reg.Count() <= 0)
                                //        {
                                //            Reg reg2 = new Reg();
                                //            reg2.IdPaye = a[0];
                                //            string date = DateTime.Now.ToShortDateString().Replace("/", "");
                                //            reg2.State = HDDSerialL.SerialNumber();
                                //            reg2.Date = int.Parse(date);
                                //            reg2.CountOpen = 1;
                                //            context.Reg.Add(reg2);

                                //        }
                                //        if (context.Setting.Count() <= 0)
                                //        {
                                //            Setting setting = new Setting();
                                //            setting.ManageName = a[2];
                                //            setting.CommercialName = a[3];
                                //            setting.Mobile = a[6];
                                //            setting.Tel = a[7];
                                //            setting.Email = a[8];
                                //            setting.Address = a[9];
                                //            //-----------tanzimate sms
                                //            setting.GroupSms = "true";
                                //            setting.WelcomeSms = "true";
                                //            setting.AcceptSms = "true";
                                //            setting.ReadySms = "true";
                                //            setting.DeliverySms = "true";
                                //            setting.BirthDaySms = "true";
                                //            setting.InviteClubeSms = "true";
                                //            context.Setting.Add(setting);
                                //            //-----------------
                                //        }
                                //        context.SaveChanges();
                                //        MessageBox.Show("شما قبلا پرداخت کرده اید،نسخه کامل در دسترس شماست", " ثبت نام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //        strlblVersion.Text = "نسخه کامل";
                                //    }

                                //    var reg = context.Reg.FirstOrDefault();
                                //    reg.Serial1 = IDGenerator.GetOpenLock(HDDSerialL.SerialNumber());
                                //    context.SaveChanges();
                                //    //this.Close();
                                //    //return;
                                //    //MessageBox.Show("sabte nam shode,pardakht karde");
                                //}
                                toolCreateServiceToolStripMenuItem.Enabled = true;
                                toolToolsToolStripMenuItem.Enabled = true;
                                toolSearchToolStripMenuItem.Enabled = true;
                                toolSmsToolStripMenuItem.Enabled = true;
                                toolReports.Enabled = true;
                                toolBackupRestore.Enabled = true;
                                toolManageToolStripMenuItem1.Visible = true;
                                toolManagePriceToolStripMenuItem.Visible = true;
                                tooSettingApplication.Visible = true;
                                toolManageToolStripMenuItem.Enabled = true;
                                //this.Close();
                            }
                            else
                            {
                                First_Enter();
                                FormFirst frmFirst = new FormFirst();
                                frmFirst.MdiParent = this;
                                frmFirst.Visible = true;
                                splitContainer1.Panel1.Controls.Add(frmFirst);
                                frmFirst.BringToFront();
                                frmFirst.Show();
                                toolCreateServiceToolStripMenuItem.Enabled = false;
                                toolToolsToolStripMenuItem.Enabled = false;
                                toolSearchToolStripMenuItem.Enabled = false;
                                toolSmsToolStripMenuItem.Enabled = false;
                                toolReports.Enabled = false;
                                toolBackupRestore.Enabled = false;
                                toolManageToolStripMenuItem1.Visible = false;
                                toolManagePriceToolStripMenuItem.Visible = false;
                                tooSettingApplication.Visible = true;
                                toolManageToolStripMenuItem.Enabled = false;
                                //MessageBox.Show("sabtenam nakarde");
                            }
                        }
                    }

                    catch (Exception)
                    {
                        toolCreateServiceToolStripMenuItem.Enabled = false;
                        toolToolsToolStripMenuItem.Enabled = false;
                        toolSearchToolStripMenuItem.Enabled = false;
                        toolSmsToolStripMenuItem.Enabled = false;
                        toolReports.Enabled = false;
                        toolBackupRestore.Enabled = false;
                        toolManageToolStripMenuItem1.Visible = false;
                        toolManagePriceToolStripMenuItem.Visible = false;
                        tooSettingApplication.Visible = true;
                        toolManageToolStripMenuItem.Enabled = false;
                        //MessageBox.Show( ex.Message);
                        MessageBox.Show("1 \n" + "برای راه انذازی اولیه به اینترنت نیاز دارید", "ارتباط", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        public void Run_Program() // contorol barname dar shoroo (baraye joloogiri az copy kardane barname)
        {
            try
            {
                //selectDate.Today_Click(null, null);
                string stPath = Application.StartupPath;
                StimulsoftEntities context = new StimulsoftEntities();
                if (context.Reg.Count() > 0)
                {
                    var check = context.Reg.Where(c => c.State != "" || c.State != null).FirstOrDefault();
                    var checkOpen = context.WhiteSms.FirstOrDefault();

                    if (calCount(check.CountOpen.ToString()) != checkOpen.D11)
                    {
                        string reg = IDGenerator.GetOpenLock(HDDSerialL.SerialNumber());
                        if (reg == check.Serial1)
                            goto Act;
                        MessageBox.Show("اختلال در نرم افزار.نرم افزار را فعال کنید", "نرم افزار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        toolCreateServiceToolStripMenuItem.Enabled = false;
                        toolToolsToolStripMenuItem.Enabled = false;
                        toolSearchToolStripMenuItem.Enabled = false;
                        toolSmsToolStripMenuItem.Enabled = false;
                        toolReports.Enabled = false;
                        toolAnbar.Enabled = false;
                        toolBackupRestore.Enabled = false;
                        toolManageToolStripMenuItem1.Visible = false;
                        toolManagePriceToolStripMenuItem.Visible = false;
                        tooSettingApplication.Visible = true;
                        strlblVersion.Text = "برنامه را فعال کنید";
                        if (File.Exists(stPath + "\\RptUsers.mrt") == false)
                            System.IO.File.Create(stPath + "\\RptUsers.mrt");
                        return;
                        //Application.Exit();

                    }

                    if (File.Exists(stPath + "\\RptUsers.mrt"))
                    {
                        string reg = IDGenerator.GetOpenLock(HDDSerialL.SerialNumber());
                        if (reg == check.Serial1)
                            goto Act;
                        MessageBox.Show("اختلال در نرم افزار.نرم افزار را فعال کنید", "نرم افزار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        toolCreateServiceToolStripMenuItem.Enabled = false;
                        toolToolsToolStripMenuItem.Enabled = false;
                        toolSearchToolStripMenuItem.Enabled = false;
                        toolSmsToolStripMenuItem.Enabled = false;
                        toolReports.Enabled = false;
                        toolAnbar.Enabled = false;
                        toolBackupRestore.Enabled = false;
                        toolManageToolStripMenuItem1.Visible = false;
                        toolManagePriceToolStripMenuItem.Visible = false;
                        tooSettingApplication.Visible = true;
                        strlblVersion.Text = "برنامه را فعال کنید";
                        return;
                    }
                    Act: var white = context.WhiteSms.FirstOrDefault();
                    if (context.Reg.ToList().Count == 0 || context.Reg.ToList() == null)
                    {
                        First_Enter();
                        FormFirst frmFirst = new FormFirst();
                        frmFirst.MdiParent = this;
                        frmFirst.Visible = true;
                        splitContainer1.Panel1.Controls.Add(frmFirst);
                        frmFirst.BringToFront();
                        frmFirst.ShowDialog();
                        return;
                    }
                    if (check.State == HDDSerialL.SerialNumber())
                    {
                        string reg = IDGenerator.GetOpenLock(HDDSerialL.SerialNumber());
                        reg = reg + "8a1e98m";
                        string code = check.Serial1 + white.R11;
                        if (code == reg)
                        {
                            Active();

                        }
                        else
                        {
                            if (check.CountOpen >= 100)
                            {
                                End_Lablator();
                            }
                            else
                            {
                                Endnot_Lablator();
                                check.CountOpen++;
                                int open = int.Parse(reversCalCount(checkOpen.D11));
                                open++;
                                checkOpen.D11 = calCount(open.ToString());
                                frmManage = stripLblLogin.Text;
                                context.SaveChanges();

                            }
                        }
                    }
                    else
                    {
                        Active_NotEcoal();
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //Application.Exit();
            }
        }
        public void Design_Notidication()
        {
            picSmsNoti.Location = new System.Drawing.Point(splitContainer1.Width - 40, 3);
            lblCountSmsNoti.Location = new System.Drawing.Point(picSmsNoti.Location.X - lblCountSmsNoti.Width, 4);
            picbirthDayNoti.Location = new System.Drawing.Point(lblCountSmsNoti.Location.X - lblCountSmsNoti.Width - 30, 3);
            lblContBirthDayNoti.Location = new System.Drawing.Point(picbirthDayNoti.Location.X - 20, 4);
        }
        private void FormMain1_Load(object sender, EventArgs e)
        {
            //selectDate.Today_Click(null, null);
            
            version();
            First_Check_Internet(); // check kardan ba site
            Run_Program();
            //-----
            Detect_BirthDay();
            timer_Sms();
            timSms.Start();
            //-----
            Design_Notidication();
        }

        private void toolReportProdoct_Click(object sender, EventArgs e)
        {
            FormReports frmReports = new FormReports();
            frmReports.MdiParent = this;
            //**********
            //frmReports.label3.Text = "کل سفارشات:";
            //frmReports.label4.Text = "کل پرداختی:";
            frmReports.PanelDate.Visible = false;
            frmReports.PanelUser.Visible = false;
            frmReports.panelProdoct.Visible = true;
            frmReports.comCategory.Focus();
            //frmReports.panelProdoct.Location = frmReports.PanelDate.Location;
            //**********
            frmReports.Visible = true;
            splitContainer1.Panel1.Controls.Add(frmReports);
            frmReports.BringToFront();
            frmReports.Show();
        }

        private void toolAbuot_Click(object sender, EventArgs e) // form about
        {
            FormAbout frmAbout = new FormAbout();
            frmAbout.MdiParent = this;
            frmAbout.Visible = true;
            splitContainer1.Panel1.Controls.Add(frmAbout);
            frmAbout.BringToFront();
            frmAbout.Show();
        }

        private void timSms_Tick(object sender, EventArgs e) // timer timSms 
        {
            timer_Sms();
        }
        FormNotification frmNoti = new FormNotification();
        private void picSmsNoti_Click(object sender, EventArgs e) // smshaye daryafti ra neshan midahad
        {
            if (lblCountSmsNoti.Text == "0")
                return;
            if (lblCountSmsNoti.Text == "-1")
                MessageBox.Show("رمز دیجیتال پنل پیامک را ثبت کنید", "پنل پیامک", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //if (frmNoti.Visible==false || frmNoti.Visible==true)
            //{
            int x = Sms_fill();
            if (x == 0)
            {
                frmNoti.MdiParent = this;
                splitContainer1.Panel1.Controls.Add(frmNoti);
                frmNoti.BringToFront();
                frmNoti.Height = splitContainer1.Panel1.Height;
                frmNoti.Location = new Point(splitContainer1.Panel1.Right - frmNoti.Width, splitContainer1.Panel1.Bottom - frmNoti.Height);
                frmNoti.Visible = true;
                frmNoti.show = 1;
            }
            else
                frmNoti.Visible = false;
            //-----

            //}
        }
        public int Sms_fill() // dgShow dakhele form notification ra ba SMS khande nashode por mikonad
        {
            // return 0= dorost
            // return 1= eshtebah
            try
            {
                try
                {
                    Ping ping = new Ping();
                    PingReply pingStatus = ping.Send("papiloo.ir");
                    StimulsoftEntities context = new StimulsoftEntities();
                    if (pingStatus.Status == IPStatus.Success)
                    {
                        var sign = context.Setting.FirstOrDefault();
                        if (sign != null)
                        {
                            PARSGREEN.API.SMS.Message.MsgService message = new PARSGREEN.API.SMS.Message.MsgService();
                            DataSet ds = message.GetMessage(sign.Signature, 1, false);
                            if (ds == null)
                                return -1;
                            DataTable tableMessage = ds.Tables[0];
                            frmNoti.dgShow.DataSource = tableMessage;
                            frmNoti.dgShow.Columns[0].Visible = false;
                            frmNoti.dgShow.Columns[1].HeaderText = "متن پیامک";
                            frmNoti.dgShow.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                            frmNoti.dgShow.Columns[1].Width = 160;
                            frmNoti.dgShow.Columns[2].Visible = false;
                            frmNoti.dgShow.Columns[3].Visible = false;
                            frmNoti.dgShow.Columns[4].HeaderText = "فرستنده";
                            frmNoti.dgShow.Columns[4].DisplayIndex = 0;

                            frmNoti.dgShow.Columns[5].Visible = false;
                            frmNoti.dgShow.Columns[6].Visible = false;
                            frmNoti.dgShow.Columns[7].Visible = false;
                            frmNoti.dgShow.Columns[8].Visible = false;
                            frmNoti.dgShow.Columns[9].Visible = false;
                            frmNoti.dgShow.Columns[10].Visible = false;
                            frmNoti.dgShow.Columns[11].Visible = false;
                            frmNoti.dgShow.Columns[12].Visible = false;
                            frmNoti.dgShow.Columns[13].Visible = false;
                            return 0;
                        }
                        else
                        {
                            frmNoti.Visible = false;
                            MessageBox.Show("رمز دیجیتال پنل پیامک را ثبت کنید", "پنل پیامک", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return 1;
                        }
                    }

                }
                catch (Exception)
                {
                    frmNoti.Visible = false;
                    MessageBox.Show("به اینترنت متصل نیستید", "اینترنت", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return 1;
                }

            }
            catch (Exception ex)
            {
                frmNoti.Visible = false;
                MessageBox.Show(ex.Message);

                return 1;
            }
            return 1;
        }

        private void picbirthDayNoti_Click(object sender, EventArgs e)
        {
            //if (frmNoti.Visible == false || frmNoti.Visible==true)
            //{

            //frmNoti.ShowDialog();

            frmNoti.Height = splitContainer1.Panel1.Height;
            frmNoti.Location = new Point(splitContainer1.Panel1.Right - frmNoti.Width, splitContainer1.Panel1.Bottom - frmNoti.Height);
            BirthDay_Fill();
            frmNoti.MdiParent = this;
            splitContainer1.Panel1.Controls.Add(frmNoti);
            frmNoti.BringToFront();
            frmNoti.Visible = true;
            frmNoti.show = 2;



            //-----

            //}
        }
        public void BirthDay_Fill() // porkardane dgShow too form Notification
        {
            try
            {
                using (var context = new StimulsoftEntities())
                {

                    string today = Practical.Today_Date().Replace("/", "").Substring(4, 4);
                    var tavalod = context.User.Where(c => c.BirthDayDate.ToString().Substring(4, 4) == today).ToList();
                    //PopupNotifier noti = new PopupNotifier();
                    if (tavalod.Count() > 0)
                    {
                        frmNoti.dgShow.DataSource = tavalod;
                        frmNoti.dgShow.Columns[0].HeaderText = "اشتراک";
                        frmNoti.dgShow.Columns[0].DisplayIndex = 2;
                        frmNoti.dgShow.Columns[0].Width = 50;
                        frmNoti.dgShow.Columns[1].HeaderText = "نام";
                        frmNoti.dgShow.Columns[1].DisplayIndex = 1;
                        frmNoti.dgShow.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        frmNoti.dgShow.Columns[1].Width = 110;
                        frmNoti.dgShow.Columns[2].Visible = false;
                        frmNoti.dgShow.Columns[3].HeaderText = "شماره تماس";
                        frmNoti.dgShow.Columns[3].DisplayIndex = 0;
                        frmNoti.dgShow.Columns[4].Visible = false;
                        frmNoti.dgShow.Columns[5].Visible = false;
                        frmNoti.dgShow.Columns[6].Visible = false;
                        frmNoti.dgShow.Columns[7].Visible = false;
                        frmNoti.dgShow.Columns[8].Visible = false;


                        //noti.TitleText = "تولد";
                        //noti.ContentText = "امروز تولد " + count.ToString() + " نفر از مشتری ها است";
                        //noti.Popup();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "تولد نوتیفیکیشن");
            }
        }

        private void splitContainer1_Panel1_Click(object sender, EventArgs e)
        {
            frmNoti.Visible = false;
        }

        private void splitContainer1_Panel2_Click(object sender, EventArgs e)
        {
            frmNoti.Visible = false;
        }

        private void toolAnbar_Click(object sender, EventArgs e)
        {
            FormAnbar frmAnbar = new FormAnbar();
            frmAnbar.ShowDialog();

        }

        private void toolTurn_Click(object sender, EventArgs e)
        {

        }

        private void toolWorks_Click(object sender, EventArgs e)
        {
            FormWorks frmWorks = new FormWorks();
            frmWorks.Show();
        }
    }
}
