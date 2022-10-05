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
    public class CRecursosUser
    {
        CADRecursosUser cadRecursosUser = new CAD.CADRecursosUser();
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

        public DataSet TraerTodosLosArchivos()
        {
            return cadRecursosUser.TraerTodosLosArchivos();
        }
        public DataSet TraerTodosLosRecursosUser(string where)
        {
            return cadRecursosUser.TraerTodosLosRecursosUser(where);
        }
        public DataSet TraerTodosLoscontenidos(int idcarpeta)
        {
            return cadRecursosUser.TraerTodosLoscontenidos(idcarpeta);
        }
        //public int ModificarArchivo(RecursosUser oRecursosUser)
        //{
        //    //if (byte.Refer(oArchivo.p_doc))
        //    //    throw new ArgumentNullException("Documento");
        //    //if (string.IsNullOrEmpty(oArchivo.p_nombre))
        //    //    throw new ArgumentNullException("Nombre del Archivo");
        //    //if (string.IsNullOrEmpty(oArchivo.p_extension))
        //    //    throw new ArgumentNullException("Extension");
        //    return cadRecursosUser.ModificarArchivos(oRecursosUser);
        //}

        //public Archivo TraerArchivo(int cod)
        //{
        //    Archivo oArchivo = cadArchivo.TraerArchivo(cod);
        //    return oArchivo;
        //}
        public int EliminarArchivo(int cod)
        {
            RecursosUser oRecursosUser = new RecursosUser();
            int c = cadRecursosUser.EliminarArchivosCarpetas(cod);
            return c;
        }
        public int MarcarEliminado(int cod, int Valor)
        {
            Sucursal oRecursosUser = new Sucursal();
            int c = cadRecursosUser.MarcarEliminado(cod, Valor);
            return c;
        }

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
