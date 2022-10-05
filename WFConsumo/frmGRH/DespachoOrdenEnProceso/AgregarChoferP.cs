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
    public partial class AgregarChoferP : DevExpress.XtraEditors.XtraForm
    {
        public AgregarChoferP()
        {
            InitializeComponent();
            TerminacionesCB();
        }
        private void TerminacionesCB()
        {
            comboBoxCI.Properties.Items.Add("CH");
            comboBoxCI.Properties.Items.Add("LP");
            comboBoxCI.Properties.Items.Add("CB");
            comboBoxCI.Properties.Items.Add("OR");
            comboBoxCI.Properties.Items.Add("PT");
            comboBoxCI.Properties.Items.Add("TJ");
            comboBoxCI.Properties.Items.Add("SC");
            comboBoxCI.Properties.Items.Add("BE");
            comboBoxCI.Properties.Items.Add("PD");
            comboBoxCI.Properties.Items.Add("N/A");
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNombre.Text) || (!string.IsNullOrEmpty(txtNombre.Text)))
            {
                if (!string.IsNullOrWhiteSpace(txtCI.Text) || (!string.IsNullOrEmpty(txtCI.Text)))
                {
                    if (!string.IsNullOrWhiteSpace(comboBoxCI.SelectedText) || (!string.IsNullOrEmpty(comboBoxCI.SelectedText)))
                    {
                        try
                        {
                            CCatChofer cChofer = new CCatChofer();
                            CatChofer _chofer = new CatChofer();
                            _chofer.nombre = txtNombre.Text;
                            _chofer.ci = txtCI.Text;
                            _chofer.procedencia = comboBoxCI.Text;
                            cChofer.GuardarChofer(_chofer);
                            //
                            XtraMessageBox.Show("Chofer agregado", "Guardar");
                            this.Close();
                        }
                        catch(Exception err)
                        {
                            XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                            Console.WriteLine("####################### = " + err.ToString());
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
            else
            {
                XtraMessageBox.Show("El campo de 'Nombre' esta vacio", "Error");
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AgregarChofer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.OpenForms["frmEditarDespachoP"].Enabled = true;
            }
        }
    }
}