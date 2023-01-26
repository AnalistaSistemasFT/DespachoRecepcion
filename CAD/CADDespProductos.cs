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
    public class CADDespProductos:DBDAC
    {
        public CADDespProductos()
            : base("SQLSERVER", "dbo.tblDespProductos")
        {

            //DbParameter par = this.CrearParametro();
            //par.ParameterName = "@DespachoId";
            //par.DbType = DbType.Int32;
            //par.Direction = ParameterDirection.Output;
            //Adapter.InsertCommand.CommandText += ";SELECT @DespachoId=SCOPE_IDENTITY();";
            //Adapter.InsertCommand.Parameters.Add(par);
        }
        public int GuardarDespProductos(DespProductos oDespProductos)
        {
            DbCommand cmdInsert = Adapter.InsertCommand;
            cmdInsert.Parameters["@DespachoId"].Value = oDespProductos.DespachoId;
            cmdInsert.Parameters["@ProductoId"].Value = oDespProductos.ProductoId;
            cmdInsert.Parameters["@ItemId"].Value = oDespProductos.ItemId;
            cmdInsert.Parameters["@Fecha"].Value = oDespProductos.Fecha;
            cmdInsert.Parameters["@Status"].Value = oDespProductos.Status;
            cmdInsert.Parameters["@Cantidad"].Value = oDespProductos.Cantidad;
            cmdInsert.Parameters["@Peso"].Value = oDespProductos.Peso;
            cmdInsert.Parameters["@CeldaId"].Value = oDespProductos.CeldaId;
            cmdInsert.Parameters["@SucursalId"].Value = oDespProductos.SucursalId;
            cmdInsert.Parameters["@ItemFId"].Value = oDespProductos.ItemFId;
            cmdInsert.Parameters["@Piezas"].Value = oDespProductos.Piezas;
            cmdInsert.Parameters["@Metros"].Value = oDespProductos.Metros;
            cmdInsert.Parameters["@Colada"].Value = oDespProductos.Colada;

            return EjecutarComando(cmdInsert);
        }
        public DataSet VerificarLlaves(string _idDespacho, string _idPaquete)
        {
            string consulta = "select * from tblDespProductos where DespachoId = '" + _idDespacho + "' AND ProductoId = '" + _idPaquete + "'";
            return this.EjecutarConsulta(consulta);
        }
        public int ModificarCantidad(string _idDespacho, string _idPaquete, int _cantRetirada, decimal _pesoNuevo)
        {
            return EjecutarComando("update tblDespProductos set Cantidad = " + _cantRetirada + ", Peso = " + _pesoNuevo + " where DespachoId = '" + _idDespacho + "' AND ProductoId = '" + _idPaquete + "'");
        }
        public DataSet TraerTodoDespProductos()
        {
            return this.Consultar("");
        }
        public DataSet TraerTodoDespProductos(string where)
        {
            return this.Consultar(where);
        }
        public int ModificarDespProductos(DespProductos oDespProductos)
        {
            DbCommand cmdModificar = Adapter.UpdateCommand;
            cmdModificar.Parameters["@DespachoId"].Value = oDespProductos.DespachoId;
            cmdModificar.Parameters["@ProductoId"].Value = oDespProductos.ProductoId;
            cmdModificar.Parameters["@ItemId"].Value = oDespProductos.ItemId;
            cmdModificar.Parameters["@Fecha"].Value = oDespProductos.Fecha;
            cmdModificar.Parameters["@Status"].Value = oDespProductos.Status;
            cmdModificar.Parameters["@Cantidad"].Value = oDespProductos.Cantidad;
            cmdModificar.Parameters["@Peso"].Value = oDespProductos.Peso;
            cmdModificar.Parameters["@CeldaId"].Value = oDespProductos.CeldaId;
            cmdModificar.Parameters["@SucursalId"].Value = oDespProductos.SucursalId;

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
        public int EliminarDespProductos(int docId)
        {
            return EjecutarComando("DELETE FROM dbo.documentos WHERE docId=" + docId.ToString());
        }
        
        public int MarcarEliminado(int docId, int Valor)
        {
            return EjecutarComando("UPDATE dbo.documentos set eliminado = " + Valor + " WHERE docId=" + docId.ToString());
        }
        public bool BuscarDespProductos(string CodPaquete,string CodDespacho)
        {
            string cadena = "select * from tblDespProductos where despachoId='" + CodDespacho + "' and productoId='"+ CodPaquete +"'";
            DataSet ds = EjecutarConsulta(cadena);
            DataTable dt=ds.Tables[0];
            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
            
        }

        public DataSet BuscarDespALecturar(string _idDespacho)
        {
            string cadena = "SELECT a.ItemId, a.ItemFId, b.Descripcion, a.ProductoId, a.Piezas, a.Peso, a.Cantidad FROM tblDespProductos a INNER JOIN tblItem b ON a.ItemId = b.ItemId where DespachoId = '" + _idDespacho + "'";
            return this.EjecutarConsulta(cadena);
        }
        public DataSet BuscarDespALecturarCompleto(string _idDespacho)
        {
            string cadena = "SELECT a.ItemId, a.ItemFId, b.Descripcion, a.ProductoId, a.Piezas, a.Peso, a.Cantidad, a.CeldaId, a.SucursalId, a.ItemFId, a.Piezas, a.Metros, a.Colada FROM tblDespProductos a INNER JOIN tblItem b ON a.ItemId = b.ItemId where DespachoId = '" + _idDespacho + "'";
            return this.EjecutarConsulta(cadena);
        }
        public DataSet DetMovDatos(string _idDespacho, string _itemId)
        {
            string cadena = "select b.ItemFId, a.Piezas, a.Peso, a.Cantidad, b.UnidadF from tblDespProductos a INNER JOIN tblItem b ON a.ItemId = b.ItemId where a.DespachoId = '" + _idDespacho + "' AND a.ItemId = '" + _itemId + "'";
            return this.EjecutarConsulta(cadena);
        }
        public DataSet DetMovDatosAjuste(string _itemId)
        {
            string cadena = "select ItemFId, UnidadF from tblItem WHERE ItemId = '" + _itemId + "'";
            return this.EjecutarConsulta(cadena);
        }
        public DataSet TraerSumaProgramados(string _idDespacho)
        {
            string cadena = "select SUM(Cantidad) as totalProg from tblDespProductos where DespachoId = '" + _idDespacho + "'";
            return this.EjecutarConsulta(cadena);
        }
        public DataSet TraerSumaEnviados(string _idDespacho)
        {
            string cadena = "select SUM(Cantidad) as totalEntrega from tblOrdenEntregaDetalle where DespachoId = '" + _idDespacho + "'";
            return this.EjecutarConsulta(cadena);
        }
        public int QuitarPaqueteLecturacion(string _idDespacho, string _PaqueteId)
        {
            return EjecutarComando("DELETE FROM tblDespProductos WHERE DespachoId = '" + _idDespacho + "' AND ProductoId = '" + _PaqueteId + "'");
        }
    }
}
