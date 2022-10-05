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

namespace WFConsumo.frmGRH.DespachoOrdenEntrega
{
    public partial class ConsultarDespachoParcial : DevExpress.XtraEditors.XtraForm
    {
        string _IdDespacho = "0";
        DataTable dataDesp = new DataTable();
        CDespacho C_Despacho;
        public ConsultarDespachoParcial(string IdDespacho)
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
                        txtTitulo.Text = item["DespachoId"].ToString();
                        txtTipoDesp.Text = item["Naturaleza"].ToString();
                        txtFecha.Text = item["Fecha"].ToString();
                        txtChofer.Text = item["Chofer"].ToString();
                        txtCI.Text = item["CI"].ToString();
                        txtPlaca.Text = item["Placa"].ToString();
                        txtCamion.Text = item["Marca"].ToString();
                        txtSucursal.Text = item["SucDestino"].ToString();
                        txtCliente.Text = item["SucDestino"].ToString();
                        txtNroOrden.Text = item["NroOrden"].ToString();
                        txtNroTraspaso.Text = item["NumTraspaso"].ToString();
                        txtProgramacion.Text = item["Tipo"].ToString();
                        txtObs.Text = item["Obs"].ToString();
                    }
                }
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("####################### = " + err.ToString());
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConsultarDespachoParcial_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                //Application.OpenForms["frmListaDespachoParcial"].Enabled = true;
            }
        }
    }
}