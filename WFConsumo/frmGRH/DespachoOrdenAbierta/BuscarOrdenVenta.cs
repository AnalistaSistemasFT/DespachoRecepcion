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
using CRN.Entidades;

namespace WFConsumo.frmGRH.DespachoOrdenAbierta
{
    public partial class BuscarOrdenVenta : DevExpress.XtraEditors.XtraForm
    {
        CNroOrden C_NroOrden;
        DataTable dataL = new DataTable();
        int _tipoBusqueda = 0;
        int _idSucursal = 12080;
        List<GlobalItem> _ListStock = new List<GlobalItem>();
        public BuscarOrdenVenta()
        {
            InitializeComponent();
            TraerOrden();
        }
        public void TraerOrden()
        {
            DataSet dataLista = C_NroOrden.TraerTodo(_idSucursal);
            //dataP = dataLista.Tables[0];
            foreach (DataRow item in dataLista.Tables[0].Rows)
            {
                _ListStock.Add(new GlobalItem
                {
                    ItemId = item[0].ToString(),
                    ItemFerro = item[1].ToString(),
                    Descripcion = item[2].ToString(),
                    StockPzs = Convert.ToInt32(item[3])
                });
            }
            this.gridControl1.DataSource = _ListStock;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {

        }

        private void BuscarOrdenVenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.OpenForms["frmNuevoDespachoMercaderia"].Enabled = true;
            }
        }

        private void checkCodigo_CheckedChanged(object sender, EventArgs e)
        {
            if (checkCodigo.Checked == true)
            {
                checkCliente.Checked = false;
                _tipoBusqueda = 0;
            }
            else if (checkCodigo.Checked == false)
            {
                checkCliente.Checked = true;
                _tipoBusqueda = 1;
            }
            else
            {
                checkCliente.Checked = true;
                checkCodigo.Checked = false;
                _tipoBusqueda = 0;
            }
        }

        private void checkCliente_CheckedChanged(object sender, EventArgs e)
        {
            if(checkCliente.Checked == true)
            {
                checkCodigo.Checked = false;
                _tipoBusqueda = 0;
            }
            else if(checkCliente.Checked == false)
            {
                checkCodigo.Checked = true;
                _tipoBusqueda = 1;
            }
            else
            {
                checkCliente.Checked = false;
                checkCodigo.Checked = true;
                _tipoBusqueda = 0;
            }
        }
    }
}