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
    public partial class frmMateriaPrima : Form
    {
        ProduccionDetalle prodDet;
        COrdenProduccionV2 corden;
        CProduccionMateriaPrima cmateria;
        private string itemS, ordS;
        public frmMateriaPrima(string ord,string item,string operador,int tipo)
        {
            InitializeComponent();
            prodDet = new ProduccionDetalle();
            corden = new COrdenProduccionV2();
            cmateria = new CProduccionMateriaPrima();
            this.itemS = item;
            this.ordS = ord;
            textBox1.Text = ord;
            this.textBox7.Text = itemS;
            this.textBox10.Text = operador;
            cargarextras();
            this.comboBox3.SelectedIndex = tipo;
            this.comboBox2.SelectedIndex = 1;
            this.comboBox1.SelectedIndex = 1;
            this.comboBox4.SelectedIndex = 1;
        }
        void cargarextras() 
        {
            try
            {
                if (this.itemS.Length > 0)
                {
                    string cons = String.Format("select ItemId,Descripcion from tblItem where ItemId = '{0}'", this.itemS);
                    var resp = corden.retornarTabla(cons);
                    string sContador = resp.Tables[0].Rows[0]["Descripcion"].ToString();
                    this.textBox3.Text = sContador;
                }    
            }
            catch (Exception error)
            {
                MessageBox.Show("Debe seleccionar una orden antes de cargar la materia prima !!!!","INFORMATION",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                this.Close();
            }               
        }
        private void frmMateriaPrima_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            //GUARDAMOS MATERIA PRIMA EN TBLPRODUCCIONDETALLE
            try
            {
                if (this.textBox4.Text.ToString().Length > 0 && this.textBox2.Text.ToString().Length > 0 && this.textBox5.Text.ToString().Length > 0 && this.textBox6.Text.ToString().Length > 0
                     && this.comboBox4.SelectedItem!=null && this.comboBox1.SelectedItem != null && this.comboBox2.SelectedItem!=null)
                {
                    this.prodDet.ordenid = this.textBox1.Text.ToString();
                    this.prodDet.itemid = this.textBox7.Text.ToString();
                    this.prodDet.descitem = this.textBox3.Text.ToString();
                    this.prodDet.paqueteid = this.textBox2.Text.ToString();
                    this.prodDet.peso = decimal.Parse(this.textBox4.Text.ToString());
                    this.prodDet.piezas = decimal.Parse(this.textBox5.Text.ToString());
                    this.prodDet.metros = decimal.Parse(this.textBox6.Text.ToString());
                    this.prodDet.unidadmedida = this.comboBox4.SelectedItem.ToString();
                    this.prodDet.operador = this.textBox10.Text.ToString();
                    this.prodDet.fechainicial = this.dateTimePicker1.Value.ToString("dd/MM/yyyy");
                    this.prodDet.fechafinal = this.dateTimePicker2.Value.ToString("dd/MM/yyyy");
                    this.prodDet.turno = this.comboBox1.SelectedItem.ToString();
                    this.prodDet.tipo = this.comboBox3.SelectedItem.ToString() == "CONSUMIDO" ? "C" : "P";
                    this.prodDet.estado = this.comboBox2.SelectedItem.ToString();
                    //guardar datos en la bd en esta parte
                    cmateria.guardarmateriaPrima(this.prodDet);
                    MessageBox.Show("DATOS GUARDADOS CORRECTAMENTE .", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                    MessageBox.Show("DEBE DE LLENAR TODOS LOS CAMPOS REQUERIDOS, E INTENTELO NUEVAMENTE .","INFORMATION",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            catch (Exception ee)
            {
                MessageBox.Show("VERIFIQUE HABER LLENADO TODOS LOS CAMPOS CON LOS DATOS CORRECTOS POR FAVOR .","INFORMATION",MessageBoxButtons.OK,MessageBoxIcon.Stop);
            }      
        }
        private void button3_Click(object sender, EventArgs e)
        {
            //buscar paqueteid
            string cons=String.Format(" select * from tblpaquetes where tblpaquetes.paqueteid='{0}'",this.textBox2.Text.ToString());
            var resp = corden.retornarTabla(cons);
            if(resp.Tables[0].Rows.Count>0)
            {
                this.textBox4.Text = resp.Tables[0].Rows[0]["Peso"].ToString();
                this.textBox5.Text = resp.Tables[0].Rows[0]["Piezas"].ToString();
                this.textBox6.Text = resp.Tables[0].Rows[0]["Metros"].ToString();
            }      
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
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
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
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
        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
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
