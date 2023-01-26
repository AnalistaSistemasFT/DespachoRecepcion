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
using WFConsumo.frmGRH.Imprimir;
using DevExpress.XtraGrid.Views.Base;

namespace WFConsumo.frmGRH
{
    public partial class BuscarControlPaquete : DevExpress.XtraEditors.XtraForm
    {
        int _tipoBusqueda = 0;
        string _cProd = string.Empty;
        string _cFerro = string.Empty;
        List<BusqPaquete> _ListPaq= new List<BusqPaquete>();
        CPaquetes C_Paquete;
        int _idSucursal = 0;

        public BuscarControlPaquete()
        {
            InitializeComponent();
            C_Paquete = new CPaquetes();
            _idSucursal = Entidades.utilitario.iSucursal;
            TraerData();
        }

        private void TraerData()
        {
            try
            {
                DataSet dataLista = C_Paquete.BuscarPaqItemControl(_idSucursal);
                foreach (DataRow item in dataLista.Tables[0].Rows)
                {
                    _ListPaq.Add(new BusqPaquete
                    {
                        p_Codigo = item[0].ToString(),
                        p_CodigoFerro = item[1].ToString(),
                        p_Descripcion = item[2].ToString(),
                        p_Celda = item[3].ToString(),
                        p_Cantidad = Convert.ToInt32(item[4]),
                        p_Paquete = item[5].ToString()
                    });
                }
                this.gridControl1.DataSource = _ListPaq;
            }
            catch(Exception err)
            {
                Console.WriteLine("###################### = " + err.ToString());
            }
        }
        private void checkCodFerro_CheckedChanged(object sender, EventArgs e)
        {
            if (checkCodFerro.Checked == true)
            {
                checkCodigo.Checked = false;
                _tipoBusqueda = 0;
            }
            else if (checkCodFerro.Checked == false)
            {
                checkCodigo.Checked = true;
                _tipoBusqueda = 1;
            }
            else
            {
                checkCodFerro.Checked = true;
                checkCodigo.Checked = false;
                _tipoBusqueda = 0;
            }
        }
        private void checkCodigo_CheckedChanged(object sender, EventArgs e)
        {
            if (checkCodigo.Checked == true)
            {
                checkCodFerro.Checked = false;
                _tipoBusqueda = 1;
            }
            else if (checkCodigo.Checked == false)
            {
                checkCodFerro.Checked = true;
                _tipoBusqueda = 0;
            }
            else
            {
                checkCodFerro.Checked = true;
                checkCodigo.Checked = false;
                _tipoBusqueda = 0;
            }
        }
        private void searchControl1_TextChanged(object sender, EventArgs e)
        {
            //buscar por Codigo Ferrotodo
            if (_tipoBusqueda == 0)
            {
                _cFerro = searchControl1.Text;
                gridControl1.DataSource = _ListPaq.Where(x => x.p_CodigoFerro.ToLower().Contains(_cFerro.ToLower()));
            }
            //buscar por Codigo Produccion
            else if (_tipoBusqueda == 1)
            {
                _cProd = searchControl1.Text;
                gridControl1.DataSource = _ListPaq.Where(x => x.p_Codigo.ToLower().StartsWith(_cProd.ToLower()));
            }
            else
            {
                _tipoBusqueda = 0;
            }
        }
        public class BusqPaquete
        {
            private string Codigo;
            private string CodigoFerro;
            private string Descripcion;
            private string Celda;
            private int Cantidad;
            private string Paquete;

            public string p_Codigo
            {
                get { return Codigo; }
                set { Codigo = value; }
            }
            public string p_CodigoFerro
            {
                get { return CodigoFerro; }
                set { CodigoFerro = value; }
            }
            public string p_Descripcion
            {
                get { return Descripcion; }
                set { Descripcion = value; }
            }
            public string p_Celda
            {
                get { return Celda; }
                set { Celda = value; }
            }
            public int p_Cantidad
            {
                get { return Cantidad; }
                set { Cantidad = value; }
            }
            public string p_Paquete
            {
                get { return Paquete; }
                set { Paquete = value; }
            }
        }
        //Imprimir
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string _codigo = string.Empty;
                if (_tipoBusqueda == 0)
                {
                    int _codFerro = Convert.ToInt32(_cFerro);
                    DataSet _detPaquetes = C_Paquete.ImprimirPaqControlFerro(_codFerro, _idSucursal);
                    DetallePaquetes _detPaq = new DetallePaquetes();
                    _detPaq.SetDataSource(_detPaquetes.Tables[0]);
                    frmReportViewer viwer = new frmReportViewer(_detPaq);
                    viwer.Width = 1000;
                    viwer.Height = 720;
                    viwer.StartPosition = FormStartPosition.CenterScreen;
                    viwer.ShowDialog();
                }
                else if(_tipoBusqueda == 1)
                {
                    ColumnView view = gridControl1.MainView as ColumnView;
                    int[] row = view.GetSelectedRows();
                    if (row.Length > 0)
                    {
                        view.FocusedRowHandle = row[0];
                    }
                    _cProd = view.GetRowCellDisplayText(row[0], view.Columns[0]);
                    DataSet _detPaquetes = C_Paquete.ImprimirPaqControlProd(_cProd, _idSucursal);
                    DetallePaquetes _detPaq = new DetallePaquetes();
                    _detPaq.SetDataSource(_detPaquetes.Tables[0]);
                    frmReportViewer viwer = new frmReportViewer(_detPaq);
                    viwer.Width = 1000;
                    viwer.Height = 750;
                    viwer.StartPosition = FormStartPosition.CenterScreen;
                    viwer.ShowDialog();
                }
                else
                {
                    DataSet _detPaquetes = C_Paquete.ImprimirPaqControlProd(_codigo, _idSucursal);
                    DetallePaquetes _detPaq = new DetallePaquetes();
                    _detPaq.SetDataSource(_detPaquetes.Tables[0]);
                    frmReportViewer viwer = new frmReportViewer(_detPaq);
                    viwer.Width = 1000;
                    viwer.Height = 800;
                    viwer.StartPosition = FormStartPosition.CenterScreen;
                    viwer.ShowDialog();
                }
                

                
            }
            catch(Exception err)
            {
                Console.WriteLine("###################### = " + err.ToString());
            }
        }
    }
}