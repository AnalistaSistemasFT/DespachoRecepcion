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
    public class CCatTablas
    {
        CADCatTablas catTabla = new CADCatTablas();
        CCatTablaDetalle cattabladetalle=new CCatTablaDetalle();
        public DataSet retornarTabla(string consulta)
        {
            return catTabla.RetornarCatTablas(consulta);
        }

        public void GuardarTablaNuevo(CatTabla ensayo, List<CatTablaDetalle> tabladetalle)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                catTabla.GuardarCatTablas(ensayo);
                foreach (var item in tabladetalle)
                {
                    cattabladetalle.GuardarTablaDetalle(item);
                }
                ts.Complete();
            }
        }
        public void ModificarCatTabla(CatTabla ensayo, List<CatTablaDetalle> tabladetalle)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                catTabla.ModificarCatTablas(ensayo);
                cattabladetalle.Eliminar(ensayo.TtablaId);
                foreach (var item in tabladetalle)
                {
                    cattabladetalle.GuardarTablaDetalle(item);
                }
                ts.Complete();
            }
        }
        public DataSet RetornoTablasHijas(string padre) 
        {
      
            return catTabla.retornoTHijas(padre);        
        }
        CADCeldas oCeldas = new CADCeldas();
        public DataSet TraerDetalleSobrantesxOrden(string sOrden)
        {
            return catTabla.DetalleSobrantesxOrden(sOrden);
        }

        public int InsertarSobrantes(string sPaquete, DateTime dtFecha, string sCelda, string sItem, decimal dPeso, string sColada, string sCentro)
        {
            return oCeldas.InsertarPaquete(sPaquete, dtFecha, sCelda, sItem, dPeso, sColada, sCentro);
        }
        public int ModificarCeldaSobrante(string sCelda)
        {
            return oCeldas.ModificarCeldaSobrante(sCelda);
        }
        
    }
}
