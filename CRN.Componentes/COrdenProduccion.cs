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
    public class COrdenProduccion
    {
        CADOrdenProduccion catTabla = new CADOrdenProduccion();
        public DataSet retornarTabla(string sConsulta)
        {
            return catTabla.RetornarOrdenP(sConsulta);
        }
        public DataSet retornarPaqueterPorOrden(string sOrden)
        {
            return catTabla.RetornarPaquetesPorOrden(sOrden);
        }
        public DataSet retornarEnsayos(string sOrden)

        {
            return catTabla.RetornarEnsayos(sOrden);
        }

        public void GuardarTablaNuevo(OrdenProduccion opp)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                catTabla.GuardarOrdenProduccion(opp);
                ts.Complete();
            }
        }
        public void Modificar(string id,int estado,DateTime festado) 
        {
            using (TransactionScope ts = new TransactionScope())
            {
                catTabla.ModificarOrdenOperacion(id,estado,festado);
                ts.Complete();
            }
        
        }

       

    }
}
