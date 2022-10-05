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
    public partial class FrmVistaSincronizador : Form
    {
        private int indicaador=0;
        CSincronizacion sincrono;
        COrdenProduccionV2 corden;
        CSector regisConex2;
        OrdenProduccionV2 ordV2ñ;
        private int sucursal;
        private string secuencia;
        public FrmVistaSincronizador(string sucursal)
        {
            InitializeComponent();          
            sincrono = new CSincronizacion();
            corden = new COrdenProduccionV2();
            regisConex2 = new CSector();
            ordV2ñ = new OrdenProduccionV2();
            this.sucursal = int.Parse(sucursal);
            cargardata();
           // this.comboBox5.SelectedIndex = 1;
            this.comboBox5.SelectedItem = "10 HECTAREAS";
            this.sucursal = 12081;
        }
        public void TraerSecuencia(int Suscursal, string sTipo)
        {
            string sSelet = String.Format("select  * from Sys_Secuencia where Operacion = '{0}' and sucursal={1}", sTipo, Suscursal);
            DataSet dtsResult = regisConex2.retornarTabla(sSelet);
            string sSecuencia = "";
            if (dtsResult.Tables[0].Rows.Count > 0)
            {
                string sContador = dtsResult.Tables[0].Rows[0]["Contador"].ToString();
                string sFijo = dtsResult.Tables[0].Rows[0]["Fijo"].ToString();
                this.secuencia= dtsResult.Tables[0].Rows[0]["Id_Secuencia"].ToString();
                int iSiguiente = 0;
                string year = "0";
                switch (dtsResult.Tables[0].Rows[0]["Reset"].ToString())
                {
                    case "y":
                        year = (sContador.Substring(1, 2));
                        if (year != (DateTime.Now.Year.ToString().Substring(2, 2)))
                            year = DateTime.Now.Year.ToString().Substring(2, 2);
                        iSiguiente = Convert.ToInt32(sContador.Substring(3, 9)) + 1;
                        sSecuencia = sFijo + year + (iSiguiente.ToString("D9"));
                        break;
                    case "m":
                        year = (sContador.Substring(0, 2));
                        if (year != (DateTime.Now.Year.ToString().Substring(2, 2)))
                            year = DateTime.Now.Year.ToString().Substring(2, 2);
                        string Mes = (sContador.Substring(2, 2));
                        if (Mes != DateTime.Now.Month.ToString())
                            Mes = DateTime.Now.Month.ToString("D2");
                        iSiguiente = Convert.ToInt32(sContador.Substring(6, 5)) + 1;
                        sSecuencia = year + Mes + sFijo + (iSiguiente.ToString("D5"));
                        break;
                }
                this.textBox1.Text = sSecuencia;
            }
            else 
            {
                this.textBox1.Text = "0";
            }            
        }
        public void cargardata() 
        {
            string cons = "select CGR_GROUP_code,CGR_CODE_DESC from [dbo].[MES_TB_LST_PRODUCT_GROUPS]";
            var data = sincrono.recojerdatos(cons);
            this.comboBox1.DataSource = data.Tables[0];
            this.comboBox1.DisplayMember = "CGR_CODE_DESC";
            this.comboBox1.ValueMember = "CGR_GROUP_code";
            cons = String.Format("select * from tblCentroTrabajo");
            data = corden.retornarTabla(cons);
            this.comboBox13.DataSource = data.Tables[0];
            this.comboBox13.DisplayMember = "Nombre";
            this.comboBox13.ValueMember="CentroId";
            //this.comboBox13 TrabaoId Nombre        
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }
        private void labelX1_Click(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            //sincronizamos
            if(this.textBox1.Text.ToString().Length>0&& this.textBox2.Text.ToString().Length>0&& this.textBox3.Text.ToString().Length>0 &&
                this.comboBox1.SelectedItem!=null && this.comboBox2.SelectedItem!=null && this.comboBox3.SelectedItem!=null &&  this.comboBox6.SelectedItem!=null && this.comboBox4.SelectedItem!=null )
            {
                string ordem = this.textBox1.Text.ToString();
                string fabrica = this.comboBox5.SelectedItem.ToString().Equals("10 HECTAREAS") ? "12081" : "12071";
                string centro = this.comboBox13.SelectedValue.ToString();
                string grupo = this.comboBox1.Text.ToString();
                string cantidad = this.textBox2.Text.ToString();
                string fechareg = this.dateTimePicker1.Value.ToString("dd/MM/yyyy");
                string fechaentreg = this.dateTimePicker2.Value.ToString("dd/MM/yyyy");
                string tipo = this.comboBox4.SelectedItem.ToString();
                string desc = this.textBox3.Text.ToString();
                string itemid = this.comboBox2.SelectedValue.ToString();
                string sum = this.comboBox3.SelectedItem.ToString();
                this.ordV2ñ.orden = ordem;
                this.ordV2ñ.fabrica = fabrica;
                this.ordV2ñ.centrotrabajo = centro;
                this.ordV2ñ.grupoProd = grupo;
                this.ordV2ñ.cantidad = cantidad.Replace('.', ',');
                this.ordV2ñ.fechaReg = fechareg;
                this.ordV2ñ.fechaentr = fechaentreg;
                this.ordV2ñ.tipo = tipo;
                this.ordV2ñ.descripcion = desc;
                this.ordV2ñ.sUm = sum;
                this.ordV2ñ.sistemId = itemid;
                this.ordV2ñ.status = this.comboBox6.SelectedItem.ToString();
                
                try
                {
                    this.corden.GuardarTablaNuevo(this.ordV2ñ);
                    string consulta = String.Format("update Sys_Secuencia set Contador='{0}' where sucursal={1} and Id_Secuencia={2}", this.ordV2ñ.orden, this.sucursal, this.secuencia);
                    if (regisConex2.SentenciaEjecut(consulta)) 
                    {
                        MessageBox.Show("GUARDADO CORRECTAMENTE ", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();                    
                    }else
                        MessageBox.Show("EL REGISTRO NO SE GUARDO CORRECTAMENTE, COMPRUEBE QUE LOS DATOS SEAN CORRECTOS E INTENTELO NUEVAMENTE .", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                       
                }
                catch (Exception w)
                {
                    MessageBox.Show("OCURRIO UN ERROR ", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }    
            
            }else
                MessageBox.Show("DEBE DE LLENAR TODOS LOS CAMPOS REQUERIDOS, E INTENTELO NUEVAMENTE .", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                     
        }
        private void button4_Click(object sender, EventArgs e)
        {
           
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {            
          
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //seleccionado item
            if (this.comboBox1.CanSelect) 
            {
                this.comboBox2.Enabled = true;
                var dd = this.comboBox1.SelectedValue.ToString();
                string con = String.Format("select * from [dbo].[MES_TB_LST_PRODUCT] WHERE [LPR_EX_GROUP_CODE] =  '{0}'", dd);
                var dato = sincrono.recojerdatos(con);
                this.comboBox2.DataSource = dato.Tables[0];
                this.comboBox2.DisplayMember="LPR_PRODUCT_DESC";
                this.comboBox2.ValueMember="LPR_PRODUCT_CODE";          
            }                  
        }
        private void labelX8_Click(object sender, EventArgs e)
        {

        }
        private void comboBox13_SelectedIndexChanged(object sender, EventArgs e)
        {
            //seleccionamos el centro de trabaoj
            if (this.comboBox13.CanSelect)
            {
                var dd = this.comboBox13.SelectedValue.ToString();
                TraerSecuencia(this.sucursal, dd);
            }           
        }
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            //aca agarraremos el codigo de la empresa
            if(this.comboBox5.CanSelect)
            {
                string selected = this.comboBox5.SelectedItem.ToString();
                //DON VALENTIN-10 HECTAREAS
                if (selected.Equals("10 HECTAREAS"))
                {
                    this.sucursal = 12081;
                }
                else
                    this.sucursal = 12071;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == ',')
            {
                e.Handled = false;

            }
            else
            {
                e.Handled = true;
            }
        }


    }
}
