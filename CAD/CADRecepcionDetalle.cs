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
	public class CADRecepcionDetalle:DBDAC
	{
		public CADRecepcionDetalle():base("SQLSERVER","dbo.Tblrecepciondetalle")
		{

			DbParameter par=this.CrearParametro();
			par.ParameterName ="@RecepcionId";
			par.DbType =DbType.Int32;
			par.Direction =ParameterDirection.Output;
			Adapter.InsertCommand.CommandText +=";SELECT @RecepcionId=SCOPE_IDENTITY();";
			Adapter.InsertCommand.Parameters.Add(par);
		}

		public void GuardarRecepcionDetalle(RecepcionDetalle oRecepcionDetalle)
		{
			DbCommand cmdInsert = Adapter.InsertCommand;
			cmdInsert.Parameters["@RecepcionId"].Value=oRecepcionDetalle.RecepcionId;
			cmdInsert.Parameters["@ItemId"].Value=oRecepcionDetalle.ItemId;
			cmdInsert.Parameters["@Cantidad"].Value=oRecepcionDetalle.Cantidad;
			cmdInsert.Parameters["@Unidad"].Value=oRecepcionDetalle.Unidad;
			cmdInsert.Parameters["@Status"].Value=oRecepcionDetalle.Status;
			cmdInsert.Parameters["@SucursalId"].Value=oRecepcionDetalle.SucursalId;
			EjecutarComando(cmdInsert);
		
		}


		public void ModificarRecepcionDetalle(RecepcionDetalle oRecepcionDetalle)
		{
			DbCommand cmdModificar = Adapter.UpdateCommand;
			cmdModificar.Parameters["@RecepcionId"].Value=oRecepcionDetalle.RecepcionId;
			cmdModificar.Parameters["@ItemId"].Value=oRecepcionDetalle.ItemId;
			cmdModificar.Parameters["@Cantidad"].Value=oRecepcionDetalle.Cantidad;
			cmdModificar.Parameters["@Unidad"].Value=oRecepcionDetalle.Unidad;
			cmdModificar.Parameters["@Status"].Value=oRecepcionDetalle.Status;
			cmdModificar.Parameters["@SucursalId"].Value=oRecepcionDetalle.SucursalId;
			EjecutarComando(cmdModificar);
		}


		public void EliminarRecepcionDetalle(string vRecepcionId)
		{
			DbCommand cmdDelete = Adapter.DeleteCommand;
			cmdDelete.Parameters["@Original_RecepcionId"].Value= vRecepcionId;
			EjecutarComando(cmdDelete);
		}


		public DataSet TraerTodosRecepcionDetalle()
		{
			return this.Consultar("");
		}


		public RecepcionDetalle  TraerRecepcionDetalle(string vRecepcionId)
		{
			DataSet ds = this.Consultar("RecepcionId=" + vRecepcionId);
			DataTable tRecepcionDetalle = ds.Tables[0];
			if (tRecepcionDetalle.Rows.Count == 0)
			{
				return null;
			}
			DataRow rRecepcionDetalle = tRecepcionDetalle.Rows[0];
			RecepcionDetalle oRecepcionDetalle = new RecepcionDetalle();
			oRecepcionDetalle.RecepcionId = Convert.ToString(rRecepcionDetalle["RecepcionId"]);
			oRecepcionDetalle.ItemId = Convert.ToString(rRecepcionDetalle["ItemId"]);
			oRecepcionDetalle.Cantidad = Convert.ToDecimal(rRecepcionDetalle["Cantidad"]);
			oRecepcionDetalle.Unidad = Convert.ToString(rRecepcionDetalle["Unidad"]);
			oRecepcionDetalle.Status = Convert.ToString(rRecepcionDetalle["Status"]);
			oRecepcionDetalle.SucursalId = Convert.ToInt32(rRecepcionDetalle["SucursalId"]);
			return oRecepcionDetalle;
		}


	}
}
