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
using WFConsumo.Reportes;

namespace WFConsumo.Recepcion
{
    public partial class frmHisCuarentena : Form
    {
        CAnotacion oAnotaion = new CAnotacion();
        string Item = string.Empty;
        public frmHisCuarentena()
        {
            InitializeComponent();
            cargarPaquetes();
        }
        private void cargarPaquetes()
        {
           
            DataSet dtsAnotacion = oAnotaion.traerCuarentena(Entidades.utilitario.iSucursal);
            this.gridPaquetes.DataSource = dtsAnotacion.Tables[0];

        }
        
        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            ColumnView view = this.gridPaquetes.MainView as ColumnView;
            int[] row = view.GetSelectedRows();
            view.FocusedRowHandle = row[0];
            Item = (view.GetRowCellDisplayText(row[0], view.Columns[0])).ToString();
            DataSet dtsAnotacion = oAnotaion.traerCuarentenaDetalle(Convert.ToInt32(Item),Entidades.utilitario.iSucursal);
            this.gridControl1.DataSource = dtsAnotacion.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void rbetiqueta1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbeqtiqueta2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }
    }
}
