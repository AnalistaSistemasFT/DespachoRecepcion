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
using WFConsumo.frmGRH.DespachoOrdenEnProceso;

namespace WFConsumo.frmGRH.DespachoOrdenAbierta
{
    public partial class ListaPaletLecturar : DevExpress.XtraEditors.XtraForm
    {
        CPaquetes C_Paquetes;
        int idSucursal = 0;
        int form = 0;
        List<ProdPalet> _prodPalet = new List<ProdPalet>();
        List<ProdPalet> _prodPaletList = new List<ProdPalet>();
        List<string> _prodVal = new List<string>();

        public ListaPaletLecturar(int _idSucursal, int frm)
        {
            InitializeComponent();
            C_Paquetes = new CPaquetes();
            idSucursal = _idSucursal;
            form = frm;
            TraerData();
        }

        public void TraerData()
        {
            try
            {
                DataSet data = C_Paquetes.TraerPaletSucursal(idSucursal);
                gridControl2.DataSource = data.Tables[0];
            }
            catch(Exception err)
            {
                Console.WriteLine("######################### = " + err.ToString());
            }
        } 
        private void gridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                string _Codigo = string.Empty;
                ColumnView view = this.gridControl2.MainView as ColumnView;
                int[] row = view.GetSelectedRows();
                view.FocusedRowHandle = row[0];
                string _Palet = (view.GetRowCellDisplayText(row[0], view.Columns[0])).ToString();
                DataSet dataDet = C_Paquetes.TraerPaquetesPaletParaLecturar(idSucursal, _Palet);
                foreach (DataRow item in dataDet.Tables[0].Rows)
                {
                    _prodPalet.Add(new ProdPalet
                    {
                        p_CodigoFerro = Convert.ToInt32(item[0]),
                        p_Codigo = item[1].ToString(),
                        p_Descripcion = item[2].ToString(),
                        p_Paquete = item[3].ToString(),
                        p_Piezas = Convert.ToInt32(item[4]),
                        p_Peso = Convert.ToDecimal(item[5]),
                        p_Unidad = item[6].ToString(),
                        p_Cantidad = Convert.ToInt32(item[7]),
                        p_Fecha = (DateTime)item[8]
                    });
                    _Codigo = item[1].ToString();
                }
                DataSet dataVal = C_Paquetes.TraerPaqLecturadoPalet(idSucursal, _Codigo);
                foreach (DataRow item in dataVal.Tables[0].Rows)
                {
                    var itemToRemove = _prodPalet.Single(r => r.p_Codigo == item[0].ToString());
                    _prodPalet.Remove(itemToRemove);
                }
                gridControl1.DataSource = _prodPalet;
            }
            catch(Exception err)
            {
                Console.WriteLine("################### = " + err.ToString());
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
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
                                    if(form == 0)
                                    {
                                        (this.Owner as ListaLecturadoA).ProductoElegido(_idItem, _itemFerro, _descripcion, _paquete, _piezas, _peso, _unidad, _cantidad);
                                    }
                                    else
                                    {
                                        (this.Owner as ListaLecturado).ProductoElegido(_idItem, _itemFerro, _descripcion, _paquete, _piezas, _peso, _unidad, _cantidad);

                                    }
                                    this.Close();
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
            catch(Exception err)
            {
                Console.WriteLine("#################### = " + err.ToString());
            }
        }
        public class ProdPalet
        {
            private int CodigoFerro;
            private string Codigo;
            private string Descripcion;
            private string Paquete;
            private DateTime Fecha;
            private string Unidad;
            private int Piezas;
            private decimal Peso;
            private int Cantidad;

            public int p_CodigoFerro
            {
                get { return CodigoFerro; }
                set { CodigoFerro = value; }
            }
            public string p_Codigo
            {
                get { return Codigo; }
                set { Codigo = value; }
            }
            public string p_Descripcion
            {
                get { return Descripcion; }
                set { Descripcion = value; }
            }
            public string p_Paquete
            {
                get { return Paquete; }
                set { Paquete = value; }
            }
            public DateTime p_Fecha
            {
                get { return Fecha; }
                set { Fecha = value; }
            }
            public string p_Unidad
            {
                get { return Unidad; }
                set { Unidad = value; }
            }
            public int p_Piezas
            {
                get { return Piezas; }
                set { Piezas = value; }
            }
            public decimal p_Peso
            {
                get { return Peso; }
                set { Peso = value; }
            }
            public int p_Cantidad
            {
                get { return Cantidad; }
                set { Cantidad = value; }
            }
        }
    }
}