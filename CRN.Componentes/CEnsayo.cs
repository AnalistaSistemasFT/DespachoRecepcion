using CAD;
using System.Data;
using System.Transactions;
using CRN.Entidades;
namespace CRN.Componentes
{
    public class CEnsayo
    {
        CADEnsayo ensayos = new CADEnsayo();

        public DataSet retornarEnsayo(string sconsulta)
        {
            return ensayos.RetornarEnsayos(sconsulta);
        }
        public DataSet retornarEnsayo(int iestado,string sCentroId) 
        {
            return ensayos.RetornarEnsayos(iestado, sCentroId);        
        }
        public DataSet retornarEnsayo1()
        {
            return ensayos.RetornarEnsayos1();
        }
        public DataSet retornarEnsayo2()
        {
            return ensayos.RetornarEnsayos2();
        }
        public DataSet cargarComboActualiza(int id) 
        {
            return ensayos.cargarComboActualizar(id);
        }
        public void GuardarEnsayoNuevo(Ensayo  ensayo)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                ensayos.GuardarEnsayo(ensayo);
                ts.Complete();
            }        
        }
        public void ModificarEnsayo(Ensayo ensayo)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                ensayos.ModificarEnsayo(ensayo);
                ts.Complete();
            }
        }
        public DataSet ReturnSUbEnsayos(int fila)
        {
            return ensayos.CargarSubEnsayos(fila);
        }
        public DataSet dataCombo(int i) 
        {
            return ensayos.dataCombos(i);        
        }
        public DataSet retornoSubEnsayoFiltrado(int tipoid) 
        {
            return ensayos.retornoSubEnsayoFiltrado(tipoid);        
        }
        public DataSet retornarEnsayoFiltrado() 
        {
            return ensayos.retornoEnsayosFiltrado();        
        }

        public DataSet retornardetalles(int id)
        {
            return ensayos.retornarDetalles(id);
        }


    }
}
