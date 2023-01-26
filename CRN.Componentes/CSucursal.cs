using CAD;
using CRN.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
namespace CRN.Componentes
{
    public class  CSucursal : oledb
    {
        CADSucursal cadSucursal = new CAD.CADSucursal();
        public CSucursal()
        {
            this.sConnName = "SQLSERVER";
        }

        public DataSet SeleccionarSucursal()
        {
            string sInsert = @"select SucursalID,Nombre from tblSucursal where SucursalID in (12094,12095,12096,12097,12098,12114,12115,12100,12101)";
            sInsert = string.Format(sInsert);
            return this.consultar(sInsert);
        }
        public DataSet SeleccionarSucursalTodo()
        {
            string sInsert = @"select SucursalID,Nombre from empleados.dbo.tblSucursal";
            sInsert = string.Format(sInsert);
            return this.consultar(sInsert);
        }
        public DataSet TraerTodasLasSucursales(string where)
        {
            string sInsert = @"select* from tblSucursal where ferrotodo  = 'true'";
            sInsert = string.Format(sInsert);
            return this.consultar(sInsert);
        }
        public DataSet TraerTodasLasSucursales(int Sucursal)
        {
            string sInsert = @"select* from tblSucursal where SucursalID  = '"+ Sucursal + "'";
            sInsert = string.Format(sInsert);
            return this.consultar(sInsert);
        }
        public Sucursal TraerSucursal(int SucursalId)
        {
            DataSet ds = TraerTodasLasSucursales(SucursalId);
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
        //public DataSet TraerSucursalesVenta()
        //{
        //    return cadSucursal.TraerSucursalesVenta();
        //}
        public DataSet TraerTransitos()
        {
            return cadSucursal.TraerTransitos();
        }
        public DataSet TraerSucursalesTraspaso()
        {
            return cadSucursal.TraerSucursalesTraspaso();
        }
        public DataSet BuscarSucursalVentaNombre(string _nombreSuc)
        {
            return cadSucursal.BuscarSucursalVentaNombre(_nombreSuc);
        }
        public DataSet BuscarSucursalVentaCodigo(string _codigoSuc)
        {
            return cadSucursal.BuscarSucursalVentaCodigo(_codigoSuc);
        }
        public DataSet BuscarSucursalTraspasoNombre(string _nombreSuc)
        {
            return cadSucursal.BuscarSucursalTraspasoNombre(_nombreSuc);
        }
        public DataSet BuscarSucursalTraspasoCodigo(string _codigoSuc)
        {
            return cadSucursal.BuscarSucursalTraspasoCodigo(_codigoSuc);
        }

        public DataSet TraerTodasLasSucursales()
        {
            return cadSucursal.TraerTodasLasSucursales();
        }
        public DataSet BuscarNombreSuc(int _idSucursal)
        {
            return cadSucursal.BuscarNombreSuc(_idSucursal);
        }

        public int TraerSucTransito(int Sucursal)
        {
            string sInsert = @"select isnull(SucIDTransito,0) suctran from [Empleados].[dbo].tblSucursal where SucursalID = {0}";
            sInsert = string.Format(sInsert, Sucursal);
            DataSet dts = this.consultar(sInsert);
            int iCodSucTra = 0;
            if (dts.Tables[0].Rows.Count > 0)
            {
                iCodSucTra = Convert.ToInt32(dts.Tables[0].Rows[0]["suctran"].ToString());
            }
            return iCodSucTra;
        }
        public DataSet TraerMovPdv(string Estado, int Sucursal)
        {
            return cadSucursal.TraerMovPdv(Estado, Sucursal);
        }
    }
}
