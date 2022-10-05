using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRN.Entidades
{
    public class NoConformidad
    {
        private int id_noconforme;
        private DateTime dtfecha_reg;
        private string dtfecha_ide;
        private string dtfecha_cierre;
        private int iareaproceso;
        private int itipo_id;
        private string descripcion;
        private int itipoIncidente_id;
        private string psconsecuencias;
        private string sDoc_relacionado;
        private string sSolucion_inmediata;
        private int iEmitido_por;
        private int iRecibido_por;
        private string sAnalisis_causaraiz;
        private int iencargado_seg;
        private int iestado;
        private int iresultado_id;
        private string sresultado;
        private string sverificacion_eficacia;
        private int iencargado_cierre;
        public int Id_Noconforme 
        {
            get { return id_noconforme; }
            set { id_noconforme = value; }        
        }
        public DateTime DtFecha_reg
        {
            get { return dtfecha_reg; }
            set { dtfecha_reg = value; }
        }
        public string Dtfecha_ide
        {
            get { return dtfecha_ide; }
            set { dtfecha_ide = value; }
        }
        public string Dtfecha_cierre
        {
            get { return dtfecha_cierre; }
            set { dtfecha_cierre = value; }
        }
        public int IAreaProceso
        {
            get { return iareaproceso; }
            set { iareaproceso = value; }
        }
        public int sucursal;


        public int ISucursal
        {
            get { return sucursal; }
            set { sucursal = value; }
        }

        public int Itipo_Id
        {
            get { return itipo_id; }
            set { itipo_id = value; }
        }
        public  string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        public int ITipoIncidente_id
        {
            get { return itipoIncidente_id; }
            set { itipoIncidente_id = value; }
        }
        public string PsConsecuencias
        {
            get { return psconsecuencias; }
            set { psconsecuencias = value; }
        }
        public string SDoc_relacionado
        {
            get { return sDoc_relacionado; }
            set { sDoc_relacionado = value; }
        }
        public string SSolucion_Inmediata
        {
            get { return sSolucion_inmediata; }
            set { sSolucion_inmediata = value; }
        }
        public int IEmitido_por
        {
            get { return iEmitido_por; }
            set { iEmitido_por = value; }
        }
        public int IRecibido_por
        {
            get { return iRecibido_por; }
            set { iRecibido_por = value; }
        }
        public string SAnalisis_Causaraiz
        {
            get { return sAnalisis_causaraiz; }
            set { sAnalisis_causaraiz = value; }
        }
        public int IEncargado_seg
        {
            get { return iencargado_seg; }
            set { iencargado_seg = value; }
        }
        public int IEstado
        {
            get { return iestado; }
            set { iestado = value; }
        }
        public int IResultado_id
        {
            get { return iresultado_id; }
            set { iresultado_id = value; }
        }
        public string SResultado
        {
            get { return sresultado; }
            set { sresultado = value; }
        }
        public string SVerificacion_eficacia
        {
            get { return sverificacion_eficacia; }
            set { sverificacion_eficacia = value; }
        }
        public int IEncargado_cierre
        {
            get { return iencargado_cierre; }
            set { iencargado_cierre = value; }
        }



    }
}
