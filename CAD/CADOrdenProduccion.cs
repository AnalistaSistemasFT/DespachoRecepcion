using CRN.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace CAD
{
    public class CADOrdenProduccion:DBDAC
    {
        OrdenProduccion op;
        public CADOrdenProduccion()
            : base("SQLSERVER1", "dbo.tblOrdenProduccion")
        {
           /* DbParameter par = this.CrearParametro();
            par.ParameterName = "@Id_Ensayo";
            par.DbType = DbType.Int32;
            par.Direction = ParameterDirection.Output;
            Adapter.InsertCommand.CommandText += ";SELECT @Id_Ensayo=SCOPE_IDENTITY();";
            Adapter.InsertCommand.Parameters.Add(par); */       
        }
        public DataSet RetornarOrdenP  (string consulta)
        {
            
            return this.EjecutarConsulta(consulta);
        }
        public DataSet RetornarPaquetesPorOrden(string sOrden)
        {
            string consulta = String.Format("select FBC_BATCH as PAQUETE,	FBC_PRODUCT_CODE,	FBC_PRODUCT_DESC, " +
                               "FBC_WEIGHT,FBC_PIECE,FBC_METERS, " +
                                " FBC_QTY_UM   from [ElsystemNet_Ferrotodo].[dbo].[MES_TB_FLD_BATCHES] where [FBC_PO] = '{0}'", sOrden);
            return this.EjecutarConsulta(consulta);
        }


        public DataSet RetornarEnsayos(string sOrden)
        {
            string consulta = String.Format("select  * from tblEnsayo where OrdenId='{0}' and Estado = 1", sOrden);
            return this.EjecutarConsulta(consulta);
        }
        public void GuardarOrdenProduccion(OrdenProduccion opp)
        {
            DbCommand cmdInsert = Adapter.InsertCommand;
            cmdInsert.Parameters["@CentroId"].Value = opp.CentroId;
            cmdInsert.Parameters["@EmpleadoId"].Value = opp.EmpleadoId;
            cmdInsert.Parameters["@Estado"].Value = opp.Estado;
            cmdInsert.Parameters["@Fecha"].Value = opp.Fecha;
            cmdInsert.Parameters["@FechaEstado"].Value = opp.FechaEstado;
            cmdInsert.Parameters["@Id_Orden"].Value = opp.ID_Orden;
            cmdInsert.Parameters["@ItemId"].Value = opp.ItemId;
            cmdInsert.Parameters["@Operacion"].Value = opp.Operacion;
            cmdInsert.Parameters["@TipoEnsayo"].Value = opp.TipoEnsayo;
            cmdInsert.Parameters["@Usuario"].Value = opp._Usuario;
            EjecutarComando(cmdInsert);
        }


       

        public void ModificarTBLEnsayoDetalle(OrdenProduccion opp)
        {
            DbCommand cmdModificar = Adapter.UpdateCommand;
            cmdModificar.Parameters["@Estado"].Value = opp.Estado;
            cmdModificar.Parameters["@FechaEstado"].Value = opp.FechaEstado;
            cmdModificar.Parameters["@Original_Id_Orden"].Value = opp.ID_Orden;
            EjecutarComando(cmdModificar);
        }
        public int ModificarOrdenOperacion(string id,int estado,DateTime fechaestado)
        {
            return EjecutarComando(String.Format("update tblOrdenProduccion set Estado={0}, FechaEstado='{1}' where Id_Orden='{2}'",estado,fechaestado,id));

        }        
    }
}
