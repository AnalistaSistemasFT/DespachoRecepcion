using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFConsumo
{
    public partial class FrmCentroTrabajosEscoger : Form
    {
        public FrmCentroTrabajosEscoger()
        {
            InitializeComponent();
        }
        public string seleecionado;
        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                seleecionado = "Panel A";
            else if (radioButton2.Checked)
                seleecionado = "Panel B";
            else if (radioButton3.Checked)
                seleecionado = "Mallao";
            else if (radioButton4.Checked)
                seleecionado = "Resorte A";
            else if (radioButton5.Checked)
                seleecionado = "Resorte B";
            else if (radioButton6.Checked)
                seleecionado = "Resorte C";

            if (seleecionado.Equals(""))
                MessageBox.Show("Selecciones un Centro de Trabajo para ingresar a esta seccion !", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
                this.Close();
        }

        private void FrmCentroTrabajosEscoger_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (seleecionado==null)
                seleecionado = "";
            this.Close();
            
        }
    }
}
