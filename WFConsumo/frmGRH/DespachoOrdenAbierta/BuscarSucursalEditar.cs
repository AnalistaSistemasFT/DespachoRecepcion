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

namespace WFConsumo.frmGRH.DespachoOrdenAbierta
{
    public partial class BuscarSucursalEditar : DevExpress.XtraEditors.XtraForm
    {
        private int _idSuc = 0;
        private string _desc;
        private int _tipoDoc = 0;
        private string _Tipodespacho;
        CSucursal C_Sucursal;
        CDespacho C_Despacho;
        DataTable dataP = new DataTable();
        DataTable dataSucursal = new DataTable();
        DataTable dataB = new DataTable();
        List<SucursalElegir> _sucursalList = new List<SucursalElegir>();
        int _tipoBusqueda = 0;
        public BuscarSucursalEditar(string _tipoDespacho)
        {
            InitializeComponent();
            _Tipodespacho = _tipoDespacho;
            C_Sucursal = new CSucursal();
            C_Despacho = new CDespacho();
            TraerData();
        }
        public void TraerData()
        {
            try
            {
                if (_Tipodespacho == "VENTA")
                {
                    _sucursalList.Clear();
                    DataSet dataList = C_Despacho.TraerSucursalesVenta();
                    dataSucursal = dataList.Tables[0];
                    foreach (DataRow item in dataSucursal.Rows)
                    {
                        _sucursalList.Add(new SucursalElegir
                        {
                            p_sccodfin = Convert.ToInt32(item[0]),
                            p_sctcdesc = item[1].ToString()
                        });
                    }
                    gridControl1.DataSource = _sucursalList;
                }
                else if (_Tipodespacho == "TRASPASO")
                {
                    _sucursalList.Clear();
                    DataSet dataList = C_Sucursal.TraerSucursalesTraspaso();
                    dataSucursal = dataList.Tables[0];
                    foreach (DataRow item in dataSucursal.Rows)
                    {
                        _sucursalList.Add(new SucursalElegir
                        {
                            p_sccodfin = Convert.ToInt32(item[0]),
                            p_sctcdesc = item[1].ToString()
                        });
                    }
                    gridControl1.DataSource = _sucursalList;
                }
                else
                {
                    _sucursalList.Clear();
                    DataSet dataList = C_Sucursal.TraerSucursalesTraspaso();
                    dataSucursal = dataList.Tables[0];
                    foreach (DataRow item in dataSucursal.Rows)
                    {
                        _sucursalList.Add(new SucursalElegir
                        {
                            p_sccodfin = Convert.ToInt32(item[0]),
                            p_sctcdesc = item[1].ToString()
                        });
                    }
                    gridControl1.DataSource = _sucursalList;
                }
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("####################### = " + err.ToString());
            }
        }
        private void RowCellClickEvent(object sender, EventArgs e)
        {
            try
            {
                ColumnView view = this.gridControl1.MainView as ColumnView;
                int[] row = view.GetSelectedRows();
                view.FocusedRowHandle = row[0];
                _idSuc = Convert.ToInt32((view.GetRowCellDisplayText(row[0], view.Columns[0])).ToString());
                _desc = (view.GetRowCellDisplayText(row[0], view.Columns[1])).ToString();
                //_tipoDoc = Convert.ToInt32(view.GetRowCellDisplayText(row[0], view.Columns[2]));
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("####################### = " + err.ToString());
            }
        } 
        private void toggleSwitch1_Toggled(object sender, EventArgs e)
        {
            if (_tipoBusqueda == 0)
            {
                _tipoBusqueda = 1;
                searchControl.Text = string.Empty;
            }
            else if (_tipoBusqueda == 1)
            {
                _tipoBusqueda = 0;
                searchControl.Text = string.Empty;
            }
            else
            {
                _tipoBusqueda = 0;
            }
        }
        private void searchControl_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (_Tipodespacho == "VENTA")
                {
                    if (_tipoBusqueda == 0)
                    {
                        string _nombreSuc = searchControl.Text;
                        gridControl1.DataSource = _sucursalList.Where(x => x.p_sctcdesc.ToLower().Contains(_nombreSuc.ToLower()));

                        this.gridControl1.RefreshDataSource();
                        this.gridControl1.Refresh();
                    }
                    else if (_tipoBusqueda == 1)
                    {
                        string _codigoSuc = searchControl.Text;
                        gridControl1.DataSource = _sucursalList.Where(x => x.p_sccodfin.ToString().Contains(_codigoSuc.ToLower()));

                        this.gridControl1.RefreshDataSource();
                        this.gridControl1.Refresh();
                    }
                }
                else if (_Tipodespacho == "TRASPASO")
                {
                    if (_tipoBusqueda == 0)
                    {
                        string _nombreSuc = searchControl.Text;
                        gridControl1.DataSource = _sucursalList.Where(x => x.p_sctcdesc.ToLower().Contains(_nombreSuc));
                    }
                    else if (_tipoBusqueda == 1)
                    {
                        string _codigoSuc = searchControl.Text;
                        gridControl1.DataSource = _sucursalList.Where(x => x.p_sccodfin.ToString().Contains(_codigoSuc));
                    }
                }
                else
                {
                    XtraMessageBox.Show("Algo salio mal, ingrese nuevamente");
                    this.Close();
                }
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("####################### = " + err.ToString());
            }

        }
        //btnAceptar
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(_desc) || (!string.IsNullOrEmpty(_desc)))
            {
                try
                {
                    (this.Owner as frmEditarDespacho).SucursalElegida(_idSuc, _desc);
                    this.Close();
                }
                catch (Exception err)
                {
                    XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                    Console.WriteLine("####################### = " + err.ToString());
                }
            }
            else
            {
                Console.WriteLine("############################### = _desc vacio ");
            }
        }
        //btnCancelar
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}