using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRN.Entidades
{
   public class Sucursal
    {
        #region atributos
        private int p_SucursalId;
        private string p_Nombre;
        private string p_Dpto;
        private string p_Direccion;
        private string p_Contacto;
        private int p_Adscrita;
        private int p_Elsystem;
        private int p_Ferrotodo;
        private int p_Inventario;
        private string p_SyncPC;
        private int p_Prefijo;
        private int p_SucIdTransito;
        private int p_TraspasoDirecto;
        private int p_EsTransito;
        private string p_Plantap_Elsystem;
        private string p_Id_AX;


        #endregion

        #region Propiedades
        public int SucursalId
        {
            get { return p_SucursalId; }
            set { p_SucursalId = value; }
        }

        public string Nombre
        {
            get { return p_Nombre; }
            set { p_Nombre = value; }
        }

        public string Dpto
        {
            get { return p_Dpto; }
            set { p_Dpto = value; }
        }
        public string Direccion
        {
            get { return p_Direccion; }
            set { p_Direccion = value; }
        }

        public string Contacto
        {
            get { return p_Contacto; }
            set { p_Contacto = value; }
        }
        public int Adscrita
        {
            get { return p_Adscrita; }
            set { p_Adscrita = value; }
        }
        public int Elsystem
        {
            get { return p_Elsystem; }
            set { p_Elsystem = value; }
        }
        public int Ferrotodo
        {
            get { return p_Ferrotodo; }
            set { p_Ferrotodo = value; }
        }
        public int Inventario
        {
            get { return p_Inventario; }
            set { p_Inventario = value; }
        }
        public string SyncPC
        {
            get { return p_SyncPC; }
            set { p_SyncPC = value; }
        }
        public int Prefijo
        {
            get { return p_Prefijo; }
            set { p_Prefijo = value; }
        }
        public int SucIdTransito
        {
            get { return p_SucIdTransito; }
            set { p_SucIdTransito = value; }
        }
        public int TraspasoDirecto
        {
            get { return p_TraspasoDirecto; }
            set { p_TraspasoDirecto = value; }
        }
        public int EsTransito
        {
            get { return p_EsTransito; }
            set { p_EsTransito = value; }
        }
        public string Plantap_Elsystem
        {
            get { return p_Plantap_Elsystem; }
            set { p_Plantap_Elsystem = value; }
        }

        public string Id_AX
        {
            get { return p_Id_AX; }
            set { p_Id_AX = value; }
        }
        #endregion
    }
}
