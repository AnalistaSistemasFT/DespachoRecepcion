using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRN.Entidades
{
    public class UserSuc
    {
        #region atributos
        string p_Login;
        int p_SucursalId;
        int p_Activo;
        #endregion

        #region Propiedades
        public string Login
        {
            get { return p_Login; }
            set { p_Login = value; }
        }
        public int SucursalId
        {
            get { return p_SucursalId; }
            set { p_SucursalId = value; }
        }
        public int Activo
        {
            get { return p_Activo; }
            set { p_Activo = value; }
        }
       
        #endregion

    }
}
