using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRN.Entidades
{
     public class DespProductos
    {
        #region atributos
        string p_DespachoId;
        string p_ProductoId;
        string p_ItemId;
        DateTime p_Fecha;
        string p_Status;
        decimal p_Cantidad;
        decimal p_Peso;
        string p_CeldaId;
        int p_SucursalId;
        string p_ItemFId;
        int p_Piezas;
        decimal p_Metros;
        string p_Colada;

        #endregion

        #region Propiedades
        public string DespachoId
        {
            get { return p_DespachoId; }
            set { p_DespachoId = value; }
        }
        public string ProductoId
        {
            get { return p_ProductoId; }
            set { p_ProductoId = value; }
        }

        public string ItemId
        {
            get { return p_ItemId; }
            set { p_ItemId = value; }
        }
        public DateTime Fecha
        {
            get { return p_Fecha; }
            set { p_Fecha = value; }
        }
        public string Status
        {
            get { return p_Status; }
            set { p_Status = value; }
        }
        public decimal Cantidad
        {
            get { return p_Cantidad; }
            set { p_Cantidad = value; }
        }
        public decimal Peso
        {
            get { return p_Peso; }
            set { p_Peso = value; }
        }
        public string CeldaId
        {
            get { return p_CeldaId; }
            set { p_CeldaId = value; }
        }
        
        public int SucursalId
        {
            get { return p_SucursalId; }
            set { p_SucursalId = value; }
        }
        public string ItemFId
        {
            get { return p_ItemFId; }
            set { p_ItemFId = value; }
        }
        public int Piezas
        {
            get { return p_Piezas; }
            set { p_Piezas = value; }
        }
        public decimal Metros
        {
            get { return p_Metros; }
            set { p_Metros = value; }
        }
        public string Colada
        {
            get { return p_Colada; }
            set { p_Colada = value; }
          
        }
        #endregion  
    }
}
