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

namespace WFConsumo
{
    public partial class frmProductos: Form
    {
        CItem oItem = new CItem();
        
        public frmProductos()
        {
            InitializeComponent();
            cargarPaquetes();
        }

        private void cargarPaquetes()
        {
            DataSet dtsItem = oItem.TraerTodoItem();
            this.gridProductos.DataSource = dtsItem.Tables[0];

        }

        
        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            ColumnView view = this.gridProductos.MainView as ColumnView;
            int[] row = view.GetSelectedRows();
            view.FocusedRowHandle = row[0];
            
            Item = (view.GetRowCellDisplayText(row[0], view.Columns["ItemId"])).ToString();

            DataSet dts = oItem.TraerItemSucursal(Item);
            this.gridDetalle.DataSource = dts.Tables[0];
        }

       
        string Item = string.Empty;
        string Desc = string.Empty;
        string Peso = string.Empty;
        string Etiqueta = string.Empty;

        private void button1_Click(object sender, EventArgs e)
        {
            frmABMItem frmItem = new frmABMItem();
            frmItem.ShowDialog();
        }
    }
}
