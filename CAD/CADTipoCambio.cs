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
	public class CADTipoCambio:DBDAC
	{
		public CADTipoCambio():base("SQLSERVER","dbo.Tbltipocambio")
		{

			DbParameter par=this.CrearParametro();
			par.ParameterName ="@Fecha";
			par.DbType =DbType.Int32;
			par.Direction =ParameterDirection.Output;
			Adapter.InsertCommand.CommandText +=";SELECT @Fecha=SCOPE_IDENTITY();";
			Adapter.InsertCommand.Parameters.Add(par);
		}

		public void GuardarTipoCambio(TipoCambio oTipoCambio)
		{
			DbCommand cmdInsert = Adapter.InsertCommand;
			cmdInsert.Parameters["@Fecha"].Value=oTipoCambio.Fecha;
			cmdInsert.Parameters["@TC"].Value=oTipoCambio.TC;
			EjecutarComando(cmdInsert);
			oTipoCambio.Fecha=Convert.ToDateTime(cmdInsert.Parameters["@Fecha"].Value);
		}


		public void ModificarTipoCambio(TipoCambio oTipoCambio)
		{
			DbCommand cmdModificar = Adapter.UpdateCommand;
			cmdModificar.Parameters["@Fecha"].Value=oTipoCambio.Fecha;
			cmdModificar.Parameters["@TC"].Value=oTipoCambio.TC;
			EjecutarComando(cmdModificar);
		}


		public void EliminarTipoCambio(DateTime vFecha)
		{
			DbCommand cmdDelete = Adapter.DeleteCommand;
			cmdDelete.Parameters["@Original_Fecha"].Value= vFecha;
			EjecutarComando(cmdDelete);
		}


		public DataSet TraerTodosTipoCambio()
		{
			return this.Consultar("");
		}


		public TipoCambio  TraerTipoCambio(DateTime vFecha)
		{
			DataSet ds = this.Consultar("Fecha=" + vFecha);
			DataTable tTipoCambio = ds.Tables[0];
			if (tTipoCambio.Rows.Count == 0)
			{
				return null;
			}
			DataRow rTipoCambio = tTipoCambio.Rows[0];
			TipoCambio oTipoCambio = new TipoCambio();
			oTipoCambio.Fecha = Convert.ToDateTime(rTipoCambio["Fecha"]);
			oTipoCambio.TC = Convert.ToDouble(rTipoCambio["TC"]);
			return oTipoCambio;
		}


	}
}
