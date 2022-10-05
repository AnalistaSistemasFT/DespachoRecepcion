using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAD
{
    public class CADLogError : DBDAC
    {
        public CADLogError() : base("SQLSERVER", "tblDespacho")
        {
            //DbParameter par = this.CrearParametro();
            //par.ParameterName = "@p_Id_servicio_mecanizado";
            //par.DbType = DbType.Int32;
            //par.Direction = ParameterDirection.Output;
            //Adapter.InsertCommand.CommandText += ";SELECT @p_Id_servicio_mecanizado=SCOPE_IDENTITY();";
            //Adapter.InsertCommand.Parameters.Add(par);
        }
        public int ModificarDataTest()
        {
            //string consulta = "delete from tblServicioMecanizado Where p_Id_servicio_mecanizado = 936576";
            //string consulta = "update tblServicioMecanizado set Codigo = 'MEC-2022-98' where p_Id_servicio_mecanizado = 740326";
            //string consulta = "INSERT INTO tblUsuarioMecanizado (p_Id_Usuario_mecanizado, p_Id_empleado, p_Login, p_Clave, p_Nombre, p_Id_grupo) VALUES (21, 6093, 'gsoto', 'gsoto', 'Denis Soto', 1);";
            string consulta = "";
            return EjecutarComando(consulta);
        }
    }
}
