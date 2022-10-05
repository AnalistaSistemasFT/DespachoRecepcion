using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRN.Entidades
{
    public class Usuario
    {

        #region atributos
        string p_Login;
        string p_Clave;
        string nombre;
        int p_Id_Grupo;
        int p_Activo;
        int p_EmpleadoId;
        int p_Nivel;

        #endregion
      
        #region Propiedades
        public string Nombre 
        {
            get { return nombre; }
            set { nombre = value; }        
        }
        public string Login
        {
            get { return p_Login; }
            set { p_Login = value; }
        }
        public string Clave
        {
            get { return p_Clave; }
            set { p_Clave = value; }
        }

        public int Id_Grupo
        {
            get { return p_Id_Grupo; }
            set { p_Id_Grupo = value; }
        }
        public int Activo
        {
            get { return p_Activo; }
            set { p_Activo = value; }
        }
        public int EmpleadoId
        {
            get { return p_EmpleadoId; }
            set { p_EmpleadoId = value; }
        }
        public int Nivel
        {
            get { return p_Nivel; }
            set { p_Nivel = value; }
        }
        
        #endregion
    }
}
