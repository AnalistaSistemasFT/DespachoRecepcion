using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CAD
{
    public class CADNroOrden : oledb
    {
        public CADNroOrden()
        {
            this.sConnName = "FTINF";
        }
        public DataSet TraerTodo(int _idSucursalDestino)
        {
            string consulta = "select * from scmovart where scmvtdoc = 9003 and scmvndoc = 4512";
            //string consulta = "select * from sctabcon";
            return this.consultar(consulta);
        }
        public DataSet TraerTodo2()
        {
            string consulta = "SELECT a.PaqueteId, a.ItemId ,a.ItemFId, a.Cantidad, a.Peso, b.CeldaId FROM tblOrdenEntregaDetalle a INNER JOIN tblPaquetes b ON a.PaqueteId = b.PaqueteId";
            //string consulta = "select scclccli as IdCliente, scclnomb as Nombre from scmaecli";
            return this.consultar(consulta);
        }
        public DataSet InformixIdItem()
        {
            string consulta = "select scmvnart, scmvcant from scmovart where scmvtdoc = 9003 and scmvndoc = 4512";
            return this.consultar(consulta);
        }
        public DataSet LYBKIdItem()
        {
            string consulta = "select ItemId from tblItem where ItemFId = ITEM_INFORMIX";
            return this.consultar(consulta);
        }
        public DataSet TraerTodasOrdenes()
        {
            //string consulta = "select a.sctfsuc, a.sctftdoc, a.sctfccli from sctfactu a inner join scmovart b on a.sctftdoc = b.scmvtdoc and a.sctfndoc = b.scmvndoc";
            //string consulta = "select a.sctfndoc as NroOrden from sctfactu a inner join scmovart b on a.sctftdoc = b.scmvtdoc and a.sctfndoc = b.scmvndoc " +
            string consulta = "SELECT COUNT(*) FROM sctfactu WHERE sctfndoc = 550";
            //"where a.sctfndoc = 550";
            return this.consultar(consulta);
        }
        public DataSet TraerOrden(int _nroOrden)
        {
            //string consulta = "select isucursal_id,inrodoc,sctcdesc from tbltipofact t inner join sctabcon p on t.inrodoc = p.sccodfin";
            string consulta = "select a.sctfsuc, a.sctftdoc, a.sctfccli" +
                "from sctfactu a inner join scmovart b on a.sctftdoc = b.scmvtdoc and a.sctfndoc = b.scmvndoc " +
                "where sctfndoc = '" + _nroOrden + "'";
            return this.consultar(consulta);
        }
        public DataSet TraerProductos(int _nroOrden, int _NroDocTraspVenta)
        {
            //string consulta = "select scmvnart, scmvcant from scmovart where scmvndoc = " + _nroOrden + " and scmvtdoc = " + _NroDocTraspVenta;
            string consulta = "select m.scmvtdoc,m.scmvndoc,m.scmvnart, nvl(cantidad, 0) cantidad " +
                                 "from scmovart m inner join scmaster a on m.scmvnart = a.scmanart left outer join " +
          "(select e.sctipdoc, e.scnrodoc, d.scmvnart, nvl(sum(d.scmvcant), 0) cantidad " +
          "from scentreg e inner join scdetent d on e.sctitdoc = d.scmvtdoc and e.sctindoc = d.scmvndoc " +
          "where e.sctipdoc = " + _NroDocTraspVenta + " and e.scnrodoc = " + _nroOrden + " group by e.sctipdoc, e.scnrodoc, d.scmvnart) de on m.scmvtdoc = de.sctipdoc and m.scmvndoc = de.scnrodoc  and m.scmvnart = de.scmvnart " +
           "where m.scmvtdoc = " + _NroDocTraspVenta + " and m.scmvndoc = " + _nroOrden + " group by m.scmvtdoc,m.scmvndoc,m.scmvnart,a.scmadesc,m.scmvcant,cantidad;";
            return this.consultar(consulta);
        }
        public DataSet TraerTipoDocumento(int _idSucursalDestino)
        {
            string consulta = "select isucursal_id, itipodoc, sctcdesc, inrodoc from tbltipofact t inner join sctabcon p on t.inrodoc = p.sccodfin " +
                "where isucursal_id = '" + _idSucursalDestino + "'";
            return this.consultar(consulta);
        }
        public DataSet TraerClientes()
        {
            string consulta = "select scclccli,scclnomb from scmaecli where scclesta = 'V'";
            return this.consultar(consulta);
        }
    }
}
