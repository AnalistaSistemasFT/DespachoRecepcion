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
    public class CDespDetalle
    {
        CADDespDetalle cadDespDetalle = new CAD.CADDespDetalle();
        //public CArchivo()
        //{
        //    // cadArchivo=new CADArchivo();
        //}
        public int GuardarDespDetalle(DespDetalle oDespDetalle)
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

            return cadDespDetalle.GuardarDespDetalle(oDespDetalle);
        }

        public DataSet TraerTodosLosDespDetalle()
        {
            return cadDespDetalle.TraerTodosLosDespDetalle();
        }
        public DataSet TraerTodosLosDespDetalle(string where)
        {
            return cadDespDetalle.TraerTodosLosDespDetalle(where);
        }

        public int ModificarDespDetalle(DespDetalle oDespDetalle)
        {
            //if (byte.Refer(oArchivo.p_doc))
            //    throw new ArgumentNullException("Documento");
            //if (string.IsNullOrEmpty(oArchivo.p_nombre))
            //    throw new ArgumentNullException("Nombre del Archivo");
            //if (string.IsNullOrEmpty(oArchivo.p_extension))
            //    throw new ArgumentNullException("Extension");
            return cadDespDetalle.ModificarDespDetalle(oDespDetalle);
        }

        public DespDetalle TraerDespDetalle(string DespachoId,string item)
        {
            DespDetalle oDespDetalle = cadDespDetalle.TraerDespDetalle(DespachoId,item);
            return oDespDetalle;
        }
        public int ModificarCantConfirmada(string DespachoId, string Item, decimal Cantidad,string Tipo)
        {
            return cadDespDetalle.ModificarCantConfirmada(DespachoId, Item, Cantidad,Tipo);
        }
        public int EliminarDespDetalle(string cod)
        {
          //  RecepcionDetalle oRecepcionDetalle = new RecepcionDetalle();
            int c = cadDespDetalle.EliminarDespDetalle(cod);
            return c;
        }
        public int MarcarEliminado(int cod, int Valor)
        {
            //DespDetalle oMovSync = new DespDetalle();
            int c = cadDespDetalle.MarcarEliminado(cod, Valor);
            return c;
        }
       
        public DataSet BuscarDespDetalle(string nombDocumento)
        {
            return cadDespDetalle.BuscarDespDetalle(nombDocumento);
        }
        public int AgregarCantDespDetalle(DespDetalle _Detdesp)
        {
            return cadDespDetalle.AgregarCantDespDetalle(_Detdesp);
        }
        public int EditarCantDespDetalle(DespDetalle _despDet)
        {
            return cadDespDetalle.EditarCantDespDetalle(_despDet);
        }
    }
}
