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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Service
{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();
        }
        int key = 0;

        public void Add_category()
        {
            try
            {
                using (var context = new kitchenEntities())
                {
                    Category k = new Category();
                    k.Name = txtAddKindService.Text;
                    context.Category.Add(k);
                    context.SaveChanges();
                    //------
                    var kindServ = context.Category.ToList();
                    comServiceKind.DataSource = kindServ;
                    comServiceKind.DisplayMember = "Name";

                    txtAddKindService.Visible = false;
                }
            }
            catch (Exception)
            { 
            }

        }
        private void Add_Prodoct()
        {
            try
            {
                using (var context = new kitchenEntities())
                {
                    Prodoct kindkala = new Prodoct();
                    kindkala.Name = txtAddKindkala.Text;
                    kindkala.NameService = comServiceKind.Text;
                    if(chxProdoctvalueAdded.Checked)
                    {
                        kindkala.ValueAdded = "0";
                    }
                    else
                    {
                        kindkala.ValueAdded = "1";
                    }
                    context.Prodoct.Add(kindkala);
                    context.SaveChanges();

                    //------
                    var kindKala = context.Prodoct.Where(c => c.NameService == comServiceKind.Text).ToList();
                    comKindKala.DataSource = kindKala;
                    comKindKala.DisplayMember = "Name";


                    txtAddKindkala.Visible = false;
                    chxProdoctvalueAdded.Visible = false;
                }
            }
            catch (Exception)
            {

                
            }

        }
        private void Add_Kind_Service()
        {
            try
            {
                using (var context = new kitchenEntities())
                {
                    NameService kkk = new NameService();
                    kkk.Name = txtAddNameService.Text;
                    context.NameService.Add(kkk);
                    context.SaveChanges();

                    //------
                    var nameServ = context.NameService.ToList();
                    comServiceName.DataSource = nameServ;
                    comServiceName.DisplayMember = "Name";

                    txtAddNameService.Visible = false;
                }
            }
            catch (Exception)
            {

                
            }
        }
        private void PrinterList(ComboBox combobox)
        {
            // POPULATE THE COMBO BOX.
            foreach (string sPrinters in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
               combobox.Items.Add(sPrinters);
            }
        }
        private void Save_Combobox_Print()
        {
            using (var context = new kitchenEntities())
            {
                
                if (context.Device.Count() > 0)
                {
                    var pri = context.Device.FirstOrDefault();

                    if(pri !=null)
                    {
                        pri.Printer1 = comPrinter1.Text;
                        pri.Printer2 = comPrinter2.Text;
                        pri.Printer3 = comPrinter3.Text;
                        context.SaveChanges();
                    }

                }
                else
                {
                    Device dev = new Device();
                    dev.Printer1 = comPrinter1.Text;
                    dev.Printer2 = comPrinter2.Text;
                    dev.Printer3 = comPrinter3.Text;
                    context.Device.Add(dev);
                    context.SaveChanges();
                }
            }
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
        private void Enter_Number(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {

            //------------------
            //******************
            if (txtName.Text == "")
            {
                txtName.BackColor = Color.LightPink;
                txtName.Focus();
                MessageBox.Show("مقدار نام تجاری و نام مدیر و شماره موبایل را باید وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("مقدار نام تجاری و نام مدیر و شماره موبایل را باید حتما وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }
            else
            {
                txtManageName.BackColor = Color.White;
            }
            //--------
            if (txtMobile.Text == "" || txtMobile.TextLength != 11)
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
            //--baraye inke chek konad mobaile vared shode ba 09 shoroo mishavad ya na
            bool checkMobile = txtMobile.Text.StartsWith("09");
            if (checkMobile == false)
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
            try
            {
                kitchenEntities context = new kitchenEntities();
                var selectReg = context.Reg.FirstOrDefault();
                string shenase = "";
                if (selectReg != null)
                    shenase = selectReg.IdPaye;
                string strReq2;
                string strData2;
                Stream dataStream2;
                StreamReader reader2;
                WebRequest request2;
                WebResponse response2;
                strReq2 = "http://www.papiloo.ir/Papiloo/Register/Select_Pay.php?Serial=" + shenase;
                request2 = WebRequest.Create(strReq2);
                response2 = request2.GetResponse();
                dataStream2 = response2.GetResponseStream();
                reader2 = new StreamReader(dataStream2);
                strData2 = reader2.ReadToEnd();
                //MessageBox.Show(strData2);
                reader2.Close();
                response2.Close();
                string[] a = strData2.Split('*');
                var paye = context.Reg.FirstOrDefault();
                if (a[0] == "1")
                {

                    //------- baraye update kardane filde transe site
                    string strReq;
                    string strData;
                    Stream dataStream;
                    StreamReader reader;
                    WebRequest request;
                    WebResponse response;
                    strReq = "http://www.papiloo.ir/Papiloo/Register/Update_Pay.php?Serial=" + IDGenerator.GetCPUId();
                    request = WebRequest.Create(strReq);
                    response = request.GetResponse();
                    dataStream = response.GetResponseStream();
                    reader = new StreamReader(dataStream);
                    strData = reader.ReadToEnd();
                    //MessageBox.Show(strData);
                    reader.Close();
                    response.Close();
                    //MessageBox.Show(strData);
                    //-------
                    selectReg.Serial1 = IDGenerator.GetOpenLock(IDGenerator.GetCPUId());
                    context.SaveChanges();
                    MessageBox.Show("نرم افزار کامل فعال شد.سپاس از انتخاب شما", "فعال سازی", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtRegister.Text = "نرم افزار فعال است";
                    txtSerial.Enabled = false;
                    txtRegister.Enabled = false;
                    btnCreate.Enabled = false;
                    btnSendRegisterCode.Enabled = false;
                    btnRegisterInternet.Enabled = false;
                    Application.Restart();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("به اینترنت متصل نیستید", "ارتباط", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

        }

        //------

        //------
        private void fill_ComboPrinter() // por kardane combobox printer
        {
            PrinterList(comPrinter1);
            PrinterList(comPrinter2);
            PrinterList(comPrinter3);

        }
        private void fill_ComboFood() // por kardane combobox sefareshat
        {
            //-----por kardane combobox sefareshat
            string firstFieldCategory = "";
            kitchenEntities context = new kitchenEntities();
            if (context.Category.Count() > 0)
            {
                comServiceKind.DataSource = context.Category.ToList();
                comServiceKind.DisplayMember = "Name";
                firstFieldCategory = context.Category.FirstOrDefault().Name;
                //comServiceKind.SelectedIndex = 0;
            }
            //---------
            var kindKalacom = context.Prodoct.Where(c => c.NameService == firstFieldCategory).ToList();
            comKindKala.DataSource = kindKalacom;
            comKindKala.DisplayMember = "Name";
            //var food = context.KindKala.Where(c=>c.NameService !=null).ToList();
            //if (food.Count > 0)
            //{
            //    comKindKala.DataSource = food;
            //    comKindKala.DisplayMember = "Name";
            //}
            //----------

            var nameServcom = context.NameService.ToList();
            if (nameServcom.Count > 0)
            {
                comServiceName.DataSource = nameServcom;
                comServiceName.DisplayMember = "Name";
            }
            //----------
            var welcome = context.WhiteSms.Where(c => c.W1 != null || c.W1 != "").FirstOrDefault();
            txtWelcome.Text = welcome.W1;
            txtWarningCreadit.Text = welcome.R10;
            //-----
            var accept = context.WhiteSms.Where(c => c.S1 != null || c.S1 != "").FirstOrDefault();
            txtAccept.Text = accept.S1;
            //-----
            var ready = context.WhiteSms.Where(c => c.R1 != null || c.R1 != "").FirstOrDefault();
            txtReady.Text = ready.R1;
            //-----
            var delivery = context.WhiteSms.Where(c => c.D1 != null || c.D1 != "").FirstOrDefault();
            txtDelivery.Text = delivery.D1;
        }
        private void fill_Setting() // por kardane checkBox Sms va chek kardane fl boodan Application
        {
            kitchenEntities context = new kitchenEntities();
            if (context.Device.Count() > 0)
            {
                var fillPrint = context.Device.FirstOrDefault();
                if (fillPrint != null)
                {
                    if (string.IsNullOrEmpty(fillPrint.Printer1))
                    {
                        chxPrinter1.Checked = false;
                        comPrinter1.Enabled = false;
                    }
                    else
                    {
                        comPrinter1.Text = fillPrint.Printer1;
                        chxPrinter1.Checked = true;
                    }
                    if(string.IsNullOrEmpty(fillPrint.Printer2))
                    {
                        chxPrinter2.Checked = false;
                        comPrinter2.Enabled = false;
                    }
                    else
                    {
                        comPrinter2.Text = fillPrint.Printer2;
                        chxPrinter2.Checked = true;
                    }
                    if(string.IsNullOrEmpty(fillPrint.Printer3))
                    {
                        chxPrinter3.Checked = false;
                        comPrinter3.Enabled = false;
                    }
                    else
                    {
                        comPrinter3.Text = fillPrint.Printer3;
                        chxPrinter3.Checked = true;
                    }
                }
            }
            //--------
            var ser = context.Reg.FirstOrDefault();
            if (ser == null)
                return;
            //----------
            //var register = context.Reg.FirstOrDefault();
            //if (register.Serial1 == IDGenerator.GetOpenLock(IDGenerator.GetCPUId()))
            //{
            //    txtRegister.Text = "نرم افزار فعال است";
            //    txtSerial.Enabled = false;
            //    txtRegister.Enabled = false;
            //    btnCreate.Enabled = false;
            //    btnSendRegisterCode.Enabled = false;
            //    btnRegisterInternet.Enabled = false;
            //}
            //-------
            //-------
            var setting = context.Setting.FirstOrDefault();
            if (setting != null)
            {
                //----
                if (setting.GroupSms == "true")
                    chxGroupSms.Checked = true;
                if (setting.GroupSms == "false")
                    chxGroupSms.Checked = false;
                //----
                if (setting.WelcomeSms == "true")
                    chxWelcomeSms.Checked = true;
                if (setting.WelcomeSms == "false")
                    chxWelcomeSms.Checked = false;
                //----
                if (setting.AcceptSms == "true")
                    chxAcceptSms.Checked = true;
                if (setting.AcceptSms == "false")
                    chxAcceptSms.Checked = false;
                //----
                if (setting.ReadySms == "true")
                    chxReadySms.Checked = true;
                if (setting.ReadySms == "false")
                    chxReadySms.Checked = false;
                //----
                if (setting.DeliverySms == "true")
                    chxDeliverySms.Checked = true;
                if (setting.DeliverySms == "false")
                    chxDeliverySms.Checked = false;
                //----
                if (setting.BirthDaySms == "true")
                    chxBirthDaySms.Checked = true;
                if (setting.BirthDaySms == "false")
                    chxBirthDaySms.Checked = false;
            }
            else
            {
                Setting set = new Setting();
                set.CommercialName = "";

                set.GroupSms = "true";
                chxGroupSms.Checked = true;

                set.WelcomeSms = "true";
                chxWelcomeSms.Checked = true;

                set.AcceptSms = "true";
                chxAcceptSms.Checked = true;

                set.ReadySms = "true";
                chxReadySms.Checked = true;

                set.DeliverySms = "true";
                chxDeliverySms.Checked = true;

                set.BirthDaySms = "true";
                chxBirthDaySms.Checked = true;

                context.Setting.Add(set);
                context.SaveChanges();
            }

        }
        private void FormSettings_Load(object sender, EventArgs e)
        {
            try
            {
                Thread t1 = new Thread(fill_ComboPrinter);
                Thread t2 = new Thread(fill_ComboFood);
                Thread t3 = new Thread(fill_Setting);
                t1.Start();
                t2.Start();
                t3.Start();
                //PrinterList(comPrinter1);
                //PrinterList(comPrinter2);
                //PrinterList(comPrinter3);
                using (var context = new kitchenEntities())
                {
                    //--------
                    var ser = context.Reg.FirstOrDefault();
                    if (ser == null)
                        return;
                    txtSerial.Text = HDDSerialL.SerialNumber() + "/" + ser.CountOpen + ser.Date;
                    txtRegister.Text = ser.IdPaye;
                    txtRegister.ForeColor = Color.Red;
                    //----------
                    if (ser.Serial1 == IDGenerator.GetOpenLock(HDDSerialL.SerialNumber()))
                    {
                        txtRegister.Text = "نرم افزار فعال است";
                        txtSerial.Enabled = false;
                        txtRegister.Enabled = false;
                        btnCreate.Enabled = false;
                        btnSendRegisterCode.Enabled = false;
                        btnRegisterInternet.Enabled = false;
                    }
                    //--------por kardane etelaate modir
                    var setting = context.Setting.FirstOrDefault();
                    if (string.IsNullOrEmpty(setting.CommercialName))
                        txtName.Text = "";

                    if (setting != null)
                    {
                        txtName.Text = setting.CommercialName;

                        txtManageName.Text = setting.ManageName;
                        txtMobile.Text = setting.Mobile;
                        txtTel.Text = setting.Tel;
                        txtEmail.Text = setting.Email;
                        txtAdress.Text = setting.Address;
                        //---------por kardane meghdare etelaate Sms
                        txtSignature.Text = setting.Signature;
                        txtNumberSms.Text = setting.NumberSms;
                        txtValueAdded.Text = setting.ValueAddedPercent.ToString();
                        //----
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnMoney_Click(object sender, EventArgs e)
        {
            try
            {

                txtMoney.Text = "";
                PARSGREEN.API.SMS.Profile.ProfileService p = new PARSGREEN.API.SMS.Profile.ProfileService();
                double creidet = p.GetCredit(txtSignature.Text);
                if (creidet == -64)
                {
                    MessageBox.Show("امضا دیجیتال اشتباه است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                txtMoney.Text = creidet.ToString();
                //long cadir2 = Int64.Parse(txtMoney.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtName.Text=="")
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
            if (txtMobile.Text == "" || txtMobile.TextLength!= 11)
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
            try
            {
                using (var context = new kitchenEntities())
                {
                    var save = context.Setting.FirstOrDefault();
                    //var welcom = context.WhiteSms.Where(c => c.W1 != "" || c.W1 != null).FirstOrDefault();
                    //var service = context.WhiteSms.Where(c => c.S1 != "" || c.S1 != null).FirstOrDefault();
                    //var Ready = context.WhiteSms.Where(c => c.R1 != "" || c.R1 != null).FirstOrDefault();
                    //var Delivery = context.WhiteSms.Where(c => c.D1 != "" || c.D1 != null).FirstOrDefault();
                    //---------------bekhatere inke table faghat 1 record dashte bashad if gozashtam
                    if (save !=null)
                    {
                        //------------tarif etelaate foroshgah va modir
                        save.CommercialName = txtName.Text;
                        //welcom.W4 = txtName.Text;
                        //service.S11 = txtName.Text;
                        //Ready.R9 = txtName.Text;
                        save.ManageName = txtManageName.Text;
                        //Delivery.D9 = txtName.Text;
                        save.Mobile = txtMobile.Text;
                        save.Tel = txtTel.Text;
                        save.Email = txtEmail.Text;
                        save.Address = txtAdress.Text;
                        context.SaveChanges();
                        MessageBox.Show(" اطلاعات ویرایش شد", "وضعیت", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
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
                        MessageBox.Show(" اطلاعات ثبت شد", "وضعیت", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnSaveSing_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new kitchenEntities())
                {
                    var save = context.Setting.FirstOrDefault();
                    //---------------bekhatere inke table faghat 1 record dashte bashad if gozashtam
                    if (save != null)
                    {
                        save.Signature = txtSignature.Text;
                        context.SaveChanges();
                        MessageBox.Show(" امضا ویرایش شد", "وضعیت", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        Setting setting = new Setting();
                        setting.Signature = txtSignature.Text;
                        context.Setting.Add(setting);
                        context.SaveChanges();
                        MessageBox.Show(" امضا ثبت شد", "وضعیت", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnSaveNumber_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new kitchenEntities())
                {
                    var save = context.Setting.FirstOrDefault();
                    //---------------bekhatere inke table faghat 1 record dashte bashad if gozashtam
                    if (save != null)
                    {
                        save.NumberSms = txtNumberSms.Text;
                        context.SaveChanges();
                        MessageBox.Show(" شماره ویرایش شد", "وضعیت", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        Setting setting = new Setting();
                        setting.NumberSms = txtNumberSms.Text;
                        context.Setting.Add(setting);
                        context.SaveChanges();
                        MessageBox.Show(" شماره ثبت شد", "وضعیت", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void chxGroupSms_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new kitchenEntities())
                {
                    var setting = context.Setting.FirstOrDefault();
                    if (setting.GroupSms == "true")
                    {
                        setting.GroupSms = "false";
                        context.SaveChanges();

                        return;
                    }
                    else
                    {
                        setting.GroupSms = "true";
                        context.SaveChanges();

                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void chxWelcomeSms_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new kitchenEntities())
                {
                    var setting = context.Setting.FirstOrDefault();
                    if (setting.WelcomeSms == "true")
                    {
                        setting.WelcomeSms = "false";
                        context.SaveChanges();

                        return;
                    }
                    else
                    {
                        setting.WelcomeSms = "true";
                        context.SaveChanges();

                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void chxAcceptSms_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new kitchenEntities())
                {
                    var setting = context.Setting.FirstOrDefault();
                    if (setting.AcceptSms == "true")
                    {
                        setting.AcceptSms = "false";
                        context.SaveChanges();

                        return;
                    }
                    else
                    {
                        setting.AcceptSms = "true";
                        context.SaveChanges();

                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void chxReadySms_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new kitchenEntities())
                {
                    var setting = context.Setting.FirstOrDefault();
                    if (setting.ReadySms == "true")
                    {
                        setting.ReadySms = "false";
                        context.SaveChanges();

                        return;
                    }
                    else
                    {
                        setting.ReadySms = "true";
                        context.SaveChanges();

                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void chxDeliverySms_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new kitchenEntities())
                {
                    var setting = context.Setting.FirstOrDefault();
                    if (setting.DeliverySms == "true")
                    {
                        setting.DeliverySms = "false";
                        context.SaveChanges();

                        return;
                    }
                    else
                    {
                        setting.DeliverySms = "true";
                        context.SaveChanges();

                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void chxBirthDaySms_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new kitchenEntities())
                {
                    var setting = context.Setting.FirstOrDefault();
                    if (setting.BirthDaySms == "true")
                    {
                        setting.BirthDaySms = "false";
                        context.SaveChanges();

                        return;
                    }
                    else
                    {
                        setting.BirthDaySms = "true";
                        context.SaveChanges();

                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void chxInviteCluoeSms_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new kitchenEntities())
                {
                    var setting = context.Setting.FirstOrDefault();
                    if (setting.InviteClubeSms == "true")
                    {
                        setting.InviteClubeSms = "false";
                        context.SaveChanges();
                        return;
                    }
                    else
                    {
                        setting.InviteClubeSms = "true";
                        context.SaveChanges();

                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnSendRegisterCode_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                txtName.BackColor = Color.LightPink;
                txtName.Focus();
                MessageBox.Show("مقدار نام تجاری و نام مدیر و شماره موبایل را باید وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("مقدار نام تجاری و نام مدیر و شماره موبایل را باید حتما وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }
            else
            {
                txtManageName.BackColor = Color.White;
            }
            //--------
            if (txtMobile.Text == "" || txtMobile.TextLength != 11)
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
            //--baraye inke chek konad mobaile vared shode ba 09 shoroo mishavad ya na
            bool checkMobile = txtMobile.Text.StartsWith("09");
            if (checkMobile == false)
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
            try
            {
                btnSendRegisterCode.Enabled = false;
                kitchenEntities context = new kitchenEntities();
                var countSmsRegister = context.WhiteSms.Where(c => c.Id == 1).FirstOrDefault();
                string count = countSmsRegister.R10;
                int reg = int.Parse(count);
                reg++;
                if (reg < 3)
                {
                    //PARSGREEN.API.SMS.Send.SendSMS send = new PARSGREEN.API.SMS.Send.SendSMS();
                    string message = "خشکشویی \n  تجاری:" + txtName.Text + "\n نام مدیر:" + txtManageName.Text + "\n شماره تماس:" + txtMobile.Text + "\n سریال: " + txtSerial.Text;

                    //int successCount = 0;
                    //int restStatus;
                    //string[] restr = null;
                    //restStatus = send.SendGroupSMS("8B0AA695-E750-4CB3-AF3E-98F9D03F06AC", "10001000300076", new string[] { "09127173428" }, message, false, string.Empty, ref successCount, ref restr);
                    //--------
                    //System.Web.HttpUtility.HtmlDecode(text);

                    string pattern = "http://login.parsgreen.com/UrlService/sendSMS.ashx?from=" + "10001000300076" + "&to=" + "09127173428" + "&text=" + message + "&signature=" + "8B0AA695-E750-4CB3-AF3E-98F9D03F06AC";

                    //MessageBox.Show(pattern);
                    System.IO.Stream st = null;
                    System.IO.StreamReader sr = null;

                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(pattern);
                    Encoding encode = System.Text.Encoding.UTF8;

                    System.Net.WebResponse resp = req.GetResponse();

                    st = resp.GetResponseStream();
                    sr = new System.IO.StreamReader(st, Encoding.UTF8);
                    string result = sr.ReadToEnd().Substring(12, 1);
                    //MessageBox.Show(sr.ReadToEnd()); //Get_Return_Message_Sms(int.Parse(result);
                    //MessageBox.Show( Get_Return_Message_Sms(int.Parse(result)));
                    sr.Close();
                    resp.Close();


                    //-------
                    if (result == "0")
                        MessageBox.Show("پیام فرستاده شد، پس از بررسی ،کد فعال سازی برای شما فرستاده میشود \n تشکر از صبر شما", "فعال سازی", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnSendRegisterCode.Enabled = false;
                }
                else
                {
                    btnSendRegisterCode.Enabled = false;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }


        private void txtMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            Enter_Number(sender, e);

        }

        private void txt11_KeyPress(object sender, KeyPressEventArgs e)
        {
            Enter_Number(sender, e);

        }

        private void txt26_KeyPress(object sender, KeyPressEventArgs e)
        {
            Enter_Number(sender, e);

        }

        private void txt28_KeyPress(object sender, KeyPressEventArgs e)
        {
            Enter_Number(sender, e);

        }

        private void txt30_KeyPress(object sender, KeyPressEventArgs e)
        {
            Enter_Number(sender, e);

        }

        private void txt32_KeyPress(object sender, KeyPressEventArgs e)
        {
            Enter_Number(sender, e);

        }

        private void txt34_KeyPress(object sender, KeyPressEventArgs e)
        {
            Enter_Number(sender, e);

        }

        private void txt36_KeyPress(object sender, KeyPressEventArgs e)
        {
            Enter_Number(sender, e);

        }

        private void txt38_KeyPress(object sender, KeyPressEventArgs e)
        {
            Enter_Number(sender, e);

        }

        private void txt2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Enter_Number(sender, e);

        }

        private void txt4_KeyPress(object sender, KeyPressEventArgs e)
        {
            Enter_Number(sender, e);

        }

        private void txt6_KeyPress(object sender, KeyPressEventArgs e)
        {
            Enter_Number(sender, e);

        }

        private void txt17_KeyPress(object sender, KeyPressEventArgs e)
        {
            Enter_Number(sender, e);

        }

        private void txt19_KeyPress(object sender, KeyPressEventArgs e)
        {
            Enter_Number(sender, e);

        }

        private void txt21_KeyPress(object sender, KeyPressEventArgs e)
        {
            Enter_Number(sender, e);

        }

        private void BtnRegisterInternet_Click(object sender, EventArgs e)
        {
            try
            {
                Ping ping = new Ping();
                PingReply pingStatus = ping.Send("papiloo.ir");
                if (pingStatus.Status == IPStatus.Success)
                {
                    System.Diagnostics.Process.Start("http://www.papiloo.ir/Laundry/index.php");
                }
                else
                {
                    MessageBox.Show("اینترنت قطع است", "ارتباط", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("به اینترنت متصل نیستید", "ارتباط", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //-------------------


        }

        private void txtWarningCreadit_Leave(object sender, EventArgs e)
        {
            try
            {
                using (var context = new kitchenEntities())
                {
                    var select = context.WhiteSms.FirstOrDefault();
                    select.R10 = txtWarningCreadit.Text;
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("مشکل در هشدار اعتبار");
            }
        }

        private void txtWarningCreadit_KeyPress(object sender, KeyPressEventArgs e)
        {
            Enter_Number(sender, e);

        }


        public void Save_WhiteSms(string text)
        {
            try
            {

                kitchenEntities context = new kitchenEntities();
                if (key == 1)
                {
                    var welcome = context.WhiteSms.Where(c => c.W1 != null || c.W1 != "").FirstOrDefault();
                    welcome.W1 = text;
                    context.SaveChanges();
                    return;
                }
                if (key == 2)
                {
                    var accept = context.WhiteSms.Where(c => c.S1 != null || c.S1 != "").FirstOrDefault();
                    accept.S1 = text;
                    context.SaveChanges();
                    return;
                }
                if (key == 3)
                {
                    var ready = context.WhiteSms.Where(c => c.R1 != null || c.R1 != "").FirstOrDefault();
                    ready.R1 = text;
                    context.SaveChanges();
                    return;
                }
                if (key == 4)
                {
                    var delivery = context.WhiteSms.Where(c => c.D1 != null || c.D1 != "").FirstOrDefault();
                    delivery.D1 = text;
                    context.SaveChanges();
                    return;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void btnSaveWelcome_Click(object sender, EventArgs e)
        {
            key = 1;
            Save_WhiteSms(txtWelcome.Text);
            
        }

        private void btnSaveAccept_Click(object sender, EventArgs e)
        {
            key = 2;
            Save_WhiteSms(txtAccept.Text);
        }

        private void btnSaveReady_Click(object sender, EventArgs e)
        {
            key = 3;
            Save_WhiteSms(txtReady.Text);
        }

        private void btnSaveDelivery_Click(object sender, EventArgs e)
        {
            key = 4;
            Save_WhiteSms(txtDelivery.Text);
        }

        private void comPrinter1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Save_Combobox_Print();
        }

        private void comPrinter2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Save_Combobox_Print();
        }

        private void comPrinter3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Save_Combobox_Print();
        }

        private void btnDelNameService_Click(object sender, EventArgs e)
        {

        }

        private void comServiceName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comKindKala_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comServiceKind_SelectedIndexChanged_2(object sender, EventArgs e)
        {

        }

        private void btnDelKindKala_Click(object sender, EventArgs e)
        {

        }

        private void btnAddKindService_Click(object sender, EventArgs e)
        {

        }

        private void btnDelKindService_Click(object sender, EventArgs e)
        {

        }

        private void btnAddKindKala_Click(object sender, EventArgs e)
        {

        }

        private void btnAddNameService_Click(object sender, EventArgs e)
        {

        }

        private void txtAddNameService_DoubleClick(object sender, EventArgs e)
        {

        }

        private void txtAddNameService_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtAddKindService_DoubleClick(object sender, EventArgs e)
        {

        }

        private void txtAddKindService_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtAddKindkala_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void btnAddKindService_Click_1(object sender, EventArgs e)
        {
            txtAddKindService.Text = "";
            txtAddKindService.Visible = true;
            txtAddKindService.Focus();
        }

        private void btnDelKindService_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (comServiceKind.Items.Count == 0)
                    return;
                using (var context = new kitchenEntities())
                {
                    
                    var del = context.Category.Where(c => c.Name == comServiceKind.Text).FirstOrDefault();
                    context.Category.Remove(del);
                    context.SaveChanges();
                    var kindServ = context.Category.ToList();
                    comServiceKind.DataSource = kindServ;
                    comServiceKind.DisplayMember = "Name";
                }
            }
            catch (Exception )
            {
            }
        }

        private void btnAddKindKala_Click_1(object sender, EventArgs e)
        {
            txtAddKindkala.Text = "";
            txtAddKindkala.Visible = true;
            chxProdoctvalueAdded.Visible = true;
            txtAddKindkala.Focus();
        }

        private void btnDelKindKala_Click_1(object sender, EventArgs e)
        {
            try
            {

                
                using (var context = new kitchenEntities())
                {
                    //var kindkala = context.KindKala.ToList();
                    var del = context.Prodoct.Where(c => c.Name == comKindKala.Text).FirstOrDefault();

                    if (del != null)
                    {
                        context.Prodoct.Remove(del);
                        context.SaveChanges();
                        var food = context.Prodoct.Where(c => c.NameService == comServiceKind.Text).ToList();
                        comKindKala.DataSource = food;
                        comKindKala.DisplayMember = "Name";
                    }
                    else
                        return;
                }
            }
            catch (Exception )
            {
            }
        }

        private void btnAddNameService_Click_1(object sender, EventArgs e)
        {
            txtAddNameService.Text = "";
            txtAddNameService.Visible = true;
            txtAddNameService.Focus();
        }

        private void btnDelNameService_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (comServiceName.Items.Count == 0)
                    return;
                using (var context = new kitchenEntities())
                {
                    var del = context.NameService.Where(c => c.Name == comServiceName.Text).FirstOrDefault();
                    context.NameService.Remove(del);
                    context.SaveChanges();

                    var nameService = context.NameService.ToList();
                    comServiceName.DataSource = nameService;
                    comServiceName.DisplayMember = "Name";
                }
            }
            catch (Exception )
            {

            }
        }

        private void tabPrinter_MouseClick(object sender, MouseEventArgs e)
        {
            txtAddKindService.Visible = false;
            txtAddKindkala.Visible = false;
            txtAddNameService.Visible = false;
            chxProdoctvalueAdded.Visible = false;

        }

        private void txtAddKindService_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                Add_category();
            }
        }

        private void txtAddKindkala_KeyDown_1(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Enter)
                {
                    using (var context = new kitchenEntities())
                    {
                        //KindKala kk = new KindKala();
                        //kk.Name = txtAddKindkala.Text;
                        //kk.NameService = comServiceKind.Text;

                        //context.KindKala.Add(kk);
                        //context.SaveChanges();

                        ////------
                        //var kindKala = context.KindKala.Where(c => c.NameService == comServiceKind.Text).ToList();
                        //comKindKala.DataSource = kindKala;
                        //comKindKala.DisplayMember = "Name";


                        //txtAddKindkala.Visible = false;
                        Prodoct kk = new Prodoct();
                        kk.Name = txtAddKindkala.Text;
                        kk.NameService = comServiceKind.Text;
                       kk.ValueAdded = "true";
                        context.Prodoct.Add(kk);
                        context.SaveChanges();

                        //------
                        var kindKala = context.Prodoct.Where(c => c.NameService == comServiceKind.Text).ToList();
                        comKindKala.DataSource = kindKala;
                        comKindKala.DisplayMember = "Name";


                        txtAddKindkala.Visible = false;
                    }



                
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("3:" + ex.Message);
                
            }

        }

        private void txtAddNameService_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                Add_Kind_Service();
            }
        }

        private void txtAddKindService_DoubleClick_1(object sender, EventArgs e)
        {
            Add_category();
        }

        private void txtAddNameService_DoubleClick_1(object sender, EventArgs e)
        {
            Add_Kind_Service();
        }

        private void txtAddKindkala_DoubleClick(object sender, EventArgs e)
        {
            Add_Prodoct();
        }

        private void comServiceKind_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (var context = new kitchenEntities())
                {
                    var food = context.Prodoct.Where(c => c.NameService == comServiceKind.Text).ToList();
                    comKindKala.DataSource = food;
                    comKindKala.DisplayMember = "Name";
                }
            }
            catch (Exception)
            {

                
            }
        }

        private void txtAddKindkala_KeyDown(object sender, KeyEventArgs e)
        {
                if (e.KeyData == Keys.Enter)
                {
                    Add_Prodoct();
                }
        }

        private void chxValueAdded_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                using (var context = new kitchenEntities())
                {
                    var valueAdded = context.Setting.FirstOrDefault();
                    if(valueAdded.ValueAddedPercent==0)
                    {
                        valueAdded.ValueAddedPercent = 1;
                        chxProdoctvalueAdded.Checked = false;
                    }
                    else
                    {
                        valueAdded.ValueAddedPercent = 0;
                        chxProdoctvalueAdded.Checked = true;
                    }
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {

                
            }
        }

        private void txtValueAdded_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (var context = new kitchenEntities())
                {
                    if (txtValueAdded.Text != "")
                    {
                        var selectSetting = context.Setting.FirstOrDefault();
                        selectSetting.ValueAddedPercent = int.Parse(txtValueAdded.Text);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ارزش افزوده \n"+ex.Message);
               
            }
        }

        private void txtValueAdded_KeyPress(object sender, KeyPressEventArgs e)
        {
            Enter_Number(sender, e);
        }

        private void chxProdoctvalueAdded_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                Add_Prodoct();
            }
        }

        private void chxPrinter1_CheckedChanged(object sender, EventArgs e)
        {
            if (chxPrinter1.Checked)
                comPrinter1.Enabled = true;
            else
            {
                comPrinter1.Text = "";
                Save_Combobox_Print();
                comPrinter1.Enabled = false;
            }
        }

        private void chxPrinter2_CheckedChanged(object sender, EventArgs e)
        {
            if (chxPrinter2.Checked)
                comPrinter2.Enabled = true;
            else
            {
                comPrinter2.Text = "";
                Save_Combobox_Print();
                comPrinter2.Enabled = false;
            }
        }

        private void chxPrinter3_CheckedChanged(object sender, EventArgs e)
        {
            if (chxPrinter3.Checked)
                comPrinter3.Enabled = true;
            else
            {
                comPrinter3.Text = "";
                Save_Combobox_Print();
                comPrinter3.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
