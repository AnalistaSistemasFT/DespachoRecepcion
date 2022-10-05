using CRN.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace CAD
{
    public class CADConforme: DBDAC
    {

        public CADConforme()
            : base("SQLSERVER", "dbo.tblnoconformidad")
		{

			DbParameter par=this.CrearParametro();
			par.ParameterName ="@inoconformidad_id";
			par.DbType =DbType.Int32;
			par.Direction =ParameterDirection.Output;
            Adapter.InsertCommand.CommandText += ";SELECT @inoconformidad_id=SCOPE_IDENTITY();";
			Adapter.InsertCommand.Parameters.Add(par);
		}
        public DataSet EjecutarXPrivado(string sentencia)
        {
                        
            return this.EjecutarConsulta(sentencia);
        }
        public void GuardarNoConforme(NoConformidad oConsumido)
        {
            DbCommand cmdInsert = Adapter.InsertCommand;
            cmdInsert.Parameters["@dtfecha_reg"].Value=oConsumido.DtFecha_reg;
            cmdInsert.Parameters["@dtfecha_ide"].Value=oConsumido.Dtfecha_ide;
            cmdInsert.Parameters["@dtfecha_cierre"].Value=oConsumido.Dtfecha_cierre;
            cmdInsert.Parameters["@iareaproceso"].Value=oConsumido.IAreaProceso;
            cmdInsert.Parameters["@itipo_id"].Value=oConsumido.Itipo_Id;
            cmdInsert.Parameters["@sdescripcion"].Value=oConsumido.Descripcion;

            cmdInsert.Parameters["@itipoincidente_id"].Value = oConsumido.ITipoIncidente_id;
            cmdInsert.Parameters["@sconsecuencias"].Value = oConsumido.PsConsecuencias;
            cmdInsert.Parameters["@sdoc_relacionado"].Value = oConsumido.SDoc_relacionado;
            cmdInsert.Parameters["@ssolicion_inmediata"].Value = oConsumido.SSolucion_Inmediata;
            cmdInsert.Parameters["@iemitido_por"].Value = oConsumido.IEmitido_por;

            cmdInsert.Parameters["@irecibido_por"].Value = oConsumido.IRecibido_por;
            cmdInsert.Parameters["@sanalisis_causaraiz"].Value = oConsumido.SAnalisis_Causaraiz;
            cmdInsert.Parameters["@iencargado_seg"].Value = oConsumido.IEncargado_seg;
            cmdInsert.Parameters["@iestado"].Value = oConsumido.IEstado;
            cmdInsert.Parameters["@iresultado_id"].Value = oConsumido.IResultado_id;

            cmdInsert.Parameters["@sresultado"].Value = oConsumido.SResultado;
            cmdInsert.Parameters["@sverificacion_eficacia"].Value = oConsumido.SVerificacion_eficacia;
            cmdInsert.Parameters["@iencargado_cierre"].Value = oConsumido.IEncargado_cierre;
            cmdInsert.Parameters["@isucursal_id"].Value = oConsumido.ISucursal;
            
            EjecutarComando(cmdInsert);           
        }

        public int EditarNoConforme(NoConformidad oConsumido)
        {
            DbCommand cmdInsert = Adapter.UpdateCommand;
            cmdInsert.Parameters["@dtfecha_reg"].Value = oConsumido.DtFecha_reg;
            cmdInsert.Parameters["@dtfecha_ide"].Value = oConsumido.Dtfecha_ide;
            cmdInsert.Parameters["@dtfecha_cierre"].Value = oConsumido.Dtfecha_cierre;
            cmdInsert.Parameters["@iareaproceso"].Value = oConsumido.IAreaProceso;
            cmdInsert.Parameters["@itipo_id"].Value = oConsumido.Itipo_Id;
            cmdInsert.Parameters["@sdescripcion"].Value = oConsumido.Descripcion;
            cmdInsert.Parameters["@itipoincidente_id"].Value = oConsumido.ITipoIncidente_id;
            cmdInsert.Parameters["@sconsecuencias"].Value = oConsumido.PsConsecuencias;
            cmdInsert.Parameters["@sdoc_relacionado"].Value = oConsumido.SDoc_relacionado;
            cmdInsert.Parameters["@ssolicion_inmediata"].Value = oConsumido.SSolucion_Inmediata;
            cmdInsert.Parameters["@iemitido_por"].Value = oConsumido.IEmitido_por;
            cmdInsert.Parameters["@irecibido_por"].Value = oConsumido.IRecibido_por;
            cmdInsert.Parameters["@sanalisis_causaraiz"].Value = oConsumido.SAnalisis_Causaraiz;
            cmdInsert.Parameters["@iencargado_seg"].Value = oConsumido.IEncargado_seg;
            cmdInsert.Parameters["@iestado"].Value = oConsumido.IEstado;
            cmdInsert.Parameters["@iresultado_id"].Value = oConsumido.IResultado_id;
            cmdInsert.Parameters["@sresultado"].Value = oConsumido.SResultado;
            cmdInsert.Parameters["@sverificacion_eficacia"].Value = oConsumido.SVerificacion_eficacia;
            cmdInsert.Parameters["@iencargado_cierre"].Value = oConsumido.IEncargado_cierre;
            cmdInsert.Parameters["@isucursal_id"].Value = oConsumido.ISucursal;
            cmdInsert.Parameters["@Original_inoconformidad_id"].Value = oConsumido.Id_Noconforme;
            return EjecutarComando(cmdInsert);
        }
        public int EjecutaSentenciasInforme(string sen)
        {
            return EjecutarComando(sen);
        }
    }
}
