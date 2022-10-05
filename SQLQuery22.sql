USE [LYBK]
GO

/****** Object:  Table [dbo].[PRODUCIDO]    Script Date: 27/10/2017 05:48:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PRODUCIDO](
	[PAQUETEID] [nvarchar](20) NOT NULL,
	[ITEM] [nvarchar](20) NULL,
	[ITEM_DESC] [nvarchar](100) NULL,
	[CENTRO_TRABAJO] [nvarchar](10) NULL,
	[NRO_ORDEN] [nvarchar](20) NULL,
	[POSICION] [smallint] NULL,
	[PESO] [decimal](9, 3) NULL,
	[PIEZAS] [smallint] NULL,
	[METROS] [decimal](9, 3) NULL,
	[FECHA] [datetime] NOT NULL,
	[CALIDAD] [nvarchar](4) NOT NULL,
	[FBC_BATCH_LABEL_1] [nvarchar](20) NOT NULL,
	[FBC_BATCH_LABEL_2] [nvarchar](100) NULL,
	[STATUS] [nvarchar](20) NULL,
 CONSTRAINT [PK_PRODUCIDO] PRIMARY KEY CLUSTERED 
(
	[PAQUETEID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


