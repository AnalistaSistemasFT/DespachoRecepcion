using CAD;
using CRN.Componentes;
using CRN.Entidades;
using DevExpress.XtraGrid.Views.Base;
using IronBarCode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFConsumo.frmGRH.DespachoVentaAbierta;
using WFConsumo.Reportes;

namespace WFConsumo.Recepcion
{
    public partial class frmEntregasPendientes : Form
    {
        CADInformix oInformix;
        int _idSucursal = 0;
        Usuario _Usuario;
        int _tipoV = 0;

        public frmEntregasPendientes(int sucursalId, Usuario user)
        {
            oInformix = new CADInformix();
            InitializeComponent();
            _Usuario = user;
            _idSucursal = sucursalId;
            cargarOvPendientes();
        }

        private void cargarOvPendientes()
        {
            DataSet dtsAnotacion = oInformix.TraerOvPendientes(Entidades.utilitario.iSucursal);
            this.gridControl1.DataSource = dtsAnotacion.Tables[0];

        }
        private void cargarDetalleOvPendientes(int iTipo, int iNro)
        {
            DataSet dtsAnotacionDet = oInformix.TraerDetalleNota(iTipoDOc,iNroDoc);
            this.gridControl2.DataSource = dtsAnotacionDet.Tables[0];

        }
        int iTipoDOc;
        int iNroDoc;
        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            
            ColumnView view = this.gridControl1.MainView as ColumnView;
            int[] row = view.GetSelectedRows();
            if (row.Count() > 0) 
            { 
                view.FocusedRowHandle = row[0];
               
                iTipoDOc = Convert.ToInt32 ((view.GetRowCellDisplayText(row[0], view.Columns[0])).ToString());
                iNroDoc = Convert.ToInt32((view.GetRowCellDisplayText(row[0], view.Columns[1])).ToString());

                cargarDetalleOvPendientes(iTipoDOc,iNroDoc);
               
            }
           
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
           
        }
        private void gridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            

        }
        private void button1_Click(object sender, EventArgs e)
        {
           
            
        }
        private void iconButton1_Click(object sender, EventArgs e)
        {
            
            
        }
        private void btnAnular_Click(object sender, EventArgs e)
        {
          
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
          

        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           

        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
           
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
           
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
           
        }
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            ColumnView view = gridControl1.MainView as ColumnView;
            int[] row = view.GetSelectedRows();
            if (row.Length > 0)
            {
                view.FocusedRowHandle = row[0];
            }
            int _tipoDoc = Convert.ToInt32(view.GetRowCellDisplayText(row[0], view.Columns[0]));
            int _nroDoc = Convert.ToInt32(view.GetRowCellDisplayText(row[0], view.Columns[1]));
            if(_tipoDoc > 0 && _nroDoc > 0)
            {
                _tipoV = 1;
                var myForm = new CrearDespachoVenta(_idSucursal, _Usuario, _tipoV, _tipoDoc, _nroDoc);
                myForm.FormClosed += F2_FormClosed;
                myForm.Show();
            }
        }
        private void F2_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.gridControl1.Refresh();
            this.gridControl1.RefreshDataSource();
            this.gridView1.RefreshData();
            this.gridView1.BeginDataUpdate();
            this.gridView1.EndDataUpdate();
            cargarOvPendientes(); 
        }
    }
}
