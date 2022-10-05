using CRN.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CAD
{
    public  class CADTblEnsayo:DBDAC
    {
       
        public CADTblEnsayo()
            : base("SQLSERVER1", "dbo.tblEnsayo")
        {
            DbParameter par = this.CrearParametro();
            par.ParameterName = "@Id_Ensayo";
            par.DbType = DbType.Int32;
            par.Direction = ParameterDirection.Output;
            Adapter.InsertCommand.CommandText += ";SELECT @Id_Ensayo=SCOPE_IDENTITY();";
            Adapter.InsertCommand.Parameters.Add(par);        
        }
        
        public DataSet RetornarCattblEnsayo (string consulta)
        {
            return this.EjecutarConsulta(consulta);
        }
        public void GuardarTblEnsayo(TblEnsayo ensayo)
        {
            DbCommand cmdInsert = Adapter.InsertCommand;
            cmdInsert.Parameters["@EnsayoId"].Value = ensayo.EnsayOID;
            cmdInsert.Parameters["@FechaCreacion"].Value = ensayo.FCreacion;
            cmdInsert.Parameters["@TipoId"].Value = ensayo.TIPOID;
            cmdInsert.Parameters["@FechaEjecucion"].Value = ensayo.FEjecucion;
            cmdInsert.Parameters["@OrdenId"].Value = ensayo.ORDENid;
            cmdInsert.Parameters["@PaqueteId"].Value = ensayo.PaqueteID;
            cmdInsert.Parameters["@Colada"].Value = ensayo.COLADA;
            cmdInsert.Parameters["@ItemId"].Value = ensayo.ITEMid;
            cmdInsert.Parameters["@EmpleadoId"].Value = ensayo.EmpleadoID;
            cmdInsert.Parameters["@Obs"].Value = ensayo.OBS;
            cmdInsert.Parameters["@Resultado"].Value = ensayo.Result;
            cmdInsert.Parameters["@Status"].Value = ensayo.STatus;
            cmdInsert.Parameters["@TipoGeneracion"].Value = ensayo.TipoGeneracioN;
           cmdInsert.Parameters["@Correlativo"].Value = ensayo.CorrelativO;
           cmdInsert.Parameters["@CentroId"].Value = ensayo.CentroID;
            cmdInsert.Parameters["@Tipo"].Value = ensayo.TIPO;
            cmdInsert.Parameters["@Estado"].Value = ensayo.Estado1;
            cmdInsert.Parameters["@Usuario"].Value = ensayo._Usuario;
            EjecutarComando(cmdInsert);
        }
        //public int EliminarTblEnsayo(TblEnsayo ensayo)
        //{
            
        //        using (SqlConnection connection = this.be)
        //        {
        //        connection.Open();
        //        SqlTransaction sqlTran = connection.BeginTransaction();
        //        ensayo.EliminarTblEnsayo(data);
        //            ensdetalle.e;

                    
        //        }
          
        //        DbCommand cmdInsert = Adapter.DeleteCommand;
        //    cmdInsert.Parameters["@EnsayoId"].Value = ensayo.EnsayOID;
        //    EjecutarComando(cmdInsert);
        //}
        public void ModificarTblEnsayo(TblEnsayo ensayo)
        {
            DbCommand cmdModificar = Adapter.UpdateCommand;
            cmdModificar.Parameters["@EnsayoId"].Value = ensayo.EnsayOID;
            cmdModificar.Parameters["@FechaCreacion"].Value = ensayo.FCreacion;
            cmdModificar.Parameters["@TipoId"].Value = ensayo.TIPOID;
            cmdModificar.Parameters["@FechaEjecucion"].Value = ensayo.FEjecucion;
            cmdModificar.Parameters["@OrdenId"].Value = ensayo.ORDENid;
            cmdModificar.Parameters["@PaqueteId"].Value = ensayo.PaqueteID;
            cmdModificar.Parameters["@Colada"].Value = ensayo.COLADA;
            cmdModificar.Parameters["@ItemId"].Value = ensayo.ITEMid;
            cmdModificar.Parameters["@EmpleadoId"].Value = ensayo.EmpleadoID;
            cmdModificar.Parameters["@Obs"].Value = ensayo.OBS;
            cmdModificar.Parameters["@Resultado"].Value = ensayo.Result;
            cmdModificar.Parameters["@Status"].Value = ensayo.STatus;
            cmdModificar.Parameters["@TipoGeneracion"].Value = ensayo.TipoGeneracioN;
            cmdModificar.Parameters["@Correlativo"].Value = ensayo.CorrelativO;
            cmdModificar.Parameters["@CentroId"].Value = ensayo.CentroID;
            cmdModificar.Parameters["@Original_Id_Ensayo"].Value = ensayo.IDEnsayo;
            cmdModificar.Parameters["@Tipo"].Value = ensayo.TIPO;
            cmdModificar.Parameters["@Estado"].Value = ensayo.Estado1;
            cmdModificar.Parameters["@Usuario"].Value = ensayo._Usuario;
            EjecutarComando(cmdModificar);
        }

        public DataSet retornarParaEditar(int id) 
        {
            string consulta = String.Format("SELECT [Id_Ensayo],[EnsayoId],[TipoId],[OrdenId],[PaqueteId],[Colada],[ItemId],[CentroId],[Tipo],[Estado] FROM [dbo].[tblEnsayo] where Id_Ensayo={0}", id);
            return this.EjecutarConsulta(consulta);        
        }
        public DataSet retornarParaCargarCombo(string grup) 
        {
            string consulta = String.Format("select [TipoId],[Descripcion] from tblTipoEnsayo where Grupo='{0}'", grup);
            return this.EjecutarConsulta(consulta);    
        }
        public DataSet retornarEnsayoTIpo()
        {
            string consulta = String.Format("select idEnsayoTipo,sDescEnsayo from tblEnsayoTipo ");
            return this.EjecutarConsulta(consulta);
        }
        public DataSet obteneridSiguiente() 
        {
            string consulta = "SELECT distinct TOP 1 (Id_Ensayo)    FROM [dbo].[tblEnsayo]  ORDER BY Id_Ensayo DESC";
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

        public DataSet retornoEnsayoCorrespondiente(string pakt)
        {
            string consulta = String.Format("select * FROM tblEnsayo where OrdenId='{0}' AND Estado = 1", pakt);
            return this.EjecutarConsulta(consulta);
        }

        public int EliminarEnsayo(int iEnsayo,string susuario)
        {
            string consulta = String.Format("update tblensayo set Estado = 0, Usuario = '{1}' where EnsayoId ={0}", iEnsayo, susuario);
            return this.EjecutarComando(consulta);
        }

        public DataSet retornarDetallesParaFiltrar(string pramId) 
        {
            string consulta = String.Format("SELECT tblTipoEnsayoParam.ParametroId, "
                              + " tblTipoEnsayoParam.Nombre,tblTipoEnsayoParam.EsFormula,tblTipoEnsayoParam.unidad,tblTipoEnsayoParam.HabilitaLimiteMin, "
                              + " tblTipoEnsayoParam.LimiteMinAprob,tblTipoEnsayoParam.HabilitaLimiteMax,tblTipoEnsayoParam.LimiteMaxAprob,tblTipoEnsayoParam.habilitalimitetabla, "
                              + " tblTipoEnsayoParam.tablaid, tblTipoEnsayoParam.Formula, tblcattabla.descripcion,tblTipoEnsayoParam.campotabla,tblTipoEnsayoParam.tipodato FROM tblTipoEnsayoParam left join "
                              + " tblcattabla on tblTipoEnsayoParam.tablaid=tblcattabla.tablaid where tipoid={0}", pramId);
            return this.EjecutarConsulta(consulta);
        }
        

    }
}
