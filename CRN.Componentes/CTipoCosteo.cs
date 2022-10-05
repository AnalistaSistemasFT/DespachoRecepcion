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
    public class CTipoCosteo
    {
        CADTipoCosteo cadTipoCosteo = new CAD.CADTipoCosteo();

        public void GuardarTipoCosteo(TipoCosteo oTipoCosteo)
        {
            //if (byte.Refer(oArchivo.p_doc))
            //    throw new ArgumentNullException("Documento");
            //if (string.IsNullOrEmpty(oArchivo.p_nombre))
            //    throw new ArgumentNullException("Nombre del Archivo");
            //if (string.IsNullOrEmpty(oArchivo.p_extension))
            //    throw new ArgumentNullException("Extension");
            cadTipoCosteo.GuardarTipoCosteo(oTipoCosteo);
        }
        public DataSet TraerTipoCosteo()
        {
            return cadTipoCosteo.TraerTodoTipoCosteo();
        }
        public DataSet TraerTodoTipoCosteo(string where)
        {
            return cadTipoCosteo.TraerTodoTipoCosteo(where);
        }

        public int ModificarTipoCosteo(TipoCosteo oTipoCosteo)
        {
            //if (byte.Refer(oArchivo.p_doc))
            //    throw new ArgumentNullException("Documento");
            //if (string.IsNullOrEmpty(oArchivo.p_nombre))
            //    throw new ArgumentNullException("Nombre del Archivo");
            //if (string.IsNullOrEmpty(oArchivo.p_extension))
            //    throw new ArgumentNullException("Extension");
            return cadTipoCosteo.ModificarTipoCosteo(oTipoCosteo);
        }


        //public Archivo TraerArchivo(int cod)
        //{
        //    Archivo oArchivo = cadArchivo.TraerArchivo(cod);
        //    return oArchivo;
        //}
        //public int EliminarTipoCosteo(int cod)
        //{
        //    MovSync oMovSync = new MovSync();
        //    int c = cadTipoCosteo.EliminarTipoCosteo(cod);
        //    return c;
        //}
        //public int MarcarEliminado(int cod, int Valor)
        //{
        //    MovSync oMovSync = new MovSync();
        //    int c = cadTipoCosteo.MarcarEliminado(cod, Valor);
        //    return c;
        //}

        public bool ContieneTipoCosteo(int idCarpeta)
        {
            string where = "Id_carpeta=" + idCarpeta;
            DataSet ds = this.TraerTodoTipoCosteo(where);
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

        public DataSet BuscarTipoCosteo(string nombDocumento)
        {
            return cadTipoCosteo.BuscarTipoCosteo(nombDocumento);
        }
    }
}
