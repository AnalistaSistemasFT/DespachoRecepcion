using CAD;
using CRN.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRN.Componentes
{
    public class CEntregaMecanizado
    {
        CADEntregaMecanizado cadEntregaMecanizado = new CADEntregaMecanizado();
        public int GuardarEntrega(EntregaMecanizado _entregaMecanizado)
        {
            return cadEntregaMecanizado.GuardarEntrega(_entregaMecanizado);
        }
    }
}
