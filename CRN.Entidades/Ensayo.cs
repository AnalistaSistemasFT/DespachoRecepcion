using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRN.Entidades
{
    public class Ensayo
    {
        private int TipoID;
        private string Descripcion ;
        private int frecuencia ;
        private int UnidadFrecuencia ;
        private string Grupo ;
        private int TomasXFrecuencia;
        private int Operacion;

        public int TipoId 
        {
            get { return TipoID; }
            set { TipoID = value; }
        }
        public string DescripcioN
        {
            get { return Descripcion; }
            set { Descripcion = value; }
        }
        public int  Frecuencia
        {
            get { return frecuencia; }
            set { frecuencia = value; }
        }
        public int UnidadFrecenciA
        {
            get { return UnidadFrecuencia; }
            set { UnidadFrecuencia = value; }
        }
        public string GrupO
        {
            get { return Grupo; }
            set {Grupo = value; }
        }
        public int TomasXFrrecuenciA
        {
            get { return TomasXFrecuencia; }
            set { TomasXFrecuencia = value; }
        }
        public int OperacioneS
        {
            get { return Operacion; }
            set { Operacion = value; }
        }
    }
}
