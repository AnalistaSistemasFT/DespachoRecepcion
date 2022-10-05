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
    public class CUserSuc
    {
        CADUserSuc cadUserSuc = new CAD.CADUserSuc();

        public int GuardarUserSuc(UserSuc oUserSuc)
        {
            //if (byte.Refer(oArchivo.p_doc))
            //    throw new ArgumentNullException("Documento");
            //if (string.IsNullOrEmpty(oArchivo.p_nombre))
            //    throw new ArgumentNullException("Nombre del Archivo");
            //if (string.IsNullOrEmpty(oArchivo.p_extension))
            //    throw new ArgumentNullException("Extension");
            return cadUserSuc.GuardarUserSuc(oUserSuc);
        }

        public DataSet TraerSucursales()
        {
            return cadUserSuc.TraerSucursales();
        }
        public UserSuc TraerUserSuc(string login)
        {
            UserSuc oUserSuc = cadUserSuc.TraerUserSuc(login);
            return oUserSuc;
        }
        public DataSet MostrarSucursales(int EmpId)
        {
            return cadUserSuc.MostrarSucursales(EmpId);
        }
        //public bool Logueado(string Login, string Clave)
        //{
        //    {
        //        UserSuc oUserSuc = cadUsuario.TraerUsuario(Login);
        //        if (oUsuario.Clave == Clave)
        //        {
        //            CSesion.User = oUsuario;
        //            return true;
        //        }
        //        else
        //            return false;

        //    }
        //}

    }
}
