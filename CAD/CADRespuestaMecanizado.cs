using CRN.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace CAD
{
    public class CADRespuestaMecanizado : DBDAC
    {
        public CADRespuestaMecanizado() : base("SQLSERVER", "tblRespuestaMecanizado")
        {
            DbParameter par = this.CrearParametro();
            par.ParameterName = "@p_Id_respuesta_mecanizado";
            par.DbType = DbType.Int32;
            par.Direction = ParameterDirection.Output;
            Adapter.InsertCommand.CommandText += ";SELECT @p_Id_respuesta_mecanizado=SCOPE_IDENTITY();";
            Adapter.InsertCommand.Parameters.Add(par);
        }
        public int GuardarRespuesta(RespuestaMecanizado _respuestaMecanizado)
        {
            DbCommand cmdInsert = Adapter.InsertCommand;
            cmdInsert.Parameters["@p_Id_respuesta_mecanizado"].Value = _respuestaMecanizado.Id_respuesta_mecanizado;
            cmdInsert.Parameters["@p_Id_servicio"].Value = _respuestaMecanizado.Id_servicio;
            cmdInsert.Parameters["@p_Estado"].Value = _respuestaMecanizado.Estado;
            cmdInsert.Parameters["@p_Observacion"].Value = _respuestaMecanizado.Observacion;
            return EjecutarComando(cmdInsert);
        }
        public int ModificarRespuesta(RespuestaMecanizado _respuestaMecanizado)
        {
            DbCommand cmdModificar = Adapter.UpdateCommand;
            cmdModificar.Parameters["@p_Id_respuesta_mecanizado"].Value = _respuestaMecanizado.Id_respuesta_mecanizado;
            cmdModificar.Parameters["@p_Id_servicio"].Value = _respuestaMecanizado.Id_servicio;
            cmdModificar.Parameters["@p_Estado"].Value = _respuestaMecanizado.Estado;
            cmdModificar.Parameters["@p_Observacion"].Value = _respuestaMecanizado.Observacion;
            return EjecutarComando(cmdModificar);
        }
        public DataSet TraerTodoRespuesta()
        {
            return this.Consultar("");
        }

        public DataSet TraerRespuesta(int id_respuesta)
        {
            return EjecutarConsulta("SELECT p_Id_servicio, p_Estado, p_Observacion FROM tblservicioresp WHERE p_Id_respuesta_mecanizado = " + id_respuesta);
        }
    }
}
