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
    public partial class FormReportAnbar : Form
    {
        public FormReportAnbar()
        {
            InitializeComponent();
        }
        int count = 0; // baraye dafate avaz shodane comProdoct
        //string SelectProdoct = "";
        public void Refresh_dgSearch()
        {
            if (count == 0)
            {
                dgSearch.Columns["Name"].HeaderText = "نام";
                dgSearch.Columns["IdProdoct"].HeaderText = "شماره محصول";
                dgSearch.Columns["IdParent"].HeaderText = "شماره سند";
                dgSearch.Columns["IdParent"].SortMode = DataGridViewColumnSortMode.NotSortable;
                //dgSearch.Columns[4].Visible = false;
                dgSearch.Columns["Positiv"].HeaderText = "ورودی";
                dgSearch.Columns["Negativ"].HeaderText = "خروجی";
                dgSearch.Columns["Price"].HeaderText = "قیمت";
                dgSearch.Columns["Price"].SortMode = DataGridViewColumnSortMode.Programmatic;
                dgSearch.Columns["Description"].HeaderText = "توضیحات";
                dgSearch.Columns["DateBuild"].HeaderText = "تاریخ تولید";
                dgSearch.Columns["DateBuild"].Visible = false;
                dgSearch.Columns["DateExpierd"].HeaderText = "تاریخ انقضا";
                dgSearch.Columns["DateExpierd"].SortMode = DataGridViewColumnSortMode.Automatic;
                dgSearch.Columns["DateExpierd"].DefaultCellStyle.Format = "0000/00/00";
                dgSearch.Columns["CodeRahgiri"].HeaderText = "کد رهگیری";
                dgSearch.Columns["CodeRahgiri"].SortMode = DataGridViewColumnSortMode.Programmatic;
                dgSearch.Columns["IdStore"].HeaderText = "طرف حساب";
                dgSearch.Columns["Id"].HeaderText = "شماره";
                dgSearch.Columns["Id"].Visible = false;

                //dgSearch.Columns[12].Visible = false;
                //dgSearch.Columns[13].Visible = false;
                //dgSearch.Columns[14].Visible = false;
                //-------
                DataGridViewTextBoxColumn positivcColumn = new DataGridViewTextBoxColumn();
                positivcColumn.HeaderText = "مانده";
                positivcColumn.Name = "sumUntilNow";
                positivcColumn.DisplayIndex = 5;
                this.dgSearch.Columns.Add(positivcColumn);
                //-------
                count++;
            }
            
        }
        public string Calculate_DataGrideView()
        {
            //if (count < 1)
            //    return "0";
            long existing = 0;
            StimulsoftEntities context = new StimulsoftEntities();

            if (dgSearch.RowCount > 0)
            {
                for (int i = 0; i < dgSearch.RowCount; i++)
                {
                    long selectCase = Int32.Parse(dgSearch.Rows[i].Cells["IdParent"].Value.ToString());
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
                                    existing = existing + Int32.Parse(dgSearch.Rows[i].Cells["Positiv"].Value.ToString());
                                    break;
                                }


                            case 1: // havale foroosh (mojoodi kam shavad)
                            case 2: // havale masraf (mojoodi kam shavad)
                            case 6: // havale anbar amani (mojoodi kam shavad)
                                {
                                    existing = existing - Int32.Parse(dgSearch.Rows[i].Cells["Negativ"].Value.ToString());
                                    break;
                                }
                        }
                        dgSearch.Rows[i].Cells["sumUntilNow"].Value = existing;

                    }
                    else
                    {
                        break;
                    }
                }
            }
            return existing.ToString();
        } // mohasebe mahsool mande dar anbar hamrah ba darj dar datagridview
        public void Select_Prodoct_Name() // entekhab mahsool 
        {
            //if (count > 1)
            //{
            StimulsoftEntities context = new StimulsoftEntities();
            var getId = context.AnbarProdoct.Where(c => c.Name == comProdoct.Text).FirstOrDefault();
            if (getId != null)
            {
                var getProdocts = context.Anbar.Where(c => c.IdProdoct == getId.Code).ToList();
                //dgSearch.DataSource = getProdocts;
                int dateFirst = int.Parse(DateFirst.Text.Replace("/", ""));
                int dateEnd = int.Parse(DateEnd.Text.Replace("/", ""));
                //for (int i = 0; i < getProdocts.Count; i++)
                //{
                var prodoct = getProdocts.Where(c => c.DateExpierd >= dateFirst && c.DateExpierd <= dateEnd).ToList();
                dgSearch.DataSource = prodoct;
                //}
            }
            


            //}
        }
        public void Select_Prodoct_Date() // entekhab mahsool
        {

        }
        private void FormReportAnbar_Load(object sender, EventArgs e)
        {
            DateFirst.Text = Practical.Today_Date();
            DateEnd.Text = Practical.Today_Date();
            StimulsoftEntities context = new StimulsoftEntities();
            if (context.AnbarProdoct.Count() > 0)
            {
                var prodocts = context.AnbarProdoct.ToList();
                comProdoct.DataSource = prodocts;
                comProdoct.DisplayMember = "Name";
                Refresh_dgSearch();
            }




        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int df= int.Parse(DateFirst.Text.Replace("/",""));
            int de = int.Parse(DateEnd.Text.Replace("/", ""));
            if(df>de) // tarikhe shoroo az payan bishtar nashavad
            {
                MessageBox.Show("تاریخ های بازه زمانی را درست کنید", "تاریخ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Select_Prodoct_Name();
            Refresh_dgSearch();
            lblTotalExisting.Text = Calculate_DataGrideView();
        }

        private void comProdoct_SelectedIndexChanged(object sender, EventArgs e)
        {
            Select_Prodoct_Name();
            if (dgSearch.RowCount > 0)
            {
                //if (count == 0)
                //{
                    Refresh_dgSearch();
                //}
                lblTotalExisting.Text = Calculate_DataGrideView();
            }
        }

        private void comProdoct_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void comProdoct_SelectionChangeCommitted(object sender, EventArgs e)
        {


        }
    }
}
