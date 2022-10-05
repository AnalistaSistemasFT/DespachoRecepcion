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
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;

namespace WFConsumo.frmGRH
{
    public partial class ControlDespacho : DevExpress.XtraEditors.XtraForm
    {
        string _idDespacho;
        CDespacho C_Despacho;
        DataTable dataT = new DataTable();
        int _totalCantidad = 0;
        decimal _totalPeso = 0;
        List<ProductosControl> _listPrd = new List<ProductosControl>();
        public ControlDespacho(string IdDespacho)
        {
            InitializeComponent();
            _idDespacho = IdDespacho;
            txtDespachoId.Text = IdDespacho;
            C_Despacho = new CDespacho();
            GetData();
        }
        public void GetData()
        {
            try
            {
                DataSet dataDetalle = C_Despacho.TraerTotalControlDespacho(_idDespacho);
                foreach (DataRow item in dataDetalle.Tables[0].Rows)
                {
                    _listPrd.Add(new ProductosControl
                    {
                        p_ItemId = "",
                        p_ItemFId = "",
                        p_Descripcion = "",
                        p_ProductoId = "",
                        p_Piezas = Convert.ToInt32(item[0]),
                        p_Peso = Convert.ToDecimal(item[1])
                    });
                }
                //
                DataSet dataLista = C_Despacho.TraerControlDespacho(_idDespacho);
                foreach(DataRow item in dataLista.Tables[0].Rows)
                {
                    _listPrd.Add(new ProductosControl
                    {
                        p_ItemId = item[0].ToString(),
                        p_ItemFId = item[1].ToString(),
                        p_Descripcion = item[2].ToString(),
                        p_ProductoId = item[3].ToString(),
                        p_Piezas = Convert.ToInt32(item[4]),
                        p_Peso = Convert.ToDecimal(item[5])
                    });
                } 
                this.gridControl1.DataSource = _listPrd;
            }
            catch (Exception err)
            {
                Console.WriteLine("###################### = " + err.ToString());
            }
        }
        string dataPiezas = string.Empty;
        string dataPeso = string.Empty;
        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            //int _totalPeso = 1000;
            
            //if (e.Column.FieldName == "Peso")
            //{
            //    Console.WriteLine("########## IF SumaryPeso" + e.Column.SummaryText);
            //    dataPeso = e.Column.SummaryText;
            //}
            //else
            //{
            //    Console.WriteLine("########## SumaryPeso" + e.Column.FieldName);

            //}
            //if (e.Column.FieldName == "Piezas")
            //{
            //    Console.WriteLine("########## IF SumaryPiezas" + e.Column.SummaryText);
            //    dataPiezas = e.Column.SummaryText;
            //}
            //else
            //{
            //    Console.WriteLine("########## SumaryPiezas" + e.Column.FieldName);

            //}
            //string dataval = e.Column.FieldNameSortGroup;
            //if(e.Column.FieldName == "Codigo")
            //{
            //    e.DisplayText = "Datos piezas: " + dataPiezas + " Datos peso: " + dataPeso;
            //}
        }
        private void gridView1_CustomDrawGroupRow(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            //gridView1.Columns["Piezas"].Group();
            //gridView1.Columns["Peso"].Group();
            //GridGroupRowInfo row = e.Info as GridGroupRowInfo;
            e.Appearance.BackColor = Color.LightBlue;
            //string columnaNombre = row.Column.FieldName.ToString();
            //string columnaDato = row.GroupValueText.ToString();
            //string columnaTotal = row.Column.SummaryItem.SummaryValue.ToString(); 

            //row.GroupText = columnaNombre + " : " + columnaDato + " - " + columnaTotal; 
            //row.GroupText = dataPiezas + " - " + dataPeso;
        }
        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle == view.FocusedRowHandle)
            {
                e.Appearance.BackColor = Color.Green;
                e.Appearance.ForeColor = Color.White;
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnImprimir_Click(object sender, EventArgs e)
        {

        }
        ////////////////////////////////////////////////////////////////////////////
        public class ProductosControl
        {
            private string ItemId;
            private string ItemFId;
            private string Descripcion;
            private string ProductoId;
            private int Piezas;
            private decimal Peso;

            public string p_ItemId
            {
                get { return ItemId; }
                set { ItemId = value; }
            }
            public string p_ItemFId
            {
                get { return ItemFId; }
                set { ItemFId = value; }
            }
            public string p_Descripcion
            {
                get { return Descripcion; }
                set { Descripcion = value; }
            }
            public string p_ProductoId
            {
                get { return ProductoId; }
                set { ProductoId = value; }
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
        }
    }
}