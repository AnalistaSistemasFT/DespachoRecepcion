using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRN.Entidades
{
    public class PaqueteLecturado
    {
        private string ItemId;
        private string ItemFerro;
        private string Descripcion;
        private string PaqueteId;
        private int Piezas;
        private decimal Peso;
        private string Unidad;
        private int Retirar;
        private DateTime Fecha;

        public string p_ItemId
        {
            get { return ItemId; }
            set { ItemId = value; }
        }
        public string p_ItemFerro
        {
            get { return ItemFerro; }
            set { ItemFerro = value; }
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
        public string p_Unidad
        {
            get { return Unidad; }
            set { Unidad = value; }
        }
        public int p_Retirar
        {
            get { return Retirar; }
            set { Retirar = value; }
        }
        public DateTime p_Fecha
        {
            get { return Fecha; }
            set { Fecha = value; }
        }
    }
}
