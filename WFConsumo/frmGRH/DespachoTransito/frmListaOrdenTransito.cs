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

namespace WFConsumo.frmGRH.DespachoTransito
{
    public partial class frmListaOrdenTransito : DevExpress.XtraEditors.XtraForm
    {
        int _idSucursal = 0;
        Usuario _user;
        public string _idDespacho;
        public string IdDespacho = "0";
        private DateTime _Fecha = DateTime.Now;
        CDespacho C_Despacho;
        DataTable dataT = new DataTable();
        DataTable dataDet = new DataTable();
        DataTable dataProd = new DataTable();
        CTraspaso C_Traspaso;
        CSucursal C_Sucursal;
        List<DetalleProducto> _lstProdDet = new List<DetalleProducto>();

        public frmListaOrdenTransito(Usuario user, int sucursalId)
        {
            InitializeComponent();
            _user = user;
            _idSucursal = sucursalId;
            C_Despacho = new CDespacho();
            C_Traspaso = new CTraspaso();
            C_Sucursal = new CSucursal();
            TraerData();
        }
        private void TraerData()
        {
            try
            {
                DataSet dataLista = C_Despacho.TraerDespachoTransito(_idSucursal);
                dataT = dataLista.Tables[0];
                this.gridControl1.DataSource = dataT;
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Problemas con la conexion", "Error");
                Console.WriteLine("####################### = " + err.ToString());
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                ColumnView view = this.gridControl1.MainView as ColumnView;
                int[] row = view.GetSelectedRows();
                view.FocusedRowHandle = row[0];
                _idDespacho = (view.GetRowCellDisplayText(row[0], view.Columns[0])).ToString();

                DataSet detalleLista = C_Despacho.TraerDetalleDespacho(_idDespacho);
                _lstProdDet.Clear();
                this.gridControl2.Refresh();
                this.gridControl2.RefreshDataSource();
                foreach (DataRow item in detalleLista.Tables[0].Rows)
                {
                    string idItem = item[0].ToString();
                    string descItem = item[1].ToString();
                    int reqItem = Convert.ToInt32(item[2]);
                    int compItem = Convert.ToInt32(item[3]);
                    decimal pesoItem = 0;
                    int numPaqCelda = 0;
                    int numPaqSob = 0;
                    DataSet sumCelda = C_Despacho.TraerDetalleDespachoSumCelda(_idDespacho, idItem);
                    foreach (DataRow sumCel in sumCelda.Tables[0].Rows)
                    {
                        numPaqCelda = Convert.ToInt32(sumCel[0]);
                    }
                    DataSet sumSobra = C_Despacho.TraerDetalleDespachoSumSob(_idDespacho, idItem);
                    foreach (DataRow sumSob in sumSobra.Tables[0].Rows)
                    {
                        numPaqSob = Convert.ToInt32(sumSob[0] is DBNull ? 0 : sumSob[0]);
                        //totaltomausado=Convert.ToDecimal(drDatos["total"] is DBNull ? 0:drDatos["total"])
                    }
                    int progItem = numPaqCelda + numPaqSob;
                    _lstProdDet.Add(new DetalleProducto
                    {
                        p_ItemId = idItem,
                        p_Descripcion = descItem,
                        p_PiezasReq = reqItem,
                        p_PiezasProg = progItem,
                        p_PiezasComp = compItem,
                        p_Peso = pesoItem
                    });
                }
                this.gridControl2.DataSource = _lstProdDet;

                DataSet detalleProd = C_Despacho.TraerDespProducto(_idDespacho);
                dataProd = detalleProd.Tables[0];
                this.gridControl3.DataSource = dataProd;
            }
            catch (Exception err)
            {
                Console.WriteLine("####################### = " + err.ToString());
            }
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            if (gridControl1.CanSelect)
            {
                ColumnView view = gridControl1.MainView as ColumnView;
                int[] row = view.GetSelectedRows();
                if (row.Length > 0)
                {
                    view.FocusedRowHandle = row[0];
                }
                try
                {
                    IdDespacho = view.GetRowCellDisplayText(row[0], view.Columns[0]);
                    if (IdDespacho != "0")
                    {
                        var myForm = new ConsultarDespacho(IdDespacho);
                        //this.Enabled = false;
                        myForm.Show();
                    }
                }
                catch (Exception err)
                {
                    XtraMessageBox.Show("Seleccione un despacho de la lista e intentelo de nuevo");
                    Console.WriteLine("########################### = " + err.ToString());
                }
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (gridView1.OptionsFind.AlwaysVisible == true)
            {
                gridView1.OptionsFind.AlwaysVisible = false;
            }
            else if (gridView1.OptionsFind.AlwaysVisible == false)
            {
                gridView1.OptionsFind.AlwaysVisible = true;
            }
            else
            {
                gridView1.OptionsFind.AlwaysVisible = true;
            }
        }
        private void btnControlDespacho_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridControl1.CanSelect)
                {
                    ColumnView view = gridControl1.MainView as ColumnView;
                    int[] row = view.GetSelectedRows();
                    if (row.Length > 0)
                    {
                        view.FocusedRowHandle = row[0];
                    }
                    try
                    {
                        IdDespacho = view.GetRowCellDisplayText(row[0], view.Columns[0]);
                        if (IdDespacho != "0")
                        {
                            var myForm = new ControlDespacho(IdDespacho);
                            myForm.Show();
                        }
                    }
                    catch (Exception err)
                    {
                        XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                        Console.WriteLine("################## = " + err.ToString());
                    }
                }
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("####################### = " + err.ToString());
            }
        }

        //////////////////////////////////////////////////////////
        public class DetalleProducto
        {
            private string ItemId;
            private string Descripcion;
            private int PiezasReq;
            private int PiezasProg;
            private int PiezasComp;
            private decimal Peso;

            public string p_ItemId
            {
                get { return ItemId; }
                set { ItemId = value; }
            }
            public string p_Descripcion
            {
                get { return Descripcion; }
                set { Descripcion = value; }
            }
            public int p_PiezasReq
            {
                get { return PiezasReq; }
                set { PiezasReq = value; }
            }
            public int p_PiezasProg
            {
                get { return PiezasProg; }
                set { PiezasProg = value; }
            }
            public int p_PiezasComp
            {
                get { return PiezasComp; }
                set { PiezasComp = value; }
            }
            public decimal p_Peso
            {
                get { return Peso; }
                set { Peso = value; }
            }
        }
    }
}