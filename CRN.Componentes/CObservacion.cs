using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Transactions;
using CRN.Entidades;
using CAD;

namespace CRN.Componentes
{
	public class CObservacion
	{
		CADObservacion cadObservacion = new CADObservacion();

		public void GuardarObservacion(Observacion oObservacion)
		{
			using (TransactionScope ts = new TransactionScope())
			{
				cadObservacion.GuardarObservacion(oObservacion);
				ts.Complete();
			}
		}


		public void ModificarObservacion(Observacion oObservacion)
		{
			using (TransactionScope ts = new TransactionScope())
			{
				cadObservacion.ModificaroObservacion(oObservacion);
				ts.Complete();
			}
		}


		public void EliminarObservacion(string v)
		{
			using (TransactionScope ts = new TransactionScope())
			{
				cadObservacion.EliminarObservacion(v);
				ts.Complete();
			}
		}
        public Observacion TraerObservacion(int Obs)
        {
            Observacion oObs = cadObservacion.TraerObservacion(Obs);
            return oObs;
        }

		public DataSet TraerTodosObservacion()
		{
			return cadObservacion.TraerTodosObservacion();
		}


		


	}
}
