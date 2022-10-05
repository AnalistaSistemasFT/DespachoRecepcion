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
	public class CADMovConsumido:DBDAC
	{
		public CADMovConsumido():base("SQLSERVER","dbo.Consumido")
		{

			//DbParameter par=this.CrearParametro();
			//par.ParameterName ="@FCS_ID";
			//par.DbType =DbType.Int32;
			//par.Direction =ParameterDirection.Output;
			//Adapter.InsertCommand.CommandText +=";SELECT @FCS_ID=SCOPE_IDENTITY();";
			//Adapter.InsertCommand.Parameters.Add(par);
		}

		public void GuardarMovConsumido(MovConsumido oMovConsumido)
		{
			DbCommand cmdInsert = Adapter.InsertCommand;
			cmdInsert.Parameters["@FCS_ID"].Value=oMovConsumido.FCS_ID;
			cmdInsert.Parameters["@PAQUETEID"].Value=oMovConsumido.PAQUETEID;
			cmdInsert.Parameters["@CENTRO_TRABAJO"].Value=oMovConsumido.CENTRO_TRABAJO;
			cmdInsert.Parameters["@NRO_ORDEN"].Value=oMovConsumido.NRO_ORDEN;
			cmdInsert.Parameters["@CANTIDAD_CONSUMIDA"].Value=oMovConsumido.CANTIDAD_CONSUMIDA;
			cmdInsert.Parameters["@UNIDAD"].Value=oMovConsumido.UNIDAD;
			cmdInsert.Parameters["@STATUS"].Value=oMovConsumido.STATUS;
			cmdInsert.Parameters["@FECHA"].Value=oMovConsumido.FECHA;
			cmdInsert.Parameters["@FCS_BATCH_LABEL_1"].Value=oMovConsumido.FCS_BATCH_LABEL_1;
            cmdInsert.Parameters["@Item"].Value = oMovConsumido.Item;
            cmdInsert.Parameters["@Item_Desc"].Value = oMovConsumido.Item_Desc;
            cmdInsert.Parameters["@AXTrackingType"].Value = oMovConsumido.AXTrackingType ;
            cmdInsert.Parameters["@AXUnitMeasure"].Value = oMovConsumido.AXUnitMeasure ;
            cmdInsert.Parameters["@AXCode"].Value = oMovConsumido.AXCode;
            cmdInsert.Parameters["@Colada"].Value = oMovConsumido.Colada;
            cmdInsert.Parameters["@NumSerie"].Value = oMovConsumido.NumSerie;
            cmdInsert.Parameters["@FechaIntegracion"].Value = oMovConsumido.FechaIntegracion ;
            cmdInsert.Parameters["@FCS_MACHINE"].Value = oMovConsumido.FCS_MACHINE;
            EjecutarComando(cmdInsert);
			//oMovConsumido.FCS_ID=Convert.ToInt32(cmdInsert.Parameters["@FCS_ID"].Value);
		}


		public void ModificarMovConsumido(MovConsumido oMovConsumido)
		{
			DbCommand cmdModificar = Adapter.UpdateCommand;
			cmdModificar.Parameters["@FCS_ID"].Value=oMovConsumido.FCS_ID;
			cmdModificar.Parameters["@PAQUETEID"].Value=oMovConsumido.PAQUETEID;
			cmdModificar.Parameters["@CENTRO_TRABAJO"].Value=oMovConsumido.CENTRO_TRABAJO;
			cmdModificar.Parameters["@NRO_ORDEN"].Value=oMovConsumido.NRO_ORDEN;
			cmdModificar.Parameters["@CANTIDAD_CONSUMIDA"].Value=oMovConsumido.CANTIDAD_CONSUMIDA;
			cmdModificar.Parameters["@UNIDAD"].Value=oMovConsumido.UNIDAD;
			cmdModificar.Parameters["@STATUS"].Value=oMovConsumido.STATUS;
			cmdModificar.Parameters["@FECHA"].Value=oMovConsumido.FECHA;
			cmdModificar.Parameters["@FCS_BATCH_LABEL_1"].Value=oMovConsumido.FCS_BATCH_LABEL_1;
            cmdModificar.Parameters["@Original_FCS_ID"].Value = oMovConsumido.FCS_ID;
            cmdModificar.Parameters["@Item"].Value = oMovConsumido.Item;
            cmdModificar.Parameters["@Item_Desc"].Value = oMovConsumido.Item_Desc;
            cmdModificar.Parameters["@AXTrackingType"].Value = oMovConsumido.AXTrackingType;
            cmdModificar.Parameters["@AXUnitMeasure"].Value = oMovConsumido.AXUnitMeasure;
            cmdModificar.Parameters["@AXCode"].Value = oMovConsumido.AXCode;
            cmdModificar.Parameters["@Colada"].Value = oMovConsumido.Colada;
            cmdModificar.Parameters["@NumSerie"].Value = oMovConsumido.NumSerie;
            cmdModificar.Parameters["@FechaIntegracion"].Value = oMovConsumido.FechaIntegracion;

            EjecutarComando(cmdModificar);
		}


		public void EliminarMovConsumido(string vFCS_ID)
		{
			DbCommand cmdDelete = Adapter.DeleteCommand;
			cmdDelete.Parameters["@Original_FCS_ID"].Value= vFCS_ID;
			EjecutarComando(cmdDelete);
		}


		public DataSet TraerTodosMovConsumido()
		{
			return this.Consultar("");
		}

        public DataSet TraerTodosMovConsumido(string centro,string orden)
        {
            return this.Consultar("Nro_Orden='"+orden+"' order by Fechaintegracion");
        }

        public List<MovConsumido> TraerListaMovConsumidos(string Orden)
        {
            List<MovConsumido> consumidos = new List<MovConsumido>();
            DataSet ds = this.Consultar("Nro_Orden='" + Orden +"'");
            foreach (DataRow rMovConsumido in ds.Tables[0].Rows)
            {
                MovConsumido oMovConsumido = new MovConsumido ();
                oMovConsumido.FCS_ID = Guid.Parse(rMovConsumido["FCS_ID"].ToString());
                oMovConsumido.PAQUETEID = Convert.ToString(rMovConsumido["PAQUETEID"]);
                oMovConsumido.CENTRO_TRABAJO = Convert.ToString(rMovConsumido["CENTRO_TRABAJO"]);
                oMovConsumido.NRO_ORDEN = Convert.ToString(rMovConsumido["NRO_ORDEN"]);
                oMovConsumido.CANTIDAD_CONSUMIDA = Convert.ToDecimal(rMovConsumido["CANTIDAD_CONSUMIDA"]);
                oMovConsumido.UNIDAD = Convert.ToString(rMovConsumido["UNIDAD"]);
                oMovConsumido.STATUS = Convert.ToString(rMovConsumido["STATUS"]);
                oMovConsumido.FECHA = Convert.ToDateTime(rMovConsumido["FECHA"]);
                oMovConsumido.FCS_BATCH_LABEL_1 = Convert.ToString(rMovConsumido["FCS_BATCH_LABEL_1"]);
                oMovConsumido.Item = Convert.ToString(rMovConsumido["Item"]);
                oMovConsumido.Item_Desc = Convert.ToString(rMovConsumido["Item_Desc"]);
                oMovConsumido.AXTrackingType = Convert.ToString(rMovConsumido["AXTrackingType"]);
                oMovConsumido.AXUnitMeasure = Convert.ToString(rMovConsumido["AXUnitMeasure"]);
                oMovConsumido.AXCode = Convert.ToString(rMovConsumido["AXCode"]);
                oMovConsumido.Colada = Convert.ToString(rMovConsumido["Colada"]);
                oMovConsumido.NumSerie = Convert.ToString(rMovConsumido["NumSerie"]);
                oMovConsumido.FechaIntegracion = Convert.ToDateTime(rMovConsumido["FechaIntegracion"]);
                oMovConsumido.FCS_MACHINE = Convert.ToString (rMovConsumido["FCS_MACHINE"]);
                consumidos.Add(oMovConsumido);
            }
            return consumidos;
        }

        public MovConsumido TraerMovConsumido(string vFCS_ID)
		{
			DataSet ds = this.Consultar("FCS_ID='" + vFCS_ID +"'");
			DataTable tMovConsumido = ds.Tables[0];
			if (tMovConsumido.Rows.Count == 0)
			{
				return null;
			}
			DataRow rMovConsumido = tMovConsumido.Rows[0];
			MovConsumido oMovConsumido = new MovConsumido();
			oMovConsumido.FCS_ID = Guid.Parse(rMovConsumido["FCS_ID"].ToString());
			oMovConsumido.PAQUETEID = Convert.ToString(rMovConsumido["PAQUETEID"]);
			oMovConsumido.CENTRO_TRABAJO = Convert.ToString(rMovConsumido["CENTRO_TRABAJO"]);
			oMovConsumido.NRO_ORDEN = Convert.ToString(rMovConsumido["NRO_ORDEN"]);
			oMovConsumido.CANTIDAD_CONSUMIDA = Convert.ToDecimal(rMovConsumido["CANTIDAD_CONSUMIDA"]);
			oMovConsumido.UNIDAD = Convert.ToString(rMovConsumido["UNIDAD"]);
			oMovConsumido.STATUS = Convert.ToString(rMovConsumido["STATUS"]);
			oMovConsumido.FECHA = Convert.ToDateTime(rMovConsumido["FECHA"]);
			oMovConsumido.FCS_BATCH_LABEL_1 = Convert.ToString(rMovConsumido["FCS_BATCH_LABEL_1"]);
            oMovConsumido.Item = Convert.ToString(rMovConsumido["Item"]);
            oMovConsumido.Item_Desc = Convert.ToString(rMovConsumido["Item_Desc"]);
            oMovConsumido.AXTrackingType = Convert.ToString(rMovConsumido["AXTrackingType"]);
            oMovConsumido.AXUnitMeasure = Convert.ToString(rMovConsumido["AXUnitMeasure"]);
            oMovConsumido.AXCode = Convert.ToString(rMovConsumido["AXCode"]);
            oMovConsumido.Colada = Convert.ToString(rMovConsumido["Colada"]);
            oMovConsumido.NumSerie = Convert.ToString(rMovConsumido["NumSerie"]);
            oMovConsumido.FechaIntegracion = Convert.ToDateTime(rMovConsumido["FechaIntegracion"]);
            oMovConsumido.FCS_MACHINE = Convert.ToString(rMovConsumido["FCS_MACHINE"]);
            return oMovConsumido;
		}


	}
}
