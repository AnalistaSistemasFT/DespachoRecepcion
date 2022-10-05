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
    public partial class Parametro : Form
    {
        CParametros cparam = new CParametros();
        DataTable dataT = new DataTable();
        public Parametro()
        {
            InitializeComponent();
            string[] op = new string[] { "SE","R1","R2"};
            this.comboBoxEx1.DataSource = op;
            traerParams();
            gridView1.OptionsView.ShowAutoFilterRow = true;
        }
        public void traerParams()
        {
            string sentencia = " select parametro_desc as Parametro, tipo_parametro as TipoParametro from Cat_Parametro";
            DataSet d = cparam.retornarTabla(sentencia);
            dataT = d.Tables[0];            
            this.gridControl1.DataSource = dataT;

            
        }
        private void buttonX1_Click(object sender, EventArgs e)
        {
            //agregamos nuevo parametros
            string tipo = this.comboBoxEx1.SelectedItem.ToString();
            CadParametros param = new CadParametros();

            param.ParamDescrip = this.textBoxX1.Text.ToString();
            param.TipoParam = tipo;
            cparam.GuardarParam(param);
            MessageBox.Show("GUARDADO");
            this.gridControl1.DataSource = null;
            this.textBoxX1.Text = "";
            traerParams();
        }


        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void textBoxX2_TextChanged(object sender, EventArgs e)
        {
            //textocargado
            if (this.textBoxX2.Text.ToString().Length > 0)
            {
                dataT.DefaultView.RowFilter = " Parametro LIKE '%" + this.textBoxX2.Text + "%'";
            }
            else
            {
                dataT.DefaultView.RowFilter = "";
            }
        }
    }
}

