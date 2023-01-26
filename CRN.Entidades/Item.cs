using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRN.Entidades
{
    public class Item
    {
        #region atributos
       
        string p_ItemId;
        string p_Descripcion;
        decimal p_CapKilos;
        int p_CapVertical;
        int p_CapHorizontal;
        decimal p_PesoPaq;
        int p_Piezas;
        decimal p_Ancho;
        string p_GrupoId;
        string p_ItemFId;
        string p_Calidad;
        decimal p_Espesor;
        string p_Uso;
        int p_Presentacion;
        int p_TipoMaterial;
        string p_Unidad;
        int p_Piramide;
        int p_UnidadesXCelda;
        string p_UnidadCalculo;
        int p_Caducidad;
        int p_Id_DimSeguimiento;
        int p_Id_TipoGalvanizado;
        #endregion

        #region Propiedades
        public string ItemId
        {
            get { return p_ItemId; }
            set { p_ItemId = value; }
        }
        public string Descripcion
        {
            get { return p_Descripcion; }
            set { p_Descripcion = value; }
        }
        public Decimal CapKilos
        {
            get { return p_CapKilos; }
            set { p_CapKilos = value; }
        }
        public int CapHorizontal
        {
            get { return p_CapHorizontal; }
            set { p_CapHorizontal = value; }
        }
           public int CapVertical
        {
            get { return p_CapVertical; }
            set { p_CapVertical = value; }
        }
        public decimal PesoPaq
        {
            get { return p_PesoPaq; }
            set { p_PesoPaq = value; }
        }
        public int Piezas
        {
            get { return p_Piezas; }
            set { p_Piezas = value; }
        }
        public decimal Ancho
        {
            get { return p_Ancho; }
            set { p_Ancho = value; }
        }
        public string GrupoId
        {
            get { return p_GrupoId; }
            set { p_GrupoId = value; }
        }
        public string ItemFId
        {
            get { return p_ItemFId; }
            set { p_ItemFId = value; }
        }
        public string Calidad
        {
            get { return p_Calidad; }
            set { p_Calidad = value; }
        }
        public decimal Espesor
        {
            get { return p_Espesor; }
            set { p_Espesor = value; }
        }
        public string Uso
        {
            get { return p_Uso; }
            set { p_Uso = value; }
        }
        public int Presentacion
        {
            get { return p_Presentacion; }
            set { p_Presentacion = value; }
        }
        public int TipoMaterial
          {
              get { return p_TipoMaterial; }
              set { p_TipoMaterial = value; }
          }
        public string Unidad
        {
            get { return p_Unidad; }
            set { p_Unidad = value; }
        }
        public int Piramide
        {
            get { return p_Piramide; }
            set { p_Piramide = value; }
        }
        public int UnidadesXCelda
        {
            get { return p_UnidadesXCelda; }
            set { p_UnidadesXCelda = value; }
        }
        public string UnidadCalculo
        {
            get { return p_UnidadCalculo; }
            set { p_UnidadCalculo = value; }
        }

        public int Caducidad
        {
            get { return p_Caducidad; }
            set { p_Caducidad = value; }
        }

        public int Id_DimSeguimiento
        {
            get { return p_Id_DimSeguimiento; }
            set { p_Id_DimSeguimiento = value; }
        }

        public int Id_TipoGalvanizado
        {
            get { return p_Id_TipoGalvanizado; }
            set { p_Id_TipoGalvanizado = value; }
        }

        

        #endregion
    }
}
