using CRN.Componentes;
using DevExpress.XtraBars;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFConsumo.Recepcion;

namespace WFConsumo
{
    public partial class frmPackingList : DevExpress.XtraEditors.XtraForm
    {
        CPackingList oPackinglist;
        public frmPackingList()
        {

            InitializeComponent();
            CargarGrid();
            //FormatoGrid();
            DataTable d = new DataTable();
            d.Columns.Add("iitem");
            d.Columns.Add("sdesc");
            d.Columns.Add("Colada");
            d.Columns.Add("Serie");
            d.Columns.Add("Cantidad");
            d.Columns.Add("peson");
            d.Columns.Add("pesob");
            d.Columns.Add("Lote");
            d.Columns.Add("FechaFabricacion");
            this.gridControl2.DataSource = d;
        }

        private void CargarGrid()
        {
            oPackinglist = new CPackingList();
            DataSet dtsLista = oPackinglist.ListaPackinglist();
            dgvPackingList.DataSource = dtsLista.Tables[0];
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        
        private void FormatoGrid()
        {
            gridView2.Columns["sNroFac"].Caption = "NroFac";
            gridView2.Columns["iItem_id"].Caption = "Item";
            gridView2.Columns["scmadesc"].Caption = "Descripcion";
            gridView2.Columns["sColada"].Caption = "Colada";
            gridView2.Columns["sSerie"].Caption = "Serie";
            gridView2.Columns["icantidad"].Caption = "Cantidad";
            gridView2.Columns["dPeso"].Caption = "Peso Bruto";
            gridView2.Columns["dPesoNeto"].Caption = "Peso Neto";
            //gridView2.Columns["dPesocc"].Caption = "Peso CC";
            gridView2.Columns["sLote"].Caption = "Lote";
            gridView2.Columns["dtFechaFabricacion"].Caption = "Fecha Fab.";

            gridView2.Columns["idetalle_id"].Visible = false;
            gridView2.Columns["iNroRec"].Visible = false;
            gridView2.Columns["iPedido_id"].Visible = false;
            gridView2.Columns["dtFechaReg"].Visible = false;

            gridView2.Columns["sNroFac"].Width = 80;
            gridView2.Columns["iItem_id"].Width = 50;
            gridView2.Columns["scmadesc"].Width = 170;
            gridView2.Columns["sColada"].Width = 90;
            gridView2.Columns["sSerie"].Width = 90;
            gridView2.Columns["dPeso"].Width = 60;
            gridView2.Columns["dPeso"].Width = 60;
            gridView2.Columns["dPesoNeto"].Width = 60;
           // gridView2.Columns["dPesocc"].Width = 60;
            gridView2.Columns["sLote"].Width = 60;
            gridView2.Columns["dtFechaFabricacion"].Width = 60;
        }

        private void gridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {

        }

        private void gridView3_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            //GridView view = sender as GridView;

            //gridView3.SetRowCellValue(GridControl.NewItemRowHandle, gridView3.Columns["iitem"], "0");
            //gridView3.SetRowCellValue(GridControl.NewItemRowHandle, "sdesc", "0");
            //gridView3.SetRowCellValue(GridControl.NewItemRowHandle, "scolada", "0");
            //gridView3.SetRowCellValue(GridControl.NewItemRowHandle, "sserie", "0");
        }

        //private void gridView4_InitNewRow(object sender, InitNewRowEventArgs e)
        //{
        //    //gridView4.SetRowCellValue(GridControl.NewItemRowHandle, gridView4.Columns["gridColumn1"], "0");
        //}

        //private void gridView4_InitNewRow_1(object sender, InitNewRowEventArgs e)
        //{

        //}

        private void tsGenerar_Click(object sender, EventArgs e)
        {
            if (gridView3.RowCount > 0)
            {
                int sucursalid = Entidades.utilitario.iSucursal;
                SysSecuencia osecuencia = new SysSecuencia();
                frmAnotacion frmanotacion = new frmAnotacion();
                string sAnotacion = osecuencia.TraerSecuencia(sucursalid, "ANOTACION");
                string sPaquete = osecuencia.TraerSecuencia(sucursalid, "PAQUETE");
                frmanotacion.txtanotacion.Text = sAnotacion;
                DataTable dt2 = new DataTable();
                dt2 = frmanotacion.griddetalle.DataSource as DataTable;
                CAnotacion oAnot = new CAnotacion();
                DataSet dtsitem = new DataSet();
                int a = 0;
                string sItem = string.Empty;
                for (int i = 0; i < gridView3.DataRowCount; i++)
                {
                    
                    DataRow row = gridView3.GetDataRow(i);
                    DataRow datarow;
                    datarow = dt2.NewRow();
                    //p.idetalle_id,sNroFac,iNroRec,iPedido_id,iItem_id,m.scmadesc,sColada,sSerie,dPeso,dtFechaReg,dPesoNeto,(dPesoNeto - dPesocc) as dPesocc
                    datarow["CodigoBarra"] = sPaquete;
                    datarow["AnotacionId"] = sAnotacion;
                    datarow["Fabricante"] = "";
                    datarow["CeldaId"] = "";
                    datarow["ItemFId"] = row["iitem"].ToString();
                    dtsitem = oAnot.TraerItemPlanta(row["iitem"].ToString().Trim());
                    if (dtsitem.Tables[0].Rows.Count > 0)
                    {
                        a = 1;
                        datarow["ItemId"] = dtsitem.Tables[0].Rows[0]["ItemId"].ToString().Trim();
                        datarow["FechaCaducidad"] = DateTime.Now.AddDays(Convert.ToInt32(dtsitem.Tables[0].Rows[0]["Caducidad"].ToString()));
                    }
                    else
                    {
                        sItem = row["iitem"].ToString();
                        a = 0;
                        break;
                    }
                    datarow["sdesc"] = row["sdesc"].ToString();
                    datarow["Piezas"] = row["Cantidad"].ToString();
                    datarow["Peso"] = row["peson"].ToString();
                    datarow["CodPackList"] = row["Serie"].ToString();
                    datarow["Colada"] = row["Colada"].ToString();
                    datarow["PesoBrutoProveedor"] = row["pesob"].ToString();
                    datarow["PesoNetoProveedor"] = row["peson"].ToString();
                    datarow["Sincronizado"] ="0";
                    datarow["sLote"] = row["Lote"].ToString();
                    if (!string.IsNullOrEmpty(row["FechaFabricacion"].ToString()))
                        datarow["Fecha"] = row["FechaFabricacion"].ToString();
                    else
                        datarow["Fecha"] = DateTime.Now.ToString("dd/MM/yyyy");
                    dt2.Rows.Add(datarow);
                }
                if(a>0)
                    frmanotacion.ShowDialog();
                else
                    MessageBox.Show("ITEM NO EXISTE EN PLANTA => " + sItem, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            ArrayList rows = new ArrayList();

            // Add the selected rows to the list.
            Int32[] selectedRowHandles = gridView2.GetSelectedRows();
            DataTable dt2 = new DataTable();
            dt2 = gridControl2.DataSource as DataTable;
            for (int i = 0; i < selectedRowHandles.Length; i++)
            {
                int selectedRowHandle = selectedRowHandles[i];
                if (selectedRowHandle >= 0)
                {
                    rows.Add(gridView2.GetDataRow(selectedRowHandle));
                    DataRow row = gridView2.GetDataRow(selectedRowHandle);
                    bool bband = false;
                    if (dt2.Rows.Count > 0)
                    {
                        for (int a = 0; a < gridView3.RowCount; a++)
                        {
                            DataRow row1 = gridView3.GetDataRow(a);
                            string sSerie1 = row["sSerie"].ToString();
                            string sSerie2 = row1["Serie"].ToString();
                            if (sSerie2.Trim() != "0")
                            {
                                if (sSerie1 == sSerie2)
                                    bband = true;
                            }

                        }
                    }
                    if (!bband)
                    {
                        DataRow datarow;
                        datarow = dt2.NewRow();
                        //p.idetalle_id,sNroFac,iNroRec,iPedido_id,iItem_id,m.scmadesc,sColada,sSerie,dPeso,dtFechaReg,dPesoNeto,(dPesoNeto - dPesocc) as dPesocc
                        datarow["iitem"] = row["iItem_id"].ToString();
                        datarow["sdesc"] = row["scmadesc"].ToString();
                        datarow["Colada"] = row["sColada"].ToString();
                        datarow["Serie"] = row["sSerie"].ToString();
                        datarow["Cantidad"] = row["icantidad"].ToString();
                        datarow["peson"] = row["dPesoNeto"].ToString();
                        datarow["pesob"] = row["dPeso"].ToString();
                        datarow["Lote"] = row["sLote"].ToString();
                        datarow["FechaFabricacion"] = row["dtFechaFabricacion"].ToString();
                        dt2.Rows.Add(datarow);
                    }

                }
            }

            try
            {
                gridView2.BeginUpdate();
                for (int i = 0; i < rows.Count; i++)
                {
                    DataRow row = rows[i] as DataRow;
                    //gridView2.DeleteRow(selectedRowHandle);
                    // Change the field value.
                    //row["Discontinued"] = true;
                }
            }
            finally
            {
                gridView2.EndUpdate();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            gridView3.DeleteRow(gridView3.FocusedRowHandle);
        }


        //private void barInsertar_ItemClick(object sender, ItemClickEventArgs e)
        //{

        //}
    }
}