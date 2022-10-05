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
    public class CADTipoCosteo:DBDAC
    {
        public CADTipoCosteo()
            : base("SQLSERVER", "dbo.Sys_TipoCosteo")
        {

            DbParameter par = this.CrearParametro();
            par.ParameterName = "@Id_Tipo";
            par.DbType = DbType.Int32;
            par.Direction = ParameterDirection.Output;
            Adapter.InsertCommand.CommandText += ";SELECT @Id_Tipo=SCOPE_IDENTITY();";
            Adapter.InsertCommand.Parameters.Add(par);
        }
        public void GuardarTipoCosteo(TipoCosteo oTipoCosteo)
        {
            DbCommand cmdInsert = Adapter.InsertCommand;
            cmdInsert.Parameters["@Id_Tipo"].Value = oTipoCosteo.IdTipo;
            cmdInsert.Parameters["@Descripcion"].Value = oTipoCosteo.Descripcion;
            EjecutarComando(cmdInsert);
        }

        public DataSet TraerTodoTipoCosteo()
        {
            return this.Consultar("");
        }
        public DataSet TraerTodoTipoCosteo(string where)
        {
            return this.Consultar(where);
        }
        public int ModificarTipoCosteo(TipoCosteo oTipoCosteo)
        {
            DbCommand cmdModificar = Adapter.UpdateCommand;
            cmdModificar.Parameters["@Id_Tipo"].Value = oTipoCosteo.IdTipo;
            cmdModificar.Parameters["@Descripcion"].Value = oTipoCosteo.Descripcion;
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
        public int EliminarTipoCosteo(int docId)
        {
            return EjecutarComando("DELETE FROM dbo.documentos WHERE docId=" + docId.ToString());
        }

        public int MarcarEliminado(int docId, int Valor)
        {
            return EjecutarComando("UPDATE dbo.documentos set eliminado = " + Valor + " WHERE docId=" + docId.ToString());
        }
        public DataSet BuscarTipoCosteo(string nombDocumento)
        {
            string cadena = "select docId,tituloDocumento,autor from documentos where tituloDocumento like '%" + nombDocumento + "%'";
            return EjecutarConsulta(cadena);
        }
    }
}
