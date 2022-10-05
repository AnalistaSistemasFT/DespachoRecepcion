using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace CRN.Entidades
{
    public class OrdenSync
    {
        private string p_OrdenId;
        private DateTime p_Fecha;
        private string p_CentroTrabajo;
        private DateTime p_FechaCierre;
        private string p_Status;
        private string p_TipoOrden;
        private int p_SucursalId;
        private int p_SucursalDestino;
        private string p_OrdenLigada;
        private string p_ItemFLigado;
        private bool p_EsDeCliente;
        public List<MovProducido> MovProducidoList { get; set; }
        public List<MovConsumido> MovConsumidoList { get; set; }
        public List<Paquetes> ProducidoList { get; set; }
        public List<Paquetes> ConsumidoList { get; set; }
        public List<Consumido> ConsumidoPartList { get; set; }
        public string OrdenId
        {
            get { return p_OrdenId; }
            set { p_OrdenId = value; }
        }
        public DateTime Fecha
        {
            get { return p_Fecha; }
            set { p_Fecha = value; }
        }
        public string CentroTrabajo
        {
            get { return p_CentroTrabajo; }
            set { p_CentroTrabajo = value; }
        }
        public DateTime FechaCierre
        {
            get { return p_FechaCierre; }
            set { p_FechaCierre = value; }
        }
        public string Status
        {
            get { return p_Status; }
            set { p_Status = value; }
        }
        public string TipoOrden
        {
            get { return p_TipoOrden; }
            set { p_TipoOrden = value; }
        }
        public int SucursalId
        {
            get { return p_SucursalId; }
            set { p_SucursalId = value; }
        }
        public int SucursalDestino
        {
            get { return p_SucursalDestino; }
            set { p_SucursalDestino = value; }
        }
        public string OrdenLigada
        {
            get { return p_OrdenLigada; }
            set { p_OrdenLigada = value; }
        }
        public string ItemFLigado
        {
            get { return p_ItemFLigado; }
            set { p_ItemFLigado = value; }
        }
        public bool EsDeCliente
        {
            get { return p_EsDeCliente; }
            set { p_EsDeCliente = value; }
        }

    }

}