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
    public partial class FormLittelEnter : Form
    {
        public FormLittelEnter()
        {
            InitializeComponent();

        }
        StimulsoftEntities context = new StimulsoftEntities();
        public int see = 0; //baraye por kardan dgshow va por kardanesh
        public string majhool1 = "";
        public string majhool2 = "";
        public string[] majhool;
        public void Select_Show()
        {
            if (majhool[0] == "editProdoct")
            {
                panelStore.Visible = false;
                dgSearch.Visible = false;
                panelProdoct.Visible = true;
                panelProdoct.Dock = DockStyle.Fill;
                //tooltxtSearch.Visible = false;
                Fill_ComUnit();
                //----
                comUnit.SelectedIndex = int.Parse(majhool[2]);
                txtNameProdoct.Text = majhool[3];
                txtCodeProdoct.Text = majhool[4];
                txtDetails.Text = majhool[5];
                txtBarcode.Text = majhool[6];
                txtRFID.Text = majhool[7];
            }
            if (majhool[0]=="editStore") // namayeshe edit store
            {
                panelStore.Visible = true;
                dgSearch.Visible = false;
                panelProdoct.Visible = false;
                panelStore.Dock = DockStyle.Fill;
                //tooltxtSearch.Visible = false;
                //-----
                txtStoreName.Text = majhool[2];
                txtTelStore.Text = majhool[3];
                txtAddressStore.Text = majhool[4];
                
            }

            if (see == 1)
            {
                panelProdoct.Visible = false;
                panelStore.Visible = false;
                dgSearch.Visible = true;
                dgSearch.Dock = DockStyle.Fill;
                dgSearch.RightToLeft = RightToLeft.Yes;
                dgSearch.DataSource = context.AnbarProdoct.ToList();
                dgSearch.Columns[0].Visible = false;
                dgSearch.Columns[1].Visible = false;
                dgSearch.Columns[2].HeaderText = "نام محصول";
                dgSearch.Columns[3].HeaderText = "کد کالا";
                dgSearch.Columns[4].HeaderText = "توضیحات";
                dgSearch.Columns[5].HeaderText = "بارکد";
                dgSearch.Columns[6].HeaderText = "تگ شناسایی";
                dgSearch.Columns[7].Visible = false;
                dgSearch.Columns[8].Visible = false;
                //------
                //tooltxtSearch.Visible = true;
            }
        }
        private void Add_Prodoct()
        {
            AnbarProdoct newprodoct = new AnbarProdoct();
            newprodoct.Name = txtNameProdoct.Text;
            newprodoct.Code = long.Parse(txtCodeProdoct.Text);
            newprodoct.IdUnit = comUnit.SelectedIndex;
            newprodoct.Description = txtDetails.Text;
            newprodoct.Barcode = txtBarcode.Text;
            newprodoct.RfID = txtRFID.Text;
            context.AnbarProdoct.Add(newprodoct);
            context.SaveChanges();
            MessageBox.Show("محصول ثبت شد", "ثبت", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtNameProdoct.Text = "";
            txtCodeProdoct.Text = "";
            txtDetails.Text = "";
            txtBarcode.Text = "";
            txtRFID.Text = "";
            txtNameProdoct.Focus();
        }
        public void Fill_ComUnit()
        {
            comUnit.DataSource = context.Unit.ToList();
            comUnit.DisplayMember = "Name";
        }
        private void FormLitelEnter_Load(object sender, EventArgs e)
        {
            Select_Show();
        }

        private void toolExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSaveProdoct_Click(object sender, EventArgs e)
        {
            if (majhool[0] == "editProdoct") // baraye edit kardane mahsool 
            {
                using (var context = new StimulsoftEntities())
                {
                    Int32 id = Int32.Parse(majhool[1]);
                    var selectProdoct = context.AnbarProdoct.Where(c => c.Id == id).FirstOrDefault();
                    if (selectProdoct == null)
                    {
                        MessageBox.Show("این نام محصول تکراری است", "ثبت", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        selectProdoct.Name = txtNameProdoct.Text;
                        selectProdoct.Code = int.Parse(txtCodeProdoct.Text);
                        selectProdoct.IdUnit = comUnit.SelectedIndex;
                        selectProdoct.Description = txtDetails.Text;
                        selectProdoct.Barcode = txtBarcode.Text;
                        selectProdoct.RfID = txtRFID.Text;
                        context.SaveChanges();
                        MessageBox.Show("ویرایش انجام شد", "ویرایش", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Close();
                        FormAnbar frmAnbar = new FormAnbar();
                        frmAnbar.Refresh_dgProdoct();
                    }
                }
            }
        }

        private void btnAddUnit_Click(object sender, EventArgs e)
        {
            FormAddUnit frmUnit = new FormAddUnit();
            //frmUnit.Location = new Point(btnAddUnit.Location.X,btnAddUnit.Location.Y);
            frmUnit.ShowDialog();
            Fill_ComUnit();

        }

        private void dgSearch_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FormAnbar frmAnbar = new FormAnbar();
            majhool1 = dgSearch.CurrentRow.Cells[3].Value.ToString();
            majhool2 = dgSearch.CurrentRow.Cells[2].Value.ToString();
            this.Close();

        }

        private void btnSaveStore_Click(object sender, EventArgs e)
        {
            if(majhool[0]=="editStore")
            {
                Int32 id = Int32.Parse(majhool[1]);

                var selectStore = context.Store.Where(c => c.Id == id).FirstOrDefault();
                selectStore.Name = txtStoreName.Text;
                selectStore.Phone = txtTelStore.Text;
                selectStore.Address = txtAddressStore.Text;
                context.SaveChanges();
                MessageBox.Show("ویرایش انجام شد", "ویرایش", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                FormAnbar frmAnbar = new FormAnbar();
                frmAnbar.Refresh_dgStore();
            }
        }

        private void btnDelUnit_Click(object sender, EventArgs e)
        {
            if(comUnit.Items.Count>0)
            {
                var selectUnit = context.Unit.Where(c => c.Name == comUnit.Text).FirstOrDefault();
                context.Unit.Remove(selectUnit);
                context.SaveChanges();
            }
            Fill_ComUnit();
        }
    }
}
