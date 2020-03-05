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
    public partial class FormWorks : Form
    {
        public FormWorks()
        {
            InitializeComponent();
        }
        int run;
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

        private void FormWorks_Load(object sender, EventArgs e)
        {
            try
            {
                tooltxtSearch.Text = "";
                kitchenEntities context = new kitchenEntities();
                var works = context.ReportService.Where(c => c.Ready == "0").ToList();
                dgSearch.DataSource = works;
            }
            catch (Exception)
            { }
            Works_Refresh();
            run = 1;
        }

        private void toolbtnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                tooltxtSearch.Text = "";
                kitchenEntities context = new kitchenEntities();
                var works = context.ReportService.Where(c => c.Ready == "0").ToList(); // 0 yani anjam shode
                dgSearch.DataSource = works;
            }
            catch (Exception)
            { }
            Works_Refresh();
        }

        private void tooltxtSearch_Enter(object sender, EventArgs e)
        {
            tooltxtSearch.Text = "";
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
                    if (search[i].Ready == "0")
                    {
                        dgSearch.Rows[i].Cells[12].Value = true;
                    }
                    if (search[i].Ready == "1")
                    {
                        dgSearch.Rows[i].Cells[12].Value = false;
                    }
                    if(search[i].Ready==null)
                    {
                        dgSearch.Rows[i].Cells[12].Value = true;
                    }

                    //if (dgSearch.Rows[i].Cells[0].Value == null)
                    //    dgSearch.Rows[i].Cells[0].Value = true;
                    //else if (dgSearch.Rows[i].Cells[0].Value.ToString() == "1000")
                    //    dgSearch.Rows[i].Cells[0].Value = false;
                    //else if (dgSearch.Rows[i].Cells[0].Value.ToString() == "0000")
                    //    dgSearch.Rows[i].Cells[0].Value = true;



                }
            }
            catch (Exception)
            { }
        }

        private void tooltxtSearch_TextChanged(object sender, EventArgs e)
        {
            select(tooltxtSearch.Text);

        }

        private void toolbtnIncomplete_Click(object sender, EventArgs e)
        {
            try
            {
                tooltxtSearch.Text = "";
                kitchenEntities context = new kitchenEntities();
                var works = context.ReportService.Where(c => c.Ready == "1").ToList(); // 1 yani anjam nashode
                dgSearch.DataSource = works;
            }
            catch (Exception)
            { }
            Works_Refresh();
        }

        private void toolbtnComplete_Click(object sender, EventArgs e)
        {
            try
            {
                tooltxtSearch.Text = "";
                kitchenEntities context = new kitchenEntities();
                var works = context.ReportService.Where(c => c.Ready == "0").ToList();
                dgSearch.DataSource = works;
            }
            catch (Exception)
            { }
            Works_Refresh();
        }

        private void toolbtnSearch_Click(object sender, EventArgs e)
        {
            select(tooltxtSearch.Text);

        }
    }

}

