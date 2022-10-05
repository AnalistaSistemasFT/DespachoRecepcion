using CRN.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace CAD
{
    public class CADEntregaMecanizado : DBDAC
    {
        public CADEntregaMecanizado() : base("SQLSERVER", "tblEntregaMecanizado")
        {
            DbParameter par = this.CrearParametro();
            par.ParameterName = "@p_Id_entrega";
            par.DbType = DbType.Int32;
            par.Direction = ParameterDirection.Output;
            Adapter.InsertCommand.CommandText += ";SELECT @p_Id_entrega=SCOPE_IDENTITY();";
            Adapter.InsertCommand.Parameters.Add(par);
        }
        public int GuardarEntrega(EntregaMecanizado _entregaMecanizado)
        {
            DbCommand cmdInsert = Adapter.InsertCommand;
            cmdInsert.Parameters["@p_Id_entrega"].Value = _entregaMecanizado.Id_entrega;
            cmdInsert.Parameters["@p_Id_servicio"].Value = _entregaMecanizado.Id_servicio;
            cmdInsert.Parameters["@p_Fecha_entrega"].Value = _entregaMecanizado.Fecha_entrega;
            cmdInsert.Parameters["@p_Cantidad"].Value = _entregaMecanizado.Cantidad;
            return EjecutarComando(cmdInsert);
        }
    }
}
