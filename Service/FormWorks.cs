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
    public partial class FormWorks : Form
    {
        public FormWorks()
        {
            InitializeComponent();
        }
        int run;
        public void Change_Ready_State(DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.ColumnIndex == 12)
                {
                    int selectId = int.Parse(dgSearch.CurrentRow.Cells[10].Value.ToString());
                    using (var context = new kitchenEntities())
                    {
                        var select = context.ReportService.Where(c => c.Id == selectId).FirstOrDefault();
                        if (select.Ready == "1")
                        {
                            select.Ready = "0";
                            context.SaveChanges();
                            dgSearch.CurrentCell.Value = true;
                            return;
                        }
                        if (select.Ready == "0")
                        {
                            select.Ready = "1";
                            context.SaveChanges();
                            dgSearch.CurrentCell.Value = false;
                            return;
                        }
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("عوض کردن وضعیت آماده ویرایش" + "\n" + ex.Message);
            }
        }
        public void Works_Refresh()
        {
            if (dgSearch.DataSource != null)
            {
                if (run < 1)
                {
                    try
                    {
                        DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                        dgSearch.Columns.Add(chk);
                        //dgSearch.Columns[0].DefaultCellStyle = chk;
                        chk.HeaderText = "آماده بودن";
                        chk.Name = "Ready";
                        chk.DisplayIndex = 0;
                        //dgSearch.Columns[0].Visible = false;
                        //dgSearch.Columns[0].HeaderText = "آماده بودن";
                        //dgSearch.Columns[0].DefaultCellStyle = data
                        //dgSearch.Columns[0].HeaderText = "آماده بودن";
                        dgSearch.Columns[0].Visible = false;
                        //dgSearch.Columns[0].DisplayIndex = 11;
                        dgSearch.Columns[1].HeaderText = "اشتراک";
                        dgSearch.Columns[2].HeaderText = "تاریخ";
                        dgSearch.Columns[2].DefaultCellStyle.Format = "0000/00/00";
                        //dgSearch.Columns[3].Visible = false;
                        dgSearch.Columns[3].HeaderText = "دسته";
                        //dgSearch.Columns[4].Visible = false;
                        dgSearch.Columns[4].HeaderText = "محصول";
                        //dgSearch.Columns[5].Visible = false;
                        dgSearch.Columns[5].HeaderText = "سرویس";
                        //dgSearch.Columns[6].Visible = false;
                        dgSearch.Columns[6].HeaderText = "تعداد";
                        //dgSearch.Columns[7].Visible = false;
                        dgSearch.Columns[7].HeaderText = "مبلغ";
                        dgSearch.Columns[8].HeaderText = "کد رهگیری";
                        dgSearch.Columns[9].Visible = false;
                        dgSearch.Columns[9].HeaderText = " شماره";
                        dgSearch.Columns[10].Visible = false;
                        dgSearch.Columns[10].HeaderText = "تعداد مراجعه";
                        //dgSearch.Columns[11].DisplayIndex = 0;
                        dgSearch.Columns[11].HeaderText = "ارزش افزوده";

                    }
                    catch (Exception)
                    {


                    }
                    dgSearch.AutoGenerateColumns = false;

                }
            }
        }
        public void select(string coderahgiri)
        {
            try
            {
                kitchenEntities context = new kitchenEntities();
                var search = context.ReportService.Where(c => c.CodeRahgiri == coderahgiri).ToList();
                dgSearch.DataSource = search;
                Works_Refresh();
                for (int i = 0; i < search.Count; i++)
                {
                    switch (search[i].Ready)
                    {
                        case "0":
                            {
                                dgSearch.Rows[i].Cells[12].Value = true;
                                break;
                            }
                        case "1":
                            {
                                dgSearch.Rows[i].Cells[12].Value = false;
                                break;
                            }
                        case null:
                            {
                                dgSearch.Rows[i].Cells[12].Value = true;
                                break;
                            }
                    }
                }
            }
            catch (Exception)
            { }
        }
        public void Incomplete() // entekhabe anjam nashodeha
        {
            try
            {
                kitchenEntities context = new kitchenEntities();
                var works = context.ReportService.Where(c => c.Ready == "1").ToList();
                dgSearch.DataSource = works;
            }
            catch (Exception)
            { }
        }
        private void FormWorks_Load(object sender, EventArgs e)
        {
            Incomplete();
            Works_Refresh();
            run = 1;
        }

        private void toolbtnRefresh_Click(object sender, EventArgs e)
        {

            Incomplete();
        }



        private void tooltxtSearch_TextChanged(object sender, EventArgs e)
        {
            select(tooltxtSearch.Text);
            run = 1;

        }

        private void toolbtnIncomplete_Click(object sender, EventArgs e)
        {
            Incomplete();
            //Works_Refresh();
        }

        private void toolbtnComplete_Click(object sender, EventArgs e)
        {
            try
            {
                //tooltxtSearch.Text = "";
                kitchenEntities context = new kitchenEntities();
                var works = context.ReportService.Where(c => c.Ready == "0").ToList();
                dgSearch.DataSource = works;
                
                for (int i=0;i<works.Count;i++)
                {
                    switch (works[i].Ready)
                    {
                        case null:
                            {
                                dgSearch.Rows[i].Cells[12].Value = true;
                                break;
                            }
                        case "0":
                            {
                                dgSearch.Rows[i].Cells[12].Value = true;
                                break;
                            }
                        case "1":
                            {
                                dgSearch.Rows[i].Cells[12].Value = false;
                                break;
                            }
                    }
                }
                tooltxtSearch.Focus();
                
            }
            catch (Exception)
            { }
            //Works_Refresh();
        }

        private void toolbtnSearch_Click(object sender, EventArgs e)
        {
            select(tooltxtSearch.Text);

        }

        private void dgSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Change_Ready_State(e);
        }

        private void tooltxtSearch_Click(object sender, EventArgs e)
        {
            tooltxtSearch.Text = "";
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                dgSearch.Rows[0].Cells[12].Value = false;
        }
    }

}

