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
	public class CTipoCambio
	{
		CADTipoCambio cadTipoCambio = new CADTipoCambio();

		public void GuardarTipoCambio(TipoCambio oTipoCambio)
		{
			using (TransactionScope ts = new TransactionScope())
			{
				cadTipoCambio.GuardarTipoCambio(oTipoCambio);
				ts.Complete();
			}
		}


		public void ModificarTipoCambio(TipoCambio oTipoCambio)
		{
			using (TransactionScope ts = new TransactionScope())
			{
				cadTipoCambio.ModificarTipoCambio(oTipoCambio);
				ts.Complete();
			}
		}


		public void EliminarTipoCambio(DateTime vFecha)
		{
			using (TransactionScope ts = new TransactionScope())
			{
				cadTipoCambio.EliminarTipoCambio(vFecha);
				ts.Complete();
			}
		}


		public DataSet TraerTodosTipoCambio()
		{
			return cadTipoCambio.TraerTodosTipoCambio();
		}


		public TipoCambio TraerTipoCambio(DateTime cod)
		{
			return cadTipoCambio.TraerTipoCambio(cod);
		}


	}
}
