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
    public partial class frmListaOrdenAbierta : DevExpress.XtraEditors.XtraForm
    {
        CLocaliza C_Localiza;
        int _IdSucursal = 0;
        string _NrOrden = string.Empty;
        public frmListaOrdenAbierta(Usuario user, int sucursalId)
        {
            InitializeComponent();
            C_Localiza = new CLocaliza();
            _IdSucursal = sucursalId;
            TraerDatos();
        }
        public void TraerDatos()
        {
            try
            {
                DataSet dataLista = C_Localiza.TraerOrdenesAbiertas(_IdSucursal);
                gridControl1.DataSource = dataLista.Tables[0];
            }
            catch (Exception err)
            {
                Console.WriteLine("###################### = " + err.ToString());
            }
        }

        private void gridView4_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            try
            {
                ColumnView view = this.gridControl1.MainView as ColumnView;
                int[] row = view.GetSelectedRows();
                view.FocusedRowHandle = row[0];
                _NrOrden = (view.GetRowCellDisplayText(row[0], view.Columns[0])).ToString();

                DataSet detalleLista = C_Localiza.TraerDetalleOrdenAbiertaProgra(_NrOrden);
                this.gridControl2.DataSource = detalleLista.Tables[0];

                DataSet detalleProducto = C_Localiza.TraerDetalleOrdenAbiertaProducto(_NrOrden);
                this.gridControl3.DataSource = detalleProducto.Tables[0];
            }
            catch (Exception err)
            {
                Console.WriteLine("###################### = " + err.ToString());
            }
        }
        private void F2_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.gridControl1.Refresh();
            this.gridControl1.RefreshDataSource();
            this.gridView1.RefreshData();
            TraerDatos();
        }
        private void btnPlanificar_Click(object sender, EventArgs e)
        {
            if (gridControl1.CanSelect)
            {
                ColumnView view = gridControl1.MainView as ColumnView;
                int[] row = view.GetSelectedRows();
                if (row.Length > 0)
                {
                    view.FocusedRowHandle = row[0];
                }
                try
                {
                    _NrOrden = view.GetRowCellDisplayText(row[0], view.Columns[1]);
                    string _centro = view.GetRowCellDisplayText(row[0], view.Columns[9]);
                    string _IdPlan = view.GetRowCellDisplayText(row[0], view.Columns[0]);
                     
                    if (_NrOrden != string.Empty)
                    {
                        var myForm = new PickearOrden(_IdSucursal, _NrOrden, _centro, _IdPlan);
                        myForm.FormClosed += F2_FormClosed;
                        myForm.Show();
                    }
                }
                catch (Exception err)
                {
                    XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                    Console.WriteLine("################## = " + err.ToString());
                }
            }
        } 
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (gridControl1.CanSelect)
            {
                ColumnView view = gridControl1.MainView as ColumnView;
                int[] row = view.GetSelectedRows();
                if (row.Length > 0)
                {
                    view.FocusedRowHandle = row[0];
                }
                try
                {
                    _NrOrden = view.GetRowCellDisplayText(row[0], view.Columns[0]);
                    string _Item = view.GetRowCellDisplayText(row[0], view.Columns[2]);
                    string _Descripcion = view.GetRowCellDisplayText(row[0], view.Columns[3]);
                    string _Fecha = view.GetRowCellDisplayText(row[0], view.Columns[4]);
                    string _Cantidad = view.GetRowCellDisplayText(row[0], view.Columns[5]);
                    string _Unidad = view.GetRowCellDisplayText(row[0], view.Columns[6]);
                    string _CentroTrabajo = view.GetRowCellDisplayText(row[0], view.Columns[9]);
                    if (_NrOrden != string.Empty)
                    {
                        var myForm = new AsignacionPosicion(_IdSucursal, _NrOrden, _Item, _Descripcion, _Fecha, _Cantidad, _Unidad, _CentroTrabajo);
                        myForm.Show();
                    }
                }
                catch (Exception err)
                {
                    XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                    Console.WriteLine("################## = " + err.ToString());
                }
            }
        }
    }
}