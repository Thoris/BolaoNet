

CREATE TABLE [dbo].[BoloesMembros](
	[NomeBolao] [varchar](100) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[FullName] [varchar](300) NULL,
	[CreatedBy] [varchar](25) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](25) NULL,
	[ModifiedDate] [datetime] NULL,
	[ActiveFlag] [smallint] NULL,
 CONSTRAINT [PK_dbo.BoloesMembros] PRIMARY KEY CLUSTERED 
(
	[NomeBolao] ASC,
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

----ALTER TABLE [dbo].[BoloesMembros]  ADD FOREIGN KEY([CreatedBy])
----REFERENCES [dbo].[Users] ([UserName])
----GO

----ALTER TABLE [dbo].[BoloesMembros]  ADD FOREIGN KEY([ModifiedBy])
----REFERENCES [dbo].[Users] ([UserName])
----GO

--ALTER TABLE [dbo].[BoloesMembros]  ADD  CONSTRAINT FK_BoloesMembros_Boloes_NomeBolao FOREIGN KEY([NomeBolao])
--REFERENCES [dbo].[Boloes] ([Nome])
--GO

--ALTER TABLE [dbo].[BoloesMembros]  ADD  CONSTRAINT FK_BoloesMembros_Users_UserName FOREIGN KEY([UserName])
--REFERENCES [dbo].[Users] ([UserName])
--GO



ALTER TABLE [dbo].[BoloesMembros]   ADD  CONSTRAINT [FK_dbo.BoloesMembros_dbo.Boloes_NomeBolao] FOREIGN KEY([NomeBolao])
REFERENCES [dbo].[Boloes] ([Nome])
GO
ALTER TABLE [dbo].[BoloesMembros] CHECK CONSTRAINT [FK_dbo.BoloesMembros_dbo.Boloes_NomeBolao]
GO
ALTER TABLE [dbo].[BoloesMembros]   ADD  CONSTRAINT [FK_dbo.BoloesMembros_dbo.Usuarios_UserName] FOREIGN KEY([UserName])
REFERENCES [dbo].[Usuarios] ([UserName])
GO
ALTER TABLE [dbo].[BoloesMembros] CHECK CONSTRAINT [FK_dbo.BoloesMembros_dbo.Usuarios_UserName]
GO