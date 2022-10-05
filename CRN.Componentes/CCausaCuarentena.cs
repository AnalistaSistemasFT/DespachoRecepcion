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
	public class CCausaCuarentena
	{
		CADCausaCuarentena cadCausaCuarentena = new CADCausaCuarentena();

		public void GuardarCausaCuarentena(CausaCuarentena oCausaCuarentena)
		{
			using (TransactionScope ts = new TransactionScope())
			{
				cadCausaCuarentena.GuardarCausaCuarentena(oCausaCuarentena);
				ts.Complete();
			}
		}


		public void ModificarCausaCuarentena(CausaCuarentena oCausaCuarentena)
		{
			using (TransactionScope ts = new TransactionScope())
			{
				cadCausaCuarentena.ModificarCausaCuarentena(oCausaCuarentena);
				ts.Complete();
			}
		}


		public void EliminarCausaCuarentena(int vId_Causa)
		{
			using (TransactionScope ts = new TransactionScope())
			{
				cadCausaCuarentena.EliminarCausaCuarentena(vId_Causa);
				ts.Complete();
			}
		}


		public DataSet TraerTodosCausaCuarentena()
		{
			return cadCausaCuarentena.TraerTodosCausaCuarentena();
		}


		public CausaCuarentena TraerCausaCuarentena(int cod)
		{
			return cadCausaCuarentena.TraerCausaCuarentena(cod);
		}
        public DataSet CargarCausaCuarentena()
        {
            return cadCausaCuarentena.CargarCausaCuarentena();
        }

	}
}
