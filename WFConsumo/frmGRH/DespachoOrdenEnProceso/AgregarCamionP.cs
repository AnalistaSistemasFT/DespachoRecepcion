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

namespace WFConsumo.frmGRH.DespachoOrdenEnProceso
{
    public partial class AgregarCamionP : DevExpress.XtraEditors.XtraForm
    {
        public AgregarCamionP()
        {
            InitializeComponent();
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtMarca.Text) || (!string.IsNullOrEmpty(txtMarca.Text)))
            {
                if (!string.IsNullOrWhiteSpace(txtPlaca.Text) || (!string.IsNullOrEmpty(txtPlaca.Text)))
                {
                    if (!string.IsNullOrWhiteSpace(txtCapacidad.Text) || (!string.IsNullOrEmpty(txtCapacidad.Text)))
                    {
                        try
                        {
                            CCatChofer cCamion = new CCatChofer();
                            CatCamion _camion = new CatCamion();
                            _camion._Placa = txtPlaca.Text;
                            _camion._Marca = txtMarca.Text;
                            _camion._Capacidad = Convert.ToDecimal(txtCapacidad.Text);
                            cCamion.GuardarCamion(_camion);
                            //
                            XtraMessageBox.Show("Camion agregado", "Guardar");
                            this.Close();
                        }
                        catch (Exception err)
                        {
                            XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                            Console.WriteLine("####################### = " + err.ToString());
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("El campo de 'Capacidad' esta vacio", "Error");
                    }
                }
                else
                {
                    XtraMessageBox.Show("El campo de 'Placa' esta vacio", "Error");
                }
            }
            else
            {
                XtraMessageBox.Show("El campo de 'Marca' esta vacio", "Error");
            }
            
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AgregarCamion_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.OpenForms["frmEditarDespachoP"].Enabled = true;
            }
        }
    }
}