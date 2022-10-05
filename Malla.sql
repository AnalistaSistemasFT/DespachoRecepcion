select distinct c.fcs_po,(SELECT SUM(FCS_CONSUMED_QTY)
FROM [ElsystemNet_Ferrotodo].[dbo].[MES_TB_FLD_CONSUMED] 
where fcs_po=c.fcs_po and FCS_MACHINE<>'TR') [Lineas],
(SELECT SUM(FCS_CONSUMED_QTY)
FROM [ElsystemNet_Ferrotodo].[dbo].[MES_TB_FLD_CONSUMED] 
where fcs_po=c.fcs_po and FCS_MACHINE='TR')[Transversal]
FROM [ElsystemNet_Ferrotodo].[dbo].[MES_TB_FLD_CONSUMED] C 
where c.fcs_po='E15000000908' 