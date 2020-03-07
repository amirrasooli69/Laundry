using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using PopupControl;
namespace PapilooDate
{
    public partial class FDate : UserControl
    {
        PersianCalendar pc = new PersianCalendar();
        int selectedYear, selectdMonth, selectedDay;
        DateTime selectedMiladiDate;
        Popup popup;
        public FDate()

        {
            InitializeComponent();

        }
        public string Text
        {
            get
            {
                return S_Date.Text;
            }
            set
            {
                S_Date.Text = value;
            }
        }
        private void popup_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            S_Date.Text = PCalander.Pc_Date;
        }

        private void S_Date_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && e.KeyChar !=3 && e.KeyChar!=22) // kodjaye ascii 8 = / , 3 = ctrl + c , 22 = ctrl + V
            {
                if (e.KeyChar < 48 || e.KeyChar > 57)
                {
                    e.Handled = true;
                }
                else
                {
                    switch (S_Date.TextLength)
                    {
                        case 4:
                            {
                                S_Date.Text += "/";
                                S_Date.SelectionStart = S_Date.Text.Length + 1;
                                break;
                            }
                        case 7:
                            {
                                S_Date.Text += "/";

                                S_Date.SelectionStart = S_Date.Text.Length + 1;
                                break;
                            }
                    }


                }
            }

        }

        private void S_Date_Leave(object sender, EventArgs e)
        {
            try
            {

                    if(S_Date.TextLength !=10 && S_Date.TextLength !=0)
                        {

                            selectedDay = int.Parse(S_Date.Text.Substring(8, 2));
                            selectdMonth = int.Parse(S_Date.Text.Substring(5, 2));
                            selectedYear = int.Parse(S_Date.Text.Substring(0, 4));
                            selectedMiladiDate = pc.ToDateTime(selectedYear, selectdMonth, selectedDay, 0, 0, 0, 0);
                            
                        }
                
            }
            catch
            {
                MessageBox.Show("تاریخ وارد شده اشتباه می باشد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                S_Date.Text = "";

            }
        }

        private void T_Date_Click(object sender, EventArgs e)
        {
            PCalander frm = new PCalander();
            popup = new Popup(frm);
            popup.Closed += popup_Closed;
            popup.Show(this);
        }
        private void S_Date_TextChanged(object sender, EventArgs e)
        {
            try
            {
                switch (S_Date.TextLength)
                {
                    case 10:
                        {
                            selectedDay = int.Parse(S_Date.Text.Substring(8, 2));
                            selectdMonth = int.Parse(S_Date.Text.Substring(5, 2));
                            selectedYear = int.Parse(S_Date.Text.Substring(0, 4));
                            selectedMiladiDate = pc.ToDateTime(selectedYear, selectdMonth, selectedDay, 0, 0, 0, 0);
                            break;
                        }
                }
            }
            catch
            {
                MessageBox.Show("تاریخ وارد شده اشتباه می باشد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                S_Date.Text = "";
            }
        }


    }
}

