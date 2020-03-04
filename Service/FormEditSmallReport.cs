using Stimulsoft.Report;
using Stimulsoft.Report.Components;
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
    public partial class FormEditSmallReport : Form
    {
        public FormEditSmallReport()
        {
            InitializeComponent();
        }
        private void Design_GrideView_Report_Service()
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
        private void Design_GrideView_Edit_Report_Service()
        {
            kitchenEntities context = new kitchenEntities();
            dgSearch.DataSource = null;
            dgSearch.Rows.Clear();
            dgSearch.Columns.Clear();
            var user = context.ReportService.Where(c => c.CodeRahgiri == label1.Text).ToList();
            dgSearch.DataSource = user;
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

            var btnDeleteRow = new DataGridViewButtonColumn();
            btnDeleteRow.Name = "btnDeleteRow";
            btnDeleteRow.Text = "حذف";
            btnDeleteRow.UseColumnTextForButtonValue = true;
            btnDeleteRow.HeaderText = "";
            btnDeleteRow.Width = 75;
            this.dgSearch.Columns.Add(btnDeleteRow);



        }
        private void FormEditSmallReport_Load(object sender, EventArgs e)
        {
            try
            {
                using (var context = new kitchenEntities())
                {

                    var user = context.ReportService.Where(c => c.CodeRahgiri == label1.Text).ToList();

                    dgSearch.DataSource = user;
                    if (label2.Text == "edit")
                        Design_GrideView_Edit_Report_Service();
                    if (label2.Text == "report")
                        Design_GrideView_Report_Service();

                    for (int i = 0; i < user.Count; i++)
                    {
                        if (dgSearch.Rows[i].Cells[0].Value == null)
                            dgSearch.Rows[i].Cells[12].Value = true;
                        else if (dgSearch.Rows[i].Cells[0].Value.ToString() == "0")
                            dgSearch.Rows[i].Cells[12].Value = true;
                        else if (dgSearch.Rows[i].Cells[0].Value.ToString() == "1")
                            dgSearch.Rows[i].Cells[12].Value = false;


                    }

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("سفارش انتخاب شده کد رهگیری ندارد.ریزگزارش \n " + ex.Message);
            }
        }

        private void dgSearch_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
                if (e.ColumnIndex == 13)
                {
                    int selectId = int.Parse(dgSearch.CurrentRow.Cells[10].Value.ToString());
                    using (var context = new kitchenEntities())
                    {
                        var del = context.ReportService.Where(c => c.Id == selectId).FirstOrDefault();
                        context.ReportService.Remove(del);
                        context.SaveChanges();
                        var user = context.ReportService.Where(c => c.CodeRahgiri == label1.Text).ToList();

                        dgSearch.DataSource = user;
                        Design_GrideView_Report_Service();
                        //-----mohasebe mojadade hazine service bad az hazfe 1 khedmat
                        var editPrice = context.Service.Where(c => c.CodeRahgiri == label1.Text).FirstOrDefault();
                        long sum = 0;
                        long valueAdded = 0;

                        if (dgSearch.RowCount > 0)
                        {
                            for (int i = 0; i < dgSearch.RowCount; i++)
                            {
                                sum = sum + long.Parse(dgSearch.Rows[i].Cells[7].Value.ToString());
                                valueAdded = valueAdded + long.Parse(dgSearch.Rows[i].Cells[11].Value.ToString());
                            }
                            editPrice.SumServices = sum;
                            editPrice.ValueAdded = valueAdded;
                            context.SaveChanges();
                            return;
                        }
                        if (dgSearch.RowCount == 0)//hame khedmatha hazf shavad in khedmat az list serviceha hazf shsvad
                        {
                            context.Service.Remove(editPrice);
                            context.SaveChanges();
                        }
                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("عوض کردن وضعیت آماده ویرایش" + "\n" + ex.Message);
            }
        }

        private void toolPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgSearch.Rows.Count == 0)
                {
                    MessageBox.Show("هیچ خدمتی ثبت نشده");
                    return;
                }
                string nameshop;
                using (var context = new kitchenEntities())
                {
                    var Name = context.Setting.Where(current => current.CommercialName != null).FirstOrDefault();
                    nameshop = Name.CommercialName;
                    string eshterak = dgSearch.CurrentRow.Cells[1].Value.ToString();
                    var selectUser = context.Service.Where(c => c.Eshterak == eshterak).FirstOrDefault();
                    List<servrvice> list = new List<servrvice>();
                    for (int i = 0; i < dgSearch.Rows.Count; i++)
                    {
                        servrvice serv = new servrvice
                        {

                            Name = selectUser.Name,
                            DateService = selectUser.DateService.ToString(),
                            Eshterak = selectUser.Eshterak,
                            NumberService = selectUser.NumberService,
                            Rahgiri = selectUser.CodeRahgiri,
                            khedmat = dgSearch.Rows[i].Cells[4].Value.ToString(),
                            Some = dgSearch.Rows[i].Cells[6].Value.ToString(),
                            Price = dgSearch.Rows[i].Cells[7].Value.ToString(),

                            //-----
                            SumPrice = selectUser.SumServices.ToString(),
                            //serv = dgShow.Rows[i].Cells[2].Value.ToString(),

                        };

                        list.Add(serv);
                    }
                    StiReport report = new StiReport();
                    report.Load(Application.StartupPath + "\\RptService.mrt");

                    report.RegBusinessObject("Service", list);

                    (report.GetComponentByName("DataService_Name") as StiText).Enabled = dgSearch.Enabled;
                    (report.GetComponentByName("DataService_Eshterak") as StiText).Enabled = dgSearch.Enabled;
                    (report.GetComponentByName("DataService_DateService") as StiText).Text = dgSearch.CurrentRow.Cells[2].Value.ToString();

                    (report.GetComponentByName("DataService_Some") as StiText).Enabled = dgSearch.Enabled;
                    (report.GetComponentByName("DataService_Price") as StiText).Enabled = dgSearch.Enabled;
                    (report.GetComponentByName("DataService_khedmat") as StiText).Enabled = dgSearch.Enabled;

                    (report.GetComponentByName("Text7") as StiText).Text = nameshop;
                    (report.GetComponentByName("Text10") as StiText).Text = selectUser.Takhfif.ToString();
                    string sumPay = (selectUser.SumServices - (selectUser.Takhfif + selectUser.Bestankar)).ToString();
                    (report.GetComponentByName("Text12") as StiText).Text = sumPay;
                    (report.GetComponentByName("Text14") as StiText).Text = selectUser.Bestankar.ToString();
                    (report.GetComponentByName("DataService_SumPrice") as StiText).Text = selectUser.SumServices.ToString();
                    (report.GetComponentByName("txtTime") as StiText).Text = DateTime.Now.ToShortTimeString();
                    (report.GetComponentByName("dataValueAdded") as StiText).Text = "-";

                    //------ select printer
                    var selectPrinter = context.Device.FirstOrDefault();
                    if (selectPrinter != null)
                    {
                        report.PrinterSettings.PrinterName = selectPrinter.Printer1;
                        report.Print(false);
                        report.Show();
                        //------------------
                        //report.Load(Application.StartupPath + "\\RptService.mrt");

                        //report.PrinterSettings.PrinterName = selectPrinter.Printer2;
                        //report.Print();
                    }

                    //-------------

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //lblError.ForeColor = Color.Red;
                //lblError.Text = "کاربری بااین شماره اشتراک وجود ندارد,خطا";
                //txtEshterak.Focus();
            }
        }
        private class servrvice
        {


            public string Name { get; set; }
            public string DateService { get; set; }
            public string Eshterak { get; set; }
            public string NumberService { get; set; }
            public string SumPrice { get; set; }
            public string khedmat { get; set; }
            public string Some { get; set; }
            public string Price { get; set; }
            public string Rahgiri { get; set; }
            public string serv { get; set; }


        }
    }
}
