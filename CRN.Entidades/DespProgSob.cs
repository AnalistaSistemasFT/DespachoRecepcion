using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRN.Entidades
{
    public class DespProgSob
    {
        private string DespachoId;
        private string ItemId;
        private string PaqueteId;
        private string CeldaId;
        private decimal Piezas;
        private int SucursalId;

        public string p_DespachoId
        {
            get { return DespachoId; }
            set { DespachoId = value; }
        }
        public string p_ItemId
        {
            get { return ItemId; }
            set { ItemId = value; }
        }
        public string p_PaqueteId
        {
            get { return PaqueteId; }
            set { PaqueteId = value; }
        }
        public string p_CeldaId
        {
            get { return CeldaId; }
            set { CeldaId = value; }
        }
        public decimal p_Piezas
        {
            get { return Piezas; }
            set { Piezas = value; }
        }
        public int p_SucursalId
        {
            get { return SucursalId; }
            set { SucursalId = value; }
        }
    }
}
