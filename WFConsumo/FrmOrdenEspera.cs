using CRN.Componentes;
using DevExpress.XtraGrid.Views.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFConsumo
{
    public partial class FrmOrdenEspera : Form
    {
        COrdenProduccionV2 corden;
        public FrmOrdenEspera()
        {
            InitializeComponent();
            corden = new COrdenProduccionV2();
            cargarOrdenEsper();
        }

        public void cargarOrdenEsper() 
        {
            string consulta = "select  *  from tblOrdenProduccion where status='ESPERA'";
            var data = corden.retornarTabla(consulta);
            this.gridControl1.DataSource = data.Tables[0];
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            //doble click
            try
            {
                ColumnView view = this.gridControl1.MainView as ColumnView;
                int[] row = view.GetSelectedRows();
                string ord = (view.GetRowCellDisplayText(row[0], view.Columns[1])).ToString();
                string iidentidad = (view.GetRowCellDisplayText(row[0], view.Columns[0])).ToString();
                DialogResult result = MessageBox.Show(String.Format("PONER EN PROCESO ESTA ORDEN  = {0} ?", ord), "INFORMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {

                    string consulta = String.Format("update tblOrdenProduccion set status='PROCESO' where iCorrelativo={0}", iidentidad);
                    bool res = this.corden.EjecutarSentenciasU(consulta);
                    if (res)
                        MessageBox.Show("ORDEN EN PROCESO", "INFORMATION");
                    else
                        MessageBox.Show("OCURRIO UN ERROR ", "INFORMATION");
                }
            }
            catch ( Exception ee)
            {
               
            }
           
        }
    }
}
