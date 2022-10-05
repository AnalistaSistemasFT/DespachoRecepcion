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
    public class CADSesion : DBDAC
    {
       public CADSesion()
            : base("SQLSERVER", "dbo.tblMovimiento")
        {

            DbParameter par = this.CrearParametro();
            par.ParameterName = "@MovimientoId";
            par.DbType = DbType.Int32;
            par.Direction = ParameterDirection.Output;
            Adapter.InsertCommand.CommandText += ";SELECT @MovimientoId=SCOPE_IDENTITY();";
            Adapter.InsertCommand.Parameters.Add(par);
        }


       public DateTime TraerGestion()
        {
         string consulta = "Select sysdatetime() as Fecha";
            DataSet ds = this.EjecutarConsulta (consulta);
                
            DataTable dt = ds.Tables[0];
            DataRow rFecha = dt.Rows[0];
            DateTime fechaactual =Convert.ToDateTime(rFecha["Fecha"]);
            return fechaactual;
       }
    }
}
