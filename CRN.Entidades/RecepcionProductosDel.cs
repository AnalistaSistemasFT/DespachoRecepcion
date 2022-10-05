using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Configuration;
using System.Data;
using System.Data.Common;
using CRN.Entidades;

namespace CRN.Entidades
{
    public class RecepcionProductosDel
    {
        private string p_RecepcionId;
        private string p_ProductoId;
        private string p_Fabricante;
        private string p_ItemId;
        private int p_Piezas;
        private decimal p_Peso;
        private string p_Colada;
        private int p_SucursalId;
        private int p_AlmacenId;
        private string p_CeldaId;
        private DateTime p_Fecha;
        private DateTime p_FechaEliminacion;
        private int p_Correlativo;
        private string p_Login;
        private string p_Status;
        private string p_CodPackList;
        private decimal p_PesoNetoProveedor;
        private decimal p_PesoBrutoProveedor;
        private bool p_EsDeCliente;
        private int p_Id_TipoObservacion;

        public string RecepcionId
        {
            get { return p_RecepcionId; }
            set { p_RecepcionId = value; }
        }
        public string ProductoId
        {
            get { return p_ProductoId; }
            set { p_ProductoId = value; }
        }
        public string Fabricante
        {
            get { return p_Fabricante; }
            set { p_Fabricante = value; }
        }
        public string ItemId
        {
            get { return p_ItemId; }
            set { p_ItemId = value; }
        }
        public int Piezas
        {
            get { return p_Piezas; }
            set { p_Piezas = value; }
        }
        public decimal Peso
        {
            get { return p_Peso; }
            set { p_Peso = value; }
        }
        public string Colada
        {
            get { return p_Colada; }
            set { p_Colada = value; }
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
        public DateTime Fecha
        {
            get { return p_Fecha; }
            set { p_Fecha = value; }
        }
        public DateTime FechaEliminacion
        {
            get { return p_FechaEliminacion; }
            set { p_FechaEliminacion = value; }
        }
        public int Correlativo
        {
            get { return p_Correlativo; }
            set { p_Correlativo = value; }
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
        public string CodPackList
        {
            get { return p_CodPackList; }
            set { p_CodPackList = value; }
        }
        public decimal PesoNetoProveedor
        {
            get { return p_PesoNetoProveedor; }
            set { p_PesoNetoProveedor = value; }
        }
        public decimal PesoBrutoProveedor
        {
            get { return p_PesoBrutoProveedor; }
            set { p_PesoBrutoProveedor = value; }
        }
        public bool EsDeCliente
        {
            get { return p_EsDeCliente; }
            set { p_EsDeCliente = value; }
        }
        public int Id_TipoObservacion
        {
            get { return p_Id_TipoObservacion; }
            set { p_Id_TipoObservacion = value; }
        }
    }
}
