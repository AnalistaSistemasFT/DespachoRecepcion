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
    public class CPaquetes
    {


        CADPaquetes cadPaquetes = new CAD.CADPaquetes();
        //public CArchivo()
        //{
        //    // cadArchivo=new CADArchivo();
        //}
        public int GuardarPaquetes(Paquetes oPaquetes)
        {
            //if (byte.Refer(oArchivo.p_doc))
            //    throw new ArgumentNullException("Documento");
            //if (string.IsNullOrEmpty(oArchivo.p_nombre))
            //    throw new ArgumentNullException("Nombre del Archivo");

            //if (string.IsNullOrEmpty(oArchivo.p_extension))
            //    throw new ArgumentNullException("Extension");
            //if (string.IsNullOrEmpty(oArchivo.p_codigoSig))
            //    throw new ArgumentNullException("codigoSig");
            //if (oArchivo.p_version > oArchivo.p_version)
            //    throw new ArgumentOutOfRangeException("version");
            //if (oArchivo.p_estado != "Activo" && oArchivo.p_estado != "Eliminado")
            //    throw new ArgumentOutOfRangeException("estado");

            return cadPaquetes.GuardarPaquetes(oPaquetes);
        }
        public DataSet TraerStock(string _codigoPr, int _idSucursal)
        {
            return cadPaquetes.TraerStock(_codigoPr, _idSucursal);
        }
        public DataSet TraerTodoPaquetes()
        {
            return cadPaquetes.TraerTodoPaquetes();
        }
        public DataSet TraerListaStock(int _idSucursal)
        {
            return cadPaquetes.TraerListaStock(_idSucursal);
        }
        public DataSet TraerTodoPaquetesActivos(string sEstado, int iSucursal)
        {
            return cadPaquetes.TraerTodoPaquetesActivos(sEstado, iSucursal);
        }
        public DataSet TraerTodoPaquetes(string where)
        {
            return cadPaquetes.TraerTodoPaquetes(where);
        }
        public DataSet TraerTodoPaquetes(string estado, int sucursal)
        {
            return cadPaquetes.TraerTodoPaquetes(estado, sucursal);
        }
        public DataSet TraerStockNombre(string _nombrePr, int _idSucursal)
        {
            return cadPaquetes.TraerStockNombre(_nombrePr, _idSucursal);
        }
        public DataSet TraerStockCodigo(string _codigoPr, int _idSucursal)
        {
            return cadPaquetes.TraerStockCodigo(_codigoPr, _idSucursal);
        }
	public DataSet TraerCantProdPorDespacho(string _idDespacho)
        {
            return cadPaquetes.TraerCantProdPorDespacho(_idDespacho);
        }
        public DataSet TraerProductosaLecturarValidar(string _idDespacho)
        {
            return cadPaquetes.TraerProductosaLecturarValidar(_idDespacho);
        }
        public DataSet TraerPaqueteLecturado(int _idSucursal)
        {
            return cadPaquetes.TraerPaqueteLecturado(_idSucursal);
        }
	public DataSet TraerPaqueteLecturadoBuscar(int _idSucursal, string _idPaquete)
        {
            return cadPaquetes.TraerPaqueteLecturadoBuscar(_idSucursal, _idPaquete);
        }
        public DataSet TraerPaqueteLecturadoFiltrado(int _idSucursal, string _ItemId)
        {
            return cadPaquetes.TraerPaqueteLecturadoFiltrado(_idSucursal, _ItemId);
        }
        public int ReservarPaquete(string _idPaquete)
        {
            return cadPaquetes.ReservarPaquete(_idPaquete);
        }
        public DataSet TraerPaqueteLecturadoPorSucursal(int _idSucursal)
        {
            return cadPaquetes.TraerPaqueteLecturadoPorSucursal(_idSucursal);
        }
        public DataSet TraerComparacionPaquetes(string _IdPaquete)
        {
            return cadPaquetes.TraerComparacionPaquetes(_IdPaquete);
        }
        public DataSet TraerEstadoPaqueteCerrar(string _idPaquete)
        {
            return cadPaquetes.TraerEstadoPaqueteCerrar(_idPaquete);
        }
        public DataSet TraerContPaquetesProgCelda(string _idDespacho)
        {
            return cadPaquetes.TraerContPaquetesProgCelda(_idDespacho);
        }
        public DataSet TraerContPaquetesProgSob(string _idDespacho)
        {
            return cadPaquetes.TraerContPaquetesProgSob(_idDespacho);
        }
        public DataSet TraerPaqProgCeldaLect(string _idDespacho)
        {
            return cadPaquetes.TraerPaqProgCeldaLect(_idDespacho);
        }
        public DataSet TraerPaqProgSobLect(string _idDespacho)
        {
            return cadPaquetes.TraerPaqProgSobLect(_idDespacho);
        }
        public DataSet TraerPaqProgramados(string _idPaquete)
        {
            return cadPaquetes.TraerPaqProgramados(_idPaquete);
        }
        public DataSet BuscarPaqueteLecturar(string _IdPaquete)
        {
            return cadPaquetes.BuscarPaqueteLecturar(_IdPaquete);
        }
        public DataSet BuscarPaqueteEntrega(string _idDespacho)
        {
            return cadPaquetes.BuscarPaqueteEntrega(_idDespacho);
        }
        public DataSet TraerCelda(string _idPaquete)
        {
            return cadPaquetes.TraerCelda(_idPaquete);
        }
        public DataSet BuscarPaqueteEntregaPacial(string _idDespacho)
        {
            return cadPaquetes.BuscarPaqueteEntregaPacial(_idDespacho);
        }
        public DataSet BuscarPaqueteEntregaParcialPendiente(string _idDespacho)
        {
            return cadPaquetes.BuscarPaqueteEntregaParcialPendiente(_idDespacho);
        }
        public DataSet BuscarPaqueteEntregaConEntrega(string _idDespacho)
        {
            return cadPaquetes.BuscarPaqueteEntregaConEntrega(_idDespacho);
        }
        public DataSet ContEntregas(string _idDespacho)
        {
            return cadPaquetes.ContEntregas(_idDespacho);
        }
        public DataSet BuscarDatosEntrega(string _idDespacho)
        {
            return cadPaquetes.BuscarDatosEntrega(_idDespacho);
        }
        public DataSet BuscarPaqueteCompleto(string _IdPaquete)
        {
            return cadPaquetes.BuscarPaqueteCompleto(_IdPaquete);
        }
        public int ModificarPaquetes(Paquetes oPaquetes)
        {
            //if (byte.Refer(oArchivo.p_doc))
            //    throw new ArgumentNullException("Documento");
            //if (string.IsNullOrEmpty(oArchivo.p_nombre))
            //    throw new ArgumentNullException("Nombre del Archivo");
            //if (string.IsNullOrEmpty(oArchivo.p_extension))
            //    throw new ArgumentNullException("Extension");
            return cadPaquetes.ModificarPaquetes(oPaquetes);
        }

        public Paquetes TraerPaquete(string cod)
        {
            Paquetes oPaquetes = cadPaquetes.TraerPaquete(cod);
            return oPaquetes;
        }


        public int EliminaroPaquetes(int cod)
        {
            RecepcionDetalle oRecepcionDetalle = new RecepcionDetalle();
            int c = cadPaquetes.EliminarPaquetes(cod);
            return c;
        }
        public int MarcarEliminado(int cod, int Valor)
        {
            //MovSync oMovSync = new MovSync();
            int c = cadPaquetes.MarcarEliminado(cod, Valor);
            return c;
        }

        public bool ContieneArchivos(int idCarpeta)
        {
            string where = "Id_carpeta=" + idCarpeta;
            DataSet ds = this.TraerTodoPaquetes(where);
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
        public int AbrirPaquete(string _IdPaquete, int _PiezaEnt, int _PiezaAct, decimal _PesoEnt, decimal _PesoAct)
        {
            return cadPaquetes.AbrirPaquete(_IdPaquete, _PiezaEnt, _PiezaAct, _PesoEnt, _PesoAct);
        }
        public DataSet TraerDatosAbrirPaq(string _IdPaquete)
        {
            return cadPaquetes.TraerDatosAbrirPaq(_IdPaquete);
        }
        public bool BuscarPaquetes(string CodPaquete)
        {
            return cadPaquetes.BuscarPaquetes(CodPaquete);
        }
        
        public DataSet BuscarPaquetePorOrden(string _NroOrden)
        {
            return cadPaquetes.BuscarPaquetePorOrden(_NroOrden);
        }
    }
}
