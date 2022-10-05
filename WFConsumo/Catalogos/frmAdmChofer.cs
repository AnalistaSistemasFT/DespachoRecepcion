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
    public partial class frmAdmChofer : Form
    {
        public frmAdmChofer()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNombre.Text) || (!string.IsNullOrEmpty(txtNombre.Text)))
            {
                if (!string.IsNullOrWhiteSpace(txtCi.Text) || (!string.IsNullOrEmpty(txtCi.Text)))
                {
                    if (!string.IsNullOrWhiteSpace(cbExt.Text) || (!string.IsNullOrEmpty(cbExt.Text)))
                    {
                        try
                        {
                            CCatChofer cChofer = new CCatChofer();
                            CatChofer _chofer = new CatChofer();
                            _chofer.nombre = txtNombre.Text;
                            _chofer.ci = txtCi.Text;
                            _chofer.procedencia = cbExt.Text;
                            cChofer.GuardarChofer(_chofer);
                            //
                            XtraMessageBox.Show("Chofer agregado", "Guardar");
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
                        XtraMessageBox.Show("El campo de 'Ext.' esta vacio", "Error");
                    }
                }
                else
                {
                    XtraMessageBox.Show("El campo de 'Nombre' esta vacio", "Error");
                }
            }
            else
            {
                XtraMessageBox.Show("El campo de 'Nombre' esta vacio", "Error");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
