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

namespace WFConsumo.frmGRH.DespachoPorAjuste
{
    public partial class ListaProdLectAjuste : DevExpress.XtraEditors.XtraForm
    {
        CPaquetes C_Paquete;
        List<PaqueteLecturado> _listPaq = new List<PaqueteLecturado>();
        List<string> _listPaqLecturado = new List<string>();
        List<DespProductos> _desProdList = new List<DespProductos>();
        int _idSucursal = 0;
        int _tipoBusqueda = 0;
        string _busq = string.Empty;

        public ListaProdLectAjuste(int idSucursal, List<string> _listPaqLecturados)
        {
            InitializeComponent();
            _idSucursal = idSucursal;
            C_Paquete = new CPaquetes();
            TraerData(_listPaqLecturados);
        }

        public void TraerData(List<string> _listPaqLecturados)
        {
            try
            {
                if (_listPaqLecturados.Count > 0)
                {
                    foreach (var item in _listPaqLecturados)
                    {
                        _listPaqLecturado.Add(item);
                    }
                }
                DataSet dataLista = C_Paquete.TraerPaqueteLecturadoPorSucursal(_idSucursal);
                foreach (DataRow item in dataLista.Tables[0].Rows)
                {
                    _listPaq.Add(new PaqueteLecturado
                    {
                        p_ItemId = item[0].ToString(),
                        p_ItemFerro = item[1].ToString(),
                        p_Descripcion = item[2].ToString(),
                        p_PaqueteId = item[3].ToString(),
                        p_Piezas = Convert.ToInt32(item[4]),
                        p_Peso = Convert.ToDecimal(item[5]),
                        p_Unidad = item[6].ToString(),
                        p_Retirar = Convert.ToInt32(item[7]),
                        p_Fecha = Convert.ToDateTime(item[8])
                    });
                }
                gridControl1.DataSource = _listPaq;
            }
            catch(Exception err)
            {
                Console.WriteLine("################### = " + err.ToString());
            }
        }
        private void checkCodigoFerro_CheckedChanged(object sender, EventArgs e)
        {
            if (checkCodigoFerro.Checked == true)
            {
                checkCodigo.Checked = false;
                checkPaquete.Checked = false;
                _tipoBusqueda = 1;
            }
        }
        private void checkCodigo_CheckedChanged(object sender, EventArgs e)
        {
            if (checkCodigo.Checked == true)
            {
                checkCodigoFerro.Checked = false;
                checkPaquete.Checked = false;
                _tipoBusqueda = 0;
            }
        }
        private void checkPaquete_CheckedChanged(object sender, EventArgs e)
        {
            if (checkPaquete.Checked == true)
            {
                checkCodigo.Checked = false;
                checkCodigoFerro.Checked = false;
                _tipoBusqueda = 2;
            }
        }
        private void searchControl1_TextChanged(object sender, EventArgs e)
        {
            if (_tipoBusqueda == 0)
            {
                _busq = searchControl1.Text;
                gridControl1.DataSource = _listPaq.Where(x => x.p_ItemId.ToLower().Contains(_busq.ToLower()));
            }
            else if (_tipoBusqueda == 1)
            {
                _busq = searchControl1.Text;
                gridControl1.DataSource = _listPaq.Where(x => x.p_ItemFerro.ToLower().Contains(_busq.ToLower()));
            }
            else if (_tipoBusqueda == 2)
            {
                _busq = searchControl1.Text;
                gridControl1.DataSource = _listPaq.Where(x => x.p_PaqueteId.ToLower().Contains(_busq.ToLower()));
            }
            else
            {
                _busq = searchControl1.Text;
                gridControl1.DataSource = _listPaq.Where(x => x.p_ItemFerro.ToLower().Contains(_busq.ToLower()));
            }
        }
        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                int _valData = e.RowHandle;
                ColumnView view = gridControl1.MainView as ColumnView;

                string _itmId = view.GetRowCellDisplayText(_valData, view.Columns[0]);
                string _paqtId = view.GetRowCellDisplayText(_valData, view.Columns[3]);
                int _piezas = Convert.ToInt32(view.GetRowCellDisplayText(_valData, view.Columns[5]));
                int _cantN = Convert.ToInt32(view.GetRowCellDisplayText(_valData, view.Columns[7]));
                //_desProdList.Find(p => p.ItemId == _itmId && p.ProductoId == _paqtId).Cantidad = _cantN;
                if (_cantN > _piezas)
                {
                    view.SetRowCellValue(_valData, view.Columns[7], _piezas);
                }
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("####################### = " + err.ToString());
            }
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (gridControl1.CanSelect)
            {
                ColumnView view = gridControl1.MainView as ColumnView;
                int[] row = view.GetSelectedRows();
                if (row.Length > 0)
                {
                    try
                    {
                        for (int i = 0; i < row.Length; i++)
                        {
                            string _idItem = string.Empty;
                            string _itemFerro = string.Empty;
                            string _descripcion = string.Empty;
                            string _paquete = string.Empty;
                            int _piezas = 0;
                            decimal _peso = 0;
                            string _unidad = string.Empty;
                            int _cantidad = 0;

                            _idItem = view.GetRowCellDisplayText(row[i], view.Columns[0]);
                            _itemFerro = view.GetRowCellDisplayText(row[i], view.Columns[1]);
                            _descripcion = view.GetRowCellDisplayText(row[i], view.Columns[2]);
                            _paquete = view.GetRowCellDisplayText(row[i], view.Columns[3]);
                            _unidad = view.GetRowCellDisplayText(row[i], view.Columns[4]);
                            _piezas = Convert.ToInt32(view.GetRowCellDisplayText(row[i], view.Columns[5]));
                            _peso = Convert.ToDecimal(view.GetRowCellDisplayText(row[i], view.Columns[6]));
                            _cantidad = Convert.ToInt32(view.GetRowCellDisplayText(row[i], view.Columns[7]));

                            if (_piezas != _cantidad)
                            {
                                decimal _pesoUnit = _peso / _piezas;
                                _peso = _pesoUnit * _cantidad;
                            }

                            if (_idItem != string.Empty)
                            {
                                (this.Owner as frmNuevoDespachoAjuste).ProductoElegido(_idItem, _itemFerro, _descripcion, _paquete, _piezas, _peso, _unidad, _cantidad);
                            }
                        }
                        this.Close();
                    }
                    catch (Exception err)
                    {
                        XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                        Console.WriteLine("####################### = " + err.ToString());
                    }
                }
            }
        }
    }
}