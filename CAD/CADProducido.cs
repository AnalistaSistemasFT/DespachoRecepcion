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
	public class CADProducido:DBDAC
	{
		public CADProducido():base("SQLSERVER2","dbo.Mes_tb_fld_Batches")
		{

            //DbParameter par=this.CrearParametro();
            //par.ParameterName ="@FCF_ID";
            //par.DbType =DbType.Int32;
            //par.Direction =ParameterDirection.Output;
            //Adapter.InsertCommand.CommandText +=";SELECT @FCF_ID=SCOPE_IDENTITY();";
            //Adapter.InsertCommand.Parameters.Add(par);
		}

        //public void GuardarProducido(Producido oProducido)
        //{
        //    DbCommand cmdInsert = Adapter.InsertCommand;
        //    cmdInsert.Parameters["@FCF_ID"].Value=oProducido.FCF_ID;
        //    cmdInsert.Parameters["@FCF_BATCH"].Value=oProducido.FCF_BATCH;
        //    cmdInsert.Parameters["@FCF_LOT"].Value=oProducido.FCF_LOT;
        //    cmdInsert.Parameters["@FCF_STATUS"].Value=oProducido.FCF_STATUS;
        //    cmdInsert.Parameters["@FCF_STATUS_DATE"].Value=oProducido.FCF_STATUS_DATE;
        //    cmdInsert.Parameters["@lastModified"].Value=oProducido.lastModified;
        //    cmdInsert.Parameters["@FCF_BATCH_LABEL_1"].Value=oProducido.FCF_BATCH_LABEL_1;
        //    EjecutarComando(cmdInsert);
        //    oProducido.FCF_ID=Convert.ToInt32(cmdInsert.Parameters["@FCF_ID"].Value);
        //}


        //public void ModificarProducido(Producido oProducido)
        //{
        //    DbCommand cmdModificar = Adapter.UpdateCommand;
        //    cmdModificar.Parameters["@FCF_ID"].Value=oProducido.FCF_ID;
        //    cmdModificar.Parameters["@FCF_BATCH"].Value=oProducido.FCF_BATCH;
        //    cmdModificar.Parameters["@FCF_LOT"].Value=oProducido.FCF_LOT;
        //    cmdModificar.Parameters["@FCF_STATUS"].Value=oProducido.FCF_STATUS;
        //    cmdModificar.Parameters["@FCF_STATUS_DATE"].Value=oProducido.FCF_STATUS_DATE;
        //    cmdModificar.Parameters["@FCF_BATCH_LABEL_1"].Value=oProducido.FCF_BATCH_LABEL_1;
        //    EjecutarComando(cmdModificar);
        //}


        //public void EliminarProducido(Guid vFCF_ID)
        //{
        //    DbCommand cmdDelete = Adapter.DeleteCommand;
        //    cmdDelete.Parameters["@Original_FCF_ID"].Value= vFCF_ID;
        //    EjecutarComando(cmdDelete); 
        //}


		public DataSet TraerTodosProducido()
		{
			return this.Consultar("");
		}

        public DataSet TraerTodosProducido(string centro,string orden)
        {
            string Consulta;
            if(centro == "SLI01")
            {
                Consulta = "select FBC_BATCH [Paquete],FBC_PRODUCT_CODE [Item],FBC_PRODUCT_DESC [Descripcion]," +
                            "(select LPF_VALUE from [ElsystemNet_Ferrotodo].[dbo].[MES_TB_LST_PRODUCT_FEATURE] where LPF_FEATURE='AX_TRACKINGTYPE' and LPF_PRODUCT_CODE=FBC_PRODUCT_CODE) as AXTrackingType," +
                            "(select LPF_VALUE from [ElsystemNet_Ferrotodo].[dbo].[MES_TB_LST_PRODUCT_FEATURE] where LPF_FEATURE='AX_UNITMEASURE' and LPF_PRODUCT_CODE=FBC_PRODUCT_CODE) as AXUnitMeasure," +
		                    "(select LPF_VALUE from [ElsystemNet_Ferrotodo].[dbo].[MES_TB_LST_PRODUCT_FEATURE] where LPF_FEATURE='AX_CODE' and LPF_PRODUCT_CODE=FBC_PRODUCT_CODE) as AXCode,"+
                            "(select left(fbF_VALUE,20) from [ElsystemNet_Ferrotodo].[dbo].MES_TB_FLD_BATCH_FEATURE where FBF_FEATURE ='HEAT' and FBF_BATCH =FBC_BATCH) as Colada," +
		                    "FBC_WORKCENTER [Centro],round(FBC_WEIGHT,2) [Peso],FBC_PIECE [Piezas],"+
                            "FBC_ISSUE [Estado],[FBC_BATCH_LABEL_1],fbc_ins_date " +
                            "from ((ElsystemNet_Ferrotodo.dbo.MES_TB_SLI_ASSEMBLING_CUT ass "+
                            "inner join ElsystemNet_Ferrotodo.dbo.MES_TB_PRO_OPR PO on ass.SAC_ASSEMBLING_CUT =po.OPR_ASSEMBLING_CUT_NAME) "+
                            "inner join ElsystemNet_Ferrotodo.dbo.MES_TB_FLD_BATCHES on po.OPR_PO=FBC_PO) "+
                            "where ass.SAC_ASSEMBLING_CUT ='" + orden + "' order by fbc_ins_date";
            }
            else if (centro=="MALLA01"||centro=="MALLLA02")
            {
                Consulta = "SELECT FBC_BATCH [Paquete],FBC_PRODUCT_CODE [Item],FBC_PRODUCT_DESC [Descripcion]," +
                                        "(select LPF_VALUE from [ElsystemNet_Ferrotodo].[dbo].[MES_TB_LST_PRODUCT_FEATURE] where LPF_FEATURE='AX_TRACKINGTYPE' and LPF_PRODUCT_CODE=FBC_PRODUCT_CODE) as AXTrackingType," +
                                        "(select LPF_VALUE from [ElsystemNet_Ferrotodo].[dbo].[MES_TB_LST_PRODUCT_FEATURE] where LPF_FEATURE='AX_UNITMEASURE' and LPF_PRODUCT_CODE=FBC_PRODUCT_CODE) as AXUnitMeasure," +
                                        "(select LPF_VALUE from [ElsystemNet_Ferrotodo].[dbo].[MES_TB_LST_PRODUCT_FEATURE] where LPF_FEATURE='AX_CODE' and LPF_PRODUCT_CODE=FBC_PRODUCT_CODE) as AXCode," +
                                        "'HEAT' as Colada," +
                                        "FBC_WORKCENTER [Centro],FBC_WEIGHT [Peso],FBC_PIECE [Piezas]," +
                                        "FBC_ISSUE [Estado],[FBC_BATCH_LABEL_1],fbc_ins_date " +
                                        "FROM [dbo].[MES_TB_FLD_BATCHES] " +
                                        "where fbc_po='" + orden + "' order by fbc_ins_date";
            }
            else
            {
                Consulta = "SELECT FBC_BATCH [Paquete],FBC_PRODUCT_CODE [Item],FBC_PRODUCT_DESC [Descripcion]," +
                                        "(select LPF_VALUE from [ElsystemNet_Ferrotodo].[dbo].[MES_TB_LST_PRODUCT_FEATURE] where LPF_FEATURE='AX_TRACKINGTYPE' and LPF_PRODUCT_CODE=FBC_PRODUCT_CODE) as AXTrackingType,"+
                                        "(select LPF_VALUE from [ElsystemNet_Ferrotodo].[dbo].[MES_TB_LST_PRODUCT_FEATURE] where LPF_FEATURE='AX_UNITMEASURE' and LPF_PRODUCT_CODE=FBC_PRODUCT_CODE) as AXUnitMeasure,"+
                                        "(select LPF_VALUE from [ElsystemNet_Ferrotodo].[dbo].[MES_TB_LST_PRODUCT_FEATURE] where LPF_FEATURE='AX_CODE' and LPF_PRODUCT_CODE=FBC_PRODUCT_CODE) as AXCode,"+
                                        "case fbc_issue when 'GOOD' THEN (select left(fbF_VALUE,20) from [ElsystemNet_Ferrotodo].[dbo].MES_TB_FLD_BATCH_FEATURE where FBF_FEATURE ='HEAT' and FBF_BATCH =FBC_BATCH) else 'HEAT' END as Colada," +
                                        "FBC_WORKCENTER [Centro],FBC_WEIGHT [Peso],FBC_PIECE [Piezas],"+
                                        "FBC_ISSUE [Estado],[FBC_BATCH_LABEL_1],fbc_ins_date "+
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
        public DataSet TraerResumenProducido(string centro,string orden)
        {
            string Consulta, Consulta1;
            if(centro == "SLI01")
            {
                Consulta1 = "SELECT fbc_product_code [Item],FBC_PRODUCT_DESC [Descripcion],FBC_WORKCENTER [Centro],sum(FBC_WEIGHT) [Peso],COUNT(*) [PIEZAS],COUNT(*) [Paquetes] " +
                "FROM dbo.[MES_TB_PRO_OPR] inner join dbo.MES_TB_FLD_BATCHES on OPR_PO=FBC_PO " +
                "where OPR_ASSEMBLING_CUT_NAME ='" + orden + "' ";

                //string consulta2 = " union SELECT tblitem.ITEMID collate modern_spanish_ci_as,tblitem.descripcion,SUM(SCR_WEIGHT) AS peso,1 AS PIEZAS,tblItem.ItemFId,tblitem.unidadf,tblitem.calidad,tblitem.espesor " +
                //"FROM ((ElsystemNet_Ferrotodo.dbo.MES_TB_SLI_ASSEMBLING_CUT inner join ElsystemNet_Ferrotodo.dbo.MES_TB_PRO_OPR on SAC_ASSEMBLING_CUT=OPR_ASSEMBLING_CUT_NAME) inner join ElsystemNet_Ferrotodo.dbo.MES_TB_FLD_SCRAP on OPR_po=SCR_PO ),tblItem " +
                //"WHERE OPR_ASSEMBLING_CUT_NAME ='" + orden + "' and tblItem.ItemId='9016-0' " +
                //"group by convert(varchar,SAC_THICKNESS),tblItem.ItemId,tblItem.Descripcion,tblItem.ItemFId,tblitem.unidadf,tblitem.calidad,tblitem.espesor ";
            }
            else
            {
                Consulta1 = "SELECT FBC_PRODUCT_CODE [Item],FBC_PRODUCT_DESC [Descripcion]," +
                            "FBC_WORKCENTER [Centro],sum(FBC_WEIGHT) [Peso],sum(FBC_PIECE) [Piezas],count(*) [Paquetes] " +
                            "FROM [dbo].[MES_TB_FLD_BATCHES] where fbc_po='" + orden + "'";
            }
                
            Consulta=Consulta1 +"Group by [FBC_PRODUCT_CODE],[FBC_PRODUCT_DESC],[FBC_WORKCENTER]";
            return this.EjecutarConsulta(Consulta);
        }
		public Producido TraerProducido(string Cod)
		{
			DataSet ds = this.Consultar("FBC_BATCH='" + Cod +"'");
			DataTable tBatches = ds.Tables[0];
			if (tBatches.Rows.Count == 0)
			{
				return null;
			}
			DataRow rBatches = tBatches.Rows[0];
			Producido oBatches = new Producido();
			oBatches.FBC_BATCH = Convert.ToString(rBatches["FBC_BATCH"]);
			oBatches.FBC_BATCH_FATHER = Convert.ToString(rBatches["FBC_BATCH_FATHER"]);
			oBatches.FBC_PRODUCT_GROUP = Convert.ToString(rBatches["FBC_PRODUCT_GROUP"]);
			oBatches.FBC_PRODUCT_CODE = Convert.ToString(rBatches["FBC_PRODUCT_CODE"]);
			oBatches.FBC_PRODUCT_DESC = Convert.ToString(rBatches["FBC_PRODUCT_DESC"]);
			oBatches.FBC_FEATURE_GROUP = Convert.ToString(rBatches["FBC_FEATURE_GROUP"]);
			oBatches.FBC_WORKCENTER = Convert.ToString(rBatches["FBC_WORKCENTER"]);
			oBatches.FBC_PO = Convert.ToString(rBatches["FBC_PO"]);
			oBatches.FBC_WEIGHT = Convert.ToDecimal(rBatches["FBC_WEIGHT"]);
			oBatches.FBC_PIECE = Convert.ToInt32(rBatches["FBC_PIECE"]);
			oBatches.FBC_METERS = Convert.ToDecimal(rBatches["FBC_METERS"]);
			oBatches.FBC_START = Convert.ToDateTime(rBatches["FBC_START"]);
			oBatches.FBC_END = Convert.ToDateTime(rBatches["FBC_END"]);
			oBatches.FBC_INS_DATE = Convert.ToDateTime(rBatches["FBC_INS_DATE"]);
			oBatches.FBC_ISSUE = Convert.ToString(rBatches["FBC_ISSUE"]);
			oBatches.FBC_BATCH_LABEL_1 = Convert.ToString(rBatches["FBC_BATCH_LABEL_1"]);
			oBatches.FBC_BATCH_LABEL_2 = Convert.ToString(rBatches["FBC_BATCH_LABEL_2"]);
			oBatches.FBC_MACHINE = Convert.ToString(rBatches["FBC_MACHINE"]);
			oBatches.FBC_QUANTITY = Convert.ToDecimal(rBatches["FBC_QUANTITY"]);
			oBatches.FBC_QTY_UM = Convert.ToString(rBatches["FBC_QTY_UM"]);
			return oBatches;
		}

	}
}
