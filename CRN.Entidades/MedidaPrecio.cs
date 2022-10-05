using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRN.Entidades
{
    public class MedidaPrecio
    {
        #region atributos
        string p_CentroId;
        decimal  p_Medida;
        decimal p_PrecioTon;

        #endregion

        #region Propiedades
        public string CentroId
        {
            get { return p_CentroId; }
            set { p_CentroId = value; }
        }
        public decimal Medida
        {
            get { return p_Medida; }
            set { p_Medida = value; }
        }
        public decimal PrecioTon
        {
            get { return p_PrecioTon; }
            set { p_PrecioTon = value; }
        }

        #endregion  
    }
}
