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

namespace WFConsumo
{
    public partial class frmMovimiento : Form
    {
        
        CCentroTrabajo centrotrab;
        DataTable dataT = new DataTable();
        CRecepcion orecepcion;
        CAnotacion oanotacion = new CAnotacion();
        string Despacho = string.Empty;
        string Id_Camion = string.Empty;
        string Placa = string.Empty;
        string CI = string.Empty;
        string Nombre = string.Empty;
        string Propietario = string.Empty;
        string Obs = string.Empty;
        string SucDestino = string.Empty;
        string SucursalId = string.Empty;
        public frmMovimiento(Usuario u,string Estado)
        {
            InitializeComponent();
            orecepcion = new CRecepcion();
            CargaDespachos(Estado);
        }
        public void CargaDespachos(string Estado) 
        {
            DataSet data = orecepcion.TraerDespachos(Estado, Entidades.utilitario.iSucursal);
            dataT = data.Tables[0];
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
                Despacho = (view.GetRowCellDisplayText(row[0], view.Columns[0])).ToString();
                CI = (view.GetRowCellDisplayText(row[0], view.Columns[1])).ToString();
                Nombre = (view.GetRowCellDisplayText(row[0], view.Columns[2])).ToString();
                Id_Camion = (view.GetRowCellDisplayText(row[0], view.Columns[3])).ToString();
                Placa = (view.GetRowCellDisplayText(row[0], view.Columns[4])).ToString();
                Propietario = (view.GetRowCellDisplayText(row[0], view.Columns[5])).ToString();
                Obs = (view.GetRowCellDisplayText(row[0], view.Columns[6])).ToString();
                SucDestino = (view.GetRowCellDisplayText(row[0], view.Columns[7])).ToString();
                SucursalId = (view.GetRowCellDisplayText(row[0], view.Columns[8])).ToString();

                //d.DespachoId,d.CI,c.Nombre,d.Id_Camion,d.Placa,'FERROTODO' AS Propietario,d.Obs,SucDestino,SucursalId
                DataSet dts = orecepcion.TraerDespachoDet(Despacho);
                gridControl2.DataSource = dts.Tables[0];
                DataSet dts1 = orecepcion.TraerDespachoDetProd(Despacho);
                gridControl3.DataSource = dts1.Tables[0];
            }
            else
                Despacho = string.Empty;
        }
       

        private void tsNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                string sError = string.Empty;
                DataTable ds;
                ds = (DataTable)gridControl3.DataSource;
                int a = oanotacion.InsertarProcesoRecepcion(out sError, ds, Despacho, DateTime.Now, Nombre, Convert.ToInt32(Id_Camion), Placa, CI, Propietario, Entidades.utilitario.sUsuario, Obs, 1, "OPEN", Convert.ToInt32(SucDestino), Convert.ToInt32(SucursalId), Despacho, 2, false, "S/M", "0", 0, "0", 0, Entidades.utilitario.iAlmacen);
                if (a > 0)
                {
                    CargaDespachos("TRANSITO");
                    MessageBox.Show("Se Genero Con Exito");
                }
                else
                {
                    MessageBox.Show("Problemas en la Trasaccion");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problemas en la Trasaccion " + ex.ToString());
                throw ex;
            }
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
            DataSet dtsRecepcion = oanotacion.ReporteRecepcionDetalle(Despacho);
            rptRecepcionDetalle rptRecepcion = new rptRecepcionDetalle();
            rptRecepcion.SetDataSource(dtsRecepcion.Tables[0]);
            frmReportViewer viwer = new frmReportViewer(rptRecepcion);
            viwer.Width = 1000;
            viwer.Height = 800;
            viwer.StartPosition = FormStartPosition.CenterScreen;
            viwer.ShowDialog();

        }
    }
}