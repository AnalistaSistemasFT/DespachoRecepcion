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
	public class CRecepcion: oledb
	{
		public CRecepcion()
		{
			this.sConnName = "SQLSERVER";
		}

		CADRecepcion cadRecepcion = new CADRecepcion();

		public void GuardarRecepcion(Recepcion oRecepcion)
		{
			using (TransactionScope ts = new TransactionScope())
			{
				cadRecepcion.GuardarRecepcion(oRecepcion);
				ts.Complete();
			}
		}
       

		public void ModificarRecepcion1(Recepcion oRecepcion)
		{
			using (TransactionScope ts = new TransactionScope())
			{
				cadRecepcion.ModificarRecepcion(oRecepcion);
				ts.Complete();
			}
		}


		public void EliminarRecepcion(string vRecepcionId)
		{
			using (TransactionScope ts = new TransactionScope())
			{
				cadRecepcion.EliminarRecepcion(vRecepcionId);
				ts.Complete();
			}
		}


		public DataSet TraerTodosRecepcion()
		{
			return cadRecepcion.TraerTodosRecepcion();
		}
		public DataSet TraerDetalleAnotacion(string sAnotacion)
		{
			return cadRecepcion.TraerDetalleAnotacion(sAnotacion);
		}




		public Recepcion TraerRecepcion(string vRecepcionId)
		{
            return cadRecepcion.TraerRecepcion(vRecepcionId);
		}

        public DataSet TraerTodosRecepcion(string estado, int sucursal)
        {
            return cadRecepcion.TraerTodosRecepcion(estado, sucursal);
        }
		public DataSet TraerDespachos(string estado, int sucursal)
		{
			return cadRecepcion.TraerOrdenDeCarga(estado, sucursal);
		}
		public DataSet TraerCC(string estado, int sucursal)
		{
			return cadRecepcion.TraerTodosCC(estado, sucursal);
		}

		public DataSet TraerRecepcionDet(string Despacho)
		{
			return cadRecepcion.TraerRecepcionDet(Despacho);
		}
		public DataSet TraerDespachoDet(string Despacho)
		{
			return cadRecepcion.TraerDespachoDet(Despacho);
		}
		public DataSet TraerOrdenCargaDetalle(int Orden)
		{
			return cadRecepcion.TraerOrdenCargaDet(Orden);
		}

		public DataSet TraerDespachoDetProd(string recepcion)
		{
			return cadRecepcion.TraerDespachoDetProd(recepcion);
		}
		public DataSet TraerOrdenDetProd(int Orden, int i)
		{
			if(i == 0)
			return cadRecepcion.TraerOrdenDetProd(Orden);
			else
				return cadRecepcion.TraerOrdenDetProd1(Orden);
		}

		public DataSet TraerRecepcionDet(string recepcion,string fuente)
		{
			return cadRecepcion.TraerRecepcionDetProd1(recepcion,fuente);
		}

		

	}
}
