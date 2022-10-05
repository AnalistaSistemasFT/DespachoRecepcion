using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRN.Entidades
{
    public class DespProgCelda
    {
        private string DespachoId;
        private string ItemId;
        private string CeldaId;
        private int Piezas;
        private int Paquetes;
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
        public string p_CeldaId
        {
            get { return CeldaId; }
            set { CeldaId = value; }
        }
        public int p_Piezas
        {
            get { return Piezas; }
            set { Piezas = value; }
        }
        public int p_Paquetes
        {
            get { return Paquetes; }
            set { Paquetes = value; }
        }
        public int p_SucursalId
        {
            get { return SucursalId; }
            set { SucursalId = value; }
        }
    }
}
