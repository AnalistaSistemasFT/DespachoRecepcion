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

namespace WFConsumo.frmGRH
{
    public partial class ConsultarDespacho : DevExpress.XtraEditors.XtraForm
    {
        string _IdDespacho = "0";
        DataTable dataDesp = new DataTable();
        CDespacho C_Despacho;
        public ConsultarDespacho(string IdDespacho)
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
                if (_IdDespacho != string.Empty)
                {
                    DataSet dataBuscar = C_Despacho.ConsultarDespacho(_IdDespacho);
                    dataDesp = dataBuscar.Tables[0];
                    foreach (DataRow item in dataDesp.Rows)
                    {
                        txtTitulo.Text = item[0].ToString();
                        txtTipoDesp.Text = item[1].ToString();
                        DateTime dat = Convert.ToDateTime(item[2]);
                        txtFecha.Text = dat.ToString("dd/MM/yyyy");
                        txtChofer.Text = item[3].ToString();
                        txtCI.Text = item[4].ToString();
                        txtPlaca.Text = item[5].ToString();
                        txtCamion.Text = item[6].ToString();
                        txtSucursal.Text = item[7].ToString();
                        txtCliente.Text = item[8].ToString();
                        txtNroOrden.Text = item[9].ToString();
                        txtProgramacion.Text = item[10].ToString();
                        txtObs.Text = item[11].ToString();
                    }
                }
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("################ = " + err.ToString());
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}