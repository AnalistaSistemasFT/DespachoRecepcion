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
using DevExpress.XtraGrid.Views.Base;
using CRN.Entidades;
using CRN.Componentes;
using System.Collections;

namespace WFConsumo.frmGRH.DespachoOrdenAbierta
{
    public partial class ListaProductosLecturadoA : DevExpress.XtraEditors.XtraForm
    {
        List<PaqueteLecturado> _listPaq = new List<PaqueteLecturado>();
        List<string> _listPaqLecturado = new List<string>();
        List<DespProductos> _desProdList = new List<DespProductos>();
        CPaquetes C_Paquete;
        CInformix C_Informix;
        int _idSucursal = 0;
        string _busq = string.Empty;
        string _idDespacho = string.Empty;
        string _ItemId = string.Empty;
        int _tipoBusqueda = 2;

        public ListaProductosLecturadoA(int IdSucursal, string _IdDespacho, List<string> _listPaqLecturados)
        {
            InitializeComponent();
            _idSucursal = IdSucursal;
            _idDespacho = _IdDespacho;
            C_Paquete = new CPaquetes();
            C_Informix = new CInformix();
            _desProdList = new List<DespProductos>();
            TraerData(_listPaqLecturados);
            this.gridControl1.DataSource = _listPaq;
        }
        private void TraerData(List<string> _listPaqLecturados)
        {
            try
            {
                //int _contCel = 0;
                //int _contSob = 0;
                //DataSet dataProgCel = C_Paquete.TraerContPaquetesProgCelda(_idDespacho);
                //foreach (DataRow item in dataProgCel.Tables[0].Rows)
                //{
                //    _contCel = Convert.ToInt32(item[0]);
                //}
                //DataSet dataProgSob = C_Paquete.TraerContPaquetesProgSob(_idDespacho);
                //foreach (DataRow item in dataProgSob.Tables[0].Rows)
                //{
                //    _contSob = Convert.ToInt32(item[0]);
                //}
                //if (_contCel > 0 || _contSob > 0)
                //{ 
                //    if (_contCel > 0)
                //    {
                //        DataSet dataProgCelLect = C_Paquete.TraerPaqProgCeldaLect(_idDespacho);
                //        foreach (DataRow itempaq in dataProgCelLect.Tables[0].Rows)
                //        {
                //            DataSet dataLista = C_Paquete.TraerPaqProgramados(itempaq[0].ToString());
                //            foreach (DataRow item in dataLista.Tables[0].Rows)
                //            {
                //                if (_listPaqLecturado.Contains(item[3].ToString()))
                //                {
                //                    //Console.WriteLine("################################ = " + item[3].ToString());
                //                }
                //                else
                //                {
                //                    if (!_listPaq.Any(n => n.p_PaqueteId == item[3].ToString()))
                //                    {
                //                        _listPaq.Add(new PaqueteLecturado
                //                        {
                //                            p_ItemId = item[0].ToString(),
                //                            p_ItemFerro = item[1].ToString(),
                //                            p_Descripcion = item[2].ToString(),
                //                            p_PaqueteId = item[3].ToString(),
                //                            p_Piezas = Convert.ToInt32(item[4]),
                //                            p_Peso = Convert.ToDecimal(item[5]),
                //                            p_Unidad = item[6].ToString(),
                //                            p_Retirar = Convert.ToInt32(item[7]),
                //                            p_Fecha = Convert.ToDateTime(item[8])
                //                        });
                //                    }
                //                }
                //            }
                //        }
                //    }
                //    if (_contSob > 0)
                //    {
                //        DataSet dataProgSobLect = C_Paquete.TraerPaqProgSobLect(_idDespacho);
                //        foreach (DataRow itemsob in dataProgSobLect.Tables[0].Rows)
                //        {
                //            DataSet dataLista = C_Paquete.TraerPaqProgramados(itemsob[0].ToString());
                //            foreach (DataRow item in dataLista.Tables[0].Rows)
                //            {
                //                if (_listPaqLecturado.Contains(item[3].ToString()))
                //                {
                //                    //Console.WriteLine("################################ = " + item[3].ToString());
                //                }
                //                else
                //                {
                //                    if (!_listPaq.Any(n => n.p_PaqueteId == item[3].ToString()))
                //                    {
                //                        _listPaq.Add(new PaqueteLecturado
                //                        {
                //                            p_ItemId = item[0].ToString(),
                //                            p_ItemFerro = item[1].ToString(),
                //                            p_Descripcion = item[2].ToString(),
                //                            p_PaqueteId = item[3].ToString(),
                //                            p_Piezas = Convert.ToInt32(item[4]),
                //                            p_Peso = Convert.ToDecimal(item[5]),
                //                            p_Unidad = item[6].ToString(),
                //                            p_Retirar = Convert.ToInt32(item[7]),
                //                            p_Fecha = Convert.ToDateTime(item[8])
                //                        });
                //                    }
                //                }
                //            }
                //        }
                //    }
                //}
                //else
                //{
                //    XtraMessageBox.Show("NO hay datos programados");
                //    ///////////////////
                //    if (_listPaqLecturados.Count > 0)
                //    {
                //        foreach (var item in _listPaqLecturados)
                //        {
                //            _listPaqLecturado.Add(item);
                //        }
                //    }

                //    DataSet dataValidar = C_Paquete.TraerProductosaLecturarValidar(_idDespacho);
                //    if (dataValidar.Tables[0].Rows.Count > 0)
                //    {
                //        foreach (DataRow itemValidar in dataValidar.Tables[0].Rows)
                //        {
                //            if (Convert.ToInt32(itemValidar[3]) <= Convert.ToInt32(itemValidar[4]))
                //            {
                //                _ItemId = itemValidar[2].ToString();
                //                DataSet dataLista = C_Paquete.TraerPaqueteLecturadoFiltrado(_idSucursal, _ItemId);
                //                foreach (DataRow item in dataLista.Tables[0].Rows)
                //                {
                //                    if (_listPaqLecturado.Contains(item[3].ToString()))
                //                    {
                //                        //Console.WriteLine("################################ = " + item[3].ToString());
                //                    }
                //                    else
                //                    {
                //                        if (!_listPaq.Any(n => n.p_PaqueteId == item[3].ToString()))
                //                        {
                //                            _listPaq.Add(new PaqueteLecturado
                //                            {
                //                                p_ItemId = item[0].ToString(),
                //                                p_ItemFerro = item[1].ToString(),
                //                                p_Descripcion = item[2].ToString(),
                //                                p_PaqueteId = item[3].ToString(),
                //                                p_Piezas = Convert.ToInt32(item[4]),
                //                                p_Peso = Convert.ToDecimal(item[5]),
                //                                p_Unidad = item[6].ToString(),
                //                                p_Retirar = Convert.ToInt32(item[7]),
                //                                p_Fecha = Convert.ToDateTime(item[8])
                //                            });
                //                        }
                //                    }
                //                }
                //            }
                //            else
                //            {

                //            }
                //        }
                //        //int _idProducto = 0;
                //        //DataSet DataListInf = C_Informix.TraerDescProducto(_idProducto);
                //        //foreach (DataRow item in DataListInf.Tables[0].Rows)
                //        //{
                //        //    //_desProdList.Find(p => p.ItemId == _itmId && p.ProductoId == _paqtId).Cantidad = _cantN;
                //        //    _listPaq.Find(p => p.p_ItemFerro == item[0].ToString()).p_Descripcion = item[1].ToString();
                //        //}
                //    }
                //    else
                //    {
                //        DataSet dataItems = C_Paquete.TraerCantProdPorDespacho(_idDespacho);
                //        if (dataItems.Tables[0].Rows.Count > 0)
                //        {
                //            foreach (DataRow itemFiltrar in dataItems.Tables[0].Rows)
                //            {
                //                _ItemId = itemFiltrar[0].ToString();
                //                DataSet dataLista = C_Paquete.TraerPaqueteLecturadoFiltrado(_idSucursal, _ItemId);
                //                foreach (DataRow item in dataLista.Tables[0].Rows)
                //                {
                //                    _listPaq.Add(new PaqueteLecturado
                //                    {
                //                        p_ItemId = item[0].ToString(),
                //                        p_ItemFerro = item[1].ToString(),
                //                        p_Descripcion = item[2].ToString(),
                //                        p_PaqueteId = item[3].ToString(),
                //                        p_Piezas = Convert.ToInt32(item[4]),
                //                        p_Peso = Convert.ToDecimal(item[5]),
                //                        p_Unidad = item[6].ToString(),
                //                        p_Retirar = Convert.ToInt32(item[7]),
                //                        p_Fecha = Convert.ToDateTime(item[8])
                //                    });
                //                }
                //            }
                //        }
                //        else
                //        {
                //            XtraMessageBox.Show("No se tiene ningun item programado", "Aviso");
                //            DataSet dataLista = C_Paquete.TraerPaqueteLecturadoPorSucursal(_idSucursal);
                //            foreach (DataRow item in dataLista.Tables[0].Rows)
                //            {
                //                _listPaq.Add(new PaqueteLecturado
                //                {
                //                    p_ItemId = item[0].ToString(),
                //                    p_ItemFerro = item[1].ToString(),
                //                    p_Descripcion = item[2].ToString(),
                //                    p_PaqueteId = item[3].ToString(),
                //                    p_Piezas = Convert.ToInt32(item[4]),
                //                    p_Peso = Convert.ToDecimal(item[5]),
                //                    p_Unidad = item[6].ToString(),
                //                    p_Retirar = Convert.ToInt32(item[7]),
                //                    p_Fecha = Convert.ToDateTime(item[8])
                //                });
                //            }
                //        }
                //    }
                //}
                if (_listPaqLecturados.Count > 0)
                {
                    foreach (var item in _listPaqLecturados)
                    {
                        _listPaqLecturado.Add(item);
                    }
                }

                DataSet dataValidar = C_Paquete.TraerProductosaLecturarValidar(_idDespacho);
                if (dataValidar.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow itemValidar in dataValidar.Tables[0].Rows)
                    {
                        if (Convert.ToInt32(itemValidar[3]) <= Convert.ToInt32(itemValidar[4]))
                        {
                            _ItemId = itemValidar[2].ToString();
                            DataSet dataLista = C_Paquete.TraerPaqueteLecturadoFiltrado(_idSucursal, _ItemId);
                            foreach (DataRow item in dataLista.Tables[0].Rows)
                            {
                                if (_listPaqLecturado.Contains(item[3].ToString()))
                                {
                                    //Console.WriteLine("################################ = " + item[3].ToString());
                                }
                                else
                                {
                                    if (!_listPaq.Any(n => n.p_PaqueteId == item[3].ToString()))
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
                                            p_Retirar = Convert.ToInt32(item[4]),
                                            p_Fecha = Convert.ToDateTime(item[8])
                                        });
                                    }
                                }
                            }
                        }
                        else
                        {

                        }
                    }
                }
                else
                {
                    DataSet dataItems = C_Paquete.TraerCantProdPorDespacho(_idDespacho);
                    if (dataItems.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow itemFiltrar in dataItems.Tables[0].Rows)
                        {
                            _ItemId = itemFiltrar[0].ToString();
                            DataSet dataLista = C_Paquete.TraerPaqueteLecturadoFiltrado(_idSucursal, _ItemId);
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
                        }
                    }
                    else
                    {
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
                    }
                }
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Problemas con la conexion", "Error");
                Console.WriteLine("####################### = " + err.ToString());
            }
        }
        private void ListaProductosLecturado_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.OpenForms["ListaLecturadoA"].Enabled = true;
            }
        }
        //btnAceptar
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (gridControl1.CanSelect)
            {
                ColumnView view = gridControl1.MainView as ColumnView;
                int[] row = view.GetSelectedRows();
                if (row.Length > 0)
                {
                    try
                    {
                        for(int i = 0; i < row.Length; i++)
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

                            if(_piezas != _cantidad)
                            {
                                decimal _pesoUnit = _peso / _piezas;
                                _peso = _pesoUnit * _cantidad;
                            }

                            if (_idItem != string.Empty)
                            {
                                (this.Owner as ListaLecturadoA).ProductoElegido(_idItem, _itemFerro, _descripcion, _paquete, _piezas, _peso, _unidad, _cantidad);
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
        //btnCancelar
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void searchControl1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if(_tipoBusqueda == 0)
                {
                    _busq = searchControl1.Text;
                    gridControl1.DataSource = _listPaq.Where(x => x.p_ItemId.ToLower().Contains(_busq.ToLower()));
                }
                else if(_tipoBusqueda == 1)
                {
                    _busq = searchControl1.Text;
                    gridControl1.DataSource = _listPaq.Where(x => x.p_ItemFerro.ToLower().Contains(_busq.ToLower()));
                }
                else if(_tipoBusqueda == 2)
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
            catch(Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("####################### = " + err.ToString());
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
            else
            {
                //
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
            else
            {
                //
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
            else
            {
                //
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
                int _piezas = Convert.ToInt32(view.GetRowCellDisplayText(_valData, view.Columns[5]));
                int _cantN = Convert.ToInt32(view.GetRowCellDisplayText(_valData, view.Columns[7]));
                //_desProdList.Find(p => p.ItemId == _itmId && p.ProductoId == _paqtId).Cantidad = _cantN;
                if(_cantN > _piezas)
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
    }
}