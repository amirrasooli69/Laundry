using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laundry
{
    public partial class FormNotification : Form
    {
        public FormNotification()
        {
            InitializeComponent();
        }
        public int show; // show=1 yani az ba sms por shode; show=2 yani ba tavalod por shode;
        private void FormNotification_Load(object sender, EventArgs e)
        {
            
        }

        private void dgShow_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (show == 1)
            {
                FormSms frmSms = new FormSms();
                frmSms.txtMobilesNumbers.Text = dgShow.CurrentRow.Cells[4].Value.ToString();
                frmSms.Show();


            }
            if (show == 2)
            {
                FormSms frmSms = new FormSms();
                frmSms.txtMobilesNumbers.Text = dgShow.CurrentRow.Cells[3].Value.ToString();
                frmSms.Show();
            }
        }
    }
}
