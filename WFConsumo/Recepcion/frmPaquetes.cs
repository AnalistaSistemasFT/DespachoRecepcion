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
    public partial class frmPaquetes: Form
    {
        CPaquetes oPaquete = new CPaquetes();
        
        public frmPaquetes()
        {
            InitializeComponent();
            cargarPaquetes();
        }

        private void cargarPaquetes()
        {
            DataSet dtsAnotacion = oPaquete.TraerTodoPaquetesActivos("ACTIVO", Entidades.utilitario.iSucursal);
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

            rptEtiqueta oEtiqueta = new rptEtiqueta();
            oEtiqueta.SetParameterValue("item", Item);
            oEtiqueta.SetParameterValue("desc", Desc);
            oEtiqueta.SetParameterValue("peso", Peso);
            oEtiqueta.SetParameterValue("calidad", Calidad);
            oEtiqueta.SetParameterValue("colada", Colada);
            oEtiqueta.SetParameterValue("pieza", Pieza);
            oEtiqueta.SetParameterValue("etiqueta", Etiqueta);
            oEtiqueta.SetParameterValue("medida", Desc);
            oEtiqueta.SetParameterValue("etiqueta", Etiqueta);
            crviwer.ReportSource = oEtiqueta;
            crviwer.Zoom(100);

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
            if (!string.IsNullOrEmpty(Etiqueta))
            {
                rptEtiqueta oEtiqueta = new rptEtiqueta();
                oEtiqueta.SetParameterValue("item", Item);
                oEtiqueta.SetParameterValue("desc", Desc);
                oEtiqueta.SetParameterValue("peso", Peso);
                oEtiqueta.SetParameterValue("calidad", Calidad);
                oEtiqueta.SetParameterValue("colada", Colada);
                oEtiqueta.SetParameterValue("pieza", Pieza);
                oEtiqueta.SetParameterValue("etiqueta", Etiqueta);
                oEtiqueta.SetParameterValue("medida", Colada);
                oEtiqueta.SetParameterValue("Correlativo", "");
                frmReportViewer viwer = new frmReportViewer(oEtiqueta);
                viwer.StartPosition = FormStartPosition.CenterScreen;
                viwer.ShowDialog();

            }
        }
    }
}
