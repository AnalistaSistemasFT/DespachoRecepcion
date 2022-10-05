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

namespace WFConsumo.frmGRH
{
    public partial class AgregarProductosTrasp : DevExpress.XtraEditors.XtraForm
    {
        int _idSucursal = 0;
        List<GlobalItem> _ListStock = new List<GlobalItem>();
        CPaquetes C_Paquete;
        CTraspaso C_Traspaso;
        CInformix C_Informix;
        int _tipoBusqueda = 1;
        string _idProducto = "0";
        int _Stock = 0;
        int _Cantidad = 0;
        string _Descripcion = string.Empty;
        string _codigoPr;
        string _descPr;
        decimal _Costo;
        string _IdProd = "0";

        public AgregarProductosTrasp(int Sucursal)
        {
            InitializeComponent();
            _idSucursal = Sucursal;
            C_Paquete = new CPaquetes();
            C_Traspaso = new CTraspaso();
            C_Informix = new CInformix();
            TraerData();
            txtCant.KeyDown += EnterKey;
            txtCant.KeyUp += EnterKey;
        }
        public void TraerData()
        {
            try
            {
                DataSet dataLista = C_Paquete.TraerListaStock(_idSucursal);
                foreach (DataRow item in dataLista.Tables[0].Rows)
                {
                    _ListStock.Add(new GlobalItem
                    {
                        ItemId = item[0].ToString(),
                        ItemFerro = item[1].ToString(),
                        Descripcion = item[2].ToString(),
                        StockPzs = Convert.ToInt32(item[3])
                    });
                }
                foreach(var item in _ListStock)
                {
                    //int _idProducto = 0;
                    //DataSet DataListInf = C_Informix.TraerDescProducto(_idProducto);
                    //foreach (DataRow itemInf in DataListInf.Tables[0].Rows)
                    //{ 
                    //    _ListStock.Find(p => p.ItemFerro == itemInf[0].ToString()).Descripcion = itemInf[1].ToString();
                    //}
                } 
                this.gridControl1.DataSource = _ListStock;
            }
            catch(Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("####################### = " + err.ToString());
            } 
        }
        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            try
            {
                ColumnView view = this.gridControl1.MainView as ColumnView;
                int[] row = view.GetSelectedRows();
                view.FocusedRowHandle = row[0];
                _idProducto = (view.GetRowCellDisplayText(row[0], view.Columns[0])).ToString();
                _IdProd = view.GetRowCellDisplayText(row[0], view.Columns[1]);
                _Descripcion = (view.GetRowCellDisplayText(row[0], view.Columns[2])).ToString();
                _Stock = Convert.ToInt32(view.GetRowCellDisplayText(row[0], view.Columns[3]));
                txtCant.Focus();
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("####################### = " + err.ToString());
            }
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (gridControl1.CanSelect)
            {
                if (!string.IsNullOrWhiteSpace(txtCant.Text) || (!string.IsNullOrEmpty(txtCant.Text)))
                {
                    bool isNumber = int.TryParse(txtCant.Text, out int numericValue);
                    if (isNumber == true)
                    {
                        ColumnView view = gridControl1.MainView as ColumnView;
                        int[] row = view.GetSelectedRows();
                        if (row.Length > 0)
                        {
                            view.FocusedRowHandle = row[0];
                        }
                        try
                        {
                            if (_idProducto != "0")
                            {
                                DataSet dataTrasp = C_Traspaso.TraerCosto(_IdProd);
                                foreach (DataRow items in dataTrasp.Tables[0].Rows)
                                {
                                    _Costo = Convert.ToDecimal(items[0]);
                                }
                                (this.Owner as AgregarTraspaso).ProductoElegido(_idProducto, _Descripcion, _Cantidad, _Costo);
                                this.Close();
                            }
                        }
                        catch (Exception err)
                        {
                            XtraMessageBox.Show("Seleccione un despacho de la lista e intentelo de nuevo");
                            Console.WriteLine("################ = " + err.ToString());
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
            else
            {
                XtraMessageBox.Show("Seleccione un producto de la lista", "Error");
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void checkCodigo_CheckedChanged(object sender, EventArgs e)
        {
            if (checkCodigo.Checked == true)
            {
                checkDesc.Checked = false;
                _tipoBusqueda = 1;
            }
            else if (checkCodigo.Checked == false)
            {
                checkDesc.Checked = true;
                _tipoBusqueda = 0;
            }
            else
            {
                checkDesc.Checked = true;
                checkCodigo.Checked = false;
                _tipoBusqueda = 0;
            }
        }
        private void checkDesc_CheckedChanged(object sender, EventArgs e)
        {
            if (checkDesc.Checked == true)
            {
                checkCodigo.Checked = false;
                _tipoBusqueda = 0;
            }
            else if (checkDesc.Checked == false)
            {
                checkCodigo.Checked = true;
                _tipoBusqueda = 1;
            }
            else
            {
                checkDesc.Checked = true;
                checkCodigo.Checked = false;
                _tipoBusqueda = 0;
            }
        }
        private void sb_search_TextChanged(object sender, EventArgs e)
        {
            //buscar por descripcion
            if (_tipoBusqueda == 0)
            {
                _descPr = sb_search.Text;
                gridControl1.DataSource = _ListStock.Where(x => x.Descripcion.ToLower().Contains(_descPr.ToLower()));
            }
            //buscar por Id
            else if (_tipoBusqueda == 1)
            {
                _codigoPr = sb_search.Text;
                gridControl1.DataSource = _ListStock.Where(x => x.ItemId.ToLower().Contains(_codigoPr.ToLower()));
            }
            else
            {
                _tipoBusqueda = 0;
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
                        int _cnt = Convert.ToInt32(txtCant.Text);
                        if(_cnt <= _Stock)
                        {
                            _Cantidad = _cnt;
                        }
                        else
                        {
                            txtCant.Text = _Stock.ToString();
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("La cantidad no puede contener letras", "Error");
                        txtCant.Text = "0";
                    }
                }
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("####################### = " + err.ToString());
            }
        }
        private void AgregarProductos_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (e.CloseReason == CloseReason.UserClosing)
            //{
            //    Application.OpenForms["NuevoTraspaso"].Enabled = true;
            //}
        }
    }
}