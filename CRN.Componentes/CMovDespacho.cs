using CAD;
using CRN.Entidades;
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
        List<string> listITemDespDet = new List<string>();
        public CMovDespacho()
        {
            this.sConnName = "SQLSERVER";
            C_Paquetes = new CPaquetes();
            C_DespProductos = new CDespProductos();
        }
        CADDespacho cadDespacho = new CAD.CADDespacho();
        CADInformix C_Informix = new CADInformix();

        public int CerrarDespacho(DataTable dtsDetalle, DataTable detPaqRoto, int _idSucursal, string DespachoId, int _idDestino, scentreg_inf _scent, DataTable dtsSCdetent)
        {
            string sError = string.Empty;
            int a = 0;
            _idDespacho = DespachoId;

            using (DbTransaction trnSql = this.IniciarTransaccion())
            {
                try
                {
                    a = InsertarMovSyn(DespachoId, DateTime.Now, "D1", DateTime.Now, "OPEN", "DESPACHO", _idSucursal, _idDestino, "0", "0", false, trnSql);
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
                                        a = ActualizarItemSucursal(ItemPV, _idSucursal, Cantidad, Peso, trnSql);
                                        
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
                            scdetent _detEnt = new scdetent();
                            a = ModificarEjecutarACerrar(DespachoId, trnSql);
                            if (a > 0)
                            {
                                a = C_Informix.InsertarSCEntrega(_scent, trnSql);
                                a = 1;
                                if (a > 0)
                                {
                                    for (int i = 0; i < dtsSCdetent.Rows.Count; i++)
                                    {
                                        _detEnt.p_scmvtdoc = Convert.ToDecimal(dtsSCdetent.Rows[i][0]);
                                        _detEnt.p_scmvndoc = Convert.ToDecimal(dtsSCdetent.Rows[i][1]);
                                        _detEnt.p_scmvnart = Convert.ToDecimal(dtsSCdetent.Rows[i][2]);
                                        _detEnt.p_scmvctra = Convert.ToDecimal(dtsSCdetent.Rows[i][3]);
                                        _detEnt.p_scmvfdoc = Convert.ToDateTime(dtsSCdetent.Rows[i][4]);
                                        _detEnt.p_scmvfreg = Convert.ToDateTime(dtsSCdetent.Rows[i][5]);
                                        _detEnt.p_scmvcsuc = Convert.ToDecimal(dtsSCdetent.Rows[i][6]);
                                        _detEnt.p_scmvcorr = Convert.ToInt32(dtsSCdetent.Rows[i][7]);
                                        _detEnt.p_scmvcmov = Convert.ToDecimal(dtsSCdetent.Rows[i][8]);
                                        _detEnt.p_scmvcant = Convert.ToDecimal(dtsSCdetent.Rows[i][9]);
                                        a = _detEnt.InsertarDetEntrega(trnSql);
                                        if (a == 0)
                                        { 
                                            //break;
                                        }
                                    }
                                    a = 1;
                                }
                                if(a > 0)
                                {
                                    trnSql.Commit();
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
                    else
                    {
                        trnSql.Rollback();
                    }
                    trnSql.Dispose();
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
        //DESPACHO POR AJUSTE
        public int DespachoPorAjuste(Despacho _despacho, DataTable dtsDetalle, DataTable dtsDespProd, int _idSucursal, string DespachoId, int _idDestino)
        {
            string sError = string.Empty;
            int a = 0;
            _idDespacho = DespachoId;

            using (DbTransaction trnSql = this.IniciarTransaccion())
            {
                try
                {
                    a = this.InsertDespacho(_despacho, trnSql);
                    if(a > 0)
                    {
                        DespDetalle _despDetalle = new DespDetalle();
                        DespProductos _despProd = new DespProductos();
                        if (dtsDetalle.Rows.Count == 0)
                        {
                            trnSql.Rollback();
                            return 0; 
                        }
                        else
                        {
                            for (int i = 0; i < dtsDetalle.Rows.Count; i++)
                            {
                                string _itmId = dtsDetalle.Rows[i][1].ToString();
                                if(listITemDespDet.Contains(_itmId))
                                {
                                    a = 1;
                                }
                                else
                                {
                                    _despDetalle.p_DespachoId = dtsDetalle.Rows[i][0].ToString();
                                    _despDetalle.p_ItemId = dtsDetalle.Rows[i][1].ToString();
                                    _despDetalle.p_Cantidad = Convert.ToDecimal(dtsDetalle.Rows[i][2]);
                                    _despDetalle.p_SolPiezasSueltas = Convert.ToInt32(dtsDetalle.Rows[i][3]);
                                    _despDetalle.p_ConfPiezasSueltas = Convert.ToInt32(dtsDetalle.Rows[i][4]);
                                    _despDetalle.p_CantConfirmada = Convert.ToDecimal(dtsDetalle.Rows[i][5]);
                                    _despDetalle.p_Unidad = dtsDetalle.Rows[i][6].ToString();
                                    _despDetalle.p_Status = dtsDetalle.Rows[i][7].ToString();
                                    _despDetalle.p_SucursalId = Convert.ToInt32(dtsDetalle.Rows[i][8]);
                                    a = _despDetalle.InsertarDespDetalle(trnSql);
                                    if (a == 0)
                                    {
                                        Console.WriteLine("%%%%%%%%%%%%%%%%%%%%%%%%%%%% = DespDetalle");
                                        break;
                                    }
                                    listITemDespDet.Add(_itmId);
                                } 
                            }
                            if (a > 0)
                            {
                                a = ActualizarSecuencia(_idSucursal, "DESPACHO", DespachoId, trnSql);
                                if (a > 0)
                                {
                                    CDespProductos c_ProdDesp = new CDespProductos();
                                    for (int i = 0; i < dtsDespProd.Rows.Count; i++)
                                    {
                                        _despProd.DespachoId = dtsDespProd.Rows[i][0].ToString();
                                        _despProd.ProductoId = dtsDespProd.Rows[i][1].ToString();
                                        _despProd.ItemId = dtsDespProd.Rows[i][2].ToString();
                                        _despProd.Fecha = Convert.ToDateTime(dtsDespProd.Rows[i][3]);
                                        _despProd.Status = dtsDespProd.Rows[i][4].ToString();
                                        _despProd.Cantidad = Convert.ToInt32(dtsDespProd.Rows[i][5]);
                                        _despProd.Peso = Convert.ToDecimal(dtsDespProd.Rows[i][6]);
                                        _despProd.CeldaId = dtsDespProd.Rows[i][7].ToString();
                                        _despProd.SucursalId = Convert.ToInt32(dtsDespProd.Rows[i][8].ToString());
                                        _despProd.ItemFId = dtsDespProd.Rows[i][9].ToString();
                                        _despProd.Piezas = Convert.ToInt32(dtsDespProd.Rows[i][10]);
                                        _despProd.Metros = Convert.ToDecimal(dtsDespProd.Rows[i][11]);
                                        _despProd.Colada = dtsDespProd.Rows[i][12].ToString();
                                        a = _despProd.InsertarDespProductos(trnSql);
                                        if (a == 0)
                                        {
                                            Console.WriteLine("%%%%%%%%%%%%%%%%%%%%%%%%%%%% = DespProductos");
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    trnSql.Rollback();
                                    Console.WriteLine("%%%%%%%%%%%%%%%%%%%%%%%%%%%% = ActualizarSecuencia");
                                }
                            }
                            else
                            {
                                trnSql.Rollback();
                                trnSql.Dispose();
                                Console.WriteLine("%%%%%%%%%%%%%%%%%%%%%%%%%%%% = DespDetalle");
                            }
                        }
                        if(a > 0)
                        {
                            a = InsertarMovSyn(DespachoId, DateTime.Now, "D1", DateTime.Now, "OPEN", "DESPACHO", _idSucursal, 0, "0", "0", false, trnSql);
                            if (a > 0)
                            {
                                for (int i = 0; i < dtsDespProd.Rows.Count; i++)
                                {
                                    int totalItems = dtsDespProd.Rows.Count;
                                    string ItemPV = dtsDespProd.Rows[i]["ItemId"].ToString();
                                    decimal dCantidad = Convert.ToDecimal(dtsDespProd.Rows[i]["Cantidad"].ToString());

                                    DataSet dtsItem = TraerItem(ItemPV);
                                    string ItemF = string.Empty;
                                    string PaqueteId = dtsDespProd.Rows[i]["ProductoId"].ToString();
                                    string NuevoEstado = "TOTAL";
                                    int Piezas = Convert.ToInt32(dtsDespProd.Rows[i]["Piezas"]);
                                    int Cantidad = Convert.ToInt32(dtsDespProd.Rows[i]["Cantidad"]);
                                    decimal Peso = Convert.ToDecimal(dtsDespProd.Rows[i]["Peso"]);
                                    string Calidad = "PRIMERA";
                                    string CeldaId = dtsDespProd.Rows[i]["CeldaId"].ToString();
                                    //string CentroTrabajo = dtsDetalle.Rows[i]["CentroTrabajo"].ToString();
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
                                        DataSet dtMov = C_DespProductos.DetMovDatosAjuste(_itemId);
                                        foreach (DataRow dat in dtMov.Tables[0].Rows)
                                        {
                                            ItemF = dat[0].ToString();
                                            _Piezas = Piezas;
                                            PesoTotal = PesoTotal + Peso;
                                            CantidadTotal = CantidadTotal + Cantidad;
                                            sUM = dat[1].ToString();
                                        }
                                        a = InsertarMovSynDet(DespachoId, ItemPV, ItemF, _Piezas, PesoTotal, 0, 0, 0, Calidad, CantidadTotal, sUM, 2, 0, trnSql);
                                        if (a > 0)
                                        {
                                            a = ActualizarCeldasDespacho(CeldaId, trnSql);
                                            if (a > 0)
                                            {
                                                a = ActualizarPaqueteDespacho(PaqueteId, NuevoEstado, Cantidad, Piezas, Peso, trnSql);
                                                if (a > 0)
                                                {
                                                    a = ActualizarItemSucursal(ItemPV, _idSucursal, Cantidad, Peso, trnSql);
                                                    if (a > 0)
                                                    {
                                                        trnSql.Commit();
                                                    }
                                                    else
                                                    {
                                                        trnSql.Rollback();
                                                        Console.WriteLine("%%%%%%%%%%%%%%%%%%%%%%%%%%%% = ActualizarItemSucursal");
                                                    }
                                                }
                                                else
                                                {
                                                    //trnSql.Rollback();
                                                    Console.WriteLine("%%%%%%%%%%%%%%%%%%%%%%%%%%%% = ActualizarPaqueteDespacho");
                                                }
                                            }
                                            else
                                            {
                                                //trnSql.Rollback();
                                                Console.WriteLine("%%%%%%%%%%%%%%%%%%%%%%%%%%%% = ActualizarCeldasDespacho");
                                            }
                                        }
                                        else
                                        {
                                            //trnSql.Rollback();
                                            Console.WriteLine("%%%%%%%%%%%%%%%%%%%%%%%%%%%% = InsertarMovSynDet");
                                        }
                                    }
                                    //
                                }
                                
                                if (a == 0)
                                {
                                    trnSql.Rollback();
                                    trnSql.Dispose();
                                }
                                return a; 
                            }
                            else
                            {
                                trnSql.Rollback();
                                Console.WriteLine("%%%%%%%%%%%%%%%%%%%%%%%%%%%% = InsertarMovSyn");
                            }
                        }
                        else
                        {
                            trnSql.Rollback();
                            Console.WriteLine("%%%%%%%%%%%%%%%%%%%%%%%%%%%% = DespProductos");
                        }
                    }
                    else
                    {
                        trnSql.Rollback();
                        Console.WriteLine("%%%%%%%%%%%%%%%%%%%%%%%%%%%% = InsertarDespacho");
                    }
                }
                catch (Exception err)
                {
                    //trnSql.Rollback();
                    //trnSql.Dispose();
                    Console.WriteLine("########################## = " + err.ToString());
                    return 0;
                }
            }
            return a;
        }
        //VENTA DESPACHO
        public int CerrarDespachoVenta(DataTable dtsDetalle, DataTable detPaqRoto, int _idSucursal, string DespachoId, DataTable dtsSCdetent)
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
            return ejecutar(ref sError, "UPDATE tblDespacho SET Status = 'CLOSE' WHERE DespachoId = '" + _IdDespacho + "'", trnProxy);
        }
        public int InsertarMovSyn(string OrdenId, DateTime Fecha, string CentroTrabajo, DateTime FechaCierre, string Status, string TipoOrden, int SucursalId, int SucursalDestino, string OrdenLigada, string ItemFLigado, bool EsDeCliente, DbTransaction trnProxy)
        {
            string sError = string.Empty;
            string sInsert = string.Empty;
            if (SucursalId == 12081 || SucursalId == 12071 )
            {
                string _statusElSys = "ELSYSTEM";
                sInsert = @"insert into tblMovSync ( OrdenId,    Fecha ,  CentroTrabajo, Status , TipoOrden ,  SucursalId,  SucursalDestino, EsDeCliente)
                        values('{0}','{1}','{2}','{3}','{4}',{5},{6},'{7}')";
                sInsert = string.Format(sInsert, OrdenId, Fecha.ToString("dd/MM/yyyy"), CentroTrabajo, _statusElSys, TipoOrden, SucursalId, 0, EsDeCliente);
            }
            else
            {
                sInsert = @"insert into tblMovSync ( OrdenId, Fecha , CentroTrabajo, Status , TipoOrden , SucursalId, SucursalDestino, EsDeCliente)
                            values('{0}','{1}','{2}','{3}','{4}',{5},{6},'{7}')";
                sInsert = string.Format(sInsert, OrdenId, Fecha.ToString("dd/MM/yyyy"), CentroTrabajo, Status, TipoOrden, SucursalId, 0, EsDeCliente);
            }
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
            Console.WriteLine("///////////////////// = " + sUpdate.ToString() + " -- " + sError);
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
        ///////////////////ITEM-SUCURSAL//////////////////////
        private DataSet TraerItem(string Item)
        {
            string sSelect = "select * from tblItem where ItemId = '{0}'";
            sSelect = string.Format(sSelect, Item);
            return this.consultar(sSelect);
        }
        public int ActualizarItemSucursal(string ItemId, int _idSucursal, int cantidad, decimal peso, DbTransaction trnProxy)
        {
            string sError = string.Empty;
            string sUpdate = @"update tblSucItem set Stock = Stock - " + cantidad + " , TotalSalidas = TotalSalidas + " + cantidad + " , Peso = Peso - " + peso + " where SucursalId = " + _idSucursal + " AND ItemId = '" + ItemId + "'";
            sUpdate = string.Format(sUpdate, ItemId);
            return ejecutar(ref sError, sUpdate, trnProxy);
        }
        public DataSet TrearCorrelativoCierre(int _idSucursal)
        {
            string sSelect = "select scmvndoc + 1 from scentreg where scticsuc = " + _idSucursal;
            return this.consultar(sSelect);
        }
        /////////////////INSERTAR-DESPACHO////////////////////
        public int InsertDespacho(Despacho _despacho, DbTransaction trnproxy)
        {
            string sError = string.Empty;
            string sInsert = @" INSERT INTO tblDespacho
                                    ([DespachoId],[Fecha],[NroOrden],[Id_Camion],[Placa],[Marca],[Chofer],[CI],[Destino],[Login],[status],[Correlativo],[Obs],[Tipo],[Cargador],[NumTraspaso],[SucursalId],[SucDestino],[HorarioPartida],[HorarioLlegada],[Naturaleza],[Anticipado], [Entregado])
                                VALUES
                                      ('{0}','{1}','{2}',{3},'{4}','{5}','{6}','{7}','{8}','{9}','{10}',{11},'{12}','{13}','{14}','{15}',{16},{17},{18},{19},'{20}',{21}, {22})";
            sInsert = string.Format(sInsert, _despacho.p_DespachoId, _despacho.p_Fecha.ToString("dd/MM/yyyy"), _despacho.p_NroOrden, _despacho.p_Id_Camion, _despacho.p_Placa, _despacho.p_Marca, _despacho.p_Chofer, _despacho.p_CI, _despacho.p_Destino, _despacho.p_Login, _despacho.p_status, _despacho.p_Correlativo, _despacho.p_Obs, _despacho.p_Tipo, _despacho.p_Cargador, _despacho.p_NumTraspaso, _despacho.p_SucursalId, _despacho.p_SucDestino, _despacho.p_HorarioPartida.ToString("dd/MM/yyyy"), _despacho.p_HorarioLlegada.ToString("dd/MM/yyyy"), _despacho.p_Naturaleza, _despacho.p_Anticipado, _despacho.p_Entregado);
            return ejecutar(ref sError, sInsert, trnproxy);
        }
        /////////////////ACTUALIZAR-SECUENCIA////////////////////
        public int ActualizarSecuencia(int iSucursal, string Operacion, string Contador, DbTransaction trnProxy)
        {
            string sError = string.Empty;
            string sUpdate = "update Sys_Secuencia set Contador = '" + Contador + "' where  sucursal=" + iSucursal + " and Operacion = '" + Operacion + "'";
            sUpdate = string.Format(sUpdate);
            return this.ejecutar(ref sError, sUpdate, trnProxy);
        }
    }
}
