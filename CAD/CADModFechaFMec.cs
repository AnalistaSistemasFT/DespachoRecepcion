using CRN.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace CAD
{
    public class CADModFechaFMec : DBDAC
    {
        public CADModFechaFMec() : base("SQLSERVER", "dbo.tblModFechaFMec")
        {
            DbParameter par = this.CrearParametro();
            par.ParameterName = "@p_Id_modFechaFinal";
            par.DbType = DbType.Int32;
            par.Direction = ParameterDirection.Output;
            Adapter.InsertCommand.CommandText += ";SELECT @p_Id_modFechaFinal=SCOPE_IDENTITY();";
            Adapter.InsertCommand.Parameters.Add(par);
        }
        public void GuardarEntrega(ModFechaFMec _modFechaFMec)
        {
            DbCommand cmdInsert = Adapter.InsertCommand;
            cmdInsert.Parameters["@p_Id_modFechaFinal"].Value = _modFechaFMec.Id_modFechaFinal;
            cmdInsert.Parameters["@p_Fecha"].Value = _modFechaFMec.Fecha;
            cmdInsert.Parameters["@p_Id_servicio"].Value = _modFechaFMec.Id_servicio;
            cmdInsert.Parameters["@p_Id_empleado"].Value = _modFechaFMec.Id_empleado;
            cmdInsert.Parameters["@p_observacion"].Value = _modFechaFMec.observacion;
            EjecutarComando(cmdInsert);
        }
        public DataSet TraerFechasModificadas(int _IdServicio)
        {
            return EjecutarConsulta("SELECT p_Fecha FROM tblModFechaFMec WHERE p_Id_servicio = " + _IdServicio);
        }
    }
}
