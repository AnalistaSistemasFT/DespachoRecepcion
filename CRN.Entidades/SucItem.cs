using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRN.Entidades
{
    public class SucItem
    {
        #region atributos
        int p_SucursalId;
        string p_ItemId;
        int p_Stock;
        int p_StckLiberadas;
        int p_stckPaquetes;
        int p_CapVertical;
        int p_CapHorizontal;
        int p_UnidadesXCelda;
        int p_peso;
        int p_piezas;
        decimal p_TotalEntradas;
        decimal p_TotalSalidas;

        #endregion

        #region Propiedades
        public int SucursalId
        {
            get { return p_SucursalId; }
            set { p_SucursalId = value; }
        }
        public string ItemId
        {
            get { return p_ItemId; }
            set { p_ItemId = value; }
        }
        public int Stock
        {
            get { return p_Stock; }
            set { p_Stock = value; }
        }
        public int StckLiberadas
        {
            get { return p_StckLiberadas; }
            set { p_StckLiberadas = value; }
        }
        public int stckPaquetes
        {
            get { return p_stckPaquetes; }
            set { p_stckPaquetes = value; }
        }
        public int CapVertical
        {
            get { return p_CapVertical; }
            set { p_CapVertical = value; }
        }
        public int CapHorizontal
        {
            get { return p_CapHorizontal; }
            set { p_CapHorizontal = value; }
        }
        public int UnidadesXCelda
        {
            get { return p_UnidadesXCelda; }
            set { p_UnidadesXCelda = value; }
        }
        public int peso
        {
            get { return p_peso; }
            set { p_peso = value; }
        }
        public int piezas
        {
            get { return p_piezas; }
            set { p_piezas = value; }
        }
        public decimal TotalEntradas
        {
            get { return p_TotalEntradas; }
            set { p_TotalEntradas = value; }
        }
        public decimal TotalSalidas
        {
            get { return p_TotalSalidas; }
            set { p_TotalSalidas = value; }
        }
        #endregion
    }
}
