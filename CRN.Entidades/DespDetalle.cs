using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace CRN.Entidades
{
    public class DespDetalle
    {
        #region atributos
        private string DespachoId;
        private string ItemId;
        private decimal Cantidad;
        private int SolPiezasSueltas;
        private int ConfPiezasSueltas;
        private decimal CantConfirmada;
        private string Unidad;
        private string Status;
        private int SucursalId;


        #endregion

        #region Propiedades
        public string p_DespachoId
        {
            get { return DespachoId; }
            set { DespachoId = value; }
        }
        public string p_ItemId
        {
            get { return ItemId; }
            set { ItemId = value; }
        }
        public decimal p_Cantidad
        {
            get { return Cantidad; }
            set { Cantidad = value; }
        }
        public int p_SolPiezasSueltas
        {
            get { return SolPiezasSueltas; }
            set { SolPiezasSueltas = value; }
        }
        public int p_ConfPiezasSueltas
        {
            get { return ConfPiezasSueltas; }
            set { ConfPiezasSueltas = value; }
        }
        public decimal p_CantConfirmada
        {
            get { return CantConfirmada; }
            set { CantConfirmada = value; }
        }
        public string p_Unidad
        {
            get { return Unidad; }
            set { Unidad = value; }
        }
        public string p_Status
        {
            get { return Status; }
            set { Status = value; }
        }
        public int p_SucursalId
        {
            get { return SucursalId; }
            set { SucursalId = value; }
        }
        #endregion
        //InsertarDespDetalle
        public int InsertarDespDetalle(DbTransaction trnproxy)
        {
            string sError = string.Empty;
            string sInsert = @"Insert into tblDespDetalle
                              ([DespachoId], [ItemId], [Cantidad],[SolPiezasSueltas], [ConfPiezasSueltas], [CantConfirmada], [Unidad], [Status], [SucursalId])
                              VALUES
                              ('{0}','{1}',{2} ,{3},{4},{5},'{6}','{7}',{8})";
            sInsert = string.Format(sInsert, DespachoId, ItemId, Cantidad, SolPiezasSueltas, ConfPiezasSueltas, CantConfirmada, Unidad, Status, SucursalId);
            return ejecutar(ref sError, sInsert, trnproxy);
        }
        protected int ejecutar(ref string er, string csql, System.Data.Common.DbTransaction obtransaccion)
        {
            try
            {
                System.Data.Common.DbCommand comando = obtransaccion.Connection.CreateCommand();
                comando.CommandText = csql;
                comando.Transaction = obtransaccion;
                return comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                er = ex.Message;
                return 0;
            }
        }
    }
}
