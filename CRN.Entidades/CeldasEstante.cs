using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRN.Entidades
{
    public class CeldasEstante
    {
        private string CodigoEstante;
        private string CeldaId;
        private int Piso;
        private string Columna;
        private int Unidades;
        private decimal Kgs;
        private decimal Max_Kgs;
        private int Status;
        private int AlmacenId;
        private int Fila;

        public string p_CodigoEstante
        {
            get { return CodigoEstante; }
            set { CodigoEstante = value; }
        }
        public string p_CeldaId
        {
            get { return CeldaId; }
            set { CeldaId = value; }
        }
        public int p_Piso
        {
            get { return Piso; }
            set { Piso = value; }
        }
        public string p_Columna
        {
            get { return Columna; }
            set { Columna = value; }
        }
        public int p_Unidades
        {
            get { return Unidades; }
            set { Unidades = value; }
        }
        public decimal p_Kgs
        {
            get { return Kgs; }
            set { Kgs = value; }
        }
        public decimal p_Max_Kgs
        {
            get { return Max_Kgs; }
            set { Max_Kgs = value; }
        }
        public int p_Status
        {
            get { return Status; }
            set { Status = value; }
        }
        public int p_AlmacenId
        {
            get { return AlmacenId; }
            set { AlmacenId = value; }
        }
        public int p_Fila
        {
            get { return Fila; }
            set { Fila = value; }
        }
    }
}
