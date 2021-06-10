
CREATE TABLE [dbo].[BoloesMembrosGrupo](
	[CreatedBy] [varchar](25) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](25) NULL,
	[ModifiedDate] [datetime] NULL,
	[ActiveFlag] [bit] NULL,
	[UserName] [varchar](25) NOT NULL,
	[UserNameSelecionado] [varchar](25) NOT NULL,
	[NomeBolao] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserName] ASC,
	[NomeBolao] ASC,
	[UserNameSelecionado] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

--SET ANSI_PADDING OFF
--GO

--ALTER TABLE [dbo].[BoloesMembrosGrupo]  ADD FOREIGN KEY([CreatedBy])
--REFERENCES [dbo].[Users] ([UserName])
--GO

--ALTER TABLE [dbo].[BoloesMembrosGrupo]  ADD FOREIGN KEY([ModifiedBy])
--REFERENCES [dbo].[Users] ([UserName])
--GO


ALTER TABLE [dbo].[BoloesMembrosGrupo]  ADD CONSTRAINT FK_BoloesMembrosGrupo_BoloesMembros_Username_NomeBolao FOREIGN KEY([UserName], [NomeBolao])
REFERENCES [dbo].[BoloesMembros] ([UserName], [NomeBolao])
GO


ALTER TABLE [dbo].[BoloesMembrosGrupo]  ADD CONSTRAINT FK_BoloesMembrosGrupo_BoloesMembros_UserNameSelectionado_NomeBolao FOREIGN KEY([UserNameSelecionado], [NomeBolao])
REFERENCES [dbo].[BoloesMembros] ([UserName], [NomeBolao])
GO
