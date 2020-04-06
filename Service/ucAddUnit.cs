using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
namespace Papiloo
{
    public partial class ucAddUnit : UserControl
    {
        public ucAddUnit()
        {
            InitializeComponent();
        }
        private void Add_Unit()
        {
            using (var context = new Service.StimulsoftEntities())
            {
                if (context.Unit.Count() > 0)
                {
                    bool existUnit = context.Unit.Where(c => c.Name == txtUnitName.Text).Any();
                    if (existUnit)
                    {
                        MessageBox.Show("واحدی با این نام وجود دارد", "واحد", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        Service.Unit newUnit = new Service.Unit();
                        newUnit.Name = txtUnitName.Text;
                        context.Unit.Add(newUnit);
                        context.SaveChanges();
                        //MessageBox.Show("واحد ثبت شد", "ثبت", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtUnitName.Text = "";
                        txtUnitName.Focus();

                    }
                }
                else
                {
                    Service.Unit newUnit = new Service.Unit();
                    newUnit.Name = txtUnitName.Text;
                    context.Unit.Add(newUnit);
                    context.SaveChanges();
                    //MessageBox.Show("واحد ثبت شد", "ثبت", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtUnitName.Text = "";
                    txtUnitName.Focus();
                }
            }
            ucAddProdoctStore ucadd = new ucAddProdoctStore();
            ucadd.Refresh_comUnit();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Add_Unit();
        }

        private void btnSave_KeyPress(object sender, KeyPressEventArgs e)
        {
            Add_Unit();
        }
    }
}
