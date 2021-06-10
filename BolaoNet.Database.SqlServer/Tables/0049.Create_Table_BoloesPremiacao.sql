  
CREATE TABLE [dbo].[BoloesPremiacao](
	[NomeBolao] [varchar](100) NOT NULL,
	[Posicao] [int] NOT NULL,
	[Percentual] [float] NOT NULL,
	[Valor] [float] NOT NULL,
	[CreatedBy] [varchar](25) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](25) NULL,
	[ModifiedDate] [datetime] NULL,
	[ActiveFlag] [smallint] NULL,
 CONSTRAINT [PK_dbo.BoloesPremiacao] PRIMARY KEY CLUSTERED 
(
	[NomeBolao] ASC,
	[Posicao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
 
GO

ALTER TABLE [dbo].[BoloesPremiacao]   ADD  CONSTRAINT [FK_dbo.BoloesPremiacao_dbo.Boloes_NomeBolao] FOREIGN KEY([NomeBolao])
REFERENCES [dbo].[Boloes] ([Nome])
GO
ALTER TABLE [dbo].[BoloesPremiacao] CHECK CONSTRAINT [FK_dbo.BoloesPremiacao_dbo.Boloes_NomeBolao]
GO
 
