using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRN.Entidades
{
    public class TblEnsayo
    {
        private int Id_Ensayo;
        private int EnsayoId;
        private DateTime FechaCreacion;
        private int TipoId;       
        private DateTime FechaEjecucion;
        private string OrdenId;
        private string PaqueteId;
        private string Colada; 
        private string ItemId;        
        private int EmpleadoId;   
        private string Obs;      
        private string Resultado;
        private string Status;
        private string TipoGeneracion;
        private int Correlativo;   
        private string CentroId;
        private string Tipo;
        private int Estado;
        private string Usuario;
        public int IDEnsayo
        {
            get { return Id_Ensayo; }
            set { Id_Ensayo = value; }        
        }
        public int EnsayOID
        {
            get { return EnsayoId; }
            set { EnsayoId = value; }
        }
        public DateTime FCreacion
        {
            get { return FechaCreacion; }
            set {FechaCreacion = value; }
        }
        public int TIPOID
        {
            get { return TipoId; }
            set { TipoId= value; }
        }
        public string TIPO
        {
            get { return Tipo; }
            set { Tipo = value; }
        }
        public DateTime FEjecucion
        {
            get { return  FechaEjecucion; }
            set { FechaEjecucion = value; }
        }
        public string ORDENid
        {
            get { return OrdenId; }
            set { OrdenId = value; }
        }
        public string PaqueteID
        {
            get { return PaqueteId; }
            set { PaqueteId = value; }        
        }
        public string COLADA
        {
            get { return Colada; }
            set { Colada = value; }        
        }
        public string ITEMid
        {
            get { return ItemId; }
            set { ItemId = value; }        
        }
        public int EmpleadoID
        {
            get { return EmpleadoId; }
            set { EmpleadoId = value; }        
        }
        public string OBS
        {
            get { return Obs; }
            set { Obs = value; }        
        }
        public string Result
        {
            get { return Resultado; }
            set { Resultado= value; }        
        }
        public string STatus
        {
            get { return Status; }
            set { Status = value; }        
        }
        public string TipoGeneracioN
        {
            get { return TipoGeneracion; }
            set { TipoGeneracion = value; }        
        }
        public int CorrelativO
        {
            get { return Correlativo; }
            set { Correlativo = value; }        
        }
        public string CentroID
        {
            get { return CentroId; }
            set { CentroId = value; }        
        }
        public string _Usuario
        {
            get { return Usuario; }
            set { Usuario = value; }
        }

        public int Estado1 { get => Estado; set => Estado = value; }
    }
}
