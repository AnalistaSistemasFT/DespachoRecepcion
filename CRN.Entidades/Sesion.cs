using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRN.Entidades
{
    public class Sesion
    {
        #region Atributos
        Sucursal p_Sucursal;
        Usuario p_Usuario;
        
        public static Usuario User;
        public static Sucursal Sucursal;
        //public static 
        public static string Conexion;
        #endregion
        #region Propiedades
        //public Sucursal Sucursal
        //{
        //    get { return p_Sucursal; }
        //    set { p_Sucursal = value; }
        //}
        
        public Usuario Usuario
        {
            get { return p_Usuario;}
            set { p_Usuario = value;}
        }
        #endregion
    }
}
