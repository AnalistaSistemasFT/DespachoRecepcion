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
    public partial class frmOrdenesProduccion : Form
    {
        COrdenProduccionV2 corden;
        private string sucursalP;
        public frmOrdenesProduccion(string sucursal)
        {
            InitializeComponent();
            this.corden = new COrdenProduccionV2();
            llenargridprincipal();
            this.sucursalP = sucursal;
        }
        public void llenargridprincipal() 
        {
            string consulta = "select * from tblOrdenProduccion where status != 'INPR' and status != 'PROCESO' ";
            var data=this.corden.retornarTabla(consulta);
            this.gridControl1.DataSource = data.Tables[0];      
        }
        private void button2_Click(object sender, EventArgs e)
        {
            FrmVistaSincronizador vista = new FrmVistaSincronizador(this.sucursalP);
            vista.ShowDialog();
            llenargridprincipal();
        }
        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            ///celda seleccionada
        }
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            ///doble click para poner en proceso una orden
            ColumnView view = this.gridControl1.MainView as ColumnView;
            int[] row = view.GetSelectedRows();
            string ord = (view.GetRowCellDisplayText(row[0], view.Columns[1])).ToString();
            string iidentidad = (view.GetRowCellDisplayText(row[0], view.Columns[0])).ToString();

            DialogResult result = MessageBox.Show(String.Format("PONER EN PROCESO ESTA ORDEN  = {0} ?",ord), "INFORMATION",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string consulta = "select * from tblOrdenProduccion where status = 'INPR' or status = 'PROCESO' ";
                var data = this.corden.retornarTabla(consulta);

                if (data.Tables[0].Rows.Count <1)
                {
                    consulta = String.Format("update tblOrdenProduccion set status='PROCESO' where iCorrelativo={0}", iidentidad);
                    bool res = this.corden.EjecutarSentenciasU(consulta);
                    if (res)
                        MessageBox.Show("ORDEN EN PROCESO", "INFORMATION",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    else
                        MessageBox.Show("OCURRIO UN ERROR ", "INFORMATION",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    llenargridprincipal();
                }
                else
                {
                    MessageBox.Show("Ya existe una orden en proceso. Concluya la orden existente  e intentelo nuevamente ","INFORMATION",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }                          
            }
            else
            {                
            }  
        }
    }
}
