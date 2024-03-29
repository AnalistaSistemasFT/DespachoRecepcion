﻿using System;
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
using DevExpress.Utils.Extensions;
using CRN.Entidades;

namespace WFConsumo.frmGRH.Administradores
{
    public partial class DespachosPendientesGeneral : DevExpress.XtraEditors.XtraForm
    {
        CDespacho C_Despacho;
        int _idSucursal = 0;
        string _idDespacho = string.Empty;
        List<DetalleProducto> _lstProdDet = new List<DetalleProducto>();
        DataTable dataProd = new DataTable();
        CPaquetes C_Paquetes;
        DataTable dataDet = new DataTable();
        List<ItemEntrega> _listEntrega = new List<ItemEntrega>();
        private decimal _pesoTotal = 0;
        int _SucursalPick = 0;
        string _SucursalNombPick = string.Empty;

        public DespachosPendientesGeneral(int idSucursal)
        {
            InitializeComponent();
            C_Despacho = new CDespacho();
            C_Paquetes = new CPaquetes();
            TraerSucursales();
        }
        public void TraerSucursales()
        {
            try
            {
                DataSet data = C_Despacho.TraerDespachosPendientes();
                gridControl1.DataSource = data.Tables[0];

                string cont = C_Despacho.TraerTotalPendientesGeneral();
                txtTitulo.Text = "DESPACHOS PENDIENTES: " + cont;
            }
            catch(Exception err)
            {
                Console.WriteLine("######################## = " + err.ToString());
            }
        } 
        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                ColumnView view = this.gridControl1.MainView as ColumnView;
                int[] row = view.GetSelectedRows();
                view.FocusedRowHandle = row[0];
                _idDespacho = (view.GetRowCellDisplayText(row[0], view.Columns[2])).ToString();

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

                try
                {
                    ColumnView viewE = this.gridControl1.MainView as ColumnView;
                    int[] rowE = Convert.ToInt32(viewE.FocusedRowHandle).ToArray();
                    string dataRow = viewE.GetRowCellDisplayText(rowE[0], viewE.Columns[0]);
                    _idDespacho = dataRow;
                    GetDetalle();
                    gridView1.UpdateTotalSummary();
                }
                catch (Exception err)
                {
                    Console.WriteLine("####################### = " + err.ToString());
                }
            }
            catch (Exception err)
            {
                Console.WriteLine("###################### = " + err.ToString());
            }
        }
        private void GetDetalle()
        {
            try
            {
                int _conEntregas = 0;
                DataSet dataCont = C_Paquetes.ContEntregas(_idDespacho);
                foreach (DataRow item in dataCont.Tables[0].Rows)
                {
                    _conEntregas = Convert.ToInt32(item[0]);
                }
                if (_conEntregas == 0)
                {
                    DataSet dataListaA = C_Paquetes.BuscarPaqueteEntrega(_idDespacho);
                    dataDet = dataListaA.Tables[0];
                    this.gridControl4.DataSource = dataDet;
                    _listEntrega.Clear();
                    _pesoTotal = 0;
                    foreach (DataRow item in dataDet.Rows)
                    {
                        _listEntrega.Add(new ItemEntrega
                        {
                            p_ItemId = item[0].ToString(),
                            p_ItemFId = Convert.ToInt32(item[1]),
                            p_Descripcion = item[2].ToString(),
                            p_PaqueteId = item[3].ToString(),
                            p_UnidadMedida = item[4].ToString(),
                            p_Piezas = Convert.ToInt32(item[5]),
                            p_Peso = Convert.ToDecimal(item[6]),
                            p_PesoTotal = Convert.ToDecimal(item[7]),
                            p_Pendiente = Convert.ToInt32(item[8]),
                            p_Retirar = 0,
                            p_NombreDisplay = (item[0] + " - " + item[1] + " - " + item[2]).ToString()
                        });
                        _pesoTotal = _pesoTotal + Convert.ToDecimal(item[6]);
                    }
                }
                else
                {
                    DataSet dataLista = C_Paquetes.BuscarPaqueteEntregaConEntrega(_idDespacho);
                    dataDet = dataLista.Tables[0];
                    this.gridControl4.DataSource = dataDet;
                    _listEntrega.Clear();
                    _pesoTotal = 0;
                    foreach (DataRow item in dataDet.Rows)
                    {
                        _listEntrega.Add(new ItemEntrega
                        {
                            p_ItemId = item[0].ToString(),
                            p_ItemFId = Convert.ToInt32(item[1]),
                            p_Descripcion = item[2].ToString(),
                            p_PaqueteId = item[3].ToString(),
                            p_UnidadMedida = item[4].ToString(),
                            p_Piezas = Convert.ToInt32(item[5]),
                            p_Peso = Convert.ToDecimal(item[6]),
                            p_PesoTotal = Convert.ToDecimal(item[7]),
                            p_Pendiente = Convert.ToInt32(item[8]),
                            p_Retirar = 0,
                            p_NombreDisplay = (item[0] + " - " + item[1] + " - " + item[2]).ToString()
                        });
                        _pesoTotal = _pesoTotal + Convert.ToDecimal(item[6]);
                    }
                }
            }
            catch (Exception err)
            {
                Console.WriteLine("####################### = " + err.ToString());
            }
        }
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
        private void gridView5_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            ColumnView view = this.gridControl1.MainView as ColumnView;
            int[] row = view.GetSelectedRows();
            view.FocusedRowHandle = row[0];
            _SucursalPick = Convert.ToInt32(view.GetRowCellDisplayText(row[0], view.Columns[0]));
            _SucursalNombPick = view.GetRowCellDisplayText(row[0], view.Columns[1]);
            DataSet data = C_Despacho.TraerDespachosPendientes();
            gridControl1.DataSource = data.Tables[0];

            string cont = C_Despacho.TraerPendientesSucursal(_SucursalPick);
            txtCont.Text = _SucursalNombPick.Trim() + ": " + cont;
        }
    }
}