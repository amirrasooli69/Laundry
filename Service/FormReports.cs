using Stimulsoft.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Service
{
    public partial class FormReports : Form
    {
        StiReport Report = new StiReport();
        SaveFileDialog _save;
        public FormReports()
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
        private void Design_GrideView_Service() // tarahi datagride service
        {
            if (dgSearch.DataSource != null)
            {
                dgSearch.Columns[0].Name = "Eshterak";
                dgSearch.Columns[0].DataPropertyName = "Eshterak";
                dgSearch.Columns[0].HeaderText = "اشتراک";
                //------
                dgSearch.Columns[1].Name = "Name";
                dgSearch.Columns[1].DataPropertyName = "Name";
                dgSearch.Columns[1].HeaderText = "نام";
                //------
                dgSearch.Columns[2].Name = "DateService";
                dgSearch.Columns[2].DataPropertyName = "DateService";
                dgSearch.Columns[2].HeaderText = "تاریخ سرویس";
                dgSearch.Columns[2].DefaultCellStyle.Format = "0000/00/00";
                //-------
                dgSearch.Columns[3].Name = "Mobile";
                dgSearch.Columns[3].DataPropertyName = "Mobile";
                dgSearch.Columns[3].HeaderText = "شماره تماس";
                //-------
                dgSearch.Columns[4].Name = "Bestankar";
                dgSearch.Columns[4].DataPropertyName = "Bestankar";
                dgSearch.Columns[4].HeaderText = "بیعانه";
                //-------
                dgSearch.Columns[5].Name = "Pardakhti";
                dgSearch.Columns[5].DataPropertyName = "Pardakhti";
                dgSearch.Columns[5].HeaderText = "پرداختی";
                //------
                dgSearch.Columns[6].Name = "Takhfif";
                dgSearch.Columns[6].DataPropertyName = "Takhfif";
                dgSearch.Columns[6].HeaderText = "تخفیف ";
                //-------
                dgSearch.Columns[7].Name = "ValueAdded";
                dgSearch.Columns[7].DataPropertyName = "ValueAdded";
                dgSearch.Columns[7].HeaderText = "ارزش افزوده ";
                //-------

                dgSearch.Columns[8].Name = "SumServices";
                dgSearch.Columns[8].DataPropertyName = "SumServices";
                dgSearch.Columns[8].HeaderText = " مبلغ کل";
                ///------
                dgSearch.Columns[9].Name = "CodeRahgiri";
                dgSearch.Columns[9].DataPropertyName = "CodeRahgiri";
                dgSearch.Columns[9].HeaderText = "کد رهگیری";
                ///------
                dgSearch.Columns[10].Name = "NumberService";
                dgSearch.Columns[10].DataPropertyName = "NumberService";
                dgSearch.Columns[10].HeaderText = "تعداد";
                ///------
                dgSearch.Columns[11].Name = "ReadyDate";
                dgSearch.Columns[11].DataPropertyName = "ReadyDate";
                dgSearch.Columns[11].HeaderText = "تاریخ آماده";
                dgSearch.Columns[11].DefaultCellStyle.Format = "0000/00/00";
                ///------
                dgSearch.Columns[12].Name = "SendReadySms";
                dgSearch.Columns[12].DataPropertyName = "SendReadySms";
                dgSearch.Columns[12].HeaderText = "تعداد پیامک آماده";
                ///------
                dgSearch.Columns[13].Name = "Description";
                dgSearch.Columns[13].DataPropertyName = "Description";
                dgSearch.Columns[13].HeaderText = "توضیحات ";
                ///------
                dgSearch.Columns[14].Name = "IdService";
                dgSearch.Columns[14].DataPropertyName = "IdService";
                dgSearch.Columns[14].HeaderText = "شماره ";
                dgSearch.Columns[14].Visible = false;
                //-------
                dgSearch.Columns[15].Name = "OrderState";
                dgSearch.Columns[15].DataPropertyName = "OrderState";
                dgSearch.Columns[15].HeaderText = "نحوه سفارش";
                //-------
                dgSearch.Columns[16].Name = "TabelState";
                dgSearch.Columns[16].DataPropertyName = "TabelState";
                dgSearch.Columns[16].HeaderText = "میز";
                //-------
                dgSearch.Columns[17].Name = "PayeState";
                dgSearch.Columns[17].DataPropertyName = "PayeState";
                dgSearch.Columns[17].HeaderText = " پرداخت";
            }
        }

        private void Design_GrideView_Report_Service() // tarahi datagride report service
        {
            //DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            //dgSearch.Columns.Add(chk);
            //dgSearch.Columns[0].DefaultCellStyle = chk;
            //chk.HeaderText = "آماده بودن";
            //chk.Name = "Ready";
            //chk.DisplayIndex = 0;
            //dgSearch.Columns[0].Visible = false;
            //dgSearch.Columns[0].HeaderText = "آماده بودن";
            //dgSearch.Columns[0].DefaultCellStyle = data
            dgSearch.Columns[0].Visible = false;
            dgSearch.Columns[1].HeaderText = "اشتراک";
            dgSearch.Columns[2].HeaderText = "تاریخ";
            dgSearch.Columns[2].DefaultCellStyle.Format = "0000/00/00";
            //dgSearch.Columns[3].Visible = false;
            dgSearch.Columns[3].HeaderText = "دسته";
            //dgSearch.Columns[4].Visible = false;
            dgSearch.Columns[4].HeaderText = "محصول";
            //dgSearch.Columns[5].Visible = false;
            dgSearch.Columns[5].HeaderText = "سفارش";
            //dgSearch.Columns[6].Visible = false;
            dgSearch.Columns[6].HeaderText = "تعداد";
            //dgSearch.Columns[7].Visible = false;
            dgSearch.Columns[7].HeaderText = "مبلغ";
            dgSearch.Columns[8].HeaderText = "کد رهگیری";
            dgSearch.Columns[9].Visible = false;
            dgSearch.Columns[9].HeaderText = "تعداد مراجعه";
            dgSearch.Columns[10].Visible = false;
            dgSearch.Columns[10].HeaderText = " شماره";
            //dgSearch.Columns[11].DisplayIndex = 0;
            dgSearch.Columns[11].HeaderText = "ارزش افزوده";

        }
        //********
        //jame kole 1 mahsool
        public double Jame_Kole_Mahsool()
        {
            double sum = 0;
            for (int i = 0; i < dgSearch.RowCount; i++)
            {

                if (dgSearch.Rows[i].Cells[7].Value.ToString() != "0" || dgSearch.Rows[i].Cells[7].Value.ToString() != null)
                    sum = sum + Convert.ToInt64(dgSearch.Rows[i].Cells[7].Value.ToString());
            }
            return sum;
        }
        //********
        //jame kole Karkard
        public double Jame_Kole_Karkard()
        {
            double sum = 0;
            for (int i = 0; i < dgSearch.RowCount; i++)
            {

                if(dgSearch.Rows[i].Cells[8].Value.ToString()!="0" || dgSearch.Rows[i].Cells[8].Value.ToString()!=null)
                sum = sum + Convert.ToInt64(dgSearch.Rows[i].Cells[8].Value.ToString());
            }
            return sum;
        }
        //********
        //jame kole daryafti
        public double Jame_Kole_Daryafti()
        {
            long bestankar = 0, pardakhti = 0, sum = 0, sumPardakhti = 0,sumBestankar=0;

            for (int i = 0; i < dgSearch.RowCount; i++)
            {
                pardakhti = 0; 
                pardakhti = Int64.Parse(dgSearch.Rows[i].Cells[5].Value.ToString());
                sumPardakhti = sumPardakhti + pardakhti;

            }
            //------
            for (int i = 0; i < dgSearch.RowCount; i++)
            {
                bestankar = 0;
                bestankar = Int64.Parse(dgSearch.Rows[i].Cells[4].Value.ToString());
                sumBestankar = sumBestankar + bestankar;

            }
            sum = sumBestankar + sumPardakhti;
            return sum;
        }
        //**********
        //jame kole daryafti
        public double Jame_Kole_Mande()
        {
            long bestankar = 0, takhfif = 0, pardakhti = 0, sumService = 0, sum = 0;

            for (int i = 0; i < dgSearch.RowCount; i++)
            {
                pardakhti = 0; bestankar = 0; takhfif = 0; sumService = 0;
                takhfif = Int64.Parse(dgSearch.Rows[i].Cells[6].Value.ToString());
                bestankar = Int64.Parse(dgSearch.Rows[i].Cells[4].Value.ToString());
                pardakhti = Int64.Parse(dgSearch.Rows[i].Cells[5].Value.ToString());
                sumService = Int64.Parse(dgSearch.Rows[i].Cells[8].Value.ToString());
                sum = sum + (sumService - (pardakhti + bestankar + takhfif));

            }
            return sum;
        }
        //**************
        //jame kole takhfif
        public double Jame_Kole_Takhfif()
        {
            double sum = 0;
            for (int i = 0; i < dgSearch.RowCount; i++)
            {

                if (dgSearch.Rows[i].Cells[6].Value.ToString() != "0" || dgSearch.Rows[i].Cells[6].Value.ToString() != null)
                    sum = sum + Convert.ToInt64(dgSearch.Rows[i].Cells[6].Value.ToString());
            }
            return sum;
        }
        //********
        //joda kardane 3ragham 3ragham
        public string Seragham(string input)
        {
            if (input != string.Empty)
            {
                input = Convert.ToInt64(input.Replace(",", "")).ToString("#,0");

            }
            return input;
        }
        //**************
        private void FormReports_Load(object sender, EventArgs e)
        {
            //------
            using (var context = new StimulsoftEntities())
            {
                if (PanelUser.Visible == true) // amade kardane panel user baraye gozaresh bar asase moshtari
                {
                    var select = context.Service.ToList();
                    string[] eshterak = new string[select.Count];
                    for (int i = 0; i < select.Count; i++)
                    {
                        eshterak[i] = select[i].Eshterak.ToString();
                    }
                    AutoCompleteStringCollection suggestEshterak = new AutoCompleteStringCollection();
                    txtEshterak.AutoCompleteCustomSource = suggestEshterak;
                    suggestEshterak.AddRange(eshterak);
                    //-------
                    string[] phone = new string[select.Count];
                    for (int i = 0; i < select.Count; i++)
                    {
                        phone[i] = select[i].Mobile.ToString();
                    }
                    AutoCompleteStringCollection suggestPhone = new AutoCompleteStringCollection();
                    txtPhone.AutoCompleteCustomSource = suggestPhone;
                    suggestPhone.AddRange(phone);
                }
                if(panelProdoct.Visible==true)// amade kardane panel prodoct baraye gozaresh bar asase mahsool
                {
                    panelProdoct.BringToFront();
                    var category = context.Category.ToList();
                    if (category.Count > 0)
                    {
                        comCategory.DataSource = category;
                        comCategory.DisplayMember = "Name";
                    }
                    //---------
                    var prodoct = context.Prodoct.Where(c => c.NameService == comCategory.Text).ToList();
                    comProdoct.DataSource = prodoct;
                    comProdoct.DisplayMember = "Name";
                    //----------
                    dtStart1.Text = Practical.Today_Date() ;
                    dtEnd1.Text = Practical.Today_Date();
                    //----------
                    label4.Text = "تعداد:";
                    label7.Visible = false;
                    label9.Visible = false;
                    lblTotalMande.Visible = false;
                    lblTotallTakhfif.Visible = false;
                }
            }
            //-----------
            if (PanelDate.Visible == true) // amade kardane panel date baraye gozaresh bar asase zaman
            {
                dtStart.Today_Click(null, null);
                dtEnd.Today_Click(null, null);
            }
            //------


        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            try
            {
                int startDate = int.Parse(dtStart.Text.Replace("/", ""));
                int endDate = int.Parse(dtEnd.Text.Replace("/", ""));
                using (var context = new StimulsoftEntities())
                {
                    var findDate = context.Service.Where(c => c.DateService >= startDate && c.DateService <= endDate).ToList();
                    dgSearch.DataSource = findDate;


                }
                Design_GrideView_Service();
                lblTotalPrice.Text = Jame_Kole_Karkard().ToString();
                lblTotalResive.Text = Jame_Kole_Daryafti().ToString();
                lblTotalMande.Text = Jame_Kole_Mande().ToString();
                lblTotallTakhfif.Text = Jame_Kole_Takhfif().ToString();

            }
            catch (Exception ex)
            {

                MessageBox.Show("بعضی از مقادیر وارد نشده \n" + ex.Message);
            }
        }

        private void btnReportUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEshterak.Text == "")
                    txtEshterak.Focus();
                using (var context = new StimulsoftEntities())
                {
                    var find = context.Service.Where(c => c.Eshterak == txtEshterak.Text).ToList();

                    dgSearch.DataSource = find;
                    
                }
                Design_GrideView_Service();
                lblTotalPrice.Text = Jame_Kole_Karkard().ToString();
                lblTotalResive.Text = Jame_Kole_Daryafti().ToString();
                lblTotalMande.Text = Jame_Kole_Mande().ToString();
                lblTotallTakhfif.Text = Jame_Kole_Takhfif().ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show("بعضی از مقادیر وارد نشده \n" + ex.Message);
            }
        }

        private void txtEshterak_TextChanged(object sender, EventArgs e)
        {
            try
            {

                using (var context = new StimulsoftEntities())
                {
                    var find = context.Service.Where(c => c.Eshterak == txtEshterak.Text).ToList();
                    
                    dgSearch.DataSource = find;
                }
                Design_GrideView_Service();
                

                string []ret = Calculate.Remaining_Total(txtEshterak.Text).Split(',');
                lblTotalMande.Text = ret[0];
                lblBestankar.Text = ret[1];
                lblTotalPrice.Text = ret[2];
                lblTotalResive.Text = ret[3];

                lblTotallTakhfif.Text = ret[4];
            }
            catch (Exception ex)
            {

                MessageBox.Show("بعضی از مقادیر وارد نشده \n" + ex.Message);
            }
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            try
            {
                
                using (var context = new StimulsoftEntities())
                {
                    var user = context.Service.Where(c => c.Mobile == txtPhone.Text).ToList();
                    dgSearch.DataSource = user;
                }
                Design_GrideView_Service();
                lblTotalPrice.Text = Jame_Kole_Karkard().ToString();
                lblTotalResive.Text = Jame_Kole_Daryafti().ToString();
                lblTotalMande.Text = Jame_Kole_Mande().ToString();
                lblTotallTakhfif.Text = Jame_Kole_Takhfif().ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show("بعضی از مقادیر وارد نشده \n" + ex.Message);
            }
        }
        private void dgSearch_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //string select = dgSearch.CurrentRow.Cells[9].Value.ToString();
                FormEditSmallReport frmReportServices = new FormEditSmallReport();
                frmReportServices.label1.Text = dgSearch.CurrentRow.Cells[9].Value.ToString();
                frmReportServices.label2.Text = "report"; // baraye inke baraye report sakhte shavad
                //Design_GrideView_Service();
                frmReportServices.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show("سفارش انتخاب شده کد رهگیری ندارد \n " + ex.Message);
            }
        }

        private void lblTotalPrice_TextChanged(object sender, EventArgs e)
        {
            lblTotalPrice.Text = Seragham(lblTotalPrice.Text);
            //lblTotalPrice.Select(lblTotalPrice., 0);
        }

        private void lblTotalResive_TextChanged(object sender, EventArgs e)
        {
            lblTotalResive.Text = Seragham(lblTotalResive.Text);

        }

        private void lblTotalMande_TextChanged(object sender, EventArgs e)
        {
            lblTotalMande.Text = Seragham(lblTotalMande.Text);

        }

        private void lblTotallTakhfif_TextChanged(object sender, EventArgs e)
        {
            lblTotallTakhfif.Text = Seragham(lblTotallTakhfif.Text);
        }

        private void btnPdfExport_Click(object sender, EventArgs e)
        {
            if (panelProdoct.Visible == true)
            {
                Report.Load(Application.StartupPath + "\\RptReportService.mrt");
                Report.RegBusinessObject("rptReportService", dgSearch.DataSource);
                Report.Render(false);

                _save = new SaveFileDialog();
                _save.Filter = "PDF File (.pdf)|*.pdf";
                if (_save.ShowDialog() == DialogResult.OK)
                    Report.ExportDocument(StiExportFormat.Pdf, _save.FileName);
            }
            else
            {
                Report.Load(Application.StartupPath + "\\RptExportService.mrt");
                Report.RegBusinessObject("rptService", dgSearch.DataSource);
                Report.Render(false);

                _save = new SaveFileDialog();
                _save.Filter = "PDF File (.pdf)|*.pdf";
                if (_save.ShowDialog() == DialogResult.OK)
                    Report.ExportDocument(StiExportFormat.Pdf, _save.FileName);
            }
        }

        private void btnWordExport_Click(object sender, EventArgs e)
        {
            if (panelProdoct.Visible == true)
            {
                Report.Load(Application.StartupPath + "\\RptReportService.mrt");
                Report.RegBusinessObject("rptReportService", dgSearch.DataSource);
                Report.Render(false);
                _save = new SaveFileDialog();
                _save.Filter = "Word File (.docx)|*.docx";
                if (_save.ShowDialog() == DialogResult.OK)
                    Report.ExportDocument(StiExportFormat.Word2007, _save.FileName);
            }
            else
            {
                Report.Load(Application.StartupPath + "\\RptExportService.mrt");
                Report.RegBusinessObject("rptService", dgSearch.DataSource);
                Report.Render(false);
                _save = new SaveFileDialog();
                _save.Filter = "Word File (.docx)|*.docx";
                if (_save.ShowDialog() == DialogResult.OK)
                    Report.ExportDocument(StiExportFormat.Word2007, _save.FileName);
            }
        }

        private void btnExcelExport_Click(object sender, EventArgs e)
        {
            if (panelProdoct.Visible == true)
            {
                Report.Load(Application.StartupPath + "\\RptReportService.mrt");
                Report.RegBusinessObject("rptReportService", dgSearch.DataSource);
                Report.Render(false);
                _save = new SaveFileDialog();
                _save.Filter = "Excel File (.xlsx)|*.xlsx";
                if (_save.ShowDialog() == DialogResult.OK)
                    Report.ExportDocument(StiExportFormat.Excel2007, _save.FileName);
            }
            else
            {
                Report.Load(Application.StartupPath + "\\RptExportService.mrt");
                Report.RegBusinessObject("rptService", dgSearch.DataSource);
                Report.Render(false);
                _save = new SaveFileDialog();
                _save.Filter = "Excel File (.xlsx)|*.xlsx";
                if (_save.ShowDialog() == DialogResult.OK)
                    Report.ExportDocument(StiExportFormat.Excel2007, _save.FileName);
            }
        }

        private void txtEshterak_KeyPress(object sender, KeyPressEventArgs e)
        {
            Enter_Number(sender, e);
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            Enter_Number(sender, e);
        }

        private void btnReportProdoct_Click(object sender, EventArgs e)
        {
            try
            {
                dgSearch.DataSource = null;
                using (var context = new StimulsoftEntities())
                {
                    int startDate = int.Parse(dtStart1.Text.Replace("/", ""));
                    int endDate = int.Parse(dtEnd1.Text.Replace("/", ""));

                        var findProdoct = context.ReportService.Where(c => c.Date >= startDate && c.Date <= endDate).ToList();
                        //dgSearch.DataSource = findDate;

                     findProdoct = findProdoct.Where(c => c.Kind == comCategory.Text && c.Kala == comProdoct.Text).ToList();
                    dgSearch.DataSource = findProdoct;

                    lblTotalResive.Text = findProdoct.Count.ToString();

                }
                Design_GrideView_Report_Service();
               
                lblTotalPrice.Text = Jame_Kole_Mahsool().ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show("بعضی از مقادیر وارد نشده \n" + ex.Message);
            }
        }

        private void comCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (var context = new StimulsoftEntities())
                {
                    var prodoct = context.Prodoct.Where(c => c.NameService == comCategory.Text).ToList();
                    comProdoct.DataSource = prodoct;
                    comProdoct.DisplayMember = "Name";
                }
            }
            catch (Exception)
            {


            }
        }
    }
}
