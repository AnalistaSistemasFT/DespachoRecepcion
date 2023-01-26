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
        string sEstado = string.Empty;
        List<string> container = new List<string>();
        public frmPaquetes(int iTIpo)
        {
            InitializeComponent();
            container = new List<string>();
            if (iTIpo == 1)
            {
                container.Add("ACTIVO");
                container.Add("TRANSITO");
            }
            else
            {
                container.Add("INACTIVO");
                container.Add("ANULADO");
            }
            sEstado = string.Join(",", container.Select(x => string.Format("'{0}'", x)));
            cargarPaquetes();
            rbetiqueta1.Checked = true;
            rbactivo.Checked = true;
        }

        private void cargarPaquetes()
        {
            DataSet dtsAnotacion = oPaquete.TraerTodoPaquetesActivos(sEstado, Entidades.utilitario.iSucursal);
            this.gridPaquetes.DataSource = dtsAnotacion.Tables[0];

        }

        string Item = string.Empty;
        string Desc = string.Empty;
        string Peso = string.Empty;
        string Pieza = string.Empty;
        string Etiqueta = string.Empty;
        string Colada = string.Empty;
        string Calidad = string.Empty;
        string Orden = string.Empty;
        string FechaVenc = string.Empty;
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
            Orden = (view.GetRowCellDisplayText(row[0], view.Columns[12])).ToString();
            FechaVenc = (view.GetRowCellDisplayText(row[0], view.Columns[3])).ToString();
            //PaqueteId, SucursalId, AlmacenId, Fecha, CeldaId, Nivel, p.ItemId, i.Descripcion,Login, Status, Peso, p.Piezas, OrdenId,
            //Contenedor, Colada, CentroTrabajo, p.ItemFId, Metros,i.Calidad

            if (rbetiqueta1.Checked == true)
            {
                rptEtiqueta oEtiqueta = new rptEtiqueta();
                oEtiqueta.SetDatabaseLogon("sa", "PlantaV.", "192.168.0.200", "LYBK");
                oEtiqueta.SetParameterValue("item", Item);
                oEtiqueta.SetParameterValue("desc", Desc);
                oEtiqueta.SetParameterValue("peso", Peso);
                oEtiqueta.SetParameterValue("calidad", Calidad);
                oEtiqueta.SetParameterValue("colada", Colada);
                oEtiqueta.SetParameterValue("pieza", Pieza);
                oEtiqueta.SetParameterValue("etiqueta", Etiqueta);
                oEtiqueta.SetParameterValue("medida", Desc);
                oEtiqueta.SetParameterValue("correlativo", "0");
                oEtiqueta.SetParameterValue("etiqueta", Etiqueta);
                crviwer.ReportSource = oEtiqueta;

            }

            if (rbetiqueta2.Checked == true)
            {
                Factura oetiqueta2 = new Factura();
                oetiqueta2.SetDatabaseLogon("sa", "PlantaV.", "192.168.0.200", "LYBK");
                oetiqueta2.SetParameterValue("orden", Orden);
                oetiqueta2.SetParameterValue("item", Item);
                oetiqueta2.SetParameterValue("desc", Desc);
                oetiqueta2.SetParameterValue("peso", Peso);
                oetiqueta2.SetParameterValue("calidad", Calidad);
                oetiqueta2.SetParameterValue("colada", Colada);
                oetiqueta2.SetParameterValue("pieza", Pieza);
                oetiqueta2.SetParameterValue("paquete", Etiqueta);
                oetiqueta2.SetParameterValue("correlativo", "0");
                oetiqueta2.SetParameterValue("fechafac", FechaVenc);
                crviwer.ReportSource = oetiqueta2;
            }
                crviwer.Zoom(100);

        }


        

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Etiqueta))
            {
                rptEtiqueta oEtiqueta = new rptEtiqueta();
                oEtiqueta.SetDatabaseLogon("sa", "PlantaV.", "192.168.0.200", "LYBK");
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

        private void rbetiqueta1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbetiqueta1.Checked == true)
            {
                rbetiqueta2.Checked = false;
            }
            else
            {
                rbetiqueta2.Checked = true;
            }
        }

        private void rbeqtiqueta2_CheckedChanged(object sender, EventArgs e)
        {
            if (rbetiqueta2.Checked == true)
            {
                rbetiqueta1.Checked = false;
            }
            else
            {
                rbetiqueta1.Checked = true;
            }
        }

        private void rbactivo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbactivo.Checked == true)
            {
                container = new List<string>();
                rbinactivo.Checked = false;
                container.Add("ACTIVO");
                container.Add("TRANSITO");
                sEstado = string.Join(",", container.Select(x => string.Format("'{0}'", x)));
                cargarPaquetes();
            }
        }

        private void rbinactivo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbinactivo.Checked == true)
            {
                container = new List<string>();
                rbactivo.Checked = false;
                container.Add("INACTIVO");
                container.Add("ANULADO");
                sEstado = string.Join(",", container.Select(x => string.Format("'{0}'", x)));
                cargarPaquetes();
            }
        }

        private void btnImprimirLista_Click(object sender, EventArgs e)
        {
            
        }
    }
}
