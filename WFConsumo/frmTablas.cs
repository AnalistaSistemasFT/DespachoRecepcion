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

namespace WFConsumo
{
    public partial class frmTablas : Form
    {
        private string consulta;        
        CCatTablas catTab;
        DataTable dataT = new DataTable();
        private int idRow;
        public frmTablas()
        {
            InitializeComponent();
            catTab = new CCatTablas();
            CargarTablaData();
        }
        public void CargarTablaData() 
        {
            consulta = "select TablaId,Descripcion,CGR_CODE_DESC,unidad  from tblCatTabla inner join [ElsystemNet_Ferrotodo].[dbo].[MES_TB_LST_PRODUCT_GROUPS] on tblCatTabla.TipoProducto =CGR_GROUP_CODE  order by TablaId";
            DataSet data = catTab.retornarTabla(consulta);
            dataT = data.Tables[0];
            dataT.Rows.Add(null,"","","Total"+(dataT.Rows.Count));
            this.gridControl1.DataSource = dataT;
            this.gridView1.Columns["TablaId"].Width = 3;
            this.gridView1.Columns["unidad"].Width = 5;
            this.gridView1.Columns["CGR_CODE_DESC"].Width = 10;
           // this.gridView1.Columns["TablaId"].AppearanceCell.TextOptions = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Columns["TablaId"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Columns["unidad"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Columns["CGR_CODE_DESC"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Columns["Descripcion"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        }
        public void CargarTablaDetalle(int idcattabla) 
        {
            consulta = String.Format("SELECT valor,minimo,maximo FROM tblCatTabladetalle where TablaId={0}",idcattabla);
            DataSet data1 = catTab.retornarTabla(consulta);            
            this.gridControl2.DataSource = data1.Tables[0];
            this.labelX1.Text = "Total " + this.gridView2.RowCount;
            this.gridView2.Columns["valor"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView2.Columns["minimo"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView2.Columns["maximo"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center; 
        }
        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            //CLICK CELDA GRID  
            try
            {
                ColumnView view = this.gridControl1.MainView as ColumnView;
                int[] row = view.GetSelectedRows();
                view.FocusedRowHandle = row[0];
                idRow = int.Parse(view.GetRowCellDisplayText(row[0], view.Columns[0]));
                CargarTablaDetalle(idRow);
            }
            catch (Exception ee)
            {
                MessageBox.Show("Seleccione otra fila "+ee.Message,"",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            
        }
        private void buttonX1_Click(object sender, EventArgs e)
        {
            //NUEVO
            frmCatTablaNuevo frmcatnuevo = new frmCatTablaNuevo(0);
            frmcatnuevo.ShowDialog();
            CargarTablaData();
        }
        private void buttonX2_Click(object sender, EventArgs e)
        {
            frmCatTablaNuevo frmcatnuevo = new frmCatTablaNuevo(idRow);
            frmcatnuevo.CargarPaEditar();
            frmcatnuevo.ShowDialog();
            CargarTablaData();
            CargarTablaDetalle(idRow);
        }
        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {
            if (this.textBoxX1.Text.ToString().Length > 0)
            {
                dataT.DefaultView.RowFilter = " Descripcion LIKE '%" + this.textBoxX1.Text + "%' or CGR_CODE_DESC LIKE '%" + this.textBoxX1.Text + "%' or unidad LIKE '%Total%' ";
            }
            else
            {
                dataT.DefaultView.RowFilter = "";
            }
        }

        private void gridView1_RowCountChanged(object sender, EventArgs e)
        {
            ColumnView view = this.gridControl1.MainView as ColumnView;
            view.SetRowCellValue(this.gridView1.RowCount-1 , view.Columns["unidad"], "Total  " + (this.gridView1.RowCount - 1));
        }

        private void labelX8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {

        }

        private void frmTablas_Load(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
