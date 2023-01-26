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
    public class CADMovimiento : DBDAC
    {
        public CADMovimiento()
            : base("SQLSERVER", "dbo.tblMovimiento")
        {

            //DbParameter par = this.CrearParametro();
            //par.ParameterName = "@MovimientoId";
            //par.DbType = DbType.Int32;
            //par.Direction = ParameterDirection.Output;
            //Adapter.InsertCommand.CommandText; //+= ";"; //SELECT @MovimientoId=SCOPE_IDENTITY();";
            //Adapter.InsertCommand.Parameters.Add(par);
        }
        public void GuardarMovimiento(Movimiento oMovimiento)
        {
            DbCommand cmdInsert = Adapter.InsertCommand;
            cmdInsert.Parameters["@MovimientoId"].Value = oMovimiento.MovimientoId;
            cmdInsert.Parameters["@Fecha"].Value = oMovimiento.Fecha;
            cmdInsert.Parameters["@TipoMovimiento"].Value = oMovimiento.TipoMovimiento;
            cmdInsert.Parameters["@Comprobante"].Value = oMovimiento.Comprobante;
            cmdInsert.Parameters["@Login"].Value = oMovimiento.Login;
            cmdInsert.Parameters["@Status"].Value = oMovimiento.Status;
            cmdInsert.Parameters["@SucursalId"].Value = oMovimiento.SucursalId;
            cmdInsert.Parameters["@SucEnTraspaso"].Value = oMovimiento.SucursalEnTraspaso;
            cmdInsert.Parameters["@Correlativo"].Value = oMovimiento.Correlativo;
            cmdInsert.Parameters["@Obs"].Value = oMovimiento.Obs;
            cmdInsert.Parameters["@OrdenLigada"].Value = oMovimiento.OrdenLigada;
            cmdInsert.Parameters["@ItemFLigado"].Value = oMovimiento.ItemFLigado;
            cmdInsert.Parameters["@TransEnTraspaso"].Value = oMovimiento.TransEnTraspaso;

            EjecutarComando(cmdInsert);
        }

        public DataSet TraerTodoMovSync()
        {
            return this.Consultar("");
        }
        public DataSet TraerTodoMovSync(string where)
        {
            return this.Consultar(where);
        }
 
        //public Cliente TraerCliente(int idCliente)
        //{
        //    DataSet ds = this.Consultar("IdCliente=" + idCliente);
        //    DataTable tClientes = ds.Tables[0];
        //    if (tClientes.Rows.Count == 0)
        //    {
        //        return null;
        //    }
        //    DataRow rCliente = tClientes.Rows[0];
        //    Cliente oCliente = new Cliente();
        //    oCliente.IdCliente = idCliente;
        //    oCliente.Nombre = rCliente["Nombre"].ToString();
        //    oCliente.ApellidoPaterno = rCliente["ApellidoPaterno"].ToString();
        //    oCliente.ApellidoMaterno = rCliente["ApellidoMaterno"].ToString();
        //    oCliente.Documento = rCliente["Documento"].ToString();
        //    oCliente.Sexo = rCliente["Sexo"].ToString();
        //    oCliente.CantidadHijos = Convert.ToInt32(rCliente["CantidadHijos"]);
        //    return oCliente;
        //}
        //Public Function UltimoNumero(pocon As AdoCnn, gestion As Long) As Long
        //    Dim rst As ADODB.Recordset
        //    Consulta = "select max(correlativo) as ID from tblmovimiento where year(fecha)=" & gestion & " and sucursalid=" & oSesion.Sucursal.SucursalId
        //    Set rst = pocon.GetDisconnectedRecordset(Consulta)
        //    If IsNull(rst!ID) Then
        //        UltimoNumero = 0
        //    Else
        //        UltimoNumero = rst!ID
        //    End If
        //End Function

        public int UltimoNumero(int gestion, int Sucursal)
        {

            string consulta = "Select max(Correlativo)as id from tblMovimiento where year(fecha)=" + gestion + "and SucursalID=" + Sucursal;
            //DataSet ds=cadMovSync.EjecutarConsulta(consulta);
            //DataTable dt = ds.Tables[0];

            DataSet ds = this.EjecutarConsulta(consulta);
                
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count == 0)
            {
                return 0;
            }
            DataRow rMovimiento = dt.Rows[0];
            int MaxValor=Convert.ToInt32(rMovimiento["id"]);
            return MaxValor;
        }
        public string NuevoNumero(DateTime Fecha,int sucursal, int prefijo)
        {
            int gestion; int mes;
            gestion = Fecha.Year ;
            mes = Fecha.Month;

            int Correlativo = UltimoNumero(gestion, sucursal) + 1;
            string SNuevoNumero = prefijo + "M" + serializa(gestion, 2) + serializa(Correlativo, 6);
            return SNuevoNumero;
        }
        //        Public Function NuevoNumero(pocon As AdoCnn, Fec As Date) As String
        //    Dim gestion As Long, Mes As Long
        //    gestion = Year(Fec)
        //    Correlativo = UltimoNumero(pocon, gestion) + 1
        //    NuevoNumero = oSesion.Sucursal.Prefijo & "M" & Serializa(gestion, 2) & Serializa(Correlativo, 6)
        //End Function


        //Public Function Serializa(ByVal num As Long, ByVal dig As Long) As String
        //    Dim snum As String
        //    snum = Trim(Str(num))
        //    If Len(snum) > dig Then
        //        snum = Mid(snum, 3, dig)
        //    Else
        //        Do While (Len(snum) < dig)
        //            snum = "0" & snum
        //        Loop
        //    End If
        //    Serializa = snum
        //End Function
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
 
        public DataSet TraerTodosLoscontenidos(int idCarpeta)
        {
            string consulta = "SELECT d.docId,Id_Carpeta,codigoSig,version,fechaRegistro,estado,eliminado,tituloDocumento,fechaAprobacion,autor,comentario " +
                            ",contiene=case when a.nombre is null then 'false' else 'true' end " +
                            "FROM documentos d left join archivo a on d.docId =a.docId where d.eliminado='false' and d.Id_Carpeta=" + idCarpeta.ToString();

            return this.EjecutarConsulta(consulta);
        }

        public DataSet TraerOrdenDespachada(string OrdenId)
        {
            string consulta = "SELECT i.ItemId ,i.descripcion,Peso=case i.unidadf when 'kg' then sum([CantConfirmada]) else 0 end, " +
                  "Piezas=case i.unidadf when 'pcs' then sum([CantConfirmada]) else 0 end,isnull(gi.PrecioTon,0) as [Precio/Ton],0 as [Costo/Unidad],i.itemfid as Ferrotodo,i.unidadf " +
                   "FROM (tblDespDetalle RD inner join tblitem I on rd.itemid=i.itemid) left join tblGrupoItem GI on gi.grupoid=i.grupoid " +
                    "where Despachoid='" + OrdenId.ToString() + "' " +
                     "group by i.ItemId,i.descripcion,i.Unidadf,gi.PrecioTon,i.itemfid";
            return this.EjecutarConsulta(consulta);
        }
        public DataSet TraerOrdenRecepcionada(string OrdenId)
        {
            string consulta = "SELECT i.ItemId ,i.descripcion,Peso=case i.unidadf when 'kg' then sum([CantidadRecibida]) else 0 end, " +
                  "Piezas=case i.unidadf when 'pcs' then sum([CantidadRecibida]) else 0 end,isnull(gi.PrecioTon,0) as [Precio/Ton],0 as [Costo/Unidad],i.itemfid as Ferrotodo,i.unidadf " +
                   "FROM (tblRecepcionDetalle RD inner join tblitem I on rd.itemid=i.itemid) left join tblGrupoItem GI on gi.grupoid=i.grupoid " +
                    "where recepcionid='" + OrdenId.ToString() + "' " +
                     "group by i.ItemId,i.descripcion,i.Unidadf,gi.PrecioTon,i.itemfid";
            return this.EjecutarConsulta(consulta);
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
        public DataSet TraerMovimientos(int Sucursal, string TipoMov)
        {
            string Consulta = @" select* from tblMovimiento where SucursalID = {0} and TipoMovimiento = '{1}'";
            Consulta = string.Format(Consulta, Sucursal, TipoMov);
            return EjecutarConsulta(Consulta);

        }

        public int EliminarArchivosCarpetas(int docId)
        {
            return EjecutarComando("DELETE FROM dbo.documentos WHERE docId=" + docId.ToString());
        }

        public int MarcarEliminado(int docId, int Valor)
        {
            return EjecutarComando("UPDATE dbo.documentos set eliminado = " + Valor + " WHERE docId=" + docId.ToString());
        }
        public DataSet BuscarDocumento(string nombDocumento)
        {
            string cadena = "select docId,tituloDocumento,autor from documentos where tituloDocumento like '%" + nombDocumento + "%'";
            return EjecutarConsulta(cadena);
        }
    }
}
