using CAD;
using CRN.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Transactions;

namespace CRN.Componentes
{
    public class CTblEnsayo
    {
        CADTblEnsayo ensayo = new CADTblEnsayo();
        CTblEnsayoDetalle ensdetalle = new CTblEnsayoDetalle();
        public DataSet retornarEnsayo(string consulta)
        {
            return ensayo.RetornarCattblEnsayo(consulta);
        }
        public void GuardarTblNuevo(TblEnsayo data, List<TblEnsayoDetalle> tbllista)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                ensayo.GuardarTblEnsayo(data);
                foreach (var item in tbllista)
                {
                    item.Limite = item.Limite == " " || item.Limite == "" ? "  " : item.Limite;
                    ensdetalle.GuardarTblNuevoDetalle(item);
                }
                ts.Complete();
            }
        }
        public void ModificarTblNuevo(TblEnsayo data,List<TblEnsayoDetalle>tbllista,  int idreg)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                ensayo.ModificarTblEnsayo(data);
                ensdetalle.EliminarParaInsertar(idreg);
                foreach (var item in tbllista)
                {
                    item.Limite = item.Limite == " " || item.Limite == "" ? "  " : item.Limite;
                    ensdetalle.GuardarTblNuevoDetalle(item);
                }
                ts.Complete();
            }
        }
        public DataSet retornarParaEditar(int id) 
        {           
               return  ensayo.retornarParaEditar(id);        
        }
        public DataSet retornarParaCargarCombo(string grp) 
        {
            return ensayo.retornarParaCargarCombo(grp);       
        }
        public DataSet retornarParaCargarComboEnsayoTipo()
        {
            return ensayo.retornarEnsayoTIpo();
        }
        public DataSet obtenerIdSiguiente()
        {
            return ensayo.obteneridSiguiente();
        }

        public DataSet retornardetalles(int id) 
        {
            return ensayo.retornarDetalles(id);
        }
        public DataSet retornarEnsayosCorrespondiente(string paqt) 
        {
            return ensayo.retornoEnsayoCorrespondiente(paqt);        
        }

        public DataSet retornarDetallesParaFiltrar(string pramId) 
        {
            return ensayo.retornarDetallesParaFiltrar(pramId);
        }

        public int EliminarEnsayo(int iEnsayo,string sUser)
        {
            return ensayo.EliminarEnsayo(iEnsayo, sUser);
        }


    }
}
