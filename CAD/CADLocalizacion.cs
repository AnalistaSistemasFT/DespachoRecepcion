using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace CAD
{
    public class CADLocalizacion : oledb
    {
        public CADLocalizacion()
        {
            this.sConnName = "SQLSERVER";
        }
        public DataSet TraerOrdenesProduccion(int _idSucursal)
        {
            string consulta = "select opr_po as Orden,opr_product_code as ItemId,opr_product_desc as Descripcion,OPR_STATUS_DATE as FechaFin,opr_qty as CANTIDAD,OPR_QTY_UM AS UNIDAD,opr_workcenter as Centro,opr_status as Status from (ElsystemNet_Ferrotodo.dbo.MES_TB_PRO_OPR inner join tblCentroTrabajo on OPR_WORKCENTER collate Modern_Spanish_CI_AS=tblCentroTrabajo.CentroId)left join tblplan on opr_po collate modern_spanish_ci_as=tblplan.OrdenId Where tblplan.OrdenId Is Null and CENTROID IN (SELECT CentroId from tblCentroTrabajo WHERE LOCALIZACION='TRUE' AND tblCentroTrabajo.SUCURSALID=" + _idSucursal + " )AND OPR_STATUS collate modern_spanish_ci_as in(SELECT Status FROM SysStatus where activo='True')  order by ORDEN";
            return this.consultar(consulta);
        }
        public DataSet TraerDetalleOrdenesProduccion(string _nrOrden)
        {
            string consulta = "select FBC_BATCH as PaqueteId,fbc_product_code as Codigo,fbc_weight as Peso,fbc_piece as Piezas from ElsystemNet_Ferrotodo.dbo.MES_TB_FLD_BATCHES where MES_TB_FLD_BATCHES.FBC_PO='" + _nrOrden + "'";
            return this.consultar(consulta);
        }
        public DataSet TraerOrdenesAbiertas(int _idSucursal)
        {
            string consulta = "select TBLPLAN.planid,TBLPLAN.ordenid,Lpr_product_code as ItemId,Lpr_product_desc as Descripcion,TBLPLAN.fecha,TBLPLAN.cantidad,TBLPLAN.unidad,TBLPLAN.operador,MES_TB_PRO_OPR.OPR_STATUS as Status, tblplan.Centrotrabajo from(tblPlan inner join ElsystemNet_Ferrotodo.dbo.MES_TB_PRO_OPR on tblplan.ordenid= opr_po collate modern_spanish_ci_as) inner join ElsystemNet_Ferrotodo.dbo.MES_TB_LST_PRODUCT on LPR_PRODUCT_CODE collate Modern_Spanish_CI_AS = TBLPLAN.ItemId where tblplan.sucursalid = " + _idSucursal + " and OPR_STATUS_DATE>= '23/08/2012 20:00:00' and tblplan.tipoplan = 'PRODUCCION' and tblplan.status = 'OPEN' order by fecha";
            return this.consultar(consulta); 
        }
        public DataSet TraerDetalleOrdenAbiertaProgra(string _nrOrden)
        {
            string consulta = "select DetalleId,AlmacenOrigen,AlmacenDestino,CeldaOrigen,CeldaDestino,Paquetes,secuencia,Status from tblplandetalle where planid='" + _nrOrden + "'";
            return this.consultar(consulta);
        }
        public DataSet TraerDetalleOrdenAbiertaProducto(string _nrOrden)
        {
            string consulta = "select tblplanlocaliza.Paqueteid,tblitem.itemid,tblplanlocaliza.piezas,tblplanlocaliza.peso,tblplanlocaliza.Celdaid,tblplanlocaliza.fecha from tblplanlocaliza inner join tblitem on tblplanlocaliza.itemid = tblitem.itemid where tblplanlocaliza.planid ='" + _nrOrden + "'";
            return this.consultar(consulta);
        }
        public DataSet TraerOrdenesCerradas(int _idSucursal)
        {
            string consulta = "select TBLPLAN.planid,TBLPLAN.ordenid,Lpr_product_code as ItemId,Lpr_product_desc as Descripcion,TBLPLAN.fecha,TBLPLAN.cantidad,TBLPLAN.unidad,TBLPLAN.operador,MES_TB_PRO_OPR.OPR_STATUS as Status, tblplan.Centrotrabajo from(tblPlan inner join ElsystemNet_Ferrotodo.dbo.MES_TB_PRO_OPR on tblplan.ordenid= opr_po collate modern_spanish_ci_as) inner join ElsystemNet_Ferrotodo.dbo.MES_TB_LST_PRODUCT on LPR_PRODUCT_CODE collate Modern_Spanish_CI_AS = TBLPLAN.ItemId where tblplan.sucursalid = " + _idSucursal + " and OPR_STATUS_DATE>= '23/08/2012 20:00:00' and tblplan.tipoplan = 'PRODUCCION' and tblplan.status = 'CLOSE' order by fecha";
            return this.consultar(consulta);
        }
        public DataSet TraerCantidadPlanificar(string _NrOrden)
        {
            string consulta = "select b.Paquetes from tblPlan a INNER JOIN tblPlanDetalle b ON a.PlanId = b.PlanId where a.OrdenId = '" + _NrOrden + "'";
            return this.consultar(consulta);
        }
        public DataSet TraerDatosPicking(string _PlanId)
        {
            string consulta = "select PaqueteId, AlmacenId, CeldaID, Fecha, Status from tblPlanLocaliza where PlanId = '" + _PlanId + "'";
            return this.consultar(consulta);
        }
        public int ConsolidarPaquetePick(string _Planid, string _PaqueteId)
        {
            string sError = string.Empty;
            string sUpdate = "UPDATE tblPlanLocaliza SET Status='CLOSE' WHERE PlanId='" + _Planid + "' AND PaqueteId = '" + _PaqueteId + "'";
            sUpdate = string.Format(sUpdate);
            return this.ejecutar(ref sError, sUpdate); 
        }
        public int CerrarOrdenPicking(out string sError, string _PlanId, string _OrdenId, DataTable dt)
        {
            sError = string.Empty;
            int a = 0;
            using (DbTransaction trnSql = this.IniciarTransaccion())
            {
                a = CloseOrdenPick(_PlanId, _OrdenId, trnSql);
                if (a > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string _paq = dt.Rows[i][2].ToString();
                        a = ClosePlanLocalizaPick(_PlanId, _OrdenId, _paq, trnSql);
                        if (a == 0)
                        {
                            break;
                        }
                    }
                    if (a > 0)
                    {
                        trnSql.Commit();
                    }
                    else
                    {
                        trnSql.Rollback();
                    }
                }
                else
                {
                    trnSql.Rollback();
                    trnSql.Dispose();
                }
                return a;
            } 
        }
        public int CloseOrdenPick(string _PlanId, string _OrdenId, DbTransaction trnProxy)
        {
            string sError = string.Empty;
            string sUpdate = "UPDATE tblPlan SET Status='CLOSE' WHERE PlanId='" + _PlanId + "' AND OrdenId = '" + _OrdenId + "'";
            sUpdate = string.Format(sUpdate);
            return this.ejecutar(ref sError, sUpdate, trnProxy);
        }
        public int ClosePlanLocalizaPick(string _PlanId, string _OrdenId, string _PaqueteId, DbTransaction trnProxy)
        {
            string sError = string.Empty;
            string sUpdate = "UPDATE tblPlanLocaliza SET Status='CLOSE' WHERE PlanId='" + _PlanId + "' AND PaqueteId = '" + _PaqueteId + "'";
            sUpdate = string.Format(sUpdate);
            return this.ejecutar(ref sError, sUpdate, trnProxy);
        }
    }
}
