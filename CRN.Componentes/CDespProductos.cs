using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Transactions;

using CRN.Entidades;
using CAD;

namespace CRN.Componentes
{
    public class CDespProductos
    {
        CADDespProductos cadDespProductos = new CAD.CADDespProductos();
        //public CArchivo()
        //{
        //    // cadArchivo=new CADArchivo();
        //}
        public int GuardarDespacho(DespProductos oDespProductos)
        {
            return cadDespProductos.GuardarDespProductos(oDespProductos);
        }
        public DataSet TraerTodosLosArchivos()
        {
            return cadDespProductos.TraerTodoDespProductos();
        }
        public DataSet BuscarDespALecturar(string _idDespacho)
        {
            return cadDespProductos.BuscarDespALecturar(_idDespacho);
        }
        public DataSet BuscarDespALecturarCompleto(string _idDespacho)
        {
            return cadDespProductos.BuscarDespALecturarCompleto(_idDespacho);
        }
        public DataSet TraerTodosLosArchivos(string where)
        {
            return cadDespProductos.TraerTodoDespProductos(where);
        }
        public DataSet DetMovDatos(string _idDespacho, string _itemId)
        {
            return cadDespProductos.DetMovDatos(_idDespacho, _itemId);
        }
        public int ModificarCantidad(string _idDespacho, string _idPaquete, int _cantRetirada, decimal _pesoNuevo)
        {
            return cadDespProductos.ModificarCantidad(_idDespacho, _idPaquete, _cantRetirada, _pesoNuevo);
        }
        //public DataSet TraerTodosLoscontenidos(int idcarpeta)
        //{
        //    return cadDespProductos.TraerTodoDespacho(idcarpeta);
        //}
        public int ModificarArchivo(DespProductos oDespProductos)
        {
            //if (byte.Refer(oArchivo.p_doc))
            //    throw new ArgumentNullException("Documento");
            //if (string.IsNullOrEmpty(oArchivo.p_nombre))
            //    throw new ArgumentNullException("Nombre del Archivo");
            //if (string.IsNullOrEmpty(oArchivo.p_extension))
            //    throw new ArgumentNullException("Extension");
            return cadDespProductos.ModificarDespProductos(oDespProductos);
        }

        //public Archivo TraerArchivo(int cod)
        //{
        //    Archivo oArchivo = cadArchivo.TraerArchivo(cod);
        //    return oArchivo;
        //}
        public int EliminarArchivo(int cod)
        {
            RecepcionDetalle oRecepcionDetalle = new RecepcionDetalle();
            int c = cadDespProductos.EliminarDespProductos(cod);
            return c;
        }
        public int MarcarEliminado(int cod, int Valor)
        {
            int c = cadDespProductos.MarcarEliminado(cod, Valor);
            return c;
        }
        public bool BuscarDespProductos(string CodPaquete, string CodDespacho)
        {
            return cadDespProductos.BuscarDespProductos(CodPaquete, CodDespacho);
        }
        public DataSet VerificarLlaves(string _idDespacho, string _idPaquete)
        {
            return cadDespProductos.VerificarLlaves(_idDespacho, _idPaquete);
        }
        public bool ContieneArchivos(int idCarpeta)
        {
            string where = "Id_carpeta=" + idCarpeta;
            DataSet ds = this.TraerTodosLosArchivos(where);
            //Agarra toda la tabla
            DataTable tArchivo = ds.Tables[0];
            //
            if (tArchivo.Rows.Count == 0)
            {
                return false;
            }
            else
                return true;

        }
        public DataSet TraerSumaProgramados(string _idDespacho)
        {
            return cadDespProductos.TraerSumaProgramados(_idDespacho);
        }
        public DataSet TraerSumaEnviados(string _idDespacho)
        {
            return cadDespProductos.TraerSumaEnviados(_idDespacho);
        }
    }
}
