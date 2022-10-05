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
using System.Data.Common;

namespace WFConsumo.frmGRH.DespachoOrdenAbierta
{
    public partial class frmEditarDespacho : DevExpress.XtraEditors.XtraForm
    {
        string _IdDespacho = "0";
        int idSucursal = 0;
        DataTable dataDesp = new DataTable();
        CDespacho C_Despacho;
        CDespDetalle C_DespDetalle;
        CCatChofer C_Chofer;
        CSucursal C_Sucursal;
        CNroOrden C_NroOrden;
        DataTable dataCamion = new DataTable();
        DataTable dataChofer = new DataTable();
        DataTable dataSucursal = new DataTable();
        DataTable dataSucDest = new DataTable();
        int _SucElegida = 0;
        string _nSucursal;
        List<string> _marcaCam = new List<string>();
        List<string> _choferNom = new List<string>();
        List<int> _sucursalId = new List<int>();
        List<GlobalItem> _itemsEdit = new List<GlobalItem>();
        List<int> _idCam = new List<int>();
        List<string> _sucursalNombre = new List<string>();
        int _IdCamion = 0;
        string _SucResultNombre;
        string _tipoDespacho = "VENTA";
        string _programacion = "0";
        string _Naturaleza = "TRASPASO";
        string _programacionCheck = "PLANNED";
        string valorDefaultSucursal = "";
        string valorDefaultCliente = "";
        string _destino = "";

        public frmEditarDespacho(string IdDespacho, int _idSucursal)
        {
            InitializeComponent();
            _IdDespacho = IdDespacho;
            idSucursal = _idSucursal;
            C_Despacho = new CDespacho();
            C_DespDetalle = new CDespDetalle();
            C_Chofer = new CCatChofer();
            C_Sucursal = new CSucursal();
            TraerData();
            TraerDataCamion();
            TraerDataChofer();
            TraerDataSucursal();
        }

        public void TraerData()
        {
            try
            {
                if (_IdDespacho != "0")
                {
                    DataSet dataBuscar = C_Despacho.ConsultarDespacho(_IdDespacho);
                    dataDesp = dataBuscar.Tables[0];
                    foreach (DataRow item in dataDesp.Rows)
                    {
                        txtNroDespacho.Text = item["DespachoId"].ToString();
                        _tipoDespacho = item["Naturaleza"].ToString();
                        pickerFecha.EditValue = Convert.ToDateTime(item["Fecha"]).ToString("dd/MM/yyyy");
                        comboBoxChofer.Text = item["Chofer"].ToString();
                        txtCI.Text = item["CI"].ToString();
                        comboBoxPlaca.Text = item["Placa"].ToString();
                        txtCamion.Text = item["Marca"].ToString();
                        comboBoxSucursal.Text = item["SucDestino"].ToString();
                        valorDefaultSucursal = item["SucDestino"].ToString();
                        _SucElegida = Convert.ToInt32(item["SucDestino"]);
                        _programacion = item["Tipo"].ToString();
                        txtObs.Text = item["Obs"].ToString();
                        _IdCamion = Convert.ToInt32(item["Id_Camion"]);
                    }
                    if (_tipoDespacho.ToUpper() == "TRASPASO")
                    {
                        checkAbast.Checked = true;
                        txtSucursal.Visible = true;
                        comboBoxSucursal.Visible = true;
                        btnBuscarSucursal.Visible = true;
                        txtCliente.Visible = false;
                        comBoxCliente.Visible = false;
                        btnCliente.Visible = false;
                    }
                    else if (_tipoDespacho.ToUpper() == "VENTA")
                    {
                        checkVenta.Visible = true;
                        txtCliente.Visible = true;
                        comBoxCliente.Visible = true;
                        btnCliente.Visible = true;
                        txtSucursal.Visible = false;
                        comboBoxSucursal.Visible = false;
                        btnBuscarSucursal.Visible = false;
                    }
                    else
                    {
                        txtSucursal.Visible = true;
                        comboBoxSucursal.Visible = true;
                        btnBuscarSucursal.Visible = true;
                        txtCliente.Visible = false;
                        comBoxCliente.Visible = false;
                        btnCliente.Visible = false;
                    }
                    //
                    if (_programacion.ToUpper() == "CONTINUO")
                    {
                        chckCont.Checked = true;
                        chckPlan.Checked = false;
                    }
                    else if (_programacion.ToUpper() == "PLANNED")
                    {
                        chckPlan.Checked = true;
                        chckCont.Checked = false;
                    }
                    else
                    {
                        chckPlan.Checked = true;
                        chckCont.Checked = false;
                    }
                    DataSet dataDet = C_Despacho.TraerEditarDetalleDespacho(_IdDespacho);
                    int contDataDet = dataDet.Tables[0].Rows.Count;
                    foreach (DataRow item in dataDet.Tables[0].Rows)
                    {
                        int PaqComp = Convert.ToInt32(item[3]) / Convert.ToInt32(item[5]);
                        int PaqSuelt = Convert.ToInt32(item[3]) - (PaqComp * Convert.ToInt32(item[5]));
                        if (contDataDet > 0)
                        {
                            Program._listaProductos.Add(new GlobalItem
                            {
                                ItemId = item[0].ToString(),
                                ItemFerro = item[1].ToString(),
                                Descripcion = item[2].ToString(),
                                CantidadPzs = Convert.ToInt32(item[3]),
                                StockPzs = Convert.ToInt32(item[4]),
                                PzasPaq = Convert.ToInt32(item[5]),
                                Paqs = PaqComp,
                                PzasSob = PaqSuelt,
                                PesoPaq = Convert.ToDecimal(item[6]),
                                PesoPaqTotal = Convert.ToDecimal(item[6]) * Convert.ToInt32(item[3])
                            });
                            _itemsEdit.Add(new GlobalItem
                            {
                                ItemId = item[0].ToString(),
                                ItemFerro = item[1].ToString(),
                                Descripcion = item[2].ToString(),
                                CantidadPzs = Convert.ToInt32(item[3]),
                                StockPzs = Convert.ToInt32(item[4]),
                                PzasPaq = Convert.ToInt32(item[5]),
                                Paqs = PaqComp,
                                PzasSob = PaqSuelt,
                                PesoPaq = Convert.ToDecimal(item[6]),
                                PesoPaqTotal = Convert.ToDecimal(item[6]) * Convert.ToInt32(item[3])
                            });
                        }
                        else
                        {
                            //XtraMessageBox.Show("Cantidad= ", _cantidad.ToString());
                        }
                    }
                    this.gridControl1.DataSource = Program._listaProductos;
                }
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("####################### = " + err.ToString());
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
                    comboBoxPlaca.Properties.Items.Add(Row[1]);
                    _marcaCam.Add(Row[2].ToString());
                }
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("####################### = " + err.ToString());
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
                    comboBoxChofer.Properties.Items.Add(Row[0]);
                    _choferNom.Add(Row[1].ToString());
                }
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("####################### = " + err.ToString());
            }
        }
        public void TraerDataSucursal()
        {
            try
            {
                //if (_tipoDespacho == "TRASPASO")
                //{
                //    DataSet dataLista = C_Sucursal.TraerSucursalesTraspaso();
                //    dataSucursal = dataLista.Tables[0];
                //    foreach (DataRow Row in dataSucursal.Rows)
                //    {
                //        comboBoxSucursal.Properties.Items.Add(Row[1]);
                //        _sucursalId.Add(Convert.ToInt32(Row[0]));
                //    }
                //}
                //else if (_tipoDespacho == "VENTA")
                //{
                //    DataSet dataLista = C_Despacho.TraerSucursalesVenta();
                //    dataSucursal = dataLista.Tables[0];
                //    foreach (DataRow Row in dataSucursal.Rows)
                //    {
                //        comboBoxSucursal.Properties.Items.Add(Row[1]);
                //        _sucursalId.Add(Convert.ToInt32(Row[0]));
                //    }
                //}
                //else
                //{
                //    DataSet dataLista = C_Sucursal.TraerSucursalesTraspaso();
                //    dataSucursal = dataLista.Tables[0];
                //    foreach (DataRow Row in dataSucursal.Rows)
                //    {
                //        comboBoxSucursal.Properties.Items.Add(Row[1]);
                //        _sucursalId.Add(Convert.ToInt32(Row[0]));
                //    }
                //}

                DataSet dataLista1 = C_Despacho.TraerSucursalesDespacho();
                dataSucursal = dataLista1.Tables[0];
                foreach (DataRow Row in dataSucursal.Rows)
                {
                    comboBoxSucursal.Properties.Items.Add((Row[0] + " - " + Row[1]).ToString());
                    _sucursalId.Add(Convert.ToInt32(Row[0]));
                    _sucursalNombre.Add(Row[1].ToString());
                }
                DataSet dataListN = C_Sucursal.BuscarNombreSuc(idSucursal);
                foreach (DataRow item in dataListN.Tables[0].Rows)
                {
                    _nSucursal = item[0].ToString();
                }
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("####################### = " + err.ToString());
            }
        }
        public void SucursalElegida(int _idSuc, string _desc)
        {
            try
            {
                comboBoxSucursal.Text = _idSuc + " - " + _desc;
                if (_sucursalId.Count() > 0)
                {
                    int _idSucursalDestino = _idSuc;
                    _SucElegida = _idSuc; 
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
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmEditarDespacho_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                //Application.OpenForms["frmListaDespachoMercaderia"].Enabled = true;
            }
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //Aceptar
        }
        private void comboBoxChofer_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int _data = comboBoxChofer.SelectedIndex;
                if (_choferNom.Count() > 0)
                {
                    txtCI.Text = _choferNom[_data].ToString();
                }
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("####################### = " + err.ToString());
            }
        }
        private void comboBoxPlaca_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int _data = comboBoxPlaca.SelectedIndex;
                if (_marcaCam.Count() > 0)
                {
                    txtCamion.Text = _marcaCam[_data].ToString();
                }
                if (_idCam.Count() > 0)
                {
                    _IdCamion = _idCam[_data];
                }
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("####################### = " + err.ToString());
            }
        }
        private void comboBoxSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int _data = comboBoxSucursal.SelectedIndex;
                if (_sucursalId.Count() > 0)
                {
                    _SucElegida = _sucursalId[_data];
                    _destino = _sucursalNombre[_data];
                    int _idSucursalDestino = _SucElegida;
                     
                    TraerNommbreSucursal(_idSucursalDestino);
                }
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("####################### = " + err.ToString());
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
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("################### = " + err.ToString());
            }
        }
        private void checkAbast_CheckedChanged(object sender, EventArgs e)
        {
            if (checkAbast.Checked == false)
            {
                checkVenta.Checked = false;
                _Naturaleza = "TRASPASO";
                txtSucursal.Visible = true;
                comboBoxSucursal.Visible = true;
                btnBuscarSucursal.Visible = true;
                txtCliente.Visible = false;
                comBoxCliente.Visible = false;
                btnCliente.Visible = false;
            }
            else if (checkAbast.Checked == true)
            {
                checkAbast.Checked = false;
                _Naturaleza = "VENTA";
                txtSucursal.Visible = false;
                comboBoxSucursal.Visible = false;
                btnBuscarSucursal.Visible = false;
                txtCliente.Visible = true;
                comBoxCliente.Visible = true;
                btnCliente.Visible = true;
            }
            else
            {
                checkVenta.Checked = false;
                _Naturaleza = "TRASPASO";
                txtSucursal.Visible = true;
                comboBoxSucursal.Visible = true;
                btnBuscarSucursal.Visible = true;
                txtCliente.Visible = false;
                comBoxCliente.Visible = false;
                btnCliente.Visible = false;
            }
        }
        private void checkVenta_CheckedChanged(object sender, EventArgs e)
        {
            if (checkVenta.Checked == false)
            {
                checkAbast.Checked = false;
                _Naturaleza = "VENTA";
                txtSucursal.Visible = false;
                comboBoxSucursal.Visible = false;
                btnBuscarSucursal.Visible = false;
                txtCliente.Visible = true;
                comBoxCliente.Visible = true;
                btnCliente.Visible = true;
            }
            else if (checkVenta.Checked == true)
            {
                checkVenta.Checked = false;
                _Naturaleza = "TRASPASO";
                txtSucursal.Visible = true;
                comboBoxSucursal.Visible = true;
                btnBuscarSucursal.Visible = true;
                txtCliente.Visible = false;
                comBoxCliente.Visible = false;
                btnCliente.Visible = false;
            }
            else
            {
                checkVenta.Checked = false;
                _Naturaleza = "TRASPASO";
                txtSucursal.Visible = true;
                comboBoxSucursal.Visible = true;
                btnBuscarSucursal.Visible = true;
                txtCliente.Visible = false;
                comBoxCliente.Visible = false;
                btnCliente.Visible = false;
            }
        }
        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            int desp = 0;
            int a = 0;
            int b = 0;
            try
            {
                if (!string.IsNullOrWhiteSpace(pickerFecha.Text) || (!string.IsNullOrEmpty(pickerFecha.Text)))
                {
                    if (!string.IsNullOrWhiteSpace(comboBoxChofer.Text) || (!string.IsNullOrEmpty(comboBoxChofer.Text)))
                    {
                        if (!string.IsNullOrWhiteSpace(txtCI.Text) || (!string.IsNullOrEmpty(txtCI.Text)))
                        {
                            if (!string.IsNullOrWhiteSpace(comboBoxSucursal.Text) || (!string.IsNullOrEmpty(comboBoxSucursal.Text)))
                            {
                                if (!string.IsNullOrWhiteSpace(txtCamion.Text) || (!string.IsNullOrEmpty(txtCamion.Text)))
                                {
                                    if (_Naturaleza == "TRASPASO")
                                    {
                                        if (!string.IsNullOrWhiteSpace(comboBoxSucursal.Text) || (!string.IsNullOrEmpty(comboBoxSucursal.Text)))
                                        {
                                            _destino = comboBoxSucursal.Text;
                                        }
                                    }
                                    else if (_Naturaleza == "VENTA")
                                    {
                                        if (!string.IsNullOrWhiteSpace(comBoxCliente.Text) || (!string.IsNullOrEmpty(comBoxCliente.Text)))
                                        {
                                            _destino = comBoxCliente.Text;
                                        }
                                    }
                                    DespachoEditar _despEdit = new DespachoEditar();
                                    CDespacho c_despacho = new CDespacho();

                                    _despEdit.p_DespachoId = txtNroDespacho.Text;
                                    _despEdit.p_Fecha = pickerFecha.DateTime;
                                    _despEdit.p_Id_Camion = _IdCamion;
                                    _despEdit.p_Placa = comboBoxPlaca.Text;
                                    _despEdit.p_Marca = txtCamion.Text;
                                    _despEdit.p_Chofer = comboBoxChofer.Text;
                                    _despEdit.p_CI = txtCI.Text; 
                                    _despEdit.p_Obs = txtObs.Text;
                                    _despEdit.p_SucursalId = idSucursal;  //sucursal actual
                                    _despEdit.p_SucDestino = _SucElegida; // cargar la info del numero de orden
                                    _despEdit.p_Naturaleza = _Naturaleza; 
                                    desp = c_despacho.EditarDespacho(_despEdit);
                                    if (desp == 0)
                                    {
                                        XtraMessageBox.Show("Algo salio mal, intentelo de nuevo");
                                        Program._listaProductos.Clear();
                                        this.Close();
                                    }
                                    else
                                    {
                                        Console.WriteLine("######################## desp = 1 !!!!!!!!!!!!!!!!!!!");
                                    }
                                    //////////////////////////////////////
                                    if (gridView1.DataRowCount > 0)
                                    {
                                        if (Program._listaProductos.Count > _itemsEdit.Count)
                                        {
                                            foreach (var item in Program._listaProductos)
                                            {
                                                if (_itemsEdit.Any(n => n.ItemId == item.ItemId))
                                                {

                                                }
                                                else
                                                {
                                                    DespDetalle _Detdesp = new DespDetalle();
                                                    CDespDetalle c_Detdesp = new CDespDetalle();
                                                    _Detdesp.p_DespachoId = txtNroDespacho.Text;
                                                    _Detdesp.p_ItemId = item.ItemId;
                                                    _Detdesp.p_Cantidad = item.CantidadPzs;
                                                    _Detdesp.p_SolPiezasSueltas = 0;
                                                    _Detdesp.p_ConfPiezasSueltas = 0;
                                                    _Detdesp.p_CantConfirmada = 0;
                                                    _Detdesp.p_Unidad = " ";
                                                    _Detdesp.p_Status = " ";
                                                    _Detdesp.p_SucursalId = idSucursal;
                                                    b = c_Detdesp.AgregarCantDespDetalle(_Detdesp);
                                                    if (b == 0)
                                                    {
                                                        break;
                                                        XtraMessageBox.Show("Algo salio mal, intentelo de nuevo");
                                                        Program._listaProductos.Clear();
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("######################## B = 1 !!!!!!!!!!!!!!!!!!!");
                                                    }
                                                }
                                                if (b == 1)
                                                {
                                                    XtraMessageBox.Show("Productos agregados", "Editar");
                                                    Program._listaProductos.Clear();
                                                    this.Close();
                                                }
                                            }
                                        }
                                        else
                                        {
                                            DespDetalle _despDetalle = new DespDetalle();
                                            CDespDetalle _cdetalleDesp = new CDespDetalle();
                                            for (int i = 0; i < gridView1.DataRowCount; i++)
                                            {
                                                _despDetalle.p_DespachoId = _IdDespacho;
                                                _despDetalle.p_ItemId = gridView1.GetRowCellValue(i, "ItemId").ToString();
                                                _despDetalle.p_Cantidad = Convert.ToInt32(gridView1.GetRowCellValue(i, "CantidadPzs"));
                                                _despDetalle.p_SolPiezasSueltas = 0;
                                                _despDetalle.p_ConfPiezasSueltas = 0;
                                                _despDetalle.p_CantConfirmada = 0;
                                                _despDetalle.p_Unidad = "";
                                                _despDetalle.p_Status = "";
                                                _despDetalle.p_SucursalId = idSucursal;
                                                a = _cdetalleDesp.EditarCantDespDetalle(_despDetalle);
                                                if (a == 0)
                                                {
                                                    break;
                                                }
                                            }
                                            if (a == 1)
                                            {
                                                XtraMessageBox.Show("Cambios realizados", "Editar");
                                            }
                                        }
                                    }
                                    else if(desp == 1)
                                    { 
                                        XtraMessageBox.Show("Despacho editado", "Editar");
                                        Program._listaProductos.Clear();
                                        this.Close();
                                    }
                                }
                                else
                                {
                                    XtraMessageBox.Show("El campo 'Camion' esta vacio", "Error");
                                }
                            }
                            else
                            {
                                XtraMessageBox.Show("El campo 'Sucursal' esta vacio", "Error");
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
                    XtraMessageBox.Show("El campo 'Fecha' esta vacio", "Error");
                }
            }
            catch (Exception err)
            {
                Console.WriteLine("######################## = " + err.ToString());
            }
        }
        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            Program._listaProductos.Clear();
            this.Close();
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
        //Agregar Producto
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            int Sucursal = idSucursal;
            ListaProductosEditar form2 = new ListaProductosEditar(Sucursal);
            form2.Owner = this;
            form2.ShowDialog(this);
        }
        //AgregarChofer
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var myForm = new AgregarChofer();
            myForm.Show();
        }
        //AgregarCamion
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var myForm = new AgregarCamion();
            myForm.Show();
        }
        //BuscarSucursal
        private void btnBuscarSucursal_Click(object sender, EventArgs e)
        {
            _tipoDespacho = _Naturaleza;
            var myForm = new BuscarSucursal(_tipoDespacho);
            myForm.Show();
        }
        //BuscarCliente
        private void btnCliente_Click(object sender, EventArgs e)
        {
            var myForm = new BuscarClienteEditar();
            myForm.Show();
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
    }
}