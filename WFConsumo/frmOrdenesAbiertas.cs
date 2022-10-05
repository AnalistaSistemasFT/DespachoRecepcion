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
using Entidades;
namespace WFConsumo
{
    public partial class frmOrdenesAbiertas : Form
    {
        CCatTablas ensayo;
        CCentroTrabajo centrotrab;
        DataTable dataT = new DataTable();
        private string IDtabla;
        private string grupo;
        private string center;
        private int ID_Empleado;
        private string item;
        private Usuario User;
        public frmOrdenesAbiertas(Usuario u)
        {
            InitializeComponent();
            ID_Empleado = u.EmpleadoId;
            ensayo = new CCatTablas();
            centrotrab = new CCentroTrabajo();
            llenarcentros_Trabajo(utilitario.iSucursal);
            User = u;
           // CargarEnsayos();            
        }
        public void CargarEnsayos(string workcenter) 
        {
            this.labelX3.Text = "Centro  => " + workcenter + "".ToString();
            string consulta = String.Format("select OPR_PO,OPR_WORKCENTER as CENTRO,OPR_PRODUCT_GROUP,OPR_PRODUCT_CODE,	OPR_PRODUCT_DESC,OPR_QTY,OPR_QTY_UM,OPR_STATUS,OPR_SCHEDULED_DATE, opr_feature_group as Grupo from [ElsystemNet_Ferrotodo].[dbo].[MES_TB_PRO_OPR] where opr_status = 'INPR' and OPR_WORKCENTER ='{0}'  and not exists(select Id_Orden from tblOrdenProduccion) ", workcenter);
            DataSet data = ensayo.retornarTabla(consulta);
            dataT = data.Tables[0];
            this.gridControl1.DataSource = dataT;  
        }
        public void llenarcentros_Trabajo(int sucursal) 
        {
            DataSet d = centrotrab.TraerxCentro(sucursal);
           // this.gridControl3.DataSource = d.Tables[0];
            this.listView1.Items.Clear();
            foreach (DataRow item in d.Tables[0].Rows)
	        {
                this.listView1.Items.Add(item[0].ToString());		 
	        }           
        }
        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            //click celda gridcontrol
            ColumnView view = this.gridControl1.MainView as ColumnView;
            int[] row = view.GetSelectedRows();
            view.FocusedRowHandle = row[0];
            IDtabla = (view.GetRowCellDisplayText(row[0], view.Columns[0])).ToString();
            grupo = (view.GetRowCellDisplayText(row[0], view.Columns[9])).ToString();
            center = (view.GetRowCellDisplayText(row[0], view.Columns[1])).ToString();
             item = (view.GetRowCellDisplayText(row[0], view.Columns[3])).ToString();
            CargarTablasHijas(IDtabla);
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
            nuevo_subensayo();
        }
        public void nuevo_subensayo() 
        {
            try
            {
             /*   //gridcontrol2 mostrar datos
                ColumnView view = this.gridControl2.MainView as ColumnView;
                int[] row = view.GetSelectedRows();
                view.FocusedRowHandle = row[0];
                string fila = (view.GetRowCellDisplayText(row[0], view.Columns[1])).ToString();
                string paquete = (view.GetRowCellDisplayText(row[0], view.Columns[0])).ToString();
                frmModeloEnsayo modelo = new frmModeloEnsayo(0,fila, IDtabla,grupo,center,paquete,ID_Empleado);
                modelo.Text = "CREAR NUEVO ENSAYO";              
                modelo.ShowDialog();         */           
            }
            catch (Exception ee)
            {
                MessageBox.Show("Seleccione una fila de la tabla consumidos para los respectivos ensayos =>"+ee.Message,"",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }                  
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
                DataSet dat = ensayo.retornarTabla(consulta);                               
                foreach (DataRow item in dat.Tables[0].Rows)
                {
                    if (int.Parse(item[0].ToString()) > 0)
                    {
                        e.Appearance.ForeColor = Color.Green;
                    }
                    else
                    {//MessageBox.Show(item[0].ToString());
                        e.Appearance.ForeColor = Color.Red;
                    }
                }
            }
        }
        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "OPR_PO")
            {
                string ids = e.CellValue.ToString();
                string consulta = String.Format("select count(*) from [ElsystemNet_Ferrotodo].[dbo].[MES_TB_FLD_BATCHES] where [FBC_PO]='{0}'", ids);
                DataSet dat = ensayo.retornarTabla(consulta);
                foreach (DataRow item in dat.Tables[0].Rows)
                {
                    if (int.Parse(item[0].ToString()) > 0)
                    {
                        e.Appearance.ForeColor = Color.Green;
                       //e.Appearance.Image
                    }
                    else
                    {
                        e.Appearance.ForeColor = Color.Red;
                        //e.Column.Image = Image.FromFile("Stars3_1.png", true);
                    }
                }
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
                CargarEnsayos(dd);
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
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            frmNuevaOrden nuevo = new frmNuevaOrden(item,grupo,IDtabla,center,ID_Empleado,0, User);
            nuevo.ShowDialog();
        }

        private void labelX8_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}