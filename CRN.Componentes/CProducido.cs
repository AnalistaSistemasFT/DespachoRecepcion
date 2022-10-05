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
	public class CProducido
	{
		CADProducido cadProducido = new CADProducido();

        //public void GuardarProducido(Producido oProducido)
        //{
        //    using (TransactionScope ts = new TransactionScope())
        //    {
        //        cadProducido.GuardarProducido(oProducido);
        //        ts.Complete();
        //    }
        //}


        //public void ModificarProducido(Producido oProducido)
        //{
        //    using (TransactionScope ts = new TransactionScope())
        //    {
        //        cadProducido.ModificarProducido(oProducido);
        //        ts.Complete();
        //    }
        //}


        //public void EliminarProducido(Guid vFCF_ID)
        //{
        //    using (TransactionScope ts = new TransactionScope())
        //    {
        //        cadProducido.EliminarProducido(vFCF_ID);
        //        ts.Complete();
        //    }
        //}


		public DataSet TraerTodosProducido(string centro,string orden)
		{
			return cadProducido.TraerTodosProducido(centro,orden);
		}
        public DataSet TraerResumenProducido(string centro,string orden)
        {
            return cadProducido.TraerResumenProducido(centro,orden);
        }

		public Producido TraerProducido(string cod)
		{
			return cadProducido.TraerProducido(cod);
		}


	}
}
