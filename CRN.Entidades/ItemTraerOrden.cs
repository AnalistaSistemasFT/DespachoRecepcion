using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRN.Entidades
{
    public class ItemTraerOrden
    {
        string ItemFId;
        string ItemId;
        string Descripcion;
        int Piezas;
        int Stock;
        decimal Peso;

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
        public int p_Piezas
        {
            get { return Piezas; }
            set { Piezas = value; }
        }
        public int p_Stock
        {
            get { return Stock; }
            set { Stock = value; }
        }
        public decimal p_Peso
        {
            get { return Peso; }
            set { Peso = value; }
        }
    }
}
