using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
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
    public partial class frmAnotacion : DevExpress.XtraEditors.XtraForm
    {
        CCamion oCamion = new CCamion();
        CChofer oChofer = new CChofer();
        CFabricante oFabricante = new CFabricante();
        CCeldas oCelda = new CCeldas();
        CSucursal oSucursal = new CSucursal();
        DataSet dtsFabricante = new DataSet();
        DataSet dtsCeldas = new DataSet();
        CItem oItem = new CItem();
        public frmAnotacion()
        {
            InitializeComponent();
            txtpropietario.Visible = false;
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
            d.Columns.Add("sLote");
            d.Columns.Add("Fecha");
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
            gridView1.Columns["FechaCaducidad"].Caption = "Fecha Vec.";
            gridView1.Columns["sLote"].Caption = "Lote";
            gridView1.Columns["Fecha"].Caption = "Fecha Fab";

            gridView1.Columns["AnotacionId"].Visible = false;
            gridView1.Columns["Fabricante"].Visible = false;
            gridView1.Columns["CeldaId"].Visible = false;
            gridView1.Columns["Sincronizado"].Visible = false;
            gridView1.Columns["Peso"].Visible = false;
            // gridView1.Columns["FechaCaducidad"].Visible = false;

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
            gridView1.Columns["Fecha"].Width = 60;
            gridView1.Columns["FechaCaducidad"].Width = 60;
            gridView1.Columns["sLote"].Width = 60;

            gridView1.Columns["FechaCaducidad"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView1.Columns["FechaCaducidad"].DisplayFormat.FormatString = "dd/MM/yyyy";

            gridView1.Columns["Fecha"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView1.Columns["Fecha"].DisplayFormat.FormatString = "dd/MM/yyyy";
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
            txtci.Text = this.cbchofer.SelectedValue.ToString();

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
                
                //view1.SetRowCellValue(ee.RowHandle, view.Columns[14], "01-01-2023");
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
            if (cbxcliente.Checked == true)
                oAntacion.Procedencia1 = 0;
            oAntacion.Propietario1 = cbfabricante.GetItemText(cbfabricante.SelectedItem);
            oAntacion.Obs1 = txtobs.Text;
            oAntacion.Correlativo1 = 0;
            oAntacion.Status1 = "INPROCESS";
            oAntacion.SucursalId1 = Entidades.utilitario.iSucursal;
            oAntacion.Tipo1 = "0";
            oAntacion.EsDeCliente1 = cbxcliente.Checked;
            oAntacion.Manifiesto1 = txtmanifiesto.Text;
            oAntacion.Login1 = Entidades.utilitario.sUsuario;
            DataTable ds;
            ds = (DataTable)griddetalle.DataSource;
            string sCelda = cbcelda.GetItemText(cbcelda.SelectedItem);
            string sError = string.Empty;
            if (oAntacion.InsertarAnotacion(out sError, ds, sCelda, Entidades.utilitario.sUsuario, Entidades.utilitario.iSucursal, Entidades.utilitario.iAlmacen) > 0)
                MessageBox.Show("se genero con exito", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else
                MessageBox.Show("problemas en la transaccion .." + sError, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void cbxcliente_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxcliente.Checked == true)
            {
                label6.Text = "Propietario";
                cbprocedencia.Visible = false;
                txtpropietario.Visible = true;
            }
            else
            {
                label6.Text = "Procedencia";
                cbprocedencia.Visible = true;
                txtpropietario.Visible = false;
            }
        }

        DataSet ds = new DataSet();
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                openFileDialog.Filter = "Archivos Excel(*.xls;*.xlsx)|*.xls;*xlsx|Todos los archivos(*.*)|*.*";
                if (openFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    string sRuta = openFileDialog.FileName;
                    OleDbConnection con = Conectar(sRuta);
                    CargarHojas(con);
                    CargarExcel(con, cbHojas.SelectedValue.ToString());
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString()); }
        }

        void CargarExcel(OleDbConnection con, string sHojas)
        {
            ds = Consultar("select * from [" + sHojas + "]", con);
            ds = EliminarFilasSobrantes(ds);
            DataTable dt2 = new DataTable();
            dt2 = griddetalle.DataSource as DataTable;
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow datarow;
                CAD.CADInformix oItemInf = new CAD.CADInformix();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    datarow = dt2.NewRow();
                    datarow["CodigoBarra"] = ds.Tables[0].Rows[i]["CodigoBarra"].ToString();
                    datarow["AnotacionId"] = txtanotacion.Text;
                    datarow["Fabricante"] = cbfabricante.GetItemText(cbfabricante.SelectedItem);
                    datarow["CeldaId"] = cbcelda.GetItemText(cbcelda.SelectedItem);

                    datarow["ItemFId"] = ds.Tables[0].Rows[i]["ItemId"].ToString();
                    string sItemF = ds.Tables[0].Rows[i]["ItemId"].ToString();
                    DataSet dtsItem = oItem.ConsultarItenF(sItemF);
                    if (dtsItem.Tables[0].Rows.Count > 0)
                    {
                        datarow["ItemId"] = dtsItem.Tables[0].Rows[0]["ItemId"].ToString();
                        string sFechaCad = ds.Tables[0].Rows[i]["FechaVec"].ToString();
                        if (!string.IsNullOrEmpty(sFechaCad))
                            datarow["FechaCaducidad"] = sFechaCad;
                        else
                            datarow["FechaCaducidad"] = DateTime.Now.AddDays(Convert.ToInt32(dtsItem.Tables[0].Rows[0]["Caducidad"].ToString()));
                    }

                    else
                    {
                        MessageBox.Show("Codigo No Registrado En el Pry " + sItemF);
                        griddetalle.DataSource = null;
                        break;
                    }
                    datarow["Piezas"] = ds.Tables[0].Rows[i]["Piezas"].ToString();
                    DataSet dtsItemF = oItemInf.ConsultarItem(Convert.ToInt32(sItemF));
                    if (dtsItemF.Tables[0].Rows.Count > 0)
                    {
                        datarow["sdesc"] = dtsItemF.Tables[0].Rows[0]["scmadesc"].ToString();
                        decimal dPeso = Convert.ToDecimal(ds.Tables[0].Rows[i]["Peso"].ToString());
                        if (dPeso == 0)
                        {
                            dPeso = Convert.ToDecimal(ds.Tables[0].Rows[i]["Piezas"].ToString()) * Convert.ToDecimal(dtsItemF.Tables[0].Rows[0]["scmapeso"].ToString());
                            datarow["Peso"] = dPeso;
                            datarow["PesoBrutoProveedor"] = dPeso;
                            datarow["PesoNetoProveedor"] = dPeso;
                        }
                        else
                        {
                            datarow["Peso"] = dPeso;
                            datarow["PesoBrutoProveedor"] = dPeso;
                            datarow["PesoNetoProveedor"] = dPeso;
                        }
                    }
                    datarow["CodPackList"] = ds.Tables[0].Rows[i]["Packinglist"].ToString();
                    datarow["Colada"] = ds.Tables[0].Rows[i]["Colada"].ToString();

                    datarow["Sincronizado"] ="0";

                    datarow["sLote"] = ds.Tables[0].Rows[i]["Lote"].ToString();
                    string sFechaFab = ds.Tables[0].Rows[i]["FechaFab"].ToString();
                    if (!string.IsNullOrEmpty(sFechaFab))
                        datarow["Fecha"] = sFechaFab;
                    else
                        datarow["Fecha"] = DateTime.Now;
                    dt2.Rows.Add(datarow);
                }
                //griddetalle.DataSource = ds.Tables[0];
            }
            else
            { griddetalle.DataSource = null; }
        }
        void CargarHojas(OleDbConnection con)
        {
            DataTable dt = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            if (dt.Rows.Count > 0)
            {
                cbHojas.DataSource = dt;
                cbHojas.ValueMember = "TABLE_NAME";
                cbHojas.DisplayMember = "TABLE_NAME";
            }
        }

        OleDbConnection Conectar(string path)
        {
            string CadenaConexion = ("Provider=Microsoft.ACE.OLEDB.12.0;" + ("Data Source=" + (path + ";Extended Properties=\"Excel 12.0;Xml;HDR=YES;IMEX=2\";")));
            OleDbConnection con = new OleDbConnection(CadenaConexion);
            con.Open();
            return con;
        }

        DataSet Consultar(string csql, OleDbConnection con)
        {
            OleDbDataAdapter da = new OleDbDataAdapter(csql, con);
            DataSet ConjuntoDatos = new DataSet();
            da.Fill(ConjuntoDatos);
            con.Close();
            con.Dispose();
            return ConjuntoDatos;
        }

        DataSet EliminarFilasSobrantes(DataSet ds)
        {
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                if (i != 4)
                {
                    string aa = ds.Tables[0].Rows[i]["CodigoBarra"].ToString();
                    if (string.IsNullOrEmpty(ds.Tables[0].Rows[i]["CodigoBarra"].ToString()))
                    {
                        ds.Tables[0].Rows[i].Delete();
                    }
                }
            }
            ds.Tables[0].AcceptChanges();
            return ds;
        }

    }
}
