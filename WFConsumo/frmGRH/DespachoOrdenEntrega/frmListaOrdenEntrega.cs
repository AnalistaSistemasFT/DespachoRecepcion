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
using WFConsumo.frmGRH.DespachoOrdenListaCerrar;

namespace WFConsumo.frmGRH.DespachoOrdenEntrega
{
    public partial class frmListaOrdenEntrega : DevExpress.XtraEditors.XtraForm
    {
        int _idSucursal = 0;
        private string _idDespacho;
        private string IdDespacho = "0";
        private decimal _pesoTotal = 0;
        private string _login = string.Empty;
        CDespacho C_Despacho;
        CMovDespacho C_MovDespacho;
        Cscentrega C_scentrega;
        CPaquetes C_Paquetes;
        COrdenEntrega C_OrdenEntrega;
        DataTable dataT = new DataTable();
        DataTable dataDet = new DataTable();
        DataTable dataProd = new DataTable();
        List<ItemEntrega> _listEntrega = new List<ItemEntrega>();
        List<EntregaItem> _listEntregaItem = new List<EntregaItem>();
        int _idDestino = 0;
        int _ImpTab = 0;

        public frmListaOrdenEntrega(Usuario user, int sucursalId)
        {
            InitializeComponent();
            _idSucursal = sucursalId;
            _login = user.Login;
            C_Despacho = new CDespacho();
            C_MovDespacho = new CMovDespacho();
            C_scentrega = new Cscentrega();
            C_Paquetes = new CPaquetes();
            C_OrdenEntrega = new COrdenEntrega();
            TraerData();
            TraerDestino();
            gridControl4.DataSource = _listEntregaItem;
        }

        private void TraerData()
        {
            try
            {
                DataSet dataLista = C_Despacho.TraerDespachoEntregar(_idSucursal);
                dataT = dataLista.Tables[0];
                this.gridControl1.DataSource = dataT;

                //DataSet dataEntregas = C_OrdenEntrega.TraerOrdenesEntregas();
                string Estado = "Enviado";
                DataSet dataEntregas = C_OrdenEntrega.TraerTodasOrdenEntregaList(Estado, _idSucursal);
                Console.WriteLine(dataEntregas.Tables[0].Rows.Count);
                this.gridControl5.DataSource = dataEntregas.Tables[0];
            }
            catch(Exception err)
            {
                XtraMessageBox.Show("Problemas con la conexion", "Error");
                Console.WriteLine("####################### = " + err.ToString());
            } 
        }
        public void TraerDestino()
        {
            try
            {
                DataSet dataDest = C_Despacho.TraerDestinoId(_idDespacho);
                foreach (DataRow item in dataDest.Tables[0].Rows)
                {
                    _idDestino = Convert.ToInt32(item[0]);
                }
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Problemas con la conexion", "Error");
                Console.WriteLine("####################### = " + err.ToString());
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
                        XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                        Console.WriteLine("############################# = " + err.ToString());
                    }
                }
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
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
                        XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                        Console.WriteLine("############################# = " + err.ToString());
                    }
                }
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Seleccione un despacho de la lista e intentelo de nuevo");
                Console.WriteLine("############################# = " + err.ToString());
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
                    string TipoReporte = "AUTORIZADOS";
                    IdDespacho = view.GetRowCellDisplayText(row[0], view.Columns[0]);
                    //var myForm = new ReportesDespacho(IdDespacho, TipoReporte);
                    //myForm.Show();
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
                    XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
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
                    dtsDetalle.Columns.Add("NuevoEstado");

                    DataRow dr = null;
                    PaquetesRotos _paqRoto = new PaquetesRotos();
                    DataSet detalleCerrar = C_Despacho.TraerDetalleCerrarDespacho(_idDespacho);
                    if (detalleCerrar.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow item in detalleCerrar.Tables[0].Rows)
                        {
                            string _status = "TOTAL";

                            DataSet detCerrar = C_Paquetes.TraerEstadoPaqueteCerrar(item[2].ToString());
                            foreach (DataRow itm in detCerrar.Tables[0].Rows)
                            {
                                if (Convert.ToInt32(itm[0]) == Convert.ToInt32(itm[1]))
                                {
                                    _status = "TOTAL";
                                }
                                else
                                {
                                    _status = "PARCIAL";
                                    DataSet PaqComp = C_Paquetes.BuscarPaqueteCompleto(item[2].ToString());
                                    foreach (DataRow itmCmp in PaqComp.Tables[0].Rows)
                                    {
                                        _paqRoto.PaqueteId = itmCmp[0].ToString();
                                        _paqRoto.SucursalId = Convert.ToInt32(itmCmp[1]);
                                        _paqRoto.AlmacenId = Convert.ToInt32(itmCmp[2]);
                                        _paqRoto.Fecha = Convert.ToDateTime(itmCmp[3]);
                                        _paqRoto.CeldaId = itmCmp[4].ToString();
                                        _paqRoto.Nivel = Convert.ToInt32(itmCmp[5]);
                                        _paqRoto.ItemId = itmCmp[6].ToString();
                                        _paqRoto.Login = itmCmp[7].ToString();
                                        _paqRoto.status = itmCmp[8].ToString();
                                        _paqRoto.Peso = Convert.ToDecimal(item[4]);
                                        _paqRoto.Piezas = Convert.ToInt32(item[3]);
                                        _paqRoto.OrdenId = itmCmp[11].ToString();
                                        _paqRoto.Contenedor = itmCmp[12].ToString();
                                        _paqRoto.Colada = itmCmp[13].ToString();
                                        _paqRoto.CentroTrabajo = itmCmp[14].ToString();
                                        _paqRoto.ItemFId = itmCmp[15].ToString();
                                        _paqRoto.Metros = Convert.ToDecimal(itmCmp[16]);
                                        _paqRoto.FechaVenc = Convert.ToDateTime(itmCmp[17]);
                                        _paqRoto.CantOriginal = Convert.ToInt32(itmCmp[18]);
                                    }
                                }
                            }
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
                            dr["NuevoEstado"] = _status;
                            dtsDetalle.Rows.Add(dr);
                        }
                        //a = C_MovDespacho.CerrarDespacho(dtsDetalle, dtsDetalle, _idSucursal, DespachoId, _idDestino);
                        //if (a > 0)
                        //{
                        //    TraerData();
                        //    XtraMessageBox.Show("Orden cerrada", "Cerrar despacho");
                        //}
                        //else
                        //{
                        //    //XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                        //    //Console.WriteLine("###########################: A = 0");
                        //}
                    }
                    else
                    {
                        //XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Hand);

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
                    if (IdDespacho != string.Empty)
                    {
                        var myForm = new ConsultarDespacho(IdDespacho); 
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
        //btnOrden de entrega
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
                    string _Naturaleza = view.GetRowCellDisplayText(row[0], view.Columns[6]);
                    if (IdDespacho != "0")
                    {
                        _listEntrega.Clear();
                        //DataSet dataLista = C_Paquetes.BuscarPaqueteEntregaPacial(_idDespacho);
                        DataSet dataLista = C_Paquetes.BuscarPaqueteEntrega(_idDespacho);
                        foreach (DataRow item in dataLista.Tables[0].Rows)
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
                                p_Retirar = Convert.ToInt32(item[8]),
                                p_NombreDisplay = (item[0] + " - " + item[1] + " - " + item[2]).ToString()
                            });
                        }
                        DataSet dataModPendiente = C_Paquetes.BuscarPaqueteEntregaConEntrega(_idDespacho);
                        foreach(DataRow item in dataModPendiente.Tables[0].Rows)
                        {
                            Console.WriteLine("####################### = " + item[3].ToString() + " - " + item[4].ToString() + " - " + item[8].ToString());
                            string _paqueteComp = item[3].ToString();
                            string _itemComp = item[0].ToString();
                            int _pendNuevo = Convert.ToInt32(item[8]);
                            _listEntrega.Find(p => p.p_PaqueteId == _paqueteComp && p.p_ItemId == _itemComp).p_Pendiente = _pendNuevo;
                        }
                        if (_listEntrega.Count > 0)
                        {
                            //var myForm = new CrearEntregaC(IdDespacho, _idSucursal, Placa, Chofer, _listEntrega, _pesoTotal, _login);
                            //myForm.Show();
                            string envio = "Parcial";
                            CrearEntregaC f2 = new CrearEntregaC(IdDespacho, _idSucursal, Placa, Chofer, _listEntrega, _pesoTotal, _login, envio, _Naturaleza);
                            //form20.Owner = this;
                            f2.FormClosed += F2_FormClosed;
                            f2.Show();
                        }
                        else
                        {
                            XtraMessageBox.Show("Seleccione un despacho de la lista e intentelo de nuevo");
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
        private void F2_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.gridControl1.Refresh();
            this.gridControl1.RefreshDataSource();
            this.gridView1.RefreshData();
            this.gridView1.BeginDataUpdate();
            this.gridView1.EndDataUpdate();
            TraerData();
        }
        public void ActualizarLista(int actualizar)
        {
            try
            {
                if (actualizar == 1)
                {
                    this.gridControl1.Refresh();
                    this.gridControl1.RefreshDataSource();
                    this.gridView1.RefreshData();
                    this.gridView1.BeginDataUpdate();
                    this.gridView1.EndDataUpdate();
                    TraerData();
                }
            }
            catch (Exception err)
            {
                //XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("################### = " + err.ToString());
            }
        }
        private void btnImprimirLocaliza_Click(object sender, EventArgs e)
        {

        }
        private void gridView4_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                ColumnView view = this.gridControl1.MainView as ColumnView;
                int[] row = Convert.ToInt32(view.FocusedRowHandle).ToArray();
                string dataRow = view.GetRowCellDisplayText(row[0], view.Columns[0]);
                _idDespacho = dataRow;
                DataSet dataDetEnt = C_OrdenEntrega.TraerTodasOrdenDetalleDespacho(_idDespacho);
                this.gridControl2.DataSource = dataDetEnt.Tables[0];
                GetDetalle();
                gridView2.UpdateTotalSummary();
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("####################### = " + err.ToString());
            }
        }
        private void gridView6_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            try
            {
                ColumnView view = this.gridControl5.MainView as ColumnView;
                int[] row = Convert.ToInt32(view.FocusedRowHandle).ToArray();
                string dataRow = view.GetRowCellDisplayText(row[0], view.Columns[0]);
                _idDespacho = dataRow;
                DataSet dataDetEnt = C_OrdenEntrega.TraerTodasOrdenDetalleDespacho(_idDespacho);
                this.gridControl2.DataSource = dataDetEnt.Tables[0];
                GetDetalle();
                gridView2.UpdateTotalSummary();
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("####################### = " + err.ToString());
            }
        }
        private void GetDetalle()
        {
            try
            {
                _listEntregaItem.Clear();
                DataSet dataLista = C_Paquetes.BuscarPaqueteEntregaPacial(_idDespacho);
                foreach(DataRow item in dataLista.Tables[0].Rows)
                {
                    _listEntregaItem.Add(new EntregaItem
                    {
                        e_Codigo = item[0].ToString(),
                        e_CodigoFerro = Convert.ToInt32(item[1]),
                        e_Descripcion = item[2].ToString(),
                        e_Paquete = item[3].ToString(),
                        e_UnidadMedida = item[4].ToString(),
                        e_Cantidad = Convert.ToInt32(item[5]),
                        e_Peso = Convert.ToDecimal(item[6]),
                        e_PesoTotal = Convert.ToDecimal(item[7]),
                        e_Pendiente = Convert.ToInt32(item[8])
                    });
                }
                DataSet dataPend = C_Paquetes.BuscarPaqueteEntregaParcialPendiente(_idDespacho);
                foreach(DataRow itemE in dataPend.Tables[0].Rows)
                {
                    string _paquete = itemE[0].ToString();
                    string _codigo = itemE[1].ToString();

                    int _nuevoPend = Convert.ToInt32(itemE[2] is DBNull ? 0 : itemE[2]);
                    _listEntregaItem.Find(p => p.e_Paquete == _paquete && p.e_Codigo == _codigo).e_Pendiente = (_listEntregaItem.Find(p => p.e_Paquete == _paquete && p.e_Codigo == _codigo).e_Pendiente - _nuevoPend);
                }
                 
                this.gridControl4.DataSource = _listEntregaItem;
                this.gridControl4.Refresh();
                this.gridControl4.RefreshDataSource();
                _listEntrega.Clear();
                _pesoTotal = 0;
                foreach (DataRow item in dataLista.Tables[0].Rows)
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
                        p_Retirar = Convert.ToInt32(item[8]), 
                        p_NombreDisplay = (item[0] + " - " + item[1] + " - " + item[2]).ToString()
                    });
                    _pesoTotal = _pesoTotal + Convert.ToDecimal(item[6]);
                }
            }
            catch (Exception err)
            {
                Console.WriteLine("####################### = " + err.ToString());
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
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (gridView4.OptionsFind.AlwaysVisible == true)
            {
                gridView4.OptionsFind.AlwaysVisible = false;
                gridView6.OptionsFind.AlwaysVisible = false;
            }
            else if (gridView4.OptionsFind.AlwaysVisible == false)
            {
                gridView4.OptionsFind.AlwaysVisible = true;
                gridView6.OptionsFind.AlwaysVisible = true;
            }
            else
            {
                gridView4.OptionsFind.AlwaysVisible = true;
                gridView6.OptionsFind.AlwaysVisible = true;
            }
        }
        public class EntregaItem
        {
            private string Codigo;
            private int CodigoFerro;
            private string Descripcion;
            private string Paquete;
            private string UnidadMedida;
            private int Cantidad;
            private decimal Peso;
            private decimal PesoTotal;
            private int Pendiente;
        
            public string e_Codigo
            {
                get { return Codigo; }
                set { Codigo = value; }
            }
            public int e_CodigoFerro
            {
                get { return CodigoFerro; }
                set { CodigoFerro = value; }
            }
            public string e_Descripcion
            {
                get { return Descripcion; }
                set { Descripcion = value; }
            }
            public string e_Paquete
            {
                get { return Paquete; }
                set { Paquete = value; }
            }
            public string e_UnidadMedida
            {
                get { return UnidadMedida; }
                set { UnidadMedida = value; }
            }
            public int e_Cantidad
            {
                get { return Cantidad; }
                set { Cantidad = value; }
            }
            public decimal e_Peso
            {
                get { return Peso; }
                set { Peso = value; }
            }
            public decimal e_PesoTotal
            {
                get { return PesoTotal; }
                set { PesoTotal = value; }
            }
            public int e_Pendiente
            {
                get { return Pendiente; }
                set { Pendiente = value; }
            }
        }

        private void btnImprimirParcial_Click(object sender, EventArgs e)
        {
            if (_ImpTab == 0)
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
                            IdDespacho = view.GetRowCellDisplayText(row[0], view.Columns[0]);
                            DataSet _despOrdenCarga = C_Despacho.TraerOrdenCarga(IdDespacho);
                            OrdenCargaParcial _ordCarga = new OrdenCargaParcial();
                            _ordCarga.SetDataSource(_despOrdenCarga.Tables[0]);
                            frmReportViewer viwer = new frmReportViewer(_ordCarga);
                            viwer.Width = 1000;
                            viwer.Height = 800;
                            viwer.StartPosition = FormStartPosition.CenterScreen;
                            viwer.ShowDialog();
                        }
                    }
                    catch (Exception err)
                    {
                        XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                        Console.WriteLine("################## = " + err.ToString());
                    }
                }
            }
            else if(_ImpTab == 1)
            {

            }
            if (gridControl5.CanSelect)
            {
                ColumnView view = gridControl5.MainView as ColumnView;
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
                        IdDespacho = view.GetRowCellDisplayText(row[0], view.Columns[0]);
                        DataSet _despOrdenCarga = C_Despacho.TraerOrdenCarga(IdDespacho);
                        OrdenCargaParcial _ordCarga = new OrdenCargaParcial();
                        _ordCarga.SetDataSource(_despOrdenCarga.Tables[0]);
                        frmReportViewer viwer = new frmReportViewer(_ordCarga);
                        viwer.Width = 1000;
                        viwer.Height = 800;
                        viwer.StartPosition = FormStartPosition.CenterScreen;
                        viwer.ShowDialog();
                    }
                }
                catch (Exception err)
                {
                    XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                    Console.WriteLine("################## = " + err.ToString());
                }
            }
        }
        private void btnImprimirEntrega_Click(object sender, EventArgs e)
        {
            if (_ImpTab == 0)
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
                            DataSet _despOrdenEntrega = C_Despacho.TraerOrdenEntrega(IdDespacho, _idSucursal);
                            OrdendeEntrega _ordEnt = new OrdendeEntrega();
                            _ordEnt.SetDataSource(_despOrdenEntrega.Tables[0]);
                            frmReportViewer viwer = new frmReportViewer(_ordEnt);
                            viwer.Width = 1000;
                            viwer.Height = 700;
                            viwer.StartPosition = FormStartPosition.CenterScreen;
                            viwer.ShowDialog();
                        }
                    }
                    catch (Exception err)
                    {
                        XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                        Console.WriteLine("################## = " + err.ToString());
                    }
                }
            }
            else if(_ImpTab == 1)
            {
                if (gridControl5.CanSelect)
                {
                    ColumnView view = gridControl5.MainView as ColumnView;
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
                            DataSet _despOrdenEntrega = C_Despacho.TraerOrdenEntrega(IdDespacho, _idSucursal);
                            OrdendeEntrega _ordEnt = new OrdendeEntrega();
                            _ordEnt.SetDataSource(_despOrdenEntrega.Tables[0]);
                            frmReportViewer viwer = new frmReportViewer(_ordEnt);
                            viwer.Width = 1000;
                            viwer.Height = 700;
                            viwer.StartPosition = FormStartPosition.CenterScreen;
                            viwer.ShowDialog();
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
        private void xtraTabControl2_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            try
            {
                if (e.Page.Name == "tabDespachos")
                {
                    _ImpTab = 0;
                    btnVer.Enabled = true;
                    simpleButton1.Enabled = true;
                }
                else if (e.Page.Name == "tabEntregas")
                {
                    _ImpTab = 1;
                    btnVer.Enabled = false;
                    simpleButton1.Enabled = false;
                }
                else
                {
                    _ImpTab = 0;
                    btnVer.Enabled = true;
                    simpleButton1.Enabled = true;
                }
            }
            catch(Exception err)
            {
                Console.WriteLine("####################### = " + err.ToString());
            }
        }

        
    }
}