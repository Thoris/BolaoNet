
CREATE TABLE [dbo].[ApostasExtras](
	[NomeBolao] [varchar](100) NOT NULL,
	[Posicao] [int] NOT NULL,
	[Titulo] [varchar](150) NULL,
	[Descricao] [varchar](255) NULL,
	[TotalPontos] [int] NULL,
	[IsValido] [bit] NULL,
	[DataValidacao] [datetime] NULL,
	[ValidadoBy] [varchar](50) NULL,
	[NomeTimeValidado] [varchar](150) NULL,
	[CreatedBy] [varchar](25) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](25) NULL,
	[ModifiedDate] [datetime] NULL,
	[ActiveFlag] [smallint] NULL,
 CONSTRAINT [PK_dbo.ApostasExtras] PRIMARY KEY CLUSTERED 
(
	[NomeBolao] ASC,
	[Posicao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

--SET ANSI_PADDING OFF
--GO

--ALTER TABLE [dbo].[ApostasExtras]  ADD FOREIGN KEY([CreatedBy])
--REFERENCES [dbo].[Users] ([UserName])
--GO

--ALTER TABLE [dbo].[ApostasExtras]  ADD FOREIGN KEY([ModifiedBy])
--REFERENCES [dbo].[Users] ([UserName])
--GO

--ALTER TABLE [dbo].[ApostasExtras]  ADD  CONSTRAINT FK_ApostasExtras_Boloes_NomeBolao FOREIGN KEY([NomeBolao])
--REFERENCES [dbo].[Boloes] ([Nome])
--GO

--ALTER TABLE [dbo].[ApostasExtras]  ADD  CONSTRAINT FK_ApostasExtras_Times_Nome FOREIGN KEY([NomeTimeValidado])
--REFERENCES [dbo].[Times] ([Nome])
--GO

--ALTER TABLE [dbo].[ApostasExtras]  ADD  CONSTRAINT FK_ApostasExtras_Users_UserName FOREIGN KEY([ValidadoBy])
--REFERENCES [dbo].[Users] ([UserName])
--GO

ALTER TABLE [dbo].[ApostasExtras]  ADD  CONSTRAINT [FK_dbo.ApostasExtras_dbo.Boloes_NomeBolao] FOREIGN KEY([NomeBolao])
REFERENCES [dbo].[Boloes] ([Nome])
GO
ALTER TABLE [dbo].[ApostasExtras] CHECK CONSTRAINT [FK_dbo.ApostasExtras_dbo.Boloes_NomeBolao]
GO
ALTER TABLE [dbo].[ApostasExtras]  ADD  CONSTRAINT [FK_dbo.ApostasExtras_dbo.Times_NomeTimeValidado] FOREIGN KEY([NomeTimeValidado])
REFERENCES [dbo].[Times] ([Nome])
GO
ALTER TABLE [dbo].[ApostasExtras] CHECK CONSTRAINT [FK_dbo.ApostasExtras_dbo.Times_NomeTimeValidado]
GO