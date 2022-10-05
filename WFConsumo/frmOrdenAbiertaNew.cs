using CRN.Componentes;
using CRN.Entidades;
using DevExpress.XtraGrid.Views.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFConsumo
{
    public partial class frmOrdenAbiertaNew : Form
    {
        COrdenProduccion prod;
        private string centroId;
        private string item;
        private int IdEmpleado;
        private string sUser;
        private string orden;
        private string paqete;
        private string grupoEnsa;
        CTblEnsayo ensayos;
        DataTable dataT = new DataTable();
        Usuario User;
        string sCentroT;
        private int iTipo;
        public frmOrdenAbiertaNew(Usuario u)
        {
            InitializeComponent();
            ensayos = new CTblEnsayo();
            prod = new COrdenProduccion();
            CargarData();
            IdEmpleado = u.EmpleadoId;
            sUser = u.Login;
            btnCerrarOrden.Enabled = true;
            btnAbrirOrden.Enabled = true;
            iTipo = 0;
            btnAbrirOrden.Enabled = false;
            User = u;

        }
        public frmOrdenAbiertaNew(String sLinea, Usuario u)
        {
            InitializeComponent();
            ensayos = new CTblEnsayo();
            prod = new COrdenProduccion();
            CargarData(sLinea);
            IdEmpleado = u.EmpleadoId;
            sUser = u.Login;
            btnCerrarOrden.Enabled = false;
            btnAbrirOrden.Enabled = true;
            sCentroT = sLinea;
            iTipo = 1;
            btnAbrirOrden.Enabled = true;
            User = u;
        }
        public void CargarData() 
        {
            string consulta = @"select O.Id_Orden,O.Fecha,o.Estado,O.FechaEstado,O.ItemId,I.Descripcion,O.EmpleadoId,O.CentroId,O.TipoEnsayo,O.Operacion,O.Usuario
                 from dbo.tblOrdenProduccion o inner join
                LYBK.dbo.tblItem i on o.ItemId = i.ItemId where Estado=0";
            DataSet d = prod.retornarTabla(consulta);
            dataT = d.Tables[0];
            this.gridControl1.DataSource = dataT;
            this.gridView1.Columns["Id_Orden"].AppearanceCell.FontStyleDelta = FontStyle.Bold;
            this.labelX6.Text = "Total " + (this.gridView1.RowCount );
            this.lblTotalPaq.Text = "Total Paquetes: " + (this.gridView3.RowCount);
            this.lblNroE.Text = "Nro Ensayos: " + (this.gridView2.RowCount);
            //this.buttonX3

        }
        public void CargarData(string sLinea)
        {
            string consulta = @"select O.Id_Orden,O.Fecha,o.Estado,O.FechaEstado,O.ItemId,I.Descripcion,O.EmpleadoId,O.CentroId,O.TipoEnsayo,O.Operacion,O.Usuario
                            from dbo.tblOrdenProduccion o inner join
                            LYBK.dbo.tblItem i on o.ItemId = i.ItemId where Estado=0 and CentroId in (" + sLinea+")";
            DataSet d = prod.retornarTabla(consulta);
            dataT = d.Tables[0];
            this.gridControl1.DataSource = dataT;
            this.gridView1.Columns["Id_Orden"].AppearanceCell.FontStyleDelta = FontStyle.Bold;
            this.labelX6.Text = "Total " + (this.gridView1.RowCount);
            this.lblTotalPaq.Text = "Total Paquetes: " + (this.gridView3.RowCount);
            this.lblNroE.Text = "Nro Ensayos: " + (this.gridView2.RowCount);
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            try
            {
                ColumnView view = this.gridControl1.MainView as ColumnView;
                int[] row = view.GetSelectedRows();
                view.FocusedRowHandle = row[0];
                orden = (view.GetRowCellDisplayText(row[0], view.Columns[0])).ToString();
                centroId ="'"+ (view.GetRowCellDisplayText(row[0], view.Columns[7])).ToString()+"'";
                sCentroT = centroId;
                grupoEnsa = (view.GetRowCellDisplayText(row[0], view.Columns[8])).ToString();
                this.labelX3.Text = "Orden " + orden + "".ToString();
                //llenar gridcontrol 3                
                DataSet data1 = prod.retornarPaqueterPorOrden(orden);
                this.gridControl3.DataSource = data1.Tables[0];
                this.gridView2.Columns.Clear();
                this.lblTotalPaq.Text = "Total Paquetes: " + (this.gridView3.RowCount);
                
                timer1.Start();
                DataSet dd = prod.retornarEnsayos(orden);
                this.gridControl2.DataSource = dd.Tables[0];
                this.gridView2.Columns["Id_Ensayo"].Visible = false;
                this.gridView2.Columns["EnsayoId"].Visible = false;
                this.gridView2.Columns["TipoId"].Visible = false;
                this.gridView2.Columns["Colada"].Visible = false;
               // this.gridView2.Columns["ItemId"].Visible = false;
                this.gridView2.Columns["Resultado"].Visible = false;
                this.gridView2.Columns["Correlativo"].Visible = false;
                this.lblItemE.Text = "Item: " + (view.GetRowCellDisplayText(row[0], view.Columns[4])).ToString();
                this.lblNroE.Text = "Nro Ensayos: " + (this.gridView2.RowCount);
            }
            catch (IndexOutOfRangeException ee)
            {
                MessageBox.Show("No debe de seleccionar mas de una fila a la vez => " + ee.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }            
        }
        private void buttonX1_Click(object sender, EventArgs e)
        {
            //cerrar orden
            DialogResult d;
            if(orden!=" ")
            {
                d = MessageBox.Show("Desea cerrar la Orden = " + orden, "ORDEN", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (d == DialogResult.Yes)
                {
                    prod.Modificar(orden, 1, DateTime.Now);
                    MessageBox.Show("ORDEN CERRADA CORRECTAMENTE => " + orden, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarData();
                    this.gridView2.Columns.Clear();
                    this.gridView3.Columns.Clear();
                }            
            }
            
        }
        private void gridView3_DoubleClick(object sender, EventArgs e)
        {
            //crear nuevo
            try     
            {            
                ColumnView view = this.gridControl3.MainView as ColumnView;
                int[] row = view.GetSelectedRows();
                view.FocusedRowHandle = row[0];
                string fila = (view.GetRowCellDisplayText(row[0], view.Columns[1])).ToString();
                paqete = (view.GetRowCellDisplayText(row[0], view.Columns[0])).ToString();
                frmModeloEnsayo modelo = new frmModeloEnsayo(0, fila, orden, grupoEnsa, centroId, paqete, IdEmpleado,sUser);
                modelo.Text = "CREAR NUEVO ENSAYO";
                modelo.ShowDialog();
                string consulta = String.Format("select  * from tblEnsayo where OrdenId='{0}'", orden);
                DataSet dd = prod.retornarTabla(consulta);
                this.gridControl2.DataSource = dd.Tables[0];
                this.lblNroE.Text = "Nro Ensayos: " + (this.gridView2.RowCount);
            }
            catch(SqlException ee)
            {
                MessageBox.Show("Hubo un errror al cargar los informacion => " + ee.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //catch (SqlException dd) { }
            catch (Exception ee)
            {
                MessageBox.Show("Seleccione una fila de la tabla consumidos para los respectivos ensayos => " + ee.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void gridView3_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "PAQUETE")
            {
                string ids = e.CellValue.ToString();
                string consulta = String.Format("SELECT count([PaqueteId]) FROM [dbo].[tblEnsayo] where PaqueteId='{0}' and Estado = 1", ids);
                DataSet dat = prod.retornarTabla(consulta);
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
        private void gridView3_RowCellClick_1(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)

        {
            try
            {
                ColumnView view = this.gridControl3.MainView as ColumnView;
                int[] row = view.GetSelectedRows();
                view.FocusedRowHandle = row[0];
                paqete = (view.GetRowCellDisplayText(row[0], view.Columns[0])).ToString();
                //item
              //  this.labelX5.Text = "" + (view.GetRowCellDisplayText(row[0], view.Columns[1])).ToString();
              //  DataSet d = ensayos.retornarEnsayosCorrespondiente(paqete);
              //  this.gridControl2.DataSource = d.Tables[0];
                this.gridView2.Columns["Id_Ensayo"].Visible = false;
                this.gridView2.Columns["EnsayoId"].Visible = false;
                this.gridView2.Columns["TipoId"].Visible = false;
                this.gridView2.Columns["Colada"].Visible = false;
                this.gridView2.Columns["ItemId"].Visible = true;
                this.gridView2.Columns["Resultado"].Visible = false;
                this.gridView2.Columns["Correlativo"].Visible = false;
            }
            catch (Exception eee)
            {
                throw eee;
            }
        }
        private void buttonX3_Click(object sender, EventArgs e)
        {
            //ver los detalles
            try
            {
                //corregir
                ColumnView view = this.gridControl2.MainView as ColumnView;
                int[] row = view.GetSelectedRows();
                view.FocusedRowHandle = row[0];
                if (row[0] != null)
                {
                    string fila = (view.GetRowCellDisplayText(row[0], view.Columns[1])).ToString();
                    string paquete = (view.GetRowCellDisplayText(row[0], view.Columns[0])).ToString();
                    string item = (view.GetRowCellDisplayText(row[0], view.Columns[4])).ToString();
                    //string item = this.labelX5.Text.ToString();
                    //frmVistaModelosEnsayos frmvistas = new frmVistaModelosEnsayos(item, orden, grupoEnsa, centroId, paqete, IdEmpleado);
                    frmVistaModelosEnsayos frmvistas = new frmVistaModelosEnsayos(item, orden, grupoEnsa, centroId,  IdEmpleado, User);
                    frmvistas.ShowDialog();
                  //  CargarTablasHijas(IDtabla);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("Hubo un error al momento de procesar el registro =>" + ee.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void dateEdit2_EditValueChanged(object sender, EventArgs e)
        {            
            //fecha uno
            string f = this.f1.DateTime.ToString();
            
            if (f.ToString().Length>0 )
            {
                dataT.DefaultView.RowFilter = " Fecha >='" + f + "' and FechaEstado <'" +DateTime.Now + "'";
            }
            else
            {
                dataT.DefaultView.RowFilter = "";
            }
        }

        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {
            
        }

        private void gridView1_RowCountChanged(object sender, EventArgs e)
        {
           this.labelX6.Text = "Total " + (this.gridView1.RowCount);
        }
        private void buttonX2_Click(object sender, EventArgs e)
        {
            //nuevo ensayo
            //  CargarTablasHijas(IDtabla);int ids,string item,string orden,string grupo,string center,string paquete,int IdUser
            //  CargarTablasHijas(IDtabla);int ids,string item,string orden,string grupo,string center,string paquete,int IdUser
            //  CargarTablasHijas(IDtabla);int ids,string item,string orden,string grupo,string center,string paquete,int IdUser
            //MessageBox.Show(" int ids,string item,string orden,string grupo,string center,string paquete,int Iduser  ");        
        }
        private void labelX5_Click(object sender, EventArgs e)
        {
        }
        private void labelX8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DataSet data1 = prod.retornarPaqueterPorOrden(orden);
            this.gridControl3.DataSource = data1.Tables[0];
            this.lblTotalPaq.Text = "Total Paquetes: " + (this.gridView3.RowCount);
        }

        private void btnAbrirOrden_Click(object sender, EventArgs e)
        {
            if(iTipo == 1)
                this.Hide();
            frmaddOrdenProd oAddOrden = new frmaddOrdenProd(sCentroT, User);
            oAddOrden.ShowDialog();
        }
    }
}
