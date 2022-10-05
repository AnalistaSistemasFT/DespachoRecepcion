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
	public class CBatches
	{
		CADBatches cadBatches = new CADBatches();

		public void GuardarBatches(Batches oBatches)
		{
			using (TransactionScope ts = new TransactionScope())
			{
				cadBatches.GuardarBatches(oBatches);
				ts.Complete();
			}
		}


		public void ModificarBatches(Batches oBatches)
		{
			using (TransactionScope ts = new TransactionScope())
			{
				cadBatches.ModificarBatches(oBatches);
				ts.Complete();
			}
		}


		public void EliminarBatches(string vFBC_BATCH)
		{
			using (TransactionScope ts = new TransactionScope())
			{
				cadBatches.EliminarBatches(vFBC_BATCH);
				ts.Complete();
			}
		}


		public DataSet TraerTodosBatches()
		{
			return cadBatches.TraerTodosBatches();
		}


		public Batches TraerBatches(int cod)
		{
			return cadBatches.TraerBatches(cod);
		}


	}
}
