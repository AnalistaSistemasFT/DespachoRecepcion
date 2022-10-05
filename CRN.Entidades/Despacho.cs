using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRN.Entidades
{
    public class Despacho
    {
        #region atributos
        private string DespachoId;
        private DateTime Fecha;
        private string NroOrden;
        private int Id_Camion;
        private string Placa;
        private string Marca;
        private string Chofer;
        private string CI;
        private string Destino;
        private string Login;
        private string status;
        private int Correlativo;
        private string Obs;
        private string Tipo;
        private string Cargador;
        private string NumTraspaso;
        private int SucursalId;
        private int SucDestino;
        private DateTime HorarioPartida;
        private DateTime HorarioLlegada;
        private string Naturaleza;
        private int Anticipado;
        private int TipoDoc;
        private int Entregado;

        #endregion

        #region Propiedades
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
        public string p_NroOrden
        {
            get { return NroOrden; }
            set { NroOrden = value; }
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
        public string p_Destino
        {
            get { return Destino; }
            set { Destino = value; }
        }
        public string p_Login
        {
            get { return Login; }
            set { Login = value; }
        }
        public string p_status
        {
            get { return status; }
            set { status = value; }
        }
        public int p_Correlativo
        {
            get { return Correlativo; }
            set { Correlativo = value; }
        }
        public string p_Obs
        {
            get { return Obs; }
            set { Obs = value; }
        }

        public string p_Tipo
        {
            get { return Tipo; }
            set { Tipo = value; }
        }
        public string p_Cargador
        {
            get { return Cargador; }
            set { Cargador = value; }
        }
        public string p_NumTraspaso
        {
            get { return NumTraspaso; }
            set { NumTraspaso = value; }
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
        public DateTime p_HorarioPartida
        {
            get { return HorarioPartida; }
            set { HorarioPartida = value; }
        }
        public DateTime p_HorarioLlegada
        {
            get { return HorarioLlegada; }
            set { HorarioLlegada = value; }
        }
        public string p_Naturaleza
        {
            get { return Naturaleza; }
            set { Naturaleza = value; }
        }
        public int p_Anticipado
        {
            get { return Anticipado; }
            set { Anticipado = value; }
        }
        public int p_TipoDoc
        {
            get { return TipoDoc; }
            set { TipoDoc = value; }
        }
        public int p_Entregado
        {
            get { return Entregado; }
            set { Entregado = value; }
        }
        #endregion
    }
}
