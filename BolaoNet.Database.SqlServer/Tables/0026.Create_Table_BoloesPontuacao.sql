
CREATE TABLE [dbo].[BoloesPontuacao](
	[NomeBolao] [varchar](100) NOT NULL,
	[Pontos] [int] NOT NULL,
	[Titulo] [varchar](150) NULL,
	[ForeColorName] [varchar](50) NULL,
	[BackColorName] [varchar](50) NULL,
	[CreatedBy] [varchar](25) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](25) NULL,
	[ModifiedDate] [datetime] NULL,
	[ActiveFlag] [smallint] NULL,
 CONSTRAINT [PK_dbo.BoloesPontuacao] PRIMARY KEY CLUSTERED 
(
	[NomeBolao] ASC,
	[Pontos] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

----SET ANSI_PADDING OFF
----GO

----ALTER TABLE [dbo].[BoloesPontuacao]  ADD FOREIGN KEY([CreatedBy])
----REFERENCES [dbo].[Users] ([UserName])
----GO

----ALTER TABLE [dbo].[BoloesPontuacao]  ADD FOREIGN KEY([ModifiedBy])
----REFERENCES [dbo].[Users] ([UserName])
----GO

--ALTER TABLE [dbo].[BoloesPontuacao]  ADD  CONSTRAINT FK_BoloesPontuacao_Boloes_NomeBolao FOREIGN KEY([NomeBolao])
--REFERENCES [dbo].[Boloes] ([Nome])
--GO


ALTER TABLE [dbo].[BoloesPontuacao]   ADD  CONSTRAINT [FK_dbo.BoloesPontuacao_dbo.Boloes_NomeBolao] FOREIGN KEY([NomeBolao])
REFERENCES [dbo].[Boloes] ([Nome])
GO
ALTER TABLE [dbo].[BoloesPontuacao] CHECK CONSTRAINT [FK_dbo.BoloesPontuacao_dbo.Boloes_NomeBolao]
GO
