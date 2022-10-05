using CAD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CRN.Componentes
{
    public  class CProduccionesCerradas
    {
        CADProduccionesCerradas cadCentroTrabajo = new CADProduccionesCerradas();

        public DataSet recojerdatos(string consulta) 
        {
            return cadCentroTrabajo.RetornarDatos(consulta);
        }

        public bool ejecutar(string consulta) 
        {
            int r = cadCentroTrabajo.EjecutarConsultaPlus(consulta);
            if (r == 1) 
            {
                return true;            
            }
            return false;
        }
    }
}
