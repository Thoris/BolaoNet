
CREATE TABLE [dbo].[BoloesPremiacao](
	[NomeBolao] [varchar](30) NOT NULL,
	[Posicao] [int] NOT NULL,	
	[Percentual] [float] NULL,	
	[Valor] [float] NULL,		
	[CreatedBy] [varchar](25) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](25) NULL,
	[ModifiedDate] [datetime] NULL,
	[ActiveFlag] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Posicao] ASC,
	[NomeBolao] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
 
GO
 
