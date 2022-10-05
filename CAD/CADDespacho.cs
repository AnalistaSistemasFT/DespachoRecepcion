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
    public class CADDespacho:DBDAC
    {
        public CADDespacho()
            : base("SQLSERVER", "dbo.tblDespacho")
        {

            //DbParameter par = this.CrearParametro();
            //par.ParameterName = "@DespachoId";
            //par.DbType = DbType.Int32;
            //par.Direction = ParameterDirection.Output;
            //Adapter.InsertCommand.CommandText += ";SELECT @DespachoId=SCOPE_IDENTITY();";
            //Adapter.InsertCommand.Parameters.Add(par);
        }
        public int GuardarDespacho(Despacho oDespacho, DbTransaction dbTr)
        {
            DbCommand cmdInsert = Adapter.InsertCommand;
            cmdInsert.Parameters["@DespachoId"].Value = oDespacho.p_DespachoId;
            cmdInsert.Parameters["@Fecha"].Value = oDespacho.p_Fecha;
            cmdInsert.Parameters["@NroOrden"].Value = oDespacho.p_NroOrden;
            cmdInsert.Parameters["@Id_Camion"].Value = oDespacho.p_Id_Camion;
            cmdInsert.Parameters["@Placa"].Value = oDespacho.p_Placa;
            cmdInsert.Parameters["@Marca"].Value = oDespacho.p_Marca;
            cmdInsert.Parameters["@Chofer"].Value = oDespacho.p_Chofer;
            cmdInsert.Parameters["@CI"].Value = oDespacho.p_CI;
            cmdInsert.Parameters["@Destino"].Value = oDespacho.p_Destino;
            cmdInsert.Parameters["@Login"].Value = oDespacho.p_Login;
            cmdInsert.Parameters["@Status"].Value = oDespacho.p_status;
            cmdInsert.Parameters["@Correlativo"].Value = oDespacho.p_Correlativo;
            cmdInsert.Parameters["@Obs"].Value = oDespacho.p_Obs;
            cmdInsert.Parameters["@Tipo"].Value = oDespacho.p_Tipo;
            cmdInsert.Parameters["@Cargador"].Value = oDespacho.p_Cargador;
            cmdInsert.Parameters["@NumTraspaso"].Value = oDespacho.p_NumTraspaso;
            cmdInsert.Parameters["@SucursalId"].Value = oDespacho.p_SucursalId;
            cmdInsert.Parameters["@SucDestino"].Value = oDespacho.p_SucDestino;
            cmdInsert.Parameters["@HorarioPartida"].Value = oDespacho.p_HorarioPartida;
            cmdInsert.Parameters["@HorarioLlegada"].Value = oDespacho.p_HorarioLlegada;
            cmdInsert.Parameters["@Naturaleza"].Value = oDespacho.p_Naturaleza;
            cmdInsert.Parameters["@Anticipado"].Value = oDespacho.p_Anticipado;
            cmdInsert.Parameters["@TipoDoc"].Value = oDespacho.p_TipoDoc;
            return EjecutarComando(cmdInsert);
        }

        public DataSet TraerTodoDespacho()
        {
            return this.Consultar("");
        }
        public DataSet TraerTodoDetalleDespacho(string IdDespacho)
        {
            string cadena = "select * from tblDespDetalle where DespachoId = '" + IdDespacho + "' ";
            return this.EjecutarConsulta(cadena);
        }
        public DataSet TraerEditarDetalleDespacho(string IdDespacho)
        {
            string cadena = "select a.ItemId, b.ItemFId, b.Descripcion, a.Cantidad, SUM(c.Piezas) as Stock, b.Piezas as PzasPaq, b.PesoPaq from tblDespDetalle a INNER JOIN tblItem b ON a.ItemId = b.ItemId INNER JOIN tblPaquetes c ON a.ItemId = c.ItemId where DespachoId = '" + IdDespacho + "' group by a.ItemId, b.ItemFId, b.Descripcion, a.Cantidad, b.Piezas, b.PesoPaq";
            return this.EjecutarConsulta(cadena);
        }
        public DataSet TraerDespachoBuscar(string IdDespacho)
        {
            string cadena = "select tblDespacho.despachoid as DespachoId, tblDespacho.Placa, tblcatchofer.nombre as Chofer, tbldespacho.nroorden as NroOrden, Destino = Case Naturaleza When 'TRASPASO' THEN(SELECT NOMBRE FROM empleados.dbo.TBLSUCURSAL WHERE SUCURSALID = tblDespacho.SUCDestino) Else TBLDESPACHO.Destino END, tblDespacho.fecha as Fecha, tblDespacho.numtraspaso as NumTraspaso, tblDespacho.Obs from(tblDespacho left join tblcatchofer on tbldespacho.ci= tblcatchofer.ci) left join tblcatcamion on tbldespacho.placa = tblcatcamion.placa where tbldespacho.despachoid = '" + IdDespacho + "' order by tblDespacho.despachoid";
            return this.EjecutarConsulta(cadena);
        }
        public DataSet TraerDespachoAbierto(int _idSucursal)
        {
            string cadena = "select tblDespacho.despachoid as Codigo, tblDespacho.fecha as Fecha, tbldespacho.nroorden as NroOrden,tblDespacho.Placa,tblcatcamion.Marca,tblcatchofer.nombre as Chofer, tblDespacho.Naturaleza as TipoDespacho,DESTINO = Case Naturaleza When 'TRASPASO' THEN(SELECT NOMBRE FROM empleados.dbo.TBLSUCURSAL WHERE SUCURSALID = tblDespacho.SUCDestino) Else TBLDESPACHO.Destino END, tblDespacho.numtraspaso as NroTraspaso,tipo,tblDespacho.status as Estado,tblDespacho.LOGIN as Usuario from(tblDespacho left join tblcatchofer on tbldespacho.ci= tblcatchofer.ci) left join tblcatcamion on tbldespacho.placa = tblcatcamion.placa where sucursalid = " + _idSucursal + " AND STATUS IN('OPEN') order by tblDespacho.despachoid";
            return this.EjecutarConsulta(cadena);
        }
        public DataSet TraerDespachoEnProceso(int _idSucursal)
        {
            string cadena = "select tblDespacho.despachoid,tblDespacho.fecha,tbldespacho.nroorden,tblDespacho.Placa,tblcatcamion.Marca,tblcatchofer.nombre as chofer, tblDespacho.Naturaleza,DESTINO = Case Naturaleza When 'TRASPASO' THEN(SELECT NOMBRE FROM empleados.dbo.TBLSUCURSAL WHERE SUCURSALID = tblDespacho.SUCDestino) Else TBLDESPACHO.Destino END, tblDespacho.numtraspaso,tipo,tblDespacho.status,tblDespacho.LOGIN from(tblDespacho left join tblcatchofer on tbldespacho.ci= tblcatchofer.ci) left join tblcatcamion on tbldespacho.placa = tblcatcamion.placa where sucursalid = '" + _idSucursal + "' AND STATUS IN('INPROCESS') order by tblDespacho.despachoid";
            return this.EjecutarConsulta(cadena);
        }
        public DataSet TraerDespachoParcial(int _idSucursal)
        {
            string cadena = "select tblDespacho.despachoid,tblDespacho.fecha,tbldespacho.nroorden,tblDespacho.Placa,tblcatcamion.Marca,tblcatchofer.nombre as chofer, tblDespacho.Naturaleza,DESTINO = Case Naturaleza When 'TRASPASO' THEN(SELECT NOMBRE FROM empleados.dbo.TBLSUCURSAL WHERE SUCURSALID = tblDespacho.SUCDestino) Else TBLDESPACHO.Destino END, tblDespacho.numtraspaso,tipo,tblDespacho.status,tblDespacho.LOGIN from(tblDespacho left join tblcatchofer on tbldespacho.ci= tblcatchofer.ci) left join tblcatcamion on tbldespacho.placa = tblcatcamion.placa where sucursalid = " + _idSucursal + " AND STATUS IN('PARCIAL') order by tblDespacho.despachoid";
            return this.EjecutarConsulta(cadena);
        }
        public DataSet TraerDespachoPorCerrar(int _idSucursal)
        {
            string cadena = "select tblDespacho.despachoid,tblDespacho.fecha,tbldespacho.nroorden,tblDespacho.Placa,tblcatcamion.Marca,tblcatchofer.nombre as chofer, tblDespacho.Naturaleza,DESTINO = Case Naturaleza When 'TRASPASO' THEN(SELECT NOMBRE FROM empleados.dbo.TBLSUCURSAL WHERE SUCURSALID = tblDespacho.SUCDestino) Else TBLDESPACHO.Destino END, tblDespacho.numtraspaso,tipo,tblDespacho.status,tblDespacho.LOGIN from(tblDespacho left join tblcatchofer on tbldespacho.ci= tblcatchofer.ci) left join tblcatcamion on tbldespacho.placa = tblcatcamion.placa where sucursalid = " + _idSucursal + " AND STATUS IN('LISTAS') order by tblDespacho.despachoid";
            return this.EjecutarConsulta(cadena);
        }
        public DataSet TraerDespachoCerrado(int _idSucursal)
        {
            string cadena = "select tblDespacho.despachoid,tblDespacho.fecha,tbldespacho.nroorden,tblDespacho.Placa,tblcatcamion.Marca,tblcatchofer.nombre as chofer, tblDespacho.Naturaleza,DESTINO = Case Naturaleza When 'TRASPASO' THEN(SELECT NOMBRE FROM empleados.dbo.TBLSUCURSAL WHERE SUCURSALID = tblDespacho.SUCDestino) Else TBLDESPACHO.Destino END, tblDespacho.numtraspaso,tipo,tblDespacho.status,tblDespacho.LOGIN from(tblDespacho left join tblcatchofer on tbldespacho.ci= tblcatchofer.ci) left join tblcatcamion on tbldespacho.placa = tblcatcamion.placa where sucursalid = " + _idSucursal + " AND STATUS IN('CLOSE') order by tblDespacho.despachoid desc";
            return this.EjecutarConsulta(cadena);
        }
        public DataSet TraerTodosLosDespachos(int _idSucursal)
        {
            string cadena = "select tblDespacho.despachoid,tblDespacho.fecha,tbldespacho.nroorden,tblDespacho.Placa,tblcatcamion.Marca,tblcatchofer.nombre as chofer, tblDespacho.Naturaleza,DESTINO = Case Naturaleza When 'TRASPASO' THEN(SELECT NOMBRE FROM empleados.dbo.TBLSUCURSAL WHERE SUCURSALID = tblDespacho.SUCDestino) Else TBLDESPACHO.Destino END, tblDespacho.numtraspaso,tipo,tblDespacho.status,tblDespacho.LOGIN from(tblDespacho left join tblcatchofer on tbldespacho.ci= tblcatchofer.ci) left join tblcatcamion on tbldespacho.placa = tblcatcamion.placa where sucursalid = " + _idSucursal + " order by tblDespacho.despachoid desc";
            return this.EjecutarConsulta(cadena);
        }
        public DataSet TraerDespachoTransito(int _idSucursal)
        {
            string cadena = "select tblDespacho.despachoid,tblDespacho.fecha,tbldespacho.nroorden,tblDespacho.Placa,tblcatcamion.Marca,tblcatchofer.nombre as chofer, tblDespacho.Naturaleza,DESTINO = Case Naturaleza When 'TRASPASO' THEN(SELECT NOMBRE FROM empleados.dbo.TBLSUCURSAL WHERE SUCURSALID = tblDespacho.SUCDestino) Else TBLDESPACHO.Destino END, tblDespacho.numtraspaso,tipo,tblDespacho.status,tblDespacho.LOGIN from(tblDespacho left join tblcatchofer on tbldespacho.ci= tblcatchofer.ci) left join tblcatcamion on tbldespacho.placa = tblcatcamion.placa where sucursalid = " + _idSucursal + " AND STATUS IN('TRANSITO') order by tblDespacho.despachoid desc";
            return this.EjecutarConsulta(cadena);
        }
        public DataSet TraerDespachoCancelado(int _idSucursal)
        {
            string cadena = "select tblDespacho.despachoid,tblDespacho.fecha,tbldespacho.nroorden,tblDespacho.Placa,tblcatcamion.Marca,tblcatchofer.nombre as chofer, tblDespacho.Naturaleza,DESTINO = Case Naturaleza When 'TRASPASO' THEN(SELECT NOMBRE FROM empleados.dbo.TBLSUCURSAL WHERE SUCURSALID = tblDespacho.SUCDestino) Else TBLDESPACHO.Destino END, tblDespacho.numtraspaso,tipo,tblDespacho.status,tblDespacho.LOGIN from(tblDespacho left join tblcatchofer on tbldespacho.ci= tblcatchofer.ci) left join tblcatcamion on tbldespacho.placa = tblcatcamion.placa where sucursalid = " + _idSucursal + " AND STATUS IN('CANCEL') order by tblDespacho.despachoid desc";
            return this.EjecutarConsulta(cadena);
        }
        public DataSet TraerDespachoEntregar(int _idSucursal)
        {
            string cadena = "select tblDespacho.despachoid as Codigo,tblDespacho.fecha as Fecha,tbldespacho.nroorden as NroOrden,tblDespacho.Placa as Placa,tblcatcamion.Marca as Marca,tblcatchofer.nombre as Chofer, tblDespacho.Naturaleza as TipoDespacho,Destino = Case Naturaleza When 'TRASPASO' THEN(SELECT NOMBRE FROM empleados.dbo.TBLSUCURSAL WHERE SUCURSALID = tblDespacho.SUCDestino) Else TBLDESPACHO.Destino END, tblDespacho.numtraspaso as NroTraspaso,tipo,tblDespacho.status as Estado,tblDespacho.LOGIN as Usuario from(tblDespacho left join tblcatchofer on tbldespacho.ci= tblcatchofer.ci) left join tblcatcamion on tbldespacho.placa = tblcatcamion.placa where sucursalid = " + _idSucursal + " AND STATUS IN('Parcial') order by tblDespacho.despachoid desc";
            return this.EjecutarConsulta(cadena);
        }
        public DataSet TraerDestinoId(string _idDespacho)
        {
            string cadena = "SELECT SucDestino FROM tblDespacho where DespachoId = '" + _idDespacho + "'";
            return this.EjecutarConsulta(cadena);
        }
        public DataSet TraerUltimoId()
        {
            string cadena = "SELECT TOP 1 DespachoId FROM tblDespacho ORDER BY DespachoId DESC";
            return this.EjecutarConsulta(cadena);
        }
        public DataSet TraerDetalleDespacho(string _idDespacho)
        {
            string cadena = "select tbldespdetalle.itemid,descripcion, tbldespdetalle.Cantidad, (isnull((select SUM(cantidad) from tblDespProductos where itemid = tblItem.ItemId and despachoid = tbldespdetalle.DespachoId), 0)) as completadas from tblitem, tbldespdetalle where tblitem.itemid = tblDespdetalle.itemid and tbldespdetalle.despachoid = '" + _idDespacho + "'";
            return this.EjecutarConsulta(cadena);
        }
        public DataSet TraerDetalleDespachoSumCelda(string _idDespacho, string _itemId)
        {
            string cadena = "select isnull(sum(piezas),0) as numpaq from tbldespprogcelda where DespachoId='" + _idDespacho + "' and itemid='" + _itemId + "'";
            return this.EjecutarConsulta(cadena);
        }
        public DataSet TraerDetalleDespachoSumSob(string _idDespacho, string _itemId)
        {
            string cadena = "select sum(piezas) as numpaq from tbldespprogsob where DespachoId='" + _idDespacho + "' and itemid='" + _itemId + "'";
            return this.EjecutarConsulta(cadena);
        }
        public DataSet TraerPzaPaq(int _idSucursal, string _ItemId)
        {
            string cadena = "select MAX(Piezas) as PaqPiezas from tblPaquetes where ItemId = '" + _ItemId + "' and Status = 'activo' and SucursalId = " + _idSucursal;
            return this.EjecutarConsulta(cadena);
        }
        public DataSet TraerDespDetalleTrasp(string _idDespacho)
        {
            //string cadena = "select b.ItemFId, a.ItemId, b.descripcion, a.Cantidad from tblDespDetalle a INNER JOIN tblItem b ON a.ItemId = b.ITemId where a.DespachoId = '" + _idDespacho + "'";
            string cadena = "select b.ItemFId, a.ItemId, b.Descripcion, SUM(a.Piezas) as Cantidad, SUM(a.Peso) as Peso from tblDespProductos a INNER JOIN tblItem b ON a.ItemId = b.ItemId where a.DespachoId = '" + _idDespacho + "' GROUP BY b.ItemFId, a.ItemId, b.Descripcion";
            return this.EjecutarConsulta(cadena);
        }
        public DataSet TraerDespProductos(string _idDespacho)
        {
            string cadena = "select a.ItemId as Codigo, b.Descripcion, a.ProductoId as Paquete, a.Piezas, a.Peso, a.Metros from tblDespProductos a INNER JOIN tblItem b ON a.ItemId = b.ItemId where a.DespachoId = '" + _idDespacho + "'";
            return this.EjecutarConsulta(cadena);
        }
        public DataSet TraerDetalleCerrarDespacho(string _idDespacho)
        {
            string cadena = "select a.ItemId as Codigo, b.Descripcion, a.ProductoId as Paquete, a.Piezas, a.Peso, a.Metros, b.Calidad, c.CeldaId, c.CentroTrabajo, a.Cantidad from tblDespProductos a INNER JOIN tblItem b ON a.ItemId = b.ItemId INNER JOIN tblPaquetes c ON a.ProductoId = c.PaqueteId where a.DespachoId = '" + _idDespacho + "'";
            return this.EjecutarConsulta(cadena);
        }
        //EditarDespacho
        public int EditarDespacho(DespachoEditar _DespEdit)
        {
            return EjecutarComando("UPDATE tblDespacho SET Fecha = '" + _DespEdit.p_Fecha.ToString("yyyyMMdd") + "', Id_Camion = " + _DespEdit.p_Id_Camion + ", Placa = '" + _DespEdit.p_Placa + "', Chofer = '" + _DespEdit.p_Chofer + "', CI = '" + _DespEdit.p_CI + "', Obs = '" + _DespEdit.p_Obs + "', SucursalId = " + _DespEdit.p_SucursalId + ", SucDestino = '" + _DespEdit.p_SucDestino + "', Naturaleza = '" + _DespEdit.p_Naturaleza + "' WHERE DespachoId = '" + _DespEdit.p_DespachoId + "'");
            //despDet.DespachoId, despDet.ItemId, despDet.Cantidad, despDet.SolPiezasSueltas, despDet.CantConfirmada, despDet.Unidad, despDet.Status, despDet.SucursalId
        }
        //Entrega
        public DataSet TraerDespachoCerradoEntrega(int _idSucursal)
        {
            string cadena = "select tblDespacho.despachoid,tblDespacho.fecha, tblDespacho.Naturaleza,DESTINO = Case Naturaleza When 'TRASPASO' THEN(SELECT NOMBRE FROM empleados.dbo.TBLSUCURSAL WHERE SUCURSALID = tblDespacho.SUCDestino) Else TBLDESPACHO.Destino END, tblDespacho.status from tblDespacho where sucursalid = " + _idSucursal + " AND STATUS IN('CLOSE') order by tblDespacho.despachoid desc";
            return this.EjecutarConsulta(cadena);
        }
        public DataSet TraerDetalleDespachoEntrega(string _idDespacho)
        {
            //string cadena = "select a.ItemId as Codigo, b.Descripcion, a.ProductoId as Paquete, a.Piezas, a.Peso, a.Metros from tblDespProductos a INNER JOIN tblItem b ON a.ItemId = b.ItemId where a.SucursalId = " + _idSucursal;
            string cadena = "select a.ItemId as Codigo, b.Descripcion, a.ProductoId as Paquete, a.Piezas, a.Peso, a.Metros from tblDespProductos a INNER JOIN tblItem b ON a.ItemId = b.ItemId where a.Despachoid = '" + _idDespacho + "'";
            return this.EjecutarConsulta(cadena);
        }
        public DataSet ConsultarDespachoEntrega(string _idDespacho)
        {
            string cadena = "select tblDespacho.despachoid as DespachoId, tblDespacho.Placa, tblcatchofer.nombre as Chofer, tblDespacho.fecha as Fecha from(tblDespacho left join tblcatchofer on tbldespacho.ci= tblcatchofer.ci) left join tblcatcamion on tbldespacho.placa = tblcatcamion.placa where tbldespacho.despachoid = '" + _idDespacho + "' order by tblDespacho.despachoid";
            return this.EjecutarConsulta(cadena);
        }
        public DataSet TraerDespachoTraspaso(string _despachoId)
        {
            string cadena = "SELECT DespachoId, SucursalId, SucDestino FROM tblDespacho WHERE DespachoId = '" + _despachoId + "' AND STATUS IN('INPROCESS') order by DespachoId";
            return this.EjecutarConsulta(cadena);
        }
        public DataSet TraerListaChoferes()
        {
            string cadena = "";
            return this.EjecutarConsulta(cadena);
        }
        public DataSet TraerTodoDespacho(string where)
        {
            return this.Consultar(where);
        }
        public DataSet TraerTodoDespacho(string estado, int sucursal)
        {
            string consulta = "Select despachoId,NroOrden,Placa,Destino from tblDespacho where status='" + estado + "' and SucursalID=" + sucursal;
            return this.EjecutarConsulta(consulta);
        }
        public int ModificarDespacho(Despacho oDespacho)
        {
            DbCommand cmdModificar = Adapter.UpdateCommand;
            cmdModificar.Parameters["@Fecha"].Value = oDespacho.p_Fecha;
            cmdModificar.Parameters["@NroOrden"].Value = oDespacho.p_NroOrden;
            cmdModificar.Parameters["@Placa"].Value = oDespacho.p_Placa;
            cmdModificar.Parameters["@Marca"].Value = oDespacho.p_Marca;
            cmdModificar.Parameters["@Chofer"].Value = oDespacho.p_Chofer;
            cmdModificar.Parameters["@CI"].Value = oDespacho.p_CI;
            cmdModificar.Parameters["@Destino"].Value = oDespacho.p_Destino;
            cmdModificar.Parameters["@Login"].Value = oDespacho.p_Login;
            cmdModificar.Parameters["@Status"].Value = oDespacho.p_status;
            cmdModificar.Parameters["@Correlativo"].Value = oDespacho.p_Correlativo;
            cmdModificar.Parameters["@Obs"].Value = oDespacho.p_Obs;
            cmdModificar.Parameters["@Tipo"].Value = oDespacho.p_Tipo;
            cmdModificar.Parameters["@Cargador"].Value = oDespacho.p_Cargador;
            cmdModificar.Parameters["@NumTraspaso"].Value = oDespacho.p_NumTraspaso;
            cmdModificar.Parameters["@SucursalId"].Value = oDespacho.p_SucursalId;
            cmdModificar.Parameters["@SucDestino"].Value = oDespacho.p_SucDestino;
            cmdModificar.Parameters["@HorarioPartida"].Value = oDespacho.p_HorarioPartida;
            cmdModificar.Parameters["@HorarioLlegada"].Value = oDespacho.p_HorarioLlegada;
            cmdModificar.Parameters["@Naturaleza"].Value = oDespacho.p_Naturaleza;
            cmdModificar.Parameters["@Anticipado"].Value = oDespacho.p_Anticipado;
            return EjecutarComando(cmdModificar);
        }
        //public Cliente TraerMovDetalle(int idCliente)
        //{
        //    DataSet ds = this.Consultar("IdCliente=" + idCliente);
        //    DataTable tClientes = ds.Tables[0];
        //    if (tClientes.Rows.Count == 0)
        //    {
        //        return null;
        //    }
        //    DataRow rCliente = tClientes.Rows[0];
        //    Cliente oCliente = new Cliente();
        //    oCliente.IdCliente = idCliente;
        //    oCliente.Nombre = rCliente["Nombre"].ToString();
        //    oCliente.ApellidoPaterno = rCliente["ApellidoPaterno"].ToString();
        //    oCliente.ApellidoMaterno = rCliente["ApellidoMaterno"].ToString();
        //    oCliente.Documento = rCliente["Documento"].ToString();
        //    oCliente.Sexo = rCliente["Sexo"].ToString();
        //    oCliente.CantidadHijos = Convert.ToInt32(rCliente["CantidadHijos"]);
        //    return oCliente;
        //}
        public int EliminarDespacho(string _IdDespacho)
        {
            return EjecutarComando("DELETE FROM tblDespacho WHERE DespachoId = '" + _IdDespacho + "'");
        }
        public int MarcarEliminado(int docId, int Valor)
        {
            return EjecutarComando("UPDATE dbo.documentos set eliminado = " + Valor + " WHERE docId=" + docId.ToString());
        }
        public DataSet BuscarDespacho(string nombDocumento)
        {
            string cadena = "select docId,tituloDocumento,autor from documentos where tituloDocumento like '%" + nombDocumento + "%'";
            return EjecutarConsulta(cadena);
        }
        //TraerPaqueteOrdendeProduccion
        public DataSet TraerPaqProduccion(string _OrdenId)
        {
            string cadena = "select b.PaqueteId from tblPlan a INNER JOIN tblPlanLocaliza b ON a.PlanId = b.PlanId where a.OrdenId = '" + _OrdenId + "'";
            return EjecutarConsulta(cadena);
        }
        public DataSet TraerInfoPaquete(string _paqueteId, int _idSucursal)
        {
            string consulta = "SELECT a.ItemId, c.ItemFId, c.Descripcion, a.PaqueteId, SUM(a.Piezas) as Piezas, SUM(a.Peso) as Peso, c.UnidadF " +
                "FROM tblPaquetes a INNER JOIN tblSucItem b ON a.ItemId = b.ItemId INNER JOIN tblItem c ON a.ItemId = c.Itemid " +
                "where b.SucursalId = " + _idSucursal + " AND PaqueteId = '" + _paqueteId + "' group by a.ItemId, c.ItemFId, c.Descripcion, a.PaqueteId, a.Fecha, c.UnidadF " +
                "order by a.Fecha ASC";
            return this.EjecutarConsulta(consulta);
        }
        //TraerDataNroOrden
        public DataSet TraerDataNroOrden(int _IdSucursal, string _ItemFId)
        {
            string cadena = "select a.ItemId, a.Descripcion, SUM(b.Piezas) as PiezasStock, a.PesoPaq, a.Piezas, a.ItemFId FROM tblItem a " +
                "INNER JOIN tblPaquetes b ON a.ItemId = b.ItemId INNER JOIN tblSucItem c ON a.ItemId = c.ItemId WHERE c.SucursalId = " + _IdSucursal + " AND a.ItemFId = '" + _ItemFId + "'" +
                "group by a.ItemId, a.Descripcion, a.PesoPaq, a.Piezas, a.ItemFId";
            return EjecutarConsulta(cadena);
        }
        public DataSet ConsultarDespacho(string _IdDespacho)
        {
            return EjecutarConsulta("select a.DespachoId, a.Naturaleza, a.Fecha, d.Nombre as Chofer, a.CI, a.Placa, c.Marca as Marca, a.SucDestino, a.NroOrden, a.NumTraspaso, a.Tipo, a.Obs, a.Id_Camion from tblDespacho a INNER JOIN tblCatCamion c ON a.Id_Camion = c.Id_Camion INNER JOIN tblCatChofer d ON a.CI = d.CI where DespachoId = '" + _IdDespacho + "' order by a.DespachoId");
        }
        //Ejecutar
        public int ModificarEjecutarAenProceso(string _IdDespacho)
        {
            return EjecutarComando("UPDATE tblDespacho SET Status = 'INPROCESS' WHERE DespachoId = '" + _IdDespacho + "'");
        }
        public int ModificarEjecutarAParcial(string _IdDespacho)
        {
            return EjecutarComando("UPDATE tblDespacho SET Status = 'PARCIAL' WHERE DespachoId = '" + _IdDespacho + "'");
        }
        public int ModificarEjecutarAListaACerrar(string _IdDespacho)
        {
            return EjecutarComando("UPDATE tblDespacho SET Status = 'LISTAS' WHERE DespachoId = '" + _IdDespacho + "'");
        }
        public int ModificarEjecutarACerrar(string _IdDespacho)
        {
            return EjecutarComando("UPDATE tblDespacho SET Status = 'CLOSE' WHERE DespachoId = '" + _IdDespacho + "'");
        }
        //Undo
        public int ModificarUndoAListaACerrar(string _idDespacho)
        {
            return EjecutarComando("UPDATE tblDespacho SET Status = 'LISTAS' WHERE DespachoId = '" + _idDespacho + "'");
        }
        public int ModificarUndoAParcial(string _idDespacho)
        {
            return EjecutarComando("UPDATE tblDespacho SET Status = 'PARCIAL' WHERE DespachoId = '" + _idDespacho + "'");
        }
        public int ModificarUndoAEnProceso(string _idDespacho)
        {
            return EjecutarComando("UPDATE tblDespacho SET Status = 'INPROCESS' WHERE DespachoId = '" + _idDespacho + "'");
        }
        public int ModificarUndoAAbierto(string _idDespacho)
        {
            return EjecutarComando("UPDATE tblDespacho SET Status = 'OPEN' WHERE DespachoId = '" + _idDespacho + "'");
        }
        //Observacion
        public DataSet TraerObsDespacho(string _idDespacho)
        {
            string cadena = "select Obs from tblDespacho where DespachoId = '" + _idDespacho + "'";
            return this.EjecutarConsulta(cadena);
        }
        public int ModificarObsDespacho(string _idDespacho, string _obs)
        {
            return EjecutarComando("UPDATE tblDespacho SET Obs = '" + _obs + "' WHERE DespachoId = '" + _idDespacho + "'");
        }
        //Control Despacho
        public DataSet TraerControlDespacho(string _idDespacho)
        {
            string cadena = "select a.ItemId, a.ItemFId, b.Descripcion, a.ProductoId, a.Cantidad, a.Peso from tblDespProductos a INNER JOIN tblItem b ON a.ItemId = b.ItemId where a.DespachoId = '" + _idDespacho + "'";
            return this.EjecutarConsulta(cadena);
        }
        public DataSet TraerTotalControlDespacho(string _idDespacho)
        {
            //string cadena = "select ItemId, SUM(Peso) as PesoTotal, SUM(Piezas) as PiezasTotal FROM tblDespProductos WHERE DespachoId = '" + _idDespacho + "' GROUP BY ItemId";
            string cadena = "select SUM(Cantidad) as PiezasTotal, SUM(Peso) as PesoTotal FROM tblDespProductos WHERE DespachoId = '" + _idDespacho + "'";
            return this.EjecutarConsulta(cadena);
        }
        //Reportes
        public DataSet TraerDespachoImpCabeceraA(string _idDespacho)
        {
            string cadena = "select  a.ItemId, a.ItemFId, b.Descripcion, a.ProductoId, a.Piezas, a.Peso from tblDespProductos a INNER JOIN tblItem b ON a.ItemId = b.ItemId where a.DespachoId = '" + _idDespacho + "'";
            return this.EjecutarConsulta(cadena);
        }
        public DataSet TraerDespachoImpDetalleA(string _idDespacho)
        {
            string cadena = "select ProductoId as Codigo, CeldaId as Celda, Piezas, Peso as Kgs from tblDespProductos where DespachoId = '" + _idDespacho + "'";
            return this.EjecutarConsulta(cadena);
        }
        //Sucursal
        public DataSet TraerSucursalesDespacho()
        {
            string cadena = "select SucursalID, Nombre from empleados.dbo.tblSucursal";
            return this.EjecutarConsulta(cadena);
        }
        //Lista Cronograma
        public DataSet TraerPaquetesCronograma(int _idSucursal, string _ItemId, int _Piezas)
        {
            //string cadena = "SELECT a.CeldaId, SUM(a.piezas) as StockPiezas, COUNT(a.piezas) as StockPaquetes, a.Fecha, DATEDIFF(DAY, a.Fecha, GETDATE()) AS Antiguedad FROM tblPaquetes a INNER JOIN tblCeldas b ON a.CeldaId = b.CeldaId where b.SucursalId = " + _idSucursal + " AND a.ItemId = '" + _ItemId + "' AND a.Status = 'activo' AND a.Piezas = " + _Piezas + " GROUP BY a.CeldaId, a.Fecha";
            string cadena = "select tblPaquetes.CeldaId, sum(tblPaquetes.piezas) as StockPiezas, count(*) as StockPaquetes, min(convert(date, tblPaquetes.Fecha)) as Fecha, DATEDIFF(day, CONVERT(date, min(tblPaquetes.Fecha)), sysdatetime()) AS Antiguedad from tblitem, tblPaquetes where tblpaquetes.SucursalId = " + _idSucursal + " and tblpaquetes.Status = 'ACTIVO' and tblitem.ItemId = tblPaquetes.ItemId and tblItem.Piezas = tblPaquetes.Piezas and tblpaquetes.ItemId = '" + _ItemId + "' group by tblPaquetes.ITEMID,tblitem.Descripcion,tblPaquetes.CeldaId order by min(convert(date, tblPaquetes.Fecha)),tblPaquetes.CeldaId";
            return this.EjecutarConsulta(cadena);
        }
        public DataSet TraerSobrantesCronograma(int _idSucursal, string _ItemId, string _despachoId)
        {
            //string cadena = "SELECT a.CeldaId, a.PaqueteId, SUM(a.piezas) FROM tblPaquetes a INNER JOIN tblCeldas b ON a.CeldaId = b.CeldaId where b.SucursalId = " + _idSucursal + " AND a.ItemId = '" + _ItemId + "' AND a.Status = 'activo' AND a.Piezas != " + _Piezas + " GROUP BY a.CeldaId, a.PaqueteId";
            string cadena = "select tblpaquetes.celdaid,tblPaquetes.PaqueteId,tblPaquetes.Piezas from tblpaquetes, tblitem where tblpaquetes.SucursalId=" + _idSucursal + " and tblpaquetes.Status='ACTIVO' and tblitem.ItemId=tblPaquetes.ItemId and tblItem.Piezas<>tblPaquetes.Piezas and tblpaquetes.ItemId='" + _ItemId + "' and tblpaquetes.PaqueteId not in (select paqueteid from tbldespacho, tbldespprogsob where tbldespacho.despachoid=tbldespprogsob.despachoid and TBLDESPprogsob.ItemId='" + _ItemId + "' and (tbldespacho.status<>'CANCEL' and tbldespacho.status<>'CLOSE' ) and tblDespacho.DespachoId<>'" + _despachoId + "')";
            return this.EjecutarConsulta(cadena);
        }
        //TraerDespProg
        public DataSet TraerDespProg(string _DespachoId, string _ItemId)
        {
            string cadena = "SELECT CeldaId, Piezas, Paquetes FROM tblDespProgCelda WHERE DespachoId = '" + _DespachoId + "' AND ItemId = '" + _ItemId + "'";
            return this.EjecutarConsulta(cadena);
        }
        //TraerSobProg
        public DataSet TraerSobProg(string _DespachoId, string _ItemId)
        {
            string cadena = "SELECT CeldaId, Piezas FROM tblDespProgSob WHERE DespachoId = '" + _DespachoId + "' AND ItemId = '" + _ItemId + "'";
            return this.EjecutarConsulta(cadena);
        }
        //TraerSucursal
        public DataSet TraerSucursalesVenta()
        {
            string consulta = "select SucursalID, Nombre from tblSucursal";
            return this.EjecutarConsulta(consulta);
        }
        //Correlativo
        public DataSet TraerCorrelativo(int _idSucursal, string Tipo)
        {
            string cadena = "select * from Sys_Secuencia where Operacion = '" + Tipo + "' and sucursal=" + _idSucursal;
            return this.EjecutarConsulta(cadena);
        }
    }
}
