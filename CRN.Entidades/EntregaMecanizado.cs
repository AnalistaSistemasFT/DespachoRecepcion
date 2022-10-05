using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRN.Entidades
{
    public class EntregaMecanizado
    {
        private int p_Id_entrega;
        private int p_Id_servicio;
        private DateTime p_Fecha_entrega;
        private int p_Cantidad;

        public int Id_entrega
        {
            get { return p_Id_entrega; }
            set { p_Id_entrega = value; }
        }
        public int Id_servicio
        {
            get { return p_Id_servicio; }
            set { p_Id_servicio = value; }
        }
        public DateTime Fecha_entrega
        {
            get { return p_Fecha_entrega; }
            set { p_Fecha_entrega = value; }
        }
        public int Cantidad
        {
            get { return p_Cantidad; }
            set { p_Cantidad = value; }
        }
    }
}
