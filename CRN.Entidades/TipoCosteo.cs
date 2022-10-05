using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRN.Entidades
{
    public class TipoCosteo
    {
        #region atributos
        int p_IdTipo;
        string p_Descripcion;

        #endregion

        #region Propiedades
        public int IdTipo
        {
            get { return p_IdTipo; }
            set { p_IdTipo = value; }
        }
        public string Descripcion
        {
            get { return p_Descripcion; }
            set { p_Descripcion = value; }
        }
        
        #endregion  
    }
}
