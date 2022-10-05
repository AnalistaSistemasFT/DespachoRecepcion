using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRN.Entidades
{
    public class MovSyncDet
    {
        string p_OrdenId;
        string p_ItemPV;
        string p_ItemF;
        int p_Piezas;
        decimal p_Peso;
        decimal p_Metros;
        decimal p_CostoUnitario;
        decimal p_PrecioTon;
        string p_Calidad;
        decimal p_Cantidad;
        string p_Unidad; 
        int p_TipoMovimiento;
        decimal p_PorcDistribucion;

        public string OrdenId
        {
            get { return p_OrdenId; }
            set { p_OrdenId = value; }
        }
        public string ItemPV
        {
            get { return p_ItemPV; }
            set { p_ItemPV = value; }
        }
        public string ItemF
        {
            get { return p_ItemF; }
            set { p_ItemF = value; }
        }
        public int Piezas
        {
            get { return p_Piezas; }
            set { p_Piezas = value; }
        }
        public decimal Peso
        {
            get { return p_Peso; }
            set { p_Peso = value; }
        }
        public decimal Metros
        {
            get { return p_Metros; }
            set { p_Metros = value; }
        }
        public decimal CostoUnitario
        {
            get { return p_CostoUnitario; }
            set { p_CostoUnitario = value; }
        }
        public decimal PrecioTon
        {
            get { return p_PrecioTon; }
            set { p_PrecioTon = value; }
        }
        public string Calidad
        {
            get { return p_Calidad; }
            set { p_Calidad = value; }
        }
        public decimal Cantidad
        {
            get { return p_Cantidad; }
            set { p_Cantidad = value; }
        }
        public string Unidad
        {
            get { return p_Unidad; }
            set { p_Unidad = value; }
        }
        public int TipoMovimiento
        {
            get { return p_TipoMovimiento; }
            set { p_TipoMovimiento = value; }
        }
        public decimal PorcDistribucion
        {
            get { return p_PorcDistribucion; }
            set { p_PorcDistribucion = value; }
        }
    }
}
