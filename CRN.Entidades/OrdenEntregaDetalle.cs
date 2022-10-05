using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace CRN.Entidades
{
    public class OrdenEntregaDetalle
    {
        private int Id_orden_entrega_detalle;
        private string DespachoId;
        private string PaqueteId;
        private string ItemId;
        private int ItemFId;
        private int Cantidad;
        private decimal Peso;
        private string Estado;
        private string Obs;
        private DateTime Fecha;
        private int Id_orden_entrega;

        public int p_Id_orden_entrega_detalle
        {
            get { return Id_orden_entrega_detalle; }
            set { Id_orden_entrega_detalle = value; }
        }
        public string p_DespachoId
        {
            get { return DespachoId; }
            set { DespachoId = value; }
        }
        public string p_PaqueteId
        {
            get { return PaqueteId; }
            set { PaqueteId = value; }
        }
        public string p_ItemId
        {
            get { return ItemId; }
            set { ItemId = value; }
        }
        public int p_ItemFId
        {
            get { return ItemFId; }
            set { ItemFId = value; }
        }
        public int p_Cantidad
        {
            get { return Cantidad; }
            set { Cantidad = value; }
        } 
        public decimal p_Peso
        {
            get { return Peso; }
            set { Peso = value; }
        }
        public string p_Estado
        {
            get { return Estado; }
            set { Estado = value; }
        }
        public string p_Obs
        {
            get { return Obs; }
            set { Obs = value; } 
        }
        public DateTime p_Fecha
        {
            get { return Fecha; }
            set { Fecha = value; }
        }
        public int p_Id_orden_entrega
        {
            get { return Id_orden_entrega; }
            set { Id_orden_entrega = value; }
        }

        //InsertarDetalleOrden
        public int InsertarOrdenDetalle(DbTransaction trnproxy)
        {
            string sError = string.Empty;
            string sInsert = @"Insert into tblOrdenEntregaDetalle
                              ([DespachoId], [PaqueteId], [ItemId],[ItemFId], [Cantidad], [Peso], [Estado], [Obs], [Fecha], [Id_orden_entrega])
                              VALUES
                              ('{0}','{1}','{2}',{3},{4},{5},'{6}','{7}','{8}', {9})";
            sInsert = string.Format(sInsert, DespachoId, PaqueteId, ItemId, ItemFId, Cantidad, Peso, Estado, Obs, Fecha.ToString("dd/MM/yyyy"), Id_orden_entrega);
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
