using CAD;
using CRN.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CRN.Componentes
{
    public class CUsuarioMecanizado
    {
        CADUsuarioMecanizado cadUsuarioMecanizado = new CADUsuarioMecanizado();
        //UsuarioMecanizado _usuarioMecanizado;
        public DataSet TraerTodosUsuarios()
        {
            return cadUsuarioMecanizado.TraerTodosUsuarios();
        }
        public DataSet TraerDatosUsuario(string _login)
        {
            return cadUsuarioMecanizado.TraerDatosUsuario(_login);
        }
        public DataSet TraerOperarios()
        {
            return cadUsuarioMecanizado.TraerOperarios();
        }
        public int GuardarUsuarioDir()
        {
            return cadUsuarioMecanizado.GuardarUsuarioDir();
        }
        public int GuardarUsuario(UsuarioMecanizado _usuarioMecanizado)
        {
            return cadUsuarioMecanizado.GuardarUsuario(_usuarioMecanizado);
        }
    }
}
