using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PopupControl;
using Papiloo;

namespace Service
{
    public partial class FormAnbar : Form
    {
        public FormAnbar()
        {
            InitializeComponent();
        }
        Popup popup;
        //public string majhool1 = "",majhool2="";
        long idParent;
        public void Refresh_dgProdoct() // update kardane maghadire dgProdoct
        {
            using (var context1 = new StimulsoftEntities())
            {
                if (context1.AnbarProdoct.Count() > 0)
                {
                    dgProdoct.DataSource = context1.AnbarProdoct.ToList();
                    dgProdoct.Columns[0].Visible = false;
                    dgProdoct.Columns[1].Visible = false;
                    dgProdoct.Columns[2].HeaderText = "نام کالا";
                    dgProdoct.Columns[3].HeaderText = "کد کالا";
                    dgProdoct.Columns[4].HeaderText = "توضیحات";
                    dgProdoct.Columns[5].HeaderText = "بارکد";
                    dgProdoct.Columns[6].HeaderText = "تگ شناسایی";
                    //dgProdoct.Columns[7].Visible = false;
                    //dgProdoct.Columns[8].Visible = false;

                }
                dgProdoct.DefaultCellStyle.Font = new Font("Tahoma", 8);
                dgProdoct.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 8);

            }
        }
        public void Refresh_dgStore()
        {
            using (var context1 = new StimulsoftEntities())
            {
                if (context1.Store.Count() > 0)
                {

                    dgStore.DataSource = context1.Store.ToList();
                    dgStore.Columns[0].Visible = false;
                    dgStore.Columns[1].HeaderText = "فروشگاه یا فرد";
                    dgStore.Columns[1].Width = 100;
                    dgStore.Columns[2].HeaderText = "تلفن";
                    dgStore.Columns[3].HeaderText = "آدرس";
                    //dgStore.Columns[4].Visible = false;
                    //MessageBox.Show("anjam shod");
                }
                dgStore.DefaultCellStyle.Font = new Font("Tahoma", 8);
                dgStore.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 8);
            }

        }// update kardane maghadire dgStore
        public void Add_Parent_Prodoct() // ezafe kardane faktore jadid be jadvale AnbarParent va tolide code rahgirie jadid
        {
            try
            {
                StimulsoftEntities context = new StimulsoftEntities();
                AnbarParent parent = new AnbarParent();
                parent.Case = comCase.SelectedIndex;
                parent.Date = int.Parse(Date.Text.Replace("/", ""));
                parent.Description = txtDetails.Text;
                context.AnbarParent.Add(parent);
                context.SaveChanges();
                //------
                groupProdoct.Enabled = true;
                dgProdoct.Focus();
                txtCodeProdoct.ForeColor = Color.Black;
                //-----
                if (context.Anbar.Count() > 0)
                {
                    var listCodeRahgiri = context.Anbar.ToList();
                    long endCodeRahgiri = Int32.Parse(listCodeRahgiri.LastOrDefault().CodeRahgiri.ToString());
                    endCodeRahgiri++;
                    lblCodeRahgiri.Text = endCodeRahgiri.ToString();
                }
                else if (context.Anbar.Count() == 0)
                {
                    lblCodeRahgiri.Text = "1";
                }
                context.Dispose();
                {
                    StimulsoftEntities context1 = new StimulsoftEntities();

                    if (context1.AnbarParent.Count() > 0)
                    {
                        var selectIdParent = context1.AnbarParent.ToList();

                        idParent = selectIdParent.LastOrDefault().Id;
                    }
                }
                //idParent = selectIdParent;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private string Sugettion_Price(string NameProdoct) // pishnahad dadane mahsool bar asase akharin gheimat
        {
            StimulsoftEntities context = new StimulsoftEntities();
            string price = "";
            if (context.Anbar.Count() > 0)
            {
                var selectAll = context.Anbar.Where(c => c.Name == NameProdoct).ToList();
                var selectEnd = selectAll.LastOrDefault();
                if (selectEnd == null)
                {
                    return price = "خرید و فروش نشده";

                }
                int countProdoct = Convert.ToInt16(selectEnd.Positiv + selectEnd.Negativ);
                price = (selectEnd.Price / countProdoct).ToString();
                price = Practical.split_3Number(price);
            }
            else
            {
                price = "محصولی ثبت نشده";
            }
            return price;
        }
        public string Count_Prodct_Anbar(string NameProdoct) // tedad mojoodi anbar 
        {
            StimulsoftEntities context = new StimulsoftEntities();
            var getId = context.AnbarProdoct.Where(c => c.Name == NameProdoct).FirstOrDefault();
            if (getId != null)
            {
                var getProdocts = context.Anbar.Where(c => c.IdProdoct == getId.Code).ToList();
                //dgSearch.DataSource = getProdocts;
                //************
                //************
                long existing = 0;
                if (getProdocts.Count > 0)
                {
                    for (int i = 0; i < getProdocts.Count; i++)
                    {
                        long selectCase = Int32.Parse(getProdocts[i].IdParent.ToString());
                        var findParentCase = context.AnbarParent.Where(c => c.Id == selectCase).FirstOrDefault();
                        if (findParentCase != null)
                        {
                            switch (findParentCase.Case)
                            {
                                case 0: // reside khard (mojoodi ezafe shavad)
                                case 3: // resid tolid (mojoodi ezafe shavad)
                                case 4: // bargasgt kala foroosh (mojoodi ezafe shavad)
                                case 5: // bargashte kala masraf (mojoodi ezafe shavad)
                                case 7: // bargasht kala amani (mojoodi ezafe shavad)
                                    {
                                        existing = existing + Int32.Parse(getProdocts[i].Positiv.ToString());
                                        break;
                                    }


                                case 1: // havale foroosh (mojoodi kam shavad)
                                case 2: // havale masraf (mojoodi kam shavad)
                                case 6: // havale anbar amani (mojoodi kam shavad)
                                    {
                                        existing = existing - Int32.Parse(getProdocts[i].Negativ.ToString());
                                        break;
                                    }
                            }
                        }
                    }
                }
                return existing.ToString();
            }

            return "0";
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Add_Parent_Prodoct();
        }

        private void FormAnbar_Load(object sender, EventArgs e)
        {
            Date.Text = Practical.Today_Date();
            dateExpird.Text = Practical.Today_Date();
            comCase.SelectedIndex = 0;
            //dgAnbar.Enabled = false;
            groupProdoct.Enabled = false;
            //dateExpird.Text = Practical.Today_Date();
            dateExpird.ForeColor = Color.DarkGray;
            //dateExpird.Text = "تاریخ انقضا";
            Refresh_dgProdoct();
            Refresh_dgStore();
            dgProdoct.ClearSelection();
            dgStore.ClearSelection();
        }


        public string[] prodoct() // gereftane maghadir va baraye ezafe kardane prodoct
        {
            string[] prodoct1;
            if (dgProdoct.SelectedRows.Count < 1)
            {
                MessageBox.Show("محصول را انتخاب کنید", "انتخاب", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                prodoct1 = new string[] { "-1" };
                dgProdoct.Focus();
                return prodoct1;
            }
            if (dgStore.SelectedRows.Count < 1)
            {
                MessageBox.Show("فروشگاه یا فرد را انتخاب کنید", "انتخاب", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                prodoct1 = new string[] { "-1" };
                dgStore.Focus();
                return prodoct1;
            }
            if (txtSomeProdoct.Text == "" || txtSomeProdoct.Text == "مقدار")
            {
                MessageBox.Show("مقدار را وارد کنید", "انتخاب", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                prodoct1 = new string[] { "-1" };
                txtSomeProdoct.Focus();
                return prodoct1;
            }
            if (comCase.SelectedIndex == 1 || comCase.SelectedIndex == 2 || comCase.SelectedIndex == 6)
            {
                if (int.Parse(lblExistingProdoct.Text) < int.Parse(txtSomeProdoct.Text))
                {
                    MessageBox.Show("موجودی انبار کافی نیست", "انبار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    prodoct1 = new string[] { "-1" };
                    txtSomeProdoct.Focus();
                    return prodoct1;
                }
            }
            if (txtPriceProdoct.Text == "" || txtPriceProdoct.Text == "قیمت")
            {
                MessageBox.Show("قیمت را وارد کنید", "انتخاب", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                prodoct1 = new string[] { "-1" };
                txtPriceProdoct.Focus();
                return prodoct1;
            }
            if (dateExpird.Text == "" || dateExpird.Text == "تاریخ انقضا")
            {
                MessageBox.Show("تاریخ را انتخاب کنید", "انتخاب", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                prodoct1 = new string[] { "-1" };
                dateExpird.Focus();
                return prodoct1;
            }
            if (txtDetailProdoct.Text == "توضیحات")
            {
                txtDetailProdoct.ForeColor = Color.Black;
                txtDetailProdoct.Text = "";
            }
            if (lblCodeRahgiri.Text == "")
            {
                MessageBox.Show("کد رهگیری ندارد", "کد رهگیری", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                prodoct1 = new string[] { "-1" };
                return prodoct1;
            }
            long price = long.Parse(txtPriceProdoct.Text.Replace(",", ""));
            long some = long.Parse(txtSomeProdoct.Text);
            price *= some;
            prodoct1 = new string[] 
            {
                dgProdoct.CurrentRow.Cells[3].Value.ToString() ,
                dgProdoct.CurrentRow.Cells[2].Value.ToString(),
                dgStore.CurrentRow.Cells[1].Value.ToString(),
                txtSomeProdoct.Text ,
                Practical.split_3Number( price.ToString()) ,
                txtDetailProdoct.Text ,
                dateExpird.Text
            };
            return prodoct1;
        }
        private void btnSaveProdoct_Click(object sender, EventArgs e)
        {
            try
            {
                string[] pro = prodoct();
                if (pro[0] != "-1")
                {
                    // *** baraye jologiri az sabte mahsoole tekrari
                    if (dgAnbar.RowCount > 0)
                    {
                        int i = 0;
                        while (i < dgAnbar.RowCount)
                        {
                            if (dgAnbar.Rows[i].Cells[0].Value.ToString() == pro[0])
                            {
                                MessageBox.Show("همچین کالایی در لیست وجود دارد", "محصول", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            i++;
                        }
                    }
                    dgAnbar.Rows.Add(pro[0], pro[1], pro[2], pro[3], pro[4], pro[5], pro[6]);
                    //dgAnbar.Enabled = true;
                }
                //------
                //Anbar newProdoct = new Anbar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void txtCodeProdoct_TextChanged(object sender, EventArgs e)
        {
            StimulsoftEntities context = new StimulsoftEntities();
            if (context.AnbarProdoct.Count() > 0)
            {
                if (txtCodeProdoct.TextLength <= 0)
                {
                    dgProdoct.DataSource = context.AnbarProdoct.ToList();
                }
                else
                {
                    long x = long.Parse(txtCodeProdoct.Text);
                    var selectProdoct = context.AnbarProdoct.Where(c => c.Code == x).ToList();
                    dgProdoct.DataSource = selectProdoct;
                }
                dgProdoct.Columns[0].Visible = false;
                dgProdoct.Columns[1].Visible = false;
                dgProdoct.Columns[2].HeaderText = "نام کالا";
                dgProdoct.Columns[3].HeaderText = "کد کالا";
                dgProdoct.Columns[4].HeaderText = "توضیحات";
                dgProdoct.Columns[5].HeaderText = "بارکد";
                dgProdoct.Columns[6].HeaderText = "تگ شناسایی";
                //dgProdoct.Columns[7].Visible = false;
                //dgProdoct.Columns[8].Visible = false;
            }
        }

        private void txtCodeProdoct_Enter(object sender, EventArgs e)
        {
            if (txtCodeProdoct.Text == "کد کالا")
            {
                txtCodeProdoct.Text = "";
                txtCodeProdoct.ForeColor = Color.Black;
            }
        }

        private void txtCodeProdoct_Leave(object sender, EventArgs e)
        {
            if (txtCodeProdoct.Text == "")
            {
                txtCodeProdoct.Text = "";
                //txtCodeProdoct.ForeColor = Color.DarkGray;
                //txtCodeProdoct.Text = "کدکالا";
            }
        }

        private void txtNameProdoct_Enter(object sender, EventArgs e)
        {
            if (txtNameProdoct.Text == "نام کالا")
            {
                txtNameProdoct.ForeColor = Color.Black;
                txtNameProdoct.Text = "";
            }
        }

        private void txtNameProdoct_Leave(object sender, EventArgs e)
        {
            if (txtNameProdoct.Text == "")
            {
                txtCodeProdoct.Text = "";
                //txtNameProdoct.ForeColor = Color.DarkGray;
                //txtNameProdoct.Text = "نام کالا";
            }
        }

        private void txtStoreProdoct_Leave(object sender, EventArgs e)
        {
            if (txtNameStore.Text == "")
            {

                //txtNameStore.ForeColor = Color.DarkGray;
                //txtNameStore.Text = "طرف حساب";
            }
        }

        private void txtStoreProdoct_Enter(object sender, EventArgs e)
        {
            if (txtNameStore.Text == "طرف حساب")
            {
                txtNameStore.ForeColor = Color.Black;
                txtNameStore.Text = "";
            }
        }

        private void txtSomeProdoct_Enter(object sender, EventArgs e)
        {
            if (txtSomeProdoct.Text == "مقدار")
            {
                txtSomeProdoct.ForeColor = Color.Black;
                txtSomeProdoct.Text = "";
            }
        }

        private void txtSomeProdoct_Leave(object sender, EventArgs e)
        {
            if (txtSomeProdoct.Text == "")
            {
                txtSomeProdoct.ForeColor = Color.DarkGray;
                txtSomeProdoct.Text = "مقدار";
            }
        }

        private void txtPriceProdoct_Leave(object sender, EventArgs e)
        {
            if (txtPriceProdoct.Text == "")
            {
                txtPriceProdoct.ForeColor = Color.DarkGray;
                txtPriceProdoct.Text = "قیمت";
            }
        }

        private void txtPriceProdoct_Enter(object sender, EventArgs e)
        {
            if (txtPriceProdoct.Text == "قیمت")
            {
                txtPriceProdoct.ForeColor = Color.Black;
                txtPriceProdoct.Text = "";
            }
        }

        private void txtDetailProdoct_Enter(object sender, EventArgs e)
        {
            if (txtDetailProdoct.Text == "توضیحات")
            {
                txtDetailProdoct.ForeColor = Color.Black;
                txtDetailProdoct.Text = "";
            }
        }

        private void txtDetailProdoct_Leave(object sender, EventArgs e)
        {
            if (txtDetailProdoct.Text == "")
            {
                txtDetailProdoct.ForeColor = Color.DarkGray;
                txtDetailProdoct.Text = "توضیحات";
            }
        }

        private void dateExpird_Enter(object sender, EventArgs e)
        {
            if (dateExpird.Text == "تاریخ انقضا")
            {
                dateExpird.ForeColor = Color.Black;
                dateExpird.Text = "";
            }
        }
        private void txtCodeProdoct_Click(object sender, EventArgs e)
        {
            txtCodeProdoct.Text = "";
            txtCodeProdoct.ForeColor = Color.Black;
        }

        private void txtCodeProdoct_KeyPress(object sender, KeyPressEventArgs e)
        {
            Practical.Enter_Number(sender, e);
        }

        private void btnAddColleague_Click(object sender, EventArgs e)
        {
            FormLittelEnter frmLitteleEnter = new FormLittelEnter();
            frmLitteleEnter.see = 3;
            frmLitteleEnter.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormLittelEnter frmlittleEnter = new FormLittelEnter();
            frmlittleEnter.see = 2;
            frmlittleEnter.ShowDialog();
        }

        private void popup_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            //S_Date.Text = PCalander.Pc_Date;
        }

        private void ucAddStore_Load(object sender, EventArgs e)
        {
            ucAddStore.btn.Text = "+";
            ucAddStore.btn.BackColor = Color.Green;
            ucAddStore.show = "store";
        }

        private void ucDelStore_Load(object sender, EventArgs e)
        {
            ucDelStore.btn.Text = "+";
            ucDelStore.btn.BackColor = Color.Green;
            ucDelStore.show = "prodoct";
        }

        private void txtNameStore_TextChanged(object sender, EventArgs e)
        {
            StimulsoftEntities context = new StimulsoftEntities();
            if (txtNameStore.Text != "")
            {
                var selectStore = context.Store.Where(c => c.Name.Contains(txtNameStore.Text)).ToList();
                dgStore.DataSource = selectStore;
            }
            else if (txtNameStore.Text == "طرف حساب" || txtNameStore.Text == "")
            {
                dgStore.DataSource = context.Store.ToList();
            }
        }

        private void txtNameProdoct_TextChanged(object sender, EventArgs e)
        {
            StimulsoftEntities context = new StimulsoftEntities();
            if (context.AnbarProdoct.Count() > 0)
            {
                if (txtNameProdoct.TextLength > 0)
                {
                    var selectProdoct = context.AnbarProdoct.Where(c => c.Name.Contains(txtNameProdoct.Text)).ToList();
                    dgProdoct.DataSource = selectProdoct;
                }
                dgProdoct.Columns[0].Visible = false;
                dgProdoct.Columns[1].Visible = false;
                dgProdoct.Columns[2].HeaderText = "نام کالا";
                dgProdoct.Columns[3].HeaderText = "کد کالا";
                dgProdoct.Columns[4].HeaderText = "توضیحات";
                dgProdoct.Columns[5].HeaderText = "بارکد";
                dgProdoct.Columns[6].HeaderText = "تگ شناسایی";
                //dgProdoct.Columns[7].Visible = false;
                //dgProdoct.Columns[8].Visible = false;
            }
        }

        private void btnRefreshDgProdoct_Click(object sender, EventArgs e)
        {
            Refresh_dgProdoct();
        }

        private void btnRefreshDgStore_Click(object sender, EventArgs e)
        {
            Refresh_dgStore();
        }

        private void btnDelProdoct_Click(object sender, EventArgs e)
        {
            StimulsoftEntities context = new StimulsoftEntities();
            if (dgProdoct.Rows.Count > 0)
            {
                if (dgProdoct.CurrentRow != null)
                {
                    int id = int.Parse(dgProdoct.CurrentRow.Cells[0].Value.ToString());
                    DialogResult result = MessageBox.Show("آیا از حذف محصول مطئن هستید؟", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        var selectProdoct = context.AnbarProdoct.Where(c => c.Id == id).FirstOrDefault();
                        context.AnbarProdoct.Remove(selectProdoct);
                        context.SaveChanges();
                        Refresh_dgProdoct();
                    }
                }
            }
        }

        private void btnDelStore_Click(object sender, EventArgs e)
        {
            StimulsoftEntities context = new StimulsoftEntities();
            if (dgStore.Rows.Count > 0 && dgStore.CurrentRow != null)
            {

                int id = int.Parse(dgStore.CurrentRow.Cells[0].Value.ToString());
                DialogResult result = MessageBox.Show("آیا از حذف فروشگاه مطئن هستید؟", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    var selectStore = context.Store.Where(c => c.Id == id).FirstOrDefault();
                    context.Store.Remove(selectStore);
                    context.SaveChanges();
                    Refresh_dgStore();
                }
            }
        }

        private void btnEditProdoct_Click(object sender, EventArgs e)
        {
            if (dgProdoct.SelectedRows.Count == 1)
            {
                FormLittelEnter frmLittelEnter = new FormLittelEnter();
                frmLittelEnter.Text = "ویرایش محصول";
                if (dgProdoct.SelectedRows.Count == 1)
                {
                    frmLittelEnter.majhool = new string[]{
                    "editProdoct",  //frmLittelEnter.prodoct[0] = "2";
                    dgProdoct.CurrentRow.Cells[0].Value.ToString(), // dadane id meghdare entekhab shode
                    dgProdoct.CurrentRow.Cells[1].Value.ToString(), // dadane meghdare unit entekhab shode
                    dgProdoct.CurrentRow.Cells[2].Value.ToString(),
                    dgProdoct.CurrentRow.Cells[3].Value.ToString(),
                    dgProdoct.CurrentRow.Cells[4].Value.ToString(),
                    dgProdoct.CurrentRow.Cells[5].Value.ToString(),
                    dgProdoct.CurrentRow.Cells[6].Value.ToString(),
                };
                    frmLittelEnter.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("یک مورد را انتخاب کنید", "ویرایش", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEditStore_Click(object sender, EventArgs e)
        {
            if (dgStore.SelectedRows.Count == 1)
            {
                FormLittelEnter frmLittelEnter = new FormLittelEnter();
                frmLittelEnter.Text = "ویرایش فروشگاه یا فرد";
                frmLittelEnter.majhool = new string[]{
                "editStore",
                dgStore.CurrentRow.Cells[0].Value.ToString(),
                dgStore.CurrentRow.Cells[1].Value.ToString(),
                dgStore.CurrentRow.Cells[2].Value.ToString(),
                dgStore.CurrentRow.Cells[3].Value.ToString()
                    };
                frmLittelEnter.ShowDialog();
            }
            else
            {
                MessageBox.Show("یک مورد را انتخاب کنید", "ویرایش", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }


        private void dgAnbar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                dgAnbar.Rows.Remove(dgAnbar.CurrentRow);
            }
        }

        private void txtCodeProdoct_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            Practical.Enter_Number(sender, e);
        }

        private void txtSomeProdoct_KeyPress(object sender, KeyPressEventArgs e)
        {
            Practical.Enter_Number(sender, e);
        }

        private void txtPriceProdoct_KeyPress(object sender, KeyPressEventArgs e)
        {
            Practical.Enter_Number(sender, e);
        }

        //private string Count_Prodoct(string codeProdoct , int count) // bargardandane tedad mojoodi anbar
        //{
        //    StimulsoftEntities context = new StimulsoftEntities();
        //}
        private void btnSaveAllProdoct_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgAnbar.RowCount == 0)
                {
                    return;
                }
                StimulsoftEntities context = new StimulsoftEntities();
                for (int i = 0; i < dgAnbar.RowCount; i++)
                {
                    Anbar newAnbar = new Anbar();

                    newAnbar.IdProdoct = Int32.Parse(dgAnbar.Rows[i].Cells[0].Value.ToString());
                    newAnbar.Name = dgAnbar.Rows[i].Cells[1].Value.ToString();
                    newAnbar.IdParent = idParent;
                    // newAnbar.Count   // baraye jame maghadir in kala
                    newAnbar.Price = int.Parse(txtPriceProdoct.Text.Replace(",", ""));
                    newAnbar.Description = dgAnbar.Rows[i].Cells[5].Value.ToString();
                    newAnbar.DateExpierd = int.Parse(dgAnbar.Rows[i].Cells[6].Value.ToString().Replace("/", ""));
                    newAnbar.CodeRahgiri = int.Parse(lblCodeRahgiri.Text);
                    newAnbar.IdStore = idStore;
                    //long countGrid = 
                    switch (comCase.SelectedIndex)
                    {
                        case 0: // reside khard (mojoodi ezafe shavad)
                        case 3: // resid tolid (mojoodi ezafe shavad)
                        case 4: // bargasgt kala foroosh (mojoodi ezafe shavad)
                        case 7: // bargasht kala amani (mojoodi ezafe shavad)
                            {
                                newAnbar.Positiv = Int32.Parse(dgAnbar.Rows[i].Cells[3].Value.ToString());
                                newAnbar.Negativ = 0;
                                break;
                            }
                        case 1: // havale foroosh (mojoodi kam shavad)
                        case 2: // havale masraf (mojoodi kam shavad)
                        case 5: // bargashte kala masraf (mojoodi kam shavad)
                        case 6: // havale anbar amani (mojoodi kam shavad)
                            {
                                newAnbar.Positiv = 0;
                                newAnbar.Negativ = Int32.Parse(dgAnbar.Rows[i].Cells[3].Value.ToString());
                                break;
                            }
                    }
                    //------
                    context.Anbar.Add(newAnbar);
                }

                context.SaveChanges();
                MessageBox.Show("محصولات ثبت شد", "ثبت", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgAnbar.Rows.Clear();
                btnSaveAllProdoct.Enabled = false;
                groupProdoct.Enabled = false;
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }

        }
        int idStore;
        private void dgStore_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgStore.RowCount > 0)
            {
                idStore = int.Parse(dgStore.CurrentRow.Cells[0].Value.ToString());
            }
        }

        private void dateExpird_Load(object sender, EventArgs e)
        {

        }


        private void dgAnbar_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            switch (dgAnbar.CurrentCell.ColumnIndex) // mahdoodiyat rooye khanehaye Data gride
            {
                case 3:
                    {
                        e.Control.KeyPress -= Practical.limited_Enter;
                        e.Control.KeyPress -= Practical.limited_Enter;
                        e.Control.KeyPress += Practical.limited_Enter;
                        break;
                    }
                case 4:
                    {
                        e.Control.KeyPress -= Practical.limited_Enter;
                        e.Control.KeyPress -= Practical.limited_Enter;
                        e.Control.KeyPress += Practical.limited_Enter;
                        break;
                    }
                default:
                    {
                        e.Control.KeyPress -= Practical.limited_Enter;
                        e.Control.KeyPress -= Practical.limited_Enter;
                        break;
                    }
            }
        }

        private void txtPriceProdoct_TextChanged(object sender, EventArgs e)
        {
            txtPriceProdoct.Text = Practical.split_3Number(txtPriceProdoct.Text);
            txtPriceProdoct.Select(txtPriceProdoct.TextLength, 0);

        }

        private void dgAnbar_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblTotalPrice.Text = Practical.Sum_price_DataGrideView(dgAnbar, 4);
            btnSaveAllProdoct.Enabled = true;
        }

        private void dgAnbar_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblTotalPrice.Text = Practical.Sum_price_DataGrideView(dgAnbar, 4);
            if (dgAnbar.RowCount == 0)
            {
                btnSaveAllProdoct.Enabled = false;
            }

        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            FormReportAnbar frmAnbarReport = new FormReportAnbar();
            frmAnbarReport.Show();
        }

        private void toolBtnAnbarReport_Click(object sender, EventArgs e)
        {
            FormReportAnbar frmAnbarReport = new FormReportAnbar();
            frmAnbarReport.Show();
        }

        private void dgProdoct_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            lblSugettion.Text = Sugettion_Price(dgProdoct.CurrentRow.Cells[2].Value.ToString());

            lblExistingProdoct.Text = Count_Prodct_Anbar(dgProdoct.CurrentRow.Cells[2].Value.ToString());
        }

    }
}


