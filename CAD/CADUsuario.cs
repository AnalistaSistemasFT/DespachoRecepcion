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
    public class CADUsuario:DBDAC
    {

       public CADUsuario()
            : base("SQLSERVER", "empleados.dbo.tbluser")
        {
            DbParameter par = this.CrearParametro();
            par.ParameterName = "@Login";
            par.DbType = DbType.Int32;
            par.Direction = ParameterDirection.Output;
            Adapter.InsertCommand.CommandText += ";SELECT @Login=SCOPE_IDENTITY();";
            Adapter.InsertCommand.Parameters.Add(par);
        }
        public int GuardarUsuario(Usuario oUsuario)
        {
            DbCommand cmdInsert = Adapter.InsertCommand;
            cmdInsert.Parameters["@Login"].Value = oUsuario.Login;
            cmdInsert.Parameters["@Clave"].Value = oUsuario.Clave;
            cmdInsert.Parameters["@Id_Grupo"].Value = oUsuario.Id_Grupo;
            cmdInsert.Parameters["@Activo"].Value = oUsuario.Activo;
            cmdInsert.Parameters["@EmpleadoId"].Value = oUsuario.EmpleadoId;
            cmdInsert.Parameters["@Nivel"].Value = oUsuario.Nivel;
            return EjecutarComando(cmdInsert);
        }

        public DataSet TraerTodoMovSync()
        {
            return this.Consultar("");
        }
        public DataSet TraerTodoMovSync(string where)
        {
            return this.Consultar(where);
        }
 
        public Usuario TraerUsuario(string login)
        {
            DataSet ds = this.Consultar("Login='" + login +"'");
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            DataRow rUsuario = dt.Rows[0];
            Usuario oUsuario = new Usuario();
            oUsuario.Login = login;
            oUsuario.Clave = rUsuario["Clave"].ToString();
            oUsuario.Id_Grupo = Convert.ToInt32(rUsuario["Id_Grupo"]);
            oUsuario.Activo = Convert.ToInt32(rUsuario["Activo"]);
            oUsuario.EmpleadoId = Convert.ToInt32(rUsuario["EmpleadoId"]);
            oUsuario.Nivel = Convert.ToInt32(rUsuario["Nivel"]);
            return oUsuario;
        }
        public bool LogueadoEnAlmacen(int Id)
        {
            string cad = "SELECT * FROM tblEmpleados e INNER JOIN TBLSUCCONEXION s on e.id_sucursal=s.id_sucursal " +
            "where EmpleadoId=" + Id;
            DataSet ds = this.EjecutarConsulta(cad);
            int reg = ds.Tables[0].Rows.Count;
            if (reg > 0)
                return true;
            else
                return false;
        }
        public DataSet TraerConexion(int id)
        {
            string cad = "SELECT e.EmpleadoId,e.Nombre,e.Apellido,s.conexion FROM [Empleados].[dbo].[tblEmpleados] E " +
                         "inner join tblSucConexion S on e.Id_Sucursal =s.id_Sucursal where EmpleadoId=" + id;
            return this.EjecutarConsulta(cad);
        }
        public DataSet TraerDatosUsuario(string login) 
        {
            string consulta = String.Format("select U.*,e.nombre+' '+e.apellido as nombre " +
                               " from (empleados.dbo.tblUser U inner join empleados.dbo.tblempleados E on u.EmpleadoId=e.EmpleadoId) "+
                               " where u.login = '{0}'",login);
            return this.EjecutarConsulta(consulta);
        }

        public DataSet TraerSucursalPorUsuario(string login)
        {
            string consulta = String.Format(@"select us.SucursalId,Nombre from empleados.dbo.tblusersuc us INNER JOIN (empleados.dbo.tblsucursal s inner join empleados.dbo.sucaplicacion sap on s.SucursalID =sap.sucursalid)ON us.sucursalid=s.sucursalid 
                            where us.login = '{0}' and sap.aplicacion = 2", login);
            return this.EjecutarConsulta(consulta);
        }

        public DataSet TraerAlmacenPorUsuario(int iSucursal)
        {
            string consulta = String.Format(@"select * from tblAlmacen where SucursalId = {0}", iSucursal);
            return this.EjecutarConsulta(consulta);
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
