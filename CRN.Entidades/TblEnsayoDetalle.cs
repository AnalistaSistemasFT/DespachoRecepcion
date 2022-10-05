using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRN.Entidades
{
    public class TblEnsayoDetalle
    {
        private int Id_Ensayo;
        private string descripcion;
        private int ParametroId;
        private int EnsayoId;
        private string Valor;
        private string Status;
        private string Limites;
        private string tipodato;


        public string Descripcion 
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        public int ID_ensayo 
        {
            get { return Id_Ensayo; }
            set { Id_Ensayo = value; }        
        }
        public int Param_ID
        {
            get { return ParametroId; }
            set { ParametroId = value; }
        }
        public int Ensayo_ID
        {
            get { return EnsayoId; }
            set { EnsayoId = value; }
        }
        public string ValoR
        {
            get { return Valor; }
            set {Valor = value; }
        }
        public string StatuS
        {
            get { return Status; }
            set { Status = value; }
        }
        public string Limite
        {
            get { return Limites; }
            set { Limites = value; }
        }
        public string TipoDato
        {
            get { return tipodato; }
            set { tipodato = value; }
        }


    }
}
