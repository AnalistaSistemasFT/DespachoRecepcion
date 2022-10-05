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
	public class CADEntregaDet:DBDAC
	{
		public CADEntregaDet():base("SQLSERVER","dbo.Tblentregadet")
		{

			DbParameter par=this.CrearParametro();
			par.ParameterName ="@Id_Entrega";
			par.DbType =DbType.Int32;
			par.Direction =ParameterDirection.Output;
			Adapter.InsertCommand.CommandText +=";SELECT @Id_Entrega=SCOPE_IDENTITY();";
			Adapter.InsertCommand.Parameters.Add(par);
		}

		public void GuardarEntregaDet(EntregaDet oED)
		{
            //DbCommand cmdInsert = Adapter.InsertCommand;
            //cmdInsert.Parameters["@Id_Entrega"].Value=oEntregaDet.Id_Entrega;
            //cmdInsert.Parameters["@PaqueteId"].Value=oEntregaDet.PaqueteId;
            //cmdInsert.Parameters["@SucursalId"].Value=oEntregaDet.SucursalId;
            //cmdInsert.Parameters["@AlmacenId"].Value=oEntregaDet.AlmacenId;
            //cmdInsert.Parameters["@Fecha"].Value=oEntregaDet.Fecha;
            //cmdInsert.Parameters["@CeldaId"].Value=oEntregaDet.CeldaId;
            //cmdInsert.Parameters["@ItemId"].Value=oEntregaDet.ItemId;
            //cmdInsert.Parameters["@Status"].Value=oEntregaDet.Status;
            //cmdInsert.Parameters["@Peso"].Value=oEntregaDet.Peso;
            //cmdInsert.Parameters["@Piezas"].Value=oEntregaDet.Piezas;
            //cmdInsert.Parameters["@OrdenId"].Value=oEntregaDet.OrdenId;
            //cmdInsert.Parameters["@Contenedor"].Value=oEntregaDet.Contenedor;
            //cmdInsert.Parameters["@Colada"].Value=oEntregaDet.Colada;
            //cmdInsert.Parameters["@CentroTrabajo"].Value=oEntregaDet.CentroTrabajo;
            //EjecutarComando(cmdInsert);
            
            string cadena = "insert into tblEntregaDet (Id_Entrega,PaqueteId,SucursalId,AlmacenId,Fecha,CeldaId,ItemId,Status,Peso,Piezas,OrdenId,Contenedor,Colada,CentroTrabajo) " +
                            "values ('" + oED.Id_Entrega + "','" + oED.PaqueteId + "'," + Convert.ToInt32(oED.SucursalId) + "," + Convert.ToInt32(oED.AlmacenId) +
                            ",sysDateTime(),'" + oED.CeldaId + "','" + oED.ItemId + "','" + oED.Status + "'," + Convert.ToDecimal(oED.Peso) + "," + Convert.ToInt32(oED.Piezas) + ",'" + oED.OrdenId + "','" + oED.Contenedor + "','" + oED.Colada + "','" + oED.CentroTrabajo + "')";
                            
                     EjecutarComando(cadena);
             }


		public void ModificarEstadoEntregaDet(EntregaDet oEntregaDet)
		{
            //DbCommand cmdModificar = Adapter.UpdateCommand;
            //cmdModificar.Parameters["@PaqueteId"].Value = oEntregaDet.PaqueteId;
            //cmdModificar.Parameters["@Status"].Value = oEntregaDet.Status;
            //cmdModificar.Parameters["@IdObservacion"].Value = oEntregaDet.IdObservacion;
            //cmdModificar.Parameters["@Original_Id_Entrega"].Value = oEntregaDet.Id_Entrega;
            //EjecutarComando(cmdModificar);
            string cadena = "update tblEntregaDet set celdaid='" + oEntregaDet.CeldaId + "',IdObservacion=" + oEntregaDet.IdObservacion + ",Status='" + oEntregaDet.Status + "' where PaqueteId='" + oEntregaDet.PaqueteId + "' and id_Entrega='" + oEntregaDet.Id_Entrega + "'";
            EjecutarComando(cadena);
            
		}
        public void ActualizarEntregaDet(EntregaDet oEntregaDet)
        {
            string cadena = "update tblEntregaDet set status='" + oEntregaDet.Status + "',celdaid='" + oEntregaDet.CeldaId + "',IdObservacion=" + oEntregaDet.IdObservacion + ", Peso=" + oEntregaDet.Peso + ",Piezas=" + oEntregaDet.Piezas + " where PaqueteId='" + oEntregaDet.PaqueteId + "' and id_Entrega='" + oEntregaDet.Id_Entrega + "'";
            EjecutarComando(cadena);

        }

		public void EliminarEntregaDet(string vId_Entrega)
		{
			DbCommand cmdDelete = Adapter.DeleteCommand;
			cmdDelete.Parameters["@Original_Id_Entrega"].Value= vId_Entrega;
			EjecutarComando(cmdDelete);
		}

        //public DataSet TraerEntregaDet2(string IdEntrega)
        //{
        //    string consulta = "Select paqueteid,Status from tblEntregaDet where Id_Entrega='" + IdEntrega + "'";
        //    return this.EjecutarConsulta(consulta);
        //}

        public DataSet TraerEntregaDet2(string IdEntrega,string where)
        {
            string consulta = "Select paqueteid,Status from tblEntregaDet where Id_Entrega='" + IdEntrega + "'";
            if (!string.IsNullOrEmpty (where))
            {
                consulta+=" and " + where;
            }
            return this.EjecutarConsulta(consulta);
        }
		public DataSet TraerTodosEntregaDet()
		{
			return this.Consultar("");
		}
        public EntregaDet TraerEntregatDet(string EntegaId, string PaqueteId)
        {
            DataSet ds = this.Consultar("Id_Entrega='" + EntegaId + "' and PaqueteId='" + PaqueteId + "'");
            DataTable tEntregaDet = ds.Tables[0];
            if (tEntregaDet.Rows.Count == 0)
            {
                return null;
            }
            DataRow rEntregaDet = tEntregaDet.Rows[0];
            EntregaDet oEntregaDet = new EntregaDet();
            oEntregaDet.Id_Entrega = EntegaId;
            oEntregaDet.PaqueteId = PaqueteId;
            oEntregaDet.SucursalId = Convert.ToInt32(rEntregaDet["SucursalId"]);
            oEntregaDet.AlmacenId = Convert.ToInt32(rEntregaDet["AlmacenId"]);
            oEntregaDet.Fecha = Convert.ToDateTime(rEntregaDet["Fecha"]);
            oEntregaDet.CeldaId =rEntregaDet["CeldaId"].ToString();
            oEntregaDet.ItemId = rEntregaDet["ItemId"].ToString();
            oEntregaDet.Status = rEntregaDet["Status"].ToString();
            oEntregaDet.Peso = Convert.ToDecimal(rEntregaDet["Peso"]);
            oEntregaDet.Piezas = Convert.ToInt32(rEntregaDet["Piezas"]);
            oEntregaDet.OrdenId=rEntregaDet["OrdenId"].ToString();
            oEntregaDet.Contenedor=rEntregaDet["OrdenId"].ToString();
            oEntregaDet.Colada=rEntregaDet["Colada"].ToString();
            oEntregaDet.CentroTrabajo=rEntregaDet["CentroTrabajo"].ToString();
            oEntregaDet.IdObservacion = Convert.ToInt32(rEntregaDet["IdObservacion"]);
            return oEntregaDet;
        }
        public bool BuscarEntProduccion(string CodPaquete, string OrdenId)
        {
            string cadena = "select * from tblEntregaDet where paqueteId='" + CodPaquete + "' and Id_Entrega='" + OrdenId + "'";
            DataSet ds = EjecutarConsulta(cadena);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
                return true;
            else
                return false;

        }

        public DataSet CargarProductosCombo()
        {
            string consulta = "SELECT P.ProductoId,rtrim(P.Descripcion) + ' ('+ rtrim(U.DESCRIPCION) +')' as Descripcion " +
                          " FROM [Inventario].[dbo].[tblProductos] P inner join CatUnidades U on p.Unidad=U.ID_UNIDAD";

            return this.EjecutarConsulta(consulta);
        }
        public EntregaDet Importar(string cod)
        {
            string cadena = "select FBC_BATCH [Paquete],FBC_BATCH_FATHER [Contenedor],FBC_PRODUCT_GROUP,FBC_PRODUCT_CODE [ItemId],FBC_PRODUCT_DESC,FBC_WORKCENTER [CentroTrabajo],FBC_PO [OrdenId],FBC_WEIGHT [Peso],FBC_PIECE [Piezas],FBC_METERS,FBC_INS_DATE,'',FBC_START [Fecha]," +
            "(SELECT [FBF_VALUE] FROM [ElsystemNet_Ferrotodo].[dbo].[MES_TB_FLD_BATCH_FEATURE] where FBF_BATCH ='" + cod + "' and FBF_FEATURE ='HEAT') as Colada " +
            "FROM [ElsystemNet_Ferrotodo].[dbo].[MES_TB_FLD_BATCHES] " +
            "where FBC_BATCH='" + cod + "'";
            DataSet ds = EjecutarConsulta(cadena);
            DataTable tEntDet = ds.Tables[0];
            if (tEntDet.Rows.Count == 0)
            {
                return null;
            }
            DataRow rEntDet = tEntDet.Rows[0];
            EntregaDet oEntDet = new EntregaDet();
            //oEntDet.Id_Entrega = cod;
            oEntDet.PaqueteId = rEntDet["Paquete"].ToString();
            oEntDet.Contenedor = rEntDet["Contenedor"].ToString();
            oEntDet.ItemId = rEntDet["ItemId"].ToString();
            oEntDet.CentroTrabajo = rEntDet["CentroTrabajo"].ToString();
            oEntDet.OrdenId = rEntDet["OrdenId"].ToString();
            oEntDet.Peso = Convert.ToDecimal(rEntDet["Peso"]);
            oEntDet.Piezas = Convert.ToInt32(rEntDet["Piezas"]);
            oEntDet.Fecha = Convert.ToDateTime(rEntDet["Fecha"]);
            oEntDet.Colada = rEntDet["Colada"].ToString();

            return oEntDet;
        }
        //public int ContarEstadoBueno(string id,string estado)
        //{
        //    string cadena = "select COUNT(*) FROM tblEntregaDet where Id_Entrega='"+ id +'" and Status<>'"+ estado +"'";

        //}

	}
}
