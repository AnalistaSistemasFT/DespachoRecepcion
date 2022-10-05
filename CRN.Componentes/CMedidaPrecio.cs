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
    public class CMedidaPrecio
    {

        CADMedidaPrecio cadMedidaPrecio = new CAD.CADMedidaPrecio();

        public void GuardarMedidaPrecio(MedidaPrecio oMedidaPrecio)
        {
            //if (byte.Refer(oArchivo.p_doc))
            //    throw new ArgumentNullException("Documento");
            //if (string.IsNullOrEmpty(oArchivo.p_nombre))
            //    throw new ArgumentNullException("Nombre del Archivo");
            //if (string.IsNullOrEmpty(oArchivo.p_extension))
            //    throw new ArgumentNullException("Extension");
            cadMedidaPrecio.GuardarMedidaPrecio(oMedidaPrecio);
        }
        public MedidaPrecio TraerMedidaPrecio(string Centro, decimal medida)
        {
            return cadMedidaPrecio.TraerMedidaPrecio(Centro,medida);
        }
        public DataSet TraerTodoMedidaPrecio(string where)
        {
            return cadMedidaPrecio.TraerTodoMedidaPrecio(where);
        }

        public int ModificaroMedidaPrecio(MedidaPrecio oMedidaPrecio)
        {
            //if (byte.Refer(oArchivo.p_doc))
            //    throw new ArgumentNullException("Documento");
            //if (string.IsNullOrEmpty(oArchivo.p_nombre))
            //    throw new ArgumentNullException("Nombre del Archivo");
            //if (string.IsNullOrEmpty(oArchivo.p_extension))
            //    throw new ArgumentNullException("Extension");
            return cadMedidaPrecio.ModificarMedidaPrecio(oMedidaPrecio);
        }


        //public Archivo TraerArchivo(int cod)
        //{
        //    Archivo oArchivo = cadArchivo.TraerArchivo(cod);
        //    return oArchivo;
        //}
        //public int EliminaroMedidaPrecio(int cod)
        //{
        //    MovSync oMovSync = new MovSync();
        //    int c = cadMedidaPrecio.EliminarMedidaPrecio(cod);
        //    return c;
        //}
        //public int MarcarEliminado(int cod, int Valor)
        //{
        //    MovSync oMovSync = new MovSync();
        //    int c = cadMedidaPrecio.MarcarEliminado(cod, Valor);
        //    return c;
        //}

        public bool ContieneoMedidaPrecio(int idCarpeta)
        {
            string where = "Id_carpeta=" + idCarpeta;
            DataSet ds = this.TraerTodoMedidaPrecio(where);
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

        //public DataSet BuscarTipoCosteo(string nombDocumento)
        //{
        //    //return cadTipoCosteo.BuscarTipoCosteo(nombDocumento);
        //}
    }
}
