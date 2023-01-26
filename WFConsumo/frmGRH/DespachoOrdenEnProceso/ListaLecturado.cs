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
using CRN.Entidades;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid;
using WFConsumo.frmGRH.DespachoOrdenAbierta;

namespace WFConsumo.frmGRH.DespachoOrdenEnProceso
{
    public partial class ListaLecturado : DevExpress.XtraEditors.XtraForm
    {
        private string _IdDespacho;
        int _idSucursal = 0;
        private DateTime _fechaD = DateTime.Now;
        private DateTime _FechaDesp;
        string _codigoPr;
        private int _CantidadPaq;
        private decimal _PesoUnidad;
        CPaquetes C_Paquete;
        CDespacho C_Despacho;
        CDespProductos C_DespProductos;
        DataTable dataT = new DataTable();
        List<PaqueteLecturado> _paqList = new List<PaqueteLecturado>();
        List<DespProductos> _desProdList = new List<DespProductos>();
        List<string> _listPaqLecturados = new List<string>();
        int _LoteCheck = 0;

        public ListaLecturado(string IdDespacho, DateTime _Fecha, int Sucursal)
        {
            InitializeComponent();
            _IdDespacho = IdDespacho;
            txtDespacho.Text = IdDespacho;
            _idSucursal = Sucursal;
            C_Paquete = new CPaquetes();
            C_Despacho = new CDespacho();
            C_DespProductos = new CDespProductos();
            txtFecha.Text = _Fecha.ToString("dd/MM/yyyy");
            _FechaDesp = _Fecha;
            _desProdList = new List<DespProductos>();
            TraerData();
            this.gridControl1.DataSource = _paqList;
            txtEtiqueta.Enabled = false;
        } 
        private void VerificarSucursal()
        {
            try
            {
                if(_idSucursal == 12071)
                {
                    btnBusqPaquete.Visible = true;
                    btnBusqPaquete.Enabled = true;
                    txtNroOrden.Visible = true;
                    txtNroOrden.Enabled = true;
                }
                else if(_idSucursal == 12081)
                {
                    btnBusqPaquete.Visible = true;
                    btnBusqPaquete.Enabled = true;
                    txtNroOrden.Visible = true;
                    txtNroOrden.Enabled = true;
                }
                else
                {
                    btnBusqPaquete.Visible = false;
                    btnBusqPaquete.Enabled = false;
                    txtNroOrden.Visible = false;
                    txtNroOrden.Enabled = false;
                }
            }
            catch(Exception err)
            {
                Console.WriteLine("################################### = " + err.ToString());
            }
        }
        private void TraerData()
        {
            try
            {
                CDespProductos c_ProdDesp = new CDespProductos();
                DataSet dataLista = c_ProdDesp.BuscarDespALecturar(_IdDespacho);
                foreach(DataRow item in dataLista.Tables[0].Rows)
                {
                    _paqList.Add(new PaqueteLecturado
                    {
                        p_ItemId = item[0].ToString(),
                        p_ItemFerro = item[1].ToString(),
                        p_Descripcion = item[2].ToString(),
                        p_PaqueteId = item[3].ToString(),
                        p_Piezas = Convert.ToInt32(item[4]),
                        p_Peso = Convert.ToDecimal(item[5]),
                        p_Retirar = Convert.ToInt32(item[6])
                    });
                    
                }

                DataSet dataLista2 = c_ProdDesp.BuscarDespALecturarCompleto(_IdDespacho);
                foreach (DataRow item in dataLista2.Tables[0].Rows)
                {
                    _desProdList.Add(new DespProductos
                    {
                        DespachoId = _IdDespacho,
                        ProductoId = item[3].ToString(),
                        ItemId = item[0].ToString(),
                        Fecha = _FechaDesp,
                        Status = "OPEN",
                        Cantidad = Convert.ToInt32(item[6]),
                        Peso = Convert.ToInt32(item[5]),
                        CeldaId = item[7].ToString(),
                        SucursalId = Convert.ToInt32(item[8]),
                        ItemFId = item[9].ToString(),
                        Piezas = Convert.ToInt32(item[10] is DBNull ? 0 : item[10]),
                        Metros = Convert.ToDecimal(item[11] is DBNull ? 0 : item[11]),
                        Colada = item[12].ToString()
                    });
                }
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Problemas con la conexion", "Error");
                Console.WriteLine("####################### = " + err.ToString());
            }
        }
        private void ListaLecturado_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                //Application.OpenForms["frmListaOrdenEnProceso"].Enabled = true;
            }
        }
        //btnCancelar
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnEmpezarLect_Click(object sender, EventArgs e)
        {
            if(txtEtiqueta.Enabled == true)
            {
                txtEtiqueta.Focus();
                //txtEtiqueta.Enabled = false;
                btnEmpezarLect.Text = "Finalizar lecturacion";
                //btnBusquedaMan.Enabled = false;
                //btnBusqPaquete.Enabled = false;
                //txtNroOrden.Enabled = false;
            }
            else if(txtEtiqueta.Enabled == false)
            {
                txtEtiqueta.Text = string.Empty;
                txtEtiqueta.Enabled = true;
                btnEmpezarLect.Text = "Empezar lecturacion";
                btnBusquedaMan.Enabled = true;
                btnBusqPaquete.Enabled = true;
                txtNroOrden.Enabled = true;
            }
            else
            {
                txtEtiqueta.Text = string.Empty;
                txtEtiqueta.Enabled = true;
                btnEmpezarLect.Text = "Empezar lecturacion";
                btnBusquedaMan.Enabled = true;
                btnBusqPaquete.Enabled = true;
                txtNroOrden.Enabled = true;
            }
        }
        private void txtEtiqueta_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtEtiqueta.Text) || (!string.IsNullOrEmpty(txtEtiqueta.Text)))
            {
                try
                {
                    _codigoPr = txtEtiqueta.Text;
                    if(_codigoPr != string.Empty)
                    {
                        if(_codigoPr.Length > 5)
                        {
                            Lecturar(_codigoPr);
                        }
                    }
                }
                catch(Exception err)
                {
                    XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                    Console.WriteLine("####################### = " + err.ToString());
                }
            }
        }
        private void Lecturar(string _codigoPr)
        {
            try
            {
                //DataSet dataLista = C_Paquete.TraerPaqueteLecturado( _idSucursal);
                string _IdPaquete = "0";
                _IdPaquete = _codigoPr;
                DataSet dataLista = C_Paquete.TraerPaqueteLecturadoBuscar(_idSucursal, _IdPaquete);
                
                int _piezaItem = 0;
                decimal _pesoItem = 0;
                foreach (DataRow item in dataLista.Tables[0].Rows)
                {
                    if(_codigoPr == item[3].ToString())
                    {
                        if (!_paqList.Any(n => n.p_PaqueteId == _codigoPr))
                        {
                            _paqList.Add(new PaqueteLecturado
                            {
                                p_ItemId = item[0].ToString(),
                                p_ItemFerro = item[1].ToString(),
                                p_Descripcion = item[2].ToString(),
                                p_PaqueteId = item[3].ToString(),
                                p_Piezas = Convert.ToInt32(item[4]),
                                p_Peso = Convert.ToDecimal(item[5]),
                                p_Retirar = Convert.ToInt32(item[4])
                            });
                            _IdPaquete = item[3].ToString();
                            _piezaItem = Convert.ToInt32(item[4]);
                            _pesoItem = Convert.ToDecimal(item[5]);
                        }
                        else
                        {

                        }
                    }
                }
                this.gridControl1.RefreshDataSource();
                this.gridControl1.Refresh();
                _codigoPr = string.Empty;
                txtEtiqueta.Text = string.Empty;
                txtEtiqueta.DoValidate();
                //
                DataSet dataL = C_Paquete.BuscarPaqueteLecturar(_IdPaquete);
                foreach (DataRow item in dataL.Tables[0].Rows)
                {
                    _desProdList.Add(new DespProductos
                    {
                        DespachoId = _IdDespacho,
                        ProductoId = item[0].ToString(),
                        ItemId = item[1].ToString(),
                        Fecha = _FechaDesp,
                        Status = "OPEN",
                        Cantidad = Convert.ToInt32(item[4] is DBNull ? 0 : item[4]),
                        Peso = _pesoItem,
                        CeldaId = item[2].ToString(),
                        SucursalId = _idSucursal,
                        ItemFId = item[3].ToString(),
                        Piezas = Convert.ToInt32(item[4] is DBNull ? 0:item[4]), 
                        Metros = Convert.ToDecimal(item[5] is DBNull ? 0 : item[5]),
                        Colada = item[6].ToString()
                    });
                }
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("####################### = " + err.ToString());
            }
        }
        public void PaqueteAbierto(string _IdPaquete, int _PiezasEnt, decimal _PesoEnt)
        {
            try
            {
                foreach(var item in _paqList)
                {
                    if(item.p_PaqueteId == _IdPaquete)
                    {
                        item.p_Piezas = _PiezasEnt;
                        item.p_Peso = _PesoEnt;
                    }
                }
                this.gridControl1.RefreshDataSource();
                this.gridControl1.Refresh();
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("####################### = " + err.ToString());
            }
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //guardar despproductos
            try
            {
                if(_desProdList.Count > 0)
                {
                    CDespProductos c_ProdDesp = new CDespProductos();
                    int responseD = 0;
                    foreach (var item in _desProdList)
                    {
                        CDespProductos c_DespPr = new CDespProductos();
                        DataSet dataLista = c_DespPr.VerificarLlaves(item.DespachoId, item.ProductoId);
                        if(dataLista.Tables[0].Rows.Count > 0)
                        {
                            DespProductos _despProductos = new DespProductos();
                            _despProductos = item;
                            string _idPaquete = item.ProductoId;
                            int _cantRetirada = Convert.ToInt32(item.Cantidad);
                            int _pesoNuevo = Convert.ToInt32(item.Peso);
                            responseD = c_ProdDesp.ModificarCantidad(_IdDespacho, _idPaquete, _cantRetirada, _pesoNuevo);
                            if(responseD > 0)
                            {
                                int resReservar = C_Paquete.ReservarPaquete(_idPaquete);
                                if (resReservar == 0)
                                {
                                    //XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Guardar");
                                    XtraMessageBox.Show("Problemas con la conexion", "Guardar");
                                }
                            } 
                        }
                        else
                        {
                            DespProductos _despProductos = new DespProductos();
                            _despProductos = item;
                            string _idPaquete = item.ProductoId;
                            responseD = c_ProdDesp.GuardarDespacho(_despProductos);
                            if(responseD > 0)
                            {
                                int resReservar = C_Paquete.ReservarPaquete(_idPaquete);
                                if(resReservar != 1)
                                {
                                    XtraMessageBox.Show("Problemas con la conexion", "Guardar");
                                }
                            }
                            if (responseD != 1)
                            {
                                //XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Guardar");
                                XtraMessageBox.Show("Problemas con la conexion", "Guardar");
                            }
                        } 
                    }
                    XtraMessageBox.Show("Se guardo correctamente", "Guardado");
                    this.Close();
                }
                else
                {
                    XtraMessageBox.Show("Lista de productos vacia", "Guardar");
                }
            }
            catch(Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("############################# = " + err.ToString());
                Console.WriteLine("$$$$$$$$$$$$$ = " + err.HResult.ToString());
            }
        }
        private void btnBusquedaMan_Click(object sender, EventArgs e)
        {
            int IdSucursal = _idSucursal;
            try
            { 
                if (_LoteCheck == 0)
                {
                    for (int i = 0; i < gridView1.DataRowCount; i++)
                    {
                        string ValPaq = gridView1.GetRowCellValue(i, "p_PaqueteId").ToString();

                        if (ValPaq != null && ValPaq != string.Empty)
                        {
                            _listPaqLecturados.Add(ValPaq);
                        }
                    }
                    ListaProductosLecturado form2 = new ListaProductosLecturado(IdSucursal, _IdDespacho, _listPaqLecturados);
                    form2.Owner = this;
                    form2.ShowDialog(this);
                }
                else
                {
                    int frm = 1;
                    ListaPaletLecturar form2 = new ListaPaletLecturar(IdSucursal, frm);
                    form2.Owner = this;
                    form2.ShowDialog(this);
                }
            }
            catch(Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("############################################# = " + err.ToString());
            }
        }
        public void ProductoElegido(string _idItem, string _itemFerro, string _descripcion, string _paquete, int _piezas, decimal _peso, string _unidad, int _cantidad)
        {
            try
            {
                if (_cantidad > 0)
                {
                    if(Convert.ToInt32(_peso) == _piezas)
                    {
                        XtraMessageBox.Show("Paquete con datos de Peso/Piezas erroneo", "Error");
                    }
                    else
                    {
                        string _IdPaquete = "0";
                        int _piezaItem = 0;
                        decimal _pesoItem = 0;
                        decimal _retirar = 0;
                        if (!_paqList.Any(n => n.p_PaqueteId == _paquete))
                        {
                            if(_unidad.ToUpper() == "KG")
                            {
                                _paqList.Add(new PaqueteLecturado
                                {
                                    p_ItemId = _idItem,
                                    p_ItemFerro = _itemFerro,
                                    p_Descripcion = _descripcion,
                                    p_PaqueteId = _paquete,
                                    p_Piezas = _piezas,
                                    p_Peso = _peso,
                                    p_Unidad = _unidad,
                                    p_Retirar = _cantidad
                                });
                                _retirar = _peso;
                            }
                            else if(_unidad.ToUpper() == "PCS")
                            {
                                _paqList.Add(new PaqueteLecturado
                                {
                                    p_ItemId = _idItem,
                                    p_ItemFerro = _itemFerro,
                                    p_Descripcion = _descripcion,
                                    p_PaqueteId = _paquete,
                                    p_Piezas = _piezas,
                                    p_Peso = _peso,
                                    p_Unidad = _unidad,
                                    p_Retirar = _cantidad
                                });
                                _retirar = _cantidad;
                            }
                            else
                            {
                                _paqList.Add(new PaqueteLecturado
                                {
                                    p_ItemId = _idItem,
                                    p_ItemFerro = _itemFerro,
                                    p_Descripcion = _descripcion,
                                    p_PaqueteId = _paquete,
                                    p_Piezas = _piezas,
                                    p_Peso = _peso,
                                    p_Unidad = _unidad,
                                    p_Retirar = _cantidad
                                });
                            }
                            _IdPaquete = _paquete;
                            _piezaItem = _cantidad;
                            _pesoItem = _peso;
                        }
                        
                        this.gridControl1.RefreshDataSource();
                        this.gridControl1.Refresh();
                        //
                        DataSet dataL = C_Paquete.BuscarPaqueteLecturar(_IdPaquete);
                        foreach (DataRow item in dataL.Tables[0].Rows)
                        {
                            if (_unidad.ToUpper() == "KG")
                            {
                                _desProdList.Add(new DespProductos
                                {
                                    DespachoId = _IdDespacho,
                                    ProductoId = item[0].ToString(),
                                    ItemId = item[1].ToString(),
                                    Fecha = _FechaDesp,
                                    Status = "OPEN",
                                    Cantidad = _piezaItem,
                                    Peso = _retirar,
                                    CeldaId = item[2].ToString(),
                                    SucursalId = _idSucursal,
                                    ItemFId = item[3].ToString(),
                                    Piezas = Convert.ToInt32(item[4] is DBNull ? 0 : item[4]),
                                    Metros = Convert.ToDecimal(item[5] is DBNull ? 0 : item[5]),
                                    Colada = item[6].ToString()
                                });
                            }
                            else if (_unidad.ToUpper() == "PCS")
                            {
                                _desProdList.Add(new DespProductos
                                {
                                    DespachoId = _IdDespacho,
                                    ProductoId = item[0].ToString(),
                                    ItemId = item[1].ToString(),
                                    Fecha = _FechaDesp,
                                    Status = "OPEN",
                                    Cantidad = _retirar,
                                    Peso = _pesoItem,
                                    CeldaId = item[2].ToString(),
                                    SucursalId = _idSucursal,
                                    ItemFId = item[3].ToString(),
                                    Piezas = Convert.ToInt32(item[4] is DBNull ? 0 : item[4]),
                                    Metros = Convert.ToDecimal(item[5] is DBNull ? 0 : item[5]),
                                    Colada = item[6].ToString()
                                });
                            }
                            else
                            {
                                _desProdList.Add(new DespProductos
                                {
                                    DespachoId = _IdDespacho,
                                    ProductoId = item[0].ToString(),
                                    ItemId = item[1].ToString(),
                                    Fecha = _FechaDesp,
                                    Status = "OPEN",
                                    Cantidad = _piezaItem,
                                    Peso = _pesoItem,
                                    CeldaId = item[2].ToString(),
                                    SucursalId = _idSucursal,
                                    ItemFId = item[3].ToString(),
                                    Piezas = Convert.ToInt32(item[4] is DBNull ? 0 : item[4]),
                                    Metros = Convert.ToDecimal(item[5] is DBNull ? 0 : item[5]),
                                    Colada = item[6].ToString()
                                });
                            }
                        }
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
                Console.WriteLine("############################# = " + err.ToString());
            }
        }
        private void btnBusqPaquete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNroOrden.Text) || (!string.IsNullOrEmpty(txtNroOrden.Text)))
            {
                try
                {
                    _paqList.Clear();
                    string _NroOrden = txtNroOrden.Text;
                    DataSet dataLista = C_Paquete.BuscarPaquetePorOrden(_NroOrden);
                    foreach (DataRow item in dataLista.Tables[0].Rows)
                    {
                        if (item[5].ToString().ToUpper() == "KG")
                        {
                            //_paqList.Find(p => p.p_ItemId == item[0].ToString()).p_Retirar = Convert.ToDecimal(item[4]);
                            _paqList.Add(new PaqueteLecturado
                            {
                                p_ItemId = item[0].ToString(),
                                p_Descripcion = item[1].ToString(),
                                p_PaqueteId = item[2].ToString(),
                                p_Piezas = Convert.ToInt32(item[3]),
                                p_Peso = Convert.ToDecimal(item[4]),
                                p_Unidad = item[5].ToString(),
                                p_Retirar = Convert.ToInt32(item[4])
                            });
                        }
                        else if (item[5].ToString().ToUpper() == "PCS")
                        {
                            _paqList.Add(new PaqueteLecturado
                            {
                                p_ItemId = item[0].ToString(),
                                p_Descripcion = item[1].ToString(),
                                p_PaqueteId = item[2].ToString(),
                                p_Piezas = Convert.ToInt32(item[3]),
                                p_Peso = Convert.ToDecimal(item[4]),
                                p_Unidad = item[5].ToString(),
                                p_Retirar = Convert.ToInt32(item[3])
                            });
                            //XtraMessageBox.Show(item[5].ToString(), "Aviso");
                        }
                        else
                        {
                            _paqList.Find(p => p.p_ItemId == item[0].ToString()).p_Retirar = 1;
                        }
                    }
                    this.gridControl1.RefreshDataSource();
                    this.gridControl1.Refresh();

                    foreach (var itm in _paqList)
                    {
                        DataSet dataL = C_Paquete.BuscarPaqueteLecturar(itm.p_PaqueteId);
                        foreach (DataRow item in dataL.Tables[0].Rows)
                        {
                            if (itm.p_Unidad.ToUpper() == "KG")
                            {
                                _desProdList.Add(new DespProductos
                                {
                                    DespachoId = _IdDespacho,
                                    ProductoId = item[0].ToString(),
                                    ItemId = item[1].ToString(),
                                    Fecha = _FechaDesp,
                                    Status = "OPEN",
                                    Cantidad = itm.p_Piezas,
                                    Peso = itm.p_Retirar,
                                    CeldaId = item[2].ToString(),
                                    SucursalId = _idSucursal,
                                    ItemFId = item[3].ToString(),
                                    Piezas = Convert.ToInt32(item[4] is DBNull ? 0 : item[4]),
                                    Metros = Convert.ToDecimal(item[5] is DBNull ? 0 : item[5]),
                                    Colada = item[6].ToString()
                                });
                            }
                            else if (itm.p_Unidad.ToUpper() == "PCS")
                            {
                                _desProdList.Add(new DespProductos
                                {
                                    DespachoId = _IdDespacho,
                                    ProductoId = item[0].ToString(),
                                    ItemId = item[1].ToString(),
                                    Fecha = _FechaDesp,
                                    Status = "OPEN",
                                    Cantidad = itm.p_Retirar,
                                    Peso = itm.p_Peso,
                                    CeldaId = item[2].ToString(),
                                    SucursalId = _idSucursal,
                                    ItemFId = item[3].ToString(),
                                    Piezas = Convert.ToInt32(item[4] is DBNull ? 0 : item[4]),
                                    Metros = Convert.ToDecimal(item[5] is DBNull ? 0 : item[5]),
                                    Colada = item[6].ToString()
                                });
                            }
                            else
                            {
                                _desProdList.Add(new DespProductos
                                {
                                    DespachoId = _IdDespacho,
                                    ProductoId = item[0].ToString(),
                                    ItemId = item[1].ToString(),
                                    Fecha = _FechaDesp,
                                    Status = "OPEN",
                                    Cantidad = itm.p_Piezas,
                                    Peso = itm.p_Peso,
                                    CeldaId = item[2].ToString(),
                                    SucursalId = _idSucursal,
                                    ItemFId = item[3].ToString(),
                                    Piezas = Convert.ToInt32(item[4] is DBNull ? 0 : item[4]),
                                    Metros = Convert.ToDecimal(item[5] is DBNull ? 0 : item[5]),
                                    Colada = item[6].ToString()
                                });
                            }
                        }
                    }
                }
                catch (Exception err)
                {
                    XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                    Console.WriteLine("############################# = " + err.ToString());
                }
            }
            else
            {
                XtraMessageBox.Show("Ingrese un numero de orden");
            }
        }
        private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                int _valData = e.RowHandle;
                ColumnView view = gridControl1.MainView as ColumnView;
                
                string _itmId = view.GetRowCellDisplayText(_valData, view.Columns[0]);
                string _paqtId = view.GetRowCellDisplayText(_valData, view.Columns[3]);
                int _cantN = Convert.ToInt32(view.GetRowCellDisplayText(_valData, view.Columns[6]));
                int _piezas = Convert.ToInt32(view.GetRowCellDisplayText(_valData, view.Columns[4]));
                decimal _peso = Convert.ToDecimal(view.GetRowCellDisplayText(_valData, view.Columns[5]));
                decimal _pesoFinal = (_peso / _piezas) * _cantN;
                _desProdList.Find(p => p.ItemId == _itmId && p.ProductoId == _paqtId).Cantidad = _cantN;
                _desProdList.Find(p => p.ItemId == _itmId && p.ProductoId == _paqtId).Peso = _pesoFinal;
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("####################### = " + err.ToString());
            }
        }
        private void btnQuitar_Click(object sender, EventArgs e)
        {
            ColumnView view = gridControl1.MainView as ColumnView;
            int[] row = view.GetSelectedRows();
            if (row.Length > 0)
            {
                view.FocusedRowHandle = row[0];
            }
            try
            {
                string _itmId = view.GetRowCellDisplayText(row[0], view.Columns[0]);
                string _paqueteId = view.GetRowCellDisplayText(row[0], view.Columns[3]);
                var itemToRemove = _desProdList.Single(r => r.ProductoId == _paqueteId);
                _desProdList.Remove(itemToRemove);

                var itemToRemove2 = _paqList.Single(r => r.p_PaqueteId == _paqueteId);
                _paqList.Remove(itemToRemove2);

                int a = C_DespProductos.QuitarPaqueteLecturacion(_IdDespacho, _paqueteId);
                if(a == 0)
                {
                    //XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                    //this.Close();
                }
                gridView1.BeginDataUpdate();
                gridView1.EndDataUpdate();
            }
            catch(Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("####################### = " + err.ToString());
            }
        }
        private void checkPallet_CheckedChanged(object sender, EventArgs e)
        {
            if (checkPallet.Checked == true)
            {
                _LoteCheck = 1;
            }
            else
            {
                _LoteCheck = 0;
            }
        }
    }
}