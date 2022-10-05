using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using CRN.Entidades;


namespace CAD
{
    public class CADEnsayo:DBDAC
    {
        public CADEnsayo()
            : base("SQLSERVER1", "dbo.tblTipoEnsayo")
        {
            DbParameter par = this.CrearParametro();
            par.ParameterName = "@TipoId";
            par.DbType = DbType.Int32;
            par.Direction = ParameterDirection.Output;
            Adapter.InsertCommand.CommandText += ";SELECT @TipoId=SCOPE_IDENTITY();";
            Adapter.InsertCommand.Parameters.Add(par);        
        }
        public DataSet RetornarEnsayos(int iEstado, string scentroid)
        {
            string consulta = String.Format("SELECT * FROM dbo.tblOrdenProduccion where Estado={0} and CentroId = '{1}' ", iEstado,scentroid);
            return this.EjecutarConsulta(consulta);
        }
        public DataSet RetornarEnsayos(string consulta)
        {
            //string consulta = String.Format("SELECT * FROM dbo.tblOrdenProduccion where Estado={0} and CentroId = '{1}' ", iEstado, scentroid);
            return this.EjecutarConsulta(consulta);
        }
        public void GuardarEnsayo(Ensayo ensayo) 
        {
            DbCommand cmdInsert = Adapter.InsertCommand;
            cmdInsert.Parameters["@Descripcion"].Value = ensayo.DescripcioN;
            cmdInsert.Parameters["@Frecuencia"].Value = ensayo.Frecuencia;
            cmdInsert.Parameters["@UnidadFrecuencia"].Value = ensayo.UnidadFrecenciA;
            cmdInsert.Parameters["@Grupo"].Value = ensayo.GrupO;
            cmdInsert.Parameters["@TomasXFrecuencia"].Value = ensayo.TomasXFrrecuenciA;
            cmdInsert.Parameters["@Operacion"].Value = ensayo.OperacioneS;            
            EjecutarComando(cmdInsert);        
        }
        public void ModificarEnsayo(Ensayo ensayo)
        {
            DbCommand cmdModificar = Adapter.UpdateCommand;
            cmdModificar.Parameters["@Original_TipoId"].Value = ensayo.TipoId;
            cmdModificar.Parameters["@Descripcion"].Value = ensayo.DescripcioN;
            cmdModificar.Parameters["@Frecuencia"].Value = ensayo.Frecuencia;
            cmdModificar.Parameters["@UnidadFrecuencia"].Value = ensayo.UnidadFrecenciA;
            cmdModificar.Parameters["@Grupo"].Value = ensayo.GrupO;
            cmdModificar.Parameters["@TomasXFrecuencia"].Value = ensayo.TomasXFrrecuenciA;
            cmdModificar.Parameters["@Operacion"].Value = ensayo.OperacioneS;
            EjecutarComando(cmdModificar);
        }
        public DataSet CargarSubEnsayos(int fila) 
        {
            string consulta = String.Format("SELECT tblTipoEnsayoParam.ParametroId,tblTipoEnsayoParam.tipoid, tblTipoEnsayoParam.Nombre,tblTipoEnsayoParam.EsFormula,tblTipoEnsayoParam.unidad," +
                                       "tblTipoEnsayoParam.HabilitaLimiteMin,tblTipoEnsayoParam.LimiteMinAprob,tblTipoEnsayoParam.HabilitaLimiteMax," +
                                       "tblTipoEnsayoParam.LimiteMaxAprob,tblTipoEnsayoParam.Formula,tblTipoEnsayoParam.Procedimiento, tblTipoEnsayoParam.habilitalimitetabla, " +
                                        "tblTipoEnsayoParam.tablaid,tblcattabla.descripcion,tblTipoEnsayoParam.tipodato,tblTipoEnsayoParam.obligatorio,tblTipoEnsayoParam.campotabla, " +
                                       "tblTipoEnsayoParam.posicion FROM tblTipoEnsayoParam left join tblcattabla on tblTipoEnsayoParam.tablaid=tblcattabla.tablaid where tipoid={0}", fila);
            return this.EjecutarConsulta(consulta);        
        }
        public DataSet retornoSubEnsayoFiltrado(int tipo) 
        {
            string consulta = String.Format("SELECT tblTipoEnsayoParam.ParametroId,tblTipoEnsayoParam.tipoid, tblTipoEnsayoParam.Nombre,tblTipoEnsayoParam.EsFormula," +
                                    " tblTipoEnsayoParam.unidad,tblTipoEnsayoParam.HabilitaLimiteMin,tblTipoEnsayoParam.LimiteMinAprob, " +
                                     " tblTipoEnsayoParam.HabilitaLimiteMax,tblTipoEnsayoParam.LimiteMaxAprob,tblTipoEnsayoParam.Formula, " +
                                    " tblTipoEnsayoParam.Procedimiento, tblTipoEnsayoParam.habilitalimitetabla,tblTipoEnsayoParam.tablaid, " +
                                    " tblcattabla.descripcion,tblTipoEnsayoParam.tipodato,tblTipoEnsayoParam.obligatorio,tblTipoEnsayoParam.campotabla, " +
                                    " tblTipoEnsayoParam.posicion FROM tblTipoEnsayoParam left join " +
                                    " tblcattabla on tblTipoEnsayoParam.tablaid=tblcattabla.tablaid where tipoid={0} order by posicion ", tipo);
            return this.EjecutarConsulta(consulta);
        }     
        public DataSet dataCombos(int id) 
        {
            string consulta = String.Format("select distinct LPR_EX_GROUP_CODE as grupo,LPF_FEATURE as Campo from ([ElsystemNet_Ferrotodo].dbo.MES_TB_LST_PRODUCT left join " +
                        " [ElsystemNet_Ferrotodo].dbo.MES_TB_LST_PRODUCT_FEATURE on LPR_PRODUCT_CODE=LPF_PRODUCT_CODE) inner join " +
                        " [ElsystemNet_Ferrotodo].dbo.MES_TB_LST_PRODUCT_GROUPS on CGR_GROUP_CODE=LPR_EX_GROUP_CODE inner join " +
                       " tblCatTabla on TipoProducto=LPR_EX_GROUP_CODE Where tablaId ={0} order by lpf_feature  ", id);
            return this.EjecutarConsulta(consulta);
        }
        public DataSet cargarComboActualizar(int iii) 
        {
            string consulta = String.Format(" SELECT [ParametroId],[TipoId],[Nombre],[EsFormula],[Unidad],[HabilitaLimiteMin],[LimiteMinAprob],[HabilitaLimiteMax],[LimiteMaxAprob]"
                            + " ,[Formula],[Procedimiento],[HabilitaLimiteTabla],[TablaId],[tipodato],[Obligatorio],[CampoTabla],[Posicion] FROM [dbo].[tblTipoEnsayoParam] where ParametroId={0}", iii);
            return this.EjecutarConsulta(consulta);
        }

        public DataSet retornoEnsayosFiltrado() 
        {
            string consulta = "SELECT tblTipoEnsayo.TipoId,tblTipoEnsayo.Descripcion,tblTipoEnsayo.Frecuencia,tblCatPeriodTarea.DESCRIPCION AS Periodo " +
                  " FROM tblTipoEnsayo left JOIN tblCatPeriodTarea ON TBLTIPOENSAYO.UnidadFrecuencia=tblCatPeriodTarea.PERIODOID " +
                  " order by tipoid";
            return this.EjecutarConsulta(consulta);
        
        }
        public DataSet RetornarEnsayos1()
        {
            string consulta = "select * from tblCatUnidad where not tipo IS NULL order by unidad asc";
            return this.EjecutarConsulta(consulta);
        }
        public DataSet RetornarEnsayos2()
        {
            string consulta = "select TablaId,Descripcion,CGR_CODE_DESC,unidad from tblcattabla inner join [ElsystemNet_Ferrotodo].[dbo].[MES_TB_LST_PRODUCT_GROUPS] on tblCatTabla.TipoProducto =CGR_GROUP_CODE ";
            return this.EjecutarConsulta(consulta);
        }

        public DataSet retornarDetalles(int id)
        {
            string consulta = String.Format("select  tblTipoEnsayoParam.Nombre,tblEnsayoDetalle.* from tblEnsayoDetalle inner join " +
                                           " tblEnsayo on tblEnsayoDetalle.Id_Ensayo=tblEnsayo.Id_Ensayo inner join " +
                                           " tblTipoEnsayoParam on tblEnsayoDetalle.ParametroId=tblTipoEnsayoParam.ParametroId " +
                                           " where tblEnsayoDetalle.Id_Ensayo={0}", id);
            return this.EjecutarConsulta(consulta);

        }

    }
}