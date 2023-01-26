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
using CRN.Entidades;
using WFConsumo.Reportes;
using CAD;
using WFConsumo.Sincronizacion;
using DevExpress.XtraEditors;

namespace WFConsumo
{
    public partial class frmSincroAzul : Form
    {
        CADInformix oInformix;
        CSucursal C_Sucursal;
        public frmSincroAzul(Usuario u,int a)
        {
            InitializeComponent();

            oInformix = new CADInformix();
            C_Sucursal = new CSucursal();
            if (a == 0)
            {
                toolStrip1.Enabled = false;
                CargarMovimiento("SYNC");
            }
            else
            {
                toolStrip1.Enabled = true;
                CargarMovimiento("CLOSE");
            }
        }
        public void CargarMovimiento(string Estado)
        {
            try
            {
                DataSet data = oInformix.TraerMovPdv(Estado, Entidades.utilitario.iSucursal);
                //DataSet data = C_Sucursal.TraerMovPdv(Estado, Entidades.utilitario.iSucursal);
                this.gvmovimiento.DataSource = data.Tables[0];
            }
            catch(Exception err)
            {
                Console.WriteLine("############################### = " + err.ToString());
            } 
        }
        string Movimiento = string.Empty;
        string Fuente = string.Empty;
        string Documento = string.Empty;
        int SucDes = 0;
        int SucOri = 0;
        int SucOriTra = 0;
        string iTipoDoc = string.Empty;
        string iNrodoc = string.Empty;
        private void gvmovimiento_DoubleClick(object sender, EventArgs e)
        {

        } 
        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            ColumnView view = this.gvmovimiento.MainView as ColumnView;
            int[] row = view.GetSelectedRows();
            view.FocusedRowHandle = row[0];
            Movimiento = (view.GetRowCellDisplayText(row[0], view.Columns[0])).ToString().Trim();
            // Fuente = (view.GetRowCellDisplayText(row[0], view.Columns[6])).ToString();
            Documento = (view.GetRowCellDisplayText(row[0], view.Columns[3])).ToString().Trim();
            SucDes = Convert.ToInt32((view.GetRowCellDisplayText(row[0], view.Columns[6])).ToString());
            SucOri = Convert.ToInt32((view.GetRowCellDisplayText(row[0], view.Columns[7])).ToString());
            SucOriTra = Convert.ToInt32((view.GetRowCellDisplayText(row[0], view.Columns[11])).ToString());
            iTipoDoc = (view.GetRowCellDisplayText(row[0], view.Columns[12])).ToString().Trim();
            iNrodoc = (view.GetRowCellDisplayText(row[0], view.Columns[13])).ToString().Trim();
            DataSet dts = oInformix.TraerMovDetPdv(Movimiento);
            gvDetalle.DataSource = dts.Tables[0];
        }
        private void tsNuevo_Click(object sender, EventArgs e)
        {
        } 
        private void GenerarSincronizacion()
        {
            try
            {
                CTraspaso oTraspaso = new CTraspaso();
                CSucursal oSucursa = new CSucursal();
                DataSet dts = oTraspaso.TraerTipoDoc(SucDes);
                int itipdoc = 0;
                if (dts.Tables[0].Rows.Count > 0)
                {
                    itipdoc = Convert.ToInt32(dts.Tables[0].Rows[0][0].ToString());
                }
                int suctransito = oSucursa.TraerSucTransito(SucDes);
                oTraspaso.p_sctttdoc = itipdoc;
                oTraspaso.p_scttndoc = 0;
                oTraspaso.p_scttsuce = SucOriTra;
                //
                oTraspaso.p_scttsucr = SucDes;
                oTraspaso.p_scttfdoc = DateTime.Now;
                oTraspaso.p_scttfreg = DateTime.Now;
                oTraspaso.p_sctiptra = 26001;
                oTraspaso.p_scttdesc = "TRASPASO POR DOCUMENTO " + Documento;
                DataTable dt = (DataTable)gvDetalle.DataSource;
                int inDoc = 0;
                int a = oTraspaso.InsertarTraspaso(out inDoc, oTraspaso, dt, Movimiento);
                if (a > 0)
                {
                    iTipoDoc = itipdoc.ToString();
                    iNrodoc = inDoc.ToString();
                    MessageBox.Show("TRANSACCION COMPLETA");
                    try
                    {
                        ImprmirTraspaso();
                    }
                    catch(Exception err)
                    {
                        XtraMessageBox.Show("Problemas con la impresión, puede realizar su impresion desde 'Historial de traspasos'", "Error al imprimir");
                    }
                    
                }
                else
                {
                    if (inDoc < 0)
                    {
                        MessageBox.Show("Stock insuficiente en sucursal origen " + SucOriTra);
                    }
                    else
                        MessageBox.Show("PROBLEMAS EN LA TRANSACCION");

                }
                CargarMovimiento("SYNC");
            }
            catch (Exception e)
            {
                MessageBox.Show("PROBLEMAS EN LA TRANSACCION " + e.ToString());
                Console.WriteLine("################################ = " + e.ToString());
                Console.WriteLine("%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%% = " + e.HResult.ToString());
            }
        } 
        private void ImprmirTraspaso()
        {
            CTraspaso oTraspaso = new CTraspaso();
            DataSet dts = oTraspaso.ConsultarTraspaso(Convert.ToInt32(iTipoDoc), Convert.ToInt32(iNrodoc));
            rptDocTrasp oReport = new rptDocTrasp();
            oReport.SetDataSource(dts.Tables[0]);
            oReport.SetParameterValue("nrodocumento", Documento);
            oReport.SetParameterValue("placa", "0");
            oReport.SetParameterValue("user", Entidades.utilitario.sUsuario);
            frmReportViewer viwer = new frmReportViewer(oReport);
            viwer.Width = 1000;
            viwer.Height = 800;
            viwer.StartPosition = FormStartPosition.CenterScreen;
            viwer.ShowDialog();
        } 
        private void gridView1_DoubleClick_1(object sender, EventArgs e)
        {
            frmDialog f = new frmDialog();
            if (f.ShowDialog() == DialogResult.OK)
            {
                GenerarSincronizacion();
            }
            else
            {
                MessageBox.Show("se cancelo el proceso");
            }
            CargarMovimiento("SYNC");
        } 
        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(iTipoDoc))
                ImprmirTraspaso();
            else
                MessageBox.Show("No se puede mostrar el reporte");
        }
    }
}