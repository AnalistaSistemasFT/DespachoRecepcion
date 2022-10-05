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
	public class CADRecepcion:DBDAC
	{
		public CADRecepcion():base("SQLSERVER","dbo.tblRecepcion")
		{

            DbParameter par = this.CrearParametro();
            par.ParameterName = "@RecepcionId";
            par.DbType = DbType.Int32;
            par.Direction = ParameterDirection.Output;
            Adapter.InsertCommand.CommandText += ";SELECT @RecepcionId=SCOPE_IDENTITY();";
            Adapter.InsertCommand.Parameters.Add(par);
		}

		public void GuardarRecepcion(Recepcion oRecepcion)
		{
			DbCommand cmdInsert = Adapter.InsertCommand;
			cmdInsert.Parameters["@RecepcionId"].Value=oRecepcion.RecepcionId;
			cmdInsert.Parameters["@Fecha"].Value=oRecepcion.Fecha;
			cmdInsert.Parameters["@Chofer"].Value=oRecepcion.Chofer;
			cmdInsert.Parameters["@Camion"].Value=oRecepcion.Camion;
			cmdInsert.Parameters["@Placa"].Value=oRecepcion.Placa;
			cmdInsert.Parameters["@CI"].Value=oRecepcion.CI;
			cmdInsert.Parameters["@Propietario"].Value=oRecepcion.Propietario;
			cmdInsert.Parameters["@Login"].Value=oRecepcion.Login;
			cmdInsert.Parameters["@Obs"].Value=oRecepcion.Obs;
			cmdInsert.Parameters["@Correlativo"].Value=oRecepcion.Correlativo;
			cmdInsert.Parameters["@Status"].Value=oRecepcion.Status;
			cmdInsert.Parameters["@SucursalId"].Value=oRecepcion.SucursalId;
			cmdInsert.Parameters["@SucOrigen"].Value=oRecepcion.SucOrigen;
			cmdInsert.Parameters["@Documento"].Value=oRecepcion.Documento;
			cmdInsert.Parameters["@Fuente"].Value=oRecepcion.Fuente;
			cmdInsert.Parameters["@EsDeCliente"].Value=oRecepcion.EsDeCliente;
			cmdInsert.Parameters["@Manifiesto"].Value=oRecepcion.Manifiesto;
			cmdInsert.Parameters["@Barco"].Value=oRecepcion.Barco;
			cmdInsert.Parameters["@Id_Pais"].Value=oRecepcion.Id_Pais;
			cmdInsert.Parameters["@BL"].Value=oRecepcion.BL;
			cmdInsert.Parameters["@ProveedorId"].Value=oRecepcion.ProveedorId;
			EjecutarComando(cmdInsert);
            
		}


		public void ModificarRecepcion(Recepcion oRecepcion)
		{
			DbCommand cmdModificar = Adapter.UpdateCommand;
			cmdModificar.Parameters["@RecepcionId"].Value=oRecepcion.RecepcionId;
			cmdModificar.Parameters["@Fecha"].Value=oRecepcion.Fecha;
			cmdModificar.Parameters["@Chofer"].Value=oRecepcion.Chofer;
			cmdModificar.Parameters["@Camion"].Value=oRecepcion.Camion;
			cmdModificar.Parameters["@Placa"].Value=oRecepcion.Placa;
			cmdModificar.Parameters["@CI"].Value=oRecepcion.CI;
			cmdModificar.Parameters["@Propietario"].Value=oRecepcion.Propietario;
			cmdModificar.Parameters["@Login"].Value=oRecepcion.Login;
			cmdModificar.Parameters["@Obs"].Value=oRecepcion.Obs;
			cmdModificar.Parameters["@Correlativo"].Value=oRecepcion.Correlativo;
			cmdModificar.Parameters["@Status"].Value=oRecepcion.Status;
			cmdModificar.Parameters["@SucursalId"].Value=oRecepcion.SucursalId;
			cmdModificar.Parameters["@SucOrigen"].Value=oRecepcion.SucOrigen;
			cmdModificar.Parameters["@Documento"].Value=oRecepcion.Documento;
			cmdModificar.Parameters["@Fuente"].Value=oRecepcion.Fuente;
			cmdModificar.Parameters["@EsDeCliente"].Value=oRecepcion.EsDeCliente;
			cmdModificar.Parameters["@Manifiesto"].Value=oRecepcion.Manifiesto;
			cmdModificar.Parameters["@Barco"].Value=oRecepcion.Barco;
			cmdModificar.Parameters["@Id_Pais"].Value=oRecepcion.Id_Pais;
			cmdModificar.Parameters["@BL"].Value=oRecepcion.BL;
			cmdModificar.Parameters["@ProveedorId"].Value=oRecepcion.ProveedorId;
			EjecutarComando(cmdModificar);
		}
        

		public void EliminarRecepcion(string vRecepcionId)
		{
			DbCommand cmdDelete = Adapter.DeleteCommand;
			cmdDelete.Parameters["@Original_RecepcionId"].Value= vRecepcionId;
			EjecutarComando(cmdDelete);
		}

		

		public DataSet TraerTodosRecepcion()
		{
			return this.Consultar("");
		}
        public DataSet TraerTodosRecepcion(string estado, int sucursal)
        {
            string consulta = @"select RecepcionId,Fecha,Documento,Placa,SucursalId,SucOrigen,F.Descripcion from tblRecepcion r inner join
								tblcatfuentes f on r.fuente = f.codigo
								 where SucursalId='{0}' and Status = '{1}' order by r.Fecha desc";
			consulta = string.Format(consulta, sucursal, estado);
            return this.EjecutarConsulta(consulta);
        }
		public DataSet TraerDespachos(string estado, int sucursal)
		{
			string consulta = @"select d.DespachoId,d.CI,c.Nombre,d.Id_Camion,d.Placa,'FERROTODO' AS Propietrio,d.Obs,SucDestino,SucursalId
									 from tblDespacho d inner join
									tblCatChofer c on  d.CI = c.CI where Status = '{0}' and SucDestino = {1}";
			consulta = string.Format(consulta, estado, sucursal);
			return this.EjecutarConsulta(consulta);
		}

		public DataSet TraerTodosCC(string estado, int sucursal)
		{
			string consulta = @"SELECT * FROM tblccargaint WHERE sestado = '{0}'";
			consulta = string.Format(consulta,  estado);
			return this.EjecutarConsulta(consulta);
		}
		public int ActualizarEstadoRecepcion(string srecepcion,string estado,DbTransaction trnProxy)
		{
			string consulta = @"update tblRecepcion set Status = '{0}' where RecepcionId = '{1}'";
			consulta = string.Format(consulta, estado,srecepcion);
			return this.EjecutarComando(consulta, trnProxy);
		}

		


		public DataSet TraerRecepcion(string estado, int sucursal)
		{
			string consulta = "Select RecepcionId,Fecha,Documento,Placa from tblRecepcion where Status='" + estado + "' and SucursalID=" + sucursal;
			return this.EjecutarConsulta(consulta);
		}

		public DataSet TraerDetalleAnotacion(string Anotacion)
		{
			string consulta = @"select* from tblAnotacion a inner join
								tblAnotacionDet d on a.AnotacionId = d.AnotacionId
								where a.AnotacionId = '"+ Anotacion + "'";
			return this.EjecutarConsulta(consulta);
		}
		public DataSet TraerRecepcionDet(string Recepcion)
		{
				string consulta = @"select tblRecepcionDetalle.RecepcionId,tblRecepcionDetalle.itemid,descripcion,tblRecepcionDetalle.Unidad,
									tblRecepcionDetalle.Cantidad,tblRecepcionDetalle.status,tblRecepcionDetalle.sucursalId 
									from tblitem, tblRecepcionDetalle 
									where tblitem.itemid= tblRecepcionDetalle.itemid  and tblRecepcionDetalle.RecepcionId='{0}'";
			consulta = string.Format(consulta, Recepcion);
			return this.EjecutarConsulta(consulta);
		}
		public DataSet TraerDespachoDet(string Despacho)
		{
			string consulta = @"select* from tblDespDetalle where DespachoId = '{0}'";
			consulta = string.Format(consulta, Despacho);
			return this.EjecutarConsulta(consulta);
		}
		public DataSet TraerDespachoDetProd(string Despacho)
		{
			string consulta = @"select* from tblDespProductos where DespachoId = '{0}'";
			consulta = string.Format(consulta, Despacho);
			return this.EjecutarConsulta(consulta);
		}
		public DataSet TraerRecepcionDetProd(string Recepcion)
		{
			string consulta = @"select * from tblRecepcionProductos where RecepcionId = '{0}'";
			consulta = string.Format(consulta, Recepcion);
			return this.EjecutarConsulta(consulta);
		}

		public DataSet TraerRecepcionDetProd1(string Recepcion, string fuente)
		{
			string consulta = string.Empty;
			if (fuente == "ANOTACION")
				consulta = @"SELECT tblANOTACIONDET.itemid,tblitem.descripcion,tblANOTACIONDET.codigobarra as productoid,tblANOTACIONDET.piezas,
								tblANOTACIONDET.peso 
								FROM (TBLRECEPCION INNER JOIN TBLANOTACIONDET ON TBLRECEPCION.Documento =TBLANOTACIONDET.ANOTACIONID) INNER JOIN 
								tblitem ON TBLANOTACIONDET.itemid=tblitem.itemid 
								where TBLRECEPCION.RECEPCIONID='{0}' order by itemid";
			else
				consulta = @"SELECT d.itemid,tblitem.descripcion,d.productoid,d.PesoNetoProveedor as piezas,
							d.peso,d.CeldaId
							FROM(TBLRECEPCION r INNER JOIN tblRecepcionProductos d on r.RecepcionId = d.RecepcionId) inner join
							 tblitem on d.itemid = tblitem.itemid
							 where r.RECEPCIONID = '{0}' order by itemid";
			consulta = string.Format(consulta, Recepcion);
			return this.EjecutarConsulta(consulta);
		}
       
		//public DataSet TraerOrdenesUsuario(int Id)
		//{
		//    string cad = "SELECT e.Id_Entrega,d.PaqueteId,e.status" +
		//                "FROM tblEntrega e inner join tblEntregaDet d on e.Id_Entrega =d.Id_Entrega" +
		//                "where e.ejecutor=" + Id + "";
		//    return this.EjecutarConsulta(cad);
		//}

		//public DataSet TraerSolicitudesUsuario(int Id)
		//{
		//    string cad = "SELECT s.Id_Solicitud,Urgente=case s.Urgente when 'true' then '!' else '' end,s.Descripcion,s.Id_Sol_Status,stat.Descripcion as Estado,stat.Id_Status " +
		//                "FROM (Solicitud S inner join Solicitud_Status ST on s.Id_Sol_Status =st.Id_Sol_Status)" +
		//                "inner join Sis_StatusSolicitud stat on st.Id_Status=stat.Id_Status " +
		//                "where s.id_usuario=" + Id + " and ST.id_Status not in(4,6)";
		//    return this.EjecutarConsulta(cad);
		//}

		public Recepcion  TraerRecepcion(string vRecepcionId)
		{
			DataSet ds = this.Consultar("RecepcionId=" + vRecepcionId);
			DataTable tRecepcion = ds.Tables[0];
			if (tRecepcion.Rows.Count == 0)
			{
				return null;
			}
			DataRow rRecepcion = tRecepcion.Rows[0];
			Recepcion oRecepcion = new Recepcion();
			oRecepcion.RecepcionId = Convert.ToString(rRecepcion["RecepcionId"]);
			oRecepcion.Fecha = Convert.ToDateTime(rRecepcion["Fecha"]);
			oRecepcion.Chofer = Convert.ToString(rRecepcion["Chofer"]);
			oRecepcion.Camion = Convert.ToString(rRecepcion["Camion"]);
			oRecepcion.Placa = Convert.ToString(rRecepcion["Placa"]);
			oRecepcion.CI = Convert.ToString(rRecepcion["CI"]);
			oRecepcion.Propietario = Convert.ToString(rRecepcion["Propietario"]);
			oRecepcion.Login = Convert.ToString(rRecepcion["Login"]);
			oRecepcion.Obs = Convert.ToString(rRecepcion["Obs"]);
			oRecepcion.Correlativo = Convert.ToInt32(rRecepcion["Correlativo"]);
			oRecepcion.Status = Convert.ToString(rRecepcion["Status"]);
			oRecepcion.SucursalId = Convert.ToInt32(rRecepcion["SucursalId"]);
			oRecepcion.SucOrigen = Convert.ToInt32(rRecepcion["SucOrigen"]);
			oRecepcion.Documento = Convert.ToString(rRecepcion["Documento"]);
			oRecepcion.Fuente = Convert.ToInt32(rRecepcion["Fuente"]);
			oRecepcion.EsDeCliente = Convert.ToBoolean(rRecepcion["EsDeCliente"]);
			oRecepcion.Manifiesto = Convert.ToString(rRecepcion["Manifiesto"]);
			oRecepcion.Barco = Convert.ToString(rRecepcion["Barco"]);
			oRecepcion.Id_Pais = Convert.ToInt32(rRecepcion["Id_Pais"]);
			oRecepcion.BL = Convert.ToString(rRecepcion["BL"]);
			oRecepcion.ProveedorId = Convert.ToInt32(rRecepcion["ProveedorId"]);
			return oRecepcion;
		}

		

	}
}
