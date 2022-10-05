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
	public class CADBatches:DBDAC
	{
		public CADBatches():base("SQLSERVER","dbo.Mes_tb_fld_batches")
		{

			DbParameter par=this.CrearParametro();
			par.ParameterName ="@FBC_BATCH";
			par.DbType =DbType.Int32;
			par.Direction =ParameterDirection.Output;
			Adapter.InsertCommand.CommandText +=";SELECT @FBC_BATCH=SCOPE_IDENTITY();";
			Adapter.InsertCommand.Parameters.Add(par);
		}

		public void GuardarBatches(Batches oBatches)
		{
			DbCommand cmdInsert = Adapter.InsertCommand;
			cmdInsert.Parameters["@FBC_BATCH"].Value=oBatches.FBC_BATCH;
			cmdInsert.Parameters["@FBC_BATCH_FATHER"].Value=oBatches.FBC_BATCH_FATHER;
			cmdInsert.Parameters["@FBC_PRODUCT_GROUP"].Value=oBatches.FBC_PRODUCT_GROUP;
			cmdInsert.Parameters["@FBC_PRODUCT_CODE"].Value=oBatches.FBC_PRODUCT_CODE;
			cmdInsert.Parameters["@FBC_PRODUCT_VERSION"].Value=oBatches.FBC_PRODUCT_VERSION;
			cmdInsert.Parameters["@FBC_PRODUCT_DESC"].Value=oBatches.FBC_PRODUCT_DESC;
			cmdInsert.Parameters["@FBC_FEATURE_GROUP"].Value=oBatches.FBC_FEATURE_GROUP;
			cmdInsert.Parameters["@FBC_WORKCENTER"].Value=oBatches.FBC_WORKCENTER;
			cmdInsert.Parameters["@FBC_PO"].Value=oBatches.FBC_PO;
			cmdInsert.Parameters["@FBC_OPR"].Value=oBatches.FBC_OPR;
			cmdInsert.Parameters["@FBC_SO"].Value=oBatches.FBC_SO;
			cmdInsert.Parameters["@FBC_POS"].Value=oBatches.FBC_POS;
			cmdInsert.Parameters["@FBC_WEIGHT"].Value=oBatches.FBC_WEIGHT;
			cmdInsert.Parameters["@FBC_PIECE"].Value=oBatches.FBC_PIECE;
			cmdInsert.Parameters["@FBC_METERS"].Value=oBatches.FBC_METERS;
			cmdInsert.Parameters["@FBC_START"].Value=oBatches.FBC_START;
			cmdInsert.Parameters["@FBC_END"].Value=oBatches.FBC_END;
			cmdInsert.Parameters["@FBC_SHIFT_ID"].Value=oBatches.FBC_SHIFT_ID;
			cmdInsert.Parameters["@FBC_SHIFT"].Value=oBatches.FBC_SHIFT;
			cmdInsert.Parameters["@FBC_OPERATOR_ID"].Value=oBatches.FBC_OPERATOR_ID;
			cmdInsert.Parameters["@FBC_OPERATOR"].Value=oBatches.FBC_OPERATOR;
			cmdInsert.Parameters["@FBC_CONS_CONF"].Value=oBatches.FBC_CONS_CONF;
			cmdInsert.Parameters["@FBC_INS_DATE"].Value=oBatches.FBC_INS_DATE;
			cmdInsert.Parameters["@FBC_ISSUE"].Value=oBatches.FBC_ISSUE;
			cmdInsert.Parameters["@FBC_COUPLING"].Value=oBatches.FBC_COUPLING;
			cmdInsert.Parameters["@FBC_PASS"].Value=oBatches.FBC_PASS;
			cmdInsert.Parameters["@lastModified"].Value=oBatches.lastModified;
			cmdInsert.Parameters["@FBC_BATCH_LABEL_1"].Value=oBatches.FBC_BATCH_LABEL_1;
			cmdInsert.Parameters["@FBC_BATCH_LABEL_2"].Value=oBatches.FBC_BATCH_LABEL_2;
			cmdInsert.Parameters["@FBC_MACHINE"].Value=oBatches.FBC_MACHINE;
			cmdInsert.Parameters["@FBC_PROGRAM"].Value=oBatches.FBC_PROGRAM;
			cmdInsert.Parameters["@FBC_PROGRAM_ROW"].Value=oBatches.FBC_PROGRAM_ROW;
			cmdInsert.Parameters["@FBC_QUANTITY"].Value=oBatches.FBC_QUANTITY;
			cmdInsert.Parameters["@FBC_QTY_UM"].Value=oBatches.FBC_QTY_UM;
			EjecutarComando(cmdInsert);
			oBatches.FBC_BATCH=Convert.ToInt32(cmdInsert.Parameters["@FBC_BATCH"].Value);
		}


		public void ModificarBatches(Batches oBatches)
		{
			DbCommand cmdModificar = Adapter.UpdateCommand;
			cmdModificar.Parameters["@FBC_BATCH"].Value=oBatches.FBC_BATCH;
			cmdModificar.Parameters["@FBC_BATCH_FATHER"].Value=oBatches.FBC_BATCH_FATHER;
			cmdModificar.Parameters["@FBC_PRODUCT_GROUP"].Value=oBatches.FBC_PRODUCT_GROUP;
			cmdModificar.Parameters["@FBC_PRODUCT_CODE"].Value=oBatches.FBC_PRODUCT_CODE;
			cmdModificar.Parameters["@FBC_PRODUCT_VERSION"].Value=oBatches.FBC_PRODUCT_VERSION;
			cmdModificar.Parameters["@FBC_PRODUCT_DESC"].Value=oBatches.FBC_PRODUCT_DESC;
			cmdModificar.Parameters["@FBC_FEATURE_GROUP"].Value=oBatches.FBC_FEATURE_GROUP;
			cmdModificar.Parameters["@FBC_WORKCENTER"].Value=oBatches.FBC_WORKCENTER;
			cmdModificar.Parameters["@FBC_PO"].Value=oBatches.FBC_PO;
			cmdModificar.Parameters["@FBC_OPR"].Value=oBatches.FBC_OPR;
			cmdModificar.Parameters["@FBC_SO"].Value=oBatches.FBC_SO;
			cmdModificar.Parameters["@FBC_POS"].Value=oBatches.FBC_POS;
			cmdModificar.Parameters["@FBC_WEIGHT"].Value=oBatches.FBC_WEIGHT;
			cmdModificar.Parameters["@FBC_PIECE"].Value=oBatches.FBC_PIECE;
			cmdModificar.Parameters["@FBC_METERS"].Value=oBatches.FBC_METERS;
			cmdModificar.Parameters["@FBC_START"].Value=oBatches.FBC_START;
			cmdModificar.Parameters["@FBC_END"].Value=oBatches.FBC_END;
			cmdModificar.Parameters["@FBC_SHIFT_ID"].Value=oBatches.FBC_SHIFT_ID;
			cmdModificar.Parameters["@FBC_SHIFT"].Value=oBatches.FBC_SHIFT;
			cmdModificar.Parameters["@FBC_OPERATOR_ID"].Value=oBatches.FBC_OPERATOR_ID;
			cmdModificar.Parameters["@FBC_OPERATOR"].Value=oBatches.FBC_OPERATOR;
			cmdModificar.Parameters["@FBC_CONS_CONF"].Value=oBatches.FBC_CONS_CONF;
			cmdModificar.Parameters["@FBC_INS_DATE"].Value=oBatches.FBC_INS_DATE;
			cmdModificar.Parameters["@FBC_ISSUE"].Value=oBatches.FBC_ISSUE;
			cmdModificar.Parameters["@FBC_COUPLING"].Value=oBatches.FBC_COUPLING;
			cmdModificar.Parameters["@FBC_PASS"].Value=oBatches.FBC_PASS;
			cmdModificar.Parameters["@lastModified"].Value=oBatches.lastModified;
			cmdModificar.Parameters["@FBC_BATCH_LABEL_1"].Value=oBatches.FBC_BATCH_LABEL_1;
			cmdModificar.Parameters["@FBC_BATCH_LABEL_2"].Value=oBatches.FBC_BATCH_LABEL_2;
			cmdModificar.Parameters["@FBC_MACHINE"].Value=oBatches.FBC_MACHINE;
			cmdModificar.Parameters["@FBC_PROGRAM"].Value=oBatches.FBC_PROGRAM;
			cmdModificar.Parameters["@FBC_PROGRAM_ROW"].Value=oBatches.FBC_PROGRAM_ROW;
			cmdModificar.Parameters["@FBC_QUANTITY"].Value=oBatches.FBC_QUANTITY;
			cmdModificar.Parameters["@FBC_QTY_UM"].Value=oBatches.FBC_QTY_UM;
			EjecutarComando(cmdModificar);
		}


		public void EliminarBatches(string vFBC_BATCH)
		{
			DbCommand cmdDelete = Adapter.DeleteCommand;
			cmdDelete.Parameters["@Original_FBC_BATCH"].Value= vFBC_BATCH;
			EjecutarComando(cmdDelete);
		}


		public DataSet TraerTodosBatches()
		{
			return this.Consultar("");
		}


		public Batches  TraerBatches(string vFBC_BATCH)
		{
			DataSet ds = this.Consultar("FBC_BATCH=" + vFBC_BATCH);
			DataTable tBatches = ds.Tables[0];
			if (tBatches.Rows.Count == 0)
			{
				return null;
			}
			DataRow rBatches = tBatches.Rows[0];
			Batches oBatches = new Batches();
			oBatches.FBC_BATCH = Convert.ToString(rBatches["FBC_BATCH"]);
			oBatches.FBC_BATCH_FATHER = Convert.ToString(rBatches["FBC_BATCH_FATHER"]);
			oBatches.FBC_PRODUCT_GROUP = Convert.ToString(rBatches["FBC_PRODUCT_GROUP"]);
			oBatches.FBC_PRODUCT_CODE = Convert.ToString(rBatches["FBC_PRODUCT_CODE"]);
			oBatches.FBC_PRODUCT_VERSION = Convert.ToString(rBatches["FBC_PRODUCT_VERSION"]);
			oBatches.FBC_PRODUCT_DESC = Convert.ToString(rBatches["FBC_PRODUCT_DESC"]);
			oBatches.FBC_FEATURE_GROUP = Convert.ToString(rBatches["FBC_FEATURE_GROUP"]);
			oBatches.FBC_WORKCENTER = Convert.ToString(rBatches["FBC_WORKCENTER"]);
			oBatches.FBC_PO = Convert.ToString(rBatches["FBC_PO"]);
			oBatches.FBC_OPR = Convert.ToString(rBatches["FBC_OPR"]);
			oBatches.FBC_SO = Convert.ToString(rBatches["FBC_SO"]);
			oBatches.FBC_POS = Convert.ToString(rBatches["FBC_POS"]);
			oBatches.FBC_WEIGHT = Convert.ToDecimal(rBatches["FBC_WEIGHT"]);
			oBatches.FBC_PIECE = Convert.(rBatches["FBC_PIECE"]);
			oBatches.FBC_METERS = Convert.ToDecimal(rBatches["FBC_METERS"]);
			oBatches.FBC_START = Convert.ToDateTime(rBatches["FBC_START"]);
			oBatches.FBC_END = Convert.ToDateTime(rBatches["FBC_END"]);
			oBatches.FBC_SHIFT_ID = Convert.(rBatches["FBC_SHIFT_ID"]);
			oBatches.FBC_SHIFT = Convert.ToString(rBatches["FBC_SHIFT"]);
			oBatches.FBC_OPERATOR_ID = Convert.(rBatches["FBC_OPERATOR_ID"]);
			oBatches.FBC_OPERATOR = Convert.ToString(rBatches["FBC_OPERATOR"]);
			oBatches.FBC_CONS_CONF = Convert.(rBatches["FBC_CONS_CONF"]);
			oBatches.FBC_INS_DATE = Convert.ToDateTime(rBatches["FBC_INS_DATE"]);
			oBatches.FBC_ISSUE = Convert.ToString(rBatches["FBC_ISSUE"]);
			oBatches.FBC_COUPLING = Convert.ToString(rBatches["FBC_COUPLING"]);
			oBatches.FBC_PASS = Convert.(rBatches["FBC_PASS"]);
			oBatches.LastModified = Convert.(rBatches["LastModified"]);
			oBatches.FBC_BATCH_LABEL_1 = Convert.ToString(rBatches["FBC_BATCH_LABEL_1"]);
			oBatches.FBC_BATCH_LABEL_2 = Convert.ToString(rBatches["FBC_BATCH_LABEL_2"]);
			oBatches.FBC_MACHINE = Convert.ToString(rBatches["FBC_MACHINE"]);
			oBatches.FBC_PROGRAM = Convert.ToString(rBatches["FBC_PROGRAM"]);
			oBatches.FBC_PROGRAM_ROW = Convert.ToString(rBatches["FBC_PROGRAM_ROW"]);
			oBatches.FBC_QUANTITY = Convert.ToDecimal(rBatches["FBC_QUANTITY"]);
			oBatches.FBC_QTY_UM = Convert.ToString(rBatches["FBC_QTY_UM"]);
			return oBatches;
		}


	}
}
