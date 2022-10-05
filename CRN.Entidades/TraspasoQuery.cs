using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRN.Entidades
{
    public class TraspasoQuery
    {
        private string ItemFId;
        private string ItemId;
        private string Descripcion;
        private int Cantidad;
        private decimal Peso;

        public string p_ItemFId
        {
            get { return ItemFId; }
            set { ItemFId = value; }
        }
        public string p_ItemId
        {
            get { return ItemId; }
            set { ItemId = value; }
        }
        public string p_Descripcion
        {
            get { return Descripcion; }
            set { Descripcion = value; }
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
    }
}
