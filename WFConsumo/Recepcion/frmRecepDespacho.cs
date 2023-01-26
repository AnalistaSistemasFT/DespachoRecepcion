using CRN.Componentes;
using DevExpress.XtraGrid.Views.Base;
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
using WFConsumo.Reportes;
using WFConsumo.Recepcion;

namespace WFConsumo
{
    public partial class frmRecepDespacho : Form
    {
        
        CCentroTrabajo centrotrab;
        DataTable dataT = new DataTable();
        CRecepcion orecepcion;
        CAnotacion oanotacion = new CAnotacion();
        CCamion oCamion = new CCamion();
        string Despacho = string.Empty;
        string Id_Camion = string.Empty;
        string Placa = string.Empty;
        string CI = string.Empty;

        string Nombre = string.Empty;
        string Propietario = string.Empty;
        string Obs = string.Empty;
        string SucDestino = string.Empty;
        string SucursalId = string.Empty;
        int Orden_Id = 0;
        string _estado = string.Empty;

        List<ItemRecepcion> _itemRecepcion = new List<ItemRecepcion>();

        public frmRecepDespacho(Usuario u,string Estado)
        {
            InitializeComponent();
            orecepcion = new CRecepcion();
            CargaDespachos(Estado);
            Orden_Id = 0;
            _estado = Estado;
        }
        public void CargaDespachos(string Estado) 
        {
            DataSet data = orecepcion.TraerDespachos("Enviado", Entidades.utilitario.iSucursal);
            dataT = data.Tables[0];
            this.gridControl1.DataSource = data.Tables[0];  
        }
        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            //click celda gridcontrol
            ColumnView view = this.gridControl1.MainView as ColumnView;
            int[] row = view.GetSelectedRows();
            if (row.Count() > 0)
            {
                view.FocusedRowHandle = row[0];
                Despacho = (view.GetRowCellDisplayText(row[0], view.Columns[0])).ToString();
                CI = (view.GetRowCellDisplayText(row[0], view.Columns[1])).ToString();
                Nombre = (view.GetRowCellDisplayText(row[0], view.Columns[2])).ToString();
                Id_Camion = (view.GetRowCellDisplayText(row[0], view.Columns[3])).ToString();
                Placa = (view.GetRowCellDisplayText(row[0], view.Columns[4])).ToString();
                Propietario = (view.GetRowCellDisplayText(row[0], view.Columns[5])).ToString();
                Obs = (view.GetRowCellDisplayText(row[0], view.Columns[6])).ToString();
                SucDestino = (view.GetRowCellDisplayText(row[0], view.Columns[7])).ToString();
                SucursalId = (view.GetRowCellDisplayText(row[0], view.Columns[8])).ToString();
                string Orden = view.GetRowCellDisplayText(row[0], view.Columns[9]).ToString();
                Orden_Id = Convert.ToInt32(Orden);
                //d.DespachoId,d.CI,c.Nombre,d.Id_Camion,d.Placa,'FERROTODO' AS Propietario,d.Obs,SucDestino,SucursalId
                DataSet dts = orecepcion.TraerOrdenCargaDetalle(Orden_Id);
                gridControl2.DataSource = dts.Tables[0];
                DataSet dts1 = orecepcion.TraerOrdenDetProd(Orden_Id,0);
                gridControl3.DataSource = dts1.Tables[0];
            }
            else
                Despacho = string.Empty;
        }
        private void tsNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(Despacho))
                {
                    int sucursalid = Entidades.utilitario.iSucursal;
                    SysSecuencia osecuencia = new SysSecuencia();
                    frmRecepcion frmrecepcion = new frmRecepcion();
                    string recepcion = osecuencia.TraerSecuencia(sucursalid, "RECEPCION");
                    frmrecepcion.txtrecepcion.Text = recepcion;
                    frmrecepcion.txtdocumento.Text = Despacho;
                    frmrecepcion.cbochofer.SelectedValue = CI;
                    DataSet dtsCamion = oCamion.SeleccionarCamion(Placa);
                    frmrecepcion.cboplaca.SelectedValue = 0;
                    if (dtsCamion.Tables[0].Rows.Count>0)
                        frmrecepcion.cboplaca.SelectedValue = Convert.ToInt32(dtsCamion.Tables[0].Rows[0]["Id_Camion"]);
                    frmrecepcion.cbofuente.SelectedItem = "TRASPASO";
                    frmrecepcion.cboorigen.SelectedValue = Convert.ToInt32(SucursalId);
                    frmrecepcion.txtpropietario.Text = "INDUSTRIA METALURGICA FERROTODO";
                    frmrecepcion.txtci.Text = CI;
                    frmrecepcion.iOrden = Orden_Id;
                    DataSet dts1 = orecepcion.TraerOrdenDetProd(Orden_Id,0);
                    ////////////////////////////////DespachoId,PaqueteId,d.ItemId,i.Descripcion,Cantidad,Peso
                    _itemRecepcion.Clear();
                    foreach (DataRow item in dts1.Tables[0].Rows)
                    {
                        string _Umed = item[6].ToString();
                        if(_Umed.ToLower() == "kg")
                        {
                            _itemRecepcion.Add(new ItemRecepcion
                            {
                                p_DespachoId = item[0].ToString(),
                                p_PaqueteId = item[1].ToString(),
                                p_ItemId = item[2].ToString(),
                                p_Descripcion = item[3].ToString(),
                                p_Cantidad = Convert.ToInt32(item[4]),
                                p_Peso = Convert.ToDecimal(item[5]),
                                p_Recepcion = Convert.ToInt32(item[5]),
                                p_UnidadMedida = item[6].ToString()
                            });
                        }
                        else
                        {
                            _itemRecepcion.Add(new ItemRecepcion
                            {
                                p_DespachoId = item[0].ToString(),
                                p_PaqueteId = item[1].ToString(),
                                p_ItemId = item[2].ToString(),
                                p_Descripcion = item[3].ToString(),
                                p_Cantidad = Convert.ToInt32(item[4]),
                                p_Peso = Convert.ToDecimal(item[5]),
                                p_Recepcion = Convert.ToInt32(item[4]),
                                p_UnidadMedida = item[6].ToString()
                            });
                        } 
                    }
                    ////////////////////////////////
                    frmrecepcion.dgvdetalle.DataSource = null;
                    frmrecepcion.dgvdetalle.DataSource = _itemRecepcion; 
                    frmrecepcion.txtrecepcion.Enabled = false;
                    frmrecepcion.txtdocumento.Enabled = false;
                    frmrecepcion.cbochofer.Enabled = false;
                    frmrecepcion.cboplaca.Enabled = false;
                    frmrecepcion.cbofuente.Enabled = false;
                    frmrecepcion.cboorigen.Enabled = false;
                    frmrecepcion.txtpropietario.Enabled = false;
                    frmrecepcion.txtci.Enabled = false;
                    frmrecepcion.FormClosed += F2_FormClosed;
                    frmrecepcion.ShowDialog();
                    this.CargaDespachos("Enviado");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problemas en la Trasaccion " + ex.ToString());
                throw ex;
            }
        }
        private void F2_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.gridControl1.DataSource = null;
            this.gridControl1.Refresh();
            this.gridControl1.RefreshDataSource();
            this.gridView1.RefreshData();
            CargaDespachos("Enviado");
        }
        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void labelX8_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            DataSet dtsRecepcion = oanotacion.ReporteRecepcionDetalle(Despacho);
            rptRecepcionDetalle rptRecepcion = new rptRecepcionDetalle();
            rptRecepcion.SetDataSource(dtsRecepcion.Tables[0]);
            frmReportViewer viwer = new frmReportViewer(rptRecepcion);
            viwer.Width = 1000;
            viwer.Height = 800;
            viwer.StartPosition = FormStartPosition.CenterScreen;
            viwer.ShowDialog();
        }
        public class ItemRecepcion
        {
            private string DespachoId;
            private string PaqueteId;
            private string ItemId;
            private string Descripcion;
            private int Cantidad;
            private decimal Peso;
            private int Recepcion;
            private string UnidadMedida;

            public string p_DespachoId
            {
                get { return DespachoId; }
                set { DespachoId = value; }
            }
            public string p_PaqueteId
            {
                get { return PaqueteId; }
                set { PaqueteId = value; }
            }
            public string p_ItemId
            {
                get { return ItemId; }
                set { ItemId = value; }
            }
            public string p_Descripcion
            {
                get { return Descripcion; }
                set { Descripcion = value; }
            }
            public int p_Cantidad
            {
                get { return Cantidad; }
                set { Cantidad = value; }
            }
            public decimal p_Peso
            {
                get { return Peso; }
                set { Peso = value; }
            }
            public int p_Recepcion
            {
                get { return Recepcion; }
                set { Recepcion = value; }
            }
            public string p_UnidadMedida
            {
                get { return UnidadMedida; }
                set { UnidadMedida = value; }
            }
        }
    }
}