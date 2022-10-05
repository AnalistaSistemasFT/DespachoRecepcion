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
    public partial class frmBuscarEmpleado : Form
    {
        CConforme objintermediario;
        public frmBuscarEmpleado()
        {
            InitializeComponent();
            objintermediario = new CConforme();
        }
        public int codigo;
        public string nombre;
        private void frmBuscarEmpleado_Load(object sender, EventArgs e)
        {

        }
        public void recargarempleados()
        {
            string sentencia = String.Format("select EmpleadoId, Nombre +' '+Apellido as Nombres,CodFerro from empleados.dbo.tblempleados where Nombre LIKE '%{0}%'",this.textBoxX1.Text.ToString());
            DataSet dd = objintermediario.Ejecutarsentencias(sentencia);
            this.gridControl1.DataSource = dd.Tables[0];
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            recargarempleados();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            ColumnView view = this.gridControl1.MainView as ColumnView;
            int[] row = view.GetSelectedRows();
            view.FocusedRowHandle = row[0];
            codigo = int.Parse((view.GetRowCellDisplayText(row[0], view.Columns[0])).ToString());
            nombre = (view.GetRowCellDisplayText(row[0], view.Columns[1])).ToString();
            this.Close();
        }
    }
}
