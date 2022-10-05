using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRN.Entidades
{
    public class RespuestaMecanizado
    {
        private int p_Id_respuesta_mecanizado;
        private int p_Id_servicio;
        private string p_Estado;
        //Estado=> Aceptado/Negado
        private string p_Observacion;
        //Puede ser Null

        public int Id_respuesta_mecanizado
        {
            get { return p_Id_respuesta_mecanizado; }
            set { p_Id_respuesta_mecanizado = value; }
        }
        public int Id_servicio
        {
            get { return p_Id_servicio; }
            set { p_Id_servicio = value; }
        }
        public string Estado
        {
            get { return p_Estado; }
            set { p_Estado = value; }
        }
        public string Observacion
        {
            get { return p_Observacion; }
            set { p_Observacion = value; }
        }
    }
}
