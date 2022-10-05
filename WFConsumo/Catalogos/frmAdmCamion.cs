using CRN.Componentes;
using CRN.Entidades;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFConsumo.Catalogos
{
    public partial class frmAdmCamion : Form
    {
        public frmAdmCamion()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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
                            _camion._Placa = txtPlaca.Text+"-"+txtExt.Text;
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
                        XtraMessageBox.Show("El campo de 'Placa' esta vacio", "Error");
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
