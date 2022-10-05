using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRN.Entidades
{
    public class Modulos
    {
        #region atributos
        int ModuloID;
        string Descripcion;
        int Aplicacion;
        
        #endregion

        #region Propiedades
        public int p_ModuloID
        {
            get { return ModuloID; }
            set { ModuloID = value; }
        }

        public string p_Descripcion
        {
            get { return Descripcion; }
            set { Descripcion = value; }
        }


        public int p_Aplicacion
        {
            get { return Aplicacion; }
            set { Aplicacion = value; }
        }
      

        #endregion
    }
}
