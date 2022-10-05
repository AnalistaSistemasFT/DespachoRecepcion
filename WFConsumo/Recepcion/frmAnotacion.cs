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
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace WFConsumo.Recepcion
{
    public partial class frmAnotacion :  DevExpress.XtraEditors.XtraForm
    {
        CCamion oCamion = new CCamion();
        CChofer oChofer = new CChofer();
        CFabricante oFabricante = new CFabricante();
        CCeldas oCelda = new CCeldas();
        CSucursal oSucursal = new CSucursal();
        DataSet dtsFabricante = new DataSet();
        DataSet dtsCeldas = new DataSet();
        public frmAnotacion()
        {
            InitializeComponent();
            DataTable d = new DataTable();
            d.Columns.Add("CodigoBarra");
            d.Columns.Add("AnotacionId");
            d.Columns.Add("Fabricante");
            d.Columns.Add("CeldaId");
            d.Columns.Add("ItemFId");
            d.Columns.Add("ItemId");
            d.Columns.Add("sdesc");
            d.Columns.Add("Piezas");
            d.Columns.Add("Peso");
            d.Columns.Add("CodPackList");
            d.Columns.Add("Colada");
            d.Columns.Add("PesoBrutoProveedor");
            d.Columns.Add("PesoNetoProveedor");
            d.Columns.Add("Sincronizado");
            d.Columns.Add("FechaCaducidad");
            this.griddetalle.DataSource = d;
           
            CargarCombox();
            FormatoGrid();
        }

        private void FormatoGrid()
        {
            gridView1.Columns["CodigoBarra"].Caption = "Codigo Barra";
            gridView1.Columns["ItemFId"].Caption = "ItemF";
            gridView1.Columns["ItemId"].Caption = "Item";
            gridView1.Columns["sdesc"].Caption = "Desc";
            gridView1.Columns["Piezas"].Caption = "Pieza";
            gridView1.Columns["Peso"].Caption = "Peso";
            gridView1.Columns["CodPackList"].Caption = "Packing";
            gridView1.Columns["Colada"].Caption = "Colada";
            gridView1.Columns["PesoBrutoProveedor"].Caption = "Peso Bruto";
            gridView1.Columns["PesoNetoProveedor"].Caption = "Peso Neto";
            gridView1.Columns["FechaCaducidad"].Caption = "FechaCaducidad";

            gridView1.Columns["AnotacionId"].Visible = false;
            gridView1.Columns["Fabricante"].Visible = false;
            gridView1.Columns["CeldaId"].Visible = false;
            gridView1.Columns["Sincronizado"].Visible = false;

            gridView1.Columns["CodigoBarra"].Width = 80;
            gridView1.Columns["ItemFId"].Width = 50;
            gridView1.Columns["ItemId"].Width = 50;
            gridView1.Columns["sdesc"].Width = 100;
            gridView1.Columns["Piezas"].Width = 60;
            gridView1.Columns["Peso"].Width = 60;
            gridView1.Columns["CodPackList"].Width = 100;
            gridView1.Columns["Colada"].Width = 100;
            gridView1.Columns["PesoBrutoProveedor"].Width = 60;
            gridView1.Columns["PesoNetoProveedor"].Width = 60;
            gridView1.Columns["FechaCaducidad"].Width = 60;

            gridView1.Columns["FechaCaducidad"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView1.Columns["FechaCaducidad"].DisplayFormat.FormatString = "dd/MM/yyyy";
        }
        private void CargarComboxCamion()
        {
            DataSet dtsCamion = oCamion.SeleccionarCamion();
            this.cbplaca.DataSource = dtsCamion.Tables[0];
            this.cbplaca.DisplayMember = "Placa";
            this.cbplaca.ValueMember = "Id_Camion";

        }
        private void CargarComboxChofer()
        {
            DataSet dtsChofer = oChofer.SeleccionarChofer();
            this.cbchofer.DataSource = dtsChofer.Tables[0];
            this.cbchofer.DisplayMember = "Nombre";
            this.cbchofer.ValueMember = "ci";
        }
        private void CargarCombox()
        {
            DataSet dtsCamion = oCamion.SeleccionarCamion();
            this.cbplaca.DataSource = dtsCamion.Tables[0];
            this.cbplaca.DisplayMember = "Placa";
            this.cbplaca.ValueMember = "Id_Camion";
            
            DataSet dtsChofer = oChofer.SeleccionarChofer();
            this.cbchofer.DataSource = dtsChofer.Tables[0];
            this.cbchofer.DisplayMember = "Nombre";
            this.cbchofer.ValueMember = "ci";
            
            DataSet dtsSucursal = oSucursal.SeleccionarSucursal();
            this.cbprocedencia.DataSource = dtsSucursal.Tables[0];
            this.cbprocedencia.DisplayMember = "Nombre";
            this.cbprocedencia.ValueMember = "SucursalID";

            DataSet dtsFabricante = oFabricante.SelectFabricante();
            this.cbfabricante.DataSource = dtsFabricante.Tables[0];
            this.cbfabricante.DisplayMember = "Nombre";
            this.cbfabricante.ValueMember = "ProveedorId";

            DataSet dtsCeldas = oCelda.CargarCelda(Entidades.utilitario.iSucursal);
            this.cbcelda.DataSource = dtsCeldas.Tables[0];
            this.cbcelda.DisplayMember = "celdaid";
            this.cbcelda.ValueMember = "celdaid";
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbchofer_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string display = cbchofer.GetItemText(cbchofer.SelectedItem);
            txtci.Text= this.cbchofer.SelectedValue.ToString();
           
        }

        private void cbplaca_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataSet dtsCam = oCamion.SeleccionarCamionId(Convert.ToInt32(cbplaca.SelectedValue.ToString()));
            txtCamion.Text = dtsCam.Tables[0].Rows[0]["Marca"].ToString();
        }


        private void griddetalle_DataSourceChanged(object sender, EventArgs e)
        {
            //cargando datasourc
            ColumnView view = this.griddetalle.MainView as ColumnView;
            //int row = view.RowCount;
            //int col = view.Columns.Count;
            //RepositoryItemTextEdit _text = new RepositoryItemTextEdit();
            RepositoryItemComboBox _riEditor1 = new RepositoryItemComboBox();
            RepositoryItemComboBox _riEditor2 = new RepositoryItemComboBox();
            
            string[] sFabricantes;
            string[] sCeldas;
            dtsCeldas = oCamion.TraerCeldas(Entidades.utilitario.iAlmacen);
            dtsFabricante = oCamion.TraerFabricantes();
            sFabricantes = new string[dtsFabricante.Tables[0].Rows.Count];
            sCeldas = new string[dtsCeldas.Tables[0].Rows.Count];
            for (int i = 0; i < dtsFabricante.Tables[0].Rows.Count; i++)
            {
                sFabricantes[i] = dtsFabricante.Tables[0].Rows[i]["Nombre"].ToString();
            }
            for (int i = 0; i < dtsCeldas.Tables[0].Rows.Count; i++)
            {
                sCeldas[i] = dtsCeldas.Tables[0].Rows[i]["CeldaId"].ToString();
            }

           
            gridView1.CustomRowCellEdit += (senda, ee) =>
            {
                GridView view1 = senda as GridView;
                if (ee.Column.FieldName == "Fabricante")
                {
                    _riEditor1.Items.AddRange(sFabricantes);
                    //int boolVal = int.Parse(view1.GetRowCellValue(ee.RowHandle, "TipoDato").ToString());
                    //if (boolVal == 1)
                    ee.RepositoryItem = _riEditor1;
                    
                }
                if (ee.Column.FieldName == "CeldaId")
                {
                    _riEditor2.Items.AddRange(sCeldas);
                    //int boolVal = int.Parse(view1.GetRowCellValue(ee.RowHandle, "TipoDato").ToString());
                    //if (boolVal == 1)
                    ee.RepositoryItem = _riEditor2;
                }
                view1.SetRowCellValue(ee.RowHandle, view.Columns[14], "01-01-2023");
            };
        }

        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            CAnotacion oAntacion = new CAnotacion();
            oAntacion.AnotacionId1 = txtanotacion.Text;
            oAntacion.Fecha1 = dtpfecha.Value;
            oAntacion.Chofer1 = cbchofer.Text;
            string display = cbplaca.GetItemText(cbplaca.SelectedValue);
            oAntacion.Id_Camion1 = Convert.ToInt32(display);
            oAntacion.Placa1 = cbplaca.GetItemText(cbplaca.SelectedItem); 
            oAntacion.CI1 = txtci.Text;
            oAntacion.Procedencia1 = Convert.ToInt32(cbprocedencia.SelectedValue);
            oAntacion.Propietario1 = cbfabricante.GetItemText(cbfabricante.SelectedItem);
            oAntacion.Obs1 = txtobs.Text;
            oAntacion.Correlativo1 = 0;
            oAntacion.Status1 = "INPROCESS";
            oAntacion.SucursalId1 = Entidades.utilitario.iSucursal;
            oAntacion.Tipo1 = "0";
            oAntacion.EsDeCliente1 = cbxcliente.Checked;
            oAntacion.Manifiesto1 = txtmanifiesto.Text;
            DataTable ds;
            ds = (DataTable)griddetalle.DataSource;
            string sCelda = cbcelda.GetItemText(cbcelda.SelectedItem);
            string sError = string.Empty;
            if (oAntacion.InsertarAnotacion(out sError,ds, sCelda, Entidades.utilitario.sUsuario, Entidades.utilitario.iSucursal, Entidades.utilitario.iAlmacen) >0)
                MessageBox.Show("se genero con exito", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else
                MessageBox.Show("problemas en la transaccion .."+sError, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            this.Close();
        }

        private void VerificarPackinglist(DataTable ds)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnPlaca_Click(object sender, EventArgs e)
        {
            Catalogos.frmAdmCamion ofrmcamion = new Catalogos.frmAdmCamion();
            ofrmcamion.ShowDialog();
            CargarComboxCamion();
         }

        private void btnChofer_Click(object sender, EventArgs e)
        {
            Catalogos.frmAdmChofer ofrmchofer = new Catalogos.frmAdmChofer();
            ofrmchofer.ShowDialog();
            CargarComboxChofer();
        }
    }
}
