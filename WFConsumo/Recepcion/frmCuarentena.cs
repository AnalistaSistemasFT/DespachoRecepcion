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
using WFConsumo.Reportes;

namespace WFConsumo.Recepcion
{
    public partial class frmCuarentena : Form
    {
        CPaquetes oPaquete = new CPaquetes();
        
        public frmCuarentena()
        {
            InitializeComponent();
            cargarPaquetes();
        }

        private void cargarPaquetes()
        {
            List<string> container = new List<string>();
            container.Add("CUARENTENA");
            string sEstado = string.Join(",", container.Select(x => string.Format("'{0}'", x)));
            DataSet dtsAnotacion = oPaquete.TraerTodoPaquetesActivos(sEstado, Entidades.utilitario.iSucursal);
            this.gridPaquetes.DataSource = dtsAnotacion.Tables[0];

        }

        
        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            ColumnView view = this.gridPaquetes.MainView as ColumnView;
            int[] row = view.GetSelectedRows();
            view.FocusedRowHandle = row[0];
            Item = (view.GetRowCellDisplayText(row[0], view.Columns[6])).ToString();
            Desc = (view.GetRowCellDisplayText(row[0], view.Columns[7])).ToString();
            Pieza = (view.GetRowCellDisplayText(row[0], view.Columns[11])).ToString();
            Peso = (view.GetRowCellDisplayText(row[0], view.Columns[10])).ToString();
            Colada = (view.GetRowCellDisplayText(row[0], view.Columns[14])).ToString();
            Etiqueta = (view.GetRowCellDisplayText(row[0], view.Columns[0])).ToString();
            Calidad = (view.GetRowCellDisplayText(row[0], view.Columns[18])).ToString();

        }


        string Item = string.Empty;
        string Desc = string.Empty;
        string Peso = string.Empty;
        string Pieza = string.Empty;
        string Etiqueta = string.Empty;
        string Colada = string.Empty;
        string Calidad = string.Empty;

        private void button1_Click(object sender, EventArgs e)
        {
            frmAdmCuarentena form2 = new frmAdmCuarentena("ENTRADA");
            //form2.Owner = this;
            form2.ShowDialog();
            this.cargarPaquetes();
        }

        private void rbetiqueta1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbeqtiqueta2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmAdmCuarentena form2 = new frmAdmCuarentena("SALIDA");
            form2.ShowDialog();
            this.cargarPaquetes();
        }
    }
}
