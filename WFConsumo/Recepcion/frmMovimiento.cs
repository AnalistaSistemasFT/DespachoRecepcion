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
using CAD;
namespace WFConsumo
{
    public partial class frmMovimiento : Form
    {
        
        //CCentroTrabajo centrotrab;
        DataTable dataT = new DataTable();
        CADMovimiento oMovimiento;
        CADMovDetalle oMovDet;
       // CAnotacion oanotacion = new CAnotacion();
        string movimiento = string.Empty;
        
        public frmMovimiento(Usuario u,string Estado)
        {
            InitializeComponent();
            oMovimiento = new CADMovimiento();
             oMovDet = new CADMovDetalle();

            CargaDespachos(Estado);
        }
        public void CargaDespachos(string Estado) 
        {
            DataSet data = oMovimiento.TraerMovimientos( Entidades.utilitario.iSucursal,"MOV001001");
            this.gridControl1.DataSource = data.Tables[0];

            data = oMovimiento.TraerMovimientos(Entidades.utilitario.iSucursal, "MOV001002");
            this.gridControl2.DataSource = data.Tables[0];
        }
        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            //click celda gridcontrol
            ColumnView view = this.gridControl1.MainView as ColumnView;
            int[] row = view.GetSelectedRows();
            if (row.Count() > 0)
            {
                view.FocusedRowHandle = row[0];
                movimiento = (view.GetRowCellDisplayText(row[0], view.Columns[0])).ToString();
               
                //d.DespachoId,d.CI,c.Nombre,d.Id_Camion,d.Placa,'FERROTODO' AS Propietario,d.Obs,SucDestino,SucursalId
                DataSet dts = oMovDet.TraerMovimientoDetalle(movimiento);
                gridControl3.DataSource = dts.Tables[0];
            }
            else
                movimiento = string.Empty;
        }
       

        private void tsNuevo_Click(object sender, EventArgs e)
        {
           
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
            //click celda gridcontrol
            ColumnView view = this.gridControl2
                .MainView as ColumnView;
            int[] row = view.GetSelectedRows();
            if (row.Count() > 0)
            {
                view.FocusedRowHandle = row[0];
                movimiento = (view.GetRowCellDisplayText(row[0], view.Columns[0])).ToString();

                //d.DespachoId,d.CI,c.Nombre,d.Id_Camion,d.Placa,'FERROTODO' AS Propietario,d.Obs,SucDestino,SucursalId
                DataSet dts = oMovDet.TraerMovimientoDetalle(movimiento);
                gridControl3.DataSource = dts.Tables[0];
            }
            else
                movimiento = string.Empty;
        }
    }
}