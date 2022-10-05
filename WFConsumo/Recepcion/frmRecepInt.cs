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

namespace WFConsumo
{
    public partial class frmRecepInt : Form
    {
        
        CCentroTrabajo centrotrab;
        DataTable dataT = new DataTable();
        CRecepcion orecepcion;
        CAnotacion oAnotacion;
        public frmRecepInt(Usuario u,string Estado)
        {
            InitializeComponent();
           
            centrotrab = new CCentroTrabajo();
            orecepcion = new CRecepcion();
            oAnotacion = new CAnotacion();
            llenarcentros_Trabajo();
            CargarRecepcion(Estado);
           // CargarEnsayos();            
        }
        public void CargarRecepcion(string Estado) 
        {
            
            
            DataSet data = orecepcion.TraerTodosRecepcion(Estado, Entidades.utilitario.iSucursal);
            dataT = data.Tables[0];
            this.gridControl1.DataSource = data.Tables[0];  
        }
        public void llenarcentros_Trabajo() 
        {
            DataSet d = centrotrab.TraerAlmacen();
           // this.gridControl3.DataSource = d.Tables[0];
            this.listView1.Items.Clear();
            foreach (DataRow item in d.Tables[0].Rows)
	        {
                this.listView1.Items.Add(item[0].ToString());		 
	        }           
        }
        string Recepcion = string.Empty;
        string Fuente = string.Empty;
        string Documento = string.Empty;
        int SucDes = 0;
        int SucOri = 0;

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            //click celda gridcontrol
            ColumnView view = this.gridControl1.MainView as ColumnView;
            int[] row = view.GetSelectedRows();
            view.FocusedRowHandle = row[0];
            Recepcion = (view.GetRowCellDisplayText(row[0], view.Columns[0])).ToString();
            Fuente = (view.GetRowCellDisplayText(row[0], view.Columns[6])).ToString();
            Documento = (view.GetRowCellDisplayText(row[0], view.Columns[2])).ToString();
            SucDes = Convert.ToInt32((view.GetRowCellDisplayText(row[0], view.Columns[4])).ToString());
            SucOri = Convert.ToInt32((view.GetRowCellDisplayText(row[0], view.Columns[5])).ToString());
            DataSet dts = orecepcion.TraerRecepcionDet(Recepcion);
            gridControl2.DataSource = dts.Tables[0];
            DataSet dts1 = orecepcion.TraerRecepcionDet(Recepcion, Fuente);
            gridControl3.DataSource = dts1.Tables[0];

            //CargarTablasHijas(IDtabla);
        }
        public void CargarTablasHijas(string idpadre) 
        {
            /*string consulta =String.Format( "select FBC_BATCH,	FBC_PRODUCT_CODE,	FBC_PRODUCT_DESC,	FBC_SO,	FBC_POS,	FBC_WEIGHT,	FBC_PIECE,	FBC_METERS,	FBC_START,	FBC_OPERATOR,	FBC_ISSUE,	FBC_QTY_UM "+
                                       "  from [ElsystemNet_Ferrotodo].[dbo].[MES_TB_FLD_BATCHES] where [FBC_PO] = '{0}'", idpadre);*/
            //DataSet dat = ensayo.RetornoTablasHijas(idpadre);
            //this.gridControl2.DataSource = dat.Tables[0];
        }
        private void buttonX1_Click(object sender, EventArgs e)
        {
        }
        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            
        }
        
        private void buttonX2_Click(object sender, EventArgs e)
        {
        }
        private void gridView2_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {           
        }
        private void gridView2_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "FBC_BATCH")
            {
                string ids = e.CellValue.ToString();
                string consulta = String.Format("SELECT count([PaqueteId]) FROM [dbo].[tblEnsayo] where PaqueteId='{0}'", ids);
                //DataSet dat = ensayo.retornarTabla(consulta);                               
                //foreach (DataRow item in dat.Tables[0].Rows)
                //{
                //    if (int.Parse(item[0].ToString()) > 0)
                //    {
                //        e.Appearance.ForeColor = Color.Green;
                //    }
                //    else
                //    {//MessageBox.Show(item[0].ToString());
                //        e.Appearance.ForeColor = Color.Red;
                //    }
                //}
            }
        }
        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "OPR_PO")
            {
                string ids = e.CellValue.ToString();
                string consulta = String.Format("select count(*) from [ElsystemNet_Ferrotodo].[dbo].[MES_TB_FLD_BATCHES] where [FBC_PO]='{0}'", ids);
                //DataSet dat = ensayo.retornarTabla(consulta);
                //foreach (DataRow item in dat.Tables[0].Rows)
                //{
                //    if (int.Parse(item[0].ToString()) > 0)
                //    {
                //        e.Appearance.ForeColor = Color.Green;
                //       //e.Appearance.Image
                //    }
                //    else
                //    {
                //        e.Appearance.ForeColor = Color.Red;
                //        //e.Column.Image = Image.FromFile("Stars3_1.png", true);
                //    }
                //}
            }
        }
        private void buttonX3_Click(object sender, EventArgs e)
        {
        }
        private void gridControl3_Click(object sender, EventArgs e)
        {
        }
        private void gridView3_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
          //  MessageBox.Show("CLICK");
            if (listView1.SelectedItems.Count > 0)
            {
                int d = int.Parse(listView1.Items.IndexOf(listView1.SelectedItems[0]).ToString());
                string dd = listView1.Items[d].Text.ToString();
                //CargarEnsayos(dd);
            }            
        }
        private void panel4_Click(object sender, EventArgs e)
        {
            this.panel3.Visible = false;
        }
        private void buttonX3_Click_1(object sender, EventArgs e)
        {
            try
            {
              /*  ColumnView view = this.gridControl2.MainView as ColumnView;
                int[] row = view.GetSelectedRows();
                view.FocusedRowHandle = row[0];
                if(row[0]!=null)
                {
                    string fila = (view.GetRowCellDisplayText(row[0], view.Columns[1])).ToString();
                    string paquete = (view.GetRowCellDisplayText(row[0], view.Columns[0])).ToString();
                    frmVistaModelosEnsayos frmvistas = new frmVistaModelosEnsayos(fila, IDtabla, grupo, center, paquete,ID_Empleado);
                    frmvistas.ShowDialog();
                    CargarTablasHijas(IDtabla);
                }          */    
            }
            catch (Exception ee)
            {
                MessageBox.Show("Hubo un error al momento de procesar el registro =>"+ee.Message,"",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }            
        }
       

        private void labelX8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                string sError = string.Empty;
                DataTable ds1, ds2;
                ds1 = (DataTable)gridControl2.DataSource;
                ds2 = (DataTable)gridControl2.DataSource;
                int a = oAnotacion.InsertarMovimientos(out sError, ds1, ds2, Entidades.utilitario.sUsuario, Entidades.utilitario.iSucursal, Entidades.utilitario.iAlmacen, Recepcion, Documento, SucOri, SucDes);
                if(a>0)
                {
                    CargarRecepcion("INPROCESS");
                    gridControl2.DataSource = null;
                    MessageBox.Show("TRNASACCION EJECUTADA CORRECTAMENTE", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Hubo un error al momento de procesar el registro =>" + sError, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            DataSet dtsRecepcion = oAnotacion.ReporteRecepcionDetalle(Recepcion);
            rptRecepcionDetalle rptRecepcion = new rptRecepcionDetalle();
            rptRecepcion.SetDataSource(dtsRecepcion.Tables[0]);
            frmReportViewer viwer = new frmReportViewer(rptRecepcion);
            viwer.Width = 1000;
            viwer.Height = 800;
            viwer.StartPosition = FormStartPosition.CenterScreen;
            viwer.ShowDialog();

        }
    }
}