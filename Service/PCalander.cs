using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PopupControl;
namespace Papiloo
{
    public partial class PCalander : UserControl
    {
        public bool dontClose=true;
        PersianCalendar pc = new PersianCalendar();
        HijriCalendar hc = new HijriCalendar();
        shamsiCalander objshamsiCalander = new shamsiCalander();
        private DateTime NowDate = DateTime.Now;
        static int mounthName;
        static int YearName;
        int selectedYear, selectdMonth, selectedDay;
        int rowIndex, columnIndex;
        string selectedShamsiDate;
        DateTime selectedMiladiDate;
        public string T_Date
        {
            get
            {
                return lblShamsi.Text;
            }
            set
            {
                lblShamsi.Text = value;
            }
        }

        public PCalander()
        {
            InitializeComponent();
            mounthName = pc.GetMonth(NowDate);
            YearName = pc.GetYear(NowDate);
            lblToday.Text = "امروز" + ":" + MiladiToShamsi(DateTime.Now);
        }
        public static string Pc_Date;
        private void frmCalander_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                dgCalander.Rows.Add();
            }

            FillCalander();
            FindCurrentDate();
            getDates();
        }
        public string MiladiToShamsi(DateTime Mdate)
        {
            string Result = pc.GetYear(Mdate).ToString();
            string Month = Convert.ToString(pc.GetMonth(Mdate));
            string day = Convert.ToString(pc.GetDayOfMonth(Mdate));
            if (Month.Length == 1)
                Month = "0" + Month;
            if (day.Length == 1)
                day = "0" + day;
            Result += "/" + Month + "/" + day;
            return Result;
        }
        public string MiladiTohejri(DateTime Hdate)
        {
            string Result = hc.GetYear(Hdate).ToString();
            string Month = Convert.ToString(hc.GetMonth(Hdate));
            string day = Convert.ToString(hc.GetDayOfMonth(Hdate));
            if (Month.Length == 1)
                Month = "0" + Month;
            if (day.Length == 1)
                day = "0" + day;
            Result += "/" + Month + "/" + day;
            return Result;
        }
        private void FillCalander()
        {
            columnIndex = dgCalander.CurrentCell.ColumnIndex;
            rowIndex = dgCalander.CurrentCell.RowIndex;
            int DayOfWeekNameInMonth = 0;
            int daysInMonth = pc.GetDaysInMonth(YearName, mounthName);
            for (int i = 1, d = 1, j = 0; i <= 5; i++, j++)
            {
                if (d == daysInMonth)
                {
                    break;
                }
                for (int x = 1; x <= 7; x++, d++)
                {
                    DateTime dtt = pc.ToDateTime(YearName, mounthName, d, 1, 1, 1, 1, 1);
                    #region MyRegion
                    switch (pc.GetDayOfWeek(dtt))
                    {
                        case DayOfWeek.Saturday: DayOfWeekNameInMonth = 0;
                            break;
                        case DayOfWeek.Sunday: DayOfWeekNameInMonth = 1;
                            break;
                        case DayOfWeek.Monday: DayOfWeekNameInMonth = 2;
                            break;
                        case DayOfWeek.Tuesday: DayOfWeekNameInMonth = 3;
                            break;
                        case DayOfWeek.Wednesday: DayOfWeekNameInMonth = 4;
                            break;
                        case DayOfWeek.Thursday: DayOfWeekNameInMonth = 5;
                            break;
                        case DayOfWeek.Friday: DayOfWeekNameInMonth = 6;
                            break;
                    }
                    #endregion
                    dgCalander.Rows[j].Cells["c" + DayOfWeekNameInMonth.ToString()].Value = pc.GetDayOfMonth(dtt);
                    if (DayOfWeekNameInMonth == 6)
                    {
                        dgCalander.Rows[j].Cells["c" + DayOfWeekNameInMonth.ToString()].Style.ForeColor = Color.Red;
                    }
                    if (DayOfWeekNameInMonth == 6)
                    {
                        d++;
                        break;

                    }
                    if (d == daysInMonth)
                    {
                        break;
                    }
                }
            }
            int lastRowData = 0;
            if (dgCalander.Rows[4].Cells["c6"].Value != null)
            {
                if (!string.IsNullOrEmpty(dgCalander.Rows[4].Cells["c6"].Value.ToString()))
                {
                    lastRowData = int.Parse(dgCalander.Rows[4].Cells["c6"].Value.ToString());
                }
            }
            if (lastRowData != 31 && lastRowData != 0)
            {
                if (daysInMonth >= 29 && lastRowData >= 29)
                {
                    int RemainDay = daysInMonth - lastRowData;
                    for (int i = 0; i < RemainDay; i++)
                    {
                        dgCalander.Rows[0].Cells["c" + i.ToString()].Value = ++lastRowData;
                    }
                }

            }
            FindCurrentCell();
        }
        private void btnNextM_Click(object sender, EventArgs e)
        {
            if (mounthName >= 12)
            {
                mounthName = 0;
                NextYear();
            }
            mounthName++;
            lblMounth.Text = getMounth(mounthName);
            ResetCalender();
            FillCalander();
            FindCurrentCell();
        }
        private void btnPrevM_Click(object sender, EventArgs e)
        {
            if (mounthName <= 1)
            {
                mounthName = 13;
                PrevYear();
            }
            mounthName--;
            lblMounth.Text = getMounth(mounthName);
            ResetCalender();
            FillCalander();
            FindCurrentCell();
        }
        private void btnNextY_Click(object sender, EventArgs e)
        {
            NextYear();
            ResetCalender();
            FillCalander();
            FindCurrentCell();
        }
        private void btnPrevY_Click(object sender, EventArgs e)
        {
            PrevYear();
            ResetCalender();
            FillCalander();
            FindCurrentCell();
        }
        private void ResetCalender()
        {
            for (int i = 0; i <= 4; i++)
            {
                for (int x = 0; x < 7; x++)
                {
                    dgCalander.Rows[i].Cells["c" + x.ToString()].Value = "";
                }
            }
        }
        private void NextYear()
        {
            YearName++;
            lblYear.Text = YearName.ToString();
        }
        private void PrevYear()
        {
            YearName--;
            lblYear.Text = YearName.ToString();
        }
        
        public string GetSelectDate()
        {
            return this.T_Date;
        }
        private void getDates()
        {
            lblShamsi.Text = MiladiToShamsi(DateTime.Now);
            lblMiladi.Text = DateTime.Now.Year.ToString() + "/" +
                            (DateTime.Now.Month.ToString().Length == 1 ? "0" + DateTime.Now.Month.ToString() : DateTime.Now.Month.ToString()) + "/" +
                            (DateTime.Now.Day.ToString().Length == 1 ? "0" + DateTime.Now.Day.ToString() : DateTime.Now.Day.ToString());
            lblhejri.Text = MiladiTohejri(DateTime.Now);
        }
        private void FindCurrentDate()
        {
            int tYear, tMonth, tDay = 0;
            tYear = pc.GetYear(DateTime.Now);
            tMonth = pc.GetMonth(DateTime.Now);
            tDay = pc.GetDayOfMonth(DateTime.Now);
            mounthName = tMonth;
            YearName = tYear;
            lblYear.Text = tYear.ToString();
            lblMounth.Text = getMounth(tMonth);
            ResetCalender();
            FillCalander();
            for (int i = 0; i <= 4; i++)
            {
                for (int x = 0; x < 7; x++)
                {
                    if (dgCalander.Rows[i].Cells["c" + x.ToString()].Value.ToString() == tDay.ToString())
                    {
                        dgCalander.ClearSelection();
                        dgCalander.Rows[i].Cells["c" + x.ToString()].Selected = true;
                    }
                }
            }
        }
        public shamsiCalander getshamsiCalander()
        {
            return objshamsiCalander;
        }
        #region GetMounth
        private string getMounth(int Mounth)
        {
            string MounthName = string.Empty;
            switch (Mounth)
            {
                case 1: MounthName = "فروردین";
                    break;
                case 2: MounthName = "اردیبهشت";
                    break;
                case 3: MounthName = "خرداد";
                    break;
                case 4: MounthName = "تیر";
                    break;
                case 5: MounthName = "مرداد";
                    break;
                case 6: MounthName = "شهریور";
                    break;
                case 7: MounthName = "مهر";
                    break;
                case 8: MounthName = "آبان";
                    break;
                case 9: MounthName = "آذر";
                    break;
                case 10: MounthName = "دی";
                    break;
                case 11: MounthName = "بهمن";
                    break;
                case 12: MounthName = "اسفند";
                    break;
            }
            return MounthName;
        }
        #endregion
        private void dgCalander_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!string.IsNullOrEmpty(dgCalander.CurrentCell.Value.ToString()))
            {
                objshamsiCalander.MiladiDate = selectedMiladiDate;
                objshamsiCalander.ShamsiDate = selectedShamsiDate;
                objshamsiCalander.HejriDate = MiladiTohejri(selectedMiladiDate);
            }
            else
            {
                objshamsiCalander.MiladiDate = DateTime.Now;
                objshamsiCalander.ShamsiDate = MiladiToShamsi(DateTime.Now);
                objshamsiCalander.HejriDate = MiladiTohejri(DateTime.Now);
            }
            if (dontClose == true)
            {
                (Parent as Popup).Close();
            }
        }

        private void dgCalander_Click(object sender, EventArgs e)
        {
            this.T_Date = lblShamsi.Text;
            GetSelectDate();
        }

        private void PCalander_Click(object sender, EventArgs e)
        {

        }

        private void FindCurrentCell()
        {
            if (dgCalander.CurrentCell.Value != null)
            {
                try
                {
                    if (!string.IsNullOrEmpty(dgCalander.CurrentCell.Value.ToString()))
                    {
                        this.Text = null;
                        selectedDay = int.Parse(dgCalander.CurrentCell.Value.ToString());
                        selectdMonth = mounthName;
                        selectedYear = YearName;
                        selectedShamsiDate = selectedYear.ToString() + "/" +
                            (selectdMonth.ToString().Length == 1 ? "0" + selectdMonth.ToString() : selectdMonth.ToString()) + "/" +
                            (selectedDay.ToString().Length == 1 ? "0" + selectedDay.ToString() : selectedDay.ToString());
                        selectedMiladiDate = pc.ToDateTime(selectedYear, selectdMonth, selectedDay, 0, 0, 0, 0);
                        lblShamsi.Text = selectedShamsiDate;
                        lblMiladi.Text = selectedMiladiDate.Year.ToString() + "/" +
                            (selectedMiladiDate.Month.ToString().Length == 1 ? "0" + selectedMiladiDate.Month.ToString() : selectedMiladiDate.Month.ToString()) + "/" +
                            (selectedMiladiDate.Day.ToString().Length == 1 ? "0" + selectedMiladiDate.Day.ToString() : selectedMiladiDate.Day.ToString());
                        lblhejri.Text = MiladiTohejri(selectedMiladiDate);
                        Pc_Date = selectedShamsiDate;
                    }
                    else
                    {
                        selectedDay = 0;
                        selectdMonth = 0;
                        selectedYear = 0;
                        lblShamsi.Text = null;
                        lblMiladi.Text = null;
                        lblhejri.Text = null;
                        selectedShamsiDate = null;
                        selectedMiladiDate = new DateTime();
                    }
                }
                catch (Exception)
                {
                    return;
                }
            }
        }
        private void dgCalander_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            FindCurrentCell();
        }
        private void lblToday_Click(object sender, EventArgs e)
        {
            FindCurrentDate();
            getDates();
        }

    }

       public class shamsiCalander
    {
        public string ShamsiDate { get; set; }
        public string HejriDate { get; set; }
        public DateTime MiladiDate { get; set; }
    }
  }
