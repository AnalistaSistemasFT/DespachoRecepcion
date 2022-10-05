using CRN.Componentes;
using CRN.Entidades;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
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
    public partial class frmVistaModelosEnsayos : Form
    {
        CTblEnsayo ensayos;
        CTblEnsayoDetalle ensayodetalle;
        TblEnsayo tblens;
        List<TblEnsayoDetalle> tblensdetalle;
        private string ord;
        private string grupEn;
        private string centro;
        private string paquet;
        private int id;
        private string ITem;
        private int Id_Empleado;
        private Usuario User;
        //public frmVistaModelosEnsayos(string item, string orden, string grupo, string center, string paquete,int idUser)
        public frmVistaModelosEnsayos(string item, string orden, string grupo, string center, int idUser,Usuario u)
        {
            InitializeComponent();
            Id_Empleado = idUser;
            ensayos = new CTblEnsayo();
            ensayodetalle = new CTblEnsayoDetalle();
            grupEn = grupo;
            ord = orden;
            centro = center;
            paquet = "";
            ITem=item;
            this.labelX3.Text = "Orden -> "+orden + "".ToString();
            this.labelX4.Text = "Item -> " + item + "".ToString();
            User = u;
            CargarEnsayosCorrespondientes();

        }
        public void CargarEnsayosCorrespondientes() 
        {
            //string consulta = String.Format("select * FROM tblEnsayo where PaqueteId='{0}'", paquet);
            DataSet d = ensayos.retornarEnsayosCorrespondiente(ord);
            this.gridControl1.DataSource = d.Tables[0];
        }
        private void gridControl1_Click(object sender, EventArgs e)
        {
        }
        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            ColumnView view = this.gridControl1.MainView as ColumnView;
            int[] row = view.GetSelectedRows();
            view.FocusedRowHandle = row[0];
            id = int.Parse((view.GetRowCellDisplayText(row[0], view.Columns[0])).ToString());
            cargardetalles( id);
        }
        public void cargardetalles(int id)
        {
            DataSet d = ensayos.retornardetalles(id);
            this.gridControl2.DataSource = d.Tables[0];
            this.gridView2.Columns["Id_Ensayo"].Visible=false;
            this.gridView2.Columns["ParametroId"].Visible=false;          
        }
        public void dataParaEditar() 
        {
            try
            {
                ColumnView view = this.gridControl1.MainView as ColumnView;
                int[] row = view.GetSelectedRows();
                view.FocusedRowHandle = row[0];
                id = int.Parse((view.GetRowCellDisplayText(row[0], view.Columns[0])).ToString());
                string orden = (view.GetRowCellDisplayText(row[0], view.Columns[5])).ToString();
                string item = (view.GetRowCellDisplayText(row[0], view.Columns[8])).ToString();
                string paqe = (view.GetRowCellDisplayText(row[0], view.Columns[6])).ToString();
                string colad = (view.GetRowCellDisplayText(row[0], view.Columns[7])).ToString();
                string cent = (view.GetRowCellDisplayText(row[0], view.Columns[15])).ToString();
                frmModeloEnsayo frm = new frmModeloEnsayo(id, item, orden, grupEn, cent, paqe, User.EmpleadoId,User.Login);
                frm.cargardataeditar(colad);
                frm.Text = "EDITAR";
                frm.ShowDialog();
                cargardetalles(id);
            }
            catch (Exception ss)
            {
                MessageBox.Show("Sin registros existentes, o sino vuelva a intentarlo"+ss.Message,"",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }           
        }
        private void buttonX1_Click(object sender, EventArgs e)
        {
            dataParaEditar();            
        }
        private void buttonX2_Click(object sender, EventArgs e)
        {
            //frmModeloEnsayo frm = new frmModeloEnsayo(0, ITem, ord, grupEn, centro, paquet,Id_Empleado);            
          ///  frm.Text = "NUEVO";
           // frm.ShowDialog();
        }
        private void gridView2_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            if (e.Column.FieldName == "Status")
            {
                if (e.CellValue.ToString() == "ok")
                {
                    e.Appearance.ForeColor = Color.Green;
                    e.Appearance.FontStyleDelta = FontStyle.Bold;
                    //   e.Appearance.Image = Image.FromFile("C:\\Users\\pasante_sis\\Pictures\\Captura.png",false);
                }
                else if (e.CellValue.ToString() == "wait")
                {
                    //e.Appearance.BackColor = Color.Black;
                    e.Appearance.ForeColor = Color.Orange;
                    e.Appearance.FontStyleDelta = FontStyle.Bold;
                }
                else
                {
                    e.Appearance.ForeColor = Color.Red;
                    e.Appearance.FontStyleDelta = FontStyle.Bold;
                }
            }      
        }

        private void buttonX2_Click_1(object sender, EventArgs e)
        {
            ColumnView view = this.gridControl1.MainView as ColumnView;
            int[] row = view.GetSelectedRows();
            view.FocusedRowHandle = row[0];
            id = int.Parse((view.GetRowCellDisplayText(row[0], view.Columns[0])).ToString());

            if (ensayos.EliminarEnsayo(id, User.Login) > 0)
            {
                MessageBox.Show("Ensayo se anulo Correctamente","MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CargarEnsayosCorrespondientes();
            }
            else
                MessageBox.Show("PROBLEMAS AL ELIMINAR", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void gridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            //labelX1.Text = "Focus state: focused row - " + gridView1.FocusedRowHandle.ToString();
            ////labelX2.Text = "Selection state: selected row - " + gridView1.GetSelectedRows().FirstOrDefault();
            //ColumnView view = this.gridControl1.MainView as ColumnView;
            //view.FocusedRowHandle = gridView1.GetSelectedRows().FirstOrDefault();
            //id = int.Parse((view.GetRowCellDisplayText(gridView1.GetSelectedRows().FirstOrDefault(), view.Columns[0])).ToString());
            ////GridView view = sender as GridView;
            ////object row = view.GetRow(e.FocusedRowHandle);
            ////if (row != null) 
            ////{

            ////    view.FocusedRowHandle = row;
            ////    id = int.Parse((view.GetRowCellDisplayText(row[0], view.Columns[0])).ToString());
            //    cargardetalles(id);

            //}

        }
    }
}
