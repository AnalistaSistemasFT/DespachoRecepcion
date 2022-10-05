using CRN.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace CAD
{
    public class CADOrdenProduccionV2 : DBDAC
    {
        public CADOrdenProduccionV2()
            : base("SQLSERVER", "dbo.tblOrdenProduccion")
        {
            DbParameter par = this.CrearParametro();
            par.ParameterName = "@iCorrelativo";
            par.DbType = DbType.Int32;
            par.Direction = ParameterDirection.Output;
            Adapter.InsertCommand.CommandText += ";SELECT @iCorrelativo=SCOPE_IDENTITY();";
            Adapter.InsertCommand.Parameters.Add(par);      
        }
        public DataSet RetornarOrdenP(string consulta)
        {
            return this.EjecutarConsulta(consulta);
        }
        public void GuardarOrdenProduccionV2(OrdenProduccionV2 opp)
        {
            DbCommand cmdInsert = Adapter.InsertCommand;
            cmdInsert.Parameters["@sOrdenId"].Value = opp.orden;
            cmdInsert.Parameters["@sGrupoProd"].Value = opp.grupoProd;
            cmdInsert.Parameters["@sitemid"].Value = opp.sistemId;
            cmdInsert.Parameters["@dCantidad"].Value = Convert.ToDouble(opp.cantidad);
            cmdInsert.Parameters["@sUM"].Value = opp.sUm;
            cmdInsert.Parameters["@dtFechaReg"].Value = opp.fechaReg;
            cmdInsert.Parameters["@dtFechaEnt"].Value = opp.fechaentr;
            cmdInsert.Parameters["@sTipo"].Value = opp.tipo;
            cmdInsert.Parameters["@iFabrica"].Value = opp.fabrica;
            cmdInsert.Parameters["@sCentroTrabajo"].Value = opp.centrotrabajo;
            cmdInsert.Parameters["@sDescripcion"].Value = opp.descripcion;
            cmdInsert.Parameters["@status"].Value = opp.status;
           
            EjecutarComando(cmdInsert);
        }

        public int EjecutarSentencias(string consulta)
        {
            return EjecutarComando(consulta);
        }
    }
}
