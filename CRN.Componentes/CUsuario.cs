using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Transactions;

using CRN.Entidades;
using CAD;

namespace CRN.Componentes
{
    public class CUsuario
    {
        CADUsuario cadUsuario = new CAD.CADUsuario();
        Usuario oUsuario;
         

         public int GuardarUsuario(Usuario oUsuario)
         {
             //if (byte.Refer(oArchivo.p_doc))
             //    throw new ArgumentNullException("Documento");
             //if (string.IsNullOrEmpty(oArchivo.p_nombre))
             //    throw new ArgumentNullException("Nombre del Archivo");
             //if (string.IsNullOrEmpty(oArchivo.p_extension))
             //    throw new ArgumentNullException("Extension");
             return cadUsuario.GuardarUsuario(oUsuario);
         }
         public bool Logueado(string Login, string Clave)
         {
             oUsuario = cadUsuario.TraerUsuario(Login);
             if (oUsuario != null)
             {
                 if (oUsuario.Clave == Clave)
                 {
                     Sesion.User = oUsuario;
                     return true;
                 }
                 else
                     return false;
             }
             else
                 return false;
         }
         public DataSet TraerConexion(int id)
         {
             return cadUsuario.TraerConexion(id);
         }
         public bool LogueadoEnAlmacen(int Id)
         {
             return cadUsuario.LogueadoEnAlmacen(Id);
         }
         public DataSet DataUsuario(string u) 
         {
             return cadUsuario.TraerDatosUsuario(u);
         }
        public DataSet DataSucursalxUsuario(string u)
        {
            return cadUsuario.TraerSucursalPorUsuario(u);
        }
        public DataSet DataAlmacenxUsuario(int u)
        {
            return cadUsuario.TraerAlmacenPorUsuario(u);
        }
    }
}
