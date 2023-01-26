
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRN.Componentes;
using CRN.Entidades;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;


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



        private void cbtipogalva_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbseguimiento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtitemf_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar))//(e.KeyChar != (char)Keys.Back)
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
                        MessageBox.Show("ITEM YA EXISTE FAVOR REVISAR");
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

        private void Insertar()
        {
           //decimal CapKilo = Convert.ToDecimal(txtCapacidadKg.Text);
            Item oItemp = new Item();
            oItemp.ItemId = txtitem.Text.Trim();
            oItemp.Descripcion = txtdescitem.Text.Trim();
            oItemp.CapKilos = Convert.ToDecimal(txtCapacidadKg.Text);
            oItemp.CapVertical = Convert.ToInt32(txtanchomax.Text.Trim());
            oItemp.CapHorizontal = Convert.ToInt32(txtalturamax.Text.Trim());
            oItemp.PesoPaq = Convert.ToDecimal(txtPesoPaq.Text.Trim());
            oItemp.Piezas = Convert.ToInt32(txtNumPieza.Text.Trim());
            oItemp.Ancho = Convert.ToDecimal(txtAnchoPaq.Text.Trim());
            oItemp.GrupoId = cbtipomaterial.SelectedValue.ToString();
            oItemp.ItemFId = txtitemf.Text.Trim();
            oItemp.Calidad = cbcalidad.SelectedValue.ToString();
            oItemp.Espesor = Convert.ToDecimal(txtespesor.Text.Trim());
            oItemp.Uso = "";
            oItemp.Presentacion = Convert.ToInt32(cbpresentacion.SelectedValue.ToString());
            oItemp.TipoMaterial = Convert.ToInt32(cbgrupo.SelectedValue.ToString());
            oItemp.Unidad = cbumf.SelectedValue.ToString();

            oItemp.Piramide = Convert.ToInt32(cbxpiramide.Checked == true ? 1 : 0);
            oItemp.UnidadesXCelda = Convert.ToInt32(txtunicel.Text.Trim());
            oItemp.UnidadCalculo = cbum.SelectedValue.ToString();
            oItemp.Caducidad = Convert.ToInt32(txtCaducidad.Text.Trim());
            oItemp.Id_DimSeguimiento = Convert.ToInt32(cbseguimiento.SelectedValue.ToString());
            oItemp.Id_TipoGalvanizado = 1;
            CItem citem = new CItem();
            citem.GuardarItem(oItemp);

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(cbseguimiento.SelectedValue.ToString()) && !string.IsNullOrEmpty(txtitem.Text.ToString()) && !string.IsNullOrEmpty(txtdescitem.Text.ToString()) && !string.IsNullOrEmpty(txtCaducidad.Text.ToString()))
                {
                    Insertar();
                    MessageBox.Show("Codigo creado corectamente");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("CAMPOS NO VALIDOS");
                }
            }
            catch (Exception ex)
            {
                throw ex;
                MessageBox.Show("Problemas En La Transaccion..."+ex.Message);
            }


        }
    }
}
