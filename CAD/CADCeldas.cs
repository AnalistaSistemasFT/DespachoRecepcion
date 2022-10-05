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
            par.ParameterName = "@CeldasId";
            par.DbType = DbType.Int32;
            par.Direction = ParameterDirection.Output;
            Adapter.InsertCommand.CommandText += ";SELECT @CeldasId=SCOPE_IDENTITY();";
            Adapter.InsertCommand.Parameters.Add(par);
        }
        public int GuardarCeldas(Celdas oCeldas)
        {
            DbCommand cmdInsert = Adapter.InsertCommand;
            cmdInsert.Parameters["@CeldasId"].Value = oCeldas.CeldaId;
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
            cmdModificar.Parameters["@CeldasId"].Value = oCeldas.CeldaId;
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

    }
}
