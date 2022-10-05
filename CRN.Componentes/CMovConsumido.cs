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
	public class CMovConsumido
	{
        CADMovConsumido cadMovConsumido;
        public CMovConsumido ()
        {
            cadMovConsumido = new CADMovConsumido();
        }
		public void GuardarMovConsumido(MovConsumido oMovConsumido)
		{
            if (string.IsNullOrEmpty(oMovConsumido.AXCode))
                throw new ArgumentNullException("AXCode");
            if (string.IsNullOrEmpty(oMovConsumido.AXUnitMeasure))
                throw new ArgumentNullException("AXUnitMeasure");
            if (string.IsNullOrEmpty(oMovConsumido.AXTrackingType))
                throw new ArgumentNullException("AXTrackingType");
            if (string.IsNullOrEmpty(oMovConsumido.Colada))
                throw new ArgumentNullException("Colada");
            if (string.IsNullOrEmpty(oMovConsumido.CENTRO_TRABAJO))
                throw new ArgumentNullException("Cntro Trabajo");
            if (string.IsNullOrEmpty(oMovConsumido.Item))
                throw new ArgumentNullException("Item PDV");
            if (string.IsNullOrEmpty(oMovConsumido.NRO_ORDEN))
                throw new ArgumentNullException("Nro Orden");
            if (string.IsNullOrEmpty(oMovConsumido.PAQUETEID ))
                throw new ArgumentNullException("PaqueteId");
            if (oMovConsumido.AXTrackingType=="SE-LO")
            {
                if (string.IsNullOrEmpty(oMovConsumido.NumSerie))
                    throw new ArgumentNullException("NumSerie");
            }
            using (TransactionScope ts = new TransactionScope())
			{
				cadMovConsumido.GuardarMovConsumido(oMovConsumido);
				ts.Complete();
			}
		}


		public void ModificarMovConsumido(MovConsumido oMovConsumido)
		{
			using (TransactionScope ts = new TransactionScope())
			{
				cadMovConsumido.ModificarMovConsumido(oMovConsumido);
				ts.Complete();
			}
		}


		public void EliminarMovConsumido(string vFCS_ID)
		{
			using (TransactionScope ts = new TransactionScope())
			{
				cadMovConsumido.EliminarMovConsumido(vFCS_ID);
				ts.Complete();
			}
		}


		public DataSet TraerTodosMovConsumido()
		{
			return cadMovConsumido.TraerTodosMovConsumido();
		}

        public DataSet TraerTodosMovConsumido(string centro,string orden)
        {
            return cadMovConsumido.TraerTodosMovConsumido(centro,orden);
        }


        public MovConsumido TraerMovConsumido(string cod)
		{
			return cadMovConsumido.TraerMovConsumido(cod);
		}


	}
}
