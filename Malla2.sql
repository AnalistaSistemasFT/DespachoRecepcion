SELECT FCS_BATCH [Paquete],FBC_PRODUCT_CODE [Item],FBC_PRODUCT_DESC [Descripcion],FCS_MACHINE,
			(select LPF_VALUE 
			from [ElsystemNet_Ferrotodo].[dbo].[MES_TB_LST_PRODUCT_FEATURE] 
			where LPF_FEATURE='AX_CODE' and LPF_PRODUCT_CODE=FBC_PRODUCT_CODE) as AXCode,
			FCS_CONSUMED_QTY [Cantidad],FCS_QTY_UM [Unidad],FCS_STATUS_DATE [Fecha],FCS_BATCH_LABEL_1 [Origen] 
FROM [ElsystemNet_Ferrotodo].[dbo].[MES_TB_FLD_CONSUMED] 
inner join [ElsystemNet_Ferrotodo].[dbo].MES_TB_FLD_BATCHES on FCS_BATCH=FBC_BATCH 
where fcs_po='E17000001623' and FCS_MACHINE<>'TR'

SELECT FCS_BATCH [Paquete],FBC_PRODUCT_CODE [Item],FBC_PRODUCT_DESC [Descripcion],FCS_MACHINE,
			(select LPF_VALUE 
			from [ElsystemNet_Ferrotodo].[dbo].[MES_TB_LST_PRODUCT_FEATURE] 
			where LPF_FEATURE='AX_CODE' and LPF_PRODUCT_CODE=FBC_PRODUCT_CODE) as AXCode,
			FCS_CONSUMED_QTY [Cantidad],FCS_QTY_UM [Unidad],FCS_STATUS_DATE [Fecha],FCS_BATCH_LABEL_1 [Origen] 
FROM [ElsystemNet_Ferrotodo].[dbo].[MES_TB_FLD_CONSUMED] 
inner join [ElsystemNet_Ferrotodo].[dbo].MES_TB_FLD_BATCHES on FCS_BATCH=FBC_BATCH 
where fcs_po='E17000001623' and FCS_MACHINE='TR'