using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRN.Entidades
{
    public class CatCamion
    {
        private string Id_Camion;
        private string Placa;
        private string Marca;
        private decimal Capacidad;

        public string _Id_Camion
        {
            get { return Id_Camion; }
            set { Id_Camion = value; }
        }
        public string _Placa
        {
            get { return Placa; }
            set { Placa = value; }
        }
        public string _Marca
        {
            get { return Marca; }
            set { Marca = value; }
        }
        public decimal _Capacidad
        {
            get { return Capacidad; }
            set { Capacidad = value; }
        }
    }
}
