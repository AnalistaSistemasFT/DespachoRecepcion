using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRN.Entidades
{
    public class MovDetalle
    {
        
        #region atributos
        string p_MovimientoId;
        string p_ItemId;
        decimal p_CantidadLiberada;
        decimal p_CantEnPaq;
        decimal p_Cantidad;
        decimal p_Costo;
        int p_SucursalId;
        string p_ItemF;
        string p_Unidad;
        decimal p_Peso;
        string p_Calidad;
        decimal p_Espesor;
        int p_Piezas;

        #endregion

        #region Propiedades
        public string MovimientoId
        {
            get { return p_MovimientoId; }
            set { p_MovimientoId = value; }
        }
        public string ItemId
        {
            get { return p_ItemId; }
            set { p_ItemId = value; }
        }
        public decimal CantidadLiberada
        {
            get { return p_CantidadLiberada; }
            set { p_CantidadLiberada = value; }
        }

        public decimal Costo
        {
            get { return p_Costo; }
            set { p_Costo = value; }
        }

        public decimal CantEnPaq
        {
            get { return p_CantEnPaq; }
            set { p_CantEnPaq = value; }
        }
        public decimal Cantidad
        {
            get { return p_Cantidad; }
            set { p_Cantidad = value; }
        }
        public int SucursalId
        {
            get { return p_SucursalId; }
            set { p_SucursalId = value; }
        }
        public string ItemF
        {
            get { return p_ItemF; }
            set { p_ItemF = value; }
        }
        public string Unidad
        {
            get { return p_Unidad; }
            set { p_Unidad = value; }
        }
        public decimal Peso
        {
            get { return p_Peso; }
            set { p_Peso = value; }
        }
        public string Calidad
        {
            get { return p_Calidad; }
            set { p_Calidad = value; }
        }
        public decimal Espesor
        {
            get { return p_Espesor; }
            set { p_Espesor = value; }
        }
        public int Piezas
        {
            get { return p_Piezas; }
            set { p_Piezas = value; }
        }



        //  public List<MovSyncDetalle> Detalle
    //{
    //    get { return this.detalle; }
    //}

        //Constructor: inicialización
    //public MovSync()
    //{
    //    this.detalle = new List<MovSyncDetalle>();
    //}   
        #endregion
    }
}
