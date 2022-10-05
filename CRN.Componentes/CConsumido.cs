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
	public class CConsumido
	{
		CADConsumido cadConsumido = new CADConsumido();

        //public void GuardarConsumido(Consumido oConsumido)
        //{
        //    using (TransactionScope ts = new TransactionScope())
        //    {
        //        cadConsumido.GuardarConsumido(oConsumido);
        //        ts.Complete();
        //    }
        //}


        //public void ModificarConsumido(Consumido oConsumido)
        //{
        //    using (TransactionScope ts = new TransactionScope())
        //    {
        //        cadConsumido.ModificarConsumido(oConsumido);
        //        ts.Complete();
        //    }
        //}


        //public void EliminarConsumido(int vFCS_ID)
        //{
        //    using (TransactionScope ts = new TransactionScope())
        //    {
        //        cadConsumido.EliminarConsumido(vFCS_ID);
        //        ts.Complete();
        //    }
        //}


		public DataSet TraerTodosConsumido()
		{
			return cadConsumido.TraerTodosConsumido();
		}
        
        public DataSet TraerTodosConsumido(string centro,string orden)
        {
            return cadConsumido.TraerTodosConsumido(centro,orden);
        }
        public DataSet TraerResumenConsumido(string centro,string orden)
        {
            return cadConsumido.TraerResumenConsumido(centro,orden);
        }

		public Consumido TraerConsumido(string cod)
		{
			return cadConsumido.TraerConsumido(cod);
		}


	}
}
