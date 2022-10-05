using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Configuration;
using System.Data.Common;
using CRN.Entidades;


namespace CAD
{
     public class CADObservacion:DBDAC
    {
         public CADObservacion():base("SQLSERVER", "dbo.TblObservacion")
		{

			DbParameter par=this.CrearParametro();
            par.ParameterName = "@IdObservacion";
			par.DbType =DbType.Int32;
			par.Direction =ParameterDirection.Output;
            Adapter.InsertCommand.CommandText += ";SELECT @IdObservacion=SCOPE_IDENTITY();";
			Adapter.InsertCommand.Parameters.Add(par);
		}

         public void GuardarObservacion(Observacion oObs)
		{
			DbCommand cmdInsert = Adapter.InsertCommand;
        	cmdInsert.Parameters["@Descripcion"].Value=oObs.Descripcion;
			
			EjecutarComando(cmdInsert);
            oObs.IdObservacion = Convert.ToInt32(cmdInsert.Parameters["@IdObservacion"].Value);
		}


         public void ModificaroObservacion(Observacion oObs)
		{
			DbCommand cmdModificar = Adapter.UpdateCommand;

            cmdModificar.Parameters["@Descripcion"].Value = oObs.Descripcion;
            cmdModificar.Parameters["@Original_IdObservacion"].Value = oObs.IdObservacion;
			EjecutarComando(cmdModificar);
		}


         public void EliminarObservacion(string vIdObs)
		{
			DbCommand cmdDelete = Adapter.DeleteCommand;
            cmdDelete.Parameters["@Original_IdObservacion"].Value = vIdObs;
			EjecutarComando(cmdDelete);
		}

         public Observacion TraerObservacion(int Obs)
         {
             DataSet ds = this.Consultar("IdObservacion=" + Obs);
             DataTable tObs = ds.Tables[0];
             if (tObs.Rows.Count == 0)
             {
                 return null;
             }
             DataRow rObs = tObs.Rows[0];
             Observacion oObs = new Observacion();
             oObs.IdObservacion = Obs;

             oObs.Descripcion = rObs["Descripcion"].ToString();
             return oObs;
         }
         public DataSet TraerTodosObservacion()
		{
			return this.Consultar("");
		}
    }
}
