using CRN.Componentes;
using DevExpress.XtraGrid.Views.Base;
using System;
//using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFConsumo
{
    public partial class frmPlantillas : Form
    {
        CEnsayo ensayoV;
        private int IDEnsayo;
        private int IDParteEnsayo=-1;
        DataTable dataT = new DataTable();
        CPartesEnsayos cpartes;
        private int Id_Empleado;
        public frmPlantillas(int idUser)
        {
            InitializeComponent();
            Id_Empleado = idUser;
            ensayoV = new CEnsayo();
            cpartes = new CPartesEnsayos();
            Cargardata();
            CargarSubEnsayos(1);
            frmTablas fr = new frmTablas();
        }
        private void Cargardata()
        {
            DataSet data = ensayoV.retornarEnsayoFiltrado();
            dataT = data.Tables[0];
            dataT.Rows.Add( null,"",null,"Total" );
            this.gridControl1.DataSource = dataT;
            // this.gridView1.AddNewRow();
            //this.gridView1.
             ColumnView view = gridControl1.MainView as ColumnView;
             view.SetRowCellValue(this.gridView1.RowCount-1, view.Columns["Periodo"], "Total "+(this.gridView1.RowCount-1));
           
        }     
        public void CargarSubEnsayos(int tipoid)
        {
            DataSet data = ensayoV.retornoSubEnsayoFiltrado(tipoid);
            DataTable dt = data.Tables[0];
            this.gridControl2.DataSource = dt;            
            this.labelX1.Text = "Total " + this.gridView2.RowCount;         
        }
        private void gridView1_Click(object sender, EventArgs e)
        {           
        }
        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {
            if (this.textBoxX1.Text.ToString().Length > 0)
            {
                dataT.DefaultView.RowFilter = " Descripcion LIKE '%" + this.textBoxX1.Text + "%' or pERIODO LIKE '%" + this.textBoxX1.Text + "%' or Descripcion =' '";
            }
            else
            {
                dataT.DefaultView.RowFilter = "";
            }
        }
        private void buttonX4_Click(object sender, EventArgs e)
        {
        }
        private void button2_Click(object sender, EventArgs e)
        {
        }
        private void buttonX1_Click_1(object sender, EventArgs e)
        {
            frmNuevoEnsayo nEnsayo = new frmNuevoEnsayo(Id_Empleado);
            nEnsayo.ShowDialog();
            Cargardata();
        }
        private void buttonX2_Click_1(object sender, EventArgs e)
        {
            //EDITAR
            frmNuevoEnsayo nEnsayo = new frmNuevoEnsayo(Id_Empleado);
            nEnsayo.LlenarFormulario(IDEnsayo);
            nEnsayo.ShowDialog();
            Cargardata();
        }
        private void textBoxX1_TextChanged_1(object sender, EventArgs e)
        {
            if (this.textBoxX1.Text.ToString().Length > 0)
            {
                dataT.DefaultView.RowFilter = " Descripcion LIKE '%" + this.textBoxX1.Text + "%' or pERIODO LIKE '%" + this.textBoxX1.Text + "%' or Descripcion=' '";
            }
            else
            {
                dataT.DefaultView.RowFilter = "";
            }
        }
        private void gridControl1_Click(object sender, EventArgs e)
        {
        }
        private void gridView1_RowCellClick_1(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            try
            {
                ColumnView view = gridControl1.MainView as ColumnView;
                int[] row = view.GetSelectedRows();
                view.FocusedRowHandle = row[0];
                IDEnsayo = int.Parse(view.GetRowCellDisplayText(row[0], view.Columns[0]));
                CargarSubEnsayos(IDEnsayo);
            }
            catch (Exception ee)
            {
                MessageBox.Show("No debe de seleccionar mas de una fila a la vez " + ee.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }           
        }
        private void gridControl2_Click(object sender, EventArgs e)
        {
        }
        private void gridView2_RowCellClick_1(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            try
            {
                ColumnView view = gridControl2.MainView as ColumnView;
                int[] row = view.GetSelectedRows();
                view.FocusedRowHandle = row[0];
                IDParteEnsayo = int.Parse(view.GetRowCellDisplayText(row[0], view.Columns[0]));
            }
            catch (Exception ee)
            {
                MessageBox.Show("No debe de seleccionar mas de una fila a la vez "+ee.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }           
        }
        private void buttonX4_Click_2(object sender, EventArgs e)
        {
            //ENVIAMOS EL ID DEL ENSAYO PADRE
            frmPartesEnsayos partes = new frmPartesEnsayos(IDEnsayo, 0,Id_Empleado);
            partes.ShowDialog();
            CargarSubEnsayos(IDEnsayo); 
        }
        private void buttonX5_Click_1(object sender, EventArgs e)
        {
            if (IDParteEnsayo >= 0)
            {
                frmPartesEnsayos parteensayo = new frmPartesEnsayos(IDEnsayo, IDParteEnsayo, Id_Empleado);
                parteensayo.CargarDatospActualizar();
                parteensayo.ShowDialog();
                CargarSubEnsayos(IDEnsayo);
            }
            else
                MessageBox.Show("No tiene seleccionado ningun registro ","",MessageBoxButtons.OK,MessageBoxIcon.Warning);
           
        }
        private void buttonX6_Click_1(object sender, EventArgs e)
        {
            //string consulta = String.Format("delete from tblTipoEnsayoParam   where ParametroId={0}", IDParteEnsayo);
            if(IDParteEnsayo>=0)
            {
                cpartes.EliminarParteEnsayo(IDParteEnsayo);
                MessageBox.Show("ELIMINADO CORECTAMENTE ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarSubEnsayos(IDEnsayo);                            
            }else
                MessageBox.Show("No tiene seleccionado ningun registro ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            IDParteEnsayo = -1;
        }

        private void gridView1_DataSourceChanged(object sender, EventArgs e)
        {
        // MessageBox.Show("CARGADO");
        }

        private void gridView1_RowCountChanged(object sender, EventArgs e)
        {
            //se invoca cuando se insertan nuevas filas
            //MessageBox.Show("CARGADO");
           // this.gridView1.DeleteRow(this.gridView1.RowCount-1);
            //this.gridView1.AddNewRow();
            ColumnView view = gridControl1.MainView as ColumnView;
            view.SetRowCellValue(this.gridView1.RowCount - 1, view.Columns["Periodo"], "Total " + (this.gridView1.RowCount-1));
        }

        private void labelX8_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
