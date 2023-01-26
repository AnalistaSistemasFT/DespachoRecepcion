using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRN.Entidades
{
    public class Palet
    {

        private string PaletId;
        private string ItemId;
        private int ItemFerro;
        private int SucursalId;
        private int Cantidad_Paqs;
        private decimal Peso_Paqs;
        private string Estado;

        public string p_PaletId
        {
            get { return PaletId; }
            set { PaletId = value; }
        }
        public string p_ItemId
        {
            get { return ItemId; }
            set { ItemId = value; }
        }
        public int p_ItemFerro
        {
            get { return ItemFerro; }
            set { ItemFerro = value; }
        } 
        public int p_SucursalId
        {
            get { return SucursalId; }
            set { SucursalId = value; }
        }
        public int p_Cantidad_Paqs
        {
            get { return Cantidad_Paqs; }
            set { Cantidad_Paqs = value; }
        }
        public decimal p_Peso_Paqs
        {
            get { return Peso_Paqs; }
            set { Peso_Paqs = value; }
        }
        public string p_Estado
        {
            get { return Estado; }
            set { Estado = value; }
        }
    }
}
