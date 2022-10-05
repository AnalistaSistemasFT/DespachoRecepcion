using CRN.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CAD
{
    public class CADOrdenEntrega : DBDAC
    {
        
        public CADOrdenEntrega() : base("SQLSERVER", "dbo.tblOrdenEntrega")
        {

        }
        public DataSet TraerOrdenesEntregas()
        {
            string cadena = "select * from tblOrdenEntrega";
            return this.EjecutarConsulta(cadena);
        }
        public DataSet TraerTodasOrdenEntrega(string Estado)
        {
            string cadena = "select * from tblOrdenEntrega where Estado = '" + Estado + "'";
            return this.EjecutarConsulta(cadena);
        }
        public DataSet TraerTodasOrdenEntregaList(string Estado)
        {
            string cadena = "select DespachoId, Fecha_salida as Fechas, Chofer, Placa, Cantidad_total as Cantidad, Peso_total as Peso, Login from tblOrdenEntrega where Estado = '" + Estado + "'";
            return this.EjecutarConsulta(cadena);
        }
        public DataSet TraerTodasOrdenDetalleDespacho(string IdDespacho)
        {
            string cadena = "select PaqueteId, ItemId as Codigo, ItemFId as CodigoFerro, Cantidad, Peso, Estado from tblOrdenEntregaDetalle where DespachoId = '" + IdDespacho + "'";
            return this.EjecutarConsulta(cadena);
        }
        public DataSet TraerIdInsertado(string _despachoId)
        {
            string cadena = "select Id_orden_entrega from tblOrdenEntrega order by Id_orden_entrega";
            return this.EjecutarConsulta(cadena);
        }
    }
}
