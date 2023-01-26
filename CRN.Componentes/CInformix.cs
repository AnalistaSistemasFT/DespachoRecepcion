using CAD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CRN.Componentes
{
    public class CInformix
    {
        CADInformix _cadInformix = new CADInformix();
        public DataSet TraerTodosClientes()
        {
            return _cadInformix.TraerTodosClientes();
        }
        public DataSet TraerDescProducto()
        {
            return _cadInformix.TraerDescProducto();
        }
        public DataSet TraerEntregas(decimal _idSucursal)
        {
            return _cadInformix.TraerEntregas(_idSucursal);
        }
        public DataSet TraerDetalleEntregas(decimal _tipoDoc, decimal _nroDoc)
        {
            return _cadInformix.TraerDetalleEntregas(_tipoDoc, _nroDoc);
        }
        public DataSet TraerDetalleEntSuc(decimal iSucursal, decimal sTipoDoc, decimal sTipoDoc1)
        {
            return _cadInformix.TraerDetalleEntSuc(iSucursal, sTipoDoc, sTipoDoc1);
        }
        public DataSet TraerTodasOrdenes()
        {
            return _cadInformix.TraerTodasOrdenes();
        }
        public DataSet TraerDetalleOV()
        {
            return _cadInformix.TraerDetalleOV();
        }
        public DataSet TraerCorrelativoCierre(int _idSucursal)
        {
            return _cadInformix.TraerCorrelativoCierre(_idSucursal);
        }
        public DataSet TraerTipoDocEntrega(decimal _tipoFact)
        {
            return _cadInformix.TraerTipoDocEntrega(_tipoFact);
        }
        public DataSet TraerScTipoDoc(int _idSucursal)
        {
            return _cadInformix.TraerScTipoDoc(_idSucursal);
        }
        public DataSet TraerContadoCredito(int _idSucursal)
        {
            return _cadInformix.TraerContadoCredito(_idSucursal);
        }
        public DataSet TraerTipoFactu(int _idSucursal)
        {
            return _cadInformix.TraerTipoFactu(_idSucursal);
        }
    }
}
