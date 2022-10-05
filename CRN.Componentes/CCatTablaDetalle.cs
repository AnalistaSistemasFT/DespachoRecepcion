using CAD;
using CRN.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace CRN.Componentes
{
    public class CCatTablaDetalle
    {
        CADCatTablaDetalle cattabla = new CADCatTablaDetalle();

        public void GuardarTablaDetalle (CatTablaDetalle ensayo)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                cattabla.GuardarCatTablaDetalle(ensayo);
                ts.Complete();
            }
        }

        public void ModificarCatTablaDetalle(CatTablaDetalle ensayo)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                cattabla.ModificarCatTablaDetalle(ensayo);
                ts.Complete();
            }
        }
        public void Eliminar(int idt)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                cattabla.EliminarDespDetalle(idt);
                ts.Complete();
            }
        }
    }
}
