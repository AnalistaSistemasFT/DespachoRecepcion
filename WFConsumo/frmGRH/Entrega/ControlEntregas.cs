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
    public partial class ControlEntregas : DevExpress.XtraEditors.XtraForm
    {
        CInformix C_Informix;
        decimal _idSucursal = 0;
        decimal _nroEnt = 0;
        decimal _tipoDoc = 0;
        decimal _tipoDoc2 = 0;
        decimal _nroVenta = 0;
        decimal _nroDoc = 0;
        decimal _nroDocumento2 = 0;
        DateTime _fechaEnt = DateTime.Now;
        decimal _sucOrigen = 0;
        decimal _codCliente = 0;
        string _nombreCliente = string.Empty;
        decimal _codVendedor = 0;
        decimal _formaPago = 0;
        DateTime _fechaV = DateTime.Now;

        public ControlEntregas()
        {
            InitializeComponent();
            C_Informix = new CInformix();
            _idSucursal = 12081;
            TraerData();
        }
        public void TraerData()
        {
            try
            {
                DataSet dataLista = C_Informix.TraerEntregas(_idSucursal);
                gridControl1.DataSource = dataLista.Tables[0];
            }
            catch(Exception err)
            {
                Console.WriteLine("################################# = " + err.ToString());
            }
        } 
        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            try
            {
                ColumnView view = this.gridControl1.MainView as ColumnView;
                int[] row = view.GetSelectedRows();
                view.FocusedRowHandle = row[0];
                _nroEnt = Convert.ToDecimal(view.GetRowCellDisplayText(row[0], view.Columns[0]));
                _tipoDoc = Convert.ToDecimal(view.GetRowCellDisplayText(row[0], view.Columns[1]));
                _nroVenta = Convert.ToDecimal(view.GetRowCellDisplayText(row[0], view.Columns[2]));
                _nroDoc = Convert.ToDecimal(view.GetRowCellDisplayText(row[0], view.Columns[3]));
                _fechaEnt = Convert.ToDateTime(view.GetRowCellDisplayText(row[0], view.Columns[4]));
                _sucOrigen = Convert.ToDecimal(view.GetRowCellDisplayText(row[0], view.Columns[5]));
                _codCliente = Convert.ToDecimal(view.GetRowCellDisplayText(row[0], view.Columns[6]));
                _nombreCliente = view.GetRowCellDisplayText(row[0], view.Columns[7]).ToString();
                _codVendedor = Convert.ToDecimal(view.GetRowCellDisplayText(row[0], view.Columns[8]));
                _formaPago = Convert.ToDecimal(view.GetRowCellDisplayText(row[0], view.Columns[9]));
                _fechaV = Convert.ToDateTime(view.GetRowCellDisplayText(row[0], view.Columns[10]));

                txtTipoDoc.Text = _tipoDoc.ToString();
                txtNroVenta.Text = _nroVenta.ToString();
                txtNroDocEntrega.Text = _nroDoc.ToString();
                txtFecha.Text = _fechaEnt.ToString("dd/MM/yyyy");
                txtSucursal.Text = _sucOrigen.ToString();
                txtCliente.Text = _codCliente.ToString() + " - " + _nombreCliente;
                txtVendedor.Text = _codVendedor.ToString();
                txtFormaPago.Text = _formaPago.ToString();
                txtFechaVenta.Text = _fechaV.ToString("dd/MM/yyyy");

                DataSet detalleLista = C_Informix.TraerDetalleEntregas(_tipoDoc, _nroDoc);
                Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$ = " + detalleLista.Tables[0].Rows.Count.ToString());
                gridControl2.DataSource = detalleLista.Tables[0];
            }
            catch(Exception err)
            {
                Console.WriteLine("##################################### = " + err.ToString());
            }
        }
    }
}