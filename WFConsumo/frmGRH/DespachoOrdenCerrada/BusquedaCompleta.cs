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

namespace WFConsumo.frmGRH.DespachoOrdenCerrada
{
    public partial class BusquedaCompleta : DevExpress.XtraEditors.XtraForm
    {
        CDespacho C_Despacho;
        int IdSucursal = 0;
        string IdDespacho = string.Empty;

        public BusquedaCompleta(int _idSucursal)
        {
            InitializeComponent();
            C_Despacho = new CDespacho();
            IdSucursal = _idSucursal;
            TraerData();
        }
        public void TraerData()
        {
            try
            {
                DataSet dataLista = C_Despacho.TraerTodosLosDespachos(IdSucursal); 
                this.gridControl1.DataSource = dataLista.Tables[0]; 
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Problemas con la conexion", "Error");
                Console.WriteLine("####################### = " + err.ToString());
            }
        }
        private void btnVer_Click(object sender, EventArgs e)
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
                    IdDespacho = view.GetRowCellDisplayText(row[0], view.Columns[0]);
                    if (IdDespacho != "0")
                    {
                        var myForm = new ConsultarDespacho(IdDespacho);
                        //this.Enabled = false;
                        myForm.Show();
                    }
                }
                catch (Exception err)
                {
                    XtraMessageBox.Show("Seleccione un despacho de la lista e intentelo de nuevo");
                    Console.WriteLine("########################### = " + err.ToString());
                }
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
        private void btnControlDespacho_Click(object sender, EventArgs e)
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
                    IdDespacho = view.GetRowCellDisplayText(row[0], view.Columns[0]);
                    if (IdDespacho != "0")
                    {
                        var myForm = new ControlDespacho(IdDespacho);
                        myForm.Show();
                    }
                }
                catch (Exception err)
                {
                    XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                    Console.WriteLine("################## = " + err.ToString());
                }
            }
        }
    }
}