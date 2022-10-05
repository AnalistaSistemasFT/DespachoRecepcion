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
	public class CADProducto:DBDAC
	{
		public CADProducto():base("SQLSERVER2","dbo.Mes_tb_lst_product")
		{

			DbParameter par=this.CrearParametro();
			par.ParameterName ="@LPR_PRODUCT_CODE";
			par.DbType =DbType.Int32;
			par.Direction =ParameterDirection.Output;
			Adapter.InsertCommand.CommandText +=";SELECT @LPR_PRODUCT_CODE=SCOPE_IDENTITY();";
			Adapter.InsertCommand.Parameters.Add(par);
		}

		public DataSet TraerTodosProducto()
		{
			return this.Consultar("");
		}


		public Producto  TraerProducto(string vLPR_PRODUCT_CODE)
		{
			DataSet ds = this.Consultar("LPR_PRODUCT_CODE=" + vLPR_PRODUCT_CODE);
			DataTable tProducto = ds.Tables[0];
			if (tProducto.Rows.Count == 0)
			{
				return null;
			}
			DataRow rProducto = tProducto.Rows[0];
			Producto oProducto = new Producto();
			oProducto.LPR_PRODUCT_CODE = Convert.ToString(rProducto["LPR_PRODUCT_CODE"]);
			oProducto.LPR_PRODUCT_VERSION = Convert.ToString(rProducto["LPR_PRODUCT_VERSION"]);
			oProducto.LPR_PRODUCT_DESC = Convert.ToString(rProducto["LPR_PRODUCT_DESC"]);
			oProducto.LPR_MEAS_UNIT = Convert.ToString(rProducto["LPR_MEAS_UNIT"]);
			oProducto.LPR_PURCHASE_MEAS_UNIT = Convert.ToString(rProducto["LPR_PURCHASE_MEAS_UNIT"]);
			oProducto.LPR_TECH_MEAS_UNIT = Convert.ToString(rProducto["LPR_TECH_MEAS_UNIT"]);
			oProducto.LPR_COEFF_PURCHASE_MEAS = Convert.ToDouble(rProducto["LPR_COEFF_PURCHASE_MEAS"]);
			oProducto.LPR_COEFF_TECH_MEAS = Convert.ToDouble(rProducto["LPR_COEFF_TECH_MEAS"]);
			oProducto.LPR_LOCATION_MNG = Convert.ToBoolean(rProducto["LPR_LOCATION_MNG"]);
			oProducto.LPR_BATCH_MNG = Convert.ToBoolean(rProducto["LPR_BATCH_MNG"]);
			oProducto.LPR_INS_DATE = Convert.ToDateTime(rProducto["LPR_INS_DATE"]);
			oProducto.LPR_ENABLED = Convert.ToBoolean(rProducto["LPR_ENABLED"]);
			oProducto.LPR_DATE = Convert.ToDateTime(rProducto["LPR_DATE"]);
			oProducto.LPR_PLANT = Convert.ToString(rProducto["LPR_PLANT"]);
			oProducto.LPR_ISSUES = Convert.ToString(rProducto["LPR_ISSUES"]);
			return oProducto;
		}

	}
}
