using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRN.Entidades
{
    public class Movimiento
    {
        #region atributos
        string p_MovimientoId;
        DateTime p_Fecha;
        string p_TipoMovimiento;
        string p_Comprobante;
        string p_Login;
        string p_Status;
        int p_SucursalId;
        int p_SucursalEnTraspaso;
        decimal p_Correlativo;
        string p_Obs;
        string p_OrdenLigada;
        string p_ItemFLigado;
        int p_TransEnTraspaso;
        List<MovDetalle> detalle;

        #endregion

        #region Propiedades
        public string MovimientoId
        {
            get { return p_MovimientoId; }
            set { p_MovimientoId = value; }
        }

        public DateTime Fecha
        {
            get { return p_Fecha; }
            set { p_Fecha = value; }
        }

        public string TipoMovimiento
        {
            get { return p_TipoMovimiento; }
            set { p_TipoMovimiento = value; }
        }

        public string Comprobante
        {
            get { return p_Comprobante; }
            set { p_Comprobante = value; }
        }

        public string Login
        {
            get { return p_Login; }
            set { p_Login = value; }
        }
        public string Status
        {
            get { return p_Status; }
            set { p_Status = value; }
        }
        public int SucursalId
        {
            get { return p_SucursalId; }
            set { p_SucursalId = value; }
        }
        public int SucursalEnTraspaso
        {
            get { return p_SucursalEnTraspaso; }
            set { p_SucursalEnTraspaso = value; }
        }
        public decimal Correlativo
        {
            get { return p_Correlativo; }
            set { p_Correlativo = value; }
        }
        public string Obs
        {
            get { return p_Obs; }
            set { p_Obs = value; }
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
        public int TransEnTraspaso
        {
            get { return p_TransEnTraspaso; }
            set { p_TransEnTraspaso = value; }
        }
    public List<MovDetalle> Detalle
    {
        get { return this.detalle; }
        set {this.detalle = value; }
    }

        //Constructor: inicialización
     public Movimiento()
    {
        this.detalle = new List<MovDetalle>();
    }   
        #endregion
    }
}
