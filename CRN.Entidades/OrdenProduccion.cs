using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRN.Entidades
{
    public class OrdenProduccion
    {
        private string id_orden;
        private DateTime fecha;
        private int estado;
        private DateTime fechaestado;
        private string itemid;
        private int empleadoid;
        private string centroid;
        private string tipoensayo;
        private int operacion;
        private string Usuario;

        public string ID_Orden 
        {
            get { return id_orden; }
            set { id_orden = value; }        
        }
        public DateTime Fecha 
        {
            get { return fecha; }
            set { fecha = value; }           
        }
        public int Estado 
        {
            get { return estado; }
            set { estado = value; }
        }
        public DateTime FechaEstado 
        {
            get { return fechaestado; }
            set { fechaestado = value; }
        }
        public string ItemId 
        {
            get { return itemid; }
            set { itemid = value; }        
        }
        public int EmpleadoId 
        {
            get { return empleadoid; }
            set { empleadoid = value; }
        
        }
        public string CentroId 
        {
            get { return centroid; }
            set { centroid = value; }
        }
        public string _Usuario
        {
            get { return Usuario; }
            set { Usuario = value; }
        }
        public string TipoEnsayo 
        {
            get { return tipoensayo; }
            set { tipoensayo = value; }
        }
        public int Operacion 
        {
            get { return operacion; }
            set { operacion = value; }        
        }

    }

}
