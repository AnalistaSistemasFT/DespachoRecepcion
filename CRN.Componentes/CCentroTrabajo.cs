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
    public class CCentroTrabajo
    {
          CADCentroTrabajo cadCentroTrabajo = new CAD.CADCentroTrabajo();

          public void GuardarCentroTrabajo(CentroTrabajo oCentroTrabajo)
        {
            //if (byte.Refer(oArchivo.p_doc))
            //    throw new ArgumentNullException("Documento");
            //if (string.IsNullOrEmpty(oArchivo.p_nombre))
            //    throw new ArgumentNullException("Nombre del Archivo");
            //if (string.IsNullOrEmpty(oArchivo.p_extension))
            //    throw new ArgumentNullException("Extension");
            cadCentroTrabajo.GuardarCentroTrabajo(oCentroTrabajo);
        }
        public DataSet TraerCentroTrabajo()
        {
            return cadCentroTrabajo.TraerTodoCentroTrabajo();
        }
        public DataSet TraerTodoMovSync(string where)
        {
            return cadCentroTrabajo.TraerTodoCentroTrabajo(where);
        }
   
        public int ModificarArchivo(CentroTrabajo oCentroTrabajo)
        {
            //if (byte.Refer(oArchivo.p_doc))
            //    throw new ArgumentNullException("Documento");
            //if (string.IsNullOrEmpty(oArchivo.p_nombre))
            //    throw new ArgumentNullException("Nombre del Archivo");
            //if (string.IsNullOrEmpty(oArchivo.p_extension))
            //    throw new ArgumentNullException("Extension");
            return cadCentroTrabajo.ModificarCentroTrabajo(oCentroTrabajo);
        }
        public DataSet TraerxCentro(int id)
        {
            return cadCentroTrabajo.TraerCentrosxID(id);
        }
        public DataSet TraerAlmacen()
        {
            return cadCentroTrabajo.TraerAlmacenes();
        }
        public CentroTrabajo TraerCentroTrabajo(string cod)
        {
            return cadCentroTrabajo.TraerCentroTrabajo(cod);
        }
        //public decimal ObtenerPrecioTonelada(CentroTrabajo oC, string Orden)
        //{
        //    decimal PrecioTon = 0;
        //    if (oC.TipoCosteo == (int)Entidades.TipoCosteo.PorCentroDeTrabajo)
        //        PrecioTon = oC.PrecioTon;
        //    else if (oC.TipoCosteo == (int)Enumeradores.TipoCosteo.PorProduccion)
        //    {
        //        COrdenSync cOrden = new COrdenSync();
        //        Decimal Diametro = cOrden.ObtenerDiametroOrden(Orden);
        //        CMedidaPrecio cMP = new CMedidaPrecio();
        //        MedidaPrecio oMP;
        //        oMP = cMP.TraerMedidaPrecio(oC.CentroId, Diametro);

        //        PrecioTon = oMP.PrecioTon;
        //    }
        //    else if (oC.TipoCosteo == (int)Enumeradores.TipoCosteo.SinCosto)
        //    {
        //        PrecioTon = 0;
        //    }
        //    return PrecioTon;
        //}

    }
}
