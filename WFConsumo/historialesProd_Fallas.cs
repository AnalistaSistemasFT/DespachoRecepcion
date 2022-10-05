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
    public partial class historialesProd_Fallas : Form
    {
        CSector csec = new CSector();
        private int tipoS;
        public historialesProd_Fallas(int tipo)
        {
        
      
            InitializeComponent();
            tipoS = tipo;
            if(tipo==1)
            {
                cargarproduccion(" ");
            } else
                cargarfallasprod(" ");
                      
            
        }
        public void cargarproduccion(string condicion) 
        {
            this.labelX5.Text =" HISTORIAL DE PRODUCCION ";
            string sentencia = "select * from tblproduccion " +condicion;
            DataSet dd = csec.retornarTabla(sentencia);
            this.gridControl1.DataSource = dd.Tables[0];
        }
        public void cargarfallasprod(string sentencia) 
        {
            this.labelX5.Text = " HISTORIAL FALLAS DE MAQUINAS ";
            string consulta = "select p.idparada ,p.scentro, c.parametro_desc as sector ,c1.parametro_desc as ref1, c2.parametro_desc as ref2,p.sobservacion,p.dtiempoparada,p.dtfecha_reg,p.dturno,p.susuario from tblparadamaquinas p inner join " +
                              "cat_parametro c on p.isector_id = c.id_parametro inner join " +
                             " cat_parametro c1 on p.ireferencia_id = c1.id_parametro inner join" +
                            " cat_parametro c2 on p.ireferencia1_id = c2.id_parametro "+sentencia;
            // where p.dtfecha_reg BETWEEN '{0} 00:00:00' AND  '{1} 23:59:59'
            DataSet ddd = csec.retornarTabla(consulta);
            this.gridControl1.DataSource = ddd.Tables[0];            
        }
        private void button2_Click(object sender, EventArgs e)
        {           
            //cargarfallasprod(String.Format("where p.dtfecha_reg BETWEEN '{0} 00:00:00' AND  '{1} 23:59:59'",date,date1));
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string date = this.dateEdit1.SelectedText.ToString();
                string date1 = this.dateEdit4.SelectedText.ToString();
                if (tipoS == 1)
                    cargarproduccion(String.Format("where dtfecha BETWEEN '{0} 00:00:00' AND  '{1} 23:59:59'", date, date1));
                else
                    cargarfallasprod(String.Format("where p.dtfecha_reg BETWEEN '{0} 00:00:00' AND  '{1} 23:59:59'", date, date1));
            }
            catch (Exception ee)
            {
                MessageBox.Show("Intente nuevamente cargando las fechas");
            }
           
                          
        }        
        private void labelX4_Click(object sender, EventArgs e)
        {
        }

        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {
            //this.dateEdit4.DateTime = this.dateEdit1.DateTime;
           // int a = (this.dateEdit4.DateTime - this.dateEdit1.DateTime).Days;
            //this.dateEdit1.DateTime.m
        }

        private void labelX8_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
