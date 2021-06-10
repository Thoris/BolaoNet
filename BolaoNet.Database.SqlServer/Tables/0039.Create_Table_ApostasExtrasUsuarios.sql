
CREATE TABLE [dbo].[ApostasExtrasUsuarios](
	[NomeBolao] [varchar](100) NOT NULL,
	[Posicao] [int] NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[DataAposta] [datetime] NOT NULL,
	[Pontos] [int] NULL,
	[NomeTime] [varchar](150) NULL,
	[IsApostaValida] [bit] NULL,
	[Automatico] [bit] NULL,
	[CreatedBy] [varchar](25) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](25) NULL,
	[ModifiedDate] [datetime] NULL,
	[ActiveFlag] [smallint] NULL,
 CONSTRAINT [PK_dbo.ApostasExtrasUsuarios] PRIMARY KEY CLUSTERED 
(
	[NomeBolao] ASC,
	[Posicao] ASC,
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

--SET ANSI_PADDING OFF
--GO

--ALTER TABLE [dbo].[ApostasExtrasUsuarios] ADD FOREIGN KEY([CreatedBy])
--REFERENCES [dbo].[Users] ([UserName])
--GO

--ALTER TABLE [dbo].[ApostasExtrasUsuarios] ADD FOREIGN KEY([ModifiedBy])
--REFERENCES [dbo].[Users] ([UserName])
--GO

--ALTER TABLE [dbo].[ApostasExtrasUsuarios] ADD  CONSTRAINT FK_ApostasExtrasUsuarios_Times_NomeTime FOREIGN KEY([NomeTime])
--REFERENCES [dbo].[Times] ([Nome])
--GO

--ALTER TABLE [dbo].[ApostasExtrasUsuarios] ADD  CONSTRAINT FK_ApostasExtrasUsuarios_Users_UserName FOREIGN KEY([UserName])
--REFERENCES [dbo].[Users] ([UserName])
--GO

--ALTER TABLE [dbo].[ApostasExtrasUsuarios] ADD  CONSTRAINT FK_ApostasExtrasUsuarios_ApostasExtras_Posicao_NomeBolao FOREIGN KEY([Posicao], [NomeBolao])
--REFERENCES [dbo].[ApostasExtras] ([Posicao], [NomeBolao])
--GO



ALTER TABLE [dbo].[ApostasExtrasUsuarios]   ADD  CONSTRAINT [FK_dbo.ApostasExtrasUsuarios_dbo.ApostasExtras_NomeBolao_Posicao] FOREIGN KEY([NomeBolao], [Posicao])
REFERENCES [dbo].[ApostasExtras] ([NomeBolao], [Posicao])
GO
ALTER TABLE [dbo].[ApostasExtrasUsuarios] CHECK CONSTRAINT [FK_dbo.ApostasExtrasUsuarios_dbo.ApostasExtras_NomeBolao_Posicao]
GO
ALTER TABLE [dbo].[ApostasExtrasUsuarios]   ADD  CONSTRAINT [FK_dbo.ApostasExtrasUsuarios_dbo.Times_NomeTime] FOREIGN KEY([NomeTime])
REFERENCES [dbo].[Times] ([Nome])
GO
ALTER TABLE [dbo].[ApostasExtrasUsuarios] CHECK CONSTRAINT [FK_dbo.ApostasExtrasUsuarios_dbo.Times_NomeTime]
GO
ALTER TABLE [dbo].[ApostasExtrasUsuarios]   ADD  CONSTRAINT [FK_dbo.ApostasExtrasUsuarios_dbo.Usuarios_UserName] FOREIGN KEY([UserName])
REFERENCES [dbo].[Usuarios] ([UserName])
GO
ALTER TABLE [dbo].[ApostasExtrasUsuarios] CHECK CONSTRAINT [FK_dbo.ApostasExtrasUsuarios_dbo.Usuarios_UserName]
GO