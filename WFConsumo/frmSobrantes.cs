using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace WFConsumo
{
    public partial class frmSobrantes :   DevExpress.XtraEditors.XtraForm
    {
        
        CRN.Componentes.CCatTablas oDetalle = new CRN.Componentes.CCatTablas();
        public frmSobrantes()
        {
            InitializeComponent();
            btnGenerar.Enabled = false;
        }

        private void btnBucar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtOrden.Text))
            {
                LlenarGrid();
            }
        }

        private void LlenarGrid()
        {
            if (!string.IsNullOrEmpty(txtOrden.Text)) { 
            dgvDetalle.DataSource = null;
            DataSet dts = oDetalle.TraerDetalleSobrantesxOrden(txtOrden.Text);
            if (dts.Tables[0].Rows.Count > 0)
            {
                dgvDetalle.DataSource = dts.Tables[0];
                btnGenerar.Enabled = true;
            }
            else { 
                btnGenerar.Enabled = false;
                MessageBox.Show("NO HAY DATOS PARA ESA ORDEN");
            }
            }
        }
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                DataTable dt = (DataTable)dgvDetalle.DataSource;
                int a = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    string sPaquete = dr["Paqueteid"].ToString();
                    DateTime dtFecha = DateTime.Now;
                    string sCelda = "AL3:5C-16S2";
                    string sItem = dr["itemid"].ToString();
                    decimal dPeso = Convert.ToDecimal(dr["Peso"]);
                    string sColada = "0";
                    string sCentro = "MALLA01";
                    a = oDetalle.InsertarSobrantes(sPaquete, dtFecha, sCelda, sItem, dPeso, sColada, sCentro);
                    if (a > 0)
                        a = oDetalle.ModificarCeldaSobrante(sCelda);
                    else
                        break;
                }
            if (a > 0) {
                    ts.Complete();
                LlenarGrid();
                MessageBox.Show("se realizo con exito");
            }
                ts.Dispose();

            }
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtOrden.Text))
            {
                LlenarGrid();
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            //using (TransactionScope ts = new TransactionScope())
            //{
                DataTable dt = (DataTable)dgvDetalle.DataSource;
                int a = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    string sPaquete = dr["Paqueteid"].ToString();
                    DateTime dtFecha = DateTime.Now;
                    string sCelda = "AL3:5C-16S2";
                    string sItem = dr["itemid"].ToString();
                    decimal dPeso = Convert.ToDecimal(dr["Peso"]);
                    string sColada = "0";
                    string sCentro = "MALLA01";
                    a = oDetalle.InsertarSobrantes(sPaquete, dtFecha, sCelda, sItem, dPeso, sColada, sCentro);
                    if (a > 0)
                        a = oDetalle.ModificarCeldaSobrante(sCelda);
                    else
                        break;
                }
                if (a > 0)
                {
                //ts.Complete();
                MessageBox.Show("se realizo con exito");
                dgvDetalle.DataSource = null;
                txtOrden.Text = string.Empty;
                //LlenarGrid();

            }
               // ts.Dispose();

            //}
        }

        private void txtOrden_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                LlenarGrid();
            }
        }
    }
}
