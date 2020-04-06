using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PopupControl;
using Service;

namespace Papiloo
{
    public partial class ucButton : UserControl
    {
        public ucButton()
        {
            InitializeComponent();
        }
        public string show = "";
        public string id, name, code, detail, unit, barcode, rfid;
        Popup pop;
        Service.StimulsoftEntities context = new Service.StimulsoftEntities();
        
        
        public static string[] getdNewDetail;

        private void btn_Click(object sender, EventArgs e)
        {
            switch (show)
            {
                case "store":
                    {
                        ucAddProdoctStore addStore = new ucAddProdoctStore();
                        addStore.panelProdoct.Visible = false;
                        addStore.panelStore.Visible = true;
                        addStore.panelStore.Dock = DockStyle.Fill;
                        addStore.Size = new System.Drawing.Size(280, 200);
                        pop = new Popup(addStore);
                        pop.Closed += popup_Closed;
                        pop.Show(this);
                        break;
                    }
                case "prodoct":
                    {
                        ucAddProdoctStore addProdoct = new ucAddProdoctStore();
                        addProdoct.panelProdoct.Visible = true;
                        addProdoct.panelStore.Visible = false;
                        addProdoct.panelProdoct.Dock = DockStyle.Fill;
                        addProdoct.Size = new System.Drawing.Size(280, 210);
                        pop = new Popup(addProdoct);
                        pop.Closed += popup_Closed;
                        pop.Show(this);
                        break;
                    }
                case "editProdoct":
                    {
                        ucAddProdoctStore EditPtodoct = new ucAddProdoctStore();
                        EditPtodoct.panelProdoct.Visible = true;
                        EditPtodoct.panelStore.Visible = false;
                        EditPtodoct.panelProdoct.Dock = DockStyle.Fill;
                        EditPtodoct.Size = new System.Drawing.Size(280, 210);
                        EditPtodoct.id = id;
                        EditPtodoct.name = name;
                        EditPtodoct.code = code;
                        EditPtodoct.unit = unit;
                        EditPtodoct.detail = detail;
                        EditPtodoct.barcode = barcode;
                        EditPtodoct.rfid = rfid;
                        pop = new Popup(EditPtodoct);
                        pop.Closed += popup_Closed;
                        pop.Show(this);
                        break;
                    }
            }

        }

        private void popup_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {

        }
    }
}
