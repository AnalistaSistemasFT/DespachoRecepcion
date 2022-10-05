using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRN.Entidades
{
    public class PaquetesRotos
    {
        private string p_PaqueteId;
        private int p_SucursalId;
        private int p_AlmacenId;
        private DateTime p_Fecha;
        private string p_CeldaId;
        private int p_Nivel;
        private string p_ItemId;
        private string p_Login;
        private string p_status;
        private decimal p_Peso;
        private int p_Piezas;
        private string p_OrdenId;
        private string p_Contenedor;
        private string p_Colada;
        private string p_CentroTrabajo;
        private string p_ItemFId;
        private decimal p_Metros;
        private DateTime p_FechaVenc;
        private int p_CantOriginal;
        ///////////////////////////
        public string PaqueteId
        {
            get { return p_PaqueteId; }
            set { p_PaqueteId = value; }
        }
        public DateTime Fecha
        {
            get { return p_Fecha; }
            set { p_Fecha = value; }
        }
        public int SucursalId
        {
            get { return p_SucursalId; }
            set { p_SucursalId = value; }
        }
        public int AlmacenId
        {
            get { return p_AlmacenId; }
            set { p_AlmacenId = value; }
        }
        public string CeldaId
        {
            get { return p_CeldaId; }
            set { p_CeldaId = value; }
        }
        public int Nivel
        {
            get { return p_Nivel; }
            set { p_Nivel = value; }
        }
        public string ItemId
        {
            get { return p_ItemId; }
            set { p_ItemId = value; }
        }
        public string Login
        {
            get { return p_Login; }
            set { p_Login = value; }
        }
        public string status
        {
            get { return p_status; }
            set { p_status = value; }
        }
        public decimal Peso
        {
            get { return p_Peso; }
            set { p_Peso = value; }
        }
        public int Piezas
        {
            get { return p_Piezas; }
            set { p_Piezas = value; }
        }
        public string OrdenId
        {
            get { return p_OrdenId; }
            set { p_OrdenId = value; }
        }
        public string Contenedor
        {
            get { return p_Contenedor; }
            set { p_Contenedor = value; }
        }
        public string Colada
        {
            get { return p_Colada; }
            set { p_Colada = value; }
        }
        public string CentroTrabajo
        {
            get { return p_CentroTrabajo; }
            set { p_CentroTrabajo = value; }
        }
        public string ItemFId
        {
            get { return p_ItemFId; }
            set { p_ItemFId = value; }
        }
        public decimal Metros
        {
            get { return p_Metros; }
            set { p_Metros = value; }
        }
        public DateTime FechaVenc
        {
            get { return p_FechaVenc; }
            set { p_FechaVenc = value; }
        }
        public int CantOriginal
        {
            get { return p_CantOriginal; }
            set { p_CantOriginal = value; }
        }
    }
}
