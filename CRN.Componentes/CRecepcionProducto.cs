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
	public class CRecepcionProducto
	{
		CADRecepcionProducto cadRecepcionProducto = new CADRecepcionProducto();

		public void GuardarRecepcionProducto(RecepcionProducto oRecepcionProducto)
		{
			using (TransactionScope ts = new TransactionScope())
			{
				cadRecepcionProducto.GuardarRecepcionProducto(oRecepcionProducto);
				ts.Complete();
			}
		}


		public void ModificarRecepcionProducto(RecepcionProducto oRecepcionProducto)
		{
			using (TransactionScope ts = new TransactionScope())
			{
				cadRecepcionProducto.ModificarRecepcionProducto(oRecepcionProducto);
				ts.Complete();
			}
		}


		public void EliminarRecepcionProducto(string ProductoId,string RecepcionId)
		{
			using (TransactionScope ts = new TransactionScope())
			{
				cadRecepcionProducto.EliminarRecepcionProducto(ProductoId,RecepcionId);
				ts.Complete();
			}
		}

        public DataSet ObtenerEtiqueta(string id)
        {
            return cadRecepcionProducto.ObtenerEtiqueta(id);
        }

		public DataSet TraerTodosRecepcionProducto()
		{
			return cadRecepcionProducto.TraerTodosRecepcionProducto();
		}
        public DataSet TraerTodoRecepcionProducto(string Recepcion)
        {
            return cadRecepcionProducto.TraerTodoRecepcionProducto(Recepcion);
        }

        public RecepcionProducto TraerRecepcionProducto(string ProductoId)
		{
            return cadRecepcionProducto.TraerRecepcionProducto(ProductoId);
		}
        
	}
}
