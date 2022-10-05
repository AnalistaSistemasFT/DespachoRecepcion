using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRN.Entidades
{
    public class OrdenEntrega
    {
        private int Id_orden_entrega;
        private string DespachoId;
        private DateTime Fecha_salida;
        private DateTime Fecha_llegada;
        private string Chofer;
        private string Placa;
        private int Origen_Id;
        private int Destino_Id;
        private string Login;
        private int Cantidad_total;
        private decimal Peso_total;
        private string Estado;
        private string Tipo_entrega;
        private string Obs;

        public int p_Id_orden_entrega
        {
            get { return Id_orden_entrega; }
            set { Id_orden_entrega = value; }
        }
        public string p_DespachoId
        {
            get { return DespachoId; }
            set { DespachoId = value; }
        }
        public DateTime p_Fecha_salida
        {
            get { return Fecha_salida; }
            set { Fecha_salida = value; }
        }
        public DateTime p_Fecha_llegada
        {
            get { return Fecha_llegada; }
            set { Fecha_llegada = value; }
        }
        public string p_Chofer
        {
            get { return Chofer; }
            set { Chofer = value; }
        }
        public string p_Placa
        {
            get { return Placa; }
            set { Placa = value; }
        }
        public int p_Origen_Id
        {
            get { return Origen_Id; }
            set { Origen_Id = value; }
        }
        public int p_Destino_Id
        {
            get { return Destino_Id; }
            set { Destino_Id = value; }

        }
        public string p_Login
        {
            get { return Login; }
            set { Login = value; }
        }
        public int p_Cantidad_total
        {
            get { return Cantidad_total; }
            set { Cantidad_total = value; }
        }
        public decimal p_Peso_total
        {
            get { return Peso_total; }
            set { Peso_total = value; }
        }
        public string p_Estado
        {
            get { return Estado; }
            set { Estado = value; }
        }
        public string p_Tipo_entrega
        {
            get { return Tipo_entrega; }
            set { Tipo_entrega = value; }
        }
        public string p_Obs
        {
            get { return Obs; }
            set { Obs = value; }

        }
    }
}
