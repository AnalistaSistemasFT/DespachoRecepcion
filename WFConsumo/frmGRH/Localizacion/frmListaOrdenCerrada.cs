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
    public partial class frmListaOrdenCerrada : DevExpress.XtraEditors.XtraForm
    {
        CLocaliza C_Localiza;
        int _IdSucursal = 0;
        string _NrOrden = string.Empty;
        public frmListaOrdenCerrada(Usuario user, int sucursalId)
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
                DataSet dataLista = C_Localiza.TraerOrdenesCerradas(_IdSucursal);
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
    }
}