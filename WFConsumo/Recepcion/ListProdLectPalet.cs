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
using DevExpress.XtraGrid.Views.Grid;

namespace WFConsumo.Recepcion
{
    public partial class ListProdLectPalet : DevExpress.XtraEditors.XtraForm
    {
        List<PaletLecturado> _listPaq = new List<PaletLecturado>();
        List<string> _listPaqLecturado = new List<string>();
        List<DespProductos> _desProdList = new List<DespProductos>();
        CPaquetes C_Paquete;
        CInformix C_Informix;
        int _idSucursal = 0;
        string _Palet = string.Empty;
        string _busq = string.Empty;
        string _ItemId = string.Empty;
        int _tipoBusqueda = 0;

        public ListProdLectPalet(int IdSucursal, string Codigo, List<string> _listPaqLecturados, string Palet)
        {
            InitializeComponent();
            _idSucursal = IdSucursal;
            _Palet = Palet;
            _ItemId = Codigo;
            C_Paquete = new CPaquetes();
            C_Informix = new CInformix();
            _desProdList = new List<DespProductos>();
            TraerData();
            this.gridControl1.DataSource = _listPaq;
        }

        private void TraerData()
        {
            try
            {
                DataSet datosPaq = C_Paquete.TraerListaPaqsPalet(_ItemId, _idSucursal);
                foreach (DataRow item in datosPaq.Tables[0].Rows)
                {
                    string _fecV = item[4].ToString();
                    DateTime _fec = DateTime.Now;
                    if (_fecV.Length < 3)
                    {
                        _fec = (DateTime)item[5];
                    }
                    else
                    {
                        _fec = (DateTime)item[4];
                    }
                    _listPaq.Add(new PaletLecturado
                    {

                        p_ItemId = item[0].ToString(),
                        p_ItemFerro = item[1].ToString(),
                        p_Descripcion = item[2].ToString(),
                        p_PaqueteId = item[3].ToString(),
                        p_FechaV = _fec,
                        p_Piezas = Convert.ToInt32(item[6]),
                        p_Peso = Convert.ToDecimal(item[7]),
                        p_Lote = item[8].ToString()
                    });
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
                Application.OpenForms["CrearPalet"].Enabled = true;
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
                        for (int i = 0; i < row.Length; i++)
                        {
                            string _idItem = string.Empty;
                            string _itemFerro = string.Empty;
                            string _descripcion = string.Empty;
                            string _paquete = string.Empty;
                            int _piezas = 0;
                            decimal _peso = 0;

                            _itemFerro = view.GetRowCellDisplayText(row[i], view.Columns[0]);
                            _idItem = view.GetRowCellDisplayText(row[i], view.Columns[1]);
                            _descripcion = view.GetRowCellDisplayText(row[i], view.Columns[2]);
                            _paquete = view.GetRowCellDisplayText(row[i], view.Columns[3]);
                            _piezas = Convert.ToInt32(view.GetRowCellDisplayText(row[i], view.Columns[5]));
                            _peso = Convert.ToDecimal(view.GetRowCellDisplayText(row[i], view.Columns[6]));

                            if (_idItem != string.Empty)
                            {
                                (this.Owner as CrearPalet).ProductoElegido(_idItem, _itemFerro, _descripcion, _paquete, _piezas, _peso);
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
                if (_tipoBusqueda == 0)
                {
                    _busq = searchControl1.Text;
                    gridControl1.DataSource = _listPaq.Where(x => x.p_PaqueteId.ToLower().Contains(_busq.ToLower()));
                }
                else if (_tipoBusqueda == 1)
                {
                    _busq = searchControl1.Text;
                    gridControl1.DataSource = _listPaq.Where(x => x.p_Lote.ToLower().Contains(_busq.ToLower()));
                }
                else
                {
                    _busq = searchControl1.Text;
                    gridControl1.DataSource = _listPaq.Where(x => x.p_PaqueteId.ToLower().Contains(_busq.ToLower()));
                }
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("####################### = " + err.ToString());
            }
        }
        private void checkPaquete_CheckedChanged(object sender, EventArgs e)
        {
            if (checkPaquete.Checked == true)
            {
                checkLote.Checked = false;
                _tipoBusqueda = 0;
            }
            else
            {
                //
            }
        }
        private void checkLote_CheckedChanged(object sender, EventArgs e)
        {
            if (checkLote.Checked == true)
            {
                checkPaquete.Checked = false;
                _tipoBusqueda = 1;
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
         
        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            try
            {
                int cnt = gridView1.GetSelectedRows().Length;
                txtContador.Text = "Total: " + cnt.ToString();
            }
            catch(Exception err)
            {
                Console.WriteLine("##################### = " + err.ToString());
            }
        }
        public int getChildRows(GridView view, int groupRowHandle)
        {
            int rv = 0;
            if (!view.IsGroupRow(groupRowHandle))
                return rv;
            //Get the number of immediate children  
            int childCount = view.GetChildRowCount(groupRowHandle);
            for (int i = 0; i < childCount; i++)
            {
                // Get the handle of a child row with the required index  
                int childHandle = view.GetChildRowHandle(groupRowHandle, i);
                //If the child is a group row, then add its children to the list  
                if (!view.IsGroupRow(childHandle) && view.IsRowSelected(childHandle))
                {
                    // The child is a data row.  
                    // Add it to the childRows as long as the row wasn't added before  
                    rv++;
                }
            }
            txtContador.Text = "Total: " + rv.ToString();
            return rv;
        }
        private void gridView1_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
                e.TotalValue = String.Format(" - {0} Selected", getChildRows(gridView1, e.GroupRowHandle));
        }
    }
}