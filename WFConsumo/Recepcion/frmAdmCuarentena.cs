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
using DevExpress.XtraEditors.Controls;
using WFConsumo.frmGRH.DespachoOrdenAbierta;
using CRN.Componentes;
using DevExpress.XtraEditors.Repository;
using CRN.Entidades;
using DevComponents.DotNetBar;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using System.Reflection;
using System.Data.Odbc;
using System.Data.SqlClient;
using CAD;
using System.Data.Common;

namespace WFConsumo.Recepcion
{
    public partial class frmAdmCuarentena : DevExpress.XtraEditors.XtraForm
    {
        //asignacion manual por pruebas
        int _idSucursal = 0;
        string _Usuario = " ";
        //
        DataTable dt = new DataTable();
        string TipoMov = string.Empty;
        public frmAdmCuarentena(string sTipoMov)
        {
            InitializeComponent();
            TipoMov = sTipoMov;
            dt.Columns.Add("Paquete");
            dt.Columns.Add("Item");
            dt.Columns.Add("Desc");
            dt.Columns.Add("Pieza");
            dt.Columns.Add("Peso");
            dt.Columns.Add("um");
            gridControl1.DataSource = dt;
            gridControl1.Enabled = false;
            txtPaquete.Focus();
            
        }

        //btnAgregarProducto
        private void simpleButton3_Click(object sender, EventArgs ev)
        {
            string sPaquete = txtPaquete.Text;
            CADPaquetes oPaquete = new CADPaquetes();
            DataSet dts = new DataSet();
            if (TipoMov == "ENTRADA")
                dts = oPaquete.BuscarPaquete(sPaquete, Entidades.utilitario.iSucursal, "ACTIVO");
            else
                dts = oPaquete.BuscarPaquete(sPaquete, Entidades.utilitario.iSucursal, "CUARENTENA");
            string PaqueteId = string.Empty;
            string ItemId = string.Empty;
            string Descripcion = string.Empty;
            string um = string.Empty;
            decimal Piezas = 0;
            decimal Peso = 0;

            if (dts.Tables[0].Rows.Count > 0)
            {
                PaqueteId = sPaquete;
                ItemId = dts.Tables[0].Rows[0]["ItemId"].ToString();
                Descripcion = dts.Tables[0].Rows[0]["Descripcion"].ToString();
                um = dts.Tables[0].Rows[0]["UnidadF"].ToString();
                Piezas = Convert.ToDecimal(dts.Tables[0].Rows[0]["Piezas"].ToString());
                Peso = Convert.ToDecimal(dts.Tables[0].Rows[0]["Peso"].ToString());
                DataRow dr = dt.NewRow();
                dr[0] = PaqueteId;
                dr[1] = ItemId;
                dr[2] = Descripcion;
                dr[3] = Piezas;
                dr[4] = Peso;
                dr[5] = um;
                dt.Rows.Add(dr);
                gridControl1.DataSource = dt;
                txtPaquete.Text = string.Empty;
            }
            else
                XtraMessageBox.Show("Etiqueta No Encontrada", "Error");
        }



        public void gridView1_RowCellClick(Object sender, EventArgs e)
        {
            ColumnView view = this.gridControl1.MainView as ColumnView;
            int[] row = view.GetSelectedRows();
            view.FocusedRowHandle = row[0];
            // _IdProducto = (view.GetRowCellDisplayText(row[0], view.Columns[0])).ToString();
        }
        //Quitar de la lista
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            gridView1.DeleteRow(gridView1.FocusedRowHandle);
        }
        //btnSalir
        private void simpleButton8_Click(object sender, EventArgs e)
        {
            Program._listaProductos.Clear();
            this.Close();
        }
        private void dateChanged(object sender, EventArgs e)
        {
            try
            {
                //_FechaElegida = dateEdit1.DateTime;
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("################## = " + err.ToString());
            }
        }
        private void EnterBtn(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    //int _idSucursalDestino = _SucElegida;
                    //string _nroOrden = txtNroOrden.Text;
                    ////DataSet dataLista = C_NroOrden.TraerOrden(_nroOrden, _idSucursalDestino);
                    //DataSet dataLista = C_NroOrden.TraerTodo(_idSucursalDestino);
                    //dataOrden = dataLista.Tables[0];
                    ////Console.WriteLine("############ == " + dataOrden.Rows.Count);
                    //if (dataOrden.Rows.Count > 0)
                    //{
                    //    foreach (DataRow item in dataLista.Tables[0].Rows)
                    //    {
                    //        Program._listaProductos.Add(new GlobalItem
                    //        {
                    //            ItemId = item[0].ToString(),
                    //            Descripcion = item[1].ToString(),
                    //            CantidadPzs = Convert.ToInt32(item[2]),
                    //            StockPzs = Convert.ToInt32(item[1]),
                    //            PzasPaq = Convert.ToInt32(item[4]),
                    //            Paqs = Convert.ToInt32(item[5]),
                    //            PzasSob = Convert.ToInt32(item[2]),
                    //            PesoPaq = Convert.ToDecimal(item[4])
                    //        });
                    //    }
                    //}
                    //else
                    //{
                    //    //XtraMessageBox.Show("Cantidad= ", _cantidad.ToString());
                    //}
                }
                catch (Exception err)
                {
                    XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                    Console.WriteLine("################## = " + err.ToString());
                }
            }
        }
        //btnAceptar
        private void simpleButton5_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtDetalle = (DataTable)gridControl1.DataSource;
                if (dtDetalle.Rows.Count > 0)
                {
                    CAnotacion oAnoacion = new CAnotacion();
                    string sError = string.Empty;
                    int a = oAnoacion.InsertCuarentena(out sError, txtobs.Text, Entidades.utilitario.iSucursal, DateTime.Now, Entidades.utilitario.sUsuario, TipoMov, dtDetalle);
                    if (a > 0)
                    {
                        XtraMessageBox.Show("Se Genero Con Exito");
                        
                    }
                    else
                    {
                        XtraMessageBox.Show("Problemas En La Trasaccion");
                    }
                    this.Close();
                }
            }
            catch (Exception eX)
            {
                throw eX;
            }
        }
        private void frmNuevoDespachoMercaderia_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {

                Program._listaProductos.Clear();
                //Application.OpenForms["frmListaDespachoMercaderia"].Enabled = true;
            }
        }
        private void btnBuscarSucursal_Click(object sender, EventArgs e)
        {
            //BuscarSucursal form3 = new BuscarSucursal(_tipoDespacho);
            //form3.Owner = this;
            //form3.ShowDialog(this);

            //this.Enabled = false;
        }




    }
}