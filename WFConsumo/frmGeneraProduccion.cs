using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CRN.Componentes;
using CRN.Entidades;
using DevExpress.XtraGrid;
using DevExpress.XtraEditors;
using DevExpress.Data;
using DevExpress.XtraGrid.Views.Grid;

namespace WFConsumo
{
    public partial class frmGeneraProduccion : DevExpress.XtraEditors.XtraForm
    {
        string orden,Centro,strStatus;
        int iSucursal;
        COrdenSync cOrden;
        public frmGeneraProduccion()
        {
            InitializeComponent();
        }
        public frmGeneraProduccion(string status,int sucursal)
        {
            InitializeComponent();
            gridView1.OptionsSelection.MultiSelect = true;
            gridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CellSelect;
            gridView1.OptionsClipboard.CopyColumnHeaders = DevExpress.Utils.DefaultBoolean.False;
            gridView2.OptionsSelection.MultiSelect = true;
            gridView2.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CellSelect;
            gridView2.OptionsClipboard.CopyColumnHeaders = DevExpress.Utils.DefaultBoolean.False;
            gridView3.OptionsSelection.MultiSelect = true;
            gridView3.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CellSelect;
            gridView3.OptionsClipboard.CopyColumnHeaders = DevExpress.Utils.DefaultBoolean.False;
            iSucursal = sucursal;
            strStatus = status;
            //dgvEntradas.CellFormatting += dgvEntradas_CellFormatting;
            //dgvEntradas.CellValueChanged += dgvEntradas_CellValueChanged;
            CargarOrdenes(strStatus, iSucursal);

            GridFormatRule gridFormatRule = new GridFormatRule();
            FormatConditionRuleDataBar formatConditionRuleDataBar = new FormatConditionRuleDataBar();
            gridFormatRule.Column = gridView1.Columns["PORCENTAJE"]; ;
            formatConditionRuleDataBar.PredefinedName = "Blue Gradient";
            gridFormatRule.Rule = formatConditionRuleDataBar;
            this.gridView1.FormatRules.Add(gridFormatRule);

        }

        private void frmGeneraProduccion_Load(object sender, EventArgs e)
        {
        }

        private void CargarOrdenes(string status,int sucursal)
        {
            string stat;
            if (status == "CLOSE")
                stat = "'CLOSE','CANCEL'";
            else
                stat = "'OPEN','SUSPEND'";

            cOrden=new COrdenSync();
            DataSet ds = cOrden.TraerTodosOrdenSync(stat, sucursal);
            DataTable dt = ds.Tables[0];
            dgvOrdenes.DataSource = dt;
            gridView1.Columns["PORCENTAJE"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns["PORCENTAJE"].DisplayFormat.FormatString = "p0";

            if (gridView1.Columns["Orden"].SummaryItem.Collection.Count == 1)
            {
                GridColumnSummaryItem CsmdCount = new GridColumnSummaryItem();
                CsmdCount.SummaryType = SummaryItemType.Count;
                CsmdCount.DisplayFormat = "RECUENTO = {0}";
                gridView1.Columns["Orden"].SummaryItem.Collection.Add(CsmdCount);
            }
        }

        private void CargarSalidas(string centro,string orden)
        {
            CConsumido cOrden = new CConsumido();
            DataSet ds = cOrden.TraerResumenConsumido(centro,orden);
            DataTable dt = ds.Tables[0];
            dgvSalidas.DataSource = dt;
            if (gridView2.Columns["Cantidad"].SummaryItem.Collection.Count == 1)
            {
                GridColumnSummaryItem CantidadSum = new GridColumnSummaryItem();
                CantidadSum.SummaryType = SummaryItemType.Sum;
                CantidadSum.DisplayFormat = "SUMA = {0}";
                gridView2.Columns["Cantidad"].SummaryItem.Collection.Add(CantidadSum);
            }
            if (gridView2.Columns["Piezas"].SummaryItem.Collection.Count == 1)
            {
                GridColumnSummaryItem PiezasSum = new GridColumnSummaryItem();
                PiezasSum.SummaryType = SummaryItemType.Sum;
                PiezasSum.DisplayFormat = "SUMA = {0}";
                gridView2.Columns["Piezas"].SummaryItem.Collection.Add(PiezasSum);
            }
        }
        private void CargarEntradas(string centro,string orden)
        {
            CProducido cOrden = new CProducido();
            DataSet ds = cOrden.TraerResumenProducido (centro,orden);
            DataTable dt = ds.Tables[0];
            dgvEntradas.DataSource = dt;
            if (gridView3.Columns["Peso"].SummaryItem.Collection.Count == 1)
            {
                GridColumnSummaryItem PesoEntSum = new GridColumnSummaryItem();
                PesoEntSum.SummaryType = SummaryItemType.Sum;
                PesoEntSum.DisplayFormat = "SUMA = {0}";
                gridView3.Columns["Peso"].SummaryItem.Collection.Add(PesoEntSum);
            }
            if (gridView3.Columns["Piezas"].SummaryItem.Collection.Count == 1)
            {
                GridColumnSummaryItem PiezasEntSum = new GridColumnSummaryItem();
                PiezasEntSum.SummaryType = SummaryItemType.Sum;
                PiezasEntSum.DisplayFormat = "SUMA = {0}";
                gridView3.Columns["Piezas"].SummaryItem.Collection.Add(PiezasEntSum);
            }
        }

        private void frmGeneraProduccion_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void tsSuspender_Click(object sender, EventArgs e)
        {
            var rowHandle = gridView1.FocusedRowHandle;
            orden = gridView1.GetRowCellValue(rowHandle, "Orden").ToString();
            Suspender(orden);
        }

        private void tsEjecutar_Click(object sender, EventArgs e)
        {
            var rowHandle = gridView1.FocusedRowHandle;
            orden = gridView1.GetRowCellValue(rowHandle, "Orden").ToString();
            Centro = gridView1.GetRowCellValue(rowHandle, "CentroTrabajo").ToString();
            Form frm;
            frm = new frmSincroniza(iSucursal, Centro, orden);
            frm.ShowDialog();
            CargarOrdenes(strStatus, iSucursal);
        }

        private void tsCerrar_Click(object sender, EventArgs e)
        {
            var rowHandle = gridView1.FocusedRowHandle;
            orden = gridView1.GetRowCellValue(rowHandle, "Orden").ToString();
            Centro = gridView1.GetRowCellValue(rowHandle, "CentroTrabajo").ToString();

            decimal Porcentaje = Convert.ToDecimal(gridView1.GetRowCellValue(rowHandle, "PORCENTAJE").ToString());
            if (Porcentaje < 1)
                MessageBox.Show("Orden Incompleta");
            else
                CerrarOrden(orden);
        }

        private void CerrarOrden(string Orden)
        {
            COrdenSync cOrden = new COrdenSync();
            OrdenSync oOrden;
            oOrden = cOrden.TraerOrdenSync(Orden);
            if (oOrden.Status == "OPEN")
            {
                string message = "", caption = "";

                message = "La orden "+ Orden +" pasará al historial, está seguro?";
                caption = "Cerrar Producción";
                oOrden.Status = "CLOSE";

                MessageBoxButtons mb = MessageBoxButtons.YesNo;
                DialogResult result;
                result = MessageBox.Show(message, caption, mb);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        cOrden.ModificarOrdenSync(oOrden);
                        CargarOrdenes(strStatus, iSucursal);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
        private void Suspender(string orden)
        {
            COrdenSync cOrden = new COrdenSync();
            OrdenSync oOrden;
            oOrden = cOrden.TraerOrdenSync(orden);
            if (oOrden.Status == "SUSPEND" | oOrden.Status == "OPEN")
            {
                string message="", caption="";

                if (oOrden.Status == "SUSPEND")
                {
                    message = "La orden podrá sincronizarse, está seguro?";
                    caption = "Reactivar Producción";
                    oOrden.Status = "OPEN";
                }
                else if (oOrden.Status == "OPEN")
                {
                    message = "La orden no podrá sincronizarse, está seguro?";
                    caption = "Suspender Producción";
                    oOrden.Status = "SUSPEND";
                }
                //oOrden.FechaCierre = DateTime.Now;
                MessageBoxButtons mb = MessageBoxButtons.YesNo;
                DialogResult result;
                result = MessageBox.Show(message, caption, mb);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        cOrden.ModificarOrdenSync(oOrden);
                        CargarOrdenes(strStatus, iSucursal);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var rowHandle = gridView1.FocusedRowHandle;
            if (!gridView1.IsFilterRow(rowHandle))
            {
                orden = gridView1.GetRowCellValue(rowHandle, "Orden").ToString();
                Centro = gridView1.GetRowCellValue(rowHandle, "CentroTrabajo").ToString();
                //strStatus = gridView1.GetRowCellValue(rowHandle, "Status").ToString();
                CargarSalidas(Centro, orden);
                CargarEntradas(Centro, orden);
            }
        }

        private void dgvOrdenes_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.G && e.Control)
            {
                bool VALOR = gridView1.OptionsView.ShowAutoFilterRow;
                gridView1.OptionsView.ShowAutoFilterRow = !VALOR;
            }
        }

        private void dgvSalidas_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.G && e.Control)
            {
                bool VALOR = gridView2.OptionsView.ShowAutoFilterRow;
                gridView2.OptionsView.ShowAutoFilterRow = !VALOR;
            }
        }

        private void dgvEntradas_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.G && e.Control)
            //{
            //    bool VALOR = gridView3.OptionsView.ShowAutoFilterRow;
            //    gridView3.OptionsView.ShowAutoFilterRow = !VALOR;
            //}
        }

        private void dgvOrdenes_Click(object sender, EventArgs e)
        {

        }

        private void dgvOrdenes_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.G && e.Control)
            {
                bool VALOR = gridView3.OptionsView.ShowAutoFilterRow;
                gridView3.OptionsView.ShowAutoFilterRow = !VALOR;
            }
        }

        private void tsVolver_Click(object sender, EventArgs e)
        {
            var rowHandle = gridView1.FocusedRowHandle;
            decimal Porcentaje = Convert.ToDecimal(gridView1.GetRowCellValue(rowHandle, "PORCENTAJE").ToString());
            if (Porcentaje > 0)
                MessageBox.Show("Sincronización no se puede deshacer");
            else
                Deshacer(orden);
        }
        private void Deshacer(string Orden)
        {
            try
            {
                COrdenSync cOrden = new COrdenSync();
                OrdenSync oOrden;
                oOrden = cOrden.TraerOrdenSync(Orden);
                if (oOrden.Status == "OPEN")
                {
                    string message = "", caption = "";

                    message = "La orden será sacada de este espacio, está seguro?";
                    caption = "Deshacer";

                    //oOrden.FechaCierre = DateTime.Now;
                    MessageBoxButtons mb = MessageBoxButtons.YesNo;
                    DialogResult result;
                    result = MessageBox.Show(message, caption, mb);
                    if (result == DialogResult.Yes)
                    {
                        //try
                        //{
                        cOrden.EliminarOrdenSync(Orden);
                        CargarOrdenes(strStatus, iSucursal);
                        //}
                        //catch (Exception ex)
                        //{
                        //    MessageBox.Show(ex.Message);
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvSalidas_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        
    }
}
