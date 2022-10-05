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
    public class CADDespDetalle:DBDAC
    {
        public CADDespDetalle()
            : base("SQLSERVER", "dbo.tblDespDetalle")
        {

            //DbParameter par = this.CrearParametro();
            //par.ParameterName = "@DespachoId";
            //par.DbType = DbType.Int32;
            //par.Direction = ParameterDirection.Output;
            //Adapter.InsertCommand.CommandText += ";SELECT @DespachoId=SCOPE_IDENTITY();";
            //Adapter.InsertCommand.Parameters.Add(par);
        }
        
        public int GuardarDespDetalle(DespDetalle _detalleDesp)
        {
            DbCommand cmdInsert = Adapter.InsertCommand;
            //cmdInsert.Parameters.Clear();
            cmdInsert.Parameters["@DespachoId"].Value = _detalleDesp.p_DespachoId;
            cmdInsert.Parameters["@ItemId"].Value = _detalleDesp.p_ItemId;
            cmdInsert.Parameters["@Cantidad"].Value = _detalleDesp.p_Cantidad;
            cmdInsert.Parameters["@SolPiezasSueltas"].Value = _detalleDesp.p_SolPiezasSueltas;
            cmdInsert.Parameters["@ConfPiezasSueltas"].Value = _detalleDesp.p_ConfPiezasSueltas;
            cmdInsert.Parameters["@CantConfirmada"].Value = _detalleDesp.p_CantConfirmada;
            cmdInsert.Parameters["@Unidad"].Value = _detalleDesp.p_Unidad;
            cmdInsert.Parameters["@Status"].Value = _detalleDesp.p_Status;
            cmdInsert.Parameters["@SucursalId"].Value = _detalleDesp.p_SucursalId;
            return EjecutarComando(cmdInsert);
        }

        public DataSet TraerTodosLosDespDetalle()
        {
            return this.Consultar("");
        }
        public DataSet TraerTodosLosDespDetalle(string where)
        {
            return this.Consultar(where);
        }

        public int ModificarDespDetalle(DespDetalle oDespDetalle)
        {
            DbCommand cmdModificar = Adapter.UpdateCommand;
            cmdModificar.Parameters["@DespachoId"].Value = oDespDetalle.p_DespachoId;
            cmdModificar.Parameters["@Itemd"].Value = oDespDetalle.p_ItemId;
            cmdModificar.Parameters["@Cantidad"].Value = oDespDetalle.p_Cantidad;
            cmdModificar.Parameters["@SolPiezasSueltas"].Value = oDespDetalle.p_SolPiezasSueltas;
            cmdModificar.Parameters["@ConfPiezasSueltas"].Value = oDespDetalle.p_ConfPiezasSueltas;
            cmdModificar.Parameters["@CantConfirmada"].Value = oDespDetalle.p_CantConfirmada;
            cmdModificar.Parameters["@Unidad"].Value = oDespDetalle.p_Unidad;
            cmdModificar.Parameters["@Status"].Value = oDespDetalle.p_Status;
            cmdModificar.Parameters["@SucursalId"].Value = oDespDetalle.p_SucursalId;
            return EjecutarComando(cmdModificar);
        }
        public int EliminarDespDetalle(string DespachoId)
        {
            return EjecutarComando("DELETE FROM dbo.tblDespDetalle WHERE DespachoId=" + DespachoId.ToString());
        }

        public int ModificarCantConfirmada(string DespachoId,string Item,decimal Cantidad,string Tipo)
        {
            string Cadena;
            if(Tipo =="PUSH")
                Cadena = "update dbo.tblDespDetalle set CantConfirmada=CantConfirmada+convert(decimal," + Cantidad + ") Where DespachoId='" + DespachoId + "' and ItemId='" + Item + "'";
            else
                Cadena = "update dbo.tblDespDetalle set CantConfirmada=CantConfirmada-convert(decimal," + Cantidad + ") Where DespachoId='" + DespachoId + "' and ItemId='" + Item + "'";
            return EjecutarComando(Cadena);
        }
        public DespDetalle TraerDespDetalle(string DespachoId,string item)
        {
            DataSet ds = this.Consultar("DespachoId='" + DespachoId + "' and ItemId='" + item + "'");
            DataTable tDespDetalle = ds.Tables[0];
            if (tDespDetalle.Rows.Count == 0)
            {
                return null;
            }
            DataRow rDespDetalle = tDespDetalle.Rows[0];
            DespDetalle oDespDetalle = new DespDetalle();
            oDespDetalle.p_DespachoId = DespachoId;
            oDespDetalle.p_ItemId = rDespDetalle["ItemId"].ToString();
            oDespDetalle.p_Cantidad = Convert.ToDecimal(rDespDetalle["Cantidad"]);
            oDespDetalle.p_SolPiezasSueltas = Convert.ToInt32(rDespDetalle["SolPiezasSueltas"]);
            oDespDetalle.p_ConfPiezasSueltas = Convert.ToInt32(rDespDetalle["ConfPiezasSueltas"]);
            oDespDetalle.p_CantConfirmada = Convert.ToInt32(rDespDetalle["CantConfirmada"]);
            oDespDetalle.p_Unidad = rDespDetalle["Unidad"].ToString();
            oDespDetalle.p_Unidad = rDespDetalle["Status"].ToString();
            oDespDetalle.p_Unidad = rDespDetalle["SucursalId"].ToString();
            return oDespDetalle;
        }

        public int MarcarEliminado(int docId, int Valor)
        {
            return EjecutarComando("UPDATE dbo.documentos set eliminado = " + Valor + " WHERE docId=" + docId.ToString());
        }
        public DataSet BuscarDespDetalle(string nombDocumento)
        {
            string cadena = "select docId,tituloDocumento,autor from documentos where tituloDocumento like '%" + nombDocumento + "%'";
            return EjecutarConsulta(cadena);
      
        }
        //EditarDespDetalle
        public int EditarCantDespDetalle(DespDetalle _despDet)
        {
            return EjecutarComando("UPDATE tblDespDetalle SET Cantidad = '" + _despDet.p_Cantidad + "' WHERE DespachoId = '" + _despDet.p_DespachoId + "' AND ItemId = '" + _despDet.p_ItemId + "'");
            //despDet.DespachoId, despDet.ItemId, despDet.Cantidad, despDet.SolPiezasSueltas, despDet.CantConfirmada, despDet.Unidad, despDet.Status, despDet.SucursalId
        }
        public int AgregarCantDespDetalle(DespDetalle _Detdesp)
        {
            return EjecutarComando("INSERT INTO tblDespDetalle ([DespachoId],[ItemId],[Cantidad],[SolPiezasSueltas],[ConfPiezasSueltas],[CantConfirmada],[Unidad],[Status],[SucursalId]) " +
                "VALUES ('" + _Detdesp.p_DespachoId + "', '" + _Detdesp.p_ItemId + "', " + _Detdesp.p_Cantidad + ", 0, 0, 0,' ',' '," + _Detdesp.p_SucursalId + ")");
        }
    }
}
