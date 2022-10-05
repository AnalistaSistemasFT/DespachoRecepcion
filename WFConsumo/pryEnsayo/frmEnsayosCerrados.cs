using CRN.Componentes;
using CRN.Entidades;
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

namespace WFConsumo.pryEnsayo
{
    public partial class frmEnsayosCerrados : Form
    {
        CCentroTrabajo centrotrab;
        CEnsayo oEnsayo;
        Usuario user;
        public frmEnsayosCerrados(string sucursal, Usuario u)
        {
            InitializeComponent();
            centrotrab = new CCentroTrabajo();
            oEnsayo = new CEnsayo();
            user = u;
            llenarcentros_Trabajo(Entidades.utilitario.iSucursal);
            if (u.Login == "stephanie")
                gvdetalle.Enabled = true;
            else
                gvdetalle.Enabled = false;
;        }

   
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
        public void CargarEnsayos(int iestado, string scentro)
        {
           
            
            DataSet data = oEnsayo.retornarEnsayo(iestado, scentro);
            this.gvensayo.DataSource = data.Tables[0];
            //this.gvensayo.Columns["Id_Orden"].AppearanceCell.FontStyleDelta = FontStyle.Bold;
            //this.labelX1.Text = "Total " + (this.gridView1.RowCount);
        }


        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                int d = int.Parse(listView1.Items.IndexOf(listView1.SelectedItems[0]).ToString());
                string dd = listView1.Items[d].Text.ToString();
                CargarEnsayos(1,dd);
            }
        }
        string grupoEnsa = string.Empty;
        string orden = string.Empty;
        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {

            ColumnView view = this.gvensayo.MainView as ColumnView;
            int[] row = view.GetSelectedRows();
            view.FocusedRowHandle = row[0];
            orden = (view.GetRowCellDisplayText(row[0], view.Columns[0])).ToString();
            grupoEnsa = (view.GetRowCellDisplayText(row[0], view.Columns[7])).ToString();
            /* string consulta = String.Format("select FBC_BATCH,	FBC_PRODUCT_CODE,	FBC_PRODUCT_DESC, " +
                            " FBC_SO,	FBC_POS,	FBC_WEIGHT,	FBC_PIECE,	FBC_METERS,	FBC_START,	FBC_OPERATOR,	FBC_ISSUE, " +
                             " FBC_QTY_UM   from [ElsystemNet_Ferrotodo].[dbo].[MES_TB_FLD_BATCHES] where [FBC_PO] = '{0}'", orden);
             DataSet data1 = ensayo.retornarEnsayo(consulta);
             this.gridControl2.DataSource = data1.Tables[0];*/
            //this.labelX3.Text = "Orden => " + orden.ToString();
            llenarDataGrid2(orden);
        }
        public void llenarDataGrid2(string orden)
        {
            string consulta = String.Format("select  * from tblEnsayo where OrdenId='{0}'", orden);
            DataSet data2 = oEnsayo.retornarEnsayo(consulta);
            this.gvdetalle.DataSource = data2.Tables[0];
            //this.labelX2.Text = "Total " + (this.gridView2.RowCount);
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                ColumnView view = this.gvdetalle.MainView as ColumnView;
                int[] row = view.GetSelectedRows();
                view.FocusedRowHandle = row[0];
                int id = int.Parse((view.GetRowCellDisplayText(row[0], view.Columns[0])).ToString());
                string orden = (view.GetRowCellDisplayText(row[0], view.Columns[5])).ToString();
                string item = (view.GetRowCellDisplayText(row[0], view.Columns[8])).ToString();
                string paqe = (view.GetRowCellDisplayText(row[0], view.Columns[6])).ToString();
                string colad = (view.GetRowCellDisplayText(row[0], view.Columns[7])).ToString();
                string cent = (view.GetRowCellDisplayText(row[0], view.Columns[15])).ToString();
              
        frmModeloEnsayo frm = new frmModeloEnsayo(id, item, orden, grupoEnsa, cent, paqe, user.EmpleadoId, user.Login);
                frm.cargardataeditar(colad);
                frm.Text = "EDITAR";
                frm.ShowDialog();
                llenarDataGrid2(orden);
            }
            catch (Exception ss)
            {
                MessageBox.Show("Sin registros existentes, o sino vuelva a intentarlo" + ss.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
