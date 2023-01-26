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
using CRN.Entidades;
using CRN.Componentes;
using DevExpress.XtraGrid.Views.Base;

namespace WFConsumo.frmGRH.DespachoPorAjuste
{
    public partial class frmNuevoDespachoAjuste : DevExpress.XtraEditors.XtraForm
    {
        CDespacho C_Despacho;
        CMovDespacho C_MovDespacho;
        CPaquetes C_Paquete;
        string sAnotacion = string.Empty;
        int _idSucursal = 0;
        List<string> _listPaqLecturados = new List<string>();
        List<PaqueteLecturado> _paqList = new List<PaqueteLecturado>();
        List<DespProductos> _desProdList = new List<DespProductos>();
        Usuario _user;

        public frmNuevoDespachoAjuste(int sucursalId, Usuario user)
        {
            InitializeComponent();
            _idSucursal = sucursalId;
            C_Despacho = new CDespacho();
            C_MovDespacho = new CMovDespacho();
            C_Paquete = new CPaquetes();
            _user = user;
            TraerData();
            pickerFecha.DateTime = DateTime.Now;
            this.gridControl1.DataSource = _paqList;
        }
        public void TraerData()
        {
            try
            {
                sAnotacion = C_Despacho.TraerSecuencia(_idSucursal, "DESPACHO");
                txtSecuencia.Text = sAnotacion;
            }
            catch(Exception err)
            {
                Console.WriteLine("########################### = " + err.ToString());
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            int IdSucursal = _idSucursal;
            try
            {
                for (int i = 0; i < gridView1.DataRowCount; i++)
                {
                    string ValPaq = gridView1.GetRowCellValue(i, "p_PaqueteId").ToString();

                    if (ValPaq != null && ValPaq != string.Empty)
                    {
                        _listPaqLecturados.Add(ValPaq);
                    }
                }
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("############################################# = " + err.ToString());
            }

            ListaProdLectAjuste form = new ListaProdLectAjuste(IdSucursal, _listPaqLecturados);
            form.Owner = this;
            form.ShowDialog();
            
        }
        public void ProductoElegido(string _idItem, string _itemFerro, string _descripcion, string _paquete, int _piezas, decimal _peso, string _unidad, int _cantidad)
        {
            try
            {
                if (_cantidad > 0)
                {
                    if (Convert.ToInt32(_peso) == _piezas)
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
                            if (_unidad.ToUpper() == "KG")
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
                            else if (_unidad.ToUpper() == "PCS")
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
                                    DespachoId = txtSecuencia.Text.Trim(),
                                    ProductoId = item[0].ToString(),
                                    ItemId = item[1].ToString(),
                                    Fecha = pickerFecha.DateTime,
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
                                    DespachoId = txtSecuencia.Text.Trim(),
                                    ProductoId = item[0].ToString(),
                                    ItemId = item[1].ToString(),
                                    Fecha = pickerFecha.DateTime,
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
                                    DespachoId = txtSecuencia.Text.Trim(),
                                    ProductoId = item[0].ToString(),
                                    ItemId = item[1].ToString(),
                                    Fecha = pickerFecha.DateTime,
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
                string _paqueteId = view.GetRowCellDisplayText(row[0], view.Columns[3]);
                var itemToRemove2 = _paqList.Single(r => r.p_PaqueteId == _paqueteId);
                _paqList.Remove(itemToRemove2);
                gridView1.BeginDataUpdate();
                gridView1.EndDataUpdate();
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("####################### = " + err.ToString());
            }
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                int _ContFilasDataGrid = gridView1.RowCount;
                string _IdDespacho = C_Despacho.TraerSecuencia(_idSucursal, "DESPACHO");
                string sError = string.Empty;
                Despacho _despacho = new Despacho();
                CDespacho c_despacho = new CDespacho();

                _despacho.p_DespachoId = txtSecuencia.Text.Trim();
                _despacho.p_Fecha = pickerFecha.DateTime;
                _despacho.p_NroOrden = "0000";
                _despacho.p_Id_Camion = 4;
                _despacho.p_Placa = "000-XXX";
                _despacho.p_Marca = "S-N";
                _despacho.p_Chofer = "S-N";
                _despacho.p_CI = "00000";
                _despacho.p_Destino = "AJUSTE";
                _despacho.p_Login = _user.Login;
                _despacho.p_status = "CLOSE";
                _despacho.p_Correlativo = 0;
                _despacho.p_Obs = txtComentarios.Text;
                _despacho.p_Tipo = "CONTINUO";
                _despacho.p_Cargador = "S-N";
                _despacho.p_NumTraspaso = "0000";
                _despacho.p_SucursalId = _idSucursal;
                _despacho.p_SucDestino = 0; 
                _despacho.p_HorarioPartida = DateTime.Now;
                _despacho.p_HorarioLlegada = DateTime.Now;
                _despacho.p_Naturaleza = "AJUSTE";
                _despacho.p_Anticipado = 0;
                _despacho.p_Entregado = 1;
                //////dtsDETALLE
                DataTable dtsDetalle = new DataTable();
                dtsDetalle.Columns.Add("p_DespachoId");
                dtsDetalle.Columns.Add("p_ItemId");
                dtsDetalle.Columns.Add("p_Cantidad");
                dtsDetalle.Columns.Add("p_SolPiezasSueltas");
                dtsDetalle.Columns.Add("p_ConfPiezasSueltas");
                dtsDetalle.Columns.Add("p_CantConfirmada");
                dtsDetalle.Columns.Add("p_Unidad");
                dtsDetalle.Columns.Add("p_Status");
                dtsDetalle.Columns.Add("p_SucursalId");
                DataRow dr = null;

                foreach (var item in _paqList)
                {
                    dr = dtsDetalle.NewRow(); // have new row on each iteration
                    dr["p_DespachoId"] = txtSecuencia.Text.Trim();
                    dr["p_ItemId"] = item.p_ItemId;
                    dr["p_Cantidad"] = item.p_Piezas;
                    dr["p_SolPiezasSueltas"] = 0;
                    dr["p_ConfPiezasSueltas"] = 0;
                    dr["p_CantConfirmada"] = 0;
                    dr["p_Unidad"] = "";
                    dr["p_Status"] = "";
                    dr["p_SucursalId"] = _idSucursal;
                    dtsDetalle.Rows.Add(dr);
                }
                //////dtsDESPPRODUCTOS
                DataTable dtsDespProductos = new DataTable();
                dtsDespProductos.Columns.Add("DespachoId");
                dtsDespProductos.Columns.Add("ProductoId");
                dtsDespProductos.Columns.Add("ItemId");
                dtsDespProductos.Columns.Add("Fecha");
                dtsDespProductos.Columns.Add("Status");
                dtsDespProductos.Columns.Add("Cantidad");
                dtsDespProductos.Columns.Add("Peso");
                dtsDespProductos.Columns.Add("CeldaId");
                dtsDespProductos.Columns.Add("SucursalId");
                dtsDespProductos.Columns.Add("ItemFId");
                dtsDespProductos.Columns.Add("Piezas");
                dtsDespProductos.Columns.Add("Metros");
                dtsDespProductos.Columns.Add("Colada");
                DataRow drprd = null;

                foreach (var item in _desProdList)
                {
                    drprd = dtsDespProductos.NewRow(); // have new row on each iteration
                    drprd["DespachoId"] = txtSecuencia.Text.Trim();
                    drprd["ProductoId"] = item.ProductoId;
                    drprd["ItemId"] = item.ItemId;
                    drprd["Fecha"] = DateTime.Now;
                    drprd["Status"] = item.Status;
                    drprd["Cantidad"] = item.Cantidad;
                    drprd["Peso"] = item.Peso;
                    drprd["CeldaId"] = item.CeldaId;
                    drprd["SucursalId"] = _idSucursal;
                    drprd["ItemFId"] = item.ItemFId;
                    drprd["Piezas"] = item.Piezas;
                    drprd["Metros"] = item.Metros;
                    drprd["Colada"] = item.Colada;
                    dtsDespProductos.Rows.Add(drprd);
                }
                string DespachoId = txtSecuencia.Text.Trim();
                int _idDestino = 0;
                int a = C_MovDespacho.DespachoPorAjuste(_despacho, dtsDetalle, dtsDespProductos, _idSucursal, DespachoId, _idDestino);
                if(a > 0)
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
            catch(Exception err)
            {
                Console.WriteLine("################## = " + err.ToString());
            }
        }
    }
}