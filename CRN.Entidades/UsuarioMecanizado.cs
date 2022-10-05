using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRN.Entidades
{
    public class UsuarioMecanizado
    {
        private int p_Id_usuario_mecanizado;
        private int p_Id_empleado;
        private string p_Login;
        private string p_Clave;
        private string p_Nombre;
        private int p_Id_grupo;

        public int Id_usuario_mecanizado
        {
            get { return p_Id_usuario_mecanizado; }
            set { p_Id_usuario_mecanizado = value; }
        }
        public int Id_empleado
        {
            get { return p_Id_empleado; }
            set { p_Id_empleado = value; }
        }
        public string Login
        {
            get { return p_Login; }
            set { p_Login = value; }
        }
        public string Clave
        {
            get { return p_Clave; }
            set { p_Clave = value; }
        }
        public string Nombre
        {
            get { return p_Nombre; }
            set { p_Nombre = value; }
        }
        public int Id_grupo
        {
            get { return p_Id_grupo; }
            set { p_Id_grupo = value; }
        }
    }
}
