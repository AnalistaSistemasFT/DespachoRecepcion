using CAD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace CRN.Componentes
{
    public class CMovDespacho : oledb
    {
        CPaquetes C_Paquetes;
        CDespProductos C_DespProductos;
        string _idDespacho = string.Empty;
        List<string> listItemMov = new List<string>();
        public CMovDespacho()
        {
            this.sConnName = "SQLSERVER";
            C_Paquetes = new CPaquetes();
            C_DespProductos = new CDespProductos();
        }
        CADDespacho cadDespacho = new CAD.CADDespacho();
        public int CerrarDespacho(DataTable dtsDetalle, DataTable detPaqRoto, int _idSucursal, string DespachoId)
        {
            string sError = string.Empty;
            int a = 0;
            _idDespacho = DespachoId;

            using (DbTransaction trnSql = this.IniciarTransaccion())
            {
                try
                {

                    a = InsertarMovSyn(DespachoId, DateTime.Now, "D1", DateTime.Now, "OPEN", "DESPACHO", _idSucursal, 0, "0", "0", false, trnSql);
                    if (a > 0)
                    {
                        for (int i = 0; i < dtsDetalle.Rows.Count; i++)
                        {
                            int totalItems = dtsDetalle.Rows.Count;
                            string ItemPV = dtsDetalle.Rows[i]["Codigo"].ToString();
                            decimal dCantidad = Convert.ToDecimal(dtsDetalle.Rows[i]["Cantidad"].ToString());

                            DataSet dtsItem = TraerItem(ItemPV);
                            string ItemF = string.Empty;
                            string PaqueteId = dtsDetalle.Rows[i]["Paquete"].ToString();
                            string NuevoEstado = dtsDetalle.Rows[i]["NuevoEstado"].ToString();
                            int Piezas = Convert.ToInt32(dtsDetalle.Rows[i]["Piezas"]);
                            int Cantidad = Convert.ToInt32(dtsDetalle.Rows[i]["Cantidad"]);
                            decimal Peso = Convert.ToDecimal(dtsDetalle.Rows[i]["Peso"]);
                            string Calidad = dtsDetalle.Rows[i]["Calidad"].ToString();
                            string CeldaId = dtsDetalle.Rows[i]["CeldaId"].ToString();
                            string CentroTrabajo = dtsDetalle.Rows[i]["CentroTrabajo"].ToString();
                            string sUM = string.Empty;

                            if (listItemMov.Contains(ItemPV))
                            {
                                a = 1;
                            }
                            else
                            {
                                listItemMov.Add(ItemPV);
                                decimal PesoTotal = 0;
                                decimal _Piezas = 0;
                                decimal CantidadTotal = 0;
                                string _itemId = ItemPV;
                                DataSet dtMov = C_DespProductos.DetMovDatos(_idDespacho, _itemId);
                                foreach (DataRow dat in dtMov.Tables[0].Rows)
                                {
                                    ItemF = dat[0].ToString();
                                    _Piezas = Convert.ToDecimal(dat[1]);
                                    PesoTotal = PesoTotal + Convert.ToDecimal(dat[2]);
                                    CantidadTotal = CantidadTotal + Convert.ToDecimal(dat[3]);
                                    sUM = dat[4].ToString();
                                }
                                a = InsertarMovSynDet(DespachoId, ItemPV, ItemF, _Piezas, PesoTotal, 0, 0, 0, Calidad, CantidadTotal, sUM, 2, 0, trnSql);
                            }
                            if (a > 0)
                            {
                                a = ActualizarCeldasDespacho(CeldaId, trnSql);
                                if (a > 0)
                                {
                                    a = ActualizarPaqueteDespacho(PaqueteId, NuevoEstado, Cantidad, Piezas, Peso, trnSql);
                                    if (a > 0)
                                    {
                                        if (NuevoEstado.ToUpper() == "PARCIAL")
                                        {
                                            //a = AgregarPaqueteRoto(PaqueteId, detPaqRoto, i, trnSql);
                                            //if (a > 0)
                                            //{

                                            //}
                                            //else
                                            //{
                                            //    //trnSql.Rollback();
                                            //}
                                        }
                                        else
                                        {
                                            //
                                        }
                                    }
                                    else
                                    {
                                        trnSql.Rollback();
                                    }
                                }
                                else
                                {
                                    trnSql.Rollback();
                                }
                            }
                            else
                            {
                                trnSql.Rollback();
                            }
                        }
                        if (a > 0)
                        {
                            a = ModificarEjecutarACerrar(DespachoId, trnSql);
                            if (a > 0)
                            {
                                trnSql.Commit();
                            }
                            else
                            {
                                trnSql.Rollback();
                            }
                        }
                    }
                    else
                    {
                        trnSql.Rollback();
                    }
                    //trnSql.Dispose();
                    return a;
                }
                catch (Exception err)
                {
                    trnSql.Rollback();
                    trnSql.Dispose();
                    Console.WriteLine("############################# = " + err.ToString());
                    return 0;
                }
            }
        }
        public int ModificarEjecutarACerrar(string _IdDespacho, DbTransaction trnProxy)
        {
            string sError = string.Empty;
            return ejecutar(ref sError, "UPDATE tblDespacho SET Status = 'TRANSITO' WHERE DespachoId = '" + _IdDespacho + "'", trnProxy);
            Console.WriteLine(sError.ToString());
        }
        public int InsertarMovSyn(string OrdenId, DateTime Fecha, string CentroTrabajo, DateTime FechaCierre, string Status, string TipoOrden, int SucursalId, int SucursalDestino, string OrdenLigada, string ItemFLigado, bool EsDeCliente, DbTransaction trnProxy)
        {
            string sError = string.Empty;
            string sInsert = @"insert into tblMovSync ( OrdenId,    Fecha ,  CentroTrabajo, Status , TipoOrden ,  SucursalId,  SucursalDestino, EsDeCliente)
                            values('{0}','{1}','{2}','{3}','{4}',{5},{6},'{7}')";
            sInsert = string.Format(sInsert, OrdenId, Fecha.ToString("dd/MM/yyyy"), CentroTrabajo, Status, TipoOrden, SucursalId, SucursalDestino, EsDeCliente);
            return ejecutar(ref sError, sInsert, trnProxy);
        }
        public int InsertarMovSynDet(string OrdenId, string ItemPV, string ItemF, decimal Piezas, decimal Peso, decimal Metros, decimal CostoUnitario, decimal PrecioTon, string Calidad, decimal Cantidad, string Unidad, int TipoMovimiento, decimal PorcDistribucion, DbTransaction trnProxy)
        {
            string sError = string.Empty;
            string sInsert = @"insert into tblMovSyncDet values('{0}','{1}','{2}',{3},{4},{5},{6},{7},'{8}',{9},'{10}','{11}',{12})";
            sInsert = string.Format(sInsert, OrdenId, ItemPV, ItemF, Piezas, Peso, Metros, CostoUnitario, PrecioTon, Calidad, Cantidad, Unidad, TipoMovimiento, PorcDistribucion);
            return ejecutar(ref sError, sInsert, trnProxy);
        }
        //////////////////////CELDAS//////////////////////////
        public int ActualizarCeldasDespacho(string sCelda, DbTransaction trnProxy)
        {
            string sError = string.Empty;
            string sUpdate = @"update tblCeldas set unidades=unidades+1 where celdaid='{0}'";
            sUpdate = string.Format(sUpdate, sCelda);
            return ejecutar(ref sError, sUpdate, trnProxy);
        }
        /////////////////////PAQUETES/////////////////////////
        public int ActualizarPaqueteDespacho(string PaqueteId, string NuevoEstado, int cantidad, int Piezas, decimal Peso, DbTransaction trnProxy)
        {
            string sError = string.Empty;
            string sUpdate = string.Empty;
            if (NuevoEstado.ToUpper() == "PARCIAL")
            {
                int _val = Piezas - cantidad;
                sUpdate = @"update tblPaquetes set Status = 'ACTIVO', Piezas = " + _val + ", Peso = " + Peso + " where PaqueteId = '{0}'";
                sUpdate = string.Format(sUpdate, PaqueteId);
            }
            else if (NuevoEstado.ToUpper() == "TOTAL")
            {
                sUpdate = @"update tblPaquetes set Status = 'INACTIVO' where PaqueteId = '{0}'";
                sUpdate = string.Format(sUpdate, PaqueteId);
            }
            return ejecutar(ref sError, sUpdate, trnProxy);
        }
        private DataSet TraerItem(string Item)
        {
            string sSelect = "select * from tblItem where ItemId = '{0}'";
            sSelect = string.Format(sSelect, Item);
            return this.consultar(sSelect);
        }
    }
}
