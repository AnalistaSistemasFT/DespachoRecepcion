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
using System.Web.UI.WebControls;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;

namespace WFConsumo
{
    public partial class frmEnsayos : Form
    {
        CEnsayo ensayo;
        DataTable dataT = new DataTable();
        private int ID_Empleado;
        public frmEnsayos(int idempleado)
        {
            InitializeComponent();
            ID_Empleado = idempleado;
            ensayo = new CEnsayo();            
        }       
        private void buttonX1_Click(object sender, EventArgs e)
        {
          // frmModeloEnsayo modeloensayo = new frmModeloEnsayo();
            //modeloensayo.ShowDialog();
        }
        private void buttonX2_Click(object sender, EventArgs e)
        {

        }
        public void CargaraEnsayos(string ids) 
        {
            /*String.Format("SELECT [Id_Ensayo],[EnsayoId],[FechaCreacion],[TipoId],[FechaEjecucion],[OrdenId]"+
                            ",[PaqueteId],[Colada],[ItemId],[EmpleadoId],[Obs],[Resultado],[Status],[TipoGeneracion],[Correlativo],[CentroId] FROM [dbo].[tblEnsayo]  ", ids);
             */
            string consulta = String.Format("SELECT * FROM dbo.tblOrdenProduccion where Estado=1 ", ids);
            DataSet data = ensayo.retornarEnsayo(consulta);
            dataT = data.Tables[0];
            this.gridControl1.DataSource = dataT;
            this.gridView1.Columns["Id_Orden"].AppearanceCell.FontStyleDelta = FontStyle.Bold;
            this.labelX1.Text = "Total " + (this.gridView1.RowCount );
        }
        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            ColumnView view = this.gridControl1.MainView as ColumnView;
            int[] row = view.GetSelectedRows();
            view.FocusedRowHandle = row[0];
            string orden = (view.GetRowCellDisplayText(row[0], view.Columns[0])).ToString();
           /* string consulta = String.Format("select FBC_BATCH,	FBC_PRODUCT_CODE,	FBC_PRODUCT_DESC, " +
                           " FBC_SO,	FBC_POS,	FBC_WEIGHT,	FBC_PIECE,	FBC_METERS,	FBC_START,	FBC_OPERATOR,	FBC_ISSUE, " +
                            " FBC_QTY_UM   from [ElsystemNet_Ferrotodo].[dbo].[MES_TB_FLD_BATCHES] where [FBC_PO] = '{0}'", orden);
            DataSet data1 = ensayo.retornarEnsayo(consulta);
            this.gridControl2.DataSource = data1.Tables[0];*/
            this.labelX3.Text = "Orden => " + orden.ToString();
            llenarDataGrid2(orden);
        }
        
        public void llenarDataGrid2(string orden) 
        {
            string consulta = String.Format("select  * from tblEnsayo where OrdenId='{0}'",orden);
            DataSet data2 = ensayo.retornarEnsayo(consulta);
            this.gridControl2.DataSource = data2.Tables[0];
            this.labelX2.Text = "Total " + (this.gridView2.RowCount );
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
        }
        private void gridView2_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
        }
        private void gridView2_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
        }
        private void gridView2_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            ColumnView view = this.gridControl2.MainView as ColumnView;
            int[] row = view.GetSelectedRows();
            view.FocusedRowHandle = row[0];
            int id =Convert.ToInt32((view.GetRowCellDisplayText(row[0], view.Columns[0])).ToString());
            DataSet d = ensayo.retornardetalles(id);
            gridControl3.DataSource = d.Tables[0];
           
        }
        private void gridView2_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox1.Text.ToString().Length > 0)
            {
                dataT.DefaultView.RowFilter = " Id_Orden LIKE '%" + this.textBox1.Text + "%' or  CentroId LIKE '%" + this.textBox1.Text + "%' or ItemId LIKE '%"+this.textBox1.Text+"%'";
            }
            else
            {
                dataT.DefaultView.RowFilter = "";
            }
        }

        private void gridView1_RowCountChanged(object sender, EventArgs e)
        {
            this.labelX1.Text = "Total " + (this.gridView1.RowCount);
        }

        private void labelX8_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
