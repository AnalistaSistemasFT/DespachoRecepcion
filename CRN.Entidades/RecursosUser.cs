using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRN.Entidades
{
    public class RecursosUser
    {
        #region atributos
        int RecursoId;
        string Descripcion;
        string Aplicacion;
        string NombreForm;
        string NombreMenu;
        string Padre;
        string Path;
        int Id_Recursos;
        int ModuloId;
        string Nombre;
        int Orden;
        int Habilita_Altas;
        int Habilita_Cambios;
        int Habilita_Bajas;
        int Habilita_Consultas;
        int Habilita_Reportes;
        int Habilita_Procesos;
        string Imagen;

        #endregion

        #region Propiedades
        public int p_RecursoId
        {
            get { return RecursoId; }
            set { RecursoId = value; }
        }

        public string p_Descripcion
        {
            get { return Descripcion; }
            set { Descripcion = value; }
        }

        public string p_Aplicacion
        {
            get { return Aplicacion; }
            set { Aplicacion = value; }
        }
        public string p_NombreForm
        {
            get { return NombreForm; }
            set { NombreForm = value; }
        }
        public string p_NombreMenu
        {
            get { return NombreMenu; }
            set { NombreMenu = value; }
        }
        
        public string p_Padre
        {
            get { return Padre; }
            set { Padre = value; }
        }

        public string p_Path
        {
            get { return Path; }
            set { Path = value; }
        }



        public int p_Id_Recursos
        {
            get { return Id_Recursos; }
            set { Id_Recursos = value; }
        }

        public int p_Id_ModuloId
        {
            get { return ModuloId; }
            set { ModuloId = value; }
        }
        public string p_Nombre
        {
            get { return Nombre; }
            set { Nombre = value; }
        }
        public int p_Orden
        {
            get { return Orden; }
            set { Orden = value; }
        }
        public int p_Habilita_Altas
        {
            get { return  Habilita_Altas; }
            set {  Habilita_Altas = value; }
        }
        public int p_Habilita_Cambios
        {
            get { return Habilita_Cambios; }
            set { Habilita_Cambios = value; }
        }
        public int p_Habilita_Bajas
        {
            get { return Habilita_Bajas; }
            set { Habilita_Bajas = value; }
        }
        public int p_Habilita_Consultas
        {
            get { return Habilita_Consultas; }
            set { Habilita_Consultas = value; }
        }
        public int p_Habilita_Reportes
        {
            get { return Habilita_Reportes; }
            set { Habilita_Reportes = value; }
        }
        public int p_Habilita_Procesos
        {
            get { return Habilita_Procesos; }
            set { Habilita_Procesos = value; }
        }
        public string p_Imagen
        {
            get { return Imagen; }
            set { Imagen = value; }
        }
        #endregion
    }
}
