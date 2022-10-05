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
	public class CADConsumido:DBDAC
	{
		public CADConsumido():base("SQLSERVER2","dbo.Mes_tb_fld_consumed")
		{

            //DbParameter par=this.CrearParametro();
            //par.ParameterName ="@FCS_ID";
            //par.DbType =DbType.Int32;
            //par.Direction =ParameterDirection.Output;
            //Adapter.InsertCommand.CommandText +=";SELECT @FCS_ID=SCOPE_IDENTITY();";
            //Adapter.InsertCommand.Parameters.Add(par);
		}

		public void GuardarConsumido(Consumido oConsumido)
		{
            //DbCommand cmdInsert = Adapter.InsertCommand;
            ////cmdInsert.Parameters["@FCS_ID"].Value=oConsumido.FCS_ID;
            //cmdInsert.Parameters["@FCS_BATCH"].Value=oConsumido.FCS_BATCH;
            //cmdInsert.Parameters["@FCS_WORKCENTER"].Value=oConsumido.FCS_WORKCENTER;
            //cmdInsert.Parameters["@FCS_MACHINE"].Value=oConsumido.FCS_MACHINE;
            //cmdInsert.Parameters["@FCS_PO"].Value=oConsumido.FCS_PO;
            //cmdInsert.Parameters["@FCS_OPR"].Value=oConsumido.FCS_OPR;
            //cmdInsert.Parameters["@FCS_CONSUMED_QTY"].Value=oConsumido.FCS_CONSUMED_QTY;
            //cmdInsert.Parameters["@FCS_QTY_UM"].Value=oConsumido.FCS_QTY_UM;
            //cmdInsert.Parameters["@FCS_START"].Value=oConsumido.FCS_START;
            //cmdInsert.Parameters["@FCS_END"].Value=oConsumido.FCS_END;
            //cmdInsert.Parameters["@FCS_SEQUENCE"].Value=oConsumido.FCS_SEQUENCE;
            ////cmdInsert.Parameters["@FCS_SUB_SEQUENCE"].Value=oConsumido.FCS_SUB_SEQUENCE;
            //cmdInsert.Parameters["@FCS_GROUP"].Value=oConsumido.FCS_GROUP;
            //cmdInsert.Parameters["@FCS_OPERATOR"].Value=oConsumido.FCS_OPERATOR;
            ////cmdInsert.Parameters["@FCS_OPERATOR_ID"].Value=oConsumido.FCS_OPERATOR_ID;
            //cmdInsert.Parameters["@FCS_SHIFT"].Value=oConsumido.FCS_SHIFT;
            ////cmdInsert.Parameters["@FCS_SHIFT_ID"].Value=oConsumido.FCS_SHIFT_ID;
            //cmdInsert.Parameters["@FCS_STATUS"].Value=oConsumido.FCS_STATUS;
            //cmdInsert.Parameters["@FCS_STATUS_DATE"].Value=oConsumido.FCS_STATUS_DATE;
            ////cmdInsert.Parameters["@lastModified"].Value=oConsumido.lastModified;
            //cmdInsert.Parameters["@FCS_BATCH_LABEL_1"].Value=oConsumido.FCS_BATCH_LABEL_1;
            //cmdInsert.Parameters["@FCS_PROGRAM"].Value=oConsumido.FCS_PROGRAM;
            //cmdInsert.Parameters["@FCS_PROGRAM_ROW"].Value=oConsumido.FCS_PROGRAM_ROW;
            //EjecutarComando(cmdInsert);
            //oConsumido.FCS_ID=Convert.ToInt32(cmdInsert.Parameters["@FCS_ID"].Value);
		}


		public void ModificarConsumido(Consumido oConsumido)
		{
            //DbCommand cmdModificar = Adapter.UpdateCommand;
            //cmdModificar.Parameters["@FCS_ID"].Value=oConsumido.FCS_ID;
            //cmdModificar.Parameters["@FCS_BATCH"].Value=oConsumido.FCS_BATCH;
            //cmdModificar.Parameters["@FCS_WORKCENTER"].Value=oConsumido.FCS_WORKCENTER;
            //cmdModificar.Parameters["@FCS_MACHINE"].Value=oConsumido.FCS_MACHINE;
            //cmdModificar.Parameters["@FCS_PO"].Value=oConsumido.FCS_PO;
            //cmdModificar.Parameters["@FCS_OPR"].Value=oConsumido.FCS_OPR;
            //cmdModificar.Parameters["@FCS_CONSUMED_QTY"].Value=oConsumido.FCS_CONSUMED_QTY;
            //cmdModificar.Parameters["@FCS_QTY_UM"].Value=oConsumido.FCS_QTY_UM;
            //cmdModificar.Parameters["@FCS_START"].Value=oConsumido.FCS_START;
            //cmdModificar.Parameters["@FCS_END"].Value=oConsumido.FCS_END;
            //cmdModificar.Parameters["@FCS_SEQUENCE"].Value=oConsumido.FCS_SEQUENCE;
            //cmdModificar.Parameters["@FCS_SUB_SEQUENCE"].Value=oConsumido.FCS_SUB_SEQUENCE;
            //cmdModificar.Parameters["@FCS_GROUP"].Value=oConsumido.FCS_GROUP;
            //cmdModificar.Parameters["@FCS_OPERATOR"].Value=oConsumido.FCS_OPERATOR;
            //cmdModificar.Parameters["@FCS_OPERATOR_ID"].Value=oConsumido.FCS_OPERATOR_ID;
            //cmdModificar.Parameters["@FCS_SHIFT"].Value=oConsumido.FCS_SHIFT;
            //cmdModificar.Parameters["@FCS_SHIFT_ID"].Value=oConsumido.FCS_SHIFT_ID;
            //cmdModificar.Parameters["@FCS_STATUS"].Value=oConsumido.FCS_STATUS;
            //cmdModificar.Parameters["@FCS_STATUS_DATE"].Value=oConsumido.FCS_STATUS_DATE;
            //cmdModificar.Parameters["@lastModified"].Value=oConsumido.lastModified;
            //cmdModificar.Parameters["@FCS_BATCH_LABEL_1"].Value=oConsumido.FCS_BATCH_LABEL_1;
            //cmdModificar.Parameters["@FCS_PROGRAM"].Value=oConsumido.FCS_PROGRAM;
            //cmdModificar.Parameters["@FCS_PROGRAM_ROW"].Value=oConsumido.FCS_PROGRAM_ROW;
            //EjecutarComando(cmdModificar);
		}


		public void EliminarConsumido(Guid vFCS_ID)
		{
            //DbCommand cmdDelete = Adapter.DeleteCommand;
            //cmdDelete.Parameters["@Original_FCS_ID"].Value= vFCS_ID;
            //EjecutarComando(cmdDelete);
		}


		public DataSet TraerTodosConsumido()
        {
			return this.Consultar("");
		} 

        public DataSet TraerTodosConsumido(string centro,string orden)
        {
            string Consulta;
            switch (centro)
            {
                case "SLI01":
                    Consulta = "select distinct FCS_BATCH [Paquete]," +
                                "FBC_PRODUCT_CODE [Item],FBC_PRODUCT_DESC [Descripcion]," +
                                "(select LPF_VALUE from [ElsystemNet_Ferrotodo].[dbo].[MES_TB_LST_PRODUCT_FEATURE] where LPF_FEATURE='AX_TRACKINGTYPE' and LPF_PRODUCT_CODE=FBC_PRODUCT_CODE) as AXTrackingType," +
                                "(select LPF_VALUE from [ElsystemNet_Ferrotodo].[dbo].[MES_TB_LST_PRODUCT_FEATURE] where LPF_FEATURE='AX_UNITMEASURE' and LPF_PRODUCT_CODE=FBC_PRODUCT_CODE) as AXUnitMeasure," +
                                "(select LPF_VALUE from [ElsystemNet_Ferrotodo].[dbo].[MES_TB_LST_PRODUCT_FEATURE] where LPF_FEATURE='AX_CODE' and LPF_PRODUCT_CODE=FBC_PRODUCT_CODE) as AXCode," +
                                "(select LEFT(fbF_VALUE,20) from [ElsystemNet_Ferrotodo].[dbo].MES_TB_FLD_BATCH_FEATURE where FBF_FEATURE ='HEAT' and FBF_BATCH =FBC_BATCH) as Colada," +
                                "round(FBC_WEIGHT,2) [Cantidad]," +
                                "FCS_QTY_UM [Unidad]," +
                                "FCS_STATUS_DATE [Fecha]," +
                                "FCS_BATCH_LABEL_1 [Origen], " +
                                "FBC_BATCH_LABEL_2 [NumSerie], " +
                                "FCS_MACHINE " +
                                "from (((ElsystemNet_Ferrotodo.dbo.MES_TB_SLI_ASSEMBLING_CUT inner join ElsystemNet_Ferrotodo.dbo.MES_TB_PRO_OPR on SAC_ASSEMBLING_CUT =OPR_ASSEMBLING_CUT_NAME) " +
                                "inner join ElsystemNet_Ferrotodo.dbo.MES_TB_FLD_CONSUMED on OPR_PO=fCs_PO) inner join [ElsystemNet_Ferrotodo].[dbo].MES_TB_FLD_BATCHES on FCS_BATCH=FBC_BATCH) " +
                                "where SAC_ASSEMBLING_CUT ='" + orden + "'";
            
                    break;
                default:
                    Consulta="SELECT FCS_BATCH [Paquete],"+
                                      "FBC_PRODUCT_CODE [Item],FBC_PRODUCT_DESC [Descripcion]," +
                                      "(select LPF_VALUE from [ElsystemNet_Ferrotodo].[dbo].[MES_TB_LST_PRODUCT_FEATURE] where LPF_FEATURE='AX_TRACKINGTYPE' and LPF_PRODUCT_CODE=FBC_PRODUCT_CODE) as AXTrackingType," +
                                      "(select LPF_VALUE from [ElsystemNet_Ferrotodo].[dbo].[MES_TB_LST_PRODUCT_FEATURE] where LPF_FEATURE='AX_UNITMEASURE' and LPF_PRODUCT_CODE=FBC_PRODUCT_CODE) as AXUnitMeasure," +
                                      "(select LPF_VALUE from [ElsystemNet_Ferrotodo].[dbo].[MES_TB_LST_PRODUCT_FEATURE] where LPF_FEATURE='AX_CODE' and LPF_PRODUCT_CODE=FBC_PRODUCT_CODE) as AXCode,"+
                                      "(select LEFT(fbF_VALUE,20) from [ElsystemNet_Ferrotodo].[dbo].MES_TB_FLD_BATCH_FEATURE where FBF_FEATURE ='HEAT' and FBF_BATCH =FBC_BATCH) as Colada," +
                                      "round(FCS_CONSUMED_QTY,2) [Cantidad],"+
                                      "FCS_QTY_UM [Unidad],"+
                                      "FCS_STATUS_DATE [Fecha],"+
                                      "FCS_BATCH_LABEL_1 [Origen], "+
                                      "FBC_BATCH_LABEL_2 [NumSerie], "+
                                      "FCS_MACHINE " +
                                    "FROM ([ElsystemNet_Ferrotodo].[dbo].[MES_TB_FLD_CONSUMED] inner join [ElsystemNet_Ferrotodo].[dbo].MES_TB_FLD_BATCHES on FCS_BATCH=FBC_BATCH) " +
                                    "where fcs_po='" + orden + "'";
                    break;
                
            }
            return this.EjecutarConsulta(Consulta);
        }
        public DataSet TraerResumenConsumido(string Centro,string orden)
        {
            string Consulta;
            switch (Centro)
            {
                case "SLI01":
                    Consulta = "select distinct fbc_batch " +
                            "FROM (ElsystemNet_Ferrotodo.dbo.MES_TB_FLD_BATCHES inner join ElsystemNet_Ferrotodo.dbo.MES_TB_FLD_CONSUMED on FCS_batch =FBC_batch) inner join ElsystemNet_Ferrotodo.dbo.MES_TB_PRO_OPR on OPR_PO=FCS_PO " +
                            "where OPR_ASSEMBLING_CUT_NAME ='" + orden + "' ";
                    DataSet ds = EjecutarConsulta(Consulta);
                    int pzasBob = ds.Tables[0].Rows.Count;
                    Consulta = "SELECT fbc_product_code [Item],FBC_PRODUCT_DESC,SUM(FCS_CONSUMED_QTY)  [Cantidad],[FCS_QTY_UM]," + pzasBob + " [piezas] " +
                    "FROM (ElsystemNet_Ferrotodo.dbo.MES_TB_FLD_BATCHES inner join ElsystemNet_Ferrotodo.dbo.MES_TB_FLD_CONSUMED on FCS_batch =FBC_batch) inner join ElsystemNet_Ferrotodo.dbo.MES_TB_PRO_OPR on OPR_PO=FCS_PO " +
                    "where OPR_ASSEMBLING_CUT_NAME ='" + orden + "'";
                    break;
                 default:
                    Consulta = "SELECT FBC_PRODUCT_CODE [Item],FBC_PRODUCT_DESC,sum([FCS_CONSUMED_QTY]) [Cantidad],[FCS_QTY_UM],count(*) [Piezas] " +
                            "FROM [ElsystemNet_Ferrotodo].[dbo].[MES_TB_FLD_CONSUMED] inner join [ElsystemNet_Ferrotodo].[dbo].MES_TB_FLD_BATCHES on FCS_BATCH=FBC_BATCH " +
                            "where fcs_po='" + orden + "' ";
                            
                    break;

            }
            Consulta = Consulta + "Group by FBC_PRODUCT_CODE,FBC_PRODUCT_DESC,FCS_QTY_UM";
            return this.EjecutarConsulta(Consulta);
        }

		public Consumido  TraerConsumido(string cod)
		{
			DataSet ds = this.Consultar("FCS_Batch=" + cod);
			DataTable tConsumido = ds.Tables[0];
			if (tConsumido.Rows.Count == 0)
			{
				return null;
			}
			DataRow rConsumido = tConsumido.Rows[0];
			Consumido oConsumido = new Consumido();
            //oConsumido.FCS_ID = Convert.(rConsumido["FCS_ID"]);
			oConsumido.FCS_BATCH = Convert.ToString(rConsumido["FCS_BATCH"]);
			oConsumido.FCS_WORKCENTER = Convert.ToString(rConsumido["FCS_WORKCENTER"]);
			oConsumido.FCS_MACHINE = Convert.ToString(rConsumido["FCS_MACHINE"]);
			oConsumido.FCS_PO = Convert.ToString(rConsumido["FCS_PO"]);
			oConsumido.FCS_OPR = Convert.ToString(rConsumido["FCS_OPR"]);
			oConsumido.FCS_CONSUMED_QTY = Convert.ToDecimal(rConsumido["FCS_CONSUMED_QTY"]);
			oConsumido.FCS_QTY_UM = Convert.ToString(rConsumido["FCS_QTY_UM"]);
			oConsumido.FCS_START = Convert.ToDateTime(rConsumido["FCS_START"]);
			oConsumido.FCS_END = Convert.ToDateTime(rConsumido["FCS_END"]);
			oConsumido.FCS_SEQUENCE = Convert.ToInt32(rConsumido["FCS_SEQUENCE"]);
			oConsumido.FCS_GROUP = Convert.ToString(rConsumido["FCS_GROUP"]);
			oConsumido.FCS_OPERATOR = Convert.ToString(rConsumido["FCS_OPERATOR"]);
			oConsumido.FCS_SHIFT = Convert.ToString(rConsumido["FCS_SHIFT"]);
			oConsumido.FCS_STATUS = Convert.ToString(rConsumido["FCS_STATUS"]);
			oConsumido.FCS_STATUS_DATE = Convert.ToDateTime(rConsumido["FCS_STATUS_DATE"]);
			oConsumido.FCS_BATCH_LABEL_1 = Convert.ToString(rConsumido["FCS_BATCH_LABEL_1"]);
			oConsumido.FCS_PROGRAM = Convert.ToString(rConsumido["FCS_PROGRAM"]);
			oConsumido.FCS_PROGRAM_ROW = Convert.ToString(rConsumido["FCS_PROGRAM_ROW"]);
			return oConsumido;
		}


	}
}
