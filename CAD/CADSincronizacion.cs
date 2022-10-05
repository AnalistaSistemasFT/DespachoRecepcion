using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace CAD
{
    public class CADSincronizacion:DBDAC
    {
        public CADSincronizacion():base("SQLSERVER4","dbo.MES_TB_LST_PRODUCT_GROUPS")
		{

			/*DbParameter par=this.CrearParametro();
			par.ParameterName ="@Id_Causa";
			par.DbType =DbType.Int32;
			par.Direction =ParameterDirection.Output;
			Adapter.InsertCommand.CommandText +=";SELECT @Id_Causa=SCOPE_IDENTITY();";
			Adapter.InsertCommand.Parameters.Add(par);*/
		}
        public DataSet Retornardatos(string consulta)
        {
            return this.EjecutarConsulta(consulta);
        }
		

	}
}
