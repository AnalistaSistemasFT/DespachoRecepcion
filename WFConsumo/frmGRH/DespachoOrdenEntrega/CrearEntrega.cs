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
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace WFConsumo.frmGRH.DespachoOrdenEntrega
{ 
    public partial class CrearEntrega : DevExpress.XtraEditors.XtraForm
    {
        string _idDespacho = string.Empty;
        int _idSuc = 0;
        int _idDestino = 0;
        decimal pesoTotal = 0;
        decimal pesoCarga = 0;
        string _Login = string.Empty;
        CDespacho C_Despacho;
        CCatChofer C_Chofer;
        CPaquetes C_Paquete;
        DataTable dataDet = new DataTable();
        List<string> _choferNom = new List<string>();
        List<int> _idCam = new List<int>();
        List<decimal> _capacidadCam = new List<decimal>();
        List<ItemEntrega> _listEntrega = new List<ItemEntrega>();

        public CrearEntrega(string IdDespacho, int _idSucursal, string Placa, string Chofer, List<ItemEntrega> itemEntregas, decimal _pesoTotal, string _login)
        {
            InitializeComponent();
            _idDespacho = IdDespacho;
            _idSuc = _idSucursal;
            txtSuc.Text = _idSucursal.ToString();
            txtDespacho.Text = IdDespacho;
            pickerFecha.DateTime = DateTime.Now;
            cmboxCamion.SelectedIndex = 0;
            comboxChofer.Text = Chofer;
            C_Despacho = new CDespacho();
            C_Chofer = new CCatChofer();
            C_Paquete = new CPaquetes();
            //TraerData();
            TraerDataChofer();
            TraerDataCamion();
            RecibirItems(itemEntregas);
            cmboxCamion.Text = Placa;
            pesoTotal = _pesoTotal;
            _Login = _login;
        }

        public class ProductosEnvio
        {
            public string e_Paquete;
            public int e_Cantidad;
            public decimal e_peso;
        }
        List<ProductosEnvio> _listEnvios = new List<ProductosEnvio>();
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
                Console.WriteLine("######################## = " + err.ToString());
            }
        }
        public void TraerData()
        {
            try
            {
                if (_idDespacho != "0")
                {
                    DataSet dataLista = C_Paquete.BuscarPaqueteEntrega(_idDespacho);
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
                            p_Retirar = Convert.ToInt32(item[5]),
                            p_PesoRetirar = 0
                        });
                    }
                    this.gridControl1.DataSource = _listEntrega;

                }
            }
            catch (Exception err)
            {
                Console.WriteLine("#################### = " + err.ToString());
            }
        }
        public void RecibirItems(List<ItemEntrega> _itemEntregas)
        {
            try
            {
                foreach (var item in _itemEntregas)
                {
                    _listEntrega.Add(new ItemEntrega
                    {
                        p_ItemId = item.p_ItemId,
                        p_ItemFId = item.p_ItemFId,
                        p_Descripcion = item.p_Descripcion,
                        p_PaqueteId = item.p_PaqueteId,
                        p_UnidadMedida = item.p_UnidadMedida,
                        p_Piezas = item.p_Piezas,
                        p_Peso = item.p_Peso,
                        p_PesoTotal = item.p_PesoTotal,
                        p_Pendiente = item.p_Pendiente,
                        p_Retirar = 0,
                        p_NombreDisplay = item.p_NombreDisplay
                    });
                }
                gridControl1.DataSource = _listEntrega;
                this.gridControl1.Refresh();
            }
            catch (Exception err)
            {
                Console.WriteLine("#################### = " + err.ToString());
            }
        }
        public void TraerDataChofer()
        {
            try
            {
                DataSet dataLista = C_Chofer.TraerChoferes();
                foreach (DataRow Row in dataLista.Tables[0].Rows)
                {
                    comboxChofer.Properties.Items.Add(Row[0]);
                    _choferNom.Add(Row[1].ToString());
                }
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("################### = " + err.ToString());
            }
        }
        public void TraerDataCamion()
        {
            try
            {
                DataSet dataLista = C_Chofer.TraerPlacas();
                foreach (DataRow Row in dataLista.Tables[0].Rows)
                {
                    cmboxCamion.Properties.Items.Add(Row[1]);
                    _idCam.Add(Convert.ToInt32(Row[0]));
                    _capacidadCam.Add(Convert.ToDecimal(Row[3] is DBNull ? 0 : Row[3]));
                }
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("################### = " + err.ToString());
            }
        }
        private void cmboxCamion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int _data = cmboxCamion.SelectedIndex;
                if (_choferNom.Count() > 0)
                {
                    txtCapKg.Text = _capacidadCam[_data].ToString();
                }
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("################### = " + err.ToString());
            }
        }
        private void txtCapKg_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                decimal peso_camion = Convert.ToDecimal(txtCapKg.Text);
                decimal peso_carga = Convert.ToDecimal(txtKgSegNota.Text);
                txtDif.Text = (peso_camion - peso_carga).ToString();
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("################### = " + err.ToString());
            }
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int _cantidadTotal = 0;
            decimal _pesoTotal = 0;
            string _tipoEnt = string.Empty;
            try
            {
                if (!string.IsNullOrWhiteSpace(txtDespacho.Text) || (!string.IsNullOrEmpty(txtDespacho.Text)))
                {
                    if (!string.IsNullOrWhiteSpace(pickerFecha.Text) || (!string.IsNullOrEmpty(pickerFecha.Text)))
                    {
                        if (!string.IsNullOrWhiteSpace(txtSuc.Text) || (!string.IsNullOrEmpty(txtSuc.Text)))
                        {
                            if (!string.IsNullOrWhiteSpace(cmboxCamion.Text) || (!string.IsNullOrEmpty(cmboxCamion.Text)))
                            {
                                if (!string.IsNullOrWhiteSpace(comboxChofer.Text) || (!string.IsNullOrEmpty(comboxChofer.Text)))
                                {
                                    if (checkEntrTodo.Checked == true)
                                    {
                                        _tipoEnt = "Completo";
                                    }
                                    else
                                    {
                                        _tipoEnt = "Parcial";
                                    }
                                    //
                                    string sError = string.Empty;
                                    ColumnView view = gridControl1.MainView as ColumnView;
                                    GridColumn colCantidad = view.Columns[5];
                                    GridColumn colPeso = view.Columns[8];
                                    int[] selectedRowHandles = view.GetSelectedRows();
                                    if (selectedRowHandles.Length > 0)
                                    {
                                        int _cantSum = 0;
                                        decimal _pesoSum = 0;
                                        // Move focus to the first selected row.
                                        view.FocusedRowHandle = selectedRowHandles[0];
                                        for (int i = 0; i < selectedRowHandles.Length; i++)
                                        {
                                            _cantSum = _cantSum + Convert.ToInt32(view.GetRowCellDisplayText(selectedRowHandles[i], colCantidad));
                                            _pesoSum = _pesoSum + Convert.ToDecimal(view.GetRowCellDisplayText(selectedRowHandles[i], colPeso));
                                        }
                                        _cantidadTotal = _cantSum;
                                        _pesoTotal = _pesoSum;
                                    }

                                    if (selectedRowHandles.Length > 0)
                                    {
                                        OrdenEntrega _ordenEnt = new OrdenEntrega();
                                        COrdenEntrega C_OrdenEnt = new COrdenEntrega();

                                        _ordenEnt.p_DespachoId = _idDespacho;
                                        _ordenEnt.p_Fecha_salida = pickerFecha.DateTime.Date;
                                        _ordenEnt.p_Fecha_llegada = pickerFecha.DateTime.Date.AddDays(2);
                                        _ordenEnt.p_Chofer = comboxChofer.Text;
                                        _ordenEnt.p_Placa = cmboxCamion.Text;
                                        _ordenEnt.p_Origen_Id = Convert.ToInt32(txtSuc.Text);
                                        _ordenEnt.p_Destino_Id = _idDestino;
                                        _ordenEnt.p_Login = _Login;
                                        _ordenEnt.p_Cantidad_total = _cantidadTotal;
                                        _ordenEnt.p_Peso_total = _pesoTotal;
                                        _ordenEnt.p_Estado = "Enviado"; //Enviado - Recibido
                                        _ordenEnt.p_Tipo_entrega = _tipoEnt;  //Completa - parcial
                                        _ordenEnt.p_Obs = txtObs.Text;
                                        //
                                        DataTable dt = new DataTable();
                                        dt.Columns.Add("Despachoid");
                                        dt.Columns.Add("Paqueteid");
                                        dt.Columns.Add("ItemId");
                                        dt.Columns.Add("ItemFId");
                                        dt.Columns.Add("Cantidad");
                                        dt.Columns.Add("Peso");
                                        dt.Columns.Add("Estado");
                                        dt.Columns.Add("Obs");
                                        DataRow dr = null;
                                        /////////////////////////////////
                                        GridColumn colPaquete = view.Columns[0];
                                        GridColumn colCodigo = view.Columns[1];
                                        GridColumn colCodigoFerro = view.Columns[2];
                                        GridColumn colCantCarg = view.Columns[7];
                                        GridColumn colPesoE = view.Columns[6];
                                        GridColumn colPend = view.Columns[8];
                                        string _estado = string.Empty;
                                        view.FocusedRowHandle = selectedRowHandles[0];
                                        for (int i = 0; i < selectedRowHandles.Length; i++)
                                        {
                                            dr = dt.NewRow(); // have new row on each iteration 
                                            dr["Despachoid"] = _idDespacho;
                                            dr["Paqueteid"] = view.GetRowCellDisplayText(selectedRowHandles[i], colPaquete);
                                            dr["ItemId"] = view.GetRowCellDisplayText(selectedRowHandles[i], colCodigo);
                                            dr["ItemFId"] = Convert.ToInt32(view.GetRowCellDisplayText(selectedRowHandles[i], colCodigoFerro));
                                            dr["Cantidad"] = Convert.ToInt32(view.GetRowCellDisplayText(selectedRowHandles[i], colCantCarg));
                                            dr["Peso"] = Convert.ToDecimal(view.GetRowCellDisplayText(selectedRowHandles[i], colPeso));
                                            if (Convert.ToInt32(view.GetRowCellDisplayText(selectedRowHandles[i], colCantCarg)) == Convert.ToInt32(view.GetRowCellDisplayText(selectedRowHandles[i], colPend)))
                                            {
                                                _estado = "Completa";
                                            }
                                            else
                                            {
                                                _estado = "Parcial";
                                            }
                                            dr["Estado"] = _estado;
                                            dr["Obs"] = "Carga " + _estado + " con " + view.GetRowCellDisplayText(selectedRowHandles[i], colCantCarg) + " de " + view.GetRowCellDisplayText(selectedRowHandles[i], colPend) + " pendientes.";
                                            dt.Rows.Add(dr);

                                        }
                                        if (C_OrdenEnt.InsertarOrdenEntrega(out sError, _ordenEnt, dt, _idSuc, _idDespacho) > 0)
                                        {
                                            XtraMessageBox.Show("Orden insertada", "Guardar");
                                            this.Close();
                                        }
                                        else
                                        {
                                            XtraMessageBox.Show("Problemas al insertar la orden", "Guardar");
                                            this.Close();
                                        }
                                    }
                                    //
                                }
                                else
                                {
                                    XtraMessageBox.Show("El campo 'Chofer' esta vacio", "Error");
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
                        XtraMessageBox.Show("El campo 'Fecha' esta vacio", "Error");
                    }
                }
                else
                {
                    XtraMessageBox.Show("Error al cargar la informacion", "Error");
                    this.Close();
                }
            }
            catch (Exception err)
            {
                //XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("################## = " + err.ToString());
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnAddCamion_Click(object sender, EventArgs e)
        {
            var myForm = new AgregarCamion();
            //this.Enabled = false;
            myForm.Show();
        }
        private void btnAddChofer_Click(object sender, EventArgs e)
        {
            var myForm = new AgregarChofer();
            //this.Enabled = false;
            myForm.Show();
        }
        private void checkEntrTodo_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEntrTodo.Checked == true)
            {
                gridView1.SelectAll();
                txtKgSegNota.Text = pesoTotal.ToString();
            }
            else if (checkEntrTodo.Checked == false)
            {
                gridView1.ClearSelection();
                txtKgSegNota.Text = "0";
            }
            else
            {
                gridView1.ClearSelection();
                txtKgSegNota.Text = "0";
            }
        }
        private void txtKgSegNota_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                decimal peso_camion = Convert.ToDecimal(txtCapKg.Text);
                decimal peso_carga = Convert.ToDecimal(txtKgSegNota.Text);
                txtDif.Text = (peso_camion - peso_carga).ToString();
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("################### = " + err.ToString());
            }
        }
        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                int _cantidadRetirar = Convert.ToInt32(e.Value);
                decimal _pesoRow = 0;
                decimal _pesoFinal = 0;
                ColumnView view = gridControl1.MainView as ColumnView;
                int[] row = view.GetSelectedRows();
                if (row.Length > 0)
                {
                    view.FocusedRowHandle = row[0];
                }
                string _paquete = view.GetRowCellDisplayText(row[0], view.Columns[2]);
                int _piezas = Convert.ToInt32(view.GetRowCellDisplayText(row[0], view.Columns[5]));
                int pendient = Convert.ToInt32(view.GetRowCellDisplayText(row[0], view.Columns[8]));
                if (_cantidadRetirar > pendient)
                {
                    view.SetFocusedRowCellValue(view.Columns[7], 0);
                }
                _pesoRow = Convert.ToDecimal(view.GetRowCellDisplayText(row[0], view.Columns[6]));
                _pesoFinal = _pesoRow * _cantidadRetirar;
                string PesoCell = _pesoFinal.ToString("F3");
                //_listEntrega.Find(p => p.p_PaqueteId == _paquete && p.p_Piezas == _piezas).p_Retirar = _pesoFinal;

                gridControl1.Refresh();

                if (!_listEnvios.Any(n => n.e_Paquete == _paquete))
                {
                    _listEnvios.Add(new ProductosEnvio
                    {
                        e_Paquete = _paquete,
                        e_Cantidad = _cantidadRetirar,
                        e_peso = _pesoFinal
                    });
                }
                else
                {
                    _listEnvios.Where(c => c.e_Paquete == _paquete).Select(c => { c.e_Cantidad = _cantidadRetirar; c.e_peso = _pesoFinal; return c; }).ToList();
                }
                pesoCarga = 0;
                foreach (var item in _listEnvios)
                {
                    pesoCarga = pesoCarga + item.e_peso;
                }
                txtKgSegNota.Text = pesoCarga.ToString();
            }
            catch (Exception err)
            {
                Console.WriteLine("#################### = " + err.ToString());
            }
        }
        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            ColumnView view = gridControl1.MainView as ColumnView;
            int[] row = view.GetSelectedRows();
            if (row.Length > 0)
            {
                try
                {
                    _listEnvios.Clear();
                    for (int i = 0; i < row.Length; i++)
                    {
                        string _paquete = string.Empty;
                        int _piezas = 0;
                        decimal _peso = 0;

                        _paquete = view.GetRowCellDisplayText(row[i], view.Columns[2]);
                        _piezas = Convert.ToInt32(view.GetRowCellDisplayText(row[i], view.Columns[5]));
                        _peso = Convert.ToDecimal(view.GetRowCellDisplayText(row[i], view.Columns[6]));

                        if (!_listEnvios.Any(n => n.e_Paquete == _paquete))
                        {

                            _listEnvios.Add(new ProductosEnvio
                            {
                                e_Paquete = _paquete,
                                e_Cantidad = _piezas,
                                e_peso = _peso
                            });
                        }
                        else
                        {
                            _listEnvios.Where(c => c.e_Paquete == _paquete).Select(c => { c.e_Cantidad = _piezas; c.e_peso = _peso; return c; }).ToList();
                        }
                    }
                    pesoCarga = 0;
                    foreach (var item in _listEnvios)
                    {
                        pesoCarga = pesoCarga + item.e_peso;
                    }
                    if (_listEnvios.Count > 0)
                    {
                        txtKgSegNota.Text = pesoCarga.ToString();
                    }
                    else
                    {
                        txtKgSegNota.Text = "0";
                    }
                }
                catch (Exception err)
                {
                    XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                    Console.WriteLine("####################### = " + err.ToString());
                }
            }
        }
        /////////////////////////////////////////
        public class ItemEntregaParcial
        {
            private string Paquete;
            private int ItemFId;
            private string ItemId;
            private int PiezasFinal;
            private decimal PesoFinal;

            public string p_Paquete
            {
                get { return Paquete; }
                set { Paquete = value; }
            }
            public int p_ItemFId
            {
                get { return ItemFId; }
                set { ItemFId = value; }
            }
            public string p_ItemId
            {
                get { return ItemId; }
                set { ItemId = value; }
            }
            public int p_PiezasFinal
            {
                get { return PiezasFinal; }
                set { PiezasFinal = value; }
            }
            public decimal p_PesoFinal
            {
                get { return PesoFinal; }
                set { PesoFinal = value; }
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            int rowH = gridView1.FocusedRowHandle;
            int rowHandle = gridView1.GetVisibleRowHandle(rowH);
            gridView1.SelectRow(rowHandle);
        }
        private void gridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                if (view == null) return;

                for (int i = 0; i < gridView1.DataRowCount; i++)
                {
                    string pend = view.GetRowCellValue(e.RowHandle, "p_Pendiente").ToString();
                    if (e.Column.FieldName == "p_Pendiente")
                    {
                        if (pend.ToUpper() == "0")
                        {
                            e.Appearance.BackColor = Color.Gray;
                            e.Appearance.ForeColor = Color.White;
                        }
                    }
                }
            }
            catch (Exception err)
            {
                Console.WriteLine("################ = " + err.ToString());
            }
        }
        private void gridView1_ShowingEditor(object sender, CancelEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                string cellValue = View.GetRowCellValue(View.FocusedRowHandle, "p_Pendiente").ToString();
                if (cellValue == "0")
                    e.Cancel = true;
            }
            catch (Exception err)
            {
                Console.WriteLine("################ = " + err.ToString());
            }
        }
        private void btnEditarCamion_Click(object sender, EventArgs e)
        {
            try
            {
                string placaCamion = cmboxCamion.Text;
                decimal CantPeso = 0;
                XtraInputBoxArgs args = new XtraInputBoxArgs();
                args.Editor.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
                args.Caption = "Capacidad de carga";
                args.Prompt = "Agregar la capacidad de carga del camión:  ";
                args.DefaultButtonIndex = 0;
                MemoEdit editor = new MemoEdit();
                args.Editor = editor;
                args.DefaultResponse = "0";
                object result = XtraInputBox.Show(args);

                if (result != null)
                {
                    CantPeso = Convert.ToDecimal(result);
                    if (placaCamion != string.Empty)
                    {
                        int _editCapacidad = C_Chofer.EditarCapacidad(placaCamion, CantPeso);
                        if (_editCapacidad > 0)
                        {
                            XtraMessageBox.Show("Capacidad de carga modificada", "Editar");
                            txtCapKg.Text = CantPeso.ToString();
                        }
                    }
                    else
                    {

                    }
                }
                else
                {
                    Console.WriteLine("################## = result es null");
                }
            }
            catch (Exception err)
            {
                Console.WriteLine("################## = " + err.ToString());
            }
        }
    }
}