using CRN.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace CAD
{
    public class CADSector : DBDAC
    {
        public CADSector()
            : base("SQLSERVER", "dbo.tblsector")
        {
            DbParameter par = this.CrearParametro();
            par.ParameterName = "@id_sector";
            par.DbType = DbType.Int32;
            par.Direction = ParameterDirection.Output;
            Adapter.InsertCommand.CommandText += ";SELECT @id_sector=SCOPE_IDENTITY();";
            Adapter.InsertCommand.Parameters.Add(par);        
        }

        public DataSet EjecutarConsult(string param)
        {
            return this.EjecutarConsulta(param);
        }
        public int EjecutarSentencia(string sql) 
        {
           return  EjecutarComando(sql);
        
        }
        public void GuardarSector(Sector param)
        {
            DbCommand cmdInsert = Adapter.InsertCommand;
            cmdInsert.Parameters["@id_centro"].Value = param.Id_Centro;
            cmdInsert.Parameters["@id_parametro"].Value = param.Id_Parametro;
            cmdInsert.Parameters["@id_parametro1"].Value = param.Id_Parametro1;
            cmdInsert.Parameters["@id_parametro2"].Value = param.Id_Parametro2;        
            EjecutarComando(cmdInsert);
        }
    }
}
