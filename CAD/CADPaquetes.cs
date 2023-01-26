using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Configuration;
using System.Data;
using System.Data.Common;
using CRN.Entidades;

namespace CAD
{
    public class CADPaquetes : DBDAC
    {

        public CADPaquetes()
            : base("SQLSERVER", "dbo.tblPaquetes")
        {

            //DbParameter par = this.CrearParametro();
            //par.ParameterName = "@PaqueteId";
            //par.DbType = DbType.Int32;
            //par.Direction = ParameterDirection.Output;
            //Adapter.InsertCommand.CommandText += ";SELECT @PaqueteId=SCOPE_IDENTITY();";
            //Adapter.InsertCommand.Parameters.Add(par);
        }
        public int GuardarPaquetes(Paquetes oPaquetes)
        {
            DbCommand cmdInsert = Adapter.InsertCommand;
            cmdInsert.Parameters["@PaqueteId"].Value = oPaquetes.PaqueteId;
            cmdInsert.Parameters["@SucursalId"].Value = oPaquetes.SucursalId;
            cmdInsert.Parameters["@AlmacenId"].Value = oPaquetes.AlmacenId;
            cmdInsert.Parameters["@Fecha"].Value = oPaquetes.Fecha;
            cmdInsert.Parameters["@CeldaId"].Value = oPaquetes.CeldaId;
            cmdInsert.Parameters["@Nivel"].Value = oPaquetes.Nivel;
            cmdInsert.Parameters["@ItemId"].Value = oPaquetes.ItemId;
            cmdInsert.Parameters["@Login"].Value = oPaquetes.Login;
            cmdInsert.Parameters["@Status"].Value = oPaquetes.status;
            cmdInsert.Parameters["@Peso"].Value = oPaquetes.Peso;
            cmdInsert.Parameters["@Piezas"].Value = oPaquetes.Piezas;
            cmdInsert.Parameters["@OrdenId"].Value = oPaquetes.OrdenId;
            cmdInsert.Parameters["@Contenedor"].Value = oPaquetes.Contenedor;
            cmdInsert.Parameters["@Colada"].Value = oPaquetes.Colada;
            return EjecutarComando(cmdInsert);
        }
        public DataSet TraerListaStock(int _IdSucursal)
        {
            string consulta = "SELECT a.ItemId as Codigo, c.ItemFId as ItemFerro, c.Descripcion, SUM(a.Piezas) as Piezas, SUM(a.Peso) as Peso, c.UnidadF " +
                "FROM tblPaquetes a INNER JOIN tblSucItem b ON a.ItemId = b.ItemId AND a.SucursalId = b.SucursalId INNER JOIN tblItem c ON a.ItemId = c.Itemid " +
                "where a.Status = 'ACTIVO' AND a.SucursalId = " + _IdSucursal + " group by a.ItemId, c.ItemFId, c.Descripcion, c.UnidadF";
            return this.EjecutarConsulta(consulta);
        }
        public DataSet TraerStock(string _codigoPr, int _idSucursal)
        {
            string consulta = "SELECT SUM(piezas) as Piezas, SUM(peso) as Peso, COUNT(*) as Paqs " +
                "from tblPaquetes WHERE SucursalId = '" + _idSucursal + "' AND ItemId = '" + _codigoPr + "'";
            return this.EjecutarConsulta(consulta);
        }
        public DataSet TraerStockNombre(string _nombrePr, int _idSucursal)
        {
            string consulta = "SELECT SUM(a.Piezas) as nPiezas, SUM(a.Peso) as nPeso, COUNT(*) as nPaqs from tblPaquetes a " +
                "INNER JOIN tblItem b ON a.ItemId = b.ItemId WHERE a.SucursalId = '" + _idSucursal + "' AND b.Descripcion = '" + _nombrePr + "'";
            return this.EjecutarConsulta(consulta);
        }
        public DataSet TraerStockCodigo(string _codigoPr, int _idSucursal)
        {
            string consulta = "SELECT SUM(piezas) as nPiezas, SUM(peso) as nPeso, COUNT(*) as nPaqs " +
                "from tblPaquetes WHERE SucursalId = '" + _idSucursal + "' AND ItemId = '" + _codigoPr + "'";
            return this.EjecutarConsulta(consulta);
        }
        public DataSet TraerCantProdPorDespacho(string _idDespacho)
        {
            string consulta = "select ItemId from tblDespDetalle where DespachoId = '" + _idDespacho + "'";
            return this.EjecutarConsulta(consulta);
        }
        public DataSet TraerProductosaLecturarValidar(string _idDespacho)
        {
            string consulta = "SELECT a.DespachoId, b.ProductoId, a.ItemId, b.Cantidad, b.Piezas FROM tblDespDetalle a INNER JOIN tblDespProductos B on A.DespachoId = B.DespachoId where a.DespachoId = '" + _idDespacho + "' AND Piezas > 0 order by a.ItemId ASC";
            return this.EjecutarConsulta(consulta);
        }
        //Para palet
        public DataSet TraerProductosLecturarPaletValidar(int _idSucursal)
        {
            string consulta = "SELECT b.ItemFId, a.ItemId, b.Descripcion, a.PaqueteId, a.Piezas, a.Peso FROM tblPaquetes a INNER JOIN tblItem b ON a.ItemId = b.ItemId where SucursalId = " + _idSucursal + " AND a.Status = 'ACTIVO' AND Len(contenedor) < 1";
            return this.EjecutarConsulta(consulta);
        }
        public DataSet TraerPaquetesLecturadosPalet(int _idSucursal, string _Palet)
        {
            string consulta = "SELECT b.ItemFId, a.ItemId, b.Descripcion, a.PaqueteId, a.Piezas, a.Peso FROM tblPaquetes a INNER JOIN tblItem b ON a.ItemId = b.ItemId where SucursalId = " + _idSucursal + " AND a.Status = 'ACTIVO' AND Len(contenedor) < 1 AND a.Contenedor = '" + _Palet + "'";
            return this.EjecutarConsulta(consulta);
        }
        public DataSet TraerPaquetesPaletParaLecturar(int _idSucursal, string _Palet)
        {
            string consulta = "SELECT b.ItemFId, a.ItemId, b.Descripcion, a.PaqueteId, a.Piezas, a.Peso, b.UnidadF, SUM(a.Piezas) as Cantidad, a.Fecha FROM tblPaquetes a INNER JOIN tblItem b ON a.ItemId = b.ItemId where a.SucursalId = " + _idSucursal + " AND a.Status = 'ACTIVO' AND a.Contenedor = '" + _Palet + "' group by a.ItemId, b.ItemFId, b.Descripcion, a.PaqueteId, a.Fecha, b.UnidadF, a.Piezas, a.Peso order by a.Fecha ASC";
            return this.EjecutarConsulta(consulta);
        }
        public DataSet TraerPaqLecturadoPalet(int _idSucursal, string _Codigo)
        {
            string consulta = "select ProductoId from tblDespProductos where SucursalId = " + _idSucursal + " AND ItemId = '" + _Codigo + "'";
            return this.EjecutarConsulta(consulta);
        }
        public DataSet TraerPaqueteLecturado(int _idSucursal)
        {
            //string consulta = "SELECT a.ItemId, b.Descripcion, a.PaqueteId, a.Piezas, a.Peso FROM tblPaquetes a " +
            //    "INNER JOIN tblItem b ON a.ItemId = b.ItemId WHERE a.SucursalId = " + _idSucursal + " AND a.PaqueteId = '" + _codigoPr + "'";
            string consulta = "SELECT a.ItemId, c.ItemFId, c.Descripcion, a.PaqueteId, SUM(a.Piezas) as Piezas, SUM(a.Peso) as Peso " +
                "FROM tblPaquetes a INNER JOIN tblSucItem b ON a.ItemId = b.ItemId INNER JOIN tblItem c ON a.ItemId = c.Itemid where a.Status = 'ACTIVO' " +
                "AND b.SucursalId = " + _idSucursal + " group by a.ItemId, c.ItemFId, c.Descripcion, a.PaqueteId, a.Fecha " +
                "order by a.Fecha ASC";
            return this.EjecutarConsulta(consulta);
        }
        public DataSet TraerPaqueteLecturadoBuscar(int _idSucursal, string _idPaquete)
        {
            string consulta = "SELECT a.ItemId, c.ItemFId, c.Descripcion, a.PaqueteId, SUM(a.Piezas) as Piezas, SUM(a.Peso) as Peso, c.UnidadF " +
                "FROM tblPaquetes a INNER JOIN tblSucItem b ON a.ItemId = b.ItemId INNER JOIN tblItem c ON a.ItemId = c.Itemid where a.Status = 'ACTIVO' " +
                "AND b.SucursalId = " + _idSucursal + " AND PaqueteId = '" + _idPaquete + "' group by a.ItemId, c.ItemFId, c.Descripcion, a.PaqueteId, a.Piezas, a.Fecha, c.UnidadF " +
                "order by a.Fecha ASC";
            return this.EjecutarConsulta(consulta);
        }
        public DataSet TraerTodoPaquetes()
        {
            return this.Consultar("");
        }
        public DataSet TraerTodoPaquetesActivos(string sEstado, int Sucursal)
        {
            string sSelect = @"select PaqueteId, SucursalId, AlmacenId, Fecha, CeldaId, Nivel, p.ItemId, i.Descripcion,Login, Status, Peso, p.Piezas, OrdenId, Contenedor, Colada, CentroTrabajo, p.ItemFId, Metros,i.Calidad 
                            from tblPaquetes p inner join 
                            tblItem i on p.ItemId = i.ItemId
                            where Status IN({0})  and SucursalId = {1}";
            sSelect = string.Format(sSelect, sEstado, Sucursal);
            return this.EjecutarConsulta(sSelect);
        }
        public DataSet TraerPaqueteLecturadoFiltrado(int _idSucursal, string _ItemId)
        {
            string consulta = "SELECT a.ItemId, c.ItemFId, c.Descripcion, a.PaqueteId, SUM(a.Piezas) as Piezas, SUM(a.Peso) as Peso, c.UnidadF, SUM(a.Piezas) as Cantidad, a.Fecha " +
                "FROM tblPaquetes a INNER JOIN tblSucItem b ON a.ItemId = b.ItemId INNER JOIN tblItem c ON a.ItemId = c.Itemid where a.Status = 'ACTIVO' " +
                "AND b.SucursalId = " + _idSucursal + " AND a.ItemId = '" + _ItemId + "' group by a.ItemId, c.ItemFId, c.Descripcion, a.PaqueteId, a.Fecha, c.UnidadF " +
                "order by a.Fecha ASC";
            return this.EjecutarConsulta(consulta);
        }
        public DataSet TraerPaqueteLecturadoPorSucursal(int _idSucursal)
        {
            string consulta = "SELECT a.ItemId, c.ItemFId, c.Descripcion, a.PaqueteId, a.Piezas as Piezas, SUM(a.Peso) as Peso, c.UnidadF, SUM(a.Piezas) as Cantidad, a.Fecha " +
                "FROM tblPaquetes a INNER JOIN tblSucItem b ON a.ItemId = b.ItemId INNER JOIN tblItem c ON a.ItemId = c.Itemid where a.Status = 'ACTIVO' " +
                "AND a.SucursalId = " + _idSucursal + " group by a.ItemId, c.ItemFId, c.Descripcion, a.PaqueteId, a.Piezas, a.Fecha, c.UnidadF " +
                "order by a.Fecha ASC";
            return this.EjecutarConsulta(consulta);
        }
        public int ReservarPaquete(string _idPaquete)
        {
            return EjecutarComando("UPDATE tblPaquetes SET Status = 'RESERVADO' WHERE PaqueteId =  '" + _idPaquete + "'");
        }
        public DataSet TraerDatosAbrirPaq(string _IdPaquete)
        {
            string consulta = "SELECT PiezasEntregada, PesoEntregado FROM tblPaquetes WHERE PaqueteId = '" + _IdPaquete + "'";
            return this.EjecutarConsulta(consulta);
        }
        public DataSet TraerComparacionPaquetes(string _IdPaquete)
        {
            string consulta = "select a.ProductoId as Paquete, a.Piezas as PiezasDespProductos, a.Cantidad as CantidadDespProductos, a.Peso as PesoDespProducto, c.Piezas as PiezasPaquete, c.Peso as PesoPaquete, c.CantOriginal from tblDespProductos a INNER JOIN tblPaquetes c ON a.ProductoId = c.PaqueteId where a.ProductoId = '" + _IdPaquete + "'";
            return this.EjecutarConsulta(consulta);
        }
        public DataSet TraerEstadoPaqueteCerrar(string _idPaquete)
        {
            string consulta = "select Piezas, Cantidad from tblDespProductos where ProductoId = '" + _idPaquete + "'";
            return this.EjecutarConsulta(consulta);
        }
        public DataSet TraerContPaquetesProgCelda(string _idDespacho)
        {
            string consulta = "select COUNT(DespachoId) AS count from tblDespProgCelda where DespachoId = '" + _idDespacho + "'";
            return this.EjecutarConsulta(consulta);
        }
        public DataSet TraerContPaquetesProgSob(string _idDespacho)
        {
            string consulta = "select COUNT(DespachoId) AS count from tblDespProgSob where DespachoId = '" + _idDespacho + "'";
            return this.EjecutarConsulta(consulta);
        }
        public DataSet TraerPaqProgCeldaLect(string _idDespacho)
        {
            string consulta = "select Paquetes from tblDespProgCelda where DespachoId = '" + _idDespacho + "'";
            return this.EjecutarConsulta(consulta);
        }
        public DataSet TraerPaqProgSobLect(string _idDespacho)
        {
            string consulta = "select PaqueteId from tblDespProgSob where DespachoId = '" + _idDespacho + "'";
            return this.EjecutarConsulta(consulta);
        }
        public DataSet TraerPaqProgramados(string _idPaquete)
        {
            string consulta = "SELECT a.ItemId, c.ItemFId, c.Descripcion, a.PaqueteId, SUM(a.Piezas) as Piezas, SUM(a.Peso) as Peso, c.UnidadF, SUM(a.Piezas) as Cantidad, a.Fecha FROM tblPaquetes a INNER JOIN tblItem c ON a.ItemId = c.Itemid where a.PaqueteId = '" + _idPaquete + "' group by a.ItemId, c.ItemFId, c.Descripcion, a.PaqueteId, a.Fecha, c.UnidadF order by a.Fecha ASC";
            return this.EjecutarConsulta(consulta);
        }
        public DataSet BuscarPaqueteCompleto(string _IdPaquete)
        {
            string consulta = "SELECT * FROM tblPaquetes WHERE PaqueteId = '" + _IdPaquete + "'";
            return this.EjecutarConsulta(consulta);
        }
        public DataSet BuscarPaqueteLecturar(string _IdPaquete)
        {
            string consulta = "SELECT a.PaqueteId, a.ItemId, a.CeldaId, b.ItemFId, a.Piezas, a.Metros, a.Colada from tblPaquetes a INNER JOIN tblItem b ON a.ItemId = b.ItemId WHERE PaqueteId = '" + _IdPaquete + "'";
            return this.EjecutarConsulta(consulta);
        }
        public DataSet BuscarPaquetePorOrden(string _NroOrden)
        {
            string consulta = "select a.ItemId, b.Descripcion, a.PaqueteId, a.Piezas, a.Peso, b.UnidadCalculo from tblPaquetes a INNER JOIN tblItem b ON a.ItemId = b.ItemId where a.OrdenId = '" + _NroOrden + "'";
            return this.EjecutarConsulta(consulta);
        }
        public DataSet BuscarPaqueteEntrega(string _idDespacho)
        {
            string consulta = "select a.ItemId, a.ItemFId, b.Descripcion, a.ProductoId, b.UnidadF, a.Piezas, a.Peso, a.Piezas*a.Peso as PesoTotal, a.Cantidad as Pendiente from tblDespProductos a INNER JOIN tblItem b ON a.ItemId = b.ItemId where a.DespachoId = '" + _idDespacho + "'";
            return this.EjecutarConsulta(consulta);
        }
        public DataSet TraerCelda(string _idPaquete)
        {
            string consulta = "select CeldaId from tblPaquetes where PaqueteId = '" + _idPaquete + "'";
            return this.EjecutarConsulta(consulta);
        }
        public DataSet BuscarPaqueteEntregaPacial(string _idDespacho)
        {
            //string consulta = "select a.ItemId as Codigo, a.ItemFId as CodigoFerro, b.Descripcion, a.ProductoId as Paquete, b.UnidadF as UnidadMedida, a.Cantidad, a.Peso, a.Cantidad*a.Peso as PesoTotal, (a.Cantidad - (SUM(c.Cantidad))) as Pendiente from tblDespProductos a INNER JOIN tblItem b ON a.ItemId = b.ItemId INNER JOIN tblOrdenEntregaDetalle c ON a.DespachoId = c.DespachoId where a.DespachoId = '" + _idDespacho + "' AND c.ItemId = a.ItemId group by a.ItemId, a.ItemFId, b.Descripcion, a.ProductoId, b.UnidadF, a.Cantidad, a.Peso";
            string consulta = "select a.ItemId as Codigo, a.ItemFId as CodigoFerro, b.Descripcion, a.ProductoId as Paquete, b.UnidadF as UnidadMedida, a.Cantidad, a.Peso, a.Cantidad*a.Peso as PesoTotal, a.Cantidad as Pendiente from tblDespProductos a INNER JOIN tblItem b ON a.ItemId = b.ItemId where a.DespachoId = '" + _idDespacho + "' group by a.ItemId, a.ItemFId, b.Descripcion, a.ProductoId, b.UnidadF, a.Cantidad, a.Peso, a.Piezas";
            return this.EjecutarConsulta(consulta);
        }
        public DataSet BuscarPaqueteEntregaParcialPendiente(string _idDespacho)
        {
            //string consulta = "select * from tblOrdenEntregaDetalle where DespachoId = '" + _idDespacho + "'";
            string consulta = "select PaqueteId, ItemId as Codigo, Cantidad from tblOrdenEntregaDetalle where DespachoId = '" + _idDespacho + "'";
            return this.EjecutarConsulta(consulta);
        }
        public DataSet BuscarPaqueteEntregaConEntrega(string _idDespacho)
        {
            string consulta = "select a.ItemId, a.ItemFId, b.Descripcion, a.ProductoId, b.UnidadF, a.Cantidad, a.Peso, a.Cantidad*a.Peso as PesoTotal, " +
                //"(a.Cantidad - SUM(c.Cantidad)) as Pendiente from tblDespProductos a INNER JOIN tblItem b ON a.ItemId = b.ItemId " +
                "a.Cantidad as Pendiente from tblDespProductos a INNER JOIN tblItem b ON a.ItemId = b.ItemId " +
                "INNER JOIN tblOrdenEntregaDetalle c ON a.ProductoId = c.PaqueteId where a.DespachoId = '" + _idDespacho + "' " +
                "group by a.DespachoId, a.ItemId, a.ItemFId, b.Descripcion, a.ProductoId, b.UnidadF, a.Cantidad, a.Peso, c.Cantidad";
            return this.EjecutarConsulta(consulta);
        }
        public DataSet BuscarPaqItemControl(int _idSucursal)
        {
            string consulta = "select a.ItemId, b.ItemFId, b.Descripcion, a.CeldaId, a.Piezas, a.PaqueteId from tblPaquetes a INNER JOIN tblItem b ON a.ItemId = b.ItemId where Status = 'ACTIVO' AND SucursalId = " + _idSucursal;
            return this.EjecutarConsulta(consulta);
        }
        public DataSet ImprimirPaqControlProd(string _Codigo, int _idSucursal)
        {
            string consulta = "select a.ItemId, b.ItemFId, b.Descripcion, a.CeldaId, a.Piezas, a.PaqueteId from tblPaquetes a INNER JOIN tblItem b ON a.ItemId = b.ItemId where Status = 'ACTIVO' AND a.ItemId = '" + _Codigo + "' AND SucursalId = " + _idSucursal;
            return this.EjecutarConsulta(consulta);
        }
        public DataSet ImprimirPaqControlFerro(int _Codigo, int _idSucursal)
        {
            string consulta = "select a.ItemId, b.ItemFId, b.Descripcion, a.CeldaId, a.Piezas, a.PaqueteId from tblPaquetes a INNER JOIN tblItem b ON a.ItemId = b.ItemId where Status = 'ACTIVO' AND b.ItemFId = " + _Codigo + " AND SucursalId = " + _idSucursal;
            return this.EjecutarConsulta(consulta);
        }
        public DataSet ContEntregas(string _idDespacho)
        {
            string consulta = "select COUNT(despachoid) contEnt from tblOrdenEntrega where DespachoId = '" + _idDespacho + "'";
            return this.EjecutarConsulta(consulta); 
        }
        public DataSet BuscarDatosEntrega(string _idDespacho)
        {
            string consulta = "select a.ItemId, a.ItemFId, b.Descripcion, a.ProductoId, a.Piezas, a.Peso from tblDespProductos a INNER JOIN tblItem b ON a.ItemId = b.ItemId where DespachoId = '" + _idDespacho + "'";
            //string consulta = "select * from tblMovSync where SucursalId = 12071";
            return this.EjecutarConsulta(consulta);
        }
        public DataSet TraerTodoPaquetes(string where)
        {
            return this.Consultar(where);
        }
        public DataSet TraerTodoPaquetes(string estado, int sucursal)
        {
            string consulta = "Select despachoId as [Nro Despacho], NroOrden as [Nro Orden] ,Placa,Destino from tblDespacho where status='" + estado + "' and SucursalID=" + sucursal;
            return this.EjecutarConsulta(consulta);
        }
        public int ModificarPaquetes(Paquetes oPaquetes)
        {
            DbCommand cmdModificar = Adapter.UpdateCommand;
            cmdModificar.Parameters["@PaqueteId"].Value = oPaquetes.PaqueteId;
            cmdModificar.Parameters["@SucursalId"].Value = oPaquetes.SucursalId;
            cmdModificar.Parameters["@AlmacenId"].Value = oPaquetes.AlmacenId;
            cmdModificar.Parameters["@Fecha"].Value = oPaquetes.Fecha;
            cmdModificar.Parameters["@CeldaId"].Value = oPaquetes.CeldaId;
            cmdModificar.Parameters["@Nivel"].Value = oPaquetes.Nivel;
            cmdModificar.Parameters["@ItemId"].Value = oPaquetes.ItemId;
            cmdModificar.Parameters["@Login"].Value = oPaquetes.Login;
            cmdModificar.Parameters["@Status"].Value = oPaquetes.status;
            cmdModificar.Parameters["@Peso"].Value = oPaquetes.Peso;
            cmdModificar.Parameters["@Piezas"].Value = oPaquetes.Piezas;
            cmdModificar.Parameters["@OrdenId"].Value = oPaquetes.OrdenId;
            cmdModificar.Parameters["@Contenedor"].Value = oPaquetes.Contenedor;
            cmdModificar.Parameters["@Colada"].Value = oPaquetes.Colada;
            return EjecutarComando(cmdModificar);
        }
        public Paquetes TraerPaquete(string idPaquete)
        {
            DataSet ds = this.Consultar("PaqueteId='" + idPaquete + "'");
            DataTable tPaquetes = ds.Tables[0];
            if (tPaquetes.Rows.Count == 0)
            {
                return null;
            }
            DataRow rPaquete = tPaquetes.Rows[0];
            Paquetes oPaquete = new Paquetes();
            oPaquete.PaqueteId = idPaquete;
            oPaquete.ItemId = rPaquete["ItemId"].ToString();

            oPaquete.SucursalId = Convert.ToInt32(rPaquete["SucursalId"].ToString());
            oPaquete.AlmacenId = Convert.ToInt32(rPaquete["AlmacenId"].ToString());
            oPaquete.Fecha = Convert.ToDateTime(rPaquete["Fecha"].ToString());
            oPaquete.Nivel = Convert.ToInt32(rPaquete["Nivel"].ToString());
            oPaquete.OrdenId = rPaquete["OrdenId"].ToString();
            oPaquete.Contenedor = rPaquete["Contenedor"].ToString();
            oPaquete.Colada = rPaquete["Colada"].ToString();

            oPaquete.CeldaId = rPaquete["CeldaId"].ToString();
            oPaquete.Peso = Convert.ToDecimal(rPaquete["Peso"].ToString());
            oPaquete.Piezas = Convert.ToInt32(rPaquete["Piezas"].ToString());
            oPaquete.status = rPaquete["Status"].ToString();
            return oPaquete;
        }
        public Paquetes Importar(string paq)
        {
            string cadena = "select FBC_BATCH [Paquete],FBC_BATCH_FATHER [Contenedor],FBC_PRODUCT_GROUP,FBC_PRODUCT_CODE [ItemId],FBC_PRODUCT_DESC,FBC_WORKCENTER [CentroTrabajo],FBC_PO [OrdenId],FBC_WEIGHT [Peso],FBC_PIECE [Piezas],FBC_METERS,FBC_INS_DATE,'',FBC_START [Fecha]," +
            "(SELECT [FBF_VALUE] FROM [ElsystemNet_Ferrotodo].[dbo].[MES_TB_FLD_BATCH_FEATURE] where FBF_BATCH ='" + paq + "' and FBF_FEATURE ='HEAT') as Colada " +
            "FROM [ElsystemNet_Ferrotodo].[dbo].[MES_TB_FLD_BATCHES] " +
            "where FBC_BATCH='" + paq + "'";
            DataSet ds = EjecutarConsulta(cadena);
            DataTable tPaq = ds.Tables[0];
            if (tPaq.Rows.Count == 0)
            {
                return null;
            }
            DataRow rPaq = tPaq.Rows[0];
            Paquetes oPaq = new Paquetes();
            oPaq.PaqueteId = paq;
            oPaq.ItemId = rPaq["ItemId"].ToString();
            oPaq.Peso = Convert.ToDecimal(rPaq["Peso"]);
            oPaq.Piezas = Convert.ToInt32(rPaq["Piezas"]);
            oPaq.OrdenId = rPaq["OrdenId"].ToString();
            oPaq.Contenedor = rPaq["Contenedor"].ToString();
            oPaq.Colada = rPaq["Colada"].ToString();
            //oPaq.CentroTrabajo = rPaq["CentroTrabajo"].ToString();
            return oPaq;
        }
        public int EliminarPaquetes(int docId)
        {
            return EjecutarComando("DELETE FROM dbo.documentos WHERE docId=" + docId.ToString());
        }
        public int AbrirPaquete(string _IdPaquete, int _PiezaEnt, int _PiezaAct, decimal _PesoEnt, decimal _PesoAct)
        {
            return EjecutarComando("UPDATE tblPaquetes set PiezasEntregada = " + _PiezaEnt + ", PesoEntregado = " + _PesoEnt + ", PiezasInicio = " + _PiezaAct + ", " +
                "PesoInicio = " + _PesoAct + " WHERE PaqueteId = '" + _IdPaquete + "'");
        }
        public int MarcarEliminado(int docId, int Valor)
        {
            return EjecutarComando("UPDATE dbo.documentos set eliminado = " + Valor + " WHERE docId=" + docId.ToString());
        }
        public bool BuscarPaquetes(string CodPaquete)
        {
            string cadena = "select * from tblPaquetes where PaqueteId='" + CodPaquete + "'";
            DataSet ds = EjecutarConsulta(cadena);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }
        public DataSet BuscarPaqueteLocaliza(int _IdSucursal)
        {
            string consulta = "select a.PaqueteId, a.ItemId, b.ItemFId, b.Descripcion, a.Peso, a.Piezas from tblPaquetes a INNER JOIN tblItem b ON a.ItemId = b.ItemId where a.Status = 'ACTIVO' AND a.SucursalId = " + _IdSucursal;
            return this.EjecutarConsulta(consulta);
        }
        public DataSet TraerNavesXAlmacen(int _IdSucursal)
        {
            string consulta = "select Naves from tblAlmacen where SucursalId = " + _IdSucursal;
            return this.EjecutarConsulta(consulta);
        }
        public DataSet PaquetesEnEstante(string _CeldaId)
        {
            string consulta = "select a.PaqueteId, a.ItemId, b.ItemFId, b.Descripcion, a.Peso, a.Piezas from tblPaquetes a INNER JOIN tblItem b ON a.ItemId = b.ItemId where CeldaId = '" + _CeldaId + "' and Status = 'ACTIVO'";
            return this.EjecutarConsulta(consulta);
        }
        public DataSet TraerPaqueteBusqueda(string _IdPaquete, int _IdSucursal)
        {
            string consulta = "select a.OrdenId, a.ItemId, b.ItemFId, b.Descripcion, a.Piezas, a.Peso, a.SucursalId, c.Nombre as NombreSucursal, a.AlmacenId, a.CeldaId, a.Status from tblPaquetes a INNER JOIN tblItem b ON a.ItemId = b.ItemId INNER JOIN tblSucursal c ON a.SucursalId = c.SucursalID where a.PaqueteId = '" + _IdPaquete + "' AND a.SucursalId = " + _IdSucursal;
            return this.EjecutarConsulta(consulta);
        }
        //Reporte Detalle de Paquetes
        public DataSet DetallePaquetes(string _idPaquete)
        {
            string cadena = "select b.ItemId+' ('+b.ItemFId+')' as Codigo, b.Descripcion, a.CeldaId, a.Piezas, a.PaqueteId from tblPaquetes a INNER JOIN tblItem b ON a.ItemId = b.ItemId where PaqueteId = '" + _idPaquete + "'";
            return this.EjecutarConsulta(cadena);
        }
        public DataSet BuscarPaquete(string CodPaquete, int Sucursal, string sEstado)
        {
            string cadena = @"select p.PaqueteId,p.ItemId,i.Descripcion,p.Piezas,p.Peso,i.UnidadF
                             from tblPaquetes p inner
                             join
                            tblItem i on p.ItemId = i.ItemId
                             where Status = '" + sEstado + "' and p.PaqueteId = '" + CodPaquete.Trim() + "' and SucursalId = " + Sucursal;
            DataSet ds = EjecutarConsulta(cadena);
            return ds;
        }
        //Palet
        public DataSet TraerPaletSucursal(int _idSucursal)
        {
            //string cadena = "select a.Contenedor, COUNT(a.PaqueteId) as Paquetes, SUM(a.Peso) as Peso, a.CeldaId from tblPaquetes a INNER JOIN tblItem b ON a.ItemId = b.ItemId where SucursalId = " + _idSucursal + " AND LEN(contenedor) > 3 group by a.Contenedor, a.CeldaId order by a.Contenedor";
            string cadena = "select PaletId, ItemId, ItemFId, Cantidad_Paqs, Peso_Paqs from tblPalet where Estado = 'ACTIVO' and SucursalId = " + _idSucursal;
            return this.EjecutarConsulta(cadena);
        }
        public DataSet PaletImprimir(string _Palet)
        {
            string cadena = "Select * from tblPalet where PaletId = '" + _Palet + "'";
            return this.EjecutarConsulta(cadena);
        }
        public DataSet TraerDetallePalet(int _idSucursal, string _Palet)
        {
            string cadena = "select a.PaqueteId, a.ItemId, b.ItemFId, b.Descripcion, a.Peso, a.Piezas, a.CeldaId from tblPaquetes a INNER JOIN tblItem b ON a.ItemId = b.ItemId where a.SucursalId = " + _idSucursal + " AND a.Contenedor = '" + _Palet + "'";
            return this.EjecutarConsulta(cadena);
        }
        public int ActualizarPaquete(string _Palet, string _idPaquete, int _idSucursal)
        {
            return EjecutarComando("UPDATE tblPaquetes set Contenedor = '" + _Palet + "' WHERE SucursalId " + _idSucursal + " AND PaqueteId = '" + _idPaquete + "'");
        }
        public DataSet TraerItemPaquetesDisponibles(int _idSucursal)
        {
            string cadena = "select ItemId from tblPaquetes where SucursalId = " + _idSucursal + " and Status = 'ACTIVO' and Piezas > 0 group by ItemId";
            return this.EjecutarConsulta(cadena);
        }
        public DataSet TraerListaPaqsPalet(string ItemId, int _idSucursal)
        {
            string cadena = "select b.ItemFId, a.ItemId, b.Descripcion, a.PaqueteId, a.FechaVenc, a.Fecha, a.Piezas, a.Peso, a.OrdenId from tblPaquetes a INNER JOIN tblItem b ON a.ItemId = b.ItemId where a.Status = 'ACTIVO' AND a.SucursalId = " + _idSucursal + " AND a.ItemId = '" + ItemId + "' order by a.FechaVenc, a.Fecha";
            return this.EjecutarConsulta(cadena);
        }
    }
}
