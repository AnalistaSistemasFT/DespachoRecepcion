using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRN.Entidades
{
    public class ServicioMecanizado
    {
        private int p_Id_servicio_mecanizado;
        private int p_Id_solicitante;
        private DateTime p_Fecha;
        private string p_Centro_trabajo;
        private int p_Prioridad;
        private int p_Producto;
        private string p_Descripcion;
        private int p_Cantidad;
        //private Bitmap p_Muestra_img;
        //private Bitmap p_Plano_img;
        private string p_Material;
        private string p_Dureza;
        private string p_Otros;
        private DateTime p_Fecha_Finalizacion;
        private int p_Estado;
        //Estado=> Pendiente / Proceso / Parcial / Finalizado
        private int p_Id_empleado;
        private int p_Cantidad_pendiente;

        public int Id_servicio_mecanizado
        {
            get { return p_Id_servicio_mecanizado; }
            set { p_Id_servicio_mecanizado = value; }
        }
        public int Id_solicitante
        {
            get { return p_Id_solicitante; }
            set { p_Id_solicitante = value; }
        }
        public DateTime Fecha
        {
            get { return p_Fecha; }
            set { p_Fecha = value; }
        }
        public string Centro_trabajo
        {
            get { return p_Centro_trabajo; }
            set { p_Centro_trabajo = value; }
        }
        public int Prioridad
        {
            get { return p_Prioridad; }
            set { p_Prioridad = value; }
        }
        public int Producto
        {
            get { return p_Producto; }
            set { p_Producto = value; }
        }
        public string Descripcion
        {
            get { return p_Descripcion; }
            set { p_Descripcion = value; }
        }
        public int Cantidad
        {
            get { return p_Cantidad; }
            set { p_Cantidad = value; }
        }
        //public Bitmap Muestra_img
        //{
        //    get { return p_Muestra_img; }
        //    set { p_Muestra_img = value; }
        //}
        //public Bitmap Plano_img
        //{
        //    get { return p_Plano_img; }
        //    set { p_Plano_img = value; }
        //}
        public string Material
        {
            get { return p_Material; }
            set { p_Material = value; }
        }
        public string Dureza
        {
            get { return p_Dureza; }
            set { p_Dureza = value; }
        }
        public string Otros
        {
            get { return p_Otros; }
            set { p_Otros = value; }
        }
        public DateTime Fecha_Finalizacion
        {
            get { return p_Fecha_Finalizacion; }
            set { p_Fecha_Finalizacion = value; }
        }
        public int Estado
        {
            get { return p_Estado; }
            set { p_Estado = value; }
        }
        public int Id_empleado
        {
            get { return p_Id_empleado; }
            set { p_Id_empleado = value; }
        }
        public int Cantidad_pendiente
        {
            get { return p_Cantidad_pendiente; }
            set { p_Cantidad_pendiente = value; }
        }
    }
}
