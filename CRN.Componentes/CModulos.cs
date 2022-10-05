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
    public class CModulos
    {

         CADModulos cadModulos= new CAD.CADModulos();
        //public CArchivo()
        //{
        //    // cadArchivo=new CADArchivo();
        //}
        //public int GuardarArchivo(Sucursal oSucursal)
        //{
        //    //if (byte.Refer(oArchivo.p_doc))
        //    //    throw new ArgumentNullException("Documento");
        //    //if (string.IsNullOrEmpty(oArchivo.p_nombre))
        //    //    throw new ArgumentNullException("Nombre del Archivo");

        //    //if (string.IsNullOrEmpty(oArchivo.p_extension))
        //    //    throw new ArgumentNullException("Extension");
        //    //if (string.IsNullOrEmpty(oArchivo.p_codigoSig))
        //    //    throw new ArgumentNullException("codigoSig");
        //    //if (oArchivo.p_version > oArchivo.p_version)
        //    //    throw new ArgumentOutOfRangeException("version");
        //    //if (oArchivo.p_estado != "Activo" && oArchivo.p_estado != "Eliminado")
        //    //    throw new ArgumentOutOfRangeException("estado");

        //    //return cadSucursal.GuardarArchivo(oSucursal);
        //}

        //public DataSet TraerTodosLosArchivos()
        //{
        //    return cadModulos.TraerTodosLosArchivos();
        //}
        public DataSet TraerTodosModulos(string where)
        {
            return cadModulos.TraerTodosModulos(where);
        }
        //public DataSet TraerTodosLoscontenidos(int idcarpeta)
        //{
        //    return cadModulos.TraerTodosLoscontenidos(idcarpeta);
        //}
        //public int ModificarArchivo(Modulos oModulos)
        //{
        //    //if (byte.Refer(oArchivo.p_doc))
        //    //    throw new ArgumentNullException("Documento");
        //    //if (string.IsNullOrEmpty(oArchivo.p_nombre))
        //    //    throw new ArgumentNullException("Nombre del Archivo");
        //    //if (string.IsNullOrEmpty(oArchivo.p_extension))
        //    //    throw new ArgumentNullException("Extension");
        //    return cadModulos.ModificarArchivos(oModulos);
        //}

        //public Archivo TraerArchivo(int cod)
        //{
        //    Archivo oArchivo = cadArchivo.TraerArchivo(cod);
        //    return oArchivo;
        //}
        //public int EliminarArchivo(int cod)
        //{
        //    Sucursal oSucursal = new Sucursal();
        //    int c = cadModulos.EliminarArchivosCarpetas(cod);
        //    return c;
        //}
        //public int MarcarEliminado(int cod, int Valor)
        //{
        //    Modulos oModulos = new Modulos();
        //    int c = cadModulos.MarcarEliminado(cod, Valor);
        //    return c;
        //}

        //public bool ContieneArchivos(int idCarpeta)
        //{
        //    string where = "Id_carpeta=" + idCarpeta;
        //    DataSet ds = this.TraerTodosLosArchivos(where);
        //    //Agarra toda la tabla
        //    DataTable tArchivo = ds.Tables[0];
        //    //
        //    if (tArchivo.Rows.Count == 0)
        //    {
        //        return false;
        //    }
        //    else
        //        return true;

        //}
        
    }
}
