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
	public class CMovProducido
	{
		CADMovProducido cadMovProducido;
        public CMovProducido ()
        {
            cadMovProducido = new CADMovProducido();
        }

		public void GuardarMovProducido(MovProducido oMovProducido)
		{
            if (string.IsNullOrEmpty(oMovProducido.AXCode))
                throw new ArgumentNullException("AXCode");
            if (string.IsNullOrEmpty(oMovProducido.AXUnitMeasure))
                throw new ArgumentNullException("AXUnitMeasure");
            if (string.IsNullOrEmpty(oMovProducido.Colada))
                throw new ArgumentNullException("Colada");
            if (string.IsNullOrEmpty(oMovProducido.CENTRO_TRABAJO))
                throw new ArgumentNullException("Cntro Trabajo");
            //if (string.IsNullOrEmpty(oMovProducido.Item))
            //    throw new ArgumentNullException("Item PDV");
            if (string.IsNullOrEmpty(oMovProducido.NRO_ORDEN))
                throw new ArgumentNullException("Nro Orden");
            if (string.IsNullOrEmpty(oMovProducido.PAQUETEID))
                throw new ArgumentNullException("PaqueteId");
            using (TransactionScope ts = new TransactionScope())
			{
				cadMovProducido.GuardarMovProducido(oMovProducido);
				ts.Complete();
			}
		}


		public void ModificarMovProducido(MovProducido oMovProducido)
		{
			using (TransactionScope ts = new TransactionScope())
			{
				cadMovProducido.ModificarMovProducido(oMovProducido);
				ts.Complete();
			}
		}


		public void EliminarMovProducido(string vPAQUETEID)
		{
			using (TransactionScope ts = new TransactionScope())
			{
				cadMovProducido.EliminarMovProducido(vPAQUETEID);
				ts.Complete();
			}
		}


		public DataSet TraerTodosMovProducido()
		{
			return cadMovProducido.TraerTodosMovProducido();
		}

        public DataSet TraerTodosMovProducido(string orden)
        {
            return cadMovProducido.TraerTodosMovProducido(orden);
        }


        public DataSet TraerTodosMovProducido(string centro, string orden)
        {
            return cadMovProducido.TraerTodosMovProducido(centro, orden);
        }


        public MovProducido TraerMovProducido(string cod)
		{
			return cadMovProducido.TraerMovProducido(cod);
		}


	}
}
