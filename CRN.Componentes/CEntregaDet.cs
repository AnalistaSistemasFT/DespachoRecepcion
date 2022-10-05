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
	public class CEntregaDet
	{
		CADEntregaDet cadEntregaDet = new CADEntregaDet();

		public void GuardarEntregaDet(EntregaDet oEntregaDet)
		{
			using (TransactionScope ts = new TransactionScope())
			{
				cadEntregaDet.GuardarEntregaDet(oEntregaDet);
				 ts.Complete();
			}
		}
        public void ModificarEstadoEntregaDet(EntregaDet oEntregaDet)
		{
			using (TransactionScope ts = new TransactionScope())
			{
				cadEntregaDet.ModificarEstadoEntregaDet(oEntregaDet);
				ts.Complete();
			}
		}
        public void ActualizarEntregaDet(EntregaDet oEntregaDet)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                cadEntregaDet.ActualizarEntregaDet(oEntregaDet);
                ts.Complete();
            }
        }

		public void EliminarEntregaDet(string vId_Entrega)
		{
			using (TransactionScope ts = new TransactionScope())
			{
				cadEntregaDet.EliminarEntregaDet(vId_Entrega);
				ts.Complete();
			}
		}
        public DataSet TraerEntregaDet2(string EntregaId,string WHERE)
        {
            return cadEntregaDet.TraerEntregaDet2(EntregaId,WHERE);
        }

		public DataSet TraerTodosEntregaDet()
		{
			return cadEntregaDet.TraerTodosEntregaDet();
		}
        public EntregaDet TraerEntregaDet(string EntregaId,string PaqueteId)
        {
            return cadEntregaDet.TraerEntregatDet(EntregaId, PaqueteId);
        }
        public bool BuscarEntProduccion(string CodPaquete, string OrdenId)
        {
            return cadEntregaDet.BuscarEntProduccion(CodPaquete, OrdenId);
        }
        public EntregaDet Importar(string cod)
        {
            EntregaDet oEntDet = cadEntregaDet.Importar(cod);
            return oEntDet;
        }

	}
}
