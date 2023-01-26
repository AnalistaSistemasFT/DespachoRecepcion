using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRN.Entidades
{
    public class Devolucion
    {
        private int Id_Devolucion;
        private int Cod_cliente;
        private string Nom_cliente;
        private int Sucursal;
        private decimal Monto;
        private int Vendedor;
        private DateTime Fecha_entrega;
        private DateTime Fecha_recepcion;
        private string Chofer;
        private string Placa;
        private string OrdenVenta;
        private string NuevaOrdenVenta;
        private string Motivo;

        public int p_Id_Devolucion
        {
            get { return Id_Devolucion; }
            set { Id_Devolucion = value; }
        }
        public int p_Cod_cliente
        {
            get { return Cod_cliente; }
            set { Cod_cliente = value; }
        }
        public string p_Nom_cliente
        {
            get { return Nom_cliente; }
            set { Nom_cliente = value; }
        }
        public int p_Sucursal
        {
            get { return Sucursal; }
            set { Sucursal = value; }
        }
        public decimal p_Monto
        {
            get { return Monto; }
            set { Monto = value; }
        }
        public int p_Vendedor
        {
            get { return Vendedor; }
            set { Vendedor = value; }
        }
        public DateTime p_Fecha_entrega
        {
            get { return Fecha_entrega; }
            set { Fecha_entrega = value; }
        }
        public DateTime p_Fecha_recepcion
        {
            get { return Fecha_recepcion; }
            set { Fecha_recepcion = value; }
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
        public string p_OrdenVenta
        {
            get { return OrdenVenta; }
            set { OrdenVenta = value; }
        }
        public string p_NuevaOrdenVenta
        {
            get { return NuevaOrdenVenta; }
            set { NuevaOrdenVenta = value; }
        }
        public string p_Motivo
        {
            get { return Motivo; }
            set { Motivo = value; }
        }
    }
}
