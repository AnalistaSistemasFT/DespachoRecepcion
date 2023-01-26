using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CAD;

namespace CRN.Componentes
{
    public class CLocaliza
    {
        CADLocalizacion cadLocaliza = new CADLocalizacion();
        public DataSet TraerOrdenesProduccion(int _idSucursal)
        {
            return cadLocaliza.TraerOrdenesProduccion(_idSucursal);
        }
        public DataSet TraerDetalleOrdenesProduccion(string _nrOrden)
        {
            return cadLocaliza.TraerDetalleOrdenesProduccion(_nrOrden);
        }
        public DataSet TraerOrdenesAbiertas(int _idSucursal)
        {
            return cadLocaliza.TraerOrdenesAbiertas(_idSucursal);
        }
        public DataSet TraerDetalleOrdenAbiertaProgra(string _nrOrden)
        {
            return cadLocaliza.TraerDetalleOrdenAbiertaProgra(_nrOrden);
        }
        public DataSet TraerDetalleOrdenAbiertaProducto(string _nrOrden)
        {
            return cadLocaliza.TraerDetalleOrdenAbiertaProducto(_nrOrden);
        }
        public DataSet TraerOrdenesCerradas(int _idSucursal)
        {
            return cadLocaliza.TraerOrdenesCerradas(_idSucursal);
        }
        public DataSet TraerCantidadPlanificar(string _NrOrden)
        {
            return cadLocaliza.TraerCantidadPlanificar(_NrOrden);
        }
        public DataSet TraerDatosPicking(string _PlanId)
        {
            return cadLocaliza.TraerDatosPicking(_PlanId);
        }
        public int ConsolidarPaquetePick(string _Planid, string _PaqueteId)
        {
            return cadLocaliza.ConsolidarPaquetePick(_Planid, _PaqueteId);
        }
        public int CerrarOrdenPicking(string sError, string _PlanId, string _OrdenId, DataTable dt)
        {
            return cadLocaliza.CerrarOrdenPicking(out sError, _PlanId, _OrdenId, dt);
        }
    }
}
