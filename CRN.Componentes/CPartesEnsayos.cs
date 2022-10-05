using CAD;
using CRN.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace CRN.Componentes
{
    public class CPartesEnsayos
    {
        CADPartesEnsayos partes = new CADPartesEnsayos();
        public void GuardarPartesEnsayos(PartesEnsayos ensayo)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                partes.GuardarPartesEnsayo(ensayo);
                ts.Complete();
            }
        }
        public void EliminarParteEnsayo(int v)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                partes.EliminarParteEnsayo(v);
                ts.Complete();
            }
        }
        public void ModificarParteEnsayo(PartesEnsayos ensayo)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                partes.ModificarParteEnsayo(ensayo);
                ts.Complete();
            }
        }
    }
}
