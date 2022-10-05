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

namespace WFConsumo.frmGRH.DespachoOrdenAbierta
{
    public partial class ListaProductos : DevExpress.XtraEditors.XtraForm
    {
        CItem C_Item;
        CPaquetes C_Paquete;
        CInformix C_Informix;
        DataTable dataP = new DataTable();
        DataTable dataB = new DataTable();
        DataTable dataItems = new DataTable();
        List<GlobalItem> _ListStock = new List<GlobalItem>();
        List<DescPrdInformix> _prdInfo = new List<DescPrdInformix>();
        string _descPr;
        string _codigoPr;
        string _codigoFePr;
        public string _idProducto = "0";
        public string _itemFerro = "0";
        public int _cantidad = 0;
        string _descripcion = "";
        int _tipoBusqueda = 2;
        int _stock = 0;
        int _piezasPaq = 0;
        decimal _pesoPaq = 0;
        decimal _pesoPaqTotal = 0;
        
        //asignacion manual por pruebas
        int _idSucursal = 0;
        public ListaProductos(int Sucursal)
        {
            InitializeComponent();
            _idSucursal = Sucursal;
            C_Item = new CItem();
            C_Paquete = new CPaquetes();
            C_Informix = new CInformix();
            //_idSucursal = _sucursal.Codigo;
            TraerData();
            txtCant.KeyDown += EnterKey;
            txtCant.KeyUp += EnterKey; 
        }
        public void TraerData()
        {
            DataSet dataLista = C_Paquete.TraerListaStock(_idSucursal);
            foreach (DataRow item in dataLista.Tables[0].Rows)
            {
                _ListStock.Add(new GlobalItem
                {
                    ItemId = item[0].ToString(),
                    ItemFerro = item[1].ToString(),
                    Descripcion = item[2].ToString(),
                    StockPzs = Convert.ToInt32(item[3]),
                    UnidadMedida = item[5].ToString()
                });
            }
            DataSet DataListInf = C_Informix.TraerDescProducto();
            foreach (DataRow itemInf in DataListInf.Tables[0].Rows)
            {
                _prdInfo.Add(new DescPrdInformix
                {
                    p_Id = itemInf[0].ToString(),
                    p_Descripcion = itemInf[1].ToString()
                });
            }
            foreach (var x in _prdInfo)
            {
                var itemToChange = _ListStock.FirstOrDefault(d => d.ItemFerro == x.p_Id);
                if (itemToChange != null)
                    itemToChange.Descripcion = x.p_Descripcion;
            }
            this.gridControl1.DataSource = _ListStock;
        }
        public void sb_search(object sender, EventArgs e)
        {
            //buscar por descripcion
            if (_tipoBusqueda == 0)
            {
                _descPr = searchControl1.Text;
                gridControl1.DataSource = _ListStock.Where(x => x.Descripcion.ToLower().Contains(_descPr.ToLower()));
            }
            //buscar por Id
            else if (_tipoBusqueda == 1)
            {
                _codigoPr = searchControl1.Text;
                gridControl1.DataSource = _ListStock.Where(x => x.ItemId.ToLower().Contains(_codigoPr.ToLower()));
            }
            //buscar por IdFerro
            else if (_tipoBusqueda == 2)
            {
                _codigoFePr = searchControl1.Text;
                gridControl1.DataSource = _ListStock.Where(x => x.ItemFerro.ToLower().Contains(_codigoFePr.ToLower()));
            }
            else
            {
                _tipoBusqueda = 2;
            }
        }
        private void RowCellClickEvent(object sender, EventArgs e)
        {
            try
            {
                txtCant.Text = "1";
                ColumnView view = this.gridControl1.MainView as ColumnView;
                int[] row = view.GetSelectedRows();
                view.FocusedRowHandle = row[0];
                _idProducto = (view.GetRowCellDisplayText(row[0], view.Columns[0])).ToString();
                _itemFerro = (view.GetRowCellDisplayText(row[0], view.Columns[1])).ToString();
                _descripcion = (view.GetRowCellDisplayText(row[0], view.Columns[2])).ToString();
                _stock = Convert.ToInt32(view.GetRowCellDisplayText(row[0], view.Columns[4]));
                txtStock.Text = "1";
                txtStock.Text = _stock.ToString();
                txtStock.Update();

                DataSet dataLista = C_Item.BuscarItems(_idProducto, _idSucursal);
                foreach (DataRow item in dataLista.Tables[0].Rows)
                {
                    if (item[0].ToString() == _idProducto)
                    {
                        _piezasPaq = Convert.ToInt32(item[2]);
                        _pesoPaq = Convert.ToDecimal(item[4]);
                        _pesoPaqTotal = Convert.ToDecimal(item[5]);
                    }
                }
                if(_piezasPaq <= 0)
                {
                    txtPzasPaq.Text = "1";
                }
                else
                {
                    txtPzasPaq.Text = _piezasPaq.ToString();
                }
                txtCant.Text = "1";
                if (!string.IsNullOrWhiteSpace(txtCant.Text) || (!string.IsNullOrEmpty(txtCant.Text)))
                {
                    bool isNumber = int.TryParse(txtCant.Text, out int numericValue);
                    if (isNumber == true)
                    {
                        _codigoPr = _idProducto;
                        TraerDatosLista(_codigoPr);
                    }
                    else
                    {
                        XtraMessageBox.Show("La cantidad no puede contener letras", "Aviso");
                        txtCant.Text = string.Empty;
                    }
                    int _cant = Convert.ToInt32(txtCant.Text);
                    int _stock = Convert.ToInt32(txtStock.Text);
                    if (_cant > _stock)
                    {
                        txtCant.Text = _stock.ToString();
                    }
                }
            }
            catch(Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("################## = " + err.ToString());
            }
        }
        //Traer datos del producto elegido
        private void TraerDatosLista(string _codigoPr)
        {
            try
            {
                DataSet dataLista = C_Item.BuscarItems(_codigoPr, _idSucursal);
                foreach (DataRow item in dataLista.Tables[0].Rows)
                {
                    if (item[0].ToString() == _idProducto)
                    {
                        _piezasPaq = Convert.ToInt32(item[2]);
                        _pesoPaq = Convert.ToDecimal(item[4]);
                    }
                }
                if(_pesoPaq != 0)
                {
                    txtPesoPaq.Text = _pesoPaq.ToString("F3");
                }
                else
                {
                    txtPesoPaq.Text = "1";
                    _pesoPaq = 1;
                }
                if (_piezasPaq != 0)
                {
                    txtPzasPaq.Text = _piezasPaq.ToString();
                }
                else
                {
                    _piezasPaq = 1;
                    txtPzasPaq.Text = "1";
                }
                txtStock.Text = _stock.ToString();
                int PaqComp = Convert.ToInt32(txtCant.Text) / Convert.ToInt32(txtPzasPaq.Text);
                int PaqSuelt = Convert.ToInt32(txtCant.Text) - (PaqComp * _piezasPaq);
                decimal _pesoSuelto = _pesoPaq / _piezasPaq;
                txtPaqsStnd.Text = PaqComp.ToString();
                txtPzasSob.Text = PaqSuelt.ToString();
                txtPesoTot.Text = (_pesoSuelto * Convert.ToDecimal(txtCant.Text)).ToString("F3");

                if (txtPaqsStnd.Text == "-")
                {
                    TraerDatosLista(_codigoPr);
                }
            }
            catch(Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("################## = " + err.ToString());
            }
        }
        private void EnterKey(object sender, KeyEventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtCant.Text) || (!string.IsNullOrEmpty(txtCant.Text)))
                {
                    bool isNumber = int.TryParse(txtCant.Text, out int numericValue);
                    if (isNumber == true)
                    {
                        _codigoPr = _idProducto;
                        TraerDatosLista(_codigoPr);
                    }
                    else
                    {
                        XtraMessageBox.Show("La cantidad no puede contener letras", "Error");
                        txtCant.Text = string.Empty;
                    }
                    int _cant = Convert.ToInt32(txtCant.Text);
                    int _stock = Convert.ToInt32(txtStock.Text);
                    if(_cant > _stock)
                    {
                        txtCant.Text = _stock.ToString();
                        EnterKey(sender, e);
                    }
                }
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("################## = " + err.ToString());
            }
        }
        //btnAceptar
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtCant.Text) || (!string.IsNullOrEmpty(txtCant.Text)))
            {
                bool isNumber = int.TryParse(txtCant.Text, out int numericValue);
                if (isNumber == true)
                {
                    _cantidad = Convert.ToInt32(txtCant.Text);
                    try
                    {
                        int _cantidad = Convert.ToInt32(txtCant.Text);
                        int _PzaxPaq = Convert.ToInt32(txtPzasPaq.Text);
                        int _Paqs = Convert.ToInt32(txtPaqsStnd.Text);
                        int _Pzas = Convert.ToInt32(txtPzasSob.Text);
                        decimal _PesoPaq = Convert.ToDecimal(txtPesoPaq.Text);
                        decimal _PesoPaqTot = Convert.ToDecimal(txtPesoTot.Text);
                        (this.Owner as frmNuevoDespachoMercaderia).ProductoElegido(_idProducto,_itemFerro, _descripcion, _cantidad, _stock, _PzaxPaq, _Paqs, _Pzas, _PesoPaq, _PesoPaqTot);
                        this.Close();
                    }
                    catch (Exception err)
                    {
                        if(err.HResult == -2146233033)
                        {
                            txtCant.Text = "0";
                            XtraMessageBox.Show("Complete los detalles de cantidad", "Error");
                            txtCant.Text = "1";
                        }
                        else
                        {
                            XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                            Console.WriteLine("################## = " + err.ToString());
                        }
                    }
                }
                else
                {
                    XtraMessageBox.Show("La cantidad no puede contener letras", "Error");
                    txtCant.Text = string.Empty;
                }
            }
            else
            {
                XtraMessageBox.Show("El campo de Cantidad esta vacio", "Error");
            }
        }
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ListaProductos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                //Application.OpenForms["frmNuevoDespachoMercaderia"].Enabled = true;
            }
        }
        private void checkCodFerro_CheckedChanged(object sender, EventArgs e)
        {
            if (checkCodFerro.Checked == true)
            {
                checkCodigo.Checked = false;
                checkDesc.Checked = false;
                _tipoBusqueda = 2;
            } 
        }
        private void checkCodigo_CheckedChanged(object sender, EventArgs e)
        {
            if(checkCodigo.Checked == true)
            {
                checkDesc.Checked = false;
                checkCodFerro.Checked = false;
                _tipoBusqueda = 1;
            } 
        }
        private void checkDesc_CheckedChanged(object sender, EventArgs e)
        {
            if(checkDesc.Checked == true)
            {
                checkCodigo.Checked = false;
                checkCodFerro.Checked = false;
                _tipoBusqueda = 0;
            } 
        }  
        //////////////////////////////////////////////////////////
        public class DescPrdInformix
        {
            private string Id;
            private string Descripcion;

            public string p_Id
            {
                get { return Id; }
                set { Id = value; }
            }
            public string p_Descripcion
            {
                get { return Descripcion; }
                set { Descripcion = value; }
            }
        }
    }
}