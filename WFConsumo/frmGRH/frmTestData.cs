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
using CAD;

namespace WFConsumo.frmGRH
{
    public partial class frmTestData : DevExpress.XtraEditors.XtraForm
    {
        int _idSucursal = 12081;
        string _Usuario = "User123";
        DataTable dataOrden = new DataTable();
        DataTable dataOrden2 = new DataTable();
        DataTable dataOrden3 = new DataTable();
        CNroOrden C_NroOrden;
        CItem C_Item;
        CInformix C_Informix;
        COrdenEntrega C_OrdenEntrega;
        CADInformix _Informix;
        CMovDespacho C_MovDespacho;
        CTbltipofact C_Tbltipofact;
        CPaquetes C_Paquetes;
        CCatChofer C_Chofer;
        CCeldas C_Celdas;

        public frmTestData()
        {
            InitializeComponent();
            C_NroOrden = new CNroOrden();
            C_Item = new CItem();
            C_Informix = new CInformix();
            C_OrdenEntrega = new COrdenEntrega();
            _Informix = new CADInformix();
            C_MovDespacho = new CMovDespacho();
            C_Tbltipofact = new CTbltipofact();
            C_Paquetes = new CPaquetes();
            C_Chofer = new CCatChofer();
            C_Celdas = new CCeldas();
            TraerData();
        }
        public void TraerData()
        {
            try
            {
                //int _idSucursalDestino = 120;
                //DataSet dataLista = C_Item.TraerTodoItem();
                //dataOrden = dataLista.Tables[0];
                //this.gridControl1.DataSource = dataOrden;
                int _idSucursal = 12081;
                decimal sTipoDoc1 = 21021;
                decimal sTipoDoc = 21021;
                //DataSet dataLista2 = C_Informix.TraerDetalleEntSuc(_idSucursal, sTipoDoc, sTipoDoc1);
                string _Correlativo = string.Empty;
                //traer correlativo
                //DataSet _listCorr = _Informix.TraerCorrelativoCierre(_idSucursal);
                //foreach (DataRow item in _listCorr.Tables[0].Rows)
                //{
                //    _Correlativo = item[0].ToString();
                //}
                //XtraMessageBox.Show("######################## = " + _Correlativo.ToString());
                //string _idDespacho = "1D22001845";
                //string _idDespacho2 = "1D22001845";
                //DataSet dataOrden = C_Celdas.TraerListaCeldas(12080);
                //this.gridControl1.DataSource = dataOrden.Tables[0];

                DataSet dataOrden2 = C_OrdenEntrega.dts1();
                this.gridControl1.DataSource = dataOrden2.Tables[0];
                DataSet dataOrden3 = C_OrdenEntrega.dts2();
                this.gridControl2.DataSource = dataOrden3.Tables[0];
                //Console.WriteLine("%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%% = " + datalistInf.Tables[0].Rows.Count.ToString());
                //////DataSet dataDet = C_Informix.TraerDetalleOV();
                //////this.gridControl1.DataSource = dataDet.Tables[0];

                //////DataSet dataA = C_Informix.TraerTodasOrdenes();
                //////this.gridControl2.DataSource = dataA.Tables[0];

                //DataSet dataDetOrd = _Informix.TraerContadoCredito(12081);
                //this.gridControl1.DataSource = dataDetOrd.Tables[0];
                //DataSet daraEntreg = _Informix.TraerTipoDocEntrega(12081);
                //this.gridControl2.DataSource = daraEntreg.Tables[0];
                //decimal _idSucursal = 12021;
                //DataSet dataLista3 = C_Informix.TraerDetalleEntSuc(_idSucursal);
                //dataOrden3 = dataLista3.Tables[0];
                //this.gridControl2.DataSource = dataOrden3;

                //dataOrden2.Columns.Add("Nombre");
                //dataOrden2.Columns.Add("Entregado");
                //dataOrden2.Columns.Add("Total");
                //dataOrden2.Columns.Add("Pendiente");

                //dataOrden2.Rows.Add(new object[] { "Lorem ipsum dolor sit amet, consectetur adipiscing elit", 20, 100, 80});
                //dataOrden2.Rows.Add(new object[] { "sed do eiusmod tempor incididunt", 20, 100, 80 });
                //dataOrden2.Rows.Add(new object[] { "ut labore et dolore magna aliqua", 20, 100, 80 });
                //dataOrden2.Rows.Add(new object[] { "Ut enim ad minim veniam", 20, 100, 80 });
                //dataOrden2.Rows.Add(new object[] { "quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat", 20, 100, 80 });
                //dataOrden2.Rows.Add(new object[] { "Duis aute irure dolor in reprehenderit", 20, 100, 80 });
                ////gridControl1.DataSourceID = null;
                //this.gridControl2.DataSource = dataOrden2;
                //this.gridControl1.DataSource = dataOrden2;
            }
            catch (Exception err)
            {
                Console.WriteLine("################## = " + err.ToString());
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            try
            {
                string Despacho = "12345";
                int a = C_OrdenEntrega.DataUpdate();
                //int a = _Informix.EditData();
                if (a > 0)
                {
                    XtraMessageBox.Show("OK");
                }
                else
                {
                    XtraMessageBox.Show("ERROR");
                }
            }
            catch(Exception err)
            {
                Console.WriteLine("############################ = " + err.ToString());
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            TraerData();
        }
    }
}