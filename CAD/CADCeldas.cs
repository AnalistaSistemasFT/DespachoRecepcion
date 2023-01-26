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
    public class CADCeldas:DBDAC
    {

        public CADCeldas()
            : base("SQLSERVER", "dbo.tblCeldas")
        {

            DbParameter par = this.CrearParametro();
            par.ParameterName = "@CeldaId";
            par.DbType = DbType.Int32;
            par.Direction = ParameterDirection.Output;
            Adapter.InsertCommand.CommandText += ";SELECT @CeldaId=SCOPE_IDENTITY();";
            Adapter.InsertCommand.Parameters.Add(par);
        }
        public int GuardarCeldas(Celdas oCeldas)
        {
            DbCommand cmdInsert = Adapter.InsertCommand;
            cmdInsert.Parameters["@CeldaId"].Value = oCeldas.CeldaId;
            cmdInsert.Parameters["@SucursalId"].Value = oCeldas.SucursalId;
            cmdInsert.Parameters["@AlmacenId"].Value = oCeldas.AlmacenId;
            cmdInsert.Parameters["@Area"].Value = oCeldas.Area;
            cmdInsert.Parameters["@Segmento"].Value = oCeldas.Segmento;
            cmdInsert.Parameters["@Fila"].Value = oCeldas.Fila;
            cmdInsert.Parameters["@Nave"].Value = oCeldas.Nave;
            cmdInsert.Parameters["@Columna"].Value = oCeldas.Columna;
            cmdInsert.Parameters["@ItemId"].Value = oCeldas.ItemId;
            cmdInsert.Parameters["@Unidades"].Value = oCeldas.Unidades;
            cmdInsert.Parameters["@Kgs"].Value = oCeldas.Kgs;
            cmdInsert.Parameters["@Status"].Value = oCeldas.Status;
            cmdInsert.Parameters["@Proceso"].Value = oCeldas.Proceso;
            cmdInsert.Parameters["@PreAsignado"].Value = oCeldas.PreAsignado;
            cmdInsert.Parameters["@CeldaTemp"].Value = oCeldas.CeldaTemp;
            return EjecutarComando(cmdInsert);
        }

        public DataSet TraerTodoCeldas()
        {
            return this.Consultar("");
        }
        public DataSet TraerTodoCeldas(string where)
        {
            return this.Consultar(where);
        }
        public DataSet TraerTodoCeldas(string estado, int sucursal)
        {
            string consulta = "Select despachoId as [Nro Despacho], NroOrden as [Nro Orden] ,Placa,Destino from tblDespacho where status='" + estado + "' and SucursalID=" + sucursal;
            return this.EjecutarConsulta(consulta);
        }
        public int ModificarCeldas(Celdas oCeldas)
        {
            DbCommand cmdModificar = Adapter.UpdateCommand;
            cmdModificar.Parameters["@CeldaId"].Value = oCeldas.CeldaId;
            cmdModificar.Parameters["@SucursalId"].Value = oCeldas.SucursalId;
            cmdModificar.Parameters["@AlmacenId"].Value = oCeldas.AlmacenId;
            cmdModificar.Parameters["@Area"].Value = oCeldas.Area;
            cmdModificar.Parameters["@Segmento"].Value = oCeldas.Segmento;
            cmdModificar.Parameters["@Fila"].Value = oCeldas.Fila;
            cmdModificar.Parameters["@Nave"].Value = oCeldas.Nave;
            cmdModificar.Parameters["@Columna"].Value = oCeldas.Columna;
            cmdModificar.Parameters["@ItemId"].Value = oCeldas.ItemId;
            cmdModificar.Parameters["@Unidades"].Value = oCeldas.Unidades;
            cmdModificar.Parameters["@Kgs"].Value = oCeldas.Kgs;
            cmdModificar.Parameters["@Status"].Value = oCeldas.Status;
            cmdModificar.Parameters["@Proceso"].Value = oCeldas.Proceso;
            cmdModificar.Parameters["@PreAsignado"].Value = oCeldas.PreAsignado;
            cmdModificar.Parameters["@CeldaTemp"].Value = oCeldas.CeldaTemp;
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
        public int EliminarCeldas(int docId)
        {
            return EjecutarComando("DELETE FROM dbo.documentos WHERE docId=" + docId.ToString());
        }

        public int MarcarEliminado(int docId, int Valor)
        {
            return EjecutarComando("UPDATE dbo.documentos set eliminado = " + Valor + " WHERE docId=" + docId.ToString());
        }
        public DataSet BuscarCeldas(string nombDocumento)
        {
            string cadena = "select docId,tituloDocumento,autor from documentos where tituloDocumento like '%" + nombDocumento + "%'";
            return EjecutarConsulta(cadena);
        }
        public DataSet CargarCeldasCombo(int Suc)
        {
            string consulta = "SELECT C.celdaId" +
                         " FROM  [LYBK].[dbo].[tblCeldas] C where SucursalId="+ Suc;

            //string consulta = "SELECT P.ProductoId,rtrim(P.Descripcion) + ' ('+ rtrim(U.DESCRIPCION) +')' as Descripcion " +
            //              " FROM [Inventario].[dbo].[tblProductos] P inner join CatUnidades U on p.Unidad=U.ID_UNIDAD";

            return this.EjecutarConsulta(consulta);
        }

        public int ModificarCeldaSobrante(string sCelda)
        {
            return EjecutarComando("update tblCeldas set unidades=unidades+1 where celdaid='"+sCelda+"'");
        }

        public int InsertarPaquete(string sPaquete,DateTime dtFecha,string sCelda,string sItem,decimal dPeso,string sColada,string sCentro)
        {
            string sInsert = @"insert into tblPaquetes (paqueteid,Sucursalid,almacenid,fecha,celdaid,nivel,itemid,itemFId,login,status,peso,piezas,Metros,ordenid,contenedor,colada,centrotrabajo)
                            values('{0}', 12081, 3, '{1}', '{2}', 0, '{3}', '', '', 'ACTIVO', {4}, 1, 0, '', '0', '{5}', '{6}')";
            sInsert = string.Format(sInsert, sPaquete, dtFecha, sCelda, sItem, dPeso, sColada, sCentro);

            return EjecutarComando(sInsert);
        }

        public DataSet CargarCeldaAsignada(string Item, int sucursal, int almacen)
        {
            string consulta = @"Select tblceldas.celdaid from (tblItem inner join tblcatnaturaleza on tblitem.Presentacion = tblcatnaturaleza.naturalezaid) inner join
                                tblceldas on tblCeldas.ItemId = tblcatnaturaleza.itemid where tblitem.itemid = '{0}'  and tblceldas.sucursalid = {1} order by Nave, Columna, Area, segmento";

            consulta = string.Format(consulta, Item, sucursal);
            return this.EjecutarConsulta(consulta);
        }

        public DataSet CargarCeldaAsignada( int sucursal)
        {
            string consulta = @"Select tblceldas.celdaid from tblceldas where  tblCeldas.sucursalid = '{0}' order by Nave, Columna, Area, segmento";

            consulta = string.Format(consulta, sucursal);
            return this.EjecutarConsulta(consulta);
        }
        public DataSet VistaAlmacenes(int _IdSucursal)
        {
            //string consulta = "select Area, Segmento, Nave, Columna, CeldaId from tblCeldas where SucursalId = 12081 order by Area, Segmento, Nave";
            string consulta = "select a.Area, a.Segmento, a.Nave, a.Columna, a.CeldaId, a.ItemId, a.Unidades, b.UnidadesXCelda, a.Status from tblCeldas a INNER JOIN tblItem b ON a.ItemId = b.ItemId where SucursalId = " + _IdSucursal + " order by Area, Segmento, Nave";
            return EjecutarConsulta(consulta);
        }
        public DataSet VistaAlmacenesMaquinas(int _IdSucursal)
        {
            string consulta = "select CeldaId from tblCeldas where SucursalId = " + _IdSucursal + " AND Status = 2";
            return EjecutarConsulta(consulta);
        }
        public DataSet VistaAlmacenesOficinas(int _IdSucursal)
        {
            string consulta = "select CeldaId from tblCeldas where SucursalId = " + _IdSucursal + " AND Status = 3";
            return EjecutarConsulta(consulta);
        }
        public DataSet VistaAlmacenesCarriles(int _IdSucursal)
        {
            string consulta = "select CeldaId from tblCeldas where SucursalId = " + _IdSucursal + " AND Status = 4";
            return EjecutarConsulta(consulta);
        }
        public DataSet DatosAlmacen(int _IdSucursal)
        {
            string consulta = "select AlmacenId, SucursalId, Nombre, Areas, Naves from tblAlmacen where SucursalId = " + _IdSucursal;
            return EjecutarConsulta(consulta);
        }
        public DataSet DatosEstante(int _IdSucursal)
        {
            string consulta = "Select CodigoEstante, CeldaId, Unidades, Kgs, Max_Kgs from tblCeldasEstante where AlmacenId = " + _IdSucursal + " AND Status = 1";
            return EjecutarConsulta(consulta);
        }
        public DataSet TraerEstantesCelda(int _IdSucursal, string _CeldaId, int _Fila)
        {
            string consulta = "select CodigoEstante, Unidades, Kgs, Max_Kgs from tblCeldasEstante";
            return EjecutarConsulta(consulta);
        }
        public DataSet TraerRelocalizacionPendiente(int _IdSucursal)
        {
            string consulta = "select a.RelocalizaId as NroPlan, a.Fecha, a.ItemId, b.Descripcion, a.CeldaOrigen as Origen, a.CeldaDestino as Destino, a.Login, a.Status from tblRelocaliza a INNER JOIN tblItem b ON a.ItemId = b.ItemId where a.Status = 'OPEN' AND a.SucursalId = " + _IdSucursal;
            return EjecutarConsulta(consulta);
        }
        public DataSet TraerDetalleRelocalizacionPendiente(string _NroPlan)
        {
            string consulta = "select a.PaqueteId, b.CeldaDestino as Destino, a.Status, a.AlmacenId as Almacen, a.CeldaId as Celda from tblPlanLocaliza a INNER JOIN tblRelocaliza b ON a.PlanId = b.RelocalizaId Where a.PlanId = '" + _NroPlan + "'";
            return EjecutarConsulta(consulta);
        }
        public DataSet TraerRelocalizacionCerrada(int _IdSucursal)
        {
            string consulta = "select a.RelocalizaId as NroPlan, a.Fecha, a.ItemId, b.Descripcion, a.CeldaOrigen as Origen, a.CeldaDestino as Destino, a.Login, a.Status from tblRelocaliza a INNER JOIN tblItem b ON a.ItemId = b.ItemId where a.Status = 'CLOSE' AND a.SucursalId = " + _IdSucursal;
            return EjecutarConsulta(consulta);
        }
        public DataSet TraerDetalleRelocalizacionCerrada(string _NroPlan)
        {
            string consulta = "select PaqueteId as Paquete, CeldaId as Destino from tblRelocDetalle where RelocalizaId = '" + _NroPlan + "'";
            return EjecutarConsulta(consulta);
        }
        public DataSet TraerListaCeldas(int _IdSucursal)
        {
            string consulta = "select CeldaId, Unidades, Area, Segmento, Nave, Columna, CASE WHEN Status = 0 THEN 'Cero' WHEN Status = 1 THEN 'Habilitado' WHEN Status = 2 THEN 'Maquina' WHEN Status = 3 THEN 'Oficina' WHEN Status = 4 THEN 'Carril' ELSE 'NO ASIGNADO' END AS Estado from tblCeldas WHERE SucursalId = " + _IdSucursal + " order by Nave, CeldaId";
            return EjecutarConsulta(consulta);
        }
        public int EditarCelda(string _Celda, int _Area, string _Segmento, int _Nave, string _Columna, int _Estado, int _Unidades)
        {
            return EjecutarComando("UPDATE tblCeldas SET Area = " + _Area + ", Segmento = '" + _Segmento + "', Nave = " + _Nave + ", Columna = '" + _Columna + "', Status = " + _Estado + ", Unidades = " + _Unidades + " WHERE CeldaId = '" + _Celda + "'");
        }
        public int AgregarCelda(Celdas _celda)
        {
            return EjecutarComando("INSERT INTO tblCeldas([SucursalId],[CeldaId],[AlmacenId],[Area],[Segmento],[Fila],[Nave],[Columna],[ItemId],[Unidades],[Kgs],[Status],[Proceso],[PreAsignado],[CeldaTemp]) " +
                "VALUES("+ _celda.SucursalId + ", '" + _celda.CeldaId + "', " + _celda.AlmacenId + ", " + _celda.Area + ", '" + _celda.Segmento + "', " + _celda.Fila + ", " + _celda.Nave + ", '" + _celda.Columna + "', '" + _celda.ItemId + "', " + _celda.Unidades + ", " + _celda.Kgs + ", " + _celda.Status + ", '" + _celda.Proceso + "', " + _celda.PreAsignado + ", '" + _celda.CeldaTemp + "');");
        }
        public DataSet BuscarAlmacenId(int _IdSucursal)
        {
            string consulta = "select AlmacenId, Areas, Naves from tblAlmacen where SucursalId = " + _IdSucursal;
            return EjecutarConsulta(consulta);
        }
        public DataSet TraerDetalleAlmacen(int _IdSucursal, int _AlmacenId)
        {
            string consulta = "select tblCeldas.ItemId,tblItem.ItemFId,tblitem.Descripcion,(tblItem.CapVertical*tblItem.Caphorizontal) as paqXcelda, count(*) as celdaUtil,(tblItem.CapVertical*tblItem.Caphorizontal* COUNT(*)) as capinst,SUM(tblceldas.unidades) as caputil, (tblItem.CapVertical * tblItem.Caphorizontal * COUNT(*) * tblitem.pesopaq) as capinstkg,(SUM(tblceldas.unidades) * tblItem.PesoPaq) as caputilkg from tblCeldas, tblItem where tblCeldas.ItemId = tblitem.itemid and tblCeldas.sucursalid = " + _IdSucursal + " and tblCeldas.AlmacenId = " + _AlmacenId + " group by tblCeldas.ItemId,tblItem.ItemFId,tblitem.descripcion,tblItem.CapHorizontal,tblItem.CapVertical,tblItem.PesoPaq";
            return EjecutarConsulta(consulta);
        }
        public DataSet TraerTipoRack(string _CeldaId)
        {
            string consulta = "select Rack from tblCeldasEstante where CeldaId = '" + _CeldaId + "'";
            return EjecutarConsulta(consulta);
        }
        public int EditData(string CeldaEdit)
        {
            //string EstanteEdit = "ALTER TABLE tblPaquetes ADD EstanteId varchar(20)";

            //return EjecutarComando("INSERT INTO tblCeldasEstante (SucursalId, CeldaId, AlmacenId, Area, Segmento, Fila, Nave, Columna, ItemId, Unidades, Kgs, Status, Proceso, PreAsignado, CeldaTemp) VALUES (12081, 'AL3:6A-1S3', 3, 1, 'S3', 0, 6, 'A', 'Maquina', 0, 0, 2, 'Llenado', 1, '')");
            return EjecutarComando("UPDATE tblCeldasEstante SET CodigoEstante = 'AL3:6A-4S2' WHERE EstanteId = 16");
            //return EjecutarComando("ALTER TABLE tblCeldasEstante ADD Rack int not null default 0");
            //return EjecutarComando(EstanteEdit);
        }
    }
}