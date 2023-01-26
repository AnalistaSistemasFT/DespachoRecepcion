using CRN.Componentes;
using DevExpress.XtraGrid.Views.Base;
using IronBarCode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFConsumo.Reportes;

namespace WFConsumo.Recepcion
{
    public partial class frmAdmAnotacion : Form
    {
        CAnotacion oanotacion = new CAnotacion();
        CAnotacionDet oanotaciondet = new CAnotacionDet();
        public frmAdmAnotacion(string status)
        {
            InitializeComponent();
            cargarAnotaciones(status);
            checkBox1.Checked = true;
            if(status == "CLOSE")
            {
                btnNuevo.Enabled = false;
                btnAnular.Enabled = false;
                btnReprint.Enabled = false;
            }
            else
            {
                btnNuevo.Enabled = true;
                btnAnular.Enabled = true;
                btnReprint.Enabled = true;
            }
        }

        private void cargarAnotaciones(string status)
        {
            DataSet dtsAnotacion = oanotacion.CargarAnotacionesPorEstado(status, Entidades.utilitario.iSucursal);
            this.gridControl1.DataSource = dtsAnotacion.Tables[0];

        }

        private void cargarAnotacionesDet(string Anotacion)
        {
            DataSet dtsAnotacionDet = oanotaciondet.CargarAnotacionesDet(Anotacion);
            this.gridControl2.DataSource = dtsAnotacionDet.Tables[0];

        }
        string Anotacion = string.Empty;
        string CodigoBarra = string.Empty;
        string Chofer = string.Empty;
        string Camion = string.Empty;
        string Placa = string.Empty;
        string CI = string.Empty;
        string Procedencia = string.Empty;
        string Propietario = string.Empty;
        string Correlativo1 = string.Empty;
        string Sucursal = string.Empty;
        string Manifiesto = string.Empty;
        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            
            ColumnView view = this.gridControl1.MainView as ColumnView;
            int[] row = view.GetSelectedRows();
            if (row.Count() > 0) 
            { 
                view.FocusedRowHandle = row[0];
               
                Anotacion = (view.GetRowCellDisplayText(row[0], view.Columns[0])).ToString();
                Chofer = (view.GetRowCellDisplayText(row[0], view.Columns[2])).ToString();
                Camion = (view.GetRowCellDisplayText(row[0], view.Columns[3])).ToString();
                Placa = (view.GetRowCellDisplayText(row[0], view.Columns[4])).ToString();
                CI = (view.GetRowCellDisplayText(row[0], view.Columns[5])).ToString();
                Procedencia = (view.GetRowCellDisplayText(row[0], view.Columns[6])).ToString();
                Propietario = (view.GetRowCellDisplayText(row[0], view.Columns[7])).ToString();
                Correlativo1 = (view.GetRowCellDisplayText(row[0], view.Columns[10])).ToString();
                Sucursal = (view.GetRowCellDisplayText(row[0], view.Columns[12])).ToString();
                Manifiesto = (view.GetRowCellDisplayText(row[0], view.Columns[14])).ToString();
                cargarAnotacionesDet(Anotacion);
               
            }
            else
                Anotacion = string.Empty;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Etiqueta))
            {
                if (Estado == "OPEN")
                {
                    if(checkBox1.Checked == true) 
                    { 
                        rptEtiqueta oEtiqueta = new rptEtiqueta();
                       
                        oEtiqueta.SetParameterValue("item", Item);
                        oEtiqueta.SetParameterValue("desc", Desc);
                        oEtiqueta.SetParameterValue("peso", Peso);
                        oEtiqueta.SetParameterValue("calidad", Calidad);
                        oEtiqueta.SetParameterValue("colada", Colada);
                        oEtiqueta.SetParameterValue("pieza", Pieza);
                        oEtiqueta.SetParameterValue("etiqueta", Etiqueta);
                        oEtiqueta.SetParameterValue("medida", PackList);
                        oEtiqueta.SetParameterValue("correlativo", Correlativo);

                        //frmReportViewer viwer = new frmReportViewer(oEtiqueta);
                        //viwer.StartPosition = FormStartPosition.CenterScreen;
                        //viwer.ShowDialog();
                        oanotaciondet.UpdateAnotacionDet(Etiqueta, "IMPR");
                        oEtiqueta.PrintToPrinter(2, true, 1, 1);
                    }
                    if (checkBox2.Checked == true)
                    {
                        Factura oetiqueta2 = new Factura();
                        oetiqueta2.SetParameterValue("orden", Anotacion);
                        oetiqueta2.SetParameterValue("item", Item);
                        oetiqueta2.SetParameterValue("desc", Desc);
                        oetiqueta2.SetParameterValue("peso", Peso);
                        oetiqueta2.SetParameterValue("calidad", Calidad);
                        oetiqueta2.SetParameterValue("colada", Colada);
                        oetiqueta2.SetParameterValue("pieza", Pieza);
                        oetiqueta2.SetParameterValue("paquete", Etiqueta);
                        //oetiqueta2.SetParameterValue("medida", PackList);
                        oetiqueta2.SetParameterValue("correlativo", Correlativo);
                       // oetiqueta2.SetParameterValue("fechafac", Correlativo);
                        //frmReportViewer viwer = new frmReportViewer(oEtiqueta);
                        //viwer.StartPosition = FormStartPosition.CenterScreen;
                        //viwer.ShowDialog();
                        oanotaciondet.UpdateAnotacionDet(Etiqueta, "IMPR");
                        oetiqueta2.PrintToPrinter(1, true, 1, 1);

                    }
                        cargarAnotacionesDet(Anotacion);
                    //printDocument1 = new System.Drawing.Printing.PrintDocument();
                    //PrinterSettings ps = new PrinterSettings();
                    //printDocument1.PrinterSettings = ps;
                    //printDocument1.PrintPage += imprimir;
                    //printDocument1.Print()
                }
            }
            else
            {
                MessageBox.Show("Seleccione Una Fila");
            }
        }

        private void imprimir(object sender, PrintPageEventArgs e)
        {

        }

        string Item = string.Empty;
        string Desc = string.Empty;
        string Peso = string.Empty;
        string Pieza = string.Empty;
        string Etiqueta = string.Empty;
        string Colada = string.Empty;
        string Calidad = string.Empty;
        string Estado = string.Empty;
        string Correlativo = string.Empty;
        string PackList = string.Empty;
        DateTime FechaCad = DateTime.Now;
        private void gridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            ColumnView view = this.gridControl2.MainView as ColumnView;
            int[] row = view.GetSelectedRows();
            view.FocusedRowHandle = row[0];
            if (row.Count() > 0)
            {
                Item = (view.GetRowCellDisplayText(row[0], view.Columns[22])).ToString();
                Desc = (view.GetRowCellDisplayText(row[0], view.Columns[4])).ToString();
                Pieza = (view.GetRowCellDisplayText(row[0], view.Columns[5])).ToString();
                Peso = (view.GetRowCellDisplayText(row[0], view.Columns[6])).ToString();
                Colada = (view.GetRowCellDisplayText(row[0], view.Columns[7])).ToString();
                Etiqueta = (view.GetRowCellDisplayText(row[0], view.Columns[0])).ToString();
                PackList = (view.GetRowCellDisplayText(row[0], view.Columns[15])).ToString();
                Calidad = (view.GetRowCellDisplayText(row[0], view.Columns[20])).ToString();
                Correlativo = (view.GetRowCellDisplayText(row[0], view.Columns[12])).ToString();
                Estado = (view.GetRowCellDisplayText(row[0], view.Columns[14])).ToString();
                FechaCad = Convert.ToDateTime((view.GetRowCellDisplayText(row[0], view.Columns[21])).ToString());


                
            }
            else
            {
                PackList = string.Empty;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sError = string.Empty;
            DataTable ds;
            ds = (DataTable)gridControl2.DataSource;
            int a = oanotacion.InsertarProcesoRecepcion(out sError, ds, Anotacion, DateTime.Now, Chofer, Convert.ToInt32(Camion), Placa, CI, Propietario, Entidades.utilitario.sUsuario, "S/O", 1, "OPEN", Convert.ToInt32(Sucursal), Convert.ToInt32(Procedencia), Anotacion, 1, false, Manifiesto, "0", 0, "0", 0, Entidades.utilitario.iAlmacen);
            if (a > 0)
            {
                cargarAnotaciones("OPEN");
                MessageBox.Show("Se Genero Con Exito");
            }
            else
            {
                MessageBox.Show("Problemas en la Transaccion");
            }
            
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            DataSet dtsAnotacionDet = oanotaciondet.CargarAnotacionesDet(Anotacion);
            if (dtsAnotacionDet.Tables[0].Rows.Count > 0)
            {
                for(int i = 0; i < dtsAnotacionDet.Tables[0].Rows.Count; i++)
                {
                    string status = dtsAnotacionDet.Tables[0].Rows[i]["Statusi"].ToString().Trim();
                    if (status == "OPEN")
                    {
                        if (checkBox1.Checked == true)
                        {
                            rptEtiqueta oEtiqueta = new rptEtiqueta();
                            oEtiqueta.SetParameterValue("item", dtsAnotacionDet.Tables[0].Rows[i]["ItemId"].ToString().Trim());
                            oEtiqueta.SetParameterValue("desc", dtsAnotacionDet.Tables[0].Rows[i]["Descripcion"].ToString().Trim());
                            oEtiqueta.SetParameterValue("peso", dtsAnotacionDet.Tables[0].Rows[i]["PesoNetoProveedor"].ToString().Trim());
                            oEtiqueta.SetParameterValue("calidad", dtsAnotacionDet.Tables[0].Rows[i]["Calidadi"].ToString().Trim());
                            oEtiqueta.SetParameterValue("colada", dtsAnotacionDet.Tables[0].Rows[i]["Coladai"].ToString().Trim());
                            oEtiqueta.SetParameterValue("pieza", dtsAnotacionDet.Tables[0].Rows[i]["Piezas"].ToString().Trim());
                            oEtiqueta.SetParameterValue("etiqueta", dtsAnotacionDet.Tables[0].Rows[i]["CodigoBarraid"].ToString().Trim());
                            oEtiqueta.SetParameterValue("medida", dtsAnotacionDet.Tables[0].Rows[i]["CodPackList"].ToString().Trim());
                            oEtiqueta.SetParameterValue("correlativo", dtsAnotacionDet.Tables[0].Rows[i]["Correlativodet"].ToString().Trim());
                            oanotaciondet.UpdateAnotacionDet(dtsAnotacionDet.Tables[0].Rows[i]["CodigoBarraid"].ToString().Trim(), "IMPR");
                            oEtiqueta.PrintToPrinter(2, true, 1, 1);
                        }
                        if (checkBox2.Checked == true)
                        {
                            Factura oetiqueta2 = new Factura();
                            oetiqueta2.SetParameterValue("orden", Anotacion);
                            oetiqueta2.SetParameterValue("item", Item);
                            oetiqueta2.SetParameterValue("desc", Desc);
                            oetiqueta2.SetParameterValue("peso", Peso);
                            oetiqueta2.SetParameterValue("calidad", Calidad);
                            oetiqueta2.SetParameterValue("colada", Colada);
                            oetiqueta2.SetParameterValue("pieza", Pieza);
                            oetiqueta2.SetParameterValue("paquete", Etiqueta);
                            //oetiqueta2.SetParameterValue("medida", PackList);
                            oetiqueta2.SetParameterValue("correlativo", Correlativo);
                            oetiqueta2.SetParameterValue("fechafac", FechaCad);
                            //frmReportViewer viwer = new frmReportViewer(oEtiqueta);
                            //viwer.StartPosition = FormStartPosition.CenterScreen;
                            //viwer.ShowDialog();
                            oanotaciondet.UpdateAnotacionDet(Etiqueta, "IMPR");
                            oetiqueta2.PrintToPrinter(1, true, 1, 1);

                        }
                    }
                    cargarAnotacionesDet(Anotacion);
                }
            }
            
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            oanotaciondet.UpdateAnotacionDet(Etiqueta, "ANULADO");
            cargarAnotacionesDet(Anotacion);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Anotacion))
            {
                frmAdmDetAnotacion ofrmDetAno = new frmAdmDetAnotacion(Anotacion, 1);
                ofrmDetAno.ShowDialog();
                cargarAnotacionesDet(Anotacion);
            }
            else
                MessageBox.Show("No Selecciono Ninguna Fila");
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(PackList))
            { 
                frmAdmDetAnotacion ofrmDetAno = new frmAdmDetAnotacion(Anotacion, 2,Etiqueta);
                ofrmDetAno.ShowDialog();
                cargarAnotacionesDet(Anotacion);
            }
            else
                MessageBox.Show("No Selecciono Ninguna Fila");

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                checkBox2.Checked = false;
            }
           else
            {
                checkBox2.Checked = true;
            }

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkBox1.Checked = false;
            }
           else
            {
                checkBox1.Checked = true;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            int sucursalid = Entidades.utilitario.iSucursal;
            SysSecuencia osecuencia = new SysSecuencia();
            frmAnotacion frmanotacion = new frmAnotacion();
            string sAnotacion = osecuencia.TraerSecuencia(sucursalid, "ANOTACION");
            string sPaquete = osecuencia.TraerSecuencia(sucursalid, "PAQUETE");
            frmanotacion.txtanotacion.Text = sAnotacion;
            frmanotacion.ShowDialog();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            string sError = string.Empty;
            DataTable ds;
            ds = (DataTable)gridControl2.DataSource;
            int a = oanotacion.InsertarProcesoRecepcion(out sError, ds, Anotacion, DateTime.Now, Chofer, Convert.ToInt32(Camion), Placa, CI, Propietario, Entidades.utilitario.sUsuario, "S/O", 1, "OPEN", Convert.ToInt32(Sucursal), Convert.ToInt32(Procedencia), Anotacion, 1, false, Manifiesto, "0", 0, "0", 0, Entidades.utilitario.iAlmacen);
            if (a > 0)
            {
                cargarAnotaciones("OPEN");
                MessageBox.Show("Se Genero Con Exito");
            }
            else
            {
                MessageBox.Show("Problemas en la Transaccion");
            }
        }
    }
}
