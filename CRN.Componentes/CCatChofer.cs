using CAD;
using CRN.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CRN.Componentes
{
    public class CCatChofer
    {
        CADChofer cadChofer = new CADChofer();
        CADCamion cadCamion = new CADCamion();
        public DataSet TraerChoferes()
        {
            return cadChofer.TraerChoferes();
        }
        public DataSet TraerPlacas()
        {
            return cadChofer.TraerPlacas();
        }
        public DataSet BuscarChofer(string _nombreB)
        {
            return cadChofer.BuscarChoferes(_nombreB);
        }
        public int GuardarChofer(CatChofer _catChofer)
        {
            return cadChofer.GuardarChofer(_catChofer);
        }
        public int GuardarCamion(CatCamion _catCamion)
        {
            return cadCamion.GuardarCamion(_catCamion);
        }
	    public int EditarCapacidad(string placa, decimal peso)
        {
            return cadChofer.EditarCapacidad(placa, peso);
        }
    }
}
