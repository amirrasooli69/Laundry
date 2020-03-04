using System;
using System.Windows.Forms;
using System.Net.NetworkInformation;

namespace Laundry
{
    public partial class FormAbout : Form
    {
        public FormAbout()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Ping ping = new Ping();
                PingReply pingStatus = ping.Send("papiloo.ir");
                if (pingStatus.Status == IPStatus.Success)
                {
                    System.Diagnostics.Process.Start(linkLabel1.Text);
                }
                else
                {
                    MessageBox.Show("اینترنت قطع است", "ارتباط", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("به اینترنت متصل نیستید", "ارتباط", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void FormAbout_Load(object sender, EventArgs e)
        {

        }

        private void picInsta_Click(object sender, EventArgs e)
        {
            try
            {
                Ping ping = new Ping();
                PingReply pingStatus = ping.Send("papiloo.ir");
                if (pingStatus.Status == IPStatus.Success)
                {
                    System.Diagnostics.Process.Start("https://www.instagram.com/papiloosoft/");
                }
                else
                {
                    MessageBox.Show("اینترنت قطع است", "ارتباط", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("به اینترنت متصل نیستید", "ارتباط", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
        }

    }
}
