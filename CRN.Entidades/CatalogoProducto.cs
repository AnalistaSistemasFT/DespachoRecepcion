using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRN.Entidades
{
    public class CatalogoProducto
    {
        private int p_Id_producto;
        private string p_Nombre;
        private string p_Descripcion;

        public int Id_producto
        {
            get { return p_Id_producto; }
            set { p_Id_producto = value; }
        }
        public string Nombre
        {
            get { return p_Nombre; }
            set { p_Nombre = value; }
        }
        public string Descripcion
        {
            get { return p_Descripcion; }
            set { p_Descripcion = value; }
        }
    }
}
