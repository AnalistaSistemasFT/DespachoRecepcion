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
using CRN.Entidades;
using WFConsumo.frmGRH.Imprimir;
using WFConsumo.frmGRH.DespachoOrdenEntrega;
using WFConsumo.frmGRH.DespachoOrdenParcial;
using DevExpress.Utils.Extensions;
using DevExpress.XtraGrid;

namespace WFConsumo.frmGRH.DespachoOrdenEntrega
{
    public partial class frmListaOrdenParcial : DevExpress.XtraEditors.XtraForm
    {
        int _idSucursal = 0;
        private string _idDespacho;
        private string IdDespacho = "0";
        private decimal _pesoTotal = 0;
        CDespacho C_Despacho;
        CMovDespacho C_MovDespacho;
        Cscentrega C_scentrega;
        CPaquetes C_Paquete;
        DataTable dataT = new DataTable();
        DataTable dataDet = new DataTable();
        DataTable dataProd = new DataTable();
        List<ItemEntrega> _listEntrega = new List<ItemEntrega>();

        public frmListaOrdenParcial(Usuario user, int sucursalId)
        {
            InitializeComponent();
            _idSucursal = sucursalId;
            C_Despacho = new CDespacho();
            C_MovDespacho = new CMovDespacho();
            C_scentrega = new Cscentrega();
            C_Paquete = new CPaquetes();
            TraerData();
        }
        private void TraerData()
        {
            try
            {
                DataSet dataLista = C_Despacho.TraerDespachoEntregar(_idSucursal);
                dataT = dataLista.Tables[0];
                this.gridControl1.DataSource = dataT;
            }
            catch(Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo");
                Console.WriteLine("############################# = " + err.ToString());
            } 
        }
        private void btnEjecutar_Click(object sender, EventArgs e)
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
                    try
                    {
                        XtraMessageBox.AllowCustomLookAndFeel = true;
                        DialogResult dialogResult = XtraMessageBox.Show("¿Confirmar accion?", "Salir", MessageBoxButtons.YesNo);
                        if (dialogResult == System.Windows.Forms.DialogResult.Yes)
                        {
                            string _idDespacho = IdDespacho;
                            C_Despacho.ModificarEjecutarAListaACerrar(_idDespacho);
                            TraerData();
                        }
                        else
                        {
                            //
                        }
                    }
                    catch (Exception err)
                    {
                        XtraMessageBox.Show("Algo salio mal, intentelo de nuevo");
                        Console.WriteLine("############################# = " + err.ToString());
                    }
                }
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo");
                Console.WriteLine("############################# = " + err.ToString());
            }
        }
        private void btnVolverEstado_Click(object sender, EventArgs e)
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
                    try
                    {
                        XtraMessageBox.AllowCustomLookAndFeel = true;
                        DialogResult dialogResult = XtraMessageBox.Show("¿Confirmar accion?", "Salir", MessageBoxButtons.YesNo);
                        if (dialogResult == System.Windows.Forms.DialogResult.Yes)
                        {
                            string _idDespacho = IdDespacho;
                            C_Despacho.ModificarUndoAEnProceso(_idDespacho);
                            TraerData();
                        }
                        else
                        {
                            //
                        }
                    }
                    catch (Exception err)
                    {
                        XtraMessageBox.Show("Algo salio mal, intentelo de nuevo");
                        Console.WriteLine("############################# = " + err.ToString());
                    }
                }
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Seleccione un despacho de la lista e intentelo de nuevo");
            }
        }
        private void btnImprimir_Click(object sender, EventArgs e)
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
                        try
                        {
                            DespachosAutorizados _ordenCarga = new DespachosAutorizados();
                            _ordenCarga.SetDatabaseLogon("sa", "PlantaV.", "192.168.0.200", "LYBK");
                            _ordenCarga.SetParameterValue("DespachoId", IdDespacho);
                            _ordenCarga.PrintToPrinter(1, true, 0, 0);
                        }
                        catch (Exception err)
                        {
                            XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                            Console.WriteLine("################## = " + err.ToString());
                        }
                    }
                }
                catch (Exception err)
                {
                    XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                    Console.WriteLine("################## = " + err.ToString());
                }
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
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
                        try
                        {
                            XtraMessageBox.AllowCustomLookAndFeel = true;
                            DialogResult dialogResult = XtraMessageBox.Show("¿Eliminar despacho?", "Salir", MessageBoxButtons.YesNo);
                            if (dialogResult == System.Windows.Forms.DialogResult.Yes)
                            {
                                string _IdDespacho = IdDespacho;
                                C_Despacho.EliminarDespacho(_idDespacho);
                                TraerData();
                            }
                            else
                            {
                                //
                            }
                        }
                        catch (Exception err)
                        {
                            //XtraMessageBox.Show(err.ToString(), "Error");
                            Console.WriteLine("############################# = " + err.ToString());
                        }
                    }
                }
                catch (Exception err)
                {
                    XtraMessageBox.Show("Algo salio mal, intentelo de nuevo");
                    Console.WriteLine("############################# = " + err.ToString());
                }
            }
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            ColumnView view = gridControl1.MainView as ColumnView;
            int[] row = view.GetSelectedRows();
            if (row.Length > 0)
            {
                view.FocusedRowHandle = row[0];
            }
            try
            {
                string DespachoId = "0";
                IdDespacho = view.GetRowCellDisplayText(row[0], view.Columns[0]);
                if (IdDespacho != "0")
                {
                    DespachoId = IdDespacho;
                }
                XtraMessageBox.AllowCustomLookAndFeel = true;
                DialogResult dialogResult = XtraMessageBox.Show("¿Cerrar despacho?", "Salir", MessageBoxButtons.YesNo);
                if (dialogResult == System.Windows.Forms.DialogResult.Yes)
                {
                    int a = 0;
                    //dtsDetalle
                    DataTable dtsDetalle = new DataTable();
                    dtsDetalle.Columns.Add("Codigo"); //Codigo
                    dtsDetalle.Columns.Add("Descripcion"); //Descripcion
                    dtsDetalle.Columns.Add("Paquete"); //Paquete
                    dtsDetalle.Columns.Add("Piezas"); //Piezas
                    dtsDetalle.Columns.Add("Peso"); //Peso
                    dtsDetalle.Columns.Add("Metros"); //Metros
                    dtsDetalle.Columns.Add("Calidad"); //Calidad
                    dtsDetalle.Columns.Add("CeldaId"); //CeldaId
                    dtsDetalle.Columns.Add("CentroTrabajo"); //CentroTrabajo

                    DataRow dr = null;
                    DataSet detalleCerrar = C_Despacho.TraerDetalleCerrarDespacho(_idDespacho);
                    if (detalleCerrar.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow item in detalleCerrar.Tables[0].Rows)
                        {
                            dr = dtsDetalle.NewRow();
                            dr["Codigo"] = item[0];
                            dr["Descripcion"] = item[1];
                            dr["Paquete"] = item[2];
                            dr["Piezas"] = item[3];
                            dr["Peso"] = item[4];
                            dr["Metros"] = item[5];
                            dr["Calidad"] = item[6];
                            dr["CeldaId"] = item[7];
                            dr["CentroTrabajo"] = item[8];
                            dtsDetalle.Rows.Add(dr);
                        }
                        a = C_MovDespacho.CerrarDespacho(dtsDetalle, dtsDetalle, _idSucursal, DespachoId);
                        if (a > 0)
                        {
                            XtraMessageBox.Show("Orden cerrada");
                        }
                        else
                        {
                            XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                            Console.WriteLine("###########################: A = 0");
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Hand);

                    }
                }
                else
                {
                    //
                }
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
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
                        var myForm = new ConsultarDespachoParcial(IdDespacho);
                        //this.Enabled = false;
                        myForm.Show();
                    }
                }
                catch (Exception err)
                {
                    XtraMessageBox.Show("Algo salio mal, intentelo de nuevo");
                    Console.WriteLine("############################# = " + err.ToString());
                }
            }
        }
        private void simpleButton1_Click(object sender, EventArgs e)
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
                    string Placa = view.GetRowCellDisplayText(row[0], view.Columns[3]);
                    string Chofer = view.GetRowCellDisplayText(row[0], view.Columns[5]);
                    if (IdDespacho != "0")
                    {
                        if(_listEntrega.Count > 0)
                        {
                            var myForm = new CrearEntrega(IdDespacho, _idSucursal, Placa, Chofer, _listEntrega, _pesoTotal);
                            myForm.Show();
                        }
                        else
                        {
                            XtraMessageBox.Show("Contador menor a cero");
                        }
                    }
                }
                catch (Exception err)
                {
                    XtraMessageBox.Show("Seleccione un despacho de la lista e intentelo de nuevo");
                    Console.WriteLine("######################### = " + err.ToString());
                }
            }
        }
        private void btnImprimirLocaliza_Click(object sender, EventArgs e)
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
                        try
                        {
                            DespachosAutorizados _ordenCarga = new DespachosAutorizados();
                            _ordenCarga.SetDatabaseLogon("sa", "PlantaV.", "192.168.0.200", "LYBK");
                            _ordenCarga.SetParameterValue("DespachoId", IdDespacho);
                            _ordenCarga.PrintToPrinter(1, true, 0, 0);
                        }
                        catch (Exception err)
                        {
                            XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                            Console.WriteLine("################## = " + err.ToString());
                        }
                    }
                }
                catch (Exception err)
                {
                    XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                    Console.WriteLine("################## = " + err.ToString());
                }
            }
        }
        private void gridView4_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                ColumnView view = this.gridControl1.MainView as ColumnView;
                int[] row = Convert.ToInt32(view.FocusedRowHandle).ToArray();
                string dataRow = view.GetRowCellDisplayText(row[0], view.Columns[0]);
                _idDespacho = dataRow;
                GetDetalle();
                gridView2.UpdateTotalSummary();
            }
            catch (Exception err)
            {
                Console.WriteLine("####################### = " + err.ToString());
            }
        }
        private void GetDetalle()
        {
            try
            {
                DataSet dataLista = C_Paquete.BuscarPaqueteEntrega(_idDespacho);
                dataDet = dataLista.Tables[0];
                this.gridControl2.DataSource = dataDet;
                _listEntrega.Clear();
                _pesoTotal = 0;
                foreach (DataRow item in dataDet.Rows)
                {
                    _listEntrega.Add(new ItemEntrega
                    {
                        p_ItemId = item[0].ToString(),
                        p_ItemFId = Convert.ToInt32(item[1]),
                        p_Descripcion = item[2].ToString(),
                        p_PaqueteId = item[3].ToString(),
                        p_UnidadMedida = item[4].ToString(),
                        p_Piezas = Convert.ToInt32(item[5]),
                        p_Peso = Convert.ToDecimal(item[6]),
                        p_PesoTotal = Convert.ToDecimal(item[7]),
                        p_Pendiente = Convert.ToInt32(item[8]),
                        p_Retirar = 0, 
                        p_NombreDisplay = (item[0] + " - " + item[1] + " - " + item[2]).ToString()
                    });
                    _pesoTotal = _pesoTotal + Convert.ToDecimal(item[7]);
                }
            }
            catch (Exception err)
            {
                Console.WriteLine("####################### = " + err.ToString());
            }
        }
    }
}