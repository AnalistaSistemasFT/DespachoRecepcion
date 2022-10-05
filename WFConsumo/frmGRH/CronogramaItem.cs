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
using CRN.Entidades;

namespace WFConsumo.frmGRH
{
    public partial class CronogramaItem : DevExpress.XtraEditors.XtraForm
    {
        int _SucursalId = 0;
        string _IdDespacho = string.Empty;
        string _ItemId = string.Empty;
        int _piezas = 0;
        CDespacho C_Despacho;
        CDespProg C_DespProg;
        List<DetalleCronograma> _listCron = new List<DetalleCronograma>();
        List<DetalleCronograma> _listCronSum = new List<DetalleCronograma>();
        List<DetalleSobrantes> _listSob = new List<DetalleSobrantes>();
        List<DespProgCelda> _listProgCelda = new List<DespProgCelda>();
        List<DespProgSob> _listProgSob = new List<DespProgSob>();
        //
        int _piezasPend = 0;
        int _piezasPendTotal = 0;
        int _pzasXpaq = 0;
        int piezaProg = 0;
        int piezaReq = 0;
        int piezasPendiente = 0;
        int numPiezas = 0;
        int standardStock = 0;
        int postStandardStock = 0;
        int standardPaq = 0;
        int sobStock = 0;
        int sobPaq = 0;
        //
        int TotalPaqStandard = 0;
        int TotalPaqSobrantes = 0;
        //

        public CronogramaItem(string DespachoId, string ItemId, string DescItem, int PzaPaq, int _idSucursal, int PzaReq, int PzaProg)
        {
            InitializeComponent();
            txtDespacho.Text = DespachoId;
            _IdDespacho = DespachoId;
            txtItemId.Text = ItemId;
            _ItemId = ItemId;
            txtItemDesc.Text = DescItem;
            txtPzsPaq.Text = PzaPaq.ToString();
            numPiezas = PzaReq;
            piezaProg = PzaProg;
            piezasPendiente = PzaReq - PzaProg;
            _piezas = PzaPaq;
            _piezasPend = piezasPendiente;
            _SucursalId = _idSucursal;
            C_Despacho = new CDespacho();
            C_DespProg = new CDespProg();
            TraerData();
            DatosIniciales();
        }
        public void DatosIniciales()
        {
            txtNumPiezas.Text = numPiezas.ToString();
            txtPiezasProg.Text = piezaProg.ToString();
            txtPiezasPend.Text = piezasPendiente.ToString();
        }
        public void TraerData()
        {
            try
            {
                int _idLista = 0;
                DataSet dataLista = C_Despacho.TraerPaquetesCronograma(_SucursalId, _ItemId, _piezas);
                foreach (DataRow item in dataLista.Tables[0].Rows)
                {
                    _idLista++;
                    _listCron.Add(new DetalleCronograma
                    {
                        p_IdLista = _idLista,
                        p_CeldaId = item[0].ToString(),
                        p_StockPiezas = Convert.ToInt32(item[1]),
                        p_StockPaquetes = Convert.ToInt32(item[2]),
                        p_PlanPiezas = 0,
                        p_PlanPaquetes = 0,
                        p_Fecha = Convert.ToDateTime(item[3]),
                        p_Antiguedad = Convert.ToInt32(item[4])
                    });
                }
                this.gridControl1.DataSource = _listCron;

                DataSet dataProg = C_Despacho.TraerDespProg(_IdDespacho, _ItemId);
                if (dataProg.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow item in dataProg.Tables[0].Rows)
                    {
                        foreach (var itemlist in _listCron)
                        {
                            if (item[0].ToString() == itemlist.p_CeldaId)
                            {
                                int stckPzs = itemlist.p_StockPiezas - Convert.ToInt32(item[1]);
                                int plnPzs = Convert.ToInt32(item[1]);
                                int plnPaq = Convert.ToInt32(item[2]);
                                itemlist.p_StockPiezas = stckPzs;
                                itemlist.p_StockPaquetes = itemlist.p_StockPiezas / _piezas;
                                itemlist.p_PlanPiezas = plnPzs;
                                itemlist.p_PlanPaquetes = plnPaq;
                            }
                        }
                        for (int i = 0; i < gridView1.DataRowCount; i++)
                        {
                            ColumnView view = gridControl1.MainView as ColumnView;
                            var row = view.GetFocusedRow();

                            int stockPiezas = Convert.ToInt32(view.GetRowCellDisplayText(i, view.Columns[1]));
                            int stckPzs = stockPiezas - Convert.ToInt32(item[1]);
                            int stckPaq = stckPzs / _piezas;
                            int plnPzs = Convert.ToInt32(item[1]);
                            int plnPaq = Convert.ToInt32(item[2]);

                            if (view.GetRowCellDisplayText(i, view.Columns[0]).ToString() == item[0].ToString())
                            {
                                int rowHandle = gridView1.GetVisibleRowHandle(i);
                                gridView1.SelectRow(rowHandle);
                            }
                        }
                    }
                }
                _piezasPendTotal = piezasPendiente;
                _pzasXpaq = _piezas;
                // 
                DataSet dataListaSob = C_Despacho.TraerSobrantesCronograma(_SucursalId, _ItemId, _IdDespacho);
                foreach(DataRow items in dataListaSob.Tables[0].Rows)
                {
                    _listSob.Add(new DetalleSobrantes
                    {
                        p_CeldaId = items[0].ToString(),
                        p_Paquete = items[1].ToString(),
                        p_Piezas = Convert.ToInt32(items[2])
                    });
                }
                this.gridControl2.DataSource = _listSob;
                ////
                DataSet dataSob = C_Despacho.TraerSobProg(_IdDespacho, _ItemId);
                if (dataSob.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow item in dataSob.Tables[0].Rows)
                    {
                        for (int i = 0; i < gridView2.DataRowCount; i++)
                        {
                            ColumnView view = gridControl2.MainView as ColumnView;
                            var row = view.GetFocusedRow();

                            if (view.GetRowCellDisplayText(i, view.Columns[0]).ToString() == item[0].ToString())
                            {
                                int rowHandle = gridView2.GetVisibleRowHandle(i);
                                gridView2.SelectRow(rowHandle);
                            }
                        }
                    }
                }
            }
            catch(Exception err)
            {
                Console.WriteLine("######################### = " + err.ToString());
                XtraMessageBox.Show("Error al traer datos", "Error");
            }
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                ColumnView view = gridControl1.MainView as ColumnView;
                int[] selectedRowHandles = view.GetSelectedRows();
                if (selectedRowHandles.Length > 0)
                {
                    for (int i = 0; i < selectedRowHandles.Length; i++)
                    {
                        _listProgCelda.Add(new DespProgCelda
                        {
                            p_DespachoId = txtDespacho.Text,
                            p_ItemId = txtItemId.Text,
                            p_CeldaId = view.GetRowCellDisplayText(selectedRowHandles[i], view.Columns[0]),
                            p_Piezas = Convert.ToInt32(view.GetRowCellDisplayText(selectedRowHandles[i], view.Columns[3])),
                            p_Paquetes = Convert.ToInt32(view.GetRowCellDisplayText(selectedRowHandles[i], view.Columns[4])),
                            p_SucursalId = _SucursalId
                        });
                    }
                }
                ColumnView viewSob = gridControl2.MainView as ColumnView;
                int[] selectedRowHandlesSob = viewSob.GetSelectedRows();
                if(selectedRowHandlesSob.Length > 0)
                {
                    for(int i = 0; i < selectedRowHandlesSob.Length; i++)
                    {
                        _listProgSob.Add(new DespProgSob
                        {
                            p_DespachoId = txtDespacho.Text,
                            p_ItemId = txtItemId.Text,
                            p_PaqueteId = viewSob.GetRowCellDisplayText(selectedRowHandlesSob[i], viewSob.Columns[1]),
                            p_CeldaId = viewSob.GetRowCellDisplayText(selectedRowHandlesSob[i], viewSob.Columns[0]),
                            p_Piezas = Convert.ToDecimal(viewSob.GetRowCellDisplayText(selectedRowHandlesSob[i], viewSob.Columns[2])),
                            p_SucursalId = _SucursalId
                        });
                    }
                }
                //
                string sError = string.Empty;
                DataTable dtCelda = new DataTable();
                dtCelda.Columns.Add("p_DespachoId");
                dtCelda.Columns.Add("p_ItemId");
                dtCelda.Columns.Add("p_CeldaId");
                dtCelda.Columns.Add("p_Piezas");
                dtCelda.Columns.Add("p_Paquetes");
                dtCelda.Columns.Add("p_SucursalId");
                DataRow dr = null;
                foreach (var item in _listProgCelda)
                {
                    dr = dtCelda.NewRow(); // have new row on each iteration
                    dr["p_DespachoId"] = item.p_DespachoId;
                    dr["p_ItemId"] = item.p_ItemId;
                    dr["p_CeldaId"] = item.p_CeldaId;
                    dr["p_Piezas"] = item.p_Piezas;
                    dr["p_Paquetes"] = item.p_Paquetes;
                    dr["p_SucursalId"] = item.p_SucursalId;
                    dtCelda.Rows.Add(dr);
                }
                //------------------------//
                DataTable dtSob = new DataTable();
                dtSob.Columns.Add("p_DespachoId");
                dtSob.Columns.Add("p_ItemId");
                dtSob.Columns.Add("p_CeldaId");
                dtSob.Columns.Add("p_Piezas");
                dtSob.Columns.Add("p_PaqueteId");
                dtSob.Columns.Add("p_SucursalId");
                DataRow ds = null;
                foreach (var item in _listProgSob)
                {
                    ds = dtSob.NewRow(); // have new row on each iteration
                    ds["p_DespachoId"] = item.p_DespachoId;
                    ds["p_ItemId"] = item.p_ItemId;
                    ds["p_CeldaId"] = item.p_CeldaId;
                    ds["p_Piezas"] = item.p_Piezas;
                    ds["p_PaqueteId"] = item.p_PaqueteId;
                    ds["p_SucursalId"] = item.p_SucursalId;
                    dtSob.Rows.Add(ds);
                }

                DespProgCelda _progCelda = new DespProgCelda();


                if (C_DespProg.InsertarDespProg(dtCelda, dtSob) > 0)
                {
                    XtraMessageBox.Show("Programacion guardada", "Guardar");
                    this.Close();
                }
                else
                {
                    XtraMessageBox.Show("Problemas al insertar la programacion", "Guardar");
                    this.Close();
                }
            }
            catch (Exception err)
            {
                Console.WriteLine("######################### = " + err.ToString());
                XtraMessageBox.Show("Error al traer datos", "Error");
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            try
            {
                if (e.Action == CollectionChangeAction.Add)
                {
                    CheckEdit edit = sender as CheckEdit;

                    ColumnView view = gridControl1.MainView as ColumnView;
                    int[] row = view.GetSelectedRows();
                    if (row.Length > 0)
                    {
                        view.FocusedRowHandle = row[0];
                    }
                    int _piezasPend = Convert.ToInt32(txtPiezasPend.Text);
                    int _pzasXpaq = Convert.ToInt32(txtPzsPaq.Text);
                    int _cantStock = Convert.ToInt32(view.GetRowCellDisplayText(row[0], view.Columns[1]));
                    int _paqStock = Convert.ToInt32(view.GetRowCellDisplayText(row[0], view.Columns[2]));
                    int _cantPlan = Convert.ToInt32(view.GetRowCellDisplayText(row[0], view.Columns[3]));
                    int _paqPlan = Convert.ToInt32(view.GetRowCellDisplayText(row[0], view.Columns[4]));
                    //
                    int _cantAsacar = _cantStock - _piezasPend;
                   
                    if (_cantAsacar > 0)
                    { 
                        _cantStock = _cantStock - _piezasPend;
                        _paqStock = _cantStock / _pzasXpaq;
                        _cantPlan = _piezasPend;
                        _paqPlan = _piezasPend / _pzasXpaq;
                        view.SetRowCellValue(row[0], view.Columns[1], _cantStock);
                        view.SetRowCellValue(row[0], view.Columns[2], _paqStock);
                        view.SetRowCellValue(row[0], view.Columns[3], _cantPlan);
                        view.SetRowCellValue(row[0], view.Columns[4], _paqPlan);
                        txtPiezasProg.Text = (Convert.ToInt32(txtPiezasProg.Text) + _cantPlan).ToString();
                    }
                    else if (_cantAsacar < 0)
                    {
                        view.SetRowCellValue(row[0], view.Columns[1], 0);
                        view.SetRowCellValue(row[0], view.Columns[2], 0);
                        view.SetRowCellValue(row[0], view.Columns[3], _cantStock);
                        view.SetRowCellValue(row[0], view.Columns[4], _paqStock);
                        txtPiezasProg.Text = (Convert.ToInt32(txtPiezasProg.Text) + _cantStock).ToString();
                    }
                    else if (_cantAsacar == _cantStock)
                    {
                        view.SetRowCellValue(row[0], view.Columns[1], 0);
                        view.SetRowCellValue(row[0], view.Columns[2], 0);
                        view.SetRowCellValue(row[0], view.Columns[3], _cantPlan);
                        view.SetRowCellValue(row[0], view.Columns[4], _paqPlan);
                        txtPiezasPend.Text = (_piezasPend - _cantPlan).ToString();
                        txtPiezasProg.Text = (Convert.ToInt32(txtPiezasProg.Text) + _cantPlan).ToString();
                    }
                }
                else if (e.Action == CollectionChangeAction.Remove)
                {
                    ColumnView view = gridControl1.MainView as ColumnView;
                    var row = view.GetFocusedRow();
                    //if (row.Length > 0)
                    //{
                    //    view.FocusedRowHandle = row[0];
                    //}
                    int indexGrid = view.FocusedRowHandle;
                    int _piezasPend = Convert.ToInt32(txtPiezasPend.Text);
                    int _pzasXpaq = Convert.ToInt32(txtPzsPaq.Text);
                    int _cantStock = Convert.ToInt32(view.GetRowCellDisplayText(view.FocusedRowHandle, view.Columns[1]));
                    int _paqStock = Convert.ToInt32(view.GetRowCellDisplayText(view.FocusedRowHandle, view.Columns[2]));
                    int _cantPlan = Convert.ToInt32(view.GetRowCellDisplayText(view.FocusedRowHandle, view.Columns[3]));
                    int _paqPlan = Convert.ToInt32(view.GetRowCellDisplayText(view.FocusedRowHandle, view.Columns[4]));
                    //
                    int _cantAsacar = _cantStock - _piezasPend;

                    if (_cantAsacar > 0)
                    {
                        _cantStock = _cantStock + _cantPlan;
                        _paqStock = _cantStock / _pzasXpaq;
                        txtPiezasProg.Text = (Convert.ToInt32(txtPiezasProg.Text) - _cantPlan).ToString();
                        _cantPlan = 0;
                        _paqPlan = 0;
                        view.SetRowCellValue(view.FocusedRowHandle, view.Columns[1], _cantStock);
                        view.SetRowCellValue(view.FocusedRowHandle, view.Columns[2], _paqStock);
                        view.SetRowCellValue(view.FocusedRowHandle, view.Columns[3], _cantPlan);
                        view.SetRowCellValue(view.FocusedRowHandle, view.Columns[4], _paqPlan);

                    }
                    else if (_cantAsacar < 0)
                    {
                        _cantStock = _cantStock + _cantPlan;
                        _paqStock = _cantStock / _pzasXpaq;
                        txtPiezasProg.Text = (Convert.ToInt32(txtPiezasProg.Text) - _cantPlan).ToString();
                        _cantPlan = 0;
                        _paqPlan = 0;
                        view.SetRowCellValue(view.FocusedRowHandle, view.Columns[1], _cantStock);
                        view.SetRowCellValue(view.FocusedRowHandle, view.Columns[2], _paqStock);
                        view.SetRowCellValue(view.FocusedRowHandle, view.Columns[3], _cantPlan);
                        view.SetRowCellValue(view.FocusedRowHandle, view.Columns[4], _paqPlan);
                    }
                    else if (_cantAsacar == _cantStock)
                    {
                        _cantStock = _cantStock + _cantPlan;
                        _paqStock = _cantStock / _pzasXpaq;
                        txtPiezasProg.Text = (Convert.ToInt32(txtPiezasProg.Text) - _cantPlan).ToString();
                        _cantPlan = 0;
                        _paqPlan = 0;
                        view.SetRowCellValue(view.FocusedRowHandle, view.Columns[1], _cantStock);
                        view.SetRowCellValue(view.FocusedRowHandle, view.Columns[2], _paqStock);
                        view.SetRowCellValue(view.FocusedRowHandle, view.Columns[3], _cantPlan);
                        view.SetRowCellValue(view.FocusedRowHandle, view.Columns[4], _paqPlan); 
                    }
                }
                else if (e.Action == CollectionChangeAction.Refresh)
                {
                    DatosIniciales();
                }
                else
                {
                    DatosIniciales();
                }
            }
            catch (Exception err)
            {
                Console.WriteLine("######################### = " + err.ToString());
                Console.WriteLine("#########################Data = " + err.Data.ToString());
                Console.WriteLine("#########################Message = " + err.Message.ToString());
                Console.WriteLine("#########################Source = " + err.Source.ToString());
            }
        }
        private void gridView2_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            try
            {
                ColumnView view = gridControl1.MainView as ColumnView;
                var row = view.GetFocusedRow();
                int indexGrid = view.FocusedRowHandle;
                int _cantStock = Convert.ToInt32(view.GetRowCellDisplayText(indexGrid, view.Columns[2]));
                int _cantAsacar = _cantStock - _piezasPend;
                _piezasPend = Convert.ToInt32(txtPiezasPend.Text);
                if (e.Action == CollectionChangeAction.Add)
                {
                    if (_cantAsacar > 0)
                    {
                        _piezasPend = _piezasPend - _cantAsacar;
                        txtPiezasPend.Text = _piezasPend.ToString();
                    }
                    else if (_cantAsacar < 0)
                    {
                        _piezasPend = _piezasPend - _cantStock;
                        txtPiezasPend.Text = _piezasPend.ToString();
                    }
                    else if (_cantAsacar == _cantStock)
                    {
                        _piezasPend = _piezasPend - _cantAsacar;
                        txtPiezasPend.Text = _piezasPend.ToString();
                    }
                }
                else if (e.Action == CollectionChangeAction.Remove)
                {
                    _piezasPend = _piezasPend + _cantAsacar;
                    txtPiezasPend.Text = _piezasPend.ToString();
                }
            }
            catch (Exception err)
            {
                Console.WriteLine("######################### = " + err.ToString());
            }
        }
        ///////////////////////////////////////////////
        public class DetalleCronograma
        {
            private int IdLista;
            private string CeldaId;
            private int StockPiezas;
            private int StockPaquetes;
            private int PlanPiezas;
            private int PlanPaquetes;
            private DateTime Fecha;
            private int Antiguedad;

            public int p_IdLista
            {
                get { return IdLista; }
                set { IdLista = value; }
            }
            public string p_CeldaId
            {
                get { return CeldaId; }
                set { CeldaId = value; }
            }
            public int p_StockPiezas
            {
                get { return StockPiezas; }
                set { StockPiezas = value; }
            }
            public int p_StockPaquetes
            {
                get { return StockPaquetes; }
                set { StockPaquetes = value; }
            }
            public int p_PlanPiezas
            {
                get { return PlanPiezas; }
                set { PlanPiezas = value; }
            }
            public int p_PlanPaquetes
            {
                get { return PlanPaquetes; }
                set { PlanPaquetes = value; }
            }
            public DateTime p_Fecha
            {
                get { return Fecha; }
                set { Fecha = value; }
            }
            public int p_Antiguedad
            {
                get { return Antiguedad; }
                set { Antiguedad = value; }
            }
        }
        /////////////////////////////////////////
        public class DetalleSobrantes
        {
            private string CeldaId;
            private string Paquete;
            private int Piezas;

            public string p_CeldaId
            {
                get { return CeldaId; }
                set { CeldaId = value; }
            }
            public string p_Paquete
            {
                get { return Paquete; }
                set { Paquete = value; }
            }
            public int p_Piezas
            {
                get { return Piezas; }
                set { Piezas = value; }
            }
        }
    }
}