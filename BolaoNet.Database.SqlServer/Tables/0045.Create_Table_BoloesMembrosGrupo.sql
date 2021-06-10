
CREATE TABLE [dbo].[BoloesMembrosGrupos](
	[NomeBolao] [varchar](100) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[UserNameSelecionado] [varchar](50) NOT NULL,
	[CreatedBy] [varchar](25) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](25) NULL,
	[ModifiedDate] [datetime] NULL,
	[ActiveFlag] [smallint] NULL,
 CONSTRAINT [PK_dbo.BoloesMembrosGrupos] PRIMARY KEY CLUSTERED 
(
	[NomeBolao] ASC,
	[UserName] ASC,
	[UserNameSelecionado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

----SET ANSI_PADDING OFF
----GO

----ALTER TABLE [dbo].[BoloesMembrosGrupo]  ADD FOREIGN KEY([CreatedBy])
----REFERENCES [dbo].[Users] ([UserName])
----GO

----ALTER TABLE [dbo].[BoloesMembrosGrupo]  ADD FOREIGN KEY([ModifiedBy])
----REFERENCES [dbo].[Users] ([UserName])
----GO


--ALTER TABLE [dbo].[BoloesMembrosGrupo]  ADD CONSTRAINT FK_BoloesMembrosGrupo_BoloesMembros_Username_NomeBolao FOREIGN KEY([UserName], [NomeBolao])
--REFERENCES [dbo].[BoloesMembros] ([UserName], [NomeBolao])
--GO


--ALTER TABLE [dbo].[BoloesMembrosGrupo]  ADD CONSTRAINT FK_BoloesMembrosGrupo_BoloesMembros_UserNameSelectionado_NomeBolao FOREIGN KEY([UserNameSelecionado], [NomeBolao])
--REFERENCES [dbo].[BoloesMembros] ([UserName], [NomeBolao])
--GO



ALTER TABLE [dbo].[BoloesMembrosGrupos]   ADD  CONSTRAINT [FK_dbo.BoloesMembrosGrupos_dbo.BoloesMembros_NomeBolao_UserName] FOREIGN KEY([NomeBolao], [UserName])
REFERENCES [dbo].[BoloesMembros] ([NomeBolao], [UserName])
GO
ALTER TABLE [dbo].[BoloesMembrosGrupos] CHECK CONSTRAINT [FK_dbo.BoloesMembrosGrupos_dbo.BoloesMembros_NomeBolao_UserName]
GO
ALTER TABLE [dbo].[BoloesMembrosGrupos]   ADD  CONSTRAINT [FK_dbo.BoloesMembrosGrupos_dbo.Usuarios_UserNameSelecionado] FOREIGN KEY([UserNameSelecionado])
REFERENCES [dbo].[Usuarios] ([UserName])
GO
ALTER TABLE [dbo].[BoloesMembrosGrupos] CHECK CONSTRAINT [FK_dbo.BoloesMembrosGrupos_dbo.Usuarios_UserNameSelecionado]
GO
ALTER TABLE [dbo].[BoloesMembrosPontos]   ADD  CONSTRAINT [FK_dbo.BoloesMembrosPontos_dbo.BoloesMembros_NomeBolao_UserName] FOREIGN KEY([NomeBolao], [UserName])
REFERENCES [dbo].[BoloesMembros] ([NomeBolao], [UserName])
GO
ALTER TABLE [dbo].[BoloesMembrosPontos] CHECK CONSTRAINT [FK_dbo.BoloesMembrosPontos_dbo.BoloesMembros_NomeBolao_UserName]
GO
ALTER TABLE [dbo].[BoloesMembrosPontos]   ADD  CONSTRAINT [FK_dbo.BoloesMembrosPontos_dbo.CampeonatosFases_NomeCampeonato_NomeFase] FOREIGN KEY([NomeCampeonato], [NomeFase])
REFERENCES [dbo].[CampeonatosFases] ([NomeCampeonato], [Nome])
GO
ALTER TABLE [dbo].[BoloesMembrosPontos] CHECK CONSTRAINT [FK_dbo.BoloesMembrosPontos_dbo.CampeonatosFases_NomeCampeonato_NomeFase]
GO
ALTER TABLE [dbo].[BoloesMembrosPontos]   ADD  CONSTRAINT [FK_dbo.BoloesMembrosPontos_dbo.CampeonatosGrupos_NomeCampeonato_NomeGrupo] FOREIGN KEY([NomeCampeonato], [NomeGrupo])
REFERENCES [dbo].[CampeonatosGrupos] ([NomeCampeonato], [Nome])
GO
ALTER TABLE [dbo].[BoloesMembrosPontos] CHECK CONSTRAINT [FK_dbo.BoloesMembrosPontos_dbo.CampeonatosGrupos_NomeCampeonato_NomeGrupo]
GO