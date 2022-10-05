using CRN.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace CAD
{
    public class CADCatTablas:DBDAC
    {
        public CADCatTablas()
            : base("SQLSERVER1", "dbo.tblCatTabla")
        {
           // DbParameter par = this.CrearParametro();
           // par.ParameterName = "@TablaId";
           // par.DbType = DbType.Int32;
          //  par.Direction = ParameterDirection.Output;
            //Adapter.InsertCommand.CommandText += ";SELECT @TablaId=SCOPE_IDENTITY();";
          //  Adapter.InsertCommand.Parameters.Add(par);        
        }
        public DataSet RetornarCatTablas(string consulta)
        {
            return this.EjecutarConsulta(consulta);
        }
        public void GuardarCatTablas(CatTabla ensayo)
        {
            DbCommand cmdInsert = Adapter.InsertCommand;
            cmdInsert.Parameters["@Descripcion"].Value = ensayo.Descripcion;
            cmdInsert.Parameters["@TipoProducto"].Value = ensayo.TipoProducto;
            cmdInsert.Parameters["@Campo"].Value = ensayo.Campo;
            cmdInsert.Parameters["@Unidad"].Value = ensayo.Unidad;
            cmdInsert.Parameters["@TablaId"].Value = ensayo.TtablaId;
            EjecutarComando(cmdInsert);
        }
        public void ModificarCatTablas(CatTabla ensayo)
        {
            DbCommand cmdModificar = Adapter.UpdateCommand;
            cmdModificar.Parameters["@Descripcion"].Value = ensayo.Descripcion;
            cmdModificar.Parameters["@TipoProducto"].Value = ensayo.TipoProducto;
            cmdModificar.Parameters["@Campo"].Value = ensayo.Campo;
            cmdModificar.Parameters["@Unidad"].Value = ensayo.Unidad;
            cmdModificar.Parameters["@TablaId"].Value = ensayo.TtablaId;
            cmdModificar.Parameters["@Original_TablaId"].Value = ensayo.TtablaId;
           // cmdModificar.Parameters["@Operacion"].Value = ensayo.OperacioneS;
            EjecutarComando(cmdModificar);
        }
        public DataSet retornoTHijas(string padre) 
        {
            string consulta = String.Format("select FBC_BATCH,	FBC_PRODUCT_CODE,	FBC_PRODUCT_DESC,	FBC_SO,	FBC_POS,	FBC_WEIGHT,	FBC_PIECE,	FBC_METERS,	FBC_START,	FBC_OPERATOR,	FBC_ISSUE,	FBC_QTY_UM " +
                     "  from [ElsystemNet_Ferrotodo].[dbo].[MES_TB_FLD_BATCHES] where [FBC_PO] = '{0}'", padre);
            return this.EjecutarConsulta(consulta);
        }

        public DataSet DetalleSobrantesxOrden(string sOrden)
        {
            string sSelect = @"SELECT FCS_BATCH as Paqueteid,tblitem.itemid,tblitem.DESCRIPCION,tblitem.itemFID,tblitem.unidadf,3 as almacenid,FBC_PIECE as piezas,
								FCS_CONSUMED_QTY As peso, FCS_END As Fecha,tblpaquetes.sucursalid,TBLPAQUETES.Celdaid
								FROM((ElsystemNet_Ferrotodo.dbo.MES_TB_FLD_CONSUMED inner join
								 ElsystemNet_Ferrotodo.dbo.MES_TB_FLD_BATCHES on FBC_BATCH = FCS_BATCH)inner join
								  [LYBK].[dbo].tblitem on FBC_PRODUCT_CODE COLLATE Modern_Spanish_CI_AS = tblitem.itemid) left join
								 [LYBK].[dbo].TBLPAQUETES on FCS_BATCH COLLATE Modern_Spanish_CI_AS = TBLPAQUETES.PaqueteId where FCS_PO = '{0}' and SucursalId is null";
            sSelect = string.Format(sSelect, sOrden);
            return this.EjecutarConsulta(sSelect);
        }
    }
}
