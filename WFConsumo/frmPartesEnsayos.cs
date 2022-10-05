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
    public partial class frmPartesEnsayos : Form
    {
        CEnsayo ensayoV;
        PartesEnsayos partes;
        CPartesEnsayos partesensayos;
        private string consulta;        
        private int idEnsayo;
        private int idparteensayolocal;
        private int ID_Empleado;
        public frmPartesEnsayos(int idPadreRegistro,int idparteensayo,int IdUser)
        {
            InitializeComponent();
            
            ID_Empleado = IdUser;
            ensayoV = new CEnsayo();
            partesensayos = new CPartesEnsayos();
            CargarDataCombos();
            BloquearDesbloquearCampos(0);
            idEnsayo = idPadreRegistro;
            this.txtensayo.Text = idEnsayo.ToString();
            this.labelX2.Text = idparteensayo.ToString();
            idparteensayolocal = idparteensayo;
        }
        private void colorPickerDropDown2_SelectedColorChanged(object sender, EventArgs e)
        {

        }
        private void superTabControl1_SelectedTabChanged(object sender, DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs e)
        {

        }
        private void frmPartesEnsayos_Load(object sender, EventArgs e)
        {
        }
        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void CargarDataCombos() 
        {
           
            DataSet data1 = ensayoV.retornarEnsayo1();
            this.comboUnidad.DataSource = data1.Tables[0];
            this.comboUnidad.DisplayMember = "Descripcion";
            this.comboUnidad.ValueMember = "Unidad";

            
            DataSet data2 = ensayoV.retornarEnsayo2();
            this.comboTabla.DataSource = data2.Tables[0];
            this.comboTabla.DisplayMember = "Descripcion";
            this.comboTabla.ValueMember = "TablaId";
            this.comboTabla.SelectedValue = 0;

        }
        private void buttonX3_Click(object sender, EventArgs e)
        {
            //AGREGAR NUEVO
            partes= new PartesEnsayos();
            try
            {
                string parametroN = this.txtparametro.Text.ToString();
                int tipodato = this.cdato.Text.ToString() == "Numerico" ? 0 : (this.cdato.Text.ToString() == "Booleano" ? 1 : 2);
                bool esformula = radioButton2.Checked;
                bool obligatorio = this.checkBoxX1.Checked;
                string formula = this.txtformula.Text.ToString();
                string unidad = this.comboUnidad.SelectedValue!=null?this.comboUnidad.SelectedValue.ToString():"";
                bool habilitalimitemin = this.minimo.Enabled;
                decimal limitemin = this.minimo.Enabled ? decimal.Parse(this.minimo.Text) : 0;
                bool habilitalimitemax = this.maximo.Enabled;
                decimal limitemax = this.maximo.Enabled ? decimal.Parse(this.maximo.Text) : 0;
                string procedimient = this.txtprod.Text;
                bool habilitalimitetab = this.radioButton7.Checked;
                int tablaid = this.comboTabla.SelectedValue != null ? int.Parse(this.comboTabla.SelectedValue.ToString()) : 0;
                string campotabla = this.comboCampo.SelectedValue != null ? this.comboCampo.SelectedValue.ToString() : "";
                partes.Nombre = parametroN;
                partes.Tipodato = tipodato;
                partes.Esformula = esformula;
                partes.Obligatorio = obligatorio;
                partes.Formula = formula;
                partes.Unidad = unidad;
                partes.Habilitalimitemin = habilitalimitemin;
                partes.Habilitelimitemax = habilitalimitemax;
                partes.Limiteminaprob = limitemin;
                partes.Limitemaxaprob = limitemax;
                partes.Procedimiento = procedimient;
                partes.Habilitalimitetabla = habilitalimitetab;
                partes.TablaId = tablaid;
                partes.Campotabla = campotabla;             
                partes.TipoId = idEnsayo;
                if (idparteensayolocal == 0)
                {
                    int posicionid = RetornarPosicion(0);
                    partes.Posicion = posicionid + 1;
                    partesensayos.GuardarPartesEnsayos(partes);
                    MessageBox.Show("AGREGADO CORRECTAMENTE","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    int posicionid = RetornarPosicion(idparteensayolocal);
                    partes.Posicion = posicionid;
                    partes.ParametroID = idparteensayolocal;
                    partesensayos.ModificarParteEnsayo(partes);
                    MessageBox.Show("ACTUALIZADO CORECTAMENTE","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                this.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show("Compruebe que los datos esten correctos correctamente Msg => "+ee.Message,"",MessageBoxButtons.OK,MessageBoxIcon.Warning);  
            }
        }
        private int RetornarPosicion(int idparteensayo) 
        {
            int s = 0;
            DataSet data4;
            if (idparteensayo == 0)
            {
                string consulta = String.Format("select count(*) from tblTipoEnsayoParam   where tipoid={0}", idEnsayo);
                data4 = ensayoV.retornarEnsayo(consulta);               
                
            }
            else 
            {
                string consulta = String.Format("select Posicion from tblTipoEnsayoParam   where Parametroid={0}", idparteensayo);
                data4 = ensayoV.retornarEnsayo(consulta);              
                        
            }
            foreach (DataRow item in data4.Tables[0].Rows)
            {
                s = int.Parse(item[0].ToString());
            }
            return s;
            
        }
        private void comboTabla_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int id = int.Parse(this.comboTabla.SelectedValue.ToString());
            CargarComboCampo(id);
        }
        public void CargarComboCampo(int id)
        {
            /*consulta = String.Format("select distinct LPR_EX_GROUP_CODE as grupo,LPF_FEATURE as Campo from ([ElsystemNet_Ferrotodo].dbo.MES_TB_LST_PRODUCT left join " +
                                    " [ElsystemNet_Ferrotodo].dbo.MES_TB_LST_PRODUCT_FEATURE on LPR_PRODUCT_CODE=LPF_PRODUCT_CODE) inner join " +
                                    " [ElsystemNet_Ferrotodo].dbo.MES_TB_LST_PRODUCT_GROUPS on CGR_GROUP_CODE=LPR_EX_GROUP_CODE inner join " +
                                   " tblCatTabla on TipoProducto=LPR_EX_GROUP_CODE Where tablaId ={0} order by lpf_feature  ", id);*/
            DataSet data3 = ensayoV.dataCombo(id);
            this.comboCampo.DataSource = data3.Tables[0];
            // SE GUARDA Y MUESTRA AMBOS 
            this.comboCampo.DisplayMember = "Campo";
            this.comboCampo.ValueMember = "Campo";
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.txtformula.Text = "".ToString();
            this.txtformula.Enabled = false;
            this.buttonX1.Enabled = false;
        }
        public void BloquearDesbloquearCampos(int comboId)
        {
            switch (comboId)
            {
                case 0:
                    //NO REQUIERE LIMITES
                    this.comboTabla.Enabled = false;
                    this.minimo.Enabled = false;
                    this.maximo.Enabled = false;
                    this.comboCampo.Enabled = false;
                    break;
                case 1:
                    //CONTROLAR SOLO LIMITE MINIMO
                    this.comboTabla.Enabled = false;
                    this.minimo.Enabled = true;
                    this.maximo.Enabled = false;
                    this.comboCampo.Enabled = false;
                    break;
                case 2:
                    //CONTROLAR SOLO LIMITE MAXIMO
                    this.comboTabla.Enabled = false;
                    this.minimo.Enabled = false;
                    this.maximo.Enabled = true;
                    this.comboCampo.Enabled = false;
                    break;
                case 3:
                    //CONTROLAR LIMITES
                     this.comboTabla.Enabled = false;
                    this.minimo.Enabled = true;
                    this.maximo.Enabled = true;
                    this.comboCampo.Enabled = false;
                    break;
                case 4:
                    //LIMITES CONTROLADOS POR TABLA
                    this.comboTabla.Enabled = true;
                    this.minimo.Enabled = false;
                    this.maximo.Enabled = false;
                    this.comboCampo.Enabled = true;
                    break;
                default:

                    break;
            }
                    
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.txtformula.Enabled = true;
            this.buttonX1.Enabled = true;
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            BloquearDesbloquearCampos(0);
        }
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            BloquearDesbloquearCampos(1);
        }
        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            BloquearDesbloquearCampos(2);
        }
        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            BloquearDesbloquearCampos(3);
        }
        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            BloquearDesbloquearCampos(4);
        }
        private void minimo_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
                if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso
                {
                    e.Handled = false;
                 
                }
                else if (Char.IsPunctuation(e.KeyChar))//teclas de coma o punto
                {
                    e.Handled = false;
                }
                else
                {
                    //el resto de teclas pulsadas se desactivan
                    e.Handled = true;
                }
        }
        private void maximo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
                if (Char.IsControl(e.KeyChar)) 
                {
                    e.Handled = false;

                }
                else if (Char.IsPunctuation(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                   
                    e.Handled = true;
                }
        }
        private void itemPanel2_ItemClick(object sender, EventArgs e)
        {
        }
        private void buttonX1_Click(object sender, EventArgs e)
        {
            string d = "";
            frmGeneradorFormulas genera = new frmGeneradorFormulas();
            genera.ShowDialog();            
            genera.textoA(ref d);
            this.txtformula.Text = d.ToString();
        }

        public void CargarDatospActualizar() 
        {
            try
            {
                //ID PARTE ENSAYO LOCAL ESTA EL REGISTRO A ACTUALIZAR
                //string consulta = String.Format(" SELECT [ParametroId],[TipoId],[Nombre],[EsFormula],[Unidad],[HabilitaLimiteMin],[LimiteMinAprob],[HabilitaLimiteMax],[LimiteMaxAprob]"
                //                             + " ,[Formula],[Procedimiento],[HabilitaLimiteTabla],[TablaId],[tipodato],[Obligatorio],[CampoTabla],[Posicion] FROM [dbo].[tblTipoEnsayoParam] where ParametroId={0}", idparteensayolocal);
                DataSet datalocal = ensayoV.cargarComboActualiza(idparteensayolocal);
                foreach (DataRow item in datalocal.Tables[0].Rows)
                {
                    this.txtparametro.Text = item[2].ToString();

                    if ((bool)item[3])
                    {
                        this.radioButton2.Checked = (bool)item[3];
                        this.radioButton1.Checked = !(bool)item[3];
                        this.txtformula.Enabled = true;
                        this.buttonX1.Enabled = true;
                    }
                    else 
                    {
                        this.radioButton1.Checked = true;
                        this.txtformula.Enabled = false;
                        this.buttonX1.Enabled =false;
                    }                       
                  
                    this.checkBoxX1.Checked = (bool)item[14];
                    this.txtformula.Text = item[9].ToString();
                    this.minimo.Text = item[6].ToString();
                    this.maximo.Text = item[8].ToString();
                    this.comboUnidad.SelectedValue = item[4].ToString();
                    this.comboTabla.SelectedValue = item[12].ToString();

                    this.CargarComboCampo(int.Parse(item[12].ToString()));

                    this.txtprod.Text = item[10].ToString();
                    this.cdato.Text = item[13].ToString() == "0" ? "Numerico".ToString() : (item[13].ToString() == "1" ? "Booleano".ToString() : "Lista");
                    if ((bool)item[5] && (bool)item[7])
                    {
                        this.radioButton6.Checked = true;
                    }
                    else if ((bool)item[11])
                    {
                        this.radioButton7.Checked = true;
                        this.comboCampo.SelectedValue = item[15].ToString();
                    }
                    else
                    {
                        this.radioButton3.Checked = !((bool)item[5] && (bool)item[7]);
                        this.radioButton4.Checked = (bool)item[5];
                        this.radioButton5.Checked = (bool)item[7];
                    }
                }   
            }
            catch (Exception ee)
            {
                MessageBox.Show("Algunos datos no estan correctamente cargados para actualizar => " + ee,"",MessageBoxButtons.OK,MessageBoxIcon.Warning);
               
            }
              
        }
    }
}
