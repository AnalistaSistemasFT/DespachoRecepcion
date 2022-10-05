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
using CRN.Entidades;
namespace WFConsumo
{
    public partial class frmNuevoEnsayo : Form
    {
        CEnsayo ensayoN;
        Ensayo objetoEnsayo;
        CObjeto objeto;
        private int Id_Empleado;
        public frmNuevoEnsayo(int idUser)
        {
            InitializeComponent();
            Id_Empleado = idUser;
            ensayoN = new CEnsayo();
            objeto=new CObjeto();
            CargarDatos();        
        }
        private void frmNuevoEnsayo_Load(object sender, EventArgs e)
        {
        }
        public void CargarDatos()
        {
            string operacinesConsulta = "SELECT [Id_Operacion],[Descripcion],[ElsystemId] FROM [dbo].[Cat_Operaciones]";

            DataSet data = ensayoN.retornarEnsayo(operacinesConsulta);       
        
            this.comboOperacion.DataSource = data.Tables[0];
            this.comboOperacion.DisplayMember = "Descripcion";
            this.comboOperacion.ValueMember = "Id_Operacion";

            operacinesConsulta = "SELECT [FGR_GROUP] as grupo,[FGR_DESC] as descripcion from [ElsystemNet_Ferrotodo].[dbo].[MES_TB_GEN_FEATURE_GROUP] where FGR_ENTITY='PRODUCT'";
            DataSet data2 = ensayoN.retornarEnsayo(operacinesConsulta);
            this.comboGrupo.DataSource = data2.Tables[0];
            this.comboGrupo.DisplayMember = "grupo";
            this.comboGrupo.ValueMember = "grupo";

            operacinesConsulta = "SELECT [PeriodoId],[Descripcion] FROM [dbo].[tblCatPeriodTarea]";
            DataSet data3 = ensayoN.retornarEnsayo(operacinesConsulta);
            this.comboTiempo.DataSource = data3.Tables[0];
            this.comboTiempo.DisplayMember = "Descripcion";
            this.comboTiempo.ValueMember = "PeriodoId";

        }
        private void labelX2_Click(object sender, EventArgs e)
        {

        }
        private void buttonX3_Click(object sender, EventArgs e)
        {
            //Aumentar
            this.textBoxX4.Text = Convert.ToString((int.Parse(this.textBoxX4.Text.ToString()) + 1)) ;
        }
        private void buttonX4_Click(object sender, EventArgs e)
        {
            //Decrementar
            this.textBoxX4.Text =int.Parse(this.textBoxX4.Text.ToString()) > 1 ? (int.Parse(this.textBoxX4.Text.ToString()) - 1)+"" : "1";

        }
        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                string idGr = this.comboGrupo.Text.ToString();
                int idoP = int.Parse(this.comboOperacion.SelectedValue.ToString());
                int tiempo = int.Parse(this.comboTiempo.SelectedValue.ToString());
                string descripcion = this.textBoxX2.Text;
                
                int frecuencia = int.Parse(textBoxX3.Text);
                int NroTomas = int.Parse(textBoxX4.Text);
                objetoEnsayo = new Ensayo();
                objetoEnsayo.GrupO = idGr;
                objetoEnsayo.Frecuencia = frecuencia;
                objetoEnsayo.TomasXFrrecuenciA = NroTomas;
                objetoEnsayo.DescripcioN = descripcion;
                objetoEnsayo.UnidadFrecenciA = tiempo;
                objetoEnsayo.OperacioneS = idoP;
                
                //  string consulta = String.Format("Insert into [dbo].[tblTipoEnsayo] ([Descripcion],[Frecuencia],[UnidadFrecuencia],[Grupo],[TomasXFrecuencia],[Operacion]) values ('{0}',{1},{2},'{3}',{4},{5})  ",descripcion,frecuencia,tiempo,idGr,NroTomas,idoP);
                if (this.textBoxX1.Text.ToString() == "")
                {
                    //AGREGAR NUEVO
                    ensayoN.GuardarEnsayoNuevo(objetoEnsayo);
                    MessageBox.Show("AGREGADO CORRECTAMENTE","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    objetoEnsayo.TipoId = int.Parse(this.textBoxX1.Text.ToString());
                    ensayoN.ModificarEnsayo(objetoEnsayo);
                    MessageBox.Show("ACTUALIZADO CORRECTAMENTE","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                this.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show("Hubo un error al realizar la accion, verifique que los datos que ingresa sean correctos. Msg =>"+ee.Message,"",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void LlenarFormulario(int id)
        {
            string consulta = String.Format("SELECT [TipoId],[Descripcion],[Frecuencia],[UnidadFrecuencia],[Grupo],[TomasXFrecuencia],[Operacion] FROM [dbo].[tblTipoEnsayo] where TipoId={0}",id);

            DataSet data = ensayoN.retornarEnsayo(consulta);
            
            foreach (DataRow item in data.Tables[0].Rows)
            {
                this.textBoxX1.Text = item[0].ToString();
                this.textBoxX2.Text=item[1].ToString();
                this.textBoxX4.Text=item[5].ToString();
                this.textBoxX3.Text=item[2].ToString();
                this.comboOperacion.SelectedValue = int.Parse(item[6].ToString());
                this.comboGrupo.SelectedValue = item[4].ToString();
                this.comboTiempo.SelectedValue = int.Parse(item[3].ToString());
            }

        }

        private void textBoxX4_TextChanged(object sender, EventArgs e)
        {
            int n=0;
            try
            {
              //  string digito = this.textBoxX4.Text.ToString().Substring(this.textBoxX4.Text.ToString().Length - 1, 1);
              //  if (!Int32.TryParse(digito, out n))
              //  {
              //      this.textBoxX4.Text = this.textBoxX4.Text.ToString().Substring(0, this.textBoxX4.Text.Length - 1);
              //  }
                if (digitoNoValido != "")
                {
                    this.textBoxX4.Text = this.textBoxX4.Text.Replace(digitoNoValido, "");
                }
            }
            catch (Exception)
            {
            }
            digitoNoValido = "";
            this.textBoxX4.SelectionStart = this.textBoxX4.Text.Length;
         
        }
        private string digitoNoValido = "";
        private void textBoxX3_TextChanged(object sender, EventArgs e)
        {
            int n = 0;
            try
            {
                if (digitoNoValido != "") 
                {
                    this.textBoxX3.Text = this.textBoxX3.Text.Replace(digitoNoValido, "");                
                }
               // string digito = this.textBoxX3.Text.ToString().Substring(this.textBoxX3.Text.ToString().Length - 1, 1);
               // if (!Int32.TryParse(digito, out n))
              //  {
               //     this.textBoxX3.Text = this.textBoxX3.Text.ToString().Substring(0, this.textBoxX3.Text.Length - 1);
              //  }
            }
            catch (Exception)
            {
            }
            digitoNoValido = "";
            this.textBoxX3.SelectionStart = this.textBoxX3.Text.Length;
        }

        private void textBoxX3_KeyPress(object sender, KeyPressEventArgs e)
        {
            string d = e.KeyChar.ToString();
            if (e.KeyChar >= 48 && e.KeyChar <= 57)
            {
            }
            else 
            {
                digitoNoValido = d;
            }
            
        }

        private void textBoxX3_CursorChanged(object sender, EventArgs e)
        {
            
        }

        private void textBoxX4_KeyPress(object sender, KeyPressEventArgs e)
        {
            string d = e.KeyChar.ToString();
            if (e.KeyChar >= 48 && e.KeyChar <= 57)
            {
            }
            else
            {
                digitoNoValido = d;
            }
        }
    }
}
