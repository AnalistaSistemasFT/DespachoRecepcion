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
	public class CProducto
	{
		CADProducto cadProducto = new CADProducto();

		public DataSet TraerTodosProducto()
		{
			return cadProducto.TraerTodosProducto();
		}


		public Producto TraerProducto(string cod)
		{
			return cadProducto.TraerProducto(cod);
		}


	}
}
