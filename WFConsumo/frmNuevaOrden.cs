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
    public partial class frmNuevaOrden : Form
    {
        COrdenProduccion prod;
        OrdenProduccion opp;
        private int Empleado;
        private int iTipo;
        private Usuario User;
        public frmNuevaOrden(string item,string grupo,string orden,string centro,int EmpleadoId,int iTipo,Usuario u)
        {
            InitializeComponent();
            opp=new OrdenProduccion();
            prod = new COrdenProduccion();
            Empleado = EmpleadoId;
            this.CargarCombos();
            this.txtitem.Text = item.ToString();
            this.txtgrupo.Text = grupo.ToString();
            this.txtcentro.Text = centro.ToString();
            this.txtorden.Text = orden.ToString();
            iTipo = iTipo;
            User = u;
        }        
        private void frmNuevaOrden_Load(object sender, EventArgs e)
        {
        }
        private void CargarCombos() 
        {
            string consulta = "select * from Cat_Operaciones  order by Descripcion";
            DataSet d = prod.retornarTabla(consulta);
            this.comboOpe.DataSource = d.Tables[0];
            this.comboOpe.DisplayMember="Descripcion";
            this.comboOpe.ValueMember="Id_Operacion";
            this.comboOpe.SelectedValue = 0;
            consulta = "select * from centros";
        }        
        private void buttonX2_Click(object sender, EventArgs e)
        {
            //NUEVO
        }
        private void buttonX3_Click(object sender, EventArgs e)
        {
            //CANCELARS
            this.Close();
        }
        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                //ACEPTAR
                opp.CentroId = this.txtcentro.Text.ToString();
                opp.EmpleadoId = Empleado;
                opp.ID_Orden = this.txtorden.Text.ToString();
                opp.FechaEstado = DateTime.Now;
                opp.Fecha = DateTime.Now;
                opp.Estado = 0;
                //this.txtgrupo.Text
                opp.TipoEnsayo = this.txtgrupo.Text.ToString();
                opp.Operacion = 0;
                opp.ItemId = this.txtitem.Text.ToString();
                opp._Usuario = User.Login;
                prod.GuardarTablaNuevo(opp);
                MessageBox.Show("EL Orden se creo correctamente " , "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                if(iTipo == 1) { 
                    frmOrdenAbiertaNew frmNew = new frmOrdenAbiertaNew(this.txtcentro.Text.ToString(), User);
                    frmNew.Show();
                }
            }
            catch (Exception EEE)
            {
                MessageBox.Show("Hubo un error al realizar la consulta => "+EEE.Message,"",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void comboBoxEx2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
