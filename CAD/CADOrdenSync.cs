using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Configuration;
using System.Data;
using System.Data.Common;
using CRN.Entidades;

namespace CAD
{
    public class CADOrdenSync:DBDAC
    {
        public CADOrdenSync()
            : base("SQLSERVER", "dbo.tblMovSync")
        {

            //DbParameter par = this.CrearParametro();
            //par.ParameterName = "@OrdenId";
            //par.DbType = DbType.Int32;
            //par.Direction = ParameterDirection.Output;
            //Adapter.InsertCommand.CommandText += ";SELECT @OrdenId=SCOPE_IDENTITY();";
            //Adapter.InsertCommand.Parameters.Add(par);
        }

        public int GuardarOrdenSync(OrdenSync oMovSync)
        {
            DbCommand cmdInsert = Adapter.InsertCommand;
            cmdInsert.Parameters["@OrdenId"].Value = oMovSync.OrdenId;
            cmdInsert.Parameters["@Fecha"].Value = oMovSync.Fecha;
            cmdInsert.Parameters["@CentroTrabajo"].Value = oMovSync.CentroTrabajo;
            cmdInsert.Parameters["@FechaCierre"].Value = oMovSync.FechaCierre;
            cmdInsert.Parameters["@Status"].Value = oMovSync.Status;
            cmdInsert.Parameters["@TipoOrden"].Value = oMovSync.TipoOrden;
            cmdInsert.Parameters["@SucursalId"].Value = oMovSync.SucursalId;
            cmdInsert.Parameters["@SucursalDestino"].Value = oMovSync.SucursalDestino;
            cmdInsert.Parameters["@OrdenLigada"].Value = oMovSync.OrdenLigada;
            cmdInsert.Parameters["@ItemFLigado"].Value = oMovSync.ItemFLigado;
            cmdInsert.Parameters["@EsDeCliente"].Value = oMovSync.EsDeCliente;
            return EjecutarComando(cmdInsert);
        }
        public void ModificarOrdenSync(OrdenSync oMovSync)
        {
            DbCommand cmdUpdate = Adapter.UpdateCommand;
            cmdUpdate.Parameters["@OrdenId"].Value = oMovSync.OrdenId;
            cmdUpdate.Parameters["@Fecha"].Value = oMovSync.Fecha;
            cmdUpdate.Parameters["@CentroTrabajo"].Value = oMovSync.CentroTrabajo;
            cmdUpdate.Parameters["@FechaCierre"].Value = oMovSync.FechaCierre;
            cmdUpdate.Parameters["@Status"].Value = oMovSync.Status;
            cmdUpdate.Parameters["@TipoOrden"].Value = oMovSync.TipoOrden;
            cmdUpdate.Parameters["@SucursalId"].Value = oMovSync.SucursalId;
            cmdUpdate.Parameters["@SucursalDestino"].Value = oMovSync.SucursalDestino;
            cmdUpdate.Parameters["@OrdenLigada"].Value = oMovSync.OrdenLigada;
            cmdUpdate.Parameters["@ItemFLigado"].Value = oMovSync.ItemFLigado;
            cmdUpdate.Parameters["@EsDeCliente"].Value = oMovSync.EsDeCliente;
            cmdUpdate.Parameters["@Original_OrdenId"].Value = oMovSync.OrdenId;
            EjecutarComando(cmdUpdate);
        }
        public void EliminarOrdenSync(string orden)
        {
            DbCommand cmdDelete = Adapter.DeleteCommand;
            cmdDelete.Parameters["@Original_OrdenId"].Value = orden;
            EjecutarComando(cmdDelete);
        }

        public DataSet TraerTodosOrdenSync()
        {
            return this.Consultar("");
        }
        public DataSet TraerTodosParaRevision(int sucursal)
        {
            string cons2= "select opr_po as Orden,opr_product_code as ItemId,opr_product_desc as Descripcion,opr_status_date as Fecha,opr_qty as CANTIDAD,OPR_QTY_UM AS UNIDAD,opr_workcenter as Centro,opr_status as Status "+
            "from ElsystemNet_Ferrotodo.dbo.MES_TB_PRO_OPR " +
            "where opr_po collate Modern_Spanish_CI_AS not in (select ordenid from tblMovSync) AND OPR_STATUS = 'CLOS' AND OPR_WORKCENTER COLLATE MODERN_SPANISH_CI_AS IN("+
            "SELECT CENTROiD FROM TBLCENTROTRABAJO WHERE TBLCENTROTRABAJO.REVISION = 'TRUE' and selectsql <> '' AND CentroId <> 'SLI01' AND SUCURSALID = "+ sucursal +")";

            string cons1 = " UNION "+
            "SELECT SAC_ASSEMBLING_CUT collate Modern_Spanish_CI_AS AS ORDEN, SPC_PRODUCT_CODE as itemid,SPC_PRODUCT_DESC as descripcion,SAC_STATUS_DATE as fecha,SAC_QTY as cantidad,SAC_QTY_UM as unidad,SAC_WORKCENTER as centro,SAC_STATUS as status " +
            "from ElsystemNet_Ferrotodo.dbo.MES_TB_SLI_ASSEMBLING_CUT inner join ElsystemNet_Ferrotodo.dbo.MES_TB_SLI_PICKING on SPC_EX_ASSEMBLING_CUT = SAC_ASSEMBLING_CUT " +
            "WHERE SAC_STATUS = 'CLOS' AND SAC_ASSEMBLING_CUT collate Modern_Spanish_CI_AS not in (select ordenid from tblMovSync where status <> 'CANCEL')";

            if (sucursal == 12070)
                cons2 += cons1; 
            return this.EjecutarConsulta(cons2);
        }

        public DataSet TraerTodosParaRevision2(int sucursal)
        {
            string cons2 = "";
            int i = 0;
            string cons1 = "SELECT * FROM TBLCENTROTRABAJO WHERE TBLCENTROTRABAJO.REVISION='TRUE' and selectsql<>'' AND SUCURSALID=" + sucursal;
            DataSet ds = EjecutarConsulta(cons1);
            DataTable dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                cons2 = cons2 + dr["SelectSQL"] + " " + dr["WhereSQL"];
                i++;
                int j = dr.Table.Rows.IndexOf(dr);
                if (j < dt.Rows.Count - 1)
                {
                    cons2 = cons2 + " UNION ";
                }
            }
            return this.EjecutarConsulta(cons2);
        }
        public DataSet TraerTodosOrdenSync(string estado,int sucursal)
        {
            string consulta = "Select OrdenId [Orden], Fecha, CentroTrabajo, FechaCierre, Status,"+
                            "case (SELECT COUNT(*) FROM PRODUCIDO WHERE NRO_ORDEN = tblMovSync.OrdenId) when 0 then 0 else "+
                            "(select convert(decimal,COUNT(*),1) FROM PRODUCIDO WHERE STATUS = 'SYNC' AND NRO_ORDEN = tblMovSync.OrdenId) / (SELECT COUNT(*) FROM PRODUCIDO WHERE NRO_ORDEN = tblMovSync.OrdenId) end AS PORCENTAJE " +
                "from tblMovSync "+
                "where TIPOORDEN='PRODUCCION' AND status in(" + estado + ") and SucursalID=" + sucursal;
            return this.EjecutarConsulta(consulta);
        }

        public OrdenSync TraerOrdenSync(string OrdenId)
        {
            //DataSet ds = this.Consultar("OrdeId=" + OrdenId);
            DataSet ds = this.Consultar("OrdenId='" + OrdenId + "'");
            DataTable tMovSync = ds.Tables[0];
            if (tMovSync.Rows.Count == 0)
            {
                return null;
            }
            DataRow rMovSync = tMovSync.Rows[0];
            OrdenSync oMovSync = new OrdenSync();
            oMovSync.OrdenId  = rMovSync["OrdenId"].ToString();
            oMovSync.Fecha = Convert.ToDateTime(rMovSync["Fecha"]);
            oMovSync.CentroTrabajo = rMovSync["CentroTrabajo"].ToString();
            oMovSync.FechaCierre = Convert.ToDateTime(rMovSync["FechaCierre"]);
            oMovSync.Status = rMovSync["Status"].ToString();
            oMovSync.TipoOrden = rMovSync["TipoOrden"].ToString();
            oMovSync.SucursalId = Convert.ToInt32(rMovSync["SucursalId"]);
            oMovSync.SucursalDestino = Convert.ToInt32(rMovSync["SucursalDestino"]);
            oMovSync.OrdenLigada = Convert.ToString(rMovSync["OrdenLigada"]);
            oMovSync.ItemFLigado = Convert.ToString(rMovSync["ItemFLigado"]);
            oMovSync.EsDeCliente = Convert.ToBoolean(rMovSync["EsDeCliente"]);
            return oMovSync;

        }

        public decimal ObtenerDiametroOrden(string Orden)
        {
            decimal Diametro;
            string Consulta = "SELECT convert(float,[OPF_VALUE]) as Valor " +
                "from [ElsystemNet_Ferrotodo].[dbo].[MES_TB_PRO_OPR_FEATURES] " +
                "where OPF_FEATURE='DIAMETER' AND OPF_PO ='" + Orden + "'";
            DataSet ds = EjecutarConsulta(Consulta);
            DataTable dt = ds.Tables[0];
            DataRow dr = dt.Rows[0];
            Diametro = Convert.ToDecimal(dr["Valor"]);
            return Diametro;
        }



        //public int UltimoNumero(int gestion, int Sucursal)
        //{

        //    string consulta = "Select max(Correlativo)as id from tblMovimiento where year(fecha)=" + gestion + "and SucursalID=" + Sucursal;

        //    DataSet ds = this.Consultar(consulta);

        //    DataTable dt = ds.Tables[0];
        //    if (dt.Rows.Count == 0)
        //    {
        //        return 0;
        //    }
        //    DataRow rMovimiento = dt.Rows[0];
        //    int MaxValor=Convert.ToInt32(rMovimiento["id"]);
        //    return MaxValor;
        //}
        //public string NuevoNumero(DateTime Fecha,int sucursal, int prefijo)
        //{
        //    int gestion; int mes;
        //    gestion = Fecha.Year ;
        //    mes = Fecha.Month;

        //    int Correlativo = UltimoNumero(gestion, sucursal) + 1;
        //    string SNuevoNumero = prefijo + "M" + serializa(gestion, 2) + serializa(Correlativo, 6);
        //    return SNuevoNumero;
        //}

        public string serializa(int num, int dig)
        {
            string snum;
            snum=num.ToString().Trim();
            if (snum.Length > dig)

                snum = snum.Substring(3, dig);
            else
            {
                while (snum.Length < dig)
                {
                    snum = "0" + snum;

                }
            }
            return snum;
         }
        
        public DataSet Consumido(string Orden, string Centro)
        {
            string selCriterio;
            int pzasBob;
            string Consulta;
            switch (Centro)
            {
                case "PAINT01":
                    selCriterio = "SUM(FBC_PIECE)";
                    //Consulta = "SELECT tblitem.itemid,tblitem.Descripcion,sum([FCS_CONSUMED_QTY]) as peso," + selCriterio + " as piezas,tblitem.itemfid,tblitem.unidadf,tblitem.calidad,tblitem.espesor " +
                    //         "FROM (ElsystemNet_Ferrotodo.dbo.MES_TB_FLD_CONSUMED inner join ElsystemNet_Ferrotodo.dbo.MES_TB_FLD_BATCHES on FCS_BATCH=FBC_BATCH) left join tblItem on FBC_PRODUCT_CODE collate modern_spanish_ci_as =tblitem.itemid " +
                    //         "WHERE FCS_PO  = '" + Orden + "' ";
                    Consulta = "SELECT tblitem.itemid,tblitem.Descripcion,sum([FCS_CONSUMED_QTY]) as peso," + selCriterio + " as piezas,tblitem.itemfid,tblitem.unidadf,tblitem.calidad,tblitem.espesor " +
                           "FROM (ElsystemNet_Ferrotodo.dbo.MES_TB_FLD_CONSUMED inner join ElsystemNet_Ferrotodo.dbo.MES_TB_FLD_BATCHES on FCS_BATCH=FBC_BATCH) left join tblItem on FBC_PRODUCT_CODE collate modern_spanish_ci_as =tblitem.itemid " +
                           "WHERE FCS_PO  = '" + Orden + "' ";
                    break;
                case "SLI01":
                    Consulta = "select distinct fbc_batch " +
                    "FROM ((ElsystemNet_Ferrotodo.dbo.MES_TB_FLD_BATCHES inner join ElsystemNet_Ferrotodo.dbo.MES_TB_FLD_CONSUMED on FCS_batch =FBC_batch) inner join ElsystemNet_Ferrotodo.dbo.MES_TB_PRO_OPR on OPR_PO=FCS_PO) left join tblItem on FBC_PRODUCT_CODE collate modern_spanish_ci_as =tblitem.itemid  " +
                    "where OPR_ASSEMBLING_CUT_NAME ='" + Orden + "' ";
                    return EjecutarConsulta(Consulta);
                    selCriterio = "count(*)";
                    Consulta = "SELECT tblitem.itemid,tblitem.Descripcion,SUM(FCS_CONSUMED_QTY)  as peso," + pzasBob + " as piezas,tblitem.itemfid,tblitem.unidadf,tblitem.calidad,tblitem.espesor " +
                    "FROM ((ElsystemNet_Ferrotodo.dbo.MES_TB_FLD_BATCHES inner join ElsystemNet_Ferrotodo.dbo.MES_TB_FLD_CONSUMED on FCS_batch =FBC_batch) inner join ElsystemNet_Ferrotodo.dbo.MES_TB_PRO_OPR on OPR_PO=FCS_PO) left join tblItem on FBC_PRODUCT_CODE collate modern_spanish_ci_as =tblitem.itemid  " +
                    "where OPR_ASSEMBLING_CUT_NAME ='" + Orden + "' ";
                    break;
                default:
                    selCriterio = "SUM(FBC_PIECE )";
                    Consulta = "SELECT tblitem.itemid,tblitem.Descripcion,sum([FCS_CONSUMED_QTY]) as peso," + selCriterio + " as piezas,tblitem.itemfid,tblitem.unidadf,tblitem.calidad,tblitem.espesor " +
                    "FROM (ElsystemNet_Ferrotodo.dbo.MES_TB_FLD_CONSUMED inner join ElsystemNet_Ferrotodo.dbo.MES_TB_FLD_BATCHES on FCS_BATCH=FBC_BATCH) left join tblItem on FBC_PRODUCT_CODE collate modern_spanish_ci_as =tblitem.itemid  " +
                    "WHERE FCS_PO  = '" + Orden + "' ";
                    break;
            }
            Consulta = Consulta + "group by tblitem.itemid,tblitem.Descripcion,tblitem.itemfid,tblitem.unidadf,tblitem.calidad,tblitem.espesor ";

            return EjecutarConsulta(Consulta);
        }

        public DataSet Producido(string Orden,string Centro)
        {
            string Consulta;
            string Consulta1;
            string Consulta2;
            if(Centro=="SLI01")
            {
            Consulta1 = "SELECT tblitem.itemid,tblitem.Descripcion, sum(FBC_WEIGHT) as peso,COUNT(*) AS PIEZAS,tblitem.itemfid,tblitem.unidadf,tblitem.calidad,tblitem.espesor " +
                        "FROM (ElsystemNet_Ferrotodo.dbo.[MES_TB_PRO_OPR] inner join ElsystemNet_Ferrotodo.dbo.MES_TB_FLD_BATCHES on OPR_PO=FBC_PO) left join tblItem on FBC_PRODUCT_CODE collate modern_spanish_ci_as =tblitem.itemid " +
                        "where OPR_ASSEMBLING_CUT_NAME ='" + Orden + "' ";

            Consulta2 = " union SELECT tblitem.itemid,tblitem.descripcion,SUM(SCR_WEIGHT) AS peso,1 AS PIEZAS,tblItem.Itemfid,tblitem.unidadf,tblitem.calidad,tblitem.espesor " +
                        "FROM ((ElsystemNet_Ferrotodo.dbo.MES_TB_SLI_ASSEMBLING_CUT inner join ElsystemNet_Ferrotodo.dbo.MES_TB_PRO_OPR on SAC_ASSEMBLING_CUT=OPR_ASSEMBLING_CUT_NAME) inner join ElsystemNet_Ferrotodo.dbo.MES_TB_FLD_SCRAP on OPR_po=SCR_PO ),tblItem " +
                        "WHERE OPR_ASSEMBLING_CUT_NAME ='" + Orden + "' and tblItem.ItemId='9016-0' " +
                        "group by convert(varchar,SAC_THICKNESS),tblitem.itemid,tblitem.Descripcion,tblItem.itemfid,tblitem.unidadf,tblitem.calidad,tblitem.espesor ";
            }
            else
            {
                    Consulta1 = "select tblitem.itemid,tblitem.Descripcion,SUM(FBC_WEIGHT) as peso,SUM(FBC_PIECE) as piezas,tblitem.itemfid,tblitem.unidadf,tblitem.calidad,tblitem.espesor " +
                                "from ElsystemNet_Ferrotodo.dbo.MES_TB_FLD_BATCHES left join tblItem on FBC_PRODUCT_CODE collate modern_spanish_ci_as =tblitem.itemid " +
                                "WHERE Fbc_pO = '" + Orden + "' ";
                    Consulta2 = "";
            }

            Consulta = Consulta1 + "group by tblitem.itemid,tblitem.Descripcion,tblitem.itemfid,tblitem.unidadf,tblitem.calidad,tblitem.espesor " + Consulta2;
            return EjecutarConsulta(Consulta);
        
        }


        //public int ModificarArchivos(OrdenSync oorden)
        //{
        //    DbCommand cmdModificar = Adapter.UpdateCommand;
        //    cmdModificar.Parameters["@OrdenId"].Value = oorden.OrdenId;
        //    cmdModificar.Parameters["@Fecha"].Value = oorden.Fecha;
        //    cmdModificar.Parameters["@CentroTrabajo"].Value = oorden.CentroTrabajo;
        //    cmdModificar.Parameters["@FechaCierre"].Value = oorden.FechaCierre;
        //    cmdModificar.Parameters["@Status"].Value = oorden.Status;
        //    cmdModificar.Parameters["@TipoOrden"].Value = oorden.TipoOrden;
        //    cmdModificar.Parameters["@SucursalId"].Value = oorden.SucursalId;
        //    cmdModificar.Parameters["@SucursalDestino"].Value = oorden.SucursalDestino;
        //    cmdModificar.Parameters["@OrdenLigada"].Value = oorden.OrdenLigada;
        //    cmdModificar.Parameters["@ItemFLigado"].Value = oorden.ItemFLigado ;
        //    cmdModificar.Parameters["@EsDeCliente"].Value = oorden.EsDeCliente;
        //    return EjecutarComando(cmdModificar);
        //}
        
        //public int EliminarArchivosCarpetas(int docId)
        //{
        //    return EjecutarComando("DELETE FROM dbo.documentos WHERE docId=" + docId.ToString());
        //}

        //public int MarcarEliminado(int docId, int Valor)
        //{
        //    return EjecutarComando("UPDATE dbo.documentos set eliminado = " + Valor + " WHERE docId=" + docId.ToString());
        //}
        //public DataSet BuscarDocumento(string nombDocumento)
        //{
        //    string cadena = "select docId,tituloDocumento,autor from documentos where tituloDocumento like '%" + nombDocumento + "%'";
        //    return EjecutarConsulta(cadena);
        //    //  return this.Consultar("tituloDocumento LIKE '"+nombDocumento+"%'");
        //    //return this.Consultar(string.Format("tituloDocumento LIKE '%{2}%'",nombDocumento.Replace("'", "''")));
        //    //     return this.Consultar(string.Format("autor LIKE '%{2}%'", nombDocumento.Replace("'", "''")));
        //    // return this.Consultar("select * from documentos where tituloDocumento Like"+nombDocumento);
        //}
        public int CerrarOrden(string orden)
        {
            //DbCommand cmdCerrarOrden = Adapter.UpdateCommand;
            //cmdCerrarOrden.Parameters["@OrdenId"].Value = orden;

            //cmdCerrarOrden.Parameters["@FechaCierre"].Value = oorden.FechaCierre;
            //cmdCerrarOrden.Parameters["@Status"].Value = oorden.Status;

            //cmdCerrarOrden.CommandText = "Update tblmovSync set statUs='CLOSE',FECHACIERRE=SYSDATETIME() WHERE ORDENID='" + orden + "'";
            string Consulta = "Update tblmovSync set statUs='CLOSE',FECHACIERRE=SYSDATETIME() WHERE ORDENID='" + orden + "'";
            return EjecutarComando(Consulta);
        }
    }

}

