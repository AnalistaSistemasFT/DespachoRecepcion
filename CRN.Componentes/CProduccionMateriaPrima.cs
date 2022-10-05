using CAD;
using CRN.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Transactions;

namespace CRN.Componentes
{
    public class CProduccionMateriaPrima
    {
        CADMateriaPrima mate = new CADMateriaPrima();
        public void guardarmateriaPrima(ProduccionDetalle materia)
        {
           using (TransactionScope ts = new TransactionScope())
           {
               mate.GuardarMateriaPrima(materia);
               ts.Complete();
           }
        }

        public DataSet traerDatos(string consulta) 
        {
            return mate.retornardata(consulta);        
        }

    }
}
