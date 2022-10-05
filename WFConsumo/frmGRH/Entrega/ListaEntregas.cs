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
using CRN.Componentes;
using DevExpress.XtraGrid.Views.Base;

namespace WFConsumo.frmGRH.Entrega
{
    public partial class ListaEntregas : DevExpress.XtraEditors.XtraForm
    {
        int _idSucursal = 12071;
        CDespacho C_Despacho;
        string _idDespacho;
        DataTable dataT = new DataTable();
        DataTable dataDet = new DataTable();
        public ListaEntregas()
        {
            InitializeComponent();
            C_Despacho = new CDespacho();
            TraerData();

        }
        private void TraerData()
        {
            try
            {
                DataSet dataLista = C_Despacho.TraerDespachoCerrado(_idSucursal);
                dataT = dataLista.Tables[0];
                this.gridControl2.DataSource = dataT;
            }
            catch (Exception err)
            {
                Console.WriteLine("####################### = " + err.ToString());
            }
        }

        private void gridView2_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            ColumnView view = this.gridControl2.MainView as ColumnView;
            int[] row = view.GetSelectedRows();
            view.FocusedRowHandle = row[0];
            _idDespacho = (view.GetRowCellDisplayText(row[0], view.Columns[0])).ToString();
            //labelControl2.Text = _idDespacho;

            DataSet detalleLista = C_Despacho.TraerDetalleDespachoEntrega(_idDespacho);
            dataDet = detalleLista.Tables[0];
            this.gridControl3.DataSource = dataDet;
        }
    }
}