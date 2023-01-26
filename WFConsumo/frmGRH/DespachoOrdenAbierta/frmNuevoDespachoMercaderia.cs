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

namespace WFConsumo.frmGRH
{
    public partial class frmNuevoDespachoMercaderia : DevExpress.XtraEditors.XtraForm
    {
        int _idSucursal = 0;
        string _Usuario = " ";
        //
        string _nSucursal;
        string _IdProducto;
        public string _id_producto;
        public int _cantidad_producto;
        public string _cantCambiada;
        CCatChofer C_Chofer;
        CItem C_Item;
        CNroOrden C_NroOrden;
        CSucursal C_Sucursal;
        CDespacho C_Despacho;
        DataTable dataCamion = new DataTable();
        DataTable dataChofer = new DataTable();
        DataTable dataProducto = new DataTable();
        DataTable dataBproducto = new DataTable();
        DataTable dataSucursal = new DataTable();
        DataTable dataOrden = new DataTable();
        DataTable dataSucDest = new DataTable();
        DataTable dataOrden2 = new DataTable();
        DataTable dataOrden3 = new DataTable();
        string[] _marca = new string[1000];
        List<string> _marcaCam = new List<string>();
        List<int> _idCam = new List<int>();
        int _IdCamion = 0;
        List<string> _choferNom = new List<string>();
        List<int> _sucursalId = new List<int>();
        List<string> _sucursalNombre = new List<string>();
        List<Item> _itemList = new List<Item>();
        DateTime _FechaElegida = DateTime.Now;
        int _Anticipado = 0;
        int _SucElegida = 0;
        string _SucResultNombre;
        string _Naturaleza = "TRASPASO";
        int _ContFilasDataGrid = 0;
        string _programacionCheck = "PLANNED";
        string _tipoDespacho = "VENTA";
        //0 = No / 1 = Si
        int _usoNroOrd = 0;
        string sAnotacion;
        List<GlobalItem> _gbItem = new List<GlobalItem>();
        int _NroDocTraspVenta = 0;
        List<ListaNroOrdenInf> _listInformix = new List<ListaNroOrdenInf>();
        List<ItemTraerOrden> _listItemOrden = new List<ItemTraerOrden>();
        CTraspaso C_Traspaso;
        Usuario _user;
        string _destino;
        string mensajeGuardar = string.Empty;

        public frmNuevoDespachoMercaderia(int Sucursal, Usuario _usuario, DateTime _hoy)
        {
            InitializeComponent();
            _idSucursal = Sucursal;
            _Usuario = _usuario.Login.ToString();
            C_Chofer = new CCatChofer();
            C_Item = new CItem();
            C_Sucursal = new CSucursal();
            C_NroOrden = new CNroOrden();
            C_Despacho = new CDespacho();
            TraerDataCamion();
            TraerDataChofer();
            dateEdit1.DateTime = DateTime.Now;
            this.gridControl1.DataSource = Program._listaProductos;
            TraerDataSucursalAsync();
            gridView1.CellValueChanging += CantidadCambiada;
            TraerSecuencia();
            txtTipoDoc.Text = "NN";
            C_Traspaso = new CTraspaso();
        }

        List<CatChofer> _dataLista = new List<CatChofer>();
        public void TraerSecuencia()
        {
            try
            {
                sAnotacion = C_Despacho.TraerSecuencia(_idSucursal, "DESPACHO");
                textEdit1.Text = sAnotacion;
            }
            catch(Exception err)
            {
                XtraMessageBox.Show("Problemas con la conexion", "Error");
                Console.WriteLine("################## = " + err.ToString());
            }
        }
        public void TraerDataCamion()
        {
            try
            {
                DataSet dataLista = C_Chofer.TraerPlacas();
                dataCamion = dataLista.Tables[0];
                foreach (DataRow Row in dataCamion.Rows)
                {
                    comboBoxEdit1.Properties.Items.Add(Row[1]);
                    _marcaCam.Add(Row[2].ToString());
                    _idCam.Add(Convert.ToInt32(Row[0]));
                }
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Problemas con la conexion", "Error");
                Console.WriteLine("################### = " + err.ToString());
            }
        }
        public void TraerDataChofer()
        {
            try
            {
                DataSet dataLista = C_Chofer.TraerChoferes();
                dataChofer = dataLista.Tables[0];
                foreach (DataRow Row in dataChofer.Rows)
                {
                    comboBoxEdit2.Properties.Items.Add(Row[0]);
                    _choferNom.Add(Row[1].ToString());
                }
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Problemas con la conexion", "Error");
                Console.WriteLine("################### = " + err.ToString());
            }
        }
        public async Task TraerDataSucursalAsync()
        {
            await Task.Delay(1000);
            try
            {
                //if(checkAbast.Checked == false)
                //{
                //    DataSet dataLista = C_Sucursal.TraerSucursalesVenta();
                //    //DataSet dataLista = C_Sucursal.TraerTransitos();
                //    dataSucursal = dataLista.Tables[0];
                //    foreach (DataRow Row in dataSucursal.Rows)
                //    {
                //        comboBoxSuc.Properties.Items.Add((Row[0] + " - " + Row[1]).ToString());
                //        _sucursalId.Add(Convert.ToInt32(Row[0]));
                //    }
                //    _tipoDespacho = "VENTA";
                //}
                //else if(checkVenta.Checked == true)
                //{
                //    DataSet dataLista = C_Sucursal.TraerSucursalesTraspaso();
                //    //DataSet dataLista = C_Sucursal.TraerTransitos();
                //    dataSucursal = dataLista.Tables[0];
                //    foreach (DataRow Row in dataSucursal.Rows)
                //    {
                //        comboBoxSuc.Properties.Items.Add((Row[0] + " - " + Row[1]).ToString());
                //        _sucursalId.Add(Convert.ToInt32(Row[0]));
                //    }
                //    _tipoDespacho = "TRASPASO";
                //}
                //else
                //{
                //    DataSet dataLista = C_Sucursal.TraerSucursalesVenta();
                //    //DataSet dataLista = C_Sucursal.TraerTransitos();
                //    dataSucursal = dataLista.Tables[0];
                //    foreach (DataRow Row in dataSucursal.Rows)
                //    {
                //        comboBoxSuc.Properties.Items.Add((Row[0] + " - " + Row[1]).ToString());
                //        _sucursalId.Add(Convert.ToInt32(Row[0]));
                //    }
                //    _tipoDespacho = "VENTA";
                //}
                DataSet dataLista = C_Despacho.TraerSucursalesDespacho(); 
                dataSucursal = dataLista.Tables[0];
                foreach (DataRow Row in dataSucursal.Rows)
                {
                    comboBoxSuc.Properties.Items.Add((Row[0] + " - " + Row[1]).ToString());
                    _sucursalId.Add(Convert.ToInt32(Row[0]));
                    _sucursalNombre.Add(Row[1].ToString());
                }
                DataSet dataListN = C_Sucursal.BuscarNombreSuc(_idSucursal);
                foreach (DataRow item in dataListN.Tables[0].Rows)
                {
                    _nSucursal = item[0].ToString();
                }
                await Task.Delay(1000);
                await TraerClientes();
            }
            catch (Exception err)
            {
                //XtraMessageBox.Show("Problemas con la conexion", "Error");
                Console.WriteLine("################### = " + err.ToString());
            }
        }
        public async Task TraerClientes()
        {
            try
            {
                comBoxCliente.Text = "Buscar clientes...";
                //DataSet dataCl = C_NroOrden.TraerClientes();
                //foreach (DataRow Row in dataCl.Tables[0].Rows)
                //{
                //    comBoxCliente.Properties.Items.Add(Row[1].ToString());
                //}
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Problemas con la conexion", "Error");
                Console.WriteLine("################### = " + err.ToString());
            }
        }
        public void TraerNommbreSucursal(int _idSucursalDestino)
        {
            try
            {
                int _idsucursal = _idSucursalDestino;
                DataSet dataListN = C_Sucursal.BuscarNombreSuc(_idsucursal);
                foreach (DataRow item in dataListN.Tables[0].Rows)
                {
                    _SucResultNombre = item[0].ToString();
                }
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Problemas con la conexion", "Error");
                Console.WriteLine("################### = " + err.ToString());
            }
        }
        public void ComboBoxEdit1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                int _data = comboBoxEdit1.SelectedIndex;
                if (_marcaCam.Count() > 0)
                {
                    textEdit3.Text = _marcaCam[_data].ToString();
                }
                if(_idCam.Count() > 0)
                {
                    _IdCamion = _idCam[_data];
                }
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("################### = " + err.ToString());
            }
        }
        public void ComboBoxEdit2_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                int _data = comboBoxEdit2.SelectedIndex;
                if (_choferNom.Count() > 0)
                {
                    textEdit2.Text = _choferNom[_data].ToString();
                }
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("################### = " + err.ToString());
            }
        }
        public void ComboBoxSuc_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                int _data = comboBoxSuc.SelectedIndex;
                if (_sucursalId.Count() > 0)
                {
                    _SucElegida = _sucursalId[_data];
                    _destino = _sucursalNombre[_data];
                    int _idSucursalDestino = _SucElegida;
                    //DataSet dataLista = C_NroOrden.TraerTipoDocumento(_idSucursalDestino);
                    //dataSucDest = dataLista.Tables[0];
                    ////gridControl1.DataSource = dataSucDest;
                    //foreach (DataRow item in dataSucDest.Rows)
                    //{
                    //    _SucElegida = Convert.ToInt32(item[0]);
                        
                    //    txtTipoDoc.Text = item[1].ToString() + " - " + item[2].ToString();
                    //    _NroDocTraspVenta = Convert.ToInt32(item[3]);
                    //    txtNroOrden.ReadOnly = false;
                    //    btnBuscOrdenVenta.Enabled = true;
                    //}
                    TraerNommbreSucursal(_idSucursalDestino);
                }
            }
            catch(Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("################### = " + err.ToString());
            }
        }
        public void btn_ChoferClick(Object sender, EventArgs e)
        {
            var myForm = new AgregarChofer();
            myForm.Show();
            //this.Enabled = false;
        }
        //btnAgregarCamion
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var myForm = new AgregarCamion();
            myForm.Show();
            //this.Enabled = false;
        }
        public void DataChofer(string _nombreChofer, string _ciChofer)
        {
            try
            {
                textEdit2.Text = _ciChofer;
                //textEdit4.Text = _nombreChofer;
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("################### = " + err.ToString());
            }
        }
        //btnAgregarProducto
        private void simpleButton3_Click(object sender, EventArgs ev)
        {
            int Sucursal = _idSucursal;
            ListaProductos form2 = new ListaProductos(Sucursal);
            form2.Owner = this;
            form2.ShowDialog(this);
        }
        public void ProductoElegido(string _idProducto, string _itemFerro, string _descripcion, int _cantidad, int _stock, int _PzaxPaq, int _Paqs, int _Pzas, decimal _PesoPaq, decimal _PesoPaqTot)
        {
            try
            {
                if (_cantidad > 0)
                {
                    Program._listaProductos.Add(new GlobalItem
                    {
                        ItemId = _idProducto,
                        ItemFerro = _itemFerro,
                        Descripcion = _descripcion,
                        CantidadPzs = _cantidad,
                        StockPzs = _stock,
                        PzasPaq = _PzaxPaq,
                        Paqs = _Paqs,
                        PzasSob = _Pzas,
                        PesoPaq = _PesoPaq,
                        PesoPaqTotal = _PesoPaqTot
                    });

                    this.gridControl1.RefreshDataSource();
                    this.gridControl1.Refresh();
                }
                else
                {
                    //XtraMessageBox.Show("Cantidad= ", _cantidad.ToString());
                }
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("################## = " + err.ToString());
            }
        }
        public void SucursalElegida(int _idSuc, string _desc)
        {
            try
            {
                comboBoxSuc.Text = _idSuc + " - " + _desc;
                if (_sucursalId.Count() > 0)
                {
                    int _idSucursalDestino = _idSuc;
                    _SucElegida = _idSuc;
                    //_SucResultNombre = _desc;
                    DataSet dataLista = C_NroOrden.TraerTipoDocumento(_idSucursalDestino);
                    dataSucDest = dataLista.Tables[0];
                    foreach (DataRow item in dataSucDest.Rows)
                    {
                        txtTipoDoc.Text = item[1].ToString() + " - " + item[2].ToString();
                        _NroDocTraspVenta = Convert.ToInt32(item[3]);
                        txtNroOrden.ReadOnly = false;
                        btnBuscOrdenVenta.Enabled = true;
                    }
                    if(this.Enabled == false)
                    {
                        this.Enabled = true;
                    }
                }
            }
            catch(Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("####################### = " + err.ToString());
            }
        }
        public void ClienteElegido(int _IdCliente, string _NombreCliente)
        {
            try
            {
                comBoxCliente.Text = _NombreCliente;
                if (_sucursalId.Count() > 0)
                {
                    //int _idSucursalDestino = _idSuc;
                    
                    if (this.Enabled == false)
                    {
                        this.Enabled = true;
                    }
                }
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("####################### = " + err.ToString());
            }
        }
        public void gridView1_RowCellClick(Object sender, EventArgs e)
        {
            ColumnView view = this.gridControl1.MainView as ColumnView;
            int[] row = view.GetSelectedRows();
            view.FocusedRowHandle = row[0];
            _IdProducto = (view.GetRowCellDisplayText(row[0], view.Columns[0])).ToString();
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
                _FechaElegida = dateEdit1.DateTime;
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
                    int _idSucursalDestino = _SucElegida;
                    string _nroOrden = txtNroOrden.Text;
                    //DataSet dataLista = C_NroOrden.TraerOrden(_nroOrden, _idSucursalDestino);
                    DataSet dataLista = C_NroOrden.TraerTodo(_idSucursalDestino);
                    dataOrden = dataLista.Tables[0];
                    //Console.WriteLine("############ == " + dataOrden.Rows.Count);
                    if (dataOrden.Rows.Count > 0)
                    {
                        foreach (DataRow item in dataLista.Tables[0].Rows)
                        {
                            Program._listaProductos.Add(new GlobalItem
                            {
                                ItemId = item[0].ToString(),
                                Descripcion = item[1].ToString(),
                                CantidadPzs = Convert.ToInt32(item[2]),
                                StockPzs = Convert.ToInt32(item[1]),
                                PzasPaq = Convert.ToInt32(item[4]),
                                Paqs = Convert.ToInt32(item[5]),
                                PzasSob = Convert.ToInt32(item[2]),
                                PesoPaq = Convert.ToDecimal(item[4])
                            });
                        }
                    }
                    else
                    {
                        //XtraMessageBox.Show("Cantidad= ", _cantidad.ToString());
                    }
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
            txtNroOrden.Text = "0000"; 
            _ContFilasDataGrid = gridView1.RowCount;
            int actualizar = 1; 
            if (!string.IsNullOrWhiteSpace(textEdit1.Text) || (!string.IsNullOrEmpty(textEdit1.Text)))
            {
                if (!string.IsNullOrWhiteSpace(comboBoxEdit1.Text) || (!string.IsNullOrEmpty(comboBoxEdit1.Text)))
                {
                    if (!string.IsNullOrWhiteSpace(comboBoxEdit2.Text) || (!string.IsNullOrEmpty(comboBoxEdit2.Text)))
                    {
                        if (!string.IsNullOrWhiteSpace(textEdit2.Text) || (!string.IsNullOrEmpty(textEdit2.Text)))
                        {
                            if (!string.IsNullOrWhiteSpace(textEdit3.Text) || (!string.IsNullOrEmpty(textEdit3.Text)))
                            {
                                if (!string.IsNullOrWhiteSpace(txtTipoDoc.Text) || (!string.IsNullOrEmpty(txtTipoDoc.Text)))
                                {
                                    if (!string.IsNullOrWhiteSpace(txtNroOrden.Text) || (!string.IsNullOrEmpty(txtNroOrden.Text)))
                                    {
                                        if (_programacionCheck == "PLANNED" && _ContFilasDataGrid != 0)
                                        {
                                            if(_Naturaleza.ToUpper() == "VENTA")
                                            {
                                                _destino = comBoxCliente.Text;
                                            }
                                            string _IdDespacho = C_Despacho.TraerSecuencia(_idSucursal, "DESPACHO");
                                            string sError = string.Empty;
                                            try
                                            {
                                                Despacho _despacho = new Despacho();
                                                CDespacho c_despacho = new CDespacho();

                                                _despacho.p_DespachoId = textEdit1.Text;
                                                _despacho.p_Fecha = _FechaElegida;
                                                _despacho.p_NroOrden = "0000";
                                                _despacho.p_Id_Camion = _IdCamion;
                                                _despacho.p_Placa = comboBoxEdit1.Text;
                                                _despacho.p_Marca = textEdit3.Text;
                                                _despacho.p_Chofer = comboBoxEdit2.Text;
                                                _despacho.p_CI = textEdit2.Text;
                                                _despacho.p_Destino = _destino;
                                                _despacho.p_Login = _Usuario;
                                                _despacho.p_status = "OPEN";
                                                _despacho.p_Correlativo = 0; // momentaneo
                                                _despacho.p_Obs = "";
                                                _despacho.p_Tipo = "PLANNED";
                                                _despacho.p_Cargador = "";
                                                _despacho.p_NumTraspaso = "0000"; //no va en este nivel
                                                _despacho.p_SucursalId = _idSucursal;  //sucursal actual
                                                _despacho.p_SucDestino = _SucElegida; // cargar la info del numero de orden
                                                _despacho.p_HorarioPartida = DateTime.Now; //
                                                _despacho.p_HorarioLlegada = DateTime.Now; //
                                                _despacho.p_Naturaleza = _Naturaleza;
                                                _despacho.p_Anticipado = 0;
                                                _despacho.p_Entregado = 0;
                                                //
                                                DataTable dt = new DataTable();
                                                dt.Columns.Add("p_DespachoId");
                                                dt.Columns.Add("p_ItemId");
                                                dt.Columns.Add("p_Cantidad");
                                                dt.Columns.Add("p_SolPiezasSueltas");
                                                dt.Columns.Add("p_ConfPiezasSueltas");
                                                dt.Columns.Add("p_CantConfirmada");
                                                dt.Columns.Add("p_Unidad");
                                                dt.Columns.Add("p_Status");
                                                dt.Columns.Add("p_SucursalId");
                                                DataRow dr = null;

                                                foreach (var item in Program._listaProductos)
                                                {
                                                    dr = dt.NewRow(); // have new row on each iteration
                                                    dr["p_DespachoId"] = textEdit1.Text;
                                                    dr["p_ItemId"] = item.ItemId;
                                                    dr["p_Cantidad"] = item.CantidadPzs;
                                                    dr["p_SolPiezasSueltas"] = 0;
                                                    dr["p_ConfPiezasSueltas"] = 0;
                                                    dr["p_CantConfirmada"] = 0;
                                                    dr["p_Unidad"] = "";
                                                    dr["p_Status"] = "";
                                                    dr["p_SucursalId"] = _idSucursal;
                                                    dt.Rows.Add(dr);
                                                } 
                                                //
                                                DataTable dtsDespDetalle;
                                                //dtsDespDetalle = (DataTable)gridView1.DataSource;
                                                int iSucursal = _idSucursal;
                                                if (c_despacho.InsertarDespacho(out sError, _despacho, dt, iSucursal) > 0)
                                                {
                                                    XtraMessageBox.Show("Despacho agregado", "Guardar");
                                                    this.Close();
                                                }
                                                else
                                                {
                                                    XtraMessageBox.Show("Problemas al agregar el despacho", "Guardar");
                                                    this.Close();
                                                }
                                            }
                                            catch (Exception err)
                                            {
                                                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                                                Console.WriteLine("################## = " + err.ToString());
                                            }
                                        }
                                        else if(_programacionCheck == "CONTINUO")
                                        {
                                            string _IdDespacho = C_Despacho.TraerSecuencia(_idSucursal, "DESPACHO");
                                            string sError = string.Empty;
                                            try
                                            {
                                                int iSucursal = _idSucursal;
                                                Despacho _despacho = new Despacho();
                                                _despacho.p_DespachoId = textEdit1.Text;
                                                _despacho.p_Fecha = _FechaElegida;
                                                _despacho.p_NroOrden = "0000";
                                                _despacho.p_Id_Camion = _IdCamion;
                                                _despacho.p_Placa = comboBoxEdit1.Text;
                                                _despacho.p_Marca = textEdit3.Text;
                                                _despacho.p_Chofer = comboBoxEdit2.Text;
                                                _despacho.p_CI = textEdit2.Text;
                                                _despacho.p_Destino = _destino;
                                                _despacho.p_Login = _Usuario;
                                                _despacho.p_status = "OPEN";
                                                _despacho.p_Correlativo = 0; // momentaneo
                                                _despacho.p_Obs = "";
                                                _despacho.p_Tipo = "CONTINUO";
                                                _despacho.p_Cargador = "";
                                                _despacho.p_NumTraspaso = "0000"; //no va en este nivel
                                                _despacho.p_SucursalId = _idSucursal;  //sucursal actual
                                                _despacho.p_SucDestino = _SucElegida; // cargar la info del numero de orden
                                                _despacho.p_HorarioPartida = DateTime.Now; //
                                                _despacho.p_HorarioLlegada = DateTime.Now; //
                                                _despacho.p_Naturaleza = _Naturaleza;
                                                _despacho.p_Anticipado = 0;
                                                CDespacho c_despacho = new CDespacho();
                                               
                                                DataTable dt = new DataTable();
                                                if(c_despacho.InsertarDespacho(out sError, _despacho, dt, iSucursal) > 0)
                                                {
                                                    XtraMessageBox.Show("Despacho agregado", "Guardar");
                                                    Program._listaProductos.Clear();
                                                    this.Close();
                                                }
                                                else
                                                {
                                                    XtraMessageBox.Show("Problemas al agregar el despacho", "Guardar");
                                                    Program._listaProductos.Clear();
                                                    this.Close();
                                                }
                                            }
                                            catch (Exception err)
                                            {
                                                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                                                Console.WriteLine("####################### = " + err.ToString());
                                            }
                                        }
                                        else
                                        {
                                            XtraMessageBox.Show("Agregue productos a la lista");
                                        }
                                    }
                                    else
                                    {
                                        XtraMessageBox.Show("El campo 'Numero de orden' esta vacio", "Error");
                                    }
                                }
                                else
                                {
                                    XtraMessageBox.Show("El campo 'Tipo de documento' esta vacio", "Error");
                                }
                            }
                            else
                            {
                                XtraMessageBox.Show("El campo 'Camion' esta vacio", "Error");
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show("El campo 'CI' esta vacio", "Error");
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("El campo 'Chofer' esta vacio", "Error");
                    }
                }
                else
                {
                    XtraMessageBox.Show("El campo 'Placa' esta vacio", "Error");
                }
            }
            else
            {
                XtraMessageBox.Show("El campo 'Numero de despacho' esta vacio", "Error");
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
            BuscarSucursal form3 = new BuscarSucursal(_tipoDespacho);
            form3.Owner = this;
            form3.ShowDialog(this);
            
            //this.Enabled = false;
        }
        //btnBuscarCliente
        private void simpleButton7_Click_1(object sender, EventArgs e)
        {
            BuscarCliente form4 = new BuscarCliente();
            form4.Owner = this;
            form4.ShowDialog(this);
        }
        private void checkVenta_CheckedChanged(object sender, EventArgs e)
        {
            if (checkVenta.Checked == true)
            {
                checkAbast.Checked = false; 
                checkAnticipada.Visible = true;
                checkNormal.Visible = true;
                _Naturaleza = "VENTA";
                labelControl7.Visible = true;
                comBoxCliente.Visible = true;
                simpleButton7.Visible = true;
                labelControl9.Visible = false;
                txtNroOrden.Visible = false;
                btnBuscOrdenVenta.Visible = false;
                if (_NroDocTraspVenta == 0)
                {
                    txtNroOrden.ReadOnly = true;
                    btnBuscOrdenVenta.Enabled = false;
                }
                else
                {
                    txtNroOrden.ReadOnly = false;
                    btnBuscOrdenVenta.Enabled = true;
                }
            }
            else if(checkVenta.Checked == false && checkAbast.Checked == false)
            {
                checkAbast.Checked = true;
            }
        }
        private void checkAbast_CheckedChanged(object sender, EventArgs e)
        {
            if (checkAbast.Checked == true)
            {
                checkVenta.Checked = false; 
                checkAnticipada.Visible = false;
                checkNormal.Visible = false;
                _Naturaleza = "TRASPASO";
                labelControl7.Visible = false;
                comBoxCliente.Visible = false;
                simpleButton7.Visible = false;
                labelControl9.Visible = false;
                txtNroOrden.Visible = false;
                btnBuscOrdenVenta.Visible = false;
                if (_NroDocTraspVenta == 0)
                {
                    txtNroOrden.ReadOnly = true;
                    btnBuscOrdenVenta.Enabled = false;
                }
                else
                {
                    txtNroOrden.ReadOnly = false;
                    btnBuscOrdenVenta.Enabled = true;
                }
            }
            else if (checkVenta.Checked == false && checkAbast.Checked == false)
            {
                checkAbast.Checked = true;
            }
        }
        private void checkNormal_CheckedChanged(object sender, EventArgs e)
        {
            if (checkNormal.Checked == true)
            {
                checkAnticipada.Checked = false;
            }
            else
            {
                checkAnticipada.Checked = true;
            }
        }
        private void checkAnticipada_CheckedChanged(object sender, EventArgs e)
        {
            if (checkAnticipada.Checked == true)
            {
                checkNormal.Checked = false;
            }
            else
            {
                checkNormal.Checked = true;
            }
        }
        private void CantidadCambiada(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                int _NewCant = Convert.ToInt32(e.Value); 
                int _stockVal = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "StockPzs"));
                if (_NewCant >= _stockVal)
                {
                    XtraMessageBox.Show("El valor es mayor al stock disponible", "Error");
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "CantidadPzs", _stockVal);
                }
                else
                {
                    //XtraMessageBox.Show("NewCant = " + _NewCant + " | Stock = " + _stockVal, "Data");
                }
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("################## = " + err.ToString());
            }
        }
        private void chckCont_CheckedChanged(object sender, EventArgs e)
        {
            if(chckCont.Checked == true)
            {
                chckPlan.Checked = false;
                _programacionCheck = "CONTINUO";
                gridControl1.Visible = false;
                simpleButton3.Visible = false;
                simpleButton4.Visible = false;
                simpleButton5.Location = new Point(649, 360);
                simpleButton8.Location = new Point(755, 360);
                ClientSize = new Size(876, 400);
            }
            else if(chckCont.Checked == false)
            {
                chckPlan.Checked = true;
                _programacionCheck = "PLANNED";
                gridControl1.Visible = true;
                simpleButton3.Visible = true;
                simpleButton4.Visible = true;
                simpleButton5.Location = new Point(649, 617);
                simpleButton8.Location = new Point(755, 617);
                ClientSize = new Size(876, 659);
            }
            else
            {
                chckCont.Checked = false;
                chckPlan.Checked = true;
                _programacionCheck = "PLANNED";
                gridControl1.Visible = true;
                simpleButton3.Visible = true;
                simpleButton4.Visible = true;
                simpleButton5.Location = new Point(649, 617);
                simpleButton8.Location = new Point(755, 617);
                ClientSize = new Size(876, 659);
            }
        }
        private void chckPlan_CheckedChanged(object sender, EventArgs e)
        {
            if(chckPlan.Checked == true)
            {
                chckCont.Checked = false;
                _programacionCheck = "PLANNED";
                gridControl1.Visible = true;
                simpleButton3.Visible = true;
                simpleButton4.Visible = true;
                simpleButton5.Location = new Point(649, 617);
                simpleButton8.Location = new Point(755, 617);
                ClientSize = new Size(876, 659);
            }
            else if(chckPlan.Checked == false)
            {
                chckCont.Checked = true;
                _programacionCheck = "CONTINUO";
                gridControl1.Visible = false;
                simpleButton3.Visible = false;
                simpleButton4.Visible = false;
                simpleButton5.Location = new Point(649, 360);
                simpleButton8.Location = new Point(755, 360);
                ClientSize = new Size(876, 400);
            }
            else
            {
                chckPlan.Checked = true;
                chckCont.Checked = false;
                _programacionCheck = "PLANNED";
                gridControl1.Visible = true;
                simpleButton3.Visible = true;
                simpleButton4.Visible = true;
                simpleButton5.Location = new Point(649, 617);
                simpleButton8.Location = new Point(755, 617);
                ClientSize = new Size(876, 659);
            }
        }
        //Buscar orden 
        private void txtNroOrden_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (!string.IsNullOrWhiteSpace(txtNroOrden.Text) || (!string.IsNullOrEmpty(txtNroOrden.Text)))
                    {
                        if (_NroDocTraspVenta == 0)
                        {
                            XtraMessageBox.Show("Elija una sucursal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (_NroDocTraspVenta > 0)
                        {
                            _listInformix.Clear();
                            _listItemOrden.Clear();
                            _gbItem.Clear();
                            this.gridControl1.DataSource = _gbItem;
                            this.gridControl1.RefreshDataSource();
                            this.gridControl1.Refresh();
                            int _nroOrden = Convert.ToInt32(txtNroOrden.Text);
                            DataSet dataLista2 = C_NroOrden.TraerProductos(_nroOrden, _NroDocTraspVenta);
                            if (dataLista2.Tables[0].Rows.Count == 0)
                            {
                                XtraMessageBox.Show("No existen productos en esa orden de venta", "Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            foreach (DataRow items in dataLista2.Tables[0].Rows)
                            {
                                _listInformix.Add(new ListaNroOrdenInf
                                {
                                    _id = items[0].ToString(),
                                    _cant = Convert.ToInt32(items[1])
                                });
                            }
                            DataSet dataItems = C_Item.TraerProductosConItemFid(_idSucursal);
                            foreach (DataRow item in dataItems.Tables[0].Rows)
                            {
                                _listItemOrden.Add(new ItemTraerOrden
                                {
                                    p_ItemFId = item[0].ToString(),
                                    p_ItemId = item[1].ToString(),
                                    p_Descripcion = item[2].ToString(),
                                    p_Piezas = Convert.ToInt32(item[3]),
                                    p_Stock = Convert.ToInt32(item[4]),
                                    p_Peso = Convert.ToDecimal(item[5])
                                });
                            }
                            var result = from _id in _listInformix join p_ItemFId in _listItemOrden on _id._id equals p_ItemFId.p_ItemFId select new { p_ItemFId.p_ItemFId, p_ItemFId.p_ItemId, p_ItemFId.p_Descripcion, p_ItemFId.p_Stock, p_ItemFId.p_Piezas, p_ItemFId.p_Peso, _id._cant };

                            foreach (var items in result)
                            {
                                int _paqs = 0;
                                _paqs = Convert.ToInt32(items._cant / items.p_Piezas);
                                int _pzsSobra = 0;
                                _pzsSobra = Convert.ToInt32(items._cant - (_paqs * Convert.ToInt32(items.p_Piezas)));
                                decimal _pesoTot = 0;
                                _pesoTot = Convert.ToDecimal(items.p_Peso * items._cant);
                                _gbItem.Add(new GlobalItem
                                {
                                    ItemId = items.p_ItemId.ToString(),
                                    ItemFerro = items.p_ItemFId.ToString(),
                                    Descripcion = items.p_Descripcion.ToString(),
                                    CantidadPzs = Convert.ToInt32(items._cant),
                                    StockPzs = Convert.ToInt32(items.p_Stock),
                                    PzasPaq = Convert.ToInt32(items.p_Piezas),
                                    Paqs = _paqs,
                                    PzasSob = _pzsSobra,
                                    PesoPaq = Convert.ToDecimal(items.p_Peso),
                                    PesoPaqTotal = _pesoTot
                                });
                            }
                            int cantInformix = dataLista2.Tables[0].Rows.Count;
                            int cantTotal = result.Count();
                            var no_result = _listInformix.Where(x => _gbItem.All(y => y.ItemFerro != x._id));

                            if (cantInformix != cantTotal)
                            {
                                XtraMessageBox.Show(no_result.Count() + " productos sin registrar, ingreselos en el pryAlmacen", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                simpleButton5.Enabled = false;
                                foreach (var item in no_result)
                                {
                                    _gbItem.Add(new GlobalItem
                                    {
                                        ItemId = "-",
                                        ItemFerro = item._id,
                                        Descripcion = "",
                                        CantidadPzs = Convert.ToInt32(item._cant),
                                        StockPzs = 0,
                                        PzasPaq = 0,
                                        Paqs = 0,
                                        PzasSob = 0,
                                        PesoPaq = 0,
                                        PesoPaqTotal = 0
                                    });
                                }
                            }
                            this.gridControl1.DataSource = _gbItem;
                            this.gridControl1.RefreshDataSource();
                            this.gridControl1.Refresh();
                        }
                        else
                        {
                            XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.Close();
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
        private void btnCarOrdenVenta_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtNroOrden.Text) || (!string.IsNullOrEmpty(txtNroOrden.Text)))
                {
                    if (_NroDocTraspVenta == 0)
                    {
                        XtraMessageBox.Show("Elija una sucursal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (_NroDocTraspVenta > 0)
                    {
                        _listInformix.Clear();
                        _listItemOrden.Clear();
                        _gbItem.Clear();
                        this.gridControl1.DataSource = _gbItem;
                        this.gridControl1.RefreshDataSource();
                        this.gridControl1.Refresh();
                        int _nroOrden = Convert.ToInt32(txtNroOrden.Text);
                        DataSet dataLista2 = C_NroOrden.TraerProductos(_nroOrden, _NroDocTraspVenta);
                        if (dataLista2.Tables[0].Rows.Count == 0)
                        {
                            XtraMessageBox.Show("No existen productos en esa orden de venta", "Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        } 
                        foreach (DataRow items in dataLista2.Tables[0].Rows)
                        {
                            _listInformix.Add(new ListaNroOrdenInf
                            {
                                _id = items[0].ToString(),
                                _cant = Convert.ToInt32(items[1])
                            });
                        }
                        DataSet dataItems = C_Item.TraerProductosConItemFid(_idSucursal);
                        foreach (DataRow item in dataItems.Tables[0].Rows)
                        {
                            _listItemOrden.Add(new ItemTraerOrden
                            {
                                p_ItemFId = item[0].ToString(),
                                p_ItemId = item[1].ToString(),
                                p_Descripcion = item[2].ToString(),
                                p_Piezas = Convert.ToInt32(item[3]),
                                p_Stock = Convert.ToInt32(item[4]),
                                p_Peso = Convert.ToDecimal(item[5])
                            });
                        }
                        var result = from _id in _listInformix join p_ItemFId in _listItemOrden on _id._id equals p_ItemFId.p_ItemFId select new { p_ItemFId.p_ItemFId, p_ItemFId.p_ItemId, p_ItemFId.p_Descripcion, p_ItemFId.p_Stock, p_ItemFId.p_Piezas, p_ItemFId.p_Peso, _id._cant };
                        
                        foreach (var items in result)
                        {
                            int _paqs = 0;
                            _paqs = Convert.ToInt32(items._cant / items.p_Piezas);
                            int _pzsSobra = 0;
                            _pzsSobra = Convert.ToInt32(items._cant - (_paqs * Convert.ToInt32(items.p_Piezas)));
                            decimal _pesoTot = 0;
                            _pesoTot = Convert.ToDecimal(items.p_Peso * items._cant);
                            _gbItem.Add(new GlobalItem
                            {
                                ItemId = items.p_ItemId.ToString(),
                                ItemFerro = items.p_ItemFId.ToString(),
                                Descripcion = items.p_Descripcion.ToString(),
                                CantidadPzs = Convert.ToInt32(items._cant),
                                StockPzs = Convert.ToInt32(items.p_Stock),
                                PzasPaq = Convert.ToInt32(items.p_Piezas),
                                Paqs = _paqs,
                                PzasSob = _pzsSobra,
                                PesoPaq = Convert.ToDecimal(items.p_Peso),
                                PesoPaqTotal = _pesoTot
                            });
                        }
                        int cantInformix = dataLista2.Tables[0].Rows.Count;
                        int cantTotal = result.Count();
                        var no_result = _listInformix.Where(x => _gbItem.All(y => y.ItemFerro != x._id));
                        
                        if(cantInformix != cantTotal)
                        {
                            XtraMessageBox.Show(no_result.Count() + " productos sin registrar, ingreselos en el pryAlmacen", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            simpleButton5.Enabled = false;
                            foreach (var item in no_result)
                            {
                                _gbItem.Add(new GlobalItem
                                {
                                    ItemId = "-",
                                    ItemFerro = item._id,
                                    Descripcion = "",
                                    CantidadPzs = Convert.ToInt32(item._cant),
                                    StockPzs = 0,
                                    PzasPaq = 0,
                                    Paqs = 0,
                                    PzasSob = 0,
                                    PesoPaq = 0,
                                    PesoPaqTotal = 0
                                });
                            }
                        }
                        this.gridControl1.DataSource = _gbItem;
                        this.gridControl1.RefreshDataSource();
                        this.gridControl1.Refresh();
                    }
                    else
                    {
                        XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Close();
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
}