using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRN.Entidades
{
    public class EmpleadoUser
    {
        private int p_Id_user;
        private int p_Id_empleado;
        private string p_Nombre;

        public int Id_user
        {
            get { return p_Id_user; }
            set { p_Id_user = value; }
        }
        public int Id_empleado
        {
            get { return p_Id_empleado; }
            set { p_Id_empleado = value; }
        }
        public string Nombre
        {
            get { return p_Nombre; }
            set { p_Nombre = value; }
        }
    }
}
