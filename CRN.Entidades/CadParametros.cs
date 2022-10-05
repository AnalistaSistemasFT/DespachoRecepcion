using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRN.Entidades
{
    public class CadParametros
    {
        private int idparam;
        private string paramdescrip;
        private string tipoparametro;

        public int IdParam 
        {
            get { return idparam; }
            set { idparam = value; }        
        }
        public string ParamDescrip
        {
            get { return paramdescrip; }
            set { paramdescrip = value; }
        }
        public string TipoParam
        {
            get { return tipoparametro; }
            set { tipoparametro = value; }
        }
    }
}
