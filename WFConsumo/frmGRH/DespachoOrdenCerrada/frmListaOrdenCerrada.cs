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

namespace WFConsumo.frmGRH.DespachoOrdenCerrada
{
    public partial class frmListaOrdenCerrada : DevExpress.XtraEditors.XtraForm
    {
        int _idSucursal = 12071;
        string _nSucursal;
        private string _idDespacho;
        private string IdDespacho = "0";
        private DateTime _Fecha = DateTime.Now;
        CDespacho C_Despacho;
        DataTable dataT = new DataTable();
        DataTable dataDet = new DataTable();
        DataTable dataProd = new DataTable();
        CTraspaso C_Traspaso;
        CSucursal C_Sucursal;

        public frmListaOrdenCerrada()
        {
            InitializeComponent();
            C_Despacho = new CDespacho();
            C_Traspaso = new CTraspaso();
            C_Sucursal = new CSucursal();
            TraerData();
        }
        private void TraerData()
        {
            try
            {
                DataSet dataLista = C_Despacho.TraerDespachoCerrado(_idSucursal);
                dataT = dataLista.Tables[0];
                this.gridControl1.DataSource = dataT;
            }
            catch (Exception err)
            {
                Console.WriteLine("####################### = " + err.ToString());
            }
        }

        private void gridView4_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            try
            {
                ColumnView view = this.gridControl1.MainView as ColumnView;
                int[] row = view.GetSelectedRows();
                view.FocusedRowHandle = row[0];
                _idDespacho = (view.GetRowCellDisplayText(row[0], view.Columns[0])).ToString();
                labelControl2.Text = _idDespacho;

                DataSet detalleLista = C_Despacho.TraerDetalleDespacho(_idDespacho);
                dataDet = detalleLista.Tables[0];
                this.gridControl2.DataSource = dataDet;

                DataSet detalleProd = C_Despacho.TraerDespProducto(_idDespacho);
                dataProd = detalleProd.Tables[0];
                this.gridControl3.DataSource = dataProd;
            }
            catch (Exception err)
            {
                Console.WriteLine("####################### = " + err.ToString());
            }
        }

        private void btnEntrega_Click(object sender, EventArgs e)
        {
            ColumnView view = gridControl1.MainView as ColumnView;
            int[] row = view.GetSelectedRows();
            if (row.Length > 0)
            {
                view.FocusedRowHandle = row[0];
            }
            try
            {
                string DespachoId = "0";
                IdDespacho = view.GetRowCellDisplayText(row[0], view.Columns[0]);
                if (IdDespacho != "0")
                {
                    DespachoId = IdDespacho;
                    var myForm = new RealizarEntrega(IdDespacho);
                    this.Enabled = false;
                    myForm.Show();
                }
            }
            catch (Exception err)
            {
                XtraMessageBox.Show(err.ToString(), "Error");
            }
        }
    }
}