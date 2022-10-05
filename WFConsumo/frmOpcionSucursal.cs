using CRN.Componentes;
using CRN.Entidades;
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
    public partial class frmOpcionSucursal : Form
    {
        CUsuario Udata;
        public frmOpcionSucursal()
        {
            InitializeComponent();
            CargarCombo();
            buttonX1.Enabled = false;
        }


        public void CargarCombo()
        {
            Udata = new CUsuario();
            DataSet dt = Udata.DataSucursalxUsuario(Entidades.utilitario.sUsuario);
            this.cbxsucursal.DataSource = dt.Tables[0];
            this.cbxsucursal.DisplayMember = "Nombre";
            this.cbxsucursal.ValueMember = "SucursalId";
            this.cbxsucursal.SelectedIndex = -1;
        }
        frmMain menu;
        private string sucursal = "";
        private void buttonX1_Click(object sender, EventArgs e)
        {
            sucursal = cbxsucursal.SelectedValue.ToString();
            Entidades.utilitario.iSucursal = Convert.ToInt32(sucursal);
           
            Udata = new CUsuario();
            DataSet dt = Udata.DataAlmacenxUsuario(Convert.ToInt32(sucursal));
            if (dt.Tables[0].Rows.Count>0)
                Entidades.utilitario.iAlmacen = Convert.ToInt32(dt.Tables[0].Rows[0]["AlmacenId"].ToString());
            sucursal = cbxsucursal.GetItemText(cbxsucursal.SelectedItem);
            this.Close();
        }
        public void prueba(ref string sucurs) 
        {
            sucurs = sucursal;
        }

        private void cbxsucursal_SelectedValueChanged(object sender, EventArgs e)
        {
            buttonX1.Enabled = true;
        }
    }
}
