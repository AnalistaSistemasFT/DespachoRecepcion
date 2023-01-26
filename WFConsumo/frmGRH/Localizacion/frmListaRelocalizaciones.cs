using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CRN.Entidades;
using CRN.Componentes;
using DevExpress.XtraGrid.Views.Base;

namespace WFConsumo.frmGRH.Localizacion
{
    public partial class frmListaRelocalizaciones : DevExpress.XtraEditors.XtraForm
    {
        CCeldas C_Celdas;
        int _IdSucursal = 0;
        string _NrOrden = string.Empty;
        public frmListaRelocalizaciones(Usuario user, int sucursalId)
        {
            InitializeComponent();
            C_Celdas = new CCeldas();
            _IdSucursal = sucursalId;
            TraerDatos();
        }
        public void TraerDatos()
        {
            try
            {
                DataSet dataLista = C_Celdas.TraerRelocalizacionPendiente(_IdSucursal);
                gridControl1.DataSource = dataLista.Tables[0]; 
                DataSet dataCerrada = C_Celdas.TraerRelocalizacionCerrada(_IdSucursal);
                gridControl3.DataSource = dataCerrada.Tables[0]; 
            }
            catch (Exception err)
            {
                Console.WriteLine("###################### = " + err.ToString());
            }
        }
        //Pendiente
        private void gridView4_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            try
            {
                ColumnView view = this.gridControl1.MainView as ColumnView;
                int[] row = view.GetSelectedRows();
                view.FocusedRowHandle = row[0];
                _NrOrden = (view.GetRowCellDisplayText(row[0], view.Columns[0])).ToString();

                DataSet detalleLista = C_Celdas.TraerDetalleRelocalizacionPendiente(_NrOrden);
                this.gridControl2.DataSource = detalleLista.Tables[0];
                xtraTabPage3.Show();
            }
            catch (Exception err)
            {
                Console.WriteLine("###################### = " + err.ToString());
            }
        }
        //Historial
        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            try
            {
                ColumnView view = this.gridControl3.MainView as ColumnView;
                int[] row = view.GetSelectedRows();
                view.FocusedRowHandle = row[0];
                _NrOrden = (view.GetRowCellDisplayText(row[0], view.Columns[0])).ToString();

                DataSet detalleLista = C_Celdas.TraerDetalleRelocalizacionCerrada(_NrOrden);
                this.gridControl4.DataSource = detalleLista.Tables[0];
                xtraTabPage4.Show();
            }
            catch (Exception err)
            {
                Console.WriteLine("###################### = " + err.ToString());
            }
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {

        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (gridView4.OptionsFind.AlwaysVisible == true)
            {
                gridView4.OptionsFind.AlwaysVisible = false;
            }
            else if (gridView4.OptionsFind.AlwaysVisible == false)
            {
                gridView4.OptionsFind.AlwaysVisible = true;
            }
            else
            {
                gridView1.OptionsFind.AlwaysVisible = true;
            }
            //
            if (gridView1.OptionsFind.AlwaysVisible == true)
            {
                gridView1.OptionsFind.AlwaysVisible = false;
            }
            else if (gridView1.OptionsFind.AlwaysVisible == false)
            {
                gridView1.OptionsFind.AlwaysVisible = true;
            }
            else
            {
                gridView1.OptionsFind.AlwaysVisible = true;
            }
        }
    }
}