
CREATE TABLE [dbo].[Campeonatos](
	[Nome] [varchar](150) NOT NULL,
	[IsClube] [bit] NOT NULL,
	[Descricao] [varchar](255) NULL,
	[FaseAtual] [varchar](50) NULL,
	[RodadaAtual] [int] NOT NULL,
	[IsIniciado] [bit] NOT NULL,
	[DataIniciado] [datetime] NULL,
	[TipoCampeonato] [int] NULL,
	[CreatedBy] [varchar](25) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](25) NULL,
	[ModifiedDate] [datetime] NULL,
	[ActiveFlag] [smallint] NULL,
 CONSTRAINT [PK_dbo.Campeonatos] PRIMARY KEY CLUSTERED 
(
	[Nome] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

--SET ANSI_PADDING OFF
--GO

--ALTER TABLE [dbo].[Campeonatos]  ADD FOREIGN KEY([CreatedBy])
--REFERENCES [dbo].[Users] ([UserName])
--GO

--ALTER TABLE [dbo].[Campeonatos]  ADD FOREIGN KEY([ModifiedBy])
--REFERENCES [dbo].[Users] ([UserName])
--GO
