/****** Script para el comando SelectTopNRows de SSMS  ******/
SELECT TOP 1000 [OrdenId]
      ,[Fecha]
      ,[CentroTrabajo]
      ,[FechaCierre]
      ,[Status]
      ,[TipoOrden]
      ,[SucursalId]
      ,[SucursalDestino]
      ,[OrdenLigada]
      ,[ItemFLigado]
      ,[EsDeCliente]
  FROM [LYBK].[dbo].[tblMovSync]
  where OrdenId='E17000002105'

delete  FROM [LYBK].[dbo].[tblMovSync]
  where OrdenId='E17000002225'