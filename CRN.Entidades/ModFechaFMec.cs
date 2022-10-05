using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRN.Entidades
{
    public class ModFechaFMec
    {
        private int p_Id_modFechaFinal;
        private DateTime p_Fecha;
        private int p_Id_servicio;
        private int p_Id_empleado;
        private string p_observacion;

        public int Id_modFechaFinal
        {
            get { return p_Id_modFechaFinal; }
            set { p_Id_modFechaFinal = value; }
        }
        public DateTime Fecha
        {
            get { return p_Fecha; }
            set { p_Fecha = value; }
        }
        public int Id_servicio
        {
            get { return p_Id_servicio; }
            set { p_Id_servicio = value; }
        }
        public int Id_empleado
        {
            get { return p_Id_empleado; }
            set { p_Id_empleado = value; }
        }
        public string observacion
        {
            get { return p_observacion; }
            set { p_observacion = value; }
        }
    }
}
