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
    public class CCeldas
    {
        CADCeldas cadCeldas = new CAD.CADCeldas();
        //public CArchivo()
        //{
        //    // cadArchivo=new CADArchivo();
        //}
        public int GuardarCeldas(Celdas oCeldas)
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

            return cadCeldas.GuardarCeldas(oCeldas);
        }

        public DataSet TraerTodoCeldas()
        {
            return cadCeldas.TraerTodoCeldas();
        }
        public DataSet TraerTodoCeldas(string where)
        {
            return cadCeldas.TraerTodoCeldas(where);
        }
        public DataSet TraerTodoCeldas(string estado, int sucursal)
        {
            return cadCeldas.TraerTodoCeldas(estado, sucursal);
        }
        public int ModificarCeldas(Celdas oCeldas)
        {
            //if (byte.Refer(oArchivo.p_doc))
            //    throw new ArgumentNullException("Documento");
            //if (string.IsNullOrEmpty(oArchivo.p_nombre))
            //    throw new ArgumentNullException("Nombre del Archivo");
            //if (string.IsNullOrEmpty(oArchivo.p_extension))
            //    throw new ArgumentNullException("Extension");
            return cadCeldas.ModificarCeldas(oCeldas);
        }

        //public Archivo TraerArchivo(int cod)
        //{
        //    Archivo oArchivo = cadArchivo.TraerArchivo(cod);
        //    return oArchivo;
        //}
        public int EliminarCeldas(int cod)
        {
            RecepcionDetalle oRecepcionDetalle = new RecepcionDetalle();
            int c = cadCeldas.EliminarCeldas(cod);
            return c;
        }
        public int MarcarEliminado(int cod, int Valor)
        {
            Celdas oMovSync = new Celdas();
            int c = cadCeldas.MarcarEliminado(cod, Valor);
            return c;
        }

        public bool ContieneArchivos(int idCarpeta)
        {
            string where = "Id_carpeta=" + idCarpeta;
            DataSet ds = this.TraerTodoCeldas(where);
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
        public DataSet BuscarCeldas(string nombDocumento)
        {
            return cadCeldas.BuscarCeldas(nombDocumento);
        }
        public DataSet CargarCeldasCombo(int suc)
        {
            return cadCeldas.CargarCeldasCombo(suc);
        }
        public DataSet CargarCeldaAsignada(string item,int suc,int almacen)
        {
            return cadCeldas.CargarCeldaAsignada(item,suc,almacen);
        }
        public DataSet CargarCelda(int almacen)
        {
            return cadCeldas.CargarCeldaAsignada(almacen);
        }
    }
}
