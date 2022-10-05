using CAD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CRN.Componentes
{
    public class Cscentrega
    {
        CADscentrega _cadscenrega = new CADscentrega();
        public DataSet TraerDetalleNotasEntrega(string idDespacho, int idSucursal)
        {
            return _cadscenrega.TraerDetalleNotasEntrega(idDespacho, idSucursal);
        }
    }
}
