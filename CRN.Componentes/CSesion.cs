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
    public static class CSesion
    {

        public static Usuario User;
        public static Sucursal sucursal;
        //static CSesion
        //{
        //    sucursal = new Sucursal();
        //    User = new Usuario();
        //}
       static CADSesion cadSesion;
        


        public static DateTime TraerGestion()
        {
            cadSesion = new CADSesion();
            DateTime c = cadSesion.TraerGestion();
            return c;
        }

    }
}
