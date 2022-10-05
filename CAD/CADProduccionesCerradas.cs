using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace CAD
{
    public class CADProduccionesCerradas : DBDAC
    {
        public CADProduccionesCerradas()
            : base("SQLSERVER2", "dbo.tblMovSyncDet")
        {
           /* DbParameter par = this.CrearParametro();
            par.ParameterName = "@TipoId";
            par.DbType = DbType.Int32;
            par.Direction = ParameterDirection.Output;
            Adapter.InsertCommand.CommandText += ";SELECT @TipoId=SCOPE_IDENTITY();";
            Adapter.InsertCommand.Parameters.Add(par);        */
        }

        public DataSet RetornarDatos(string consulta)
        {
            return this.EjecutarConsulta(consulta);
        }

        public int EjecutarConsultaPlus(string consulta)
        {
            return EjecutarComando(consulta);
        }
    }
}
