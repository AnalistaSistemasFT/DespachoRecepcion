using CRN.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace CAD
{
    public class CADParametros : DBDAC
    {
        public CADParametros()
            : base("SQLSERVER2", "dbo.Cat_Parametro")
        {
            DbParameter par = this.CrearParametro();
            par.ParameterName = "@id_parametro";
            par.DbType = DbType.Int32;
            par.Direction = ParameterDirection.Output;
            Adapter.InsertCommand.CommandText += ";SELECT @id_parametro=SCOPE_IDENTITY();";
            Adapter.InsertCommand.Parameters.Add(par);        
        }

        public DataSet EjecutarConsult(string param)
        {
            return this.EjecutarConsulta(param);
        }

        public void GuardarParametros(CadParametros param)
        {
            DbCommand cmdInsert = Adapter.InsertCommand;
            cmdInsert.Parameters["@parametro_desc"].Value = param.ParamDescrip;
            cmdInsert.Parameters["@tipo_parametro"].Value = param.TipoParam;           
            EjecutarComando(cmdInsert);
        }

    }
}
