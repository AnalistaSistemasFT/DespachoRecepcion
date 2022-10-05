using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRN.Entidades
{
    public class CatTabla
    {
        private int tablaID;
        private string descripcion;
        private string tipoProducto;
        private string campo;
        private string unidad;
        public int TtablaId
        {
            get { return tablaID; }
            set { tablaID = value; }
        }
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        public string TipoProducto
        {
            get { return tipoProducto; }
            set {  tipoProducto = value; }
        }
        public string Campo
        {
            get { return campo; }
            set { campo = value; }
        }
        public string Unidad
        {
            get { return unidad; }
            set { unidad = value; }
        }
        
    }
}
