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

namespace WFConsumo.frmGRH.DespachoOrdenAbierta
{
    public partial class frmConsultarDespacho : DevExpress.XtraEditors.XtraForm
    {
        string _IdDespacho = "0";
        DataTable dataDesp = new DataTable();
        CDespacho C_Despacho;
        public frmConsultarDespacho(string IdDespacho)
        {
            InitializeComponent();
            _IdDespacho = IdDespacho;
            C_Despacho = new CDespacho();
            TraerData();
        }
        public void TraerData()
        {
            try
            {
                if (_IdDespacho != "0")
                {
                    DataSet dataBuscar = C_Despacho.ConsultarDespacho(_IdDespacho);
                    dataDesp = dataBuscar.Tables[0];
                    foreach (DataRow item in dataDesp.Rows)
                    {
                        txtNroDespacho.Text = item["DespachoId"].ToString();
                        txtTipoDespacho.Text = item["Naturaleza"].ToString();
                        pickerFecha.EditValue = Convert.ToDateTime(item["Fecha"]);
                        comboBoxChofer.Text = item["Chofer"].ToString();
                        txtCI.Text = item["CI"].ToString();
                        comboBoxPlaca.Text = item["Placa"].ToString();
                        txtCamion.Text = item["Marca"].ToString();
                        comboBoxSucursal.Text = item["SucDestino"].ToString();
                        txtCliente.Text = item["SucDestino"].ToString();
                        txtNroOrden.Text = item["NroOrden"].ToString();
                        txtNroTraspaso.Text = item["NumTraspaso"].ToString();
                        txtProgramacion.Text = item["Tipo"].ToString();
                        txtObs.Text = item["Obs"].ToString();
                    }
                    if (txtTipoDespacho.Text.ToUpper() == "TRASPASO")
                    {
                        txtCliente.Visible = false;
                        comboBoxSucursal.Visible = true;
                    }
                    else if (txtTipoDespacho.Text.ToUpper() == "VENTA")
                    {
                        txtCliente.Visible = true;
                        comboBoxSucursal.Visible = false;
                    } 
                    else
                    {
                        txtCliente.Visible = true;
                        comboBoxSucursal.Visible = true;
                    }
                }
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Problemas con la conexion", "Error");
                Console.WriteLine("####################### = " + err.ToString());
            }
        }
        private void frmConsultarDespacho_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.OpenForms["frmListaDespachoMercaderia"].Enabled = true;
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}