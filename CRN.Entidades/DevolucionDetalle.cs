using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRN.Entidades
{
    public class DevolucionDetalle
    {
        private int Id_detalle_devolucion;
        private int Id_devolucion;
        private string Codigo;
        private int CodigoFerro;
        private string Descripcion;
        private int Cantidad;
        private string Unidad;
        private int Reincorporado;
        private string Observaciones;

        public int p_Id_detalle_devolucion
        {
            get { return Id_detalle_devolucion; }
            set { Id_detalle_devolucion = value; }
        }
        public int p_Id_devolucion
        {
            get { return Id_devolucion; }
            set { Id_devolucion = value; }
        }
        public string p_Codigo
        {
            get { return Codigo; }
            set { Codigo = value; }
        }
        public int p_CodigoFerro
        {
            get { return CodigoFerro; }
            set { CodigoFerro = value; }
        }
        public string p_Descripcion
        {
            get { return Descripcion; }
            set { Descripcion = value; }
        }
        public int p_Cantidad
        {
            get { return Cantidad; }
            set { Cantidad = value; }
        }
        public string p_Unidad
        {
            get { return Unidad; }
            set { Unidad = value; }
        }
        public int p_Reincorporado
        {
            get { return Reincorporado; }
            set { Reincorporado = value; }
        }
        public string p_Observaciones
        {
            get { return Observaciones; }
            set { Observaciones = value; }
        }
    }
}
