using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRN.Entidades
{
    public class PartesEnsayos
    {
        private int parametroID;
        private int tipoId;
        private string nombre;
        private bool esformula;
        private string unidad;
        private  bool habilitalimitemin;
        private decimal limiteminaprob;
        private bool habilitalimitemax;
        private decimal limitemaxaprob;
        private string formula;
        private string procedimiento;
        private bool habilitaLimiteTabla;
        private int tablaId;
        private int tipodato;
        private bool obligatorio;
        private string campoTabla;
        private int posicion;       

        public int ParametroID 
        {
            get { return parametroID; }
            set { parametroID = value; }
        }
        public int TipoId 
        {
            get { return tipoId; }
            set { tipoId = value; }        
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }        
        }
        public bool Esformula 
        {
            get { return esformula; }
            set { esformula = value; }        
        }
        public string Unidad 
        {
            get { return unidad; }
            set { unidad = value; }
        }
        public bool Habilitalimitemin 
        {
            get { return habilitalimitemin; }
            set { habilitalimitemin = value; }        
        }
        public decimal Limiteminaprob
        {
            get { return limiteminaprob; }
            set { limiteminaprob = value; }        
        }
        public bool Habilitelimitemax 
        {
            get { return habilitalimitemax; }
            set { habilitalimitemax = value; }        
        }
        public decimal Limitemaxaprob 
        {
            get { return limitemaxaprob; }
            set { limitemaxaprob = value; }        
        }
        public string Formula 
        {
            get { return formula; }
            set { formula = value; }        
        }
        public string Procedimiento
        {
            get { return procedimiento; }
            set { procedimiento = value; }
        }
        public bool Habilitalimitetabla
        {
            get { return habilitaLimiteTabla; }
            set { habilitaLimiteTabla= value; }
        }
        public int TablaId
        {
            get { return tablaId; }
            set { tablaId = value; }
        }
        public int Tipodato
        {
            get { return tipodato; }
            set { tipodato = value; }
        }
        public bool Obligatorio
        {
            get { return obligatorio; }
            set { obligatorio = value; }
        }
        public string Campotabla
        {
            get { return campoTabla; }
            set { campoTabla = value; }
        }
        public int Posicion
        {
            get { return posicion; }
            set { posicion = value; }
        }
    }
}
