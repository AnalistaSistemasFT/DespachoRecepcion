using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Configuration;
using System.Data;
using System.Data.Common;
using CRN.Entidades;

namespace CAD
{
    public class CADSucursal: oledb
    {
          public CADSucursal()
        {
            this.sConnName = "FTINF";
        }
        public DataSet TraerTodasLasSucursales()
        {
            return this.consultar("");
        }
        public DataSet TraerTransitos()
        {
            string consulta = "SELECT sccodfin, sctcdesc FROM sctabcon WHERE sctcgrup = 12 AND sctcdesc LIKE'%TRN%'";
            return this.consultar(consulta);
        }
        public DataSet TraerTodasLasSucursales(string where)
        {
            return this.consultar(where);
        }
        public DataSet TraerSucursalesVenta()
        {
            string consulta = "select isucursal_id, p.sctcdesc from tbltipofact t inner join sctabcon p on t.isucursal_id = p.sccodfin group by isucursal_id, p.sctcdesc order by isucursal_id";
            return this.consultar(consulta);
        }
        //
        public DataSet TraerSucursalesTraspaso()
        {
            return this.consultar("select sccodfin, sctcdesc from sctabcon where sctcgrup = 12 and sctcvalo !=0");
        }
        public DataSet BuscarSucursalVentaNombre(string _nombreSuc)
        {
            string consulta = "select isucursal_id, p.sctcdesc from tbltipofact t inner join sctabcon p on t.isucursal_id = p.sccodfin " +
                "WHERE p.sctcdesc like '%" + _nombreSuc + "%' group by isucursal_id, p.sctcdesc order by isucursal_id";
            return this.consultar(consulta);
        }
        public DataSet BuscarSucursalVentaCodigo(string _codigoSuc)
        {
            string consulta = "select isucursal_id, p.sctcdesc from tbltipofact t inner join sctabcon p on t.isucursal_id = p.sccodfin " +
                "WHERE isucursal_id = '" + _codigoSuc + "' group by isucursal_id, p.sctcdesc order by isucursal_id";
            return this.consultar(consulta);
        }
        public DataSet BuscarSucursalTraspasoNombre(string _nombreSuc)
        {
            string consulta = "select sccodfin, sctcdesc from sctabcon where sctcgrup = 12 and sctcvalo !=0 " +
                "AND sctcdesc like '%" + _nombreSuc + "%' GROUP BY sccodfin, sctcdesc";
            return this.consultar(consulta);
        }
        public DataSet BuscarSucursalTraspasoCodigo(string _codigoSuc)
        {
            string consulta = "select sccodfin, sctcdesc from sctabcon where sctcgrup = 12 and sctcvalo !=0 " +
                "AND sccodfin = '" + _codigoSuc + "' GROUP BY sccodfin, sctcdesc";
            return this.consultar(consulta);
        }
        public DataSet BuscarNombreSuc(int _idSucursal)
        {
            string consulta = "select sctcdesc from sctabcon where sctcgrup = 12 and sctcvalo != 0 " +
                "AND sccodfin = '" + _idSucursal + "' GROUP BY sccodfin, sctcdesc";
            return this.consultar(consulta);
        }
        public Sucursal TraerSucursal(int SucursalId)
        {
            DataSet ds = this.consultar("SucursalId=" + SucursalId);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            DataRow rSucursal = dt.Rows[0];
            Sucursal oSucursal = new Sucursal();
            oSucursal.SucursalId = SucursalId;
            oSucursal.Nombre = rSucursal["Nombre"].ToString();
            oSucursal.Dpto = rSucursal["Dpto"].ToString();
            oSucursal.Direccion = rSucursal["Direccion"].ToString();
            oSucursal.Contacto = rSucursal["Contacto"].ToString();
            oSucursal.Adscrita = Convert.ToInt32(rSucursal["Adscrita"]);
            oSucursal.Elsystem = Convert.ToInt32(rSucursal["ElSystem"]);
            oSucursal.Ferrotodo = Convert.ToInt32(rSucursal["ElSystem"]);
            oSucursal.Inventario = Convert.ToInt32(rSucursal["Inventario"]);
            oSucursal.SyncPC = rSucursal["SyncPC"].ToString();
            oSucursal.Prefijo = Convert.ToInt32(rSucursal["Prefijo"]);
            oSucursal.SucIdTransito = Convert.ToInt32(rSucursal["SucIdTransito"]);
            oSucursal.TraspasoDirecto = Convert.ToInt32(rSucursal["TraspasoDirecto"]);
            oSucursal.EsTransito = Convert.ToInt32(rSucursal["EsTransito"]);
            oSucursal.Id_AX = rSucursal["Id_AX"].ToString();
            return oSucursal;
        }
    }
}
