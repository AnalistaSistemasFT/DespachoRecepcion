using CAD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CRN.Componentes
{
    public class CSincronizacion
    {
        CADSincronizacion sincro=new CADSincronizacion();

        public DataSet recojerdatos(string consulta)
        {
            return sincro.Retornardatos(consulta);
        }

        



    }
}
