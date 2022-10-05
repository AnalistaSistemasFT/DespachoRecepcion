using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using WFConsumo.frmGRH.DespachoOrdenEnProceso;

namespace WFConsumo.frmGRH
{
    public partial class MenuDespacho : DevExpress.XtraBars.TabForm
    {
        public MenuDespacho()
        {
            InitializeComponent();
        }

        private void btnOrdenAbierta_Click(object sender, EventArgs e)
        {
            //var myForm = new frmListaDespachoMercaderia();
            //myForm.Show();
            
        }

        private void btnOrdenPendiente_Click(object sender, EventArgs e)
        {
            //var myForm = new frmListaOrdenEnProceso();
            //myForm.Show();
        }
    }
}