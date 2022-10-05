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
	public class CADMovProducido:DBDAC
	{
		public CADMovProducido():base("SQLSERVER","dbo.Producido")
		{
			//DbParameter par=this.CrearParametro();
			//par.ParameterName ="@PAQUETEID";
			//par.DbType =DbType.Int32;
			//par.Direction =ParameterDirection.Output;
			//Adapter.InsertCommand.CommandText +=";SELECT @PAQUETEID=SCOPE_IDENTITY();";
			//Adapter.InsertCommand.Parameters.Add(par);
		}

		public void GuardarMovProducido(MovProducido oMovProducido)
		{
			DbCommand cmdInsert = Adapter.InsertCommand;
			cmdInsert.Parameters["@PAQUETEID"].Value=oMovProducido.PAQUETEID;
			cmdInsert.Parameters["@ITEM"].Value=oMovProducido.ITEM;
			cmdInsert.Parameters["@ITEM_DESC"].Value=oMovProducido.ITEM_DESC;
			cmdInsert.Parameters["@CENTRO_TRABAJO"].Value=oMovProducido.CENTRO_TRABAJO;
			cmdInsert.Parameters["@NRO_ORDEN"].Value=oMovProducido.NRO_ORDEN;
			cmdInsert.Parameters["@POSICION"].Value=oMovProducido.POSICION;
			cmdInsert.Parameters["@PESO"].Value=oMovProducido.PESO;
			cmdInsert.Parameters["@PIEZAS"].Value=oMovProducido.PIEZAS;
			cmdInsert.Parameters["@METROS"].Value=oMovProducido.METROS;
			cmdInsert.Parameters["@FECHA"].Value=oMovProducido.FECHA;
			cmdInsert.Parameters["@CALIDAD"].Value=oMovProducido.CALIDAD;
			cmdInsert.Parameters["@FBC_BATCH_LABEL_1"].Value=oMovProducido.FBC_BATCH_LABEL_1;
			cmdInsert.Parameters["@FBC_BATCH_LABEL_2"].Value=oMovProducido.FBC_BATCH_LABEL_2;
			cmdInsert.Parameters["@STATUS"].Value=oMovProducido.STATUS;
            cmdInsert.Parameters["@AXUnitMeasure"].Value = oMovProducido.AXUnitMeasure;
            cmdInsert.Parameters["@AXCode"].Value = oMovProducido.AXCode;
            cmdInsert.Parameters["@Colada"].Value = oMovProducido.Colada;
            cmdInsert.Parameters["@FechaIntegracion"].Value = oMovProducido.FechaIntegracion;
            cmdInsert.Parameters["@CostoUnitario"].Value = oMovProducido.CostoUnitario;
            cmdInsert.Parameters["@CostoTotal"].Value = oMovProducido.CostoTotal;
            EjecutarComando(cmdInsert);
			//oMovProducido.PAQUETEID=Convert.ToInt32(cmdInsert.Parameters["@PAQUETEID"].Value);
		}
		public void ModificarMovProducido(MovProducido oMovProducido)
		{
			DbCommand cmdModificar = Adapter.UpdateCommand;
			cmdModificar.Parameters["@PAQUETEID"].Value=oMovProducido.PAQUETEID;
			cmdModificar.Parameters["@ITEM"].Value=oMovProducido.ITEM;
			cmdModificar.Parameters["@ITEM_DESC"].Value=oMovProducido.ITEM_DESC;
			cmdModificar.Parameters["@CENTRO_TRABAJO"].Value=oMovProducido.CENTRO_TRABAJO;
			cmdModificar.Parameters["@NRO_ORDEN"].Value=oMovProducido.NRO_ORDEN;
			cmdModificar.Parameters["@POSICION"].Value=oMovProducido.POSICION;
			cmdModificar.Parameters["@PESO"].Value=oMovProducido.PESO;
			cmdModificar.Parameters["@PIEZAS"].Value=oMovProducido.PIEZAS;
			cmdModificar.Parameters["@METROS"].Value=oMovProducido.METROS;
			cmdModificar.Parameters["@FECHA"].Value=oMovProducido.FECHA;
			cmdModificar.Parameters["@CALIDAD"].Value=oMovProducido.CALIDAD;
			cmdModificar.Parameters["@FBC_BATCH_LABEL_1"].Value=oMovProducido.FBC_BATCH_LABEL_1;
			cmdModificar.Parameters["@FBC_BATCH_LABEL_2"].Value=oMovProducido.FBC_BATCH_LABEL_2;
			cmdModificar.Parameters["@STATUS"].Value=oMovProducido.STATUS;
            cmdModificar.Parameters["@AXUnitMeasure"].Value = oMovProducido.AXUnitMeasure;
            cmdModificar.Parameters["@AXCode"].Value = oMovProducido.AXCode;
            cmdModificar.Parameters["@Colada"].Value = oMovProducido.Colada;
            cmdModificar.Parameters["@FechaIntegracion"].Value = oMovProducido.FechaIntegracion;
            cmdModificar.Parameters["@CostoUnitario"].Value = oMovProducido.CostoUnitario;
            cmdModificar.Parameters["@CostoTotal"].Value = oMovProducido.CostoTotal;
            cmdModificar.Parameters["@Original_PAQUETEID"].Value = oMovProducido.PAQUETEID;
            EjecutarComando(cmdModificar);
		}
		public void EliminarMovProducido(string vPAQUETEID)
		{
			DbCommand cmdDelete = Adapter.DeleteCommand;
			cmdDelete.Parameters["@Original_PAQUETEID"].Value= vPAQUETEID;
			EjecutarComando(cmdDelete);
		}
		public DataSet TraerTodosMovProducido()
		{
			return this.Consultar("");
		}
        public DataSet TraerTodosMovProducido(string orden)
        {
            return this.Consultar("Nro_Orden='" + orden + "' order by posicion");
        }
        public DataSet TraerTodosMovProducido(string centro, string orden)
        {
            string Consulta;
            if (centro == "SLI01")
            {
                Consulta = "select FBC_BATCH [Paquete],FBC_PRODUCT_CODE [Item],FBC_PRODUCT_DESC [Descripcion]," +
                            "(select LPF_VALUE from [ElsystemNet_Ferrotodo].[dbo].[MES_TB_LST_PRODUCT_FEATURE] where LPF_FEATURE='AX_TRACKINGTYPE' and LPF_PRODUCT_CODE=FBC_PRODUCT_CODE) as AXTrackingType," +
                            "(select LPF_VALUE from [ElsystemNet_Ferrotodo].[dbo].[MES_TB_LST_PRODUCT_FEATURE] where LPF_FEATURE='AX_UNITMEASURE' and LPF_PRODUCT_CODE=FBC_PRODUCT_CODE) as AXUnitMeasure," +
                            "(select LPF_VALUE from [ElsystemNet_Ferrotodo].[dbo].[MES_TB_LST_PRODUCT_FEATURE] where LPF_FEATURE='AX_CODE' and LPF_PRODUCT_CODE=FBC_PRODUCT_CODE) as AXCode," +
                            "(select left(fbF_VALUE,20) from [ElsystemNet_Ferrotodo].[dbo].MES_TB_FLD_BATCH_FEATURE where FBF_FEATURE ='HEAT' and FBF_BATCH =FBC_BATCH) as Colada," +
                            "FBC_WORKCENTER [Centro],FBC_WEIGHT [Peso],FBC_PIECE [Piezas]," +
                            "FBC_ISSUE [Estado],[FBC_BATCH_LABEL_1],fbc_ins_date " +
                            "from ((ElsystemNet_Ferrotodo.dbo.MES_TB_SLI_ASSEMBLING_CUT ass " +
                            "inner join ElsystemNet_Ferrotodo.dbo.MES_TB_PRO_OPR PO on ass.SAC_ASSEMBLING_CUT =po.OPR_ASSEMBLING_CUT_NAME) " +
                            "inner join ElsystemNet_Ferrotodo.dbo.MES_TB_FLD_BATCHES on po.OPR_PO=FBC_PO) " +
                            "where ass.SAC_ASSEMBLING_CUT ='" + orden + "' order by fbc_ins_date";
            }
            else
            {
                Consulta = "SELECT FBC_BATCH [Paquete],FBC_PRODUCT_CODE [Item],FBC_PRODUCT_DESC [Descripcion]," +
                                        "(select LPF_VALUE from [ElsystemNet_Ferrotodo].[dbo].[MES_TB_LST_PRODUCT_FEATURE] where LPF_FEATURE='AX_TRACKINGTYPE' and LPF_PRODUCT_CODE=FBC_PRODUCT_CODE) as AXTrackingType," +
                                        "(select LPF_VALUE from [ElsystemNet_Ferrotodo].[dbo].[MES_TB_LST_PRODUCT_FEATURE] where LPF_FEATURE='AX_UNITMEASURE' and LPF_PRODUCT_CODE=FBC_PRODUCT_CODE) as AXUnitMeasure," +
                                        "(select LPF_VALUE from [ElsystemNet_Ferrotodo].[dbo].[MES_TB_LST_PRODUCT_FEATURE] where LPF_FEATURE='AX_CODE' and LPF_PRODUCT_CODE=FBC_PRODUCT_CODE) as AXCode," +
                                        "(select left(fbF_VALUE,20) from [ElsystemNet_Ferrotodo].[dbo].MES_TB_FLD_BATCH_FEATURE where FBF_FEATURE ='HEAT' and FBF_BATCH =FBC_BATCH) as Colada," +
                                        "FBC_WORKCENTER [Centro],FBC_WEIGHT [Peso],FBC_PIECE [Piezas]," +
                                        "FBC_ISSUE [Estado],[FBC_BATCH_LABEL_1],fbc_ins_date " +
                                        "FROM [dbo].[MES_TB_FLD_BATCHES] " +
                                        "where fbc_po='" + orden + "' order by fbc_ins_date";
            }

            //return this.EjecutarConsulta("SELECT FBC_BATCH [Paquete],FBC_PRODUCT_CODE [Item],FBC_PRODUCT_DESC [Descripcion],"+
            //                            "(select LPF_VALUE from [ElsystemNet_Ferrotodo].[dbo].[MES_TB_LST_PRODUCT_FEATURE] where LPF_FEATURE='AX_CODE' and LPF_PRODUCT_CODE=FBC_PRODUCT_CODE) as AXCode,"+
            //                            "FBC_WORKCENTER [Centro],FBC_WEIGHT [Peso],FBC_PIECE [Piezas],"+
            //                            "FBC_ISSUE [Estado],[FBC_BATCH_LABEL_1]  "+
            //                            "FROM [dbo].[MES_TB_FLD_BATCHES] where fbc_po='"+orden+"'");
            return this.EjecutarConsulta(Consulta);
        }
        public List<MovProducido> TraerListaMovProducidos(string Orden)
        {
            List<MovProducido> producidos = new List<MovProducido>();
            DataSet ds = this.Consultar("Nro_Orden='" + Orden +"'");
            foreach (DataRow rMov in ds.Tables[0].Rows)
            {
                MovProducido oMovProducido = new MovProducido();
                oMovProducido.PAQUETEID = Convert.ToString(rMov["PAQUETEID"]);
                oMovProducido.ITEM = Convert.ToString(rMov["ITEM"]);
                oMovProducido.ITEM_DESC = Convert.ToString(rMov["ITEM_DESC"]);
                oMovProducido.CENTRO_TRABAJO = Convert.ToString(rMov["CENTRO_TRABAJO"]);
                oMovProducido.NRO_ORDEN = Convert.ToString(rMov["NRO_ORDEN"]);
                oMovProducido.POSICION = Convert.ToInt16(rMov["POSICION"]);
                oMovProducido.PESO = Convert.ToDecimal(rMov["PESO"]);
                oMovProducido.PIEZAS = Convert.ToInt16(rMov["PIEZAS"]);
                oMovProducido.METROS = Convert.ToDecimal(rMov["METROS"]);
                oMovProducido.FECHA = Convert.ToDateTime(rMov["FECHA"]);
                oMovProducido.CALIDAD = Convert.ToString(rMov["CALIDAD"]);
                oMovProducido.FBC_BATCH_LABEL_1 = Convert.ToString(rMov["FBC_BATCH_LABEL_1"]);
                oMovProducido.FBC_BATCH_LABEL_2 = Convert.ToString(rMov["FBC_BATCH_LABEL_2"]);
                oMovProducido.STATUS = Convert.ToString(rMov["STATUS"]);
                oMovProducido.AXUnitMeasure = Convert.ToString(rMov["AXUnitMeasure"]);
                oMovProducido.AXCode = Convert.ToString(rMov["AXCode"]);
                oMovProducido.Colada = Convert.ToString(rMov["Colada"]);
                oMovProducido.FechaIntegracion = Convert.ToDateTime(rMov["FechaIntegracion"]);
                oMovProducido.CostoUnitario = Convert.ToDecimal(rMov["CostoUnitario"]);
                oMovProducido.CostoTotal = Convert.ToDecimal(rMov["CostoTotal"]);
                producidos.Add(oMovProducido);
            }
            return producidos;
        }
        public MovProducido  TraerMovProducido(string vPAQUETEID)
		{
			DataSet ds = this.Consultar("PAQUETEID='" + vPAQUETEID +"'");
			DataTable tMovProducido = ds.Tables[0];
			if (tMovProducido.Rows.Count == 0)
			{
				return null;
			}
			DataRow rMovProducido = tMovProducido.Rows[0];
			MovProducido oMovProducido = new MovProducido();
			oMovProducido.PAQUETEID = Convert.ToString(rMovProducido["PAQUETEID"]);
			oMovProducido.ITEM = Convert.ToString(rMovProducido["ITEM"]);
			oMovProducido.ITEM_DESC = Convert.ToString(rMovProducido["ITEM_DESC"]);
			oMovProducido.CENTRO_TRABAJO = Convert.ToString(rMovProducido["CENTRO_TRABAJO"]);
			oMovProducido.NRO_ORDEN = Convert.ToString(rMovProducido["NRO_ORDEN"]);
			oMovProducido.POSICION = Convert.ToInt16(rMovProducido["POSICION"]);
			oMovProducido.PESO = Convert.ToDecimal(rMovProducido["PESO"]);
			oMovProducido.PIEZAS = Convert.ToInt16(rMovProducido["PIEZAS"]);
			oMovProducido.METROS = Convert.ToDecimal(rMovProducido["METROS"]);
			oMovProducido.FECHA = Convert.ToDateTime(rMovProducido["FECHA"]);
			oMovProducido.CALIDAD = Convert.ToString(rMovProducido["CALIDAD"]);
			oMovProducido.FBC_BATCH_LABEL_1 = Convert.ToString(rMovProducido["FBC_BATCH_LABEL_1"]);
			oMovProducido.FBC_BATCH_LABEL_2 = Convert.ToString(rMovProducido["FBC_BATCH_LABEL_2"]);
			oMovProducido.STATUS = Convert.ToString(rMovProducido["STATUS"]);
            oMovProducido.AXUnitMeasure = Convert.ToString(rMovProducido["AXUnitMeasure"]);
            oMovProducido.AXCode = Convert.ToString(rMovProducido["AXCode"]);
            oMovProducido.Colada = Convert.ToString(rMovProducido["Colada"]);
            oMovProducido.FechaIntegracion = Convert.ToDateTime(rMovProducido["FechaIntegracion"]);
            oMovProducido.CostoUnitario = Convert.ToDecimal(rMovProducido["CostoUnitario"]);
            oMovProducido.CostoTotal = Convert.ToDecimal(rMovProducido["CostoTotal"]);
            return oMovProducido;
		}


	}
}
