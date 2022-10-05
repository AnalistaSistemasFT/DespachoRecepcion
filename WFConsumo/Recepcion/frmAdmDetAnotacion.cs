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

namespace WFConsumo.Recepcion
{
    public partial class frmAdmDetAnotacion : Form
    {
        string sAnotacion;
        CFabricante oFabricante = new CFabricante();
        CCeldas oCelda = new CCeldas();
        int iTipoTra = 0;
        string Paquete;
        public frmAdmDetAnotacion(string Anotacion,int iTipoT)
        {
            InitializeComponent();
            sAnotacion = Anotacion;
            txtNro.Text = Anotacion;
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Enabled = false;
            txtNro.Enabled = false;
            iTipoTra = iTipoT;
            CargarCombox();
            
        }
        public frmAdmDetAnotacion(string Anotacion, int iTipoT,string sPaquete)
        {
            InitializeComponent();
            sAnotacion = Anotacion;
            txtNro.Text = Anotacion;
            Paquete = sPaquete;
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Enabled = false;
            txtNro.Enabled = false;
            iTipoTra = iTipoT;
            CargarCombox();
            if (iTipoT == 2)
                TraerDatosPaquete(Paquete);
        }

        private void CargarCampos()
        {
            CAnotacionDet oAnotDet = new CAnotacionDet();
            DataSet dtsPaquete = oAnotDet.SelectAnotacionDet(Paquete);

        }
        private void CargarCombox()
        {
            DataSet dtsFabricante = oFabricante.SelectFabricante();
            this.cbFabricante.DataSource = dtsFabricante.Tables[0];
            this.cbFabricante.DisplayMember = "Nombre";
            this.cbFabricante.ValueMember = "ProveedorId";

            DataSet dtsCeldas = oCelda.CargarCelda(Entidades.utilitario.iSucursal);
            this.cbCelda.DataSource = dtsCeldas.Tables[0];
            this.cbCelda.DisplayMember = "celdaid";
            this.cbCelda.ValueMember = "celdaid";
        }
        private void TraerDatosPackingList(string sPacking)
        {
            CPackingList oPackinglist = new CPackingList();
            DataSet dtsPacking = oPackinglist.ListaPackinglisxSerie(sPacking);
            if (dtsPacking.Tables[0].Rows.Count > 0)
            {
                btnAceptar.Visible = true;
                string sItemF = dtsPacking.Tables[0].Rows[0]["iItem_id"].ToString();
                string sColada = dtsPacking.Tables[0].Rows[0]["sColada"].ToString();
                string sSerie = dtsPacking.Tables[0].Rows[0]["sSerie"].ToString();
                decimal dPesoB = Convert.ToDecimal(dtsPacking.Tables[0].Rows[0]["dPeso"].ToString());
                decimal dPesoN = Convert.ToDecimal(dtsPacking.Tables[0].Rows[0]["dPesoNeto"].ToString());
                txtPack.Text = sSerie;
                txtColada.Text = sColada;
                txtPesoBruto.Text = dPesoB.ToString();
                txtPesoNeto.Text = dPesoN.ToString();
                txtPesoBal.Text = dPesoN.ToString();
                txtPiezas.Text = "1";
                CAD.CADItem oItem = new CAD.CADItem();
                DataSet dtsItemP = oItem.BuscarItemFerro(sItemF);
                if (dtsItemP.Tables[0].Rows.Count > 0)
                {
                    string sItemP = dtsItemP.Tables[0].Rows[0]["ItemId"].ToString();
                    string sDescricpion = dtsItemP.Tables[0].Rows[0]["Descripcion"].ToString();
                    txtItem.Text = sItemP;
                    txtDesc.Text = sDescricpion;
                }
                else
                {
                    MessageBox.Show("El Codigo "+sItemF +", no existe en pdv");
                }
                //DataSet dtsFabricante = oFabricante.SelectFabricantePorNombre();
            }
            else {
                txtPack.Text = string.Empty;
                txtColada.Text = string.Empty;
                txtPesoBruto.Text = string.Empty;
                txtPesoNeto.Text = string.Empty;
                txtPesoBal.Text = string.Empty;
                txtPiezas.Text = string.Empty;
                btnAceptar.Visible = false;
                MessageBox.Show("no se encontro ningun dato");
            }
                
        }

        private void TraerDatosPaquete(string Paquete)
        {
            //CPackingList oPackinglist = new CPackingList();
            CAnotacionDet oPackinglist = new CAnotacionDet();
            DataSet dtsPacking = oPackinglist.SelectAnotacionDet(Paquete);
            if (dtsPacking.Tables[0].Rows.Count > 0)
            {
                // CodigoBarra AnotacionId Fabricante ItemId  Piezas Peso    Colada SucursalId  AlmacenId CeldaId Fecha Correlativo Login Status  CodPackList PesoNetoProveedor   PesoBrutoProveedor EsDeCliente Sincronizado FechaCaducidad

                txtNro.Text = dtsPacking.Tables[0].Rows[0]["AnotacionId"].ToString();
                txtCodigoBarra.Text = dtsPacking.Tables[0].Rows[0]["CodigoBarra"].ToString();
                txtPack.Text = dtsPacking.Tables[0].Rows[0]["CodPackList"].ToString();
                cbstatus.SelectedItem = dtsPacking.Tables[0].Rows[0]["status"].ToString();
                txtItem.Text = dtsPacking.Tables[0].Rows[0]["ItemId"].ToString();
                txtColada.Text = dtsPacking.Tables[0].Rows[0]["Colada"].ToString();
                txtPesoBruto.Text = dtsPacking.Tables[0].Rows[0]["PesoBrutoProveedor"].ToString();
                txtPesoNeto.Text = dtsPacking.Tables[0].Rows[0]["PesoNetoProveedor"].ToString();
                txtPesoBal.Text = dtsPacking.Tables[0].Rows[0]["Peso"].ToString();
                txtPiezas.Text = dtsPacking.Tables[0].Rows[0]["Piezas"].ToString();
                cbCelda.SelectedValue = dtsPacking.Tables[0].Rows[0]["CeldaId"].ToString();
                DataSet dtsFabricante = oFabricante.SelectFabricantePorNombre(dtsPacking.Tables[0].Rows[0]["Fabricante"].ToString());
                cbFabricante.SelectedValue = dtsFabricante.Tables[0].Rows[0]["ProveedorId"].ToString();
                //txtObs.Text = dtsPacking.Tables[0].Rows[0]["CeldaId"].ToString();
                CAD.CADItem oItem = new CAD.CADItem();
                DataSet dtsItemP = oItem.BuscarItemFerro(dtsPacking.Tables[0].Rows[0]["ItemId"].ToString());
                if (dtsItemP.Tables[0].Rows.Count > 0)
                {
                    string sItemP = dtsItemP.Tables[0].Rows[0]["ItemId"].ToString();
                    string sDescricpion = dtsItemP.Tables[0].Rows[0]["Descripcion"].ToString();
                    txtItem.Text = sItemP;
                    txtDesc.Text = sDescricpion;
                }
            }
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
           
            int a = 0;
            string sMensaje = string.Empty;
            if (iTipoTra == 1) {
                CAnotacionDet oAnotDet = new CAnotacionDet();
                if (oAnotDet.VerificarColada(txtColada.Text.Trim()) == 0)
                {
                    a = InsertPaqueteDetalle();
                    sMensaje = "Paquete Creado Correctamente";
                }
                else
                    MessageBox.Show("COLADA YA EXISTE FAVOR REVISAR");
            }
            if (iTipoTra == 2) 
            {
                sMensaje = "Se Modifico Correctamente";
                a = UpdatePaqueteDetalle();
            }
                
            if (a > 0)
                MessageBox.Show(sMensaje);
                
                else
                MessageBox.Show("Problemas en la transaccion");
            this.Close();
        }

        private int InsertPaqueteDetalle()
        {
            SysSecuencia osecuencia = new SysSecuencia();
            CAnotacionDet oAnotDet = new CAnotacionDet();
            string sError = string.Empty;
            string sPaquete = osecuencia.TraerSecuencia(Entidades.utilitario.iSucursal, "PAQUETE");
            oAnotDet.CodigoBarra1 = sPaquete;
            oAnotDet.AnotacionId1 = sAnotacion;
            oAnotDet.Fabricante1 = this.cbFabricante.SelectedValue.ToString();
            oAnotDet.ItemId1 = txtItem.Text;
            oAnotDet.Piezas1 = Convert.ToInt32(txtPiezas.Text);
            oAnotDet.Peso1 = Convert.ToDecimal(txtPesoNeto.Text);
            oAnotDet.Colada1 = txtColada.Text;
            oAnotDet.SucursalId1 = Entidades.utilitario.iSucursal;
            oAnotDet.AlmacenId1 = Entidades.utilitario.iAlmacen;
            oAnotDet.CeldaId1 = cbCelda.SelectedValue.ToString();
            oAnotDet.Fecha1 = dateTimePicker1.Value;
            oAnotDet.Correlativo1 = 1 + 1;
            oAnotDet.Login1 = Entidades.utilitario.sUsuario;
            oAnotDet.Status1 = "OPEN";
            oAnotDet.CodPackList1 = txtPack.Text;
            oAnotDet.PesoNetoProveedor1 = Convert.ToDecimal(txtPesoNeto.Text);
            oAnotDet.PesoBrutoProveedor1 = Convert.ToDecimal(txtPesoBruto.Text);
            oAnotDet.EsDeCliente1 = false;
            oAnotDet.Sincronizado1 = false;
            oAnotDet.FechaCaducidad1 = dateTimePicker2.Value;
            
                return oAnotDet.InsertAnotacionDet(out sError);
            

        }

        private int UpdatePaqueteDetalle()
        {
            
            CAnotacionDet oAnotDet = new CAnotacionDet();
            string sError = string.Empty;
            return oAnotDet.UpdateAnotacionDet(txtCodigoBarra.Text.Trim(),"OPEN");

        }

        private void txtPack_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                if(!string.IsNullOrEmpty(txtPack.Text))
                {
                    CAnotacionDet oAnotDet = new CAnotacionDet();
                    if (oAnotDet.VerificarColada(txtPack.Text.Trim()) == 0)
                    {
                        TraerDatosPackingList(txtPack.Text);
                    }
                    else
                        MessageBox.Show("COLADA YA EXISTE FAVOR REVISAR");
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
