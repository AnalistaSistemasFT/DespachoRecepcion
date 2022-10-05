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

namespace WFConsumo.frmGRH.DespachoOrdenParcial
{
    public partial class AddEnvio : DevExpress.XtraEditors.XtraForm
    {
        string _IdDespacho = "0";
        DataTable dataDesp = new DataTable();
        CDespacho C_Despacho;
        public AddEnvio(string IdDespacho)
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
                        
                    }
                }
            }
            catch (Exception err)
            {
                XtraMessageBox.Show(err.ToString(), "Error");
            }
        }
        private void ConsultarDespachoEnProceso_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.OpenForms["frmListaDespachoEnProceso"].Enabled = true;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}