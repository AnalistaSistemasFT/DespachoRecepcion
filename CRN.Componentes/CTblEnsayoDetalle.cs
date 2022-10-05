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
    public class CTblEnsayoDetalle
    {
        CADTblEnsayoDetalle ensdetalle=new CADTblEnsayoDetalle();
        public DataSet retornartblEnsayo(string consulta)
        {
            return null; ensdetalle.RetornarCattblEnsayoDetalle(consulta);
        }

        public void GuardarTblNuevoDetalle(TblEnsayoDetalle data)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                ensdetalle.GuardarTblEnsayoDetalle(data);
                ts.Complete();
            }
        }
        public void ModificarTblNuevoDetalle(TblEnsayoDetalle data)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                ensdetalle.ModificarTBLEnsayoDetalle(data);
                ts.Complete();
            }
        }
        public void EliminarParaInsertar(int id) 
        {
            using (TransactionScope ts = new TransactionScope())
            {
                ensdetalle.EliminarRegsDeta(id);
                ts.Complete();
            }
        
        }
    }
}
