using CRN.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace CAD
{
    public class CADNoConformeAccion:DBDAC
    {
        public CADNoConformeAccion()
            : base("SQLSERVER", "dbo.tblaccion")
		{

			DbParameter par=this.CrearParametro();
			par.ParameterName ="@iaccion_id";
			par.DbType =DbType.Int32;
			par.Direction =ParameterDirection.Output;
            Adapter.InsertCommand.CommandText += ";SELECT @iaccion_id=SCOPE_IDENTITY();";
			Adapter.InsertCommand.Parameters.Add(par);
		}

        public void GuardarNoConformeAccion(TAccion accion,int idconforme)
        {
            DbCommand cmdInsert = Adapter.InsertCommand;
            cmdInsert.Parameters["@saccion_desc"].Value =accion.SAccion_Desc;
            cmdInsert.Parameters["@iresponsable_id"].Value = accion.IResponsable_ID;
            cmdInsert.Parameters["@dtfecha_plazo"].Value = accion.DTfecha_plazo;
            cmdInsert.Parameters["@sestado"].Value = accion.EstadoId;
            cmdInsert.Parameters["@dtfecha_cierre"].Value =  accion.DTfecha_cierre==null||accion.DTfecha_cierre==""?DBNull.Value: (object)accion.DTfecha_cierre;
            cmdInsert.Parameters["@inoconformidad_id"].Value = idconforme;          
            EjecutarComando(cmdInsert);

        }

        public int EjecutaSentenciasAccion(string sen)
        {
            return EjecutarComando(sen);
        }


    }
}
