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
    public class COrdenSync
    {
        CADOrdenSync cadOrdenSync;
        CADMovProducido cadMovProducido;
        CADMovConsumido cadMovConsumido;

        public COrdenSync()
        {
            cadOrdenSync = new CADOrdenSync();
            cadMovProducido = new CADMovProducido();
            cadMovConsumido = new CADMovConsumido();
        }

        public void GuardarOrdenSync(OrdenSync oOrdenSync)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                cadOrdenSync.GuardarOrdenSync(oOrdenSync);
                GuardarProducido(oOrdenSync);
                GuardarConsumido(oOrdenSync);
                ts.Complete();
            }
        }


		public void ModificarOrdenSync(OrdenSync oOrdenSync)
		{
			using (TransactionScope ts = new TransactionScope())
			{
				cadOrdenSync.ModificarOrdenSync(oOrdenSync);
				ts.Complete();
			}
		}


        public void EliminarOrdenSync(string vOrdenId)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                cadOrdenSync.EliminarOrdenSync(vOrdenId);
                ts.Complete();
            }
        }


		public DataSet TraerTodosOrdenSync()
		{
			return cadOrdenSync.TraerTodosOrdenSync();
		}
        public DataSet TraerTodosParaRevision(int sucursal)
        {
            return cadOrdenSync.TraerTodosParaRevision(sucursal);
        }

        public DataSet TraerTodosOrdenSync(string estado, int sucursal)
        {
            return cadOrdenSync.TraerTodosOrdenSync(estado,sucursal);
        }

		public OrdenSync TraerOrdenSync(string cod)
		{
            OrdenSync  oOrden = cadOrdenSync.TraerOrdenSync(cod);
            oOrden.MovConsumidoList  = cadMovConsumido.TraerListaMovConsumidos(cod);
            oOrden.MovProducidoList = cadMovProducido.TraerListaMovProducidos(cod);
            return oOrden;
		}

        public void GuardarProducido(OrdenSync oOrden)
        {
            foreach (MovProducido oMP in oOrden.MovProducidoList)
            {
                if (string.IsNullOrEmpty(oMP.AXCode))
                    throw new ArgumentNullException(oMP.AXCode + " AXCode");
                if (string.IsNullOrEmpty(oMP.AXUnitMeasure))
                    throw new ArgumentNullException(oMP.AXCode + " AXUnitMeasure");
                if (string.IsNullOrEmpty(oMP.Colada))
                    throw new ArgumentNullException("Producido:" + oMP.PAQUETEID + " Colada");
                if (string.IsNullOrEmpty(oMP.CENTRO_TRABAJO))
                    throw new ArgumentNullException("Centro Trabajo");
                //if (string.IsNullOrEmpty(oMovProducido.Item))
                //    throw new ArgumentNullException("Item PDV");
                if (string.IsNullOrEmpty(oMP.NRO_ORDEN))
                    throw new ArgumentNullException("Nro Orden");
                if (string.IsNullOrEmpty(oMP.PAQUETEID))
                    throw new ArgumentNullException("Producido:" + oMP.PAQUETEID + " PaqueteId");
                cadMovProducido.GuardarMovProducido(oMP);
            }

        }
        public void GuardarConsumido(OrdenSync oOrden)
        {
            foreach (MovConsumido oMC in oOrden.MovConsumidoList)
            {
                if (string.IsNullOrEmpty(oMC.AXCode))
                    throw new ArgumentNullException(oMC.AXCode+" AXCode");
                if (string.IsNullOrEmpty(oMC.AXUnitMeasure))
                    throw new ArgumentNullException(oMC.AXCode + " AXUnitMeasure");
                if (string.IsNullOrEmpty(oMC.AXTrackingType))
                    throw new ArgumentNullException(oMC.AXCode + " AXTrackingType");
                if (string.IsNullOrEmpty(oMC.Colada))
                    throw new ArgumentNullException("Consumido:"+oMC.PAQUETEID + " Colada");
                if (string.IsNullOrEmpty(oMC.CENTRO_TRABAJO))
                    throw new ArgumentNullException("Centro Trabajo");
                if (string.IsNullOrEmpty(oMC.Item))
                    throw new ArgumentNullException(oMC.AXCode + " Item PDV");
                if (string.IsNullOrEmpty(oMC.NRO_ORDEN))
                    throw new ArgumentNullException("Nro Orden");
                if (string.IsNullOrEmpty(oMC.PAQUETEID))
                    throw new ArgumentNullException("Consumido:"+oMC.AXCode + " PaqueteId");
                if (oMC.AXTrackingType == "SE-LO")
                {
                    if (string.IsNullOrEmpty(oMC.NumSerie))
                        throw new ArgumentNullException("NumSerie");
                }
                cadMovConsumido.GuardarMovConsumido(oMC);
            }

        }

        public decimal ObtenerDiametroOrden(string Orden)
        {
            return cadOrdenSync.ObtenerDiametroOrden(Orden);
        }

    }
}
