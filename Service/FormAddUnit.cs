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
    public partial class FormAddUnit : Form
    {
        public FormAddUnit()
        {
            InitializeComponent();
        }

        private void toolExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using(var context=new StimulsoftEntities())
            {
                if(context.Unit.Count()>0)
                {
                    bool existUnit = context.Unit.Where(c => c.Name == txtUnitName.Text).Any();
                    if(existUnit)
                    {
                        MessageBox.Show("این واحد وجود دارد", "واحد", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        Unit newUnit = new Unit();
                        newUnit.Name = txtUnitName.Text;
                        context.Unit.Add(newUnit);
                        context.SaveChanges();
                        MessageBox.Show("واحد ثبت شد", "ثبت", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtUnitName.Text = "";
                        txtUnitName.Focus();

                    }

                }
                else
                {
                    Unit newUnit = new Unit();
                    newUnit.Name = txtUnitName.Text;
                    context.Unit.Add(newUnit);
                    context.SaveChanges();
                    MessageBox.Show("واحد ثبت شد", "ثبت", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtUnitName.Text = "";
                    txtUnitName.Focus();
                }

            }
        }

        private void FormAddUnit_Load(object sender, EventArgs e)
        {
            
        }
    }
}
