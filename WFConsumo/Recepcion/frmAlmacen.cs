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
using CRN.Entidades;
using WFConsumo.Reportes;
using WFConsumo.Recepcion;
using CAD;
namespace WFConsumo
{
    public partial class frmAlmacen : Form
    {
        CADAlmacen oAlmacen;
       

        public frmAlmacen(Usuario u)
        {
            InitializeComponent();
            oAlmacen = new CADAlmacen();
            CargarAlmacen();
           
        }
        public void CargarAlmacen() 
        {
            DataSet data = oAlmacen.TraerAlmacen( Entidades.utilitario.iSucursal);
            this.gridControl1.DataSource = data.Tables[0];  
        }
        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            //click celda gridcontrol
            ColumnView view = this.gridControl1.MainView as ColumnView;
            int[] row = view.GetSelectedRows();
            if (row.Count() > 0)
            {
                view.FocusedRowHandle = row[0];
                int iAlmacen = Convert.ToInt32((view.GetRowCellDisplayText(row[0], view.Columns[0])).ToString());
               
                //d.DespachoId,d.CI,c.Nombre,d.Id_Camion,d.Placa,'FERROTODO' AS Propietario,d.Obs,SucDestino,SucursalId
                DataSet dts = oAlmacen.TraerAlmacenDetalleItem(Entidades.utilitario.iSucursal, iAlmacen);
                gridControl2.DataSource = dts.Tables[0];
                
            }
           
        }
        private void tsNuevo_Click(object sender, EventArgs e)
        {
            
        }
        private void F2_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.gridControl1.DataSource = null;
            this.gridControl1.Refresh();
            this.gridControl1.RefreshDataSource();
            this.gridView1.RefreshData();
            //CargaDespachos("Enviado");
        }
        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void labelX8_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
           
        }

        private void gridView2_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {

            ColumnView view = this.gridControl1.MainView as ColumnView;
            int[] row = view.GetSelectedRows();
            if (row.Count() > 0)
            {
                view.FocusedRowHandle = row[0];
                string Item = ((view.GetRowCellDisplayText(row[0], view.Columns[0])).ToString());

                //d.DespachoId,d.CI,c.Nombre,d.Id_Camion,d.Placa,'FERROTODO' AS Propietario,d.Obs,SucDestino,SucursalId
                DataSet dts1 = oAlmacen.TraerAlmacenDetalleXItem(Item);
                gridControl3.DataSource = dts1.Tables[0];

            }


            
        }
    }
}