using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Transactions;
using CRN.Entidades;
using CAD;

namespace CRN.Componentes
{
    public class CRecepcionProductosDel
    {
        CADRecepcionProductosDel cadRecepcionProductosDel = new CADRecepcionProductosDel();

        public void GuardarRecepcionProductosDel(RecepcionProductosDel oRecepcionProductosDel)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                cadRecepcionProductosDel.GuardarRecepcionProductosDel(oRecepcionProductosDel);
                ts.Complete();
            }
        }


        public void ModificarRecepcionProducto(RecepcionProductosDel  oRecepcionProducto)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                cadRecepcionProductosDel.ModificarRecepcionProductoDel(oRecepcionProducto);
                ts.Complete();
            }
        }


        public void EliminarRecepcionProducto(string ProductoId, string RecepcionId)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                cadRecepcionProductosDel.EliminarRecepcionProductoDel(ProductoId, RecepcionId);
                ts.Complete();
            }
        }
    }
}
