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

namespace WFConsumo.frmGRH.Localizacion
{
    public partial class VerCelda : DevExpress.XtraEditors.XtraForm
    {
        CPaquetes C_Paquete;
        CCeldas C_Celdas;
        int _IdSucursal = 0;
        string _CeldaId;
        List<PaqueteACelda> _lisPaqueteCelda = new List<PaqueteACelda>();
        List<PaqueteACelda> _PaqEnCelda = new List<PaqueteACelda>();
        List<CeldaConsulta> _listCeldas = new List<CeldaConsulta>();
        int _CantidadTotal = 0;
        decimal _PesoTotal = 0;
        string _PaqXMover = string.Empty;
        int _NaveElegida = 0;
        string _ColumnaElegida = string.Empty;
        string _CeldaElegida = string.Empty;
        string _ColumnaRackElegido = string.Empty;
        int tipoCelda = 0;

        public VerCelda(string CeldaNom, int idSucursal, int _tipoCelda, string _estante)
        {
            InitializeComponent();
            txtCeldaNom.Text = CeldaNom;
            _CeldaId = CeldaNom;
            txtEstanteNom.Text = _estante;
            _IdSucursal = idSucursal;
            tipoCelda = _tipoCelda;
            C_Paquete = new CPaquetes();
            C_Celdas = new CCeldas();
            TraerData();
        }
        public void TraerData()
        {
            try
            {
                //DataDeCelda
                DataSet dataEst = C_Paquete.PaquetesEnEstante(_CeldaId);
                foreach(DataRow itm in dataEst.Tables[0].Rows)
                {
                    _PaqEnCelda.Add(new PaqueteACelda
                    {
                        p_PaqueteId = itm[0].ToString(),
                        p_ItemId = itm[1].ToString(),
                        p_ItemFId = Convert.ToInt32(itm[2]),
                        p_Descripcion = itm[3].ToString(),
                        p_Peso = Convert.ToDecimal(itm[4]),
                        p_Piezas = Convert.ToInt32(itm[5])
                    });
                }

                //ListDropDown
                DataSet lista = C_Paquete.BuscarPaqueteLocaliza(_IdSucursal);
                foreach (DataRow item in lista.Tables[0].Rows)
                {
                    _lisPaqueteCelda.Add(new PaqueteACelda
                    {
                        //Convert.ToDecimal(drDatos["total"] is DBNull ? 0:drDatos["total"])
                        p_PaqueteId = item[0].ToString(),
                        p_ItemId = item[1].ToString(),
                        p_ItemFId = Convert.ToInt32(item[2] is DBNull ? 0 : item[2]),
                        p_Descripcion = item[3].ToString(),
                        p_Peso = Convert.ToDecimal(item[4] is DBNull ? 0 : item[4]),
                        p_Piezas = Convert.ToInt32(item[5] is DBNull ? 0 : item[5])
                    });
                    comboxPaq.Properties.Items.Add(item[0].ToString());
                }

                gridControl1.DataSource = _PaqEnCelda;
                foreach(var item in _PaqEnCelda)
                {
                    _CantidadTotal = _CantidadTotal + 1;
                    _PesoTotal = _PesoTotal + item.p_Peso;
                }
                txtCantidadTotal.Text = _CantidadTotal.ToString();
                txtPesoTotal.Text = _PesoTotal.ToString() + " Kgs.";

                int _NavesAlm = 0;
                DataSet listAlmacen = C_Paquete.TraerNavesXAlmacen(_IdSucursal);
                foreach(DataRow item in listAlmacen.Tables[0].Rows)
                {
                    _NavesAlm = Convert.ToInt32(item[0]);
                }
                _NavesAlm = _NavesAlm + 1;
                for(int i = 1; i < _NavesAlm; i++)
                {
                    comboxNave.Properties.Items.Add(i.ToString());
                } 
                comboxColNav.Properties.Items.Add("A");
                comboxColNav.Properties.Items.Add("B");
                comboxColNav.Properties.Items.Add("C");
                if(tipoCelda == 0)
                {
                    comboxPiso.Properties.Items.Add("1");
                }
                else if(tipoCelda == 1)
                {
                    comboxPiso.Properties.Items.Add("1");
                    comboxPiso.Properties.Items.Add("2");
                    comboxPiso.Properties.Items.Add("3");
                    comboxPiso.Properties.Items.Add("4");
                    comboxPiso.Properties.Items.Add("5");
                    
                }
                else
                {
                    comboxPiso.Properties.Items.Add("1");
                }
                comboxColRack.Properties.Items.Add("A");
                comboxColRack.Properties.Items.Add("B");
                comboxColRack.Properties.Items.Add("C");
                comBoxFila.Properties.Items.Add("1");
                comBoxFila.Properties.Items.Add("2");
                ////////////////////////////////////////////
                DataSet dataCeldas = C_Celdas.VistaAlmacenes(_IdSucursal);
                foreach(DataRow item in dataCeldas.Tables[0].Rows)
                {
                    _listCeldas.Add(new CeldaConsulta
                    {
                        p_Area = Convert.ToInt32(item[0]),
                        p_Segmento = item[1].ToString(),
                        p_Nave = Convert.ToInt32(item[2] is DBNull ? 0 : item[2]),
                        p_Columna = item[3].ToString(),
                        p_CeldaId = item[4].ToString(),
                        p_ItemId = item[5].ToString(),
                        p_Unidades = Convert.ToInt32(item[6] is DBNull ? 0 : item[6]),
                        p_UnidadesXCelda = Convert.ToInt32(item[7] is DBNull ? 0 : item[6]),
                        p_Status = Convert.ToInt32(item[8] is DBNull ? 0 : item[8])
                    });
                }
            }
            catch(Exception err)
            {
                Console.WriteLine("####################### = " + err.ToString());
            }
        }
        public class PaqueteACelda
        {
            private string PaqueteId;
            private string ItemId;
            private int ItemFId;
            private string Descripcion;
            private decimal Peso;
            private int Piezas;

            public string p_PaqueteId
            {
                get { return PaqueteId; }
                set { PaqueteId = value; }
            }
            public string p_ItemId
            {
                get { return ItemId; }
                set { ItemId = value; }
            }
            public int p_ItemFId
            {
                get { return ItemFId; }
                set { ItemFId = value; }
            }
            public string p_Descripcion
            {
                get { return Descripcion; }
                set { Descripcion = value; }
            }
            public decimal p_Peso
            {
                get { return Peso; }
                set { Peso = value; }
            }
            public int p_Piezas
            {
                get { return Piezas; }
                set { Piezas = value; }
            }
        }
        public class CeldaConsulta
        {
            private int Area;
            private string Segmento;
            private int Nave;
            private string Columna;
            private string CeldaId;
            private string ItemId;
            private int Unidades;
            private int UnidadesXCelda;
            private int Status;

            public int p_Area
            {
                get { return Area; }
                set { Area = value; }
            }
            public string p_Segmento
            {
                get { return Segmento; }
                set { Segmento = value; }
            }
            public int p_Nave
            {
                get { return Nave; }
                set { Nave = value; }
            }
            public string p_Columna
            {
                get { return Columna; }
                set { Columna = value; }
            }
            public string p_CeldaId
            {
                get { return CeldaId; }
                set { CeldaId = value; }
            }
            public string p_ItemId
            {
                get { return ItemId; }
                set { ItemId = value; }
            }
            public int p_Unidades
            {
                get { return Unidades; }
                set { Unidades = value; }
            }
            public int p_UnidadesXCelda
            {
                get { return UnidadesXCelda; }
                set { UnidadesXCelda = value; }
            }
            public int p_Status
            {
                get { return Status; }
                set { Status = value; }
            }
        }
        private void comboxPaq_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int _data = comboxPaq.SelectedIndex;
                if (_data > 0)
                {
                    foreach(var item in _lisPaqueteCelda)
                    {
                        if(comboxPaq.Text == item.p_PaqueteId)
                        {
                            txtPaquete.Text = item.p_PaqueteId;
                            txtItemId.Text = item.p_ItemId;
                            txtItemFerro.Text = item.p_ItemFId.ToString();
                            txtPesoPaq.Text = item.p_Peso.ToString();
                            txtDescripcionPaq.Text = item.p_Descripcion;
                        }
                    }
                }
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("################### = " + err.ToString());
            }
        }
        private void btnAgregarPaq_Click(object sender, EventArgs e)
        {
            try
            {
                _PaqEnCelda.Add(new PaqueteACelda
                { 
                    p_PaqueteId = txtPaquete.Text,
                    p_ItemId = txtItemId.Text,
                    p_ItemFId = Convert.ToInt32(txtItemFerro.Text),
                    p_Descripcion = txtDescripcionPaq.Text,
                    p_Peso = Convert.ToDecimal(txtPesoPaq.Text)
                });
                gridControl1.RefreshDataSource();
                _CantidadTotal = 0;
                _PesoTotal = 0;
                foreach (var item in _PaqEnCelda)
                {
                    _CantidadTotal = _CantidadTotal + 1;
                    _PesoTotal = _PesoTotal + item.p_Peso;
                }
                txtCantidadTotal.Text = _CantidadTotal.ToString();
                txtPesoTotal.Text = _PesoTotal.ToString() + " Kgs.";
            }
            catch(Exception err)
            {
                Console.WriteLine("################## = " + err.ToString());
            }
        }
        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
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
                    _PaqXMover = view.GetRowCellDisplayText(row[0], view.Columns[0]).ToString();
                    txtPaqueteEnv.Text = _PaqXMover;
                }
                catch (Exception err)
                {
                    XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                    Console.WriteLine("################## = " + err.ToString());
                }
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void comboxNave_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int _data = comboxNave.SelectedIndex;
                if (_data > 0)
                {
                    _NaveElegida = Convert.ToInt32(comboxNave.Text);
                    if(_ColumnaElegida != string.Empty)
                    {
                        comboxCeldaDest.Properties.Items.Clear();
                        foreach(var item in _listCeldas)
                        {
                            if(item.p_Nave == _NaveElegida && item.p_Columna == _ColumnaElegida)
                            {
                                comboxCeldaDest.Properties.Items.Add(item.p_CeldaId);
                            }
                        }
                    }
                }
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("################### = " + err.ToString());
            }
        }
        private void comboxColNav_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int _data = comboxNave.SelectedIndex;
                if (_data > 0)
                {
                    _ColumnaElegida = comboxColNav.Text;
                    if (_NaveElegida > 0)
                    {
                        comboxCeldaDest.Properties.Items.Clear();
                        foreach (var item in _listCeldas)
                        {
                            if (item.p_Nave == _NaveElegida && item.p_Columna == _ColumnaElegida)
                            {
                                comboxCeldaDest.Properties.Items.Add(item.p_CeldaId);
                            }
                        }
                    }
                }
            }
            catch (Exception err)
            {
                XtraMessageBox.Show("Algo salio mal, intentelo de nuevo", "Error");
                Console.WriteLine("################### = " + err.ToString());
            }
        }
        private void txtPaqueteEnv_TextChanged(object sender, EventArgs e)
        {
            string val = txtPaqueteEnv.Text;
            if(val.Length > 6)
            {
                groupBoxRetirar.Enabled = true;
            }
        }
    }
}