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

namespace WFConsumo.frmGRH.DespachoOrdenAbierta
{
    public partial class BuscarDespacho : DevExpress.XtraEditors.XtraForm
    {
        string _tipoBusqueda;
        public BuscarDespacho()
        {
            InitializeComponent();
            comBoxBuscarPor.Properties.Items.Add("Nro Despacho");
            comBoxBuscarPor.Properties.Items.Add("Fecha");
            comBoxBuscarPor.Properties.Items.Add("Nro Orden");
            comBoxBuscarPor.Properties.Items.Add("Placa");
            comBoxBuscarPor.Properties.Items.Add("Chofer");
            comBoxBuscarPor.Properties.Items.Add("Naturaleza");
            comBoxBuscarPor.Properties.Items.Add("Destino");
            comBoxBuscarPor.Properties.Items.Add("Nro Traspaso");
            checkInicio.Checked = true;
            checkCompleta.Checked = false;
        }
        public DataGridView Dgv { get; set; }
        private void comBoxBuscarPor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int data = comBoxBuscarPor.SelectedIndex;
                if (data != 0)
                {
                    _tipoBusqueda = comBoxBuscarPor.SelectedItem.ToString();
                    if(_tipoBusqueda == "Fecha")
                    {
                        txtBusqueda.Visible = false;
                        txtBusqueda.Text = string.Empty;
                        txtBusqueda.ReadOnly = true;
                        datePick.Visible = true;
                    }
                    else
                    {
                        txtBusqueda.Visible = true;
                        txtBusqueda.ReadOnly = false;
                        datePick.Visible = false;
                    }
                }
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("###############= " + err.ToString());
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if(checkInicio.Checked)
            {

            }
            else if(checkCompleta.Checked)
            {

            }
        }
        private void checkInicio_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkInicio.Checked)
                {
                    checkInicio.Checked = true;
                    checkCompleta.Checked = false;
                }
                else if (checkCompleta.Checked)
                {
                    checkInicio.Checked = false;
                    checkCompleta.Checked = true;
                }
                else
                {
                    checkInicio.Checked = false;
                    checkCompleta.Checked = false;
                }
            }
            catch(Exception err)
            {
                Console.WriteLine("################## = " + err.ToString());
            }
        }
        private void checkCompleta_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkCompleta.Checked)
                {
                    checkCompleta.Checked = true;
                    checkInicio.Checked = false;
                }
                else if (checkInicio.Checked)
                {
                    checkCompleta.Checked = false;
                    checkInicio.Checked = true;
                }
                else
                {
                    checkCompleta.Checked = false;
                    checkInicio.Checked = false;
                }
            }
            catch (Exception err)
            {
                Console.WriteLine("################## = " + err.ToString());
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}