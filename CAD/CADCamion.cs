using CRN.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace CAD
{
    public class CADCamion : DBDAC
    {
        public CADCamion() : base("SQLSERVER", "dbo.tblCatCamion")
        {
            DbParameter par = this.CrearParametro();
            par.ParameterName = "@Id_Camion";
            par.DbType = DbType.Int32;
            par.Direction = ParameterDirection.Output;
            Adapter.InsertCommand.CommandText += ";SELECT @Id_Camion=SCOPE_IDENTITY();";
            Adapter.InsertCommand.Parameters.Add(par);
        }
        public int GuardarCamion(CatCamion _catCamion)
        {
            DbCommand cmdInsert = Adapter.InsertCommand;
            cmdInsert.Parameters["@Marca"].Value = _catCamion._Marca;
            cmdInsert.Parameters["@Placa"].Value = _catCamion._Placa;
            cmdInsert.Parameters["@Capacidad"].Value = _catCamion._Capacidad;
            return EjecutarComando(cmdInsert);
        }
    }
}
