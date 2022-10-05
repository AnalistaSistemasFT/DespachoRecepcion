using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRN.Componentes;
using CRN.Entidades;
using Entidades;
using DevExpress.XtraGrid;
using DevExpress.Data;
using DevExpress.XtraGrid.Views.Grid;

namespace WFConsumo
{
    public partial class frmVerOrdenes : DevExpress.XtraEditors.XtraForm
    {
        COrdenSync cOrden;
        OrdenSync oOrden;
        int iSucursal;
        string Orden,Centro;

        decimal CostoTotal = 0, CostoPrimera = 0, CostoSegunda = 0, TotalCostoSegunda = 0;
        decimal PesoPrimeraKgs, PesoPrimeraPza; int PiezasPrimeraKgs, PiezasPrimeraPza;
        decimal KgsPrimera = 0, CostoKgsPrimera = 0,CostoPzaPrimera = 0;
        int PiezasPrimera = 0;

        public frmVerOrdenes(int sucursal)
        {
            InitializeComponent();
            iSucursal = sucursal;
            //gridView3.OptionsBehavior.AutoPopulateColumns = false;
            //gridView3.OptionsView.ShowFooter = true;
            gridView1.OptionsSelection.MultiSelect = true;
            gridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CellSelect;
            gridView1.OptionsClipboard.CopyColumnHeaders = DevExpress.Utils.DefaultBoolean.False;
            gridView2.OptionsSelection.MultiSelect = true;
            gridView2.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CellSelect;
            gridView2.OptionsClipboard.CopyColumnHeaders = DevExpress.Utils.DefaultBoolean.False;
            gridView3.OptionsSelection.MultiSelect = true;
            gridView3.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CellSelect;
            gridView3.OptionsClipboard.CopyColumnHeaders = DevExpress.Utils.DefaultBoolean.False;
            CargaForm();
            //gridView3.PopulateColumns();
        }

        private void CargaForm()
        {
            Cursor.Current = Cursors.WaitCursor;
            cOrden = new COrdenSync();
            DataSet ds = cOrden.TraerTodosParaRevision(iSucursal);
            DataTable dt = ds.Tables[0];
            //dt.Columns.Add("COLUMNA1");
            dgvOrdenes.DataSource = dt;
            if (gridView3.Columns["Orden"].SummaryItem.Collection.Count == 1)
            {
                GridColumnSummaryItem OrdenCount = new GridColumnSummaryItem();
                OrdenCount.SummaryType = SummaryItemType.Count;
                OrdenCount.DisplayFormat = "RECUENTO = {0}";
                gridView3.Columns["Orden"].SummaryItem.Collection.Add(OrdenCount);
            }
            lblFilas.Text = gridView3.RowCount.ToString() + " Registros";
            Cursor.Current = Cursors.Default;
        }

        private void frmVerOrdenes_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void gridView3_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var rowHandle = gridView3.FocusedRowHandle;
            if (!gridView3.IsFilterRow(rowHandle))
            {
                Orden = gridView3.GetRowCellValue(rowHandle, "Orden").ToString();
                Centro = gridView3.GetRowCellValue(rowHandle, "Centro").ToString();
                CargaGrilla(tabControl1.SelectedIndex);
            }
        }

        private void tsbRevisar_Click(object sender, EventArgs e)
        {
            string message;
            string caption;
            //var rowHandle = gridView3.FocusedRowHandle;
            //MessageBox.Show(gridView3.GetRowCellValue(rowHandle, "Orden").ToString());
            message = Orden + " se enviará a Revisión Está seguro?";
            caption = "Revisar Producción";


            MessageBoxButtons mb = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(message, caption, mb);
            if (result == DialogResult.Yes)
            {
                try
                {
                    GuardarOrden(false);
                    CargaForm();
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                    System.Console.ReadLine();
                }

            }
        }

        private void tsbEsDeCliente_Click(object sender, EventArgs e)
        {
            string message;
            string caption;
            //var rowHandle = gridView3.FocusedRowHandle;
            //MessageBox.Show(gridView3.GetRowCellValue(rowHandle, "Orden").ToString());
            message = Orden + " Enviar Es de Cliente, Está seguro?";
            caption = "Revisar Producción";


            MessageBoxButtons mb = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(message, caption, mb);
            if (result == DialogResult.Yes)
            {
                try
                {
                    GuardarOrden(true);
                    CargaForm();
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                    System.Console.ReadLine();
                }

            }

        }

        private void frmVerOrdenes_Load(object sender, EventArgs e)
        {
        }

        private void dgvOrdenes_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.G && e.Control)
            {
                bool VALOR = gridView3.OptionsView.ShowAutoFilterRow;
                gridView3.OptionsView.ShowAutoFilterRow = !VALOR;
            }
        }

        private void dgvConsumidos_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.G && e.Control)
            {
                bool VALOR = gridView1.OptionsView.ShowAutoFilterRow;
                gridView1.OptionsView.ShowAutoFilterRow = !VALOR;
            }
        }

        private void dgvProducidos_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.G && e.Control)
            {
                bool VALOR = gridView2.OptionsView.ShowAutoFilterRow;
                gridView2.OptionsView.ShowAutoFilterRow = !VALOR;
            }
        }

        private void GuardarOrden(bool EsCliente)
        {
            try
            {

                oOrden = new OrdenSync();
                //oOrden=cOrden.TraerOrdenSync(Orden);
                oOrden.CentroTrabajo = gridView3.GetRowCellValue(gridView3.FocusedRowHandle, "Centro").ToString();
                oOrden.Fecha = DateTime.Now;
                oOrden.FechaCierre = DateTime.Now;
                oOrden.ItemFLigado = string.Empty;
                oOrden.OrdenId = Orden;
                oOrden.OrdenLigada = string.Empty;
                oOrden.EsDeCliente = EsCliente;
                if (EsCliente)
                    oOrden.Status = "CLOSE";
                else
                    oOrden.Status = "OPEN";
                oOrden.SucursalDestino = 0;
                oOrden.SucursalId = iSucursal;
                oOrden.TipoOrden = "PRODUCCION";
                oOrden.MovConsumidoList = ObtenerConsumido(oOrden.CentroTrabajo, Orden);
                oOrden.MovProducidoList = ObtenerProducido(oOrden.CentroTrabajo, Orden);

                cOrden.GuardarOrdenSync(oOrden);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        private List<MovConsumido> ObtenerConsumido(string Centro,string Orden)
        {
            List<MovConsumido> l=new List<MovConsumido>();
            DataSet ds;
            MovConsumido oMC;
            //CMovConsumido cMC;
            CConsumido cCons = new CConsumido();
            ds = cCons.TraerTodosConsumido(Centro, Orden);
            DataTable dt = ds.Tables[0];
            foreach(DataRow dr in dt.Rows)
            {
                oMC = new MovConsumido();
                oMC.FCS_ID = Guid.NewGuid();
                oMC.PAQUETEID= dr["Paquete"].ToString();
                oMC.NRO_ORDEN = Orden;
                oMC.UNIDAD= dr["Unidad"].ToString();
                oMC.CANTIDAD_CONSUMIDA = Convert.ToDecimal(dr["Cantidad"]);
                oMC.CENTRO_TRABAJO = Centro;
                oMC.FCS_BATCH_LABEL_1= dr["Origen"].ToString();
                oMC.STATUS = "OPEN";
                oMC.FECHA = Convert.ToDateTime(dr["Fecha"]);
                oMC.Item= dr["Item"].ToString();
                oMC.Item_Desc = dr["Descripcion"].ToString();
                oMC.AXTrackingType = dr["AXTrackingType"].ToString();
                oMC.AXUnitMeasure = dr["AXUnitMeasure"].ToString();
                oMC.AXCode = dr["AXCode"].ToString();
                oMC.Colada = dr["Colada"].ToString();
                if (oMC.AXTrackingType == "SE-LO")
                    oMC.NumSerie = dr["NumSerie"].ToString();
                else
                    oMC.NumSerie = string.Empty;
                //oMC.NumSerie = dr["NumSerie"].ToString().Substring(0,20);
                oMC.FechaIntegracion = DateTime.Now;
                oMC.FCS_MACHINE = dr["FCS_MACHINE"].ToString();

                l.Add(oMC);
                //                cMC = new CMovConsumido();

                //                cMC.GuardarMovConsumido(oMC);

            }
            return l;
        }

        private List<MovProducido> ObtenerProducido(string Centro, string Orden)
        {
            List<MovProducido> l = new List<MovProducido>();
            CCentroTrabajo cc = new CCentroTrabajo();
            CentroTrabajo oC;
            oC = cc.TraerCentroTrabajo(Centro);
            int i = 0;
            DataSet ds;
            MovProducido oMP;
            CProducido cProd = new CProducido();
            ds = cProd.TraerTodosProducido(Centro, Orden);
            DataTable dt = ds.Tables[0];
            decimal PrecioTon = ObtenerPrecioTonelada(oC, Orden);
            Costo oCosto = new Costo();
            oCosto.CalculoCosto(dt, PrecioTon);
            foreach (DataRow dr in dt.Rows)
            {
                oMP = new MovProducido();
                i++;
                oMP.PAQUETEID = dr["Paquete"].ToString();
                oMP.NRO_ORDEN = Orden;
                oMP.ITEM = dr["Item"].ToString();
                oMP.ITEM_DESC = dr["Descripcion"].ToString();
                oMP.PESO  = Convert.ToDecimal(dr["Peso"]);
                oMP.PIEZAS = Convert.ToInt32(dr["Piezas"]);
                oMP.CENTRO_TRABAJO = Centro;
                oMP.FBC_BATCH_LABEL_1 = dr["FBC_BATCH_LABEL_1"].ToString();
                oMP.STATUS = "OPEN";
                oMP.FECHA = Convert.ToDateTime(dr["fbc_ins_date"]);
                oMP.FBC_BATCH_LABEL_2 = "";
                oMP.POSICION = i;
                oMP.CALIDAD= dr["Estado"].ToString();
                oMP.AXUnitMeasure = dr["AXUnitMeasure"].ToString();
                oMP.AXCode = dr["AXCode"].ToString();
                oMP.Colada = dr["Colada"].ToString();
                oMP.FechaIntegracion = DateTime.Now;

                decimal CostoUnitario=0, CostoPaquete = 0;

                if (oC.TipoCosteo == (int)Entidades.TipoCosteo.SinCosto)
                {
                    CostoUnitario = 0;
                    CostoPaquete = 0;
                }
                else
                {
                    if (oMP.CALIDAD != "GOOD")
                    {
                        CostoUnitario = 0.01M;
                        CostoPaquete = CostoUnitario * oMP.PESO;
                    }
                    else
                    {
                        if (oMP.AXUnitMeasure == "KGS")
                        {
                            CostoUnitario = oCosto.CostoKgsPrimera;
                            CostoPaquete = oCosto.CostoKgsPrimera * oMP.PESO;
                        }
                        else
                        {
                            CostoUnitario = oCosto.CostoPzaPrimera;
                            CostoPaquete = CostoUnitario * oMP.PIEZAS;
                        }
                    }
                }
                oMP.CostoUnitario = CostoUnitario;
                oMP.CostoTotal = CostoPaquete;

                l.Add(oMP);

            }
            oCosto = null;
            return l;
        }
        decimal ObtenerPrecioTonelada(CentroTrabajo oC,string Orden)
        {
            decimal PrecioTon = 0;
            if (oC.TipoCosteo == (int)Entidades.TipoCosteo.PorCentroDeTrabajo)
                PrecioTon = oC.PrecioTon;
            else if (oC.TipoCosteo == (int)Entidades.TipoCosteo.PorProduccion)
            {
                COrdenSync cOrden = new COrdenSync();
                Decimal Diametro = cOrden.ObtenerDiametroOrden(Orden);
                CMedidaPrecio cMP = new CMedidaPrecio();
                MedidaPrecio oMP;
                oMP = cMP.TraerMedidaPrecio(Centro, Diametro);

                PrecioTon = oMP.PrecioTon;
            }
            else if (oC.TipoCosteo == (int)Entidades.TipoCosteo.SinCosto)
            {
                PrecioTon = 0;
            }
            return PrecioTon;
        }
        void CalulaCosto2(DataTable dt,decimal PrecioTon)
        {

            decimal PrecioKg = PrecioTon / 1000;
            decimal sumaPeso = dt.AsEnumerable().Sum(x => x.Field<decimal>("Peso"));

            var sumaPiezas = dt.AsEnumerable().Sum(x => x.Field<short>("Piezas"));

            var result = from r in dt.AsEnumerable()
                         group r by new { Estado = r["Estado"], Unidad = r["AXUnitMeasure"] } into g
                         select new
                         {
                             Estado = g.Key.Estado,
                             Unidad = g.Key.Unidad,
                             SumPeso = g.Sum(x => Convert.ToDecimal(x["Peso"])),
                             SumPiezas = g.Sum(x => Convert.ToDecimal(x["Piezas"]))
                         };

            foreach (var r in result)
            {
                if (r.Estado.ToString() == "GOOD")
                {
                    PiezasPrimera += (short)r.SumPiezas;
                    KgsPrimera += (decimal)r.SumPeso;
                    if (r.Unidad.ToString() == "KGS")
                    {
                        PesoPrimeraKgs = (decimal)(r.SumPeso);
                        PiezasPrimeraKgs = (short)(r.SumPiezas);
                    }
                    else
                    {
                        PesoPrimeraPza = (decimal)(r.SumPeso);
                        PiezasPrimeraPza = (short)(r.SumPiezas);
                    }
                }
                else
                {
                    CostoSegunda = (0.01M * r.SumPeso);
                    TotalCostoSegunda += CostoSegunda;
                }
                Console.WriteLine("Estado {0}, Unidad {1}, Peso {2}, Piezas {3}", r.Estado, r.Unidad, r.SumPeso, r.SumPiezas);
            }


            CostoTotal = PrecioKg * sumaPeso;

            CostoPrimera = CostoTotal - TotalCostoSegunda;
            if (KgsPrimera > 0)
                CostoKgsPrimera = CostoPrimera / KgsPrimera;
            else
                CostoKgsPrimera = 0;

            if (PiezasPrimeraPza > 0)
                CostoPzaPrimera = CostoKgsPrimera * PesoPrimeraPza / PiezasPrimeraPza;
            else
                CostoPzaPrimera = 0;
        }

        void CalculoCosto(DataTable dt)
        {
            CCentroTrabajo cc = new CCentroTrabajo();
            CentroTrabajo oC;
            decimal PrecioTon=0;
            oC = cc.TraerCentroTrabajo(Centro);
            if (oC.TipoCosteo == (int)Entidades.TipoCosteo.PorCentroDeTrabajo)
                PrecioTon = oC.PrecioTon;
            else if(oC.TipoCosteo== (int)Entidades.TipoCosteo.PorProduccion)
            {
                COrdenSync cOrden = new COrdenSync();
                Decimal Diametro = cOrden.ObtenerDiametroOrden(Orden);
                CMedidaPrecio cMP = new CMedidaPrecio();
                MedidaPrecio oMP;
                oMP = cMP.TraerMedidaPrecio(Centro, Diametro);

                PrecioTon = oMP.PrecioTon;
            }
            else if (oC.TipoCosteo == (int)Entidades.TipoCosteo.SinCosto)
            {
                PrecioTon = 0;
            }
            //lblPrecioTonelada.Text = PrecioTon.ToString();
            decimal PrecioKg = PrecioTon / 1000;
            decimal sumaPeso = dt.AsEnumerable().Sum(x => x.Field<decimal>("Peso"));
            //decimal sumaPeso = oOrden.ProducidoList.Sum(item => item.Peso);
            //lblTotalPeso.Text = sumaPeso.ToString();

            //decimal sumaPiezas = oOrden.ProducidoList.Sum(item => item.Piezas);
            var sumaPiezas = dt.AsEnumerable().Sum(x => x.Field<short>("Piezas"));
            
            var result = from r in dt.AsEnumerable()
             group r by new { Estado = r["Estado"], Unidad = r["AXUnitMeasure"] } into g
             select new { Estado = g.Key.Estado, 
                          Unidad = g.Key.Unidad, 
                          SumPeso = g.Sum(x => Convert.ToDecimal(x["Peso"])),
                          SumPiezas = g.Sum(x => Convert.ToDecimal(x["Piezas"]))
             };
            
            foreach (var r in result)
            {
                if (r.Estado.ToString() == "GOOD")
                {
                    PiezasPrimera += (short)r.SumPiezas;
                    KgsPrimera += (decimal)r.SumPeso;
                    if (r.Unidad.ToString() == "KGS")
                    {
                        PesoPrimeraKgs = (decimal)(r.SumPeso);
                        PiezasPrimeraKgs = (short)(r.SumPiezas);
                    }
                    else
                    {
                        PesoPrimeraPza = (decimal)(r.SumPeso);
                        PiezasPrimeraPza = (short)(r.SumPiezas);
                    }
                }
                else
                {
                    CostoSegunda = (0.01M * r.SumPeso);
                    TotalCostoSegunda += CostoSegunda;
                }
                Console.WriteLine("Estado {0}, Unidad {1}, Peso {2}, Piezas {3}", r.Estado, r.Unidad, r.SumPeso,r.SumPiezas);
            }
            
            CostoTotal = PrecioKg * sumaPeso;
            CostoPrimera = CostoTotal - TotalCostoSegunda;
            if (KgsPrimera > 0)
                CostoKgsPrimera = CostoPrimera / KgsPrimera;
            else
                CostoKgsPrimera = 0;

            if (PiezasPrimeraPza > 0)
                CostoPzaPrimera = CostoKgsPrimera * PesoPrimeraPza / PiezasPrimeraPza;
            else
                CostoPzaPrimera = 0;
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargaGrilla(tabControl1.SelectedIndex);
        }

         void CargaGrilla(int indice)
        {
            Cursor.Current = Cursors.WaitCursor;
            DataSet ds; DataTable dt;
            if (indice == 0)
            {
                CConsumido cCsmd = new CConsumido();
                ds = cCsmd.TraerTodosConsumido(Centro, Orden);
                dt = ds.Tables[0];
                dgvConsumidos.DataSource = dt;
                if (gridView1.Columns["Paquete"].SummaryItem.Collection.Count == 1)
                {
                    GridColumnSummaryItem CsmdCount = new GridColumnSummaryItem();
                    CsmdCount.SummaryType = SummaryItemType.Count;
                    CsmdCount.DisplayFormat = "RECUENTO = {0}";
                    gridView1.Columns["Paquete"].SummaryItem.Collection.Add(CsmdCount);
                }
                if (gridView1.Columns["Cantidad"].SummaryItem.Collection.Count == 1)
                {
                    GridColumnSummaryItem CsmdTotal = new GridColumnSummaryItem();
                    CsmdTotal.SummaryType = SummaryItemType.Sum;
                    CsmdTotal.DisplayFormat = "SUMA = {0}";
                    gridView1.Columns["Cantidad"].SummaryItem.Collection.Add(CsmdTotal);
                }
            }
            else
            {
                CProducido cProd = new CProducido();
                ds = cProd.TraerTodosProducido(Centro, Orden);
                dt = ds.Tables[0];
                dgvProducidos.DataSource = dt;
                if (gridView2.Columns["Paquete"].SummaryItem.Collection.Count == 1)
                {
                    GridColumnSummaryItem ProdCount = new GridColumnSummaryItem();
                    ProdCount.SummaryType = SummaryItemType.Count;
                    ProdCount.DisplayFormat = "RECUENTO = {0}";
                    gridView2.Columns["Paquete"].SummaryItem.Collection.Add(ProdCount);
                }
                if (gridView2.Columns["Peso"].SummaryItem.Collection.Count == 1)
                {
                    GridColumnSummaryItem ProdTotal = new GridColumnSummaryItem();
                    ProdTotal.SummaryType = SummaryItemType.Sum;
                    ProdTotal.DisplayFormat = "SUMA = {0}";
                    gridView2.Columns["Peso"].SummaryItem.Collection.Add(ProdTotal);
                }
            }
            Cursor.Current = Cursors.Default ;
        }

         private void dgvOrdenes_Click(object sender, EventArgs e)
         {

         }

         private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
         {

         }

         private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
         {

         }

    }
}
