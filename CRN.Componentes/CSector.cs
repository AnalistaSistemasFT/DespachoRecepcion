using CAD;
using CRN.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Transactions;

namespace CRN.Componentes
{
    public class CSector
    {
        CADSector cadsec = new CADSector();
        public DataSet retornarTabla(string consulta)
        {
            return cadsec.EjecutarConsult(consulta);
        }

        public void GuardarParam(Sector sec)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                cadsec.GuardarSector(sec);
                ts.Complete();
            }
        }
        public bool SentenciaEjecut(string sql) 
        {
            if (cadsec.EjecutarSentencia(sql) == 1)
                return true;
            else
                return false;

            
            
        }




    }
}
