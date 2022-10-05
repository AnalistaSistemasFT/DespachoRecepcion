using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAD
{
    public class CADTransaction : oledb
    {
        public CADTransaction()
        {
            this.sConnName = "SQLSERVER";
        }
        public System.Data.Common.DbTransaction IniciarTrn()
        {
            return inicio_tr();
        }

        public void CerrarTrn(System.Data.Common.DbTransaction Trn)
        {
            //Trn.Dispose();
            Trn.Commit();
        }

        public void DeshacerTrn(System.Data.Common.DbTransaction Trn)
        {
            Trn.Rollback();
        }
    }
}
