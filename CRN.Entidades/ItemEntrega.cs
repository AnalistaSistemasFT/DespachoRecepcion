using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRN.Entidades
{
    public class ItemEntrega
    {
        private string ItemId;
        private int ItemFId;
        private string Descripcion;
        private string PaqueteId;
        private int Piezas;
        private decimal Peso;
        private string UnidadMedida;
        private decimal PesoTotal;
        private int Pendiente;
        private int Retirar;
        private decimal PesoRetirar;
        private string NombreDisplay;

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
        public string p_Descripcion
        {
            get { return Descripcion; }
            set { Descripcion = value; }
        }
        public string p_PaqueteId
        {
            get { return PaqueteId; }
            set { PaqueteId = value; }
        }
        public int p_Piezas
        {
            get { return Piezas; }
            set { Piezas = value; }
        }
        public decimal p_Peso
        {
            get { return Peso; }
            set { Peso = value; }
        }
        public string p_UnidadMedida
        {
            get { return UnidadMedida; }
            set { UnidadMedida = value; }
        }
        public decimal p_PesoTotal
        {
            get { return PesoTotal; }
            set { PesoTotal = value; }
        }
        public int p_Pendiente
        {
            get { return Pendiente; }
            set { Pendiente = value; }
        }
        public int p_Retirar
        {
            get { return Retirar; }
            set { Retirar = value; }
        }
        public decimal p_PesoRetirar
        {
            get { return PesoRetirar; }
            set { PesoRetirar = value; }
        }
        public string p_NombreDisplay
        {
            get { return NombreDisplay; }
            set { NombreDisplay = value; }
        }
    }
}
