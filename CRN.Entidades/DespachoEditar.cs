using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRN.Entidades
{
    public class DespachoEditar
    {
        private string DespachoId;
        private DateTime Fecha;
        private int Id_Camion;
        private string Placa;
        private string Marca;
        private string Chofer;
        private string CI; 
        private string Obs;
        private int SucursalId;
        private int SucDestino;
        private string Naturaleza;

        public string p_DespachoId
        {
            get { return DespachoId; }
            set { DespachoId = value; }
        }
        public DateTime p_Fecha
        {
            get { return Fecha; }
            set { Fecha = value; }
        }
        public int p_Id_Camion
        {
            get { return Id_Camion; }
            set { Id_Camion = value; }
        }
        public string p_Placa
        {
            get { return Placa; }
            set { Placa = value; }
        }
        public string p_Marca
        {
            get { return Marca; }
            set { Marca = value; }
        }
        public string p_Chofer
        {
            get { return Chofer; }
            set { Chofer = value; }
        }
        public string p_CI
        {
            get { return CI; }
            set { CI = value; }
        } 
        public string p_Obs
        {
            get { return Obs; }
            set { Obs = value; }
        }
        public int p_SucursalId
        {
            get { return SucursalId; }
            set { SucursalId = value; }
        }
        public int p_SucDestino
        {
            get { return SucDestino; }
            set { SucDestino = value; }
        }
        public string p_Naturaleza
        {
            get { return Naturaleza; }
            set { Naturaleza = value; }
        }
    }
}
