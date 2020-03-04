using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laundry
{
    public partial class OnlinForm : Form
    {
        public OnlinForm()
        {
            InitializeComponent();
        }
        public void Refresh_dgSearch()
        {
            try
            {
                dgShow.Columns[0].Name = "Name";
                dgShow.Columns[0].DataPropertyName = "Name";
                dgShow.Columns[0].HeaderText = "نام";
                //dgSearch.Columns[0].Visible = false;
                dgShow.Columns[0].Width = 150;
                //------
                dgShow.Columns[1].Name = "Phone";
                dgShow.Columns[1].DataPropertyName = "Phone";
                dgShow.Columns[1].HeaderText = "شماره تماس";
                //-------
                dgShow.Columns[2].Name = "Date";
                dgShow.Columns[2].DataPropertyName = "Date";
                dgShow.Columns[2].HeaderText = "تاریخ ارسال";
                dgShow.Columns[2].DefaultCellStyle.Format = "0000/00/00";
                //-------
                dgShow.Columns[3].Name = "Time";
                dgShow.Columns[3].DataPropertyName = "Time";
                dgShow.Columns[3].HeaderText = "زمان ارسال";
                ///------
                var btnSend = new DataGridViewButtonColumn();

                btnSend.Text = "ارسال";
                btnSend.Name = "btnErsal";
                btnSend.HeaderText = "";
                btnSend.DataPropertyName = "Ersal";
                btnSend.Width = 75;
                btnSend.UseColumnTextForButtonValue = true;
                this.dgShow.Columns.Add(btnSend);
                //-------
                var btnDelete = new DataGridViewButtonColumn();

                btnDelete.Text = "حذف";
                btnDelete.Name = "btDelete";
                btnDelete.HeaderText = "";
                btnDelete.DataPropertyName = "Delete";
                btnDelete.Width = 75;
                btnDelete.UseColumnTextForButtonValue = true;
                this.dgShow.Columns.Add(btnDelete);
                //-------

                //btnDelete.Name = "btnDelete";
                //btnDelete.HeaderText = "حذف";
                //btnDelete.DataPropertyName = "Delete";
                //btnDelete.Width = 50;
                //dgSearch.Columns[0].HeaderText = "نام";
                //dgSearch.Columns[1].HeaderText = "شماره تماس";
                //dgSearch.Columns[2].Width = 300;
                //dgSearch.Columns[2].HeaderText = "متن پیام";
                //dgSearch.Columns[3].HeaderText = "تاریخ ارسال";
                //dgSearch.Columns[3].DefaultCellStyle.Format = "0000/00/00";
                //dgSearch.Columns[4].HeaderText = "کد رهگیری";
                //dgSearch.Columns[5].HeaderText = "شماره";
                //dgSearch.Columns[5].Visible = false;
                //DataGridViewButtonColumn btnSend = new DataGridViewButtonColumn();
                //dgSearch.Columns.Add(btnSend);
                //btnSend.Text = "ارسال";
                //btnSend.Name = "btnErsal";
                //btnSend.HeaderText = "ارسال";
                //btnSend.DataPropertyName = "Ersal";
                //btnSend.Width = 50;
                //DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
                //dgSearch.Columns.Add(btnDelete);
                //btnDelete.Text = "حذف";

                //btnDelete.Name = "btnDelete";
                //btnDelete.HeaderText = "حذف";
                //btnDelete.DataPropertyName = "Delete";
                //btnDelete.Width = 50;


            }
            catch (Exception ex)
            {

                MessageBox.Show("ارسال نشده" + "\n" + ex.Message);
            }
        }
        private void OnlinForm_Load(object sender, EventArgs e)
        {
            try
            {
                kitchenEntities context = new kitchenEntities();
                var user = context.User.Where(c => c.Eshterak == dgShow.CurrentRow.Cells[0].Value.ToString()).FirstOrDefault();
                if(user==null)//agar shomare eshterak dar DB nabood ya vared nakarde bood ya eshtebah bood
                {
                    user= context.User.Where(c => c.Phone == dgShow.CurrentRow.Cells[3].Value.ToString()).FirstOrDefault();
                }
                if(user==null)//agar shomare tamas ya shomare eshterak dar DB nabood
                {
                     DialogResult resultCreate=MessageBox.Show("کاربری با این شماره اشتراک وجود ندارد و تماس و وجود ندارد،مشترک جدید ایجاد شود؟","کاربر", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if(resultCreate==DialogResult.No)
                    {
                        return;
                    }
                    else
                    {
                        //sabte user jadid
                        User newUser = new User();
                        string eshterak = dgShow.CurrentRow.Cells[0].Value.ToString();
                        if (eshterak == "" || eshterak == null)
                            eshterak = dgShow.CurrentRow.Cells[3].Value.ToString().Substring(8, 4);
                        newUser.Eshterak = eshterak;
                        newUser.Name = dgShow.CurrentRow.Cells[1].Value.ToString();
                        newUser.Phone = dgShow.CurrentRow.Cells[3].Value.ToString();
                        context.User.Add(newUser);
                        //context.SaveChanges();
                        //sabte sefaresh jadid

                    }
                }

                
            }
            catch (Exception ex)
            {

                MessageBox.Show("مشکل در سفارش آنلاین: \n", ex.Message, MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);

            }
        }
    }
}
