using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Service
{
    public partial class FormNewUser : Form
    {

        public FormNewUser()
        {
            InitializeComponent();

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            dateEnter.Text = Practical.Today_Date();
            //dateBirthDay.Text = Practical.Today_Date(); 
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("آقا /خانم " + txtName.Text + " به خشکشویی باران خوش آمدید\nکد اشتراک شما " + txtEshterak.Text, "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //MessageBox.Show("آقا /خانم " + txtName + " به خشکشویی باران خوش آمدید.کد اشتراک شما " + txtEshterak.Text);

            try
            {
                if (txtEshterak.Text == "")
                {
                    MessageBox.Show("شماره اشتراک خالی است", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    using (var context = new StimulsoftEntities())
                    {

                        bool isContact = context.User.Where(check => check.Eshterak == txtEshterak.Text).Any();
                        if (isContact)
                        {
                            //MessageBox.Show("کاربری بااین شماره اشتراک وجود دارد", "اشتراک", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            lblError.ForeColor = Color.Red;
                            lblError.Text = "کاربری بااین شماره اشتراک وجود دارد";
                            txtEshterak.Focus();
                        }
                        else
                        {
                            if (txtPhone.Text == "")
                                txtPhone.Text = "0";
                            User user = new User
                            {
                                Name = txtName.Text,
                                Phone = txtPhone.Text,
                                Eshterak = txtEshterak.Text,
                                //Date = int.Parse(DateEnter.Text.Replace("/", "")),
                                Email = txtEmail.Text,
                                //************
                            };
                            context.User.Add(user);
                            context.SaveChanges();
                            lblError.ForeColor = Color.Green;
                            lblError.Text = "اطلاعات با موفقیت ثیت شد";
                        }
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            //-----ersal sms
            try
            {

                // PARSGREEN.API_SendSMS.SendSMS send = new PARSGREEN.API_SendSMS.SendSMS();
                PARSGREEN.API.SMS.Send.SendSMS send = new PARSGREEN.API.SMS.Send.SendSMS();
                int successCount = 0;
                int restStatus;
                string[] restr = null;
                restStatus = send.SendGroupSMS("8B0AA695-E750-4CB3-AF3E-98F9D03F06AC", "10001000300076", new string[] { txtPhone.Text }, "آقا /خانم " + txtName.Text + " به خشکشویی باران خوش آمدید\nکد اشتراک شما " + txtEshterak.Text, false, string.Empty, ref successCount, ref restr);
                //MessageBox.Show("تعداد پیام ها: " + restStatus.ToString() + "\r" + "تحویل داده شده: " + successCount);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }








        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            if (txtPhone.TextLength > 11)
                lblError.Text = "شماره تلفن را به صورت درست وارد کنید";
            if (txtPhone.TextLength <= 11)
                lblError.Text = "";


        }

        private void txtEshterak_TextChanged(object sender, EventArgs e)
        {
            using (var context = new StimulsoftEntities())
            {

                bool isContact = context.User.Where(check => check.Eshterak == txtEshterak.Text).Any();
                if (isContact)
                {
                    //MessageBox.Show("کاربری بااین شماره اشتراک وجود دارد", "اشتراک", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lblError.ForeColor = Color.Red;
                    lblError.Text = "کاربری بااین شماره اشتراک وجود دارد";

                }
                else
                {
                    lblError.Text = "";
                }
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtEshterak_KeyPress(object sender, KeyPressEventArgs e)
        {
            Practical.Enter_Number(sender, e);
        }

        private void txtYearCreate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtPhone_TextChanged_1(object sender, EventArgs e)
        {
            lblError.Text = "";
            if (txtPhone.TextLength > 12)
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = "شماره موبایل اشتباه است";
                txtEshterak.Focus();
            }
            else
                lblError.Text = "";
        }

        private void btnSaveUser_Click(object sender, EventArgs e)
        {
            try
            {

                using (var context = new StimulsoftEntities())
                {
                    Colleague colleague = new Colleague();
                    colleague.Name = txtName.Text;
                    colleague.Phone = txtPhone.Text;
                    colleague.Tel = txtTel.Text;
                    //----
                    string selectDay= dateEnter.Text.Replace("/", "");
                    selectDay = selectDay.Replace(" ", "");
                    if(selectDay=="")
                    {
                        colleague.DateEnter = 0;
                    }
                    else
                    {
                        colleague.DateEnter = int.Parse(selectDay);
                    }
                    selectDay = dateBirthDay.Text.Replace("/", "");
                    selectDay = selectDay.Replace(" ", "");
                    if (selectDay == "")
                    {
                        colleague.DateBirthDay = 0;
                    }
                    else
                    {
                        colleague.DateBirthDay = int.Parse(selectDay);
                    }
                    if(radFemale.Enabled)
                    {
                        colleague.Sex = "زن";
                    }
                    else
                    {
                        colleague.Sex = "مرد";
                    }
                    colleague.Address = txtAddress.Text;
                    colleague.CardNumber = mtxtCardNumber.Text;
                    colleague.AccountNumber = txtAccountNumber.Text;
                    colleague.Description = txtDescription.Text;
                    colleague.Email = txtEmail.Text;
                    colleague.Eshterak = txtEshterak.Text;
                    context.Colleague.Add(colleague);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("مشکل در ثبت همکار", "همکار", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPhone_TextChanged_2(object sender, EventArgs e)
        {

            txtEshterak.Text = Practical.Build_Eshterak_Number(txtPhone.Text);
        }

        private void txtPhone_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            Practical.Enter_Number(sender, e);
        }

        private void txtTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            Practical.Enter_Number(sender, e);
        }

        private void txtCardNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            Practical.Enter_Number(sender, e);
        }

        private void txtAccountNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            Practical.Enter_Number(sender, e);
        }

        private void txtCardNumber_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
