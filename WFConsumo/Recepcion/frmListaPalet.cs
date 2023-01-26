using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CRN.Componentes;
using DevExpress.XtraGrid.Views.Base;
using WFConsumo.Reportes;

namespace WFConsumo.Recepcion
{
    public partial class frmListaPalet : DevExpress.XtraEditors.XtraForm
    {
        int _idSucursal = 0;
        CPaquetes C_Paquetes;
        string _Palet = string.Empty;

        public frmListaPalet(int IdSucursal)
        {
            InitializeComponent();
            C_Paquetes = new CPaquetes();
            _idSucursal = IdSucursal;
            TraerData();
        }
        public void TraerData()
        {
            try
            {
                DataSet data = C_Paquetes.TraerPaletSucursal(_idSucursal);
                gridControl1.DataSource = data.Tables[0];
            }
            catch(Exception err)
            {
                Console.WriteLine("######################## = " + err.ToString());
            }
        } 
        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                ColumnView view = this.gridControl1.MainView as ColumnView;
                int[] row = view.GetSelectedRows();
                view.FocusedRowHandle = row[0];
                _Palet = (view.GetRowCellDisplayText(row[0], view.Columns[0])).ToString();
                DataSet detalle = C_Paquetes.TraerDetallePalet(_idSucursal, _Palet);
                gridControl2.DataSource = detalle.Tables[0];
                this.gridControl2.Refresh();
                this.gridControl2.RefreshDataSource();
            }
            catch(Exception err)
            {
                Console.WriteLine("################### = " + err.ToString());
            }
        } 
        private void btnCrearPalet_Click(object sender, EventArgs e)
        {
            CrearPalet f2 = new CrearPalet(_idSucursal);
            f2.FormClosed += F2_FormClosed;
            f2.Show(); 
        }
        private void btnEditarPalet_Click(object sender, EventArgs e)
        {
            var myForm = new CrearPalet(_idSucursal);
            myForm.Show();
        }
        private void F2_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.gridControl1.Refresh();
            this.gridControl1.RefreshDataSource();
            this.gridView1.RefreshData();
            TraerData();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridControl1.CanSelect)
                {
                    ColumnView view = gridControl1.MainView as ColumnView;
                    int[] row = view.GetSelectedRows();
                    if (row.Length > 0)
                    {
                        view.FocusedRowHandle = row[0];
                    }
                    try
                    {
                        string PaletId = view.GetRowCellDisplayText(row[0], view.Columns[0]);
                        DataSet _paletImpr = C_Paquetes.PaletImprimir(PaletId);
                        EtiquetaPalet _rptPalet = new EtiquetaPalet();
                        _rptPalet.SetDataSource(_paletImpr.Tables[0]);
                        frmReportViewer viwer = new frmReportViewer(_rptPalet);
                        viwer.Width = 1000;
                        viwer.Height = 750;
                        viwer.StartPosition = FormStartPosition.CenterScreen;
                        viwer.ShowDialog();
                    }
                    catch (Exception err)
                    {
                        XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                        Console.WriteLine("################## = " + err.ToString());
                    }
                }
            }
            catch(Exception err)
            {
                Console.WriteLine("####################### = " + err.ToString());
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (gridView1.OptionsFind.AlwaysVisible == true)
            {
                gridView1.OptionsFind.AlwaysVisible = false;
            }
            else if (gridView1.OptionsFind.AlwaysVisible == false)
            {
                gridView1.OptionsFind.AlwaysVisible = true;
            }
            else
            {
                gridView1.OptionsFind.AlwaysVisible = true;
            }
        }
    }
}