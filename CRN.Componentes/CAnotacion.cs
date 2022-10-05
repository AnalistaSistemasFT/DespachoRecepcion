using CAD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
namespace CRN.Componentes
{
    public class CAnotacion : oledb
    {
        private string AnotacionId;
        private DateTime Fecha;
        private string Chofer;
        private int Id_Camion;
        private string Placa;
        private string CI;
        private int Procedencia;
        private string Propietario;
        private string Login;
        private string Obs;
        private int Correlativo;
        private string Status;
        private int SucursalId;
        private string Tipo;
        private bool EsDeCliente;
        private string Manifiesto;

        public string AnotacionId1 { get => AnotacionId; set => AnotacionId = value; }
        public DateTime Fecha1 { get => Fecha; set => Fecha = value; }
        public string Chofer1 { get => Chofer; set => Chofer = value; }
        public int Id_Camion1 { get => Id_Camion; set => Id_Camion = value; }
        public string Placa1 { get => Placa; set => Placa = value; }
        public string CI1 { get => CI; set => CI = value; }
        public int Procedencia1 { get => Procedencia; set => Procedencia = value; }
        public string Propietario1 { get => Propietario; set => Propietario = value; }
        public string Login1 { get => Login; set => Login = value; }
        public string Obs1 { get => Obs; set => Obs = value; }
        public int Correlativo1 { get => Correlativo; set => Correlativo = value; }
        public string Status1 { get => Status; set => Status = value; }
        public int SucursalId1 { get => SucursalId; set => SucursalId = value; }
        public string Tipo1 { get => Tipo; set => Tipo = value; }
        public bool EsDeCliente1 { get => EsDeCliente; set => EsDeCliente = value; }
        public string Manifiesto1 { get => Manifiesto; set => Manifiesto = value; }

        public CAnotacion()
        {
            this.sConnName = "SQLSERVER";
        }

       
        public int InsertAnotacion(DbTransaction trnproxy)
        {
            string sError = string.Empty;
            string sInsert = @" INSERT INTO tblAnotacion
                                    ([AnotacionId],[Fecha],[Chofer],[Id_Camion],[Placa],[CI],[Procedencia],[Propietario],[Login],[Obs],[Correlativo],[Status],[SucursalId],[Tipo],[EsDeCliente],[Manifiesto])
                                VALUES
                                      ('{0}','{1}','{2}' ,{3},'{4}','{5}',{6},'{7}','{8}','{9}',{10},'{11}',{12},'{13}','{14}','{15}')";
            sInsert = string.Format(sInsert, AnotacionId, Fecha.ToString("dd/MM/yyyy"), Chofer, Id_Camion, Placa, CI, Procedencia, Propietario, Login, Obs, Correlativo, Status, SucursalId, Tipo, EsDeCliente, Manifiesto);
            return ejecutar(ref sError, sInsert, trnproxy);
        }

        public DataSet CargarAnotacionesPorEstado(string estado,int sucursal)
        {

            string sSelect = @"select AnotacionId,	Fecha,	Chofer,	Id_Camion,	Placa,	CI,	Procedencia,	Propietario,	Login,	Obs,	Correlativo,	Status,	SucursalId,	Tipo,	EsDeCliente,	Manifiesto
                                from tblAnotacion where Status = '{0}' AND SucursalId = {1} and Fecha >= '01-01-2022' order by Fecha desc";
            sSelect = string.Format(sSelect, estado,sucursal);
            return this.consultar(sSelect);
        }

        public DataSet TraerItemPlanta(string item)
        {
            string sSelect = @"select * from tblItem where ItemFId = '{0}'";
            sSelect = string.Format(sSelect, item);
            return this.consultar(sSelect);
        }


        public int InsertarAnotacion(out string sError,DataTable dtsDetalle,string celda,string login,int isucursal,int ialmacen)
        {
            sError = string.Empty;
            using (DbTransaction trnSql = this.IniciarTransaccion())
            {
                SysSecuencia osecuencia = new SysSecuencia();
                string sAnotacion = osecuencia.TraerSecuencia(isucursal, "ANOTACION",trnSql);
               
                int a = this.InsertAnotacion(trnSql);
                if (a > 0)
                {
                    CAnotacionDet oAnotDet = new CAnotacionDet();
                    for(int i = 0;i< dtsDetalle.Rows.Count; i++)
                    {
                        string sPaquete = osecuencia.TraerSecuencia(isucursal, "PAQUETE",trnSql);
                        oAnotDet.CodigoBarra1 = sPaquete;
                        oAnotDet.AnotacionId1 = sAnotacion;
                        oAnotDet.Fabricante1 = this.Propietario1;
                        oAnotDet.ItemId1 = dtsDetalle.Rows[i]["ItemId"].ToString();
                        oAnotDet.Piezas1 = Convert.ToInt32(dtsDetalle.Rows[i]["Piezas"].ToString());
                        oAnotDet.Peso1 = Convert.ToDecimal(dtsDetalle.Rows[i]["Peso"].ToString());
                        oAnotDet.Colada1 = dtsDetalle.Rows[i]["Colada"].ToString();
                        oAnotDet.SucursalId1 = isucursal;
                        oAnotDet.AlmacenId1 = ialmacen;
                        oAnotDet.CeldaId1 =celda;
                        oAnotDet.Fecha1 = DateTime.Now;
                        oAnotDet.Correlativo1 = i+1;
                        oAnotDet.Login1 =login;
                        oAnotDet.Status1 = "OPEN";
                        oAnotDet.CodPackList1 = dtsDetalle.Rows[i]["CodPackList"].ToString();
                        oAnotDet.PesoNetoProveedor1 = Convert.ToDecimal(dtsDetalle.Rows[i]["PesoNetoProveedor"].ToString());
                        oAnotDet.PesoBrutoProveedor1 = Convert.ToDecimal(dtsDetalle.Rows[i]["PesoBrutoProveedor"].ToString());
                        oAnotDet.EsDeCliente1 = this.EsDeCliente1;
                        oAnotDet.Sincronizado1 = false;
                        DateTime dFechaCaducidad = DateTime.Now.AddMonths(12);
                        if (!string.IsNullOrEmpty(dtsDetalle.Rows[i]["FechaCaducidad"].ToString()))
                            dFechaCaducidad = Convert.ToDateTime(dtsDetalle.Rows[i]["FechaCaducidad"].ToString());
                        oAnotDet.FechaCaducidad1 = dFechaCaducidad;
                        a = oAnotDet.InsertAnotacionDet(out sError, trnSql);
                        if (a > 0) { 
                           a =  osecuencia.ActualizarSecuencia(isucursal, "PAQUETE", sPaquete,trnSql);
                            if (a == 0)
                                break;
                        }
                    }
                    if(a>0)
                    {
                       a= osecuencia.ActualizarSecuencia(isucursal, "ANOTACION", sAnotacion,trnSql);
                        if (a > 0)
                        {
                            trnSql.Commit();
                        }
                        else
                            trnSql.Rollback();
                    }
                    else
                        trnSql.Rollback();
                    trnSql.Dispose();
                }
                return a;
            }
        }

        public int InsertarMovimientos(out string sError, DataTable dtsDetalle,DataTable dtsDetalle2, string login, int isucursal, int ialmacen, string sRecepcion,string Documento,int SucOri,int SucDes)
        {

            
            sError = string.Empty;
            int a = 0;
            using (DbTransaction trnSql = this.IniciarTransaccion("SQLSERVER"))
            {
                DbTransaction trnInf = this.IniciarTransaccion("FTINF");
                try
                {
                    SysSecuencia osecuencia = new SysSecuencia();
                    a = ActualizarEstadoRecepcion(sRecepcion, "CLOSE", trnSql);
                    if (a > 0)
                    {
                        a = InsertarMovSyn(sRecepcion, DateTime.Now, "R1", DateTime.Now, "ELSYSTEM", "RECEPCION", SucDes, 0, "0", "0", false, trnSql);
                        if (a > 0)
                        {
                            string sMovimiento = osecuencia.TraerSecuencia(isucursal, "MOVIMIENTO", trnSql);
                            a = InsertarMovimiento(sMovimiento, DateTime.Now, "MOV001001", sRecepcion, login, "SYNC", SucDes, SucOri, 0, "rec-int", SucOri, trnSql);
                            if (a > 0)
                            {
                                a = InsertarMovPdv(sMovimiento, DateTime.Now, "MOV001001", sRecepcion, login, "SYNC", SucDes, SucOri, "S/O", "0", "0", SucOri, trnInf);
                                if (a > 0) 
                                { 
                                    for (int i = 0; i < dtsDetalle.Rows.Count; i++)
                                    {
                                        string sItemPdv = dtsDetalle.Rows[i]["ItemId"].ToString();
                                        decimal dCantidad = Convert.ToDecimal(dtsDetalle.Rows[i]["Cantidad"].ToString());
                                        string sUM = dtsDetalle.Rows[i]["Unidad"].ToString();
                                        DataSet dtsItem = TraerItem(sItemPdv);
                                        string ItemF = string.Empty;
                                        if (dtsItem.Tables[0].Rows.Count > 0)
                                            ItemF = dtsItem.Tables[0].Rows[0]["ItemFId"].ToString();
                                        else
                                        {
                                            a = 0;
                                            break;
                                        }
                                        a = InsertarMovSynDet(sRecepcion, sItemPdv, ItemF, 0, dCantidad, 0, 0, 0, "", dCantidad, sUM, 1, 0, trnSql);
                                        if (a > 0)
                                        {
                                            a = InsertarMovimientoDetalle(sMovimiento, sItemPdv, 0, 0, dCantidad, 0, SucDes, ItemF, sUM, 0, "", 0, 0, trnSql);
                                            if (a > 0)
                                            {
                                                a = InsertarMovDetPdv(sMovimiento, sItemPdv, dCantidad, 0, SucDes, ItemF, sUM, 0, "", 0, trnInf);
                                                if (a > 0)
                                                {
                                                    a = VerificarItenSucursal(sItemPdv, dCantidad, SucDes, trnSql);
                                                    if (a == 0)
                                                        break;
                                                }
                                                else
                                                    break;
                                            }
                                            else
                                                break;
                                        }
                                        else
                                            break;

                                    }
                                }
                            }
                            if (a > 0)
                            {
                                a = osecuencia.ActualizarSecuencia(isucursal, "MOVIMIENTO", sMovimiento, trnSql);
                                if (a > 0)
                                {
                                    DataSet dtsDetalleProd = TraerRecepcionDetProd(sRecepcion);
                                    for (int i = 0; i < dtsDetalleProd.Tables[0].Rows.Count; i++)
                                    {
                                        string sProducto = dtsDetalleProd.Tables[0].Rows[i]["ProductoId"].ToString();
                                        string Item = dtsDetalleProd.Tables[0].Rows[i]["ItemId"].ToString();
                                        decimal Piezas = Convert.ToDecimal(dtsDetalleProd.Tables[0].Rows[i]["Piezas"].ToString());
                                        decimal Peso = Convert.ToDecimal(dtsDetalleProd.Tables[0].Rows[i]["Peso"].ToString());
                                        string Colada = dtsDetalleProd.Tables[0].Rows[i]["Colada"].ToString();
                                        int SucursalId = Convert.ToInt32(dtsDetalleProd.Tables[0].Rows[i]["SucursalId"].ToString());
                                        int AlmacenId = Convert.ToInt32(dtsDetalleProd.Tables[0].Rows[i]["AlmacenId"].ToString());
                                        string CeldaId = dtsDetalleProd.Tables[0].Rows[i]["CeldaId"].ToString();

                                        int Correlativo = Convert.ToInt32(dtsDetalleProd.Tables[0].Rows[i]["Correlativo"].ToString());
                                        string CodPackList = dtsDetalleProd.Tables[0].Rows[i]["CodPackList"].ToString();
                                        decimal PesoNetoProveedor = Convert.ToDecimal(dtsDetalleProd.Tables[0].Rows[i]["PesoNetoProveedor"].ToString());
                                        decimal PesoBrutoProveedor = Convert.ToDecimal(dtsDetalleProd.Tables[0].Rows[i]["PesoBrutoProveedor"].ToString());
                                        int Id_TipoObservacion = Convert.ToInt32(dtsDetalleProd.Tables[0].Rows[i]["Id_TipoObservacion"].ToString());
                                        bool EsDeCliente = Convert.ToBoolean(dtsDetalleProd.Tables[0].Rows[i]["EsDeCliente"].ToString());

                                        DateTime FechaVec = Convert.ToDateTime(dtsDetalleProd.Tables[0].Rows[i]["FechaVenc"].ToString());

                                        a = InsertarPaquete(sProducto, SucursalId, AlmacenId, DateTime.Now, CeldaId, 0, Item, "0", login, "ACTIVO", Peso, Piezas, 0, sRecepcion, "0", Colada, "R1", FechaVec, trnSql);
                                        if (a > 0)
                                        {
                                            a = updateCelda(CeldaId, SucursalId, AlmacenId, Item, trnSql);
                                            if (a == 0)
                                                break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (a > 0)
                    {
                        trnSql.Commit();
                        trnInf.Commit();
                    }
                    else
                    {
                        trnInf.Rollback();
                        trnSql.Rollback();
                    }
                    trnSql.Dispose();
                    trnInf.Dispose();
                    return a;
                }
                catch(Exception ex)
                {
                    trnInf.Rollback();
                    trnSql.Rollback();
                    trnSql.Dispose();
                    trnInf.Dispose();
                    return 0;
                }
            }
        }

        public DataSet TraerRecepcionDetProd(string Recepcion)
        {
            string consulta = @"select * from tblRecepcionProductos where RecepcionId = '{0}'";
            consulta = string.Format(consulta, Recepcion);
            return this.consultar(consulta, "SQLSERVER");
        }

        public DataSet ReporteRecepcionDetalle(string Recepcion)
        {
            string consulta = @"select R.RecepcionId, R.Fecha, R.Chofer, R.Id_Camion, R.Placa, R.CI, R.Propietario, R.Login, R.Obs, R.Status, R.SucursalId, S.Nombre SUCURSAL, R.SucOrigen, S1.Nombre SUCURSALORI, R.Manifiesto,
                                    D.ProductoId, D.ItemId, I.Descripcion, D.Fabricante, D.AlmacenId, D.CeldaId, D.Correlativo, D.CodPackList, D.Colada, D.PesoBrutoProveedor, D.PesoNetoProveedor, D.Peso, I.UnidadF,d.Piezas
                                    from tblRecepcion r inner join
                                     tblRecepcionProductos d on r.RecepcionId = d.RecepcionId inner join
                                     tblItem i on d.ItemId = i.ItemId inner join
                                     tblSucursal s on r.SucursalId = s.SucursalID inner join
                                     tblSucursal s1 on r.SucOrigen = s1.SucursalID
                                    where r.RecepcionId = '{0}'";
            consulta = string.Format(consulta, Recepcion);
            return this.consultar(consulta, "SQLSERVER");
        }

        
        private DataSet TraerItem(string Item)
            {
                string sSelect = "select * from tblItem where ItemId = '{0}'";
                sSelect = string.Format(sSelect, Item);
                return this.consultar(sSelect, "SQLSERVER");
            }

        private int VerificarItenSucursal(string Item,decimal dCantidad, int iSucursal,DbTransaction trnProxy)
        {
            string sError = string.Empty;
            string sSelect = "select * from tblSucItem where ItemId = '{0}' and SucursalId = {1}";
            sSelect = string.Format(sSelect, Item,iSucursal);
            DataSet dts = this.consultar(sSelect,"SQLSERVER");
            int a = 0;
            string sQuery = string.Empty;
            if (dts.Tables[0].Rows.Count == 0)
            {
                sQuery = "insert into tblSucItem values({0},'{1}',{2},{3},{4},{5},{6},{7},{8},{9},{10},{11})";
                sQuery = string.Format(sQuery, iSucursal, Item, dCantidad, 0, 0, 0, 0, 0, 0, 0, dCantidad, 0);
            }
            else
            {
                decimal dstock = Convert.ToDecimal(dts.Tables[0].Rows[0]["Stock"].ToString())+dCantidad;
                decimal dTotalEn = Convert.ToDecimal(dts.Tables[0].Rows[0]["TotalEntradas"].ToString())+dCantidad;
                sQuery = "update tblSucItem set Stock = {0},TotalEntradas = {1} where ItemId = '{2}' and SucursalId = {3}";
                sQuery = string.Format(sQuery, dstock, dTotalEn, Item, iSucursal);
            }
            a = this.ejecutar(ref sError, sQuery, trnProxy);
            return a;
        }
        public int ActualizarEstadoRecepcion(string srecepcion, string estado, DbTransaction trnProxy)
        {
            string sError = string.Empty;
            string consulta = @"update tblRecepcion set Status = '{0}' where RecepcionId = '{1}'";
            consulta = string.Format(consulta, estado, srecepcion);
            return this.ejecutar(ref sError,consulta, trnProxy);
        }
        public int UpdateAnotacion(string Anotacion, string status,DbTransaction trnProxy)
        {
            string sError = string.Empty;
            string sInsert = @"update tblAnotacion set  Status = '{0}' where AnotacionId = '{1}'";
            sInsert = string.Format(sInsert, status, Anotacion);
            return ejecutar(ref sError, sInsert,trnProxy);
        }
        public int UpdateDespacho(string Despacho, string status,DbTransaction trnProxy)
        {
            string sError = string.Empty;
            string sInsert = @"update  tblDespacho set  status = '{2}',HorarioLlegada = '{0}' where DespachoId = '{1}'";
            sInsert = string.Format(sInsert, DateTime.Now.ToString("dd/MM/yyyy"), Despacho,status);
            return ejecutar(ref sError, sInsert, trnProxy);
        }

        public int InsertarProcesoRecepcion(out string sError, DataTable dtsDetalle, string AnotacionId,DateTime Fecha, string Chofer, int Id_Camion, string Placa, string CI, string Propietario, string Login, string Obs,
                int Correlativo, string Status, int SucursalId, int SucOrigen, string Documento, int Fuente, Boolean EsDeCliente, string Manifiesto, string Barco, int Id_Pais, string BL, int ProveedorId,int iAlmacen)
        {
            
            sError = string.Empty;
            using (DbTransaction trnSql = this.IniciarTransaccion())
            {
                try
                {
                    SysSecuencia osecuencia = new SysSecuencia();
                    string sRecepcion = osecuencia.TraerSecuencia(SucursalId, "RECEPCION", trnSql);

                    int a = this.InsertarRecepcion(sRecepcion, Fecha, Chofer, Id_Camion, Placa, CI, Propietario, Login, Obs, Correlativo, Status, SucursalId, SucOrigen, AnotacionId, Fuente, EsDeCliente, Manifiesto, Barco, Id_Pais, BL, ProveedorId, trnSql);
                    if (a > 0)
                    {
                         DataSet dtsDetalleProductos = TaerDetalleAnotacion(AnotacionId, Fuente);
                       
                        for (int i = 0; i < dtsDetalleProductos.Tables[0].Rows.Count; i++)
                        {
                            a = InsertarRecepcionDetalle(sRecepcion, dtsDetalleProductos.Tables[0].Rows[i]["ItemId"].ToString(), Convert.ToDecimal(dtsDetalleProductos.Tables[0].Rows[i]["Peso"].ToString()), dtsDetalleProductos.Tables[0].Rows[i]["UnidadCalculo"].ToString(), "OPEN", SucursalId, trnSql);
                            if (a == 0)
                                break;

                        }
                        if (a > 0)
                        {
                            for (int i = 0; i < dtsDetalle.Rows.Count; i++)
                            {
                                if(Fuente == 1) 
                                { 
                                    if(dtsDetalle.Rows[i]["Status"].ToString().Trim() != "ANULADO") 
                                    { 
                                        string CodigoBarra = dtsDetalle.Rows[i]["CodigoBarra"].ToString();
                                        string Fabricante = dtsDetalle.Rows[i]["Fabricante"].ToString();
                                        string ItemId = dtsDetalle.Rows[i]["ItemId"].ToString();
                                        int Pieza = Convert.ToInt32(dtsDetalle.Rows[i]["Piezas"].ToString());
                                        decimal Peso = Convert.ToDecimal(dtsDetalle.Rows[i]["Peso"].ToString());
                                        string Colada = dtsDetalle.Rows[i]["Colada"].ToString();
                                        string Celda = dtsDetalle.Rows[i]["CeldaId"].ToString();
                                        int Correlativod = Convert.ToInt32(dtsDetalle.Rows[i]["Correlativo"].ToString());
                                        string Logind = dtsDetalle.Rows[i]["Login"].ToString();
                                        string CodPackin = dtsDetalle.Rows[i]["CodPackList"].ToString();
                                        decimal PesoNeto = Convert.ToDecimal(dtsDetalle.Rows[i]["PesoNetoProveedor"].ToString());
                                        decimal PesoBruto = Convert.ToDecimal(dtsDetalle.Rows[i]["PesoBrutoProveedor"].ToString());
                                        DateTime FechaVenc = Convert.ToDateTime(dtsDetalle.Rows[i]["FechaCaducidad"].ToString());
                                        a = InsertarRecepcionProductos(sRecepcion, CodigoBarra, Fabricante, ItemId, Pieza, Peso, Colada, SucursalId, iAlmacen, Celda, DateTime.Now, Correlativod, Login, "OPEN", CodPackin, PesoNeto, PesoBruto, false, 0, FechaVenc, trnSql);
                                        if (a == 0)
                                            break;
                                    }
                                }
                                else
                                {
                                    string ProductoId= dtsDetalle.Rows[i]["ProductoId"].ToString();
                                    string ItemId= dtsDetalle.Rows[i]["ItemId"].ToString();
                                    decimal Cantidad= Convert.ToDecimal(dtsDetalle.Rows[i]["Cantidad"].ToString());
                                    string ItemFId= dtsDetalle.Rows[i]["ItemFId"].ToString();
                                    string Colada= dtsDetalle.Rows[i]["Colada"].ToString();
                                    string sCelda = TraerCeldaAsignada(ItemId, SucursalId);
                                    DateTime FechaVenc = TraerFecaVencimineto(ProductoId, SucOrigen);
                                    if (!string.IsNullOrEmpty(sCelda)) { 
                                    a = InsertarRecepcionProductos(sRecepcion, ProductoId, "", ItemId, Convert.ToInt32(Cantidad), Cantidad, Colada, SucursalId, iAlmacen, sCelda, DateTime.Now, i, Login, "OPEN", Colada, Cantidad, Cantidad, false, 0,FechaVenc, trnSql);
                                    if (a == 0)
                                        break;
                                    }
                                    else
                                    {
                                        a = 0;
                                        break;
                                    }
                                }

                            }
                            if (a > 0)
                            {
                                
                                    a = osecuencia.ActualizarSecuencia(SucursalId, "RECEPCION", sRecepcion, trnSql);

                                if (a > 0)
                                {
                                    if(Fuente == 1)
                                        a = UpdateAnotacion(AnotacionId, "CLOSE", trnSql);
                                    else
                                        a = UpdateDespacho(AnotacionId, "CLOSE",trnSql);

                                }
                            }
                        }
                        if (a > 0)
                        {
                            trnSql.Commit();
                        }
                        else
                            trnSql.Rollback();
                        trnSql.Dispose();
                    }
                    return a;
                }

            catch(Exception e)
                {
                    trnSql.Rollback();
                    trnSql.Dispose();
                    throw e;
                }
            }
        }
        
        private string TraerCeldaAsignada(string Item, int Sucursal)
        {
            string sSelect = @"select top(1) c.CeldaId from tblItem i inner join 
                                [dbo].[tblCatNaturaleza] n on i.Presentacion = n.NaturalezaId inner join 
                                tblCeldas c on n.ItemId = c.ItemId
                                 where i.ItemId = '{0}' and c.SucursalId = {1} order by c.Unidades asc";
            sSelect = string.Format(sSelect, Item, Sucursal);
            DataSet dtsCelda = this.consultar(sSelect);
            string sCelda = string.Empty;
            if (dtsCelda.Tables[0].Rows.Count > 0)
                sCelda = dtsCelda.Tables[0].Rows[0]["CeldaId"].ToString();
            return sCelda;
        }
        private DateTime TraerFecaVencimineto(string PaqueteId, int Sucursal)
        {
            string sSelect = @" select * from tblPaquetes where PaqueteId = '{0}' and SucursalId = {1}";
            sSelect = string.Format(sSelect, PaqueteId, Sucursal);
            DataSet dtsCelda = this.consultar(sSelect);
            DateTime FechaVenc = DateTime.Now.AddMonths(6);
            if (dtsCelda.Tables[0].Rows.Count > 0)
            {
                if(!string.IsNullOrEmpty(dtsCelda.Tables[0].Rows[0]["FechaVenc"].ToString()))
                FechaVenc = Convert.ToDateTime(dtsCelda.Tables[0].Rows[0]["FechaVenc"].ToString());
            }
                
            return FechaVenc;
        }
        public DataSet TaerDetalleAnotacion(string Anotacion, int iFuente)
        {
            string sSelect = string.Empty;
            if (iFuente == 1) { 
                sSelect = @"select d.ItemId, sum(PesoNetoProveedor) Peso, i.UnidadCalculo
                             from tblAnotacionDet d inner join
                             tblItem i on d.ItemId = i.ItemId
                              where AnotacionId = '{0}' and d.Status !='ANULADO'
                              group by d.ItemId, i.UnidadCalculo";
            }
            else
                sSelect = @"select d.ItemId,sum(Cantidad) Peso,i.UnidadCalculo
                            from tblDespProductos d inner join 
                            tblItem i on d.ItemId = i.ItemId
                            where DespachoId = '{0}'
                            group by d.ItemId,i.UnidadCalculo";
            sSelect = string.Format(sSelect, Anotacion);
            return this.consultar(sSelect);
        }

        
        public int InsertarRecepcion(string RecepcionId, DateTime Fecha, string Chofer, int Id_Camion, string Placa, string CI, string Propietario, string Login, string Obs,
                int Correlativo, string Status, int SucursalId, int SucOrigen, string Documento, int Fuente, Boolean EsDeCliente, string Manifiesto, string Barco, int Id_Pais, string BL, int ProveedorId, DbTransaction trnProxy)
        {
            string sError = string.Empty;
            string sInsert = @"insert into tblRecepcion 
                                (RecepcionId,Fecha,Chofer,Id_Camion,Placa,CI,Propietario,Login,Obs,Correlativo,Status,SucursalId,SucOrigen,Documento,Fuente,EsDeCliente,Manifiesto,Barco,Id_Pais,BL,ProveedorId)
                                values('{0}','{1}','{2}',{3},'{4}','{5}','{6}','{7}','{8}',{9},'{10}',{11},{12},'{13}',{14},'{15}','{16}','{17}',{18},'{19}',{20})";
            sInsert = string.Format(sInsert, RecepcionId, Fecha.ToString("dd/MM/yyyy"), Chofer, Id_Camion, Placa, CI, Propietario, Login, Obs, Correlativo, Status, SucursalId, SucOrigen, Documento, Fuente, EsDeCliente, Manifiesto, Barco, Id_Pais, BL, ProveedorId);
            return ejecutar(ref sError, sInsert, trnProxy);
        }
        public int InsertarRecepcionDetalle(string RecepcionId, string sItem, decimal Cantidad, string sUm, string sTatus, int sucursal, DbTransaction trnProxy)
        {
            string sError = string.Empty;
            string sInsert = @"insert into tblRecepcionDetalle 
                                (RecepcionId,ItemId,Cantidad,Unidad,Status,SucursalId)
                                values('{0}','{1}',{2},'{3}','{4}',{5})";
            sInsert = string.Format(sInsert, RecepcionId, sItem, Cantidad, sUm, sTatus, sucursal);
            return ejecutar(ref sError, sInsert, trnProxy);
        }
        public int InsertarRecepcionProductos(string RecepcionId, string ProductoId, string Fabricante, string ItemId, int Piezas, decimal Peso, string Colada, int SucursalId, int AlmacenId, string CeldaId, DateTime Fecha, int Correlativo, string Login, string Status, string CodPackList, decimal PesoNetoProveedor, decimal PesoBrutoProveedor, bool EsDeCliente, int Id_TipoObservacion, DateTime FechaVenc, DbTransaction trnProxy)
        {
            string sError = string.Empty;
            string sInsert = @"INSERT INTO tblRecepcionProductos(RecepcionId,ProductoId,Fabricante,ItemId,Piezas,Peso,Colada,SucursalId,AlmacenId,CeldaId,Fecha,Correlativo,Login,Status
           ,CodPackList,PesoNetoProveedor,PesoBrutoProveedor,EsDeCliente,Id_TipoObservacion,FechaVenc)
            VALUES('{0}','{1}','{2}','{3}',{4},{5},'{6}',{7},{8},'{9}','{10}',{11},'{12}','{13}','{14}',{15},{16},'{17}',{18},'{19}')";
            sInsert = string.Format(sInsert, RecepcionId, ProductoId, Fabricante, ItemId, Piezas, Peso, Colada, SucursalId, AlmacenId, CeldaId, Fecha.ToString("dd/MM/yyyy"), Correlativo, Login, Status, CodPackList, PesoNetoProveedor, PesoBrutoProveedor, EsDeCliente, Id_TipoObservacion, FechaVenc.ToString("dd/MM/yyyy"));
            return ejecutar(ref sError, sInsert, trnProxy);
        }

        public int InserRecepcioInt(int iccarga, int itipodoc, int inrodoc, DateTime dtFechaReg, DateTime dtFechaDoc, string sAnotacion, string sRecepcion, DbTransaction trnProxy)
        {
            string sError = string.Empty;
            return this.ejecutar(ref sError,string.Format(@"INSERT INTO tblRecepcionInt(iccarga_id,itipodoc,inrodoc,dtfecha_reg,dtfecha_doc,sanotacionid,srecepcionid)
                                                    values ({0},{1},{2},'{3}','{4}','{5}','{6}')", iccarga, (object)itipodoc, (object)inrodoc, dtFechaReg.ToString("dd/MM/yyyy"), dtFechaDoc.ToString("dd/MM/yyyy"), sAnotacion, sRecepcion), trnProxy);
        }

        public int InsertarPaquete(string paqueteid, int Sucursalid, int almacenid, DateTime fecha, string celdaid, int nivel, string itemid, string itemFId, string login, string status, decimal peso, decimal piezas, decimal Metros, string ordenid, string contenedor, string colada, string centrotrabajo, DateTime FechaVenc,DbTransaction trnProxy)
        {
            string sError = string.Empty;
            string sInsert = @"insert into tblPaquetes ([PaqueteId],[SucursalId],[AlmacenId],[Fecha],[CeldaId],[Nivel],[ItemId],[Login],[Status],[Peso],[Piezas],[OrdenId],[Contenedor],[Colada],[CentroTrabajo],[ItemFId],[Metros],FechaVenc)
                                values ('{0}',{1},{2},'{3}','{4}',{5},'{6}','{7}','{8}',{9},{10},'{11}','{12}','{13}','{14}','{15}',{16},'{17}')";
            sInsert = string.Format(sInsert, paqueteid, Sucursalid, almacenid, fecha.ToString("dd/MM/yyyy"), celdaid, nivel, itemid, login, status, peso, piezas, ordenid, contenedor, colada, centrotrabajo, itemFId, Metros, FechaVenc.ToString("dd/MM/yyyy"));
            return ejecutar(ref sError, sInsert, trnProxy);

        }
        public int updateCelda(string sCelda, int sucursal, int almacen,string item,DbTransaction trnProxy)
        {
            string sError = string.Empty;
            string sSelect = "select * from tblCeldas where celdaid='{0}'";
            sSelect = string.Format(sSelect, sCelda);
            DataSet dtsCelda = consultar(sSelect, trnProxy);
            string sUpdate = string.Empty;
            if (dtsCelda.Tables[0].Rows.Count > 0)
            {
                sUpdate = "update tblCeldas set unidades=unidades+1 where celdaid='{0}'";
                sUpdate = string.Format(sUpdate, sCelda);
               
            }
            else
            {
                List<string> list = new List<string>();
                list = sCelda.Split(':').ToList();
                string sParte1 = list[0].ToString();
                string sParte2 = list[1].ToString();
                list = sParte2.Split('-').ToList();
                sParte1 = list[0].ToString();
                sParte2 = list[1].ToString();
                string sNave = sParte1.Substring(0, sParte1.Length - 1);
                string sColumna = sParte1.Substring(sParte1.Length - 1);
                string sArea = sParte2.Substring(0, sParte1.Length - 2);
                string sSegmento = sParte2.Substring(sParte1.Length - 2);
                sUpdate = @" insert into tblCeldas(SucursalId, CeldaId, AlmacenId, Area, Segmento, Fila, Nave, Columna, ItemId, Unidades, Kgs, Status, Proceso, PreAsignado, CeldaTemp)
                    values({0},'{1}',{2},{3},'{4}','{5}',{6},'{7}','{8}',{9}),{10},{11},'{12}',{13},'{14}'";
                sUpdate = string.Format(sUpdate,sucursal, sCelda,almacen, sArea, sSegmento,"0",sNave,sColumna,item,0,1,"Llenado",1,"");
            }
            return ejecutar(ref sError, sUpdate, trnProxy);
        }


        public int InsertarMovSyn(string OrdenId,DateTime Fecha,string   CentroTrabajo,DateTime FechaCierre,string Status,string TipoOrden,int   SucursalId,int SucursalDestino,string OrdenLigada,string ItemFLigado,bool EsDeCliente, DbTransaction trnProxy)
        {
            string sError = string.Empty;
            string sInsert = @"insert into tblMovSync ( OrdenId,    Fecha ,  CentroTrabajo, Status , TipoOrden ,  SucursalId,  SucursalDestino, EsDeCliente)
                                values('{0}','{1}','{2}','{3}','{4}',{5},{6},'{7}')";
            sInsert = string.Format(sInsert, OrdenId,    Fecha.ToString("dd/MM/yyyy") ,  CentroTrabajo, Status , TipoOrden ,  SucursalId,  SucursalDestino, EsDeCliente);
            return ejecutar(ref sError, sInsert, trnProxy);
        }
        public int InsertarMovSynDet(string OrdenId,string  ItemPV ,string  ItemF,decimal Piezas ,decimal Peso,decimal Metros,decimal  CostoUnitario,decimal PrecioTon,string   Calidad,decimal Cantidad,string    Unidad,int TipoMovimiento,decimal  PorcDistribucion, DbTransaction trnProxy)
        {
            string sError = string.Empty;
            string sInsert = @"insert into tblMovSyncDet values('{0}','{1}','{2}',{3},{4},{5},{6},{7},'{8}',{9},'{10}','{11}',{12})";
            sInsert = string.Format(sInsert, OrdenId,   ItemPV  ,ItemF,   Piezas,  Peso   , Metros  ,CostoUnitario ,  PrecioTon,   Calidad, Cantidad ,   Unidad , TipoMovimiento,  PorcDistribucion);
            return ejecutar(ref sError, sInsert, trnProxy);
        }


        private int InsertarMovimiento(string MovimientoId, DateTime Fecha, string TipoMovimiento, string Comprobante, string Login, string Status, int SucursalID, int SucEnTraspaso, int Correlativo, string Obs, int TransEnTraspaso, DbTransaction trnProxy)
        {
            string sError = string.Empty;
            string sInsert = @"insert into tblMovimiento(MovimientoId, Fecha, TipoMovimiento, Comprobante, Login, Status, SucursalID, SucEnTraspaso, Correlativo, Obs, TransEnTraspaso) 
                                values('{0}','{1}','{2}','{3}','{4}','{5}',{6},{7},{8},'{9}',{10})";
            sInsert = string.Format(sInsert, MovimientoId, Fecha.ToString("dd/MM/yyyy"), TipoMovimiento, Comprobante, Login, Status, SucursalID, SucEnTraspaso, Correlativo, Obs, TransEnTraspaso);
            return ejecutar(ref sError, sInsert, trnProxy);
        }
        private int InsertarMovimientoDetalle(string MovimientoId, string ItemId, decimal CantidadLiberada, decimal CantEnPaq, decimal Cantidad, decimal Costo, int sucursalId, string ItemF, string Unidad, decimal Peso, string Calidad, decimal Espesor, int Piezas, DbTransaction trnProxy)
        {
            string sError = string.Empty;
            string sInsert = @"insert into tblMovDetalle values('{0}','{1}',{2},{3},{4},{5},{6},'{7}','{8}',{9},'{10}',{11},{12})";
            sInsert = string.Format(sInsert, MovimientoId, ItemId, CantidadLiberada, CantEnPaq, Cantidad, Costo, SucursalId, ItemF, Unidad, Peso, Calidad, Espesor, Piezas);
            return ejecutar(ref sError, sInsert, trnProxy);
        }


        private int InsertarMovPdv(string movimientoid, DateTime fecha, string tipomovimiento, string comprobante, string login, string status, int sucursalid, int sucentraspaso, string obs, string ordenligada, string itemfligado, int transentraspaso, DbTransaction trnProxy)
        {
            string sError = string.Empty;
            string sInsert = @"insert into tblmovpdv values('{0}','{1}','{2}','{3}','{4}','{5}',{6},{7},'{8}','{9}','{10}',{11})";
            sInsert = string.Format(sInsert, movimientoid, fecha.ToString("dd/MM/yyyy"), tipomovimiento, comprobante, login, status, sucursalid, sucentraspaso, obs, ordenligada, itemfligado, transentraspaso);
            return ejecutar(ref sError, sInsert, trnProxy);
        }
        private int InsertarMovDetPdv(string movimientoid, string itemid, decimal cantidad, decimal costo, int sucursalid, string itemf, string unidad, decimal peso, string calidad, decimal espesor, DbTransaction trnProxy)
        {
            string sError = string.Empty;
            string sInsert = @"insert into tblmovdetpdv values('{0}','{1}',{2},{3},{4},{5},'{6}',{7},'{8}',{9})";
            sInsert = string.Format(sInsert, movimientoid, itemid, cantidad, costo, sucursalid, itemf, unidad, peso, calidad, espesor);
            return ejecutar(ref sError, sInsert, trnProxy);
        }

        //private int InsertarPaquetes(string PaqueteId,int SucursalId,int AlmacenId,DateTime Fecha,string CeldaId,int Nivel,string ItemId,string Login,string Status,decimal Peso,decimal Piezas,string OrdenId,string Contenedor,string Colada,string CentroTrabajo,string ItemFId,decimal Metros,DateTime FechaVenc, DbTransaction trnProxy)
        //{
        //    string sError = string.Empty;
        //    string sInsert = @"insert into tblPaquetes(PaqueteId, SucursalId, AlmacenId, Fecha, CeldaId, Nivel, ItemId, Login, Status, Peso, Piezas, OrdenId, Contenedor, Colada, CentroTrabajo, ItemFId, Metros, FechaVenc)
        //                        values('{0}',)";
        //    sInsert = string.Format(sInsert, PaqueteId, SucursalId, AlmacenId, Fecha, CeldaId, Nivel, ItemId, Login, Status, Peso, Piezas, OrdenId, Contenedor, Colada, CentroTrabajo, ItemFId, Metros, FechaVenc);
        //    return ejecutar(ref sError, sInsert, trnProxy);
        //}
        



    }
}
