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
	public class CPackingList
	{
		CADPackingList cadPacking = new CADPackingList();

	


		public DataSet ListaPackinglist()
		{
			return cadPacking.TraerListaPaclinklist();
		
		}

		public DataSet ListaPackinglisxSerie(string Packing)
		{
			return cadPacking.TraerListaPaclinklistxSerie(Packing);
		}

		public DataSet traerAnotacionPaquete(string Packing)
		{
			return cadPacking.traerAnotacionPaquete(Packing);
		}

		




	}
}
