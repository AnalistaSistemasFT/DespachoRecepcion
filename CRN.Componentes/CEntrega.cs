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
	public class CEntrega
	{
		CADEntrega cadEntrega = new CADEntrega();

		public void GuardarEntrega(Entrega oEntrega)
		{
			using (TransactionScope ts = new TransactionScope())
			{
				cadEntrega.GuardarEntrega(oEntrega);
				ts.Complete();
			}
		}


		public void ModificarEntrega(Entrega oEntrega)
		{
			using (TransactionScope ts = new TransactionScope())
			{
				cadEntrega.ModificarEntrega(oEntrega);
				ts.Complete();
			}
		}


        public void EliminarEntrega(string v)
		{
			using (TransactionScope ts = new TransactionScope())
			{
				cadEntrega.EliminarEntrega(v);
				ts.Complete();
			}
		}


		public DataSet TraerTodosEntrega()
		{
			return cadEntrega.TraerTodosEntrega();
		}

        public DataSet TraerSolicitudesUsuario(int Id,string estado)
        {
            return cadEntrega.TraerOrdenesUsuario(Id,estado);
        }
        public void CambiarEstadoOrdenesUsuario(string id,string estado)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                cadEntrega.CambiarEstadoOrdenesUsuario(id,estado);
                ts.Complete();
            }
        }
        public int ContarEstado(string id, string estado)
        {
              return cadEntrega.ContarEstado(id, estado);
    
    
        }
        //public Entrega TraerEntrega(int cod)
        //{
        //    return cadEntrega.TraerEntrega(cod);
        //}

        //public bool BuscarEntProduccion(string CodPaquete, string CodDespacho)
        //{
        //    return cadEntrega.(CodPaquete, CodDespacho);
        //}


	}
}
