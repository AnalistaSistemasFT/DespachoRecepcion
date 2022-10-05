using CAD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CRN.Componentes
{
   public  class CFabricante : oledb
    {
        public CFabricante()
        {
            this.sConnName = "SQLSERVER";
        }

        public DataSet SelectFabricante()
        {

            string sInsert = @"  select ProveedorId,Nombre from tblCatProveedor";
            sInsert = string.Format(sInsert);
            return this.consultar(sInsert);
        }
        public DataSet SelectFabricantePorNombre(string sNombre)
        {

            string sInsert = @" select* from tblCatProveedor where Nombre = '"+ sNombre + "'";
            sInsert = string.Format(sInsert);
            return this.consultar(sInsert);
        }

        
    }
}
