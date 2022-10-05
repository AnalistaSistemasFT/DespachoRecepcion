using CRN.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace CAD
{
    public class CADUsuarioMecanizado : DBDAC
    {
        public CADUsuarioMecanizado() : base("SQLSERVER", "tblUsuarioMecanizado")
        {
            DbParameter par = this.CrearParametro();
            par.ParameterName = "@p_Id_usuario_mecanizado";
            par.DbType = DbType.Int32;
            par.Direction = ParameterDirection.Output;
            Adapter.InsertCommand.CommandText += ";SELECT @p_Id_usuario_mecanizado=SCOPE_IDENTITY();";
            Adapter.InsertCommand.Parameters.Add(par);
        }
        public DataSet TraerTodosUsuarios()
        {
            return this.Consultar("");
        }
        public DataSet TraerDatosUsuario(string _login)
        {
            string consulta = "select * from tblUsuarioMecanizado where p_Login = '" + _login + "'";
            return this.EjecutarConsulta(consulta);
        }
        public DataSet TraerOperarios()
        {
            string consulta = "select * from tblUsuarioMecanizado where p_Id_grupo = 5";
            return this.EjecutarConsulta(consulta);
        }
        public int GuardarUsuarioDir()
        {
            string consulta = "INSERT INTO tblUsuarioMecanizado (p_Id_usuario_mecanizado, p_Id_empleado, p_Login, p_Clave, p_Nombre, p_Id_grupo) VALUES('16', '6350', 'ksanchez', 'ksanchez', 'Kleber Sanchez', '5')";
            return EjecutarComando(consulta);
        }
        public int GuardarUsuario(UsuarioMecanizado _usuarioMecanizado)
        {
            DbCommand cmdInsert = Adapter.InsertCommand;
            //cmdInsert.Parameters["@p_Id_usuario_mecanizado"].Value = _usuarioMecanizado.Id_usuario_mecanizado;
            cmdInsert.Parameters["@p_Id_empleado"].Value = _usuarioMecanizado.Id_empleado;
            cmdInsert.Parameters["@p_Login"].Value = _usuarioMecanizado.Login;
            cmdInsert.Parameters["@p_Clave"].Value = _usuarioMecanizado.Clave;
            cmdInsert.Parameters["@p_Nombre"].Value = _usuarioMecanizado.Nombre;
            cmdInsert.Parameters["@p_Id_grupo"].Value = _usuarioMecanizado.Id_grupo;
            return EjecutarComando(cmdInsert);
        }
    }
}
