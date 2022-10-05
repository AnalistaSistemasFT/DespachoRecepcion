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
    class CSucItem
    {
         CADSucItem cadCSucItem = new CADSucItem();
       
        //public CArchivo()
        //{
        //    // cadArchivo=new CADArchivo();
        //}

        public DataSet TraerTodoItem()
        {
            return cadCSucItem.TraerTodoSucItem();
        }
        public DataSet TraerTodoItem(string where)
        {
            return cadCSucItem.TraerTodoSucItem(where);
        }
        public void GuardaroSucItem(SucItem oSucItem)
        {
            //if (byte.Refer(oArchivo.p_doc))
            //    throw new ArgumentNullException("Documento");
            //if (string.IsNullOrEmpty(oArchivo.p_nombre))
            //    throw new ArgumentNullException("Nombre del Archivo");
            //if (string.IsNullOrEmpty(oArchivo.p_extension))
            //    throw new ArgumentNullException("Extension");
            cadCSucItem.GuardarSucItem(oSucItem);
        }

        public void ModificarSucItem(SucItem oSucItem)
        {
            //if (byte.Refer(oArchivo.p_doc))
            //    throw new ArgumentNullException("Documento");
            //if (string.IsNullOrEmpty(oArchivo.p_nombre))
            //    throw new ArgumentNullException("Nombre del Archivo");
            //if (string.IsNullOrEmpty(oArchivo.p_extension))
            //    throw new ArgumentNullException("Extension");
           cadCSucItem.ModificarSucItem(oSucItem);
        }

      

        //public Archivo TraerArchivo(int cod)
        //{
        //    Archivo oArchivo = cadArchivo.TraerArchivo(cod);
        //    return oArchivo;
        //}
    }
    
}
