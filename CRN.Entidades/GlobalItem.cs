using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRN.Entidades
{
    public class GlobalItem
    {
        //ItemId | ItemFerro | Descripcion | Stock (Pzs) | Cantidad (Pzs) | Pzas/Paq | Paqs (Stnd) | Pzas (Sob) | Peso Paq | PesoPaqTotal
        private string G_ItemId = "";
        private string G_ItemFerro = "";
        private string G_Descripcion = "";
        private string G_UnidadMedida = "";
        private int G_Stock = 0;
        private int G_Cantidad = 0;
        private int G_PzaXpaq = 0;
        private int G_Paqs = 0;
        private int G_Pzas = 0;
        private decimal G_PesoPaq = 0;
        private decimal G_PesoPaqTotal = 0;

        public string ItemId
        {
            get { return G_ItemId; }
            set { G_ItemId = value; }
        }
        public string ItemFerro
        {
            get { return G_ItemFerro; }
            set { G_ItemFerro = value; }
        }
        public string Descripcion
        {
            get { return G_Descripcion; }
            set { G_Descripcion = value; }
        }
        public string UnidadMedida
        {
            get { return G_UnidadMedida; }
            set { G_UnidadMedida = value; }
        }
        public int StockPzs
        {
            get { return G_Stock; }
            set { G_Stock = value; }
        }
        public int CantidadPzs
        {
            get { return G_Cantidad; }
            set { G_Cantidad = value; }
        }
        public int PzasPaq
        {
            get { return G_PzaXpaq; }
            set { G_PzaXpaq = value; }
        }
        public int Paqs
        {
            get { return G_Paqs; }
            set { G_Paqs = value; }
        }
        public int PzasSob
        {
            get { return G_Pzas; }
            set { G_Pzas = value; }
        }
        public decimal PesoPaq
        {
            get { return G_PesoPaq; }
            set { G_PesoPaq = value; }
        }
        public decimal PesoPaqTotal
        {
            get { return G_PesoPaqTotal; }
            set { G_PesoPaqTotal = value; }
        }
    }
}
