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
using System.Data.Common;
using CRN.Entidades;
using WFConsumo.frmGRH.Imprimir;
using DevExpress.Utils.Extensions;

namespace WFConsumo.frmGRH.DespachoOrdenListaCerrar
{
    public partial class frmListaOrdenListaCerrar : DevExpress.XtraEditors.XtraForm
    {
        int _idSucursal = 0; 
        private string _idDespacho;
        private string IdDespacho = "0";
        private decimal _pesoTotal = 0;
        private DateTime _Fecha = DateTime.Now;
        private string _login = string.Empty;
        CDespacho C_Despacho;
        DataTable dataT = new DataTable();
        DataTable dataDet = new DataTable();
        DataTable dataProd = new DataTable();
        List<DetalleProducto> _lstProdDet = new List<DetalleProducto>();
        List<ItemEntrega> _listEntrega = new List<ItemEntrega>();
        CTraspaso C_Traspaso;
        CSucursal C_Sucursal;
        CMovDespacho C_MovDespacho;
        CPaquetes C_Paquetes;
        CLogError C_LogError;

        public frmListaOrdenListaCerrar(Usuario user, int sucursalId)
        {
            InitializeComponent();
            _idSucursal = sucursalId;
            _login = user.Login;
            C_Despacho = new CDespacho();
            C_Traspaso = new CTraspaso();
            C_Sucursal = new CSucursal();
            C_MovDespacho = new CMovDespacho();
            C_Paquetes = new CPaquetes();
            C_LogError = new CLogError();
            TraerData();
        }
        private void TraerData()
        {
            try
            {
                DataSet dataLista = C_Despacho.TraerDespachoPorCerrar(_idSucursal);
                dataT = dataLista.Tables[0];
                this.gridControl1.DataSource = dataT;
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Problemas con la conexion", "Error");
                Console.WriteLine("####################### = " + err.ToString());
            }
        }       
        private void gridView4_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            try
            {
                ColumnView view = this.gridControl1.MainView as ColumnView;
                int[] row = view.GetSelectedRows();
                view.FocusedRowHandle = row[0];
                _idDespacho = (view.GetRowCellDisplayText(row[0], view.Columns[0])).ToString();
                labelControl2.Text = _idDespacho;

                DataSet detalleLista = C_Despacho.TraerDetalleDespacho(_idDespacho);
                _lstProdDet.Clear();
                this.gridControl2.Refresh();
                this.gridControl2.RefreshDataSource();
                foreach (DataRow item in detalleLista.Tables[0].Rows)
                {
                    string idItem = item[0].ToString();
                    string descItem = item[1].ToString();
                    int reqItem = Convert.ToInt32(item[2]);
                    int compItem = Convert.ToInt32(item[3]);
                    decimal pesoItem = 0;
                    int numPaqCelda = 0;
                    int numPaqSob = 0;
                    DataSet sumCelda = C_Despacho.TraerDetalleDespachoSumCelda(_idDespacho, idItem);
                    foreach (DataRow sumCel in sumCelda.Tables[0].Rows)
                    {
                        numPaqCelda = Convert.ToInt32(sumCel[0]);
                    }
                    DataSet sumSobra = C_Despacho.TraerDetalleDespachoSumSob(_idDespacho, idItem);
                    foreach (DataRow sumSob in sumSobra.Tables[0].Rows)
                    {
                        numPaqSob = Convert.ToInt32(sumSob[0] is DBNull ? 0 : sumSob[0]);
                        //totaltomausado=Convert.ToDecimal(drDatos["total"] is DBNull ? 0:drDatos["total"])
                    }
                    int progItem = numPaqCelda + numPaqSob;
                    _lstProdDet.Add(new DetalleProducto
                    {
                        p_ItemId = idItem,
                        p_Descripcion = descItem,
                        p_PiezasReq = reqItem,
                        p_PiezasProg = progItem,
                        p_PiezasComp = compItem,
                        p_Peso = pesoItem
                    });
                }
                this.gridControl2.DataSource = _lstProdDet;

                DataSet detalleProd = C_Despacho.TraerDespProducto(_idDespacho);
                dataProd = detalleProd.Tables[0];
                this.gridControl3.DataSource = dataProd;

                try
                {
                    ColumnView viewE = this.gridControl1.MainView as ColumnView;
                    int[] rowE = Convert.ToInt32(viewE.FocusedRowHandle).ToArray();
                    string dataRow = viewE.GetRowCellDisplayText(rowE[0], viewE.Columns[0]);
                    _idDespacho = dataRow;
                    GetDetalle();
                    gridView1.UpdateTotalSummary();
                }
                catch (Exception err)
                {
                    Console.WriteLine("####################### = " + err.ToString());
                }
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
                int _conEntregas = 0;
                DataSet dataCont = C_Paquetes.ContEntregas(_idDespacho);
                foreach (DataRow item in dataCont.Tables[0].Rows)
                {
                    _conEntregas = Convert.ToInt32(item[0]);
                }
                if(_conEntregas == 0)
                {
                    DataSet dataListaA = C_Paquetes.BuscarPaqueteEntrega(_idDespacho);
                    dataDet = dataListaA.Tables[0];
                    this.gridControl4.DataSource = dataDet;
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
                        _pesoTotal = _pesoTotal + Convert.ToDecimal(item[6]);
                    }
                }
                else
                {
                    DataSet dataLista = C_Paquetes.BuscarPaqueteEntregaConEntrega(_idDespacho);
                    dataDet = dataLista.Tables[0];
                    this.gridControl4.DataSource = dataDet;
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
                        _pesoTotal = _pesoTotal + Convert.ToDecimal(item[6]);
                    }
                }
            }
            catch (Exception err)
            {
                Console.WriteLine("####################### = " + err.ToString());
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
                    dtsDetalle.Columns.Add("Cantidad");
                    dtsDetalle.Columns.Add("PesoFinal");

                    DataTable detMov = new DataTable();
                    DataTable detPaqRoto = new DataTable();
                    detPaqRoto.Columns.Add("PaqueteId"); //Codigo
                    detPaqRoto.Columns.Add("SucursalId"); //Descripcion
                    detPaqRoto.Columns.Add("AlmacenId"); //Paquete
                    detPaqRoto.Columns.Add("Fecha"); //Piezas
                    detPaqRoto.Columns.Add("CeldaId"); //Peso
                    detPaqRoto.Columns.Add("Nivel"); //Metros
                    detPaqRoto.Columns.Add("ItemId"); //Calidad
                    detPaqRoto.Columns.Add("Login"); //CeldaId
                    detPaqRoto.Columns.Add("Status"); //CentroTrabajo
                    detPaqRoto.Columns.Add("Peso");
                    detPaqRoto.Columns.Add("Piezas");
                    detPaqRoto.Columns.Add("OrdenId");
                    detPaqRoto.Columns.Add("Contenedor");
                    detPaqRoto.Columns.Add("Colada");
                    detPaqRoto.Columns.Add("CentroTrabajo");
                    detPaqRoto.Columns.Add("ItemFId");
                    detPaqRoto.Columns.Add("Metros");
                    detPaqRoto.Columns.Add("FechaVenc");
                    detPaqRoto.Columns.Add("CantOriginal");

                    DataRow dr = null;
                    DataRow drpaRt = null;
                    PaquetesRotos _paqRoto = new PaquetesRotos();
                    DataSet detalleCerrar = C_Despacho.TraerDetalleCerrarDespacho(_idDespacho);
                    if(detalleCerrar.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow item in detalleCerrar.Tables[0].Rows)
                        {
                            string _status = "TOTAL";
                            string _paqueteId = item[2].ToString();
                            DataSet detCerrar = C_Paquetes.TraerEstadoPaqueteCerrar(_paqueteId);
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
                                        //_paqRoto.PaqueteId = itmCmp[0].ToString();
                                        //_paqRoto.SucursalId = Convert.ToInt32(itmCmp[1]);
                                        //_paqRoto.AlmacenId = Convert.ToInt32(itmCmp[2]);
                                        //_paqRoto.Fecha = Convert.ToDateTime(itmCmp[3]);
                                        //_paqRoto.CeldaId = itmCmp[4].ToString();
                                        //_paqRoto.Nivel = Convert.ToInt32(itmCmp[5]);
                                        //_paqRoto.ItemId = itmCmp[6].ToString();
                                        //_paqRoto.Login = itmCmp[7].ToString();
                                        //_paqRoto.status = itmCmp[8].ToString();
                                        //_paqRoto.Peso = Convert.ToDecimal(item[4]);
                                        //_paqRoto.Piezas = Convert.ToInt32(item[9]);
                                        //_paqRoto.OrdenId = itmCmp[11].ToString();
                                        //_paqRoto.Contenedor = itmCmp[12].ToString();
                                        //_paqRoto.Colada = itmCmp[13].ToString();
                                        //_paqRoto.CentroTrabajo = itmCmp[14].ToString();
                                        //_paqRoto.ItemFId = itmCmp[15].ToString();
                                        //_paqRoto.Metros = Convert.ToDecimal(itmCmp[16] is DBNull ? 0 : itmCmp[16]);
                                        //_paqRoto.FechaVenc = Convert.ToDateTime(itmCmp[17] is DBNull ? DateTime.Now : itmCmp[17]);
                                        //_paqRoto.CantOriginal = Convert.ToInt32(itmCmp[18] is DBNull ? 0 : itmCmp[18]);
                                        drpaRt = detPaqRoto.NewRow();
                                        drpaRt["PaqueteId"] = itmCmp[0].ToString();
                                        drpaRt["SucursalId"] = Convert.ToInt32(itmCmp[1]);
                                        drpaRt["AlmacenId"] = Convert.ToInt32(itmCmp[2]);
                                        drpaRt["Fecha"] = Convert.ToDateTime(itmCmp[3]);
                                        drpaRt["CeldaId"] = itmCmp[4].ToString();
                                        drpaRt["Nivel"] = Convert.ToInt32(itmCmp[5]);
                                        drpaRt["ItemId"] = itmCmp[6].ToString();
                                        drpaRt["Login"] = itmCmp[7].ToString();
                                        drpaRt["Status"] = itmCmp[8].ToString();
                                        drpaRt["Peso"] = Convert.ToDecimal(item[4]);
                                        drpaRt["Piezas"] = Convert.ToInt32(item[9]);
                                        drpaRt["OrdenId"] = itmCmp[11].ToString();
                                        drpaRt["Contenedor"] = itmCmp[12].ToString();
                                        drpaRt["Colada"] = itmCmp[13].ToString();
                                        drpaRt["CentroTrabajo"] = itmCmp[14].ToString();
                                        drpaRt["ItemFId"] = itmCmp[15].ToString();
                                        drpaRt["Metros"] = Convert.ToDecimal(itmCmp[16] is DBNull ? 0 : itmCmp[16]);
                                        drpaRt["FechaVenc"] = Convert.ToDateTime(itmCmp[17] is DBNull ? DateTime.Now : itmCmp[17]);
                                        drpaRt["CantOriginal"] = Convert.ToInt32(itmCmp[18] is DBNull ? 0 : itmCmp[18]);
                                        detPaqRoto.Rows.Add(drpaRt);
                                    }
                                }
                            }
                            dr = dtsDetalle.NewRow();
                            dr["Codigo"] = item[0];
                            dr["Descripcion"] = item[1];
                            dr["Paquete"] = item[2];
                            dr["Piezas"] = Convert.ToInt32(item[3]);
                            dr["Peso"] = item[4];
                            dr["Metros"] = item[5];
                            dr["Calidad"] = item[6];
                            dr["CeldaId"] = item[7];
                            dr["CentroTrabajo"] = item[8];
                            dr["NuevoEstado"] = _status;
                            dr["Cantidad"] = Convert.ToInt32(item[9]);
                            dtsDetalle.Rows.Add(dr);
                        }
                        a = C_MovDespacho.CerrarDespacho(dtsDetalle, detPaqRoto, _idSucursal, DespachoId);
                        if (a > 0)
                        {
                            TraerData();
                            XtraMessageBox.Show("Orden cerrada", "Cerrar despacho");
                        }
                        else
                        {
                            XtraMessageBox.Show("Problemas con la conexion", "Error");
                            Console.WriteLine("####################### = A = 0");
                        }
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
                if(err.HResult == -2146233079)
                {
                    XtraMessageBox.Show("Orden cerrada", "Cerrar despacho");
                    TraerData();
                }
                else
                {
                    XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                    Console.WriteLine("####################### = " + err.ToString());
                    Console.WriteLine("####################### = " + err.HResult.ToString());
                }
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
                    var myForm = new ReportesDespacho(IdDespacho, TipoReporte);
                    myForm.Show();
                }
                catch (Exception err)
                {
                    XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                    Console.WriteLine("################## = " + err.ToString());
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
                        string TipoReporte = "ORDENCARGA";
                        IdDespacho = view.GetRowCellDisplayText(row[0], view.Columns[0]);
                        var myForm = new ReportesDespacho(IdDespacho, TipoReporte);
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
                        DialogResult dialogResult = XtraMessageBox.Show("¿Mover el despacho " + IdDespacho + " a 'Orden en Proceso'?", "Salir", MessageBoxButtons.YesNo);
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
                        Console.WriteLine("################ = " + err.ToString());
                    }
                }
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Seleccione un despacho de la lista e intentelo de nuevo");
                Console.WriteLine("################ = " + err.ToString());
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
        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (gridControl2.CanSelect)
                {
                    ColumnView view = gridControl2.MainView as ColumnView;
                    int[] row = view.GetSelectedRows();
                    if (row.Length > 0)
                    {
                        view.FocusedRowHandle = row[0];
                    }

                    ColumnView viewDesp = gridControl1.MainView as ColumnView;
                    int[] rowDesp = viewDesp.GetSelectedRows();
                    if (rowDesp.Length > 0)
                    {
                        viewDesp.FocusedRowHandle = rowDesp[0];
                    }

                    try
                    {
                        IdDespacho = viewDesp.GetRowCellDisplayText(rowDesp[0], viewDesp.Columns[0]);
                        string ItemId = view.GetRowCellDisplayText(row[0], view.Columns[0]);
                        string DescItem = view.GetRowCellDisplayText(row[0], view.Columns[1]);
                        int PzaReq = Convert.ToInt32(view.GetRowCellDisplayText(row[0], view.Columns[2]));
                        int PzaProg = Convert.ToInt32(view.GetRowCellDisplayText(row[0], view.Columns[3]));
                        int PzaPaq = 1;
                        DataSet dataPaq = C_Despacho.TraerPzaPaq(_idSucursal, ItemId);
                        foreach (DataRow item in dataPaq.Tables[0].Rows)
                        {
                            PzaPaq = Convert.ToInt32(item[0] is DBNull ? 0 : item[0]);
                        }
                        if (IdDespacho != "0")
                        {
                            try
                            {
                                var myForm = new CronogramaItem(IdDespacho, ItemId, DescItem, PzaPaq, _idSucursal, PzaReq, PzaProg);
                                myForm.Show();
                            }
                            catch (Exception err)
                            {
                                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                                Console.WriteLine("################## = " + err.ToString());
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show("Seleccione un item de la lista", "Error");
                        }
                    }
                    catch (Exception err)
                    {
                        XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                        Console.WriteLine("################## = " + err.ToString());
                    }
                }
                else
                {
                    Console.WriteLine("################## = GRIDCONTROL 2 NO SELECCIONA");
                }
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("####################### = " + err.ToString());
            }
        }
        private void simpleButton3_Click(object sender, EventArgs e)
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
                        string _obsDesp = string.Empty;
                        DataSet dataLista = C_Despacho.TraerObsDespacho(_idDespacho);
                        foreach (DataRow item in dataLista.Tables[0].Rows)
                        {
                            _obsDesp = item[0].ToString();
                        }

                        string ObsText = "";
                        XtraInputBoxArgs args = new XtraInputBoxArgs();
                        args.Editor.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
                        args.Caption = "Observacion";
                        args.Prompt = "Agregar observacion:  ";
                        args.DefaultButtonIndex = 0;
                        MemoEdit editor = new MemoEdit();
                        args.Editor = editor;
                        args.DefaultResponse = _obsDesp;
                        object result = XtraInputBox.Show(args);

                        if (result != null)
                        {
                            ObsText = result.ToString();
                            C_Despacho.ModificarObsDespacho(IdDespacho, ObsText);
                        }
                        Console.WriteLine("################################### = " + ObsText);
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
        //////////////////////////////////////////////////////////
        public class DetalleProducto
        {
            private string ItemId;
            private string Descripcion;
            private int PiezasReq;
            private int PiezasProg;
            private int PiezasComp;
            private decimal Peso;

            public string p_ItemId
            {
                get { return ItemId; }
                set { ItemId = value; }
            }
            public string p_Descripcion
            {
                get { return Descripcion; }
                set { Descripcion = value; }
            }
            public int p_PiezasReq
            {
                get { return PiezasReq; }
                set { PiezasReq = value; }
            }
            public int p_PiezasProg
            {
                get { return PiezasProg; }
                set { PiezasProg = value; }
            }
            public int p_PiezasComp
            {
                get { return PiezasComp; }
                set { PiezasComp = value; }
            }
            public decimal p_Peso
            {
                get { return Peso; }
                set { Peso = value; }
            }
        }
        //////////////////////////////////////////////////////////
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (gridView4.OptionsFind.AlwaysVisible == true)
            {
                gridView4.OptionsFind.AlwaysVisible = false;
            }
            else if (gridView4.OptionsFind.AlwaysVisible == false)
            {
                gridView4.OptionsFind.AlwaysVisible = true;
            }
            else
            {
                gridView4.OptionsFind.AlwaysVisible = true;
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
                    if (IdDespacho != "0")
                    {
                        if (_listEntrega.Count > 0)
                        {
                            var myForm = new CrearEntregaC(IdDespacho, _idSucursal, Placa, Chofer, _listEntrega, _pesoTotal, _login);
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
        private void btnCerrarEntregar_Click(object sender, EventArgs e)
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
                    string _fecha = view.GetRowCellDisplayText(row[0], view.Columns[1]);
                    string _sucursal = view.GetRowCellDisplayText(row[0], view.Columns[7]);
                    string _camion = view.GetRowCellDisplayText(row[0], view.Columns[3]);
                    string _chofer = view.GetRowCellDisplayText(row[0], view.Columns[5]);
                    if (IdDespacho != "0")
                    {
                        var myForm = new CerrarEntregar(IdDespacho, _fecha, _sucursal, _camion, _chofer);
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