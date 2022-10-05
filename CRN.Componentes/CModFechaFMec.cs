using CAD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CRN.Componentes
{
    public class CModFechaFMec
    {
        CADModFechaFMec cadModFechaFinal = new CADModFechaFMec();
        public DataSet TraerFechasModificadas(int _IdServicio)
        {
            return cadModFechaFinal.TraerFechasModificadas(_IdServicio);
        }
    }
}
