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
    public partial class frmABMItem : Form
    {
        CItem oitem;
        CItemF oItemF;
        public frmABMItem()
        {
            InitializeComponent();
            oitem = new CItem();
            oItemF = new CItemF();
            CargarCombos();
        }

        private void CargarCombos()
        {
            DataSet dts1 = oitem.TraerGrupoProducto();
            DataSet dts2 = oitem.TraerGrupoItem();
            DataSet dts3 = oitem.TraerCat_Calidad();
            DataSet dts4 = oitem.TraerCatUnidad();
            DataSet dts5 = oitem.TraerNaturaleza();
            DataSet dts6 = oitem.TraerSeguimiento();
            DataSet dts7 = oitem.TraerTipoGalvanizado();
            DataSet dts8 = oitem.TraerSucursal();

          

            this.cbseguimiento.DataSource = dts6.Tables[0]; 
            this.cbseguimiento.DisplayMember = "descripcionLarga";
            this.cbseguimiento.ValueMember = "Id_DimSeguimiento";
            this.cbseguimiento.SelectedIndex = -1;

            this.cbtipomaterial.DataSource = dts2.Tables[0];
            this.cbtipomaterial.DisplayMember = "Descripcion";
            this.cbtipomaterial.ValueMember = "GrupoId";
            this.cbtipomaterial.SelectedIndex = -1;

            this.cbtipogalva.DataSource = dts7.Tables[0];
            this.cbtipogalva.DisplayMember = "Descripcion";
            this.cbtipogalva.ValueMember = "Id_Tipo";
            this.cbtipogalva.SelectedIndex = -1;

            this.cbpresentacion.DataSource = dts5.Tables[0];
            this.cbpresentacion.DisplayMember = "Naturaleza"; 
            this.cbpresentacion.ValueMember = "NaturalezaId";
            this.cbpresentacion.SelectedIndex = -1;

            this.cbgrupo.DataSource = dts1.Tables[0];
            this.cbgrupo.DisplayMember = "Descripcion"; 
            this.cbgrupo.ValueMember = "ID_GrupoProducto";
            this.cbgrupo.SelectedIndex = -1;

            this.cbcalidad.DataSource = dts3.Tables[0];
            this.cbcalidad.DisplayMember = "Descripcion";
            this.cbcalidad.ValueMember = "ID_Calidad";
            this.cbcalidad.SelectedIndex = -1;

            this.cbum.DataSource = dts4.Tables[0];
            this.cbum.DisplayMember = "Descripcion"; 
            this.cbum.ValueMember = "Unidad";
            this.cbum.SelectedIndex = -1;

            this.cbumf.DataSource = dts4.Tables[0];
            this.cbumf.DisplayMember = "Descripcion";
            this.cbumf.ValueMember = "Unidad";
            this.cbumf.SelectedIndex = -1;


        }

        private void frmABMItem_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //CRN.Entidades.Item oItemp = new CRN.Entidades.Item();
            //oItemp.ItemId = txtitem.Text.Trim();
            //oItemp.Descripcion = txtdescitem.Text.Trim();
            //oItemp.CapKilos = Conve.(txtCapacidadKg.Text.Trim());
            //oItemp.CapVertical = Convert.(txtAnchoPaq.Text.Trim());
            //oItemp.CapHorizontal = Convert.ToDecimal(txtdescitem.Text.Trim());
            //oItemp.PesoPaq = Convert.ToDecimal(txtPesoPaq.Text.Trim());
            //oItemp.Piezas = Convert.ToDecimal(txtNumPieza.Text.Trim());
            //oItemp.Ancho = Convert.ToDecimal(txtAnchoPaq.Text.Trim());
            //oItemp.GrupoId = Convert(cbgrupo.SelectedValue);
            //oItemp.ItemFId = txtdescitem.Text.Trim();
            //oItemp.Calidad = txtdescitem.Text.Trim();
            //oItemp.Espesor = txtes.Text.Trim();
            //oItemp.Uso = txtdescitem.Text.Trim();
            //oItemp.Presentacion = Convert.ToDecimal(txtdescitem.Text.Trim());
            //oItemp.TipoMaterial Convert.ToDecimal(txtdescitem.Text.Trim());
            //oItemp.Unidad = txtdescitem.Text.Trim();
            //oItemp.Piramide = Convert.ToDecimal(txtdescitem.Text.Trim());
            //oItemp.UnidadesXCelda = Convert.ToDecimal(txtdescitem.Text.Trim());
            //oItemp.UnidadCalculo = txtdescitem.Text.Trim());
            //oItemp.Caducidad = Convert.toInt(txtdescitem.Text.Trim());

        }

        private void cbtipogalva_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbseguimiento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtitemf_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsNumber(e.KeyChar))//(e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
            
                if (Convert.ToInt32(e.KeyChar) == 13)
                {
                    if (!string.IsNullOrEmpty(txtitemf.Text))
                    {

                        if (oitem.VerificarItem(txtitemf.Text.Trim()) == 0)
                        {
                            DataSet dtsItemF = oItemF.TraerItemF(Convert.ToInt32(txtitemf.Text));
                            if (dtsItemF.Tables[0].Rows.Count > 0)
                            {
                                txtdescf.Text = dtsItemF.Tables[0].Rows[0]["scmadesc"].ToString();
                                txtdescitem.Text = dtsItemF.Tables[0].Rows[0]["scmadesc"].ToString();
                            }
                            else
                            {
                                txtdescf.Text = string.Empty;
                                txtdescitem.Text = string.Empty;
                            }
                        }
                        else
                            MessageBox.Show("COLADA YA EXISTE FAVOR REVISAR");
                    }
                }
            
        }

        private void txtCaducidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }
    }
}
