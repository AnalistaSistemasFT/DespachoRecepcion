/****** Script para el comando SelectTopNRows de SSMS  ******/
insert into [ElsystemNet_Ferrotodo].[dbo].[MES_TB_FLD_BATCH_FEATURE](fbf_batch,FBF_FEATURE,FBF_VALUE)
SELECT [FBC_BATCH],'HEAT','HEAT'
  FROM [ElsystemNet_Ferrotodo].[dbo].[MES_TB_FLD_BATCHES]
  where FBC_BATCH in(
'17SCR08828'
,'17SCR08830'
,'17SCR08832'
,'17SCR08834'
)