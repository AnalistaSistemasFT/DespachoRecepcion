using CAD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CRN.Componentes
{
    public class CNroOrden
    {
        CADNroOrden _cadNroOrden = new CADNroOrden();
        public DataSet TraerTodo(int _idSucursalDestino)
        {
            return _cadNroOrden.TraerTodo(_idSucursalDestino);
        }
        public DataSet TraerTodo2()
        {
            return _cadNroOrden.TraerTodo2();
        }
        public DataSet TraerOrden(int _nroOrden)
        {
            return _cadNroOrden.TraerOrden(_nroOrden);
        }
        public DataSet TraerProductos(int _nroOrden, int _NroDocTraspVenta)
        {
            return _cadNroOrden.TraerProductos(_nroOrden, _NroDocTraspVenta);
        }
        public DataSet TraerTipoDocumento(int _idSucursalDestino)
        {
            return _cadNroOrden.TraerTipoDocumento(_idSucursalDestino);
        }
        public DataSet TraerTodasOrdenes()
        {
            return _cadNroOrden.TraerTodasOrdenes();
        }
        public DataSet TraerClientes()
        {
            return _cadNroOrden.TraerClientes();
        }
    }
}
