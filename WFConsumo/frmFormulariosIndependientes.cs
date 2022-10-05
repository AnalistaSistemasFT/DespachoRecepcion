using CRN.Componentes;
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
    public partial class frmFormulariosIndependientes : Form
    {
        CConforme objintermediario;
        public frmFormulariosIndependientes()
        {
            InitializeComponent();
            objintermediario = new CConforme();
            llenargrids1();
            llenargrids2();
            llenargrids3();
            llenargrids4();
            llenargrids5();
        }
        public void llenargrids1() 
        {
            string consulta = "select * from tbltipoincidente";
            DataSet data = objintermediario.Ejecutarsentencias(consulta);
            this.gridControl1.DataSource = data.Tables[0];
        }
        public void llenargrids2()
        {
            string consulta = "select * from tbltiponoconformidad";
            DataSet data = objintermediario.Ejecutarsentencias(consulta);
            this.gridControl2.DataSource = data.Tables[0];
        }
        public void llenargrids3()
        {
            string consulta = "select * from tbltiporesultado";
            DataSet data = objintermediario.Ejecutarsentencias(consulta);
            this.gridControl3.DataSource = data.Tables[0];
        }
        public void llenargrids4()
        {
            string consulta = "select * from tblareaproceso";
            DataSet data = objintermediario.Ejecutarsentencias(consulta);
            this.gridControl4.DataSource = data.Tables[0];
        }
        public void llenargrids5()
        {
            string consulta = "select * from tblestado";
            DataSet data = objintermediario.Ejecutarsentencias(consulta);
            this.gridControl5.DataSource = data.Tables[0];
        }
        private void buttonX1_Click(object sender, EventArgs e)
        {
            string desc=this.textBoxX1.Text.ToString();
            string consulta = String.Format("insert into tbltipoincidente (sdescripcion) values ('{0}')",desc);
            if (!objintermediario.Ejecutarconsulta(consulta)) 
            {
                MessageBox.Show("HUBO UN ERROR AL GUARDAR LA INFORMACION");
            }
            llenargrids1();
        }
        private void buttonX2_Click(object sender, EventArgs e)
        {
            string analisis = this.textBoxX2.Text.ToString();
            string desc = this.textBoxX3.Text.ToString();
            string consulta = String.Format("insert into tbltiponoconformidad (sabreviacion,sdescripcion) values ('{0}','{1}')", analisis,desc);
            if (!objintermediario.Ejecutarconsulta(consulta))
            {
                MessageBox.Show("HUBO UN ERROR AL GUARDAR LA INFORMACION");
            }
            llenargrids2();
        }
        private void buttonX3_Click(object sender, EventArgs e)
        {
            string desc = this.textBoxX4.Text.ToString();
            string consulta = String.Format("insert into tbltiporesultado (sdescripcion) values ('{0}')",desc);
            if (!objintermediario.Ejecutarconsulta(consulta))
            {
                MessageBox.Show("HUBO UN ERROR AL GUARDAR LA INFORMACION");
            }
            llenargrids3();
        }
        private void xtraTabControl1_Click(object sender, EventArgs e)
        {
        }
        private void buttonX4_Click(object sender, EventArgs e)
        {
            string desc = this.textBoxX5.Text.ToString();
            string consulta = String.Format("insert into tblareaproceso (sdescripcion) values ('{0}')", desc);
            if (!objintermediario.Ejecutarconsulta(consulta))
            {
                MessageBox.Show("HUBO UN ERROR AL GUARDAR LA INFORMACION");
            }
            llenargrids4();
        }
        private void buttonX5_Click_1(object sender, EventArgs e)
        {
            string desc = this.textBoxX6.Text.ToString();
            string consulta = String.Format("insert into tblestado (sdescricpion) values ('{0}')", desc);
            if (!objintermediario.Ejecutarconsulta(consulta))
            {
                MessageBox.Show("HUBO UN ERROR AL GUARDAR LA INFORMACION");
            }
            llenargrids5();
        }
        private void xtraTabPage3_Paint(object sender, PaintEventArgs e)
        {
        }

        private void labelX13_Click(object sender, EventArgs e)
        {
            this.Close();
        }    
    }
}
