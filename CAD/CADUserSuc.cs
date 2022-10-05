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
    public class CADUserSuc:DBDAC
    {
        public CADUserSuc()
            : base("SQLSERVER2", "dbo.tblUserSuc")
        {

            DbParameter par = this.CrearParametro();
            par.ParameterName = "@Login";
            par.DbType = DbType.Int32;
            par.Direction = ParameterDirection.Output;
            Adapter.InsertCommand.CommandText += ";SELECT @Login=SCOPE_IDENTITY();";
            Adapter.InsertCommand.Parameters.Add(par);
        }
        public int GuardarUserSuc(UserSuc oUserSuc)
        {
            DbCommand cmdInsert = Adapter.InsertCommand;
            cmdInsert.Parameters["@Login"].Value = oUserSuc.Login;
            cmdInsert.Parameters["@SucursalId"].Value = oUserSuc.SucursalId;
            cmdInsert.Parameters["@Activo"].Value = oUserSuc.Activo;
            return EjecutarComando(cmdInsert);
        }

        public DataSet TraerSucursales()
        {
            return this.Consultar("");
        }
        public DataSet TraerSucursales(string where)
        {
            return this.Consultar(where);
        }
 
        public UserSuc TraerUserSuc(string login)
        {
            DataSet ds = this.Consultar("Login='" + login + "'");
            //DataSet ds = this.Consultar("SucursalId=" + Sucursal);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            DataRow rUserSuc = dt.Rows[0];
            UserSuc oUserSuc = new UserSuc();
            oUserSuc.Login = rUserSuc["Login"].ToString();
            oUserSuc.SucursalId = Convert.ToInt32(rUserSuc["SucursalId"]); ;
            oUserSuc.Activo = Convert.ToInt32(rUserSuc["Activo"]);

            return oUserSuc;
        }
        public DataSet MostrarSucursales(int EmpId)
        {
            string Cadena = "select U.SucursalId,S.Nombre from tblUserSuc U inner join tblsucursal S on U.Sucursalid=S.sucursalid where u.empleadoid=" + EmpId;
            return EjecutarConsulta(Cadena);
        }
        //public Cliente TraerCliente(int idCliente)
        //{
        //    DataSet ds = this.Consultar("IdCliente=" + idCliente);
        //    DataTable tClientes = ds.Tables[0];
        //    if (tClientes.Rows.Count == 0)
        //    {
        //        return null;
        //    }
        //    DataRow rCliente = tClientes.Rows[0];
        //    Cliente oCliente = new Cliente();
        //    oCliente.IdCliente = idCliente;
        //    oCliente.Nombre = rCliente["Nombre"].ToString();
        //    oCliente.ApellidoPaterno = rCliente["ApellidoPaterno"].ToString();
        //    oCliente.ApellidoMaterno = rCliente["ApellidoMaterno"].ToString();
        //    oCliente.Documento = rCliente["Documento"].ToString();
        //    oCliente.Sexo = rCliente["Sexo"].ToString();
        //    oCliente.CantidadHijos = Convert.ToInt32(rCliente["CantidadHijos"]);
        //    return oCliente;
        //}

    }
}
