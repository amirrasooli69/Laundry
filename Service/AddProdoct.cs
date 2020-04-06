using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PapilooDate
{
    public partial class AddProdoct : UserControl
    {
        public AddProdoct()
        {
            InitializeComponent();
        }

        private void txtCodeProdoct_Enter(object sender, EventArgs e)
        {
            txtCodeProdoct.Text = "";

        }

        private void txtCodeProdoct_TabIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtNameProdoct_Enter(object sender, EventArgs e)
        {
            txtNameProdoct.Text = "";
        }

        private void txtNameProdoct_TabIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddNew_Click(object sender, EventArgs e)
        {
            AddProdoct pro = new AddProdoct();
            pro.Location = new Point(10, 240);
        }

        private void txtCodeProdoct_Leave(object sender, EventArgs e)
        {
            if (txtCodeProdoct.Text == "")
            {
                txtCodeProdoct.Text = "کد کالا";
            }
        }

        private void txtNameProdoct_Leave(object sender, EventArgs e)
        {
            if (txtNameProdoct.Text == "")
            {
                txtNameProdoct.Text = "نام کالا";
            }
        }
        public string[] prodoct()
        {
                string []prodoct1= {txtCodeProdoct.Text , txtNameProdoct.Text , txtStoreProdoct.Text ,
            txtSomeProdoct.Text , txtPriceProdoct.Text , txtDetailProdoct.Text , dateExpired.Text };
            return prodoct1;
        }
        private void btnSaveProdoct_Click(object sender, EventArgs e)
        {
           string [] pro= prodoct();
            DataGridView dgAnbar = new DataGridView();
            
            dgAnbar.Rows.Add(pro[0], pro[1],pro[2],pro[3],pro[4],pro[5],pro[6]);
            
        }
    }
}
