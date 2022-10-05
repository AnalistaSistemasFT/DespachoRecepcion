using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using CRN.Entidades;

namespace CAD
{
	public class CADEntrega:DBDAC
	{
		public CADEntrega():base("SQLSERVER","dbo.Tblentrega")
		{
			DbParameter par=this.CrearParametro();
			par.ParameterName ="@ID_Entrega";
			par.DbType =DbType.Int32;
			par.Direction =ParameterDirection.Output;
			Adapter.InsertCommand.CommandText +=";SELECT @ID_Entrega=SCOPE_IDENTITY();";
			Adapter.InsertCommand.Parameters.Add(par);
		}

		public void GuardarEntrega(Entrega oEntrega)
		{
			DbCommand cmdInsert = Adapter.InsertCommand;
			cmdInsert.Parameters["@ID_Entrega"].Value=oEntrega.ID_Entrega;
			cmdInsert.Parameters["@FechaCreacion"].Value=oEntrega.FechaCreacion;
			cmdInsert.Parameters["@Ejecutor"].Value=oEntrega.Ejecutor;
			cmdInsert.Parameters["@Id_DptoOrigen"].Value=oEntrega.Id_DptoOrigen;
			cmdInsert.Parameters["@Id_DptoDestino"].Value=oEntrega.Id_DptoDestino;
			cmdInsert.Parameters["@TipoEntrega"].Value=oEntrega.TipoEntrega;
			cmdInsert.Parameters["@Referencia"].Value=oEntrega.Referencia;
			cmdInsert.Parameters["@Obs"].Value=oEntrega.Obs;
			cmdInsert.Parameters["@Status"].Value=oEntrega.Status;
			cmdInsert.Parameters["@CentroTrabajo"].Value=oEntrega.CentroTrabajo;
			cmdInsert.Parameters["@ItemId"].Value=oEntrega.ItemId;
			cmdInsert.Parameters["@Cantidad"].Value=oEntrega.Cantidad;
			cmdInsert.Parameters["@Unidad"].Value=oEntrega.Unidad;
			cmdInsert.Parameters["@SucursalId"].Value=oEntrega.SucursalId;
			cmdInsert.Parameters["@Correlativo"].Value=oEntrega.Correlativo;
			cmdInsert.Parameters["@FechaEjecucion"].Value=oEntrega.FechaEjecucion;
			cmdInsert.Parameters["@FechaFinEjecucion"].Value=oEntrega.FechaFinEjecucion;
			cmdInsert.Parameters["@FechaCierre"].Value=oEntrega.FechaCierre;
			cmdInsert.Parameters["@Duracion"].Value=oEntrega.Duracion;
			EjecutarComando(cmdInsert);
            //oEntrega.ID_Entrega=Convert.ToInt32(cmdInsert.Parameters["@ID_Entrega"].Value);
		}
		public void ModificarEntrega(Entrega oEntrega)
		{
			DbCommand cmdModificar = Adapter.UpdateCommand;
			cmdModificar.Parameters["@ID_Entrega"].Value=oEntrega.ID_Entrega;
			cmdModificar.Parameters["@FechaCreacion"].Value=oEntrega.FechaCreacion;
			cmdModificar.Parameters["@Ejecutor"].Value=oEntrega.Ejecutor;
			cmdModificar.Parameters["@Id_DptoOrigen"].Value=oEntrega.Id_DptoOrigen;
			cmdModificar.Parameters["@Id_DptoDestino"].Value=oEntrega.Id_DptoDestino;
			cmdModificar.Parameters["@TipoEntrega"].Value=oEntrega.TipoEntrega;
			cmdModificar.Parameters["@Referencia"].Value=oEntrega.Referencia;
			cmdModificar.Parameters["@Obs"].Value=oEntrega.Obs;
			cmdModificar.Parameters["@Status"].Value=oEntrega.Status;
			cmdModificar.Parameters["@CentroTrabajo"].Value=oEntrega.CentroTrabajo;
			cmdModificar.Parameters["@ItemId"].Value=oEntrega.ItemId;
			cmdModificar.Parameters["@Cantidad"].Value=oEntrega.Cantidad;
			cmdModificar.Parameters["@Unidad"].Value=oEntrega.Unidad;
			cmdModificar.Parameters["@SucursalId"].Value=oEntrega.SucursalId;
			cmdModificar.Parameters["@Correlativo"].Value=oEntrega.Correlativo;
			cmdModificar.Parameters["@FechaEjecucion"].Value=oEntrega.FechaEjecucion;
			cmdModificar.Parameters["@FechaFinEjecucion"].Value=oEntrega.FechaFinEjecucion;
			cmdModificar.Parameters["@FechaCierre"].Value=oEntrega.FechaCierre;
			cmdModificar.Parameters["@Duracion"].Value=oEntrega.Duracion;
			EjecutarComando(cmdModificar);
		}        
		public void EliminarEntrega(string vID_Entrega)
		{
			DbCommand cmdDelete = Adapter.DeleteCommand;
			cmdDelete.Parameters["@Original_ID_Entrega"].Value= vID_Entrega;
			EjecutarComando(cmdDelete);
		}
		public DataSet TraerTodosEntrega()
		{
			return this.Consultar("");
		}
        public DataSet TraerOrdenesUsuario(int Id,string estado)
        {
            string cad = "SELECT e.Id_Entrega,e.Referencia,e.status " +
                        "FROM tblEntrega e " +
                        "where e.status='"+ estado +"' and e.ejecutor=" + Id + "";
            return this.EjecutarConsulta(cad);
        }
        public void CambiarEstadoOrdenesUsuario(string id,string estado)
        {
            string cad = "update tblEntrega set status='" + estado + "' where id_Entrega='"+id+"'";
            EjecutarComando(cad);
        }
        public int ContarEstado(string id,string sWHERE)
        {
            string cadena = "select COUNT(*) as Total FROM tblEntregaDet WHERE Id_Entrega='"+ id +"' ";
            if (!string.IsNullOrEmpty(sWHERE))
                cadena+=" AND "+sWHERE;
            //            where Id_Entrega='"+ id +"' and Status<>'"+ estado +"'";            
            DataSet ds = EjecutarConsulta(cadena);
            DataTable dt = ds.Tables[0];
            DataRow dr = dt.Rows[0];
            int valor = Convert.ToInt32(dr["Total"].ToString());
            return valor;
        }
	}
}
