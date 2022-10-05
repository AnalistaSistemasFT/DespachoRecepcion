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
    public class CMovDetalle
    {
        CADMovDetalle cadMovDetalle=new CADMovDetalle();
        MovDetalle oMovDetalle=new MovDetalle(); 
        //public CArchivo()
        //{
        //    // cadArchivo=new CADArchivo();
        //}

        public DataSet TraerTodoMovSync()
        {
            return cadMovDetalle.TraerTodoMovDetalle();
        }
        public DataSet TraerTodoMovSync(string where)
        {
            return cadMovDetalle.TraerTodoMovDetalle(where);
        }
        //public void GuardarMovDetalle(MovDetalle oMovDetalle)
        //{
        //    //if (byte.Refer(oArchivo.p_doc))
        //    //    throw new ArgumentNullException("Documento");
        //    //if (string.IsNullOrEmpty(oArchivo.p_nombre))
        //    //    throw new ArgumentNullException("Nombre del Archivo");
        //    //if (string.IsNullOrEmpty(oArchivo.p_extension))
        //    //    throw new ArgumentNullException("Extension");
        //    cadMovDetalle.GuardarMovDetalle(oMovDetalle);
        //}

        //public int ModificarMovDetalle(MovDetalle oOrden)
        //{
        //    //if (byte.Refer(oArchivo.p_doc))
        //    //    throw new ArgumentNullException("Documento");
        //    //if (string.IsNullOrEmpty(oArchivo.p_nombre))
        //    //    throw new ArgumentNullException("Nombre del Archivo");
        //    //if (string.IsNullOrEmpty(oArchivo.p_extension))
        //    //    throw new ArgumentNullException("Extension");
        //    return cadMovDetalle.ModificarMovDetalle(oOrden);
        //}
      

        //public Archivo TraerArchivo(int cod)
        //{
        //    Archivo oArchivo = cadArchivo.TraerArchivo(cod);
        //    return oArchivo;
        //}
     
    }
}
