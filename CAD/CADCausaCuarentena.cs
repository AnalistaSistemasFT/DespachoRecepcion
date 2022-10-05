using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using CRN.Entidades;

namespace CAD
{
	public class CADCausaCuarentena:DBDAC
	{
		public CADCausaCuarentena():base("SQLSERVER","dbo.Causacuarentena")
		{

			DbParameter par=this.CrearParametro();
			par.ParameterName ="@Id_Causa";
			par.DbType =DbType.Int32;
			par.Direction =ParameterDirection.Output;
			Adapter.InsertCommand.CommandText +=";SELECT @Id_Causa=SCOPE_IDENTITY();";
			Adapter.InsertCommand.Parameters.Add(par);
		}

		public void GuardarCausaCuarentena(CausaCuarentena oCausaCuarentena)
		{
			DbCommand cmdInsert = Adapter.InsertCommand;
            //cmdInsert.Parameters["@Id_Causa"].Value=oCausaCuarentena.Id_Causa;
			cmdInsert.Parameters["@Descripcion"].Value=oCausaCuarentena.Descripcion;
			EjecutarComando(cmdInsert);
			oCausaCuarentena.Id_Causa=Convert.ToInt32(cmdInsert.Parameters["@Id_Causa"].Value);
		}


		public void ModificarCausaCuarentena(CausaCuarentena oCausaCuarentena)
		{
			DbCommand cmdModificar = Adapter.UpdateCommand;
			
			cmdModificar.Parameters["@Descripcion"].Value=oCausaCuarentena.Descripcion;
            cmdModificar.Parameters["@Original_Id_Causa"].Value = oCausaCuarentena.Id_Causa;
			EjecutarComando(cmdModificar);
		}

		public void EliminarCausaCuarentena(int vId_Causa)
		{
			DbCommand cmdDelete = Adapter.DeleteCommand;
			cmdDelete.Parameters["@Original_Id_Causa"].Value= vId_Causa;
			EjecutarComando(cmdDelete);
		}


		public DataSet TraerTodosCausaCuarentena()
		{
			return this.Consultar("");
		}


		public CausaCuarentena  TraerCausaCuarentena(int vId_Causa)
		{
			DataSet ds = this.Consultar("Id_Causa=" + vId_Causa);
			DataTable tCausaCuarentena = ds.Tables[0];
			if (tCausaCuarentena.Rows.Count == 0)
			{
				return null;
			}
			DataRow rCausaCuarentena = tCausaCuarentena.Rows[0];
			CausaCuarentena oCausaCuarentena = new CausaCuarentena();
			oCausaCuarentena.Id_Causa = Convert.ToInt32(rCausaCuarentena["Id_Causa"]);
			oCausaCuarentena.Descripcion = Convert.ToString(rCausaCuarentena["Descripcion"]);
			return oCausaCuarentena;
		}

        public DataSet CargarCausaCuarentena()
        {
            string consulta = "SELECT C.Id_Causa,C.Descripcion" +
                         " FROM  [LYBK].[dbo].[CausaCuarentena] C ";

            return this.EjecutarConsulta(consulta);
        }
	}
}
