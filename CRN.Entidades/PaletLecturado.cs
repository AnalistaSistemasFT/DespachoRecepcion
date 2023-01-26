using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRN.Entidades
{
    public class PaletLecturado
    {
        private string ItemId;
        private string ItemFerro;
        private string Descripcion;
        private string PaqueteId;
        private DateTime FechaV;
        private int Piezas;
        private decimal Peso;
        private string Lote;

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
        public DateTime p_FechaV
        {
            get { return FechaV; }
            set { FechaV = value; }
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
        public string p_Lote
        {
            get { return Lote; }
            set { Lote = value; }
        }
    }
}
