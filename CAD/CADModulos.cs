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
    public class CADModulos:DBDAC
    {
        public CADModulos()
            : base("SQLSERVER", "dbo.tblModulos")
        {

            DbParameter par = this.CrearParametro();
            par.ParameterName = "@ModuloId";
            par.DbType = DbType.Int32;
            par.Direction = ParameterDirection.Output;
            Adapter.InsertCommand.CommandText += ";SELECT @ModuloId=SCOPE_IDENTITY();";
            Adapter.InsertCommand.Parameters.Add(par);
        }
    
        public DataSet TraerTodosModulos(string where)
        {
            return this.Consultar(where);
        }
       
      
         public DataSet CargarComboSucursal()
        {
            string cadena = "select SucursalID,Nombre from Empleados.dbo.Sucursal where Adscrita='true'";
            return EjecutarConsulta(cadena);
       
        }
    }
}
