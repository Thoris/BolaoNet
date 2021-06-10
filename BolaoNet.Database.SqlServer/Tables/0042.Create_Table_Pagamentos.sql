
CREATE TABLE [dbo].[Pagamentos](
	[NomeBolao] [varchar](100) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[DataPagamento] [datetime] NOT NULL,
	[PagamentoTipoID] [int] NOT NULL,
	[Valor] [decimal](18, 2) NULL,
	[Descricao] [varchar](255) NULL,
	[CreatedBy] [varchar](25) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](25) NULL,
	[ModifiedDate] [datetime] NULL,
	[ActiveFlag] [smallint] NULL,
 CONSTRAINT [PK_dbo.Pagamentos] PRIMARY KEY CLUSTERED 
(
	[NomeBolao] ASC,
	[UserName] ASC,
	[DataPagamento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

----SET ANSI_PADDING OFF
----GO

----ALTER TABLE [dbo].[Pagamentos]  ADD FOREIGN KEY([CreatedBy])
----REFERENCES [dbo].[Users] ([UserName])
----GO

----ALTER TABLE [dbo].[Pagamentos]  ADD FOREIGN KEY([ModifiedBy])
----REFERENCES [dbo].[Users] ([UserName])
----GO

--ALTER TABLE [dbo].[Pagamentos]  ADD CONSTRAINT FK_Pagamentos_Boloes_NomeBolao  FOREIGN KEY([NomeBolao])
--REFERENCES [dbo].[Boloes] ([Nome])
--GO

--ALTER TABLE [dbo].[Pagamentos]  ADD  CONSTRAINT FK_Pagamentos_PagamentoTipo_TipoPagamento FOREIGN KEY([TipoPagamento])
--REFERENCES [dbo].[PagamentoTipo] ([TipoPagamento])
--GO

--ALTER TABLE [dbo].[Pagamentos]  ADD CONSTRAINT FK_Pagamentos_Users_UserName FOREIGN KEY([UserName])
--REFERENCES [dbo].[Users] ([UserName])
--GO

ALTER TABLE [dbo].[Pagamentos]   ADD  CONSTRAINT [FK_dbo.Pagamentos_dbo.Boloes_NomeBolao] FOREIGN KEY([NomeBolao])
REFERENCES [dbo].[Boloes] ([Nome])
GO
ALTER TABLE [dbo].[Pagamentos] CHECK CONSTRAINT [FK_dbo.Pagamentos_dbo.Boloes_NomeBolao]
GO
ALTER TABLE [dbo].[Pagamentos]   ADD  CONSTRAINT [FK_dbo.Pagamentos_dbo.PagamentosTipo_PagamentoTipoID] FOREIGN KEY([PagamentoTipoID])
REFERENCES [dbo].[PagamentosTipo] ([TipoPagamento])
GO
ALTER TABLE [dbo].[Pagamentos] CHECK CONSTRAINT [FK_dbo.Pagamentos_dbo.PagamentosTipo_PagamentoTipoID]
GO
ALTER TABLE [dbo].[Pagamentos]   ADD  CONSTRAINT [FK_dbo.Pagamentos_dbo.Usuarios_UserName] FOREIGN KEY([UserName])
REFERENCES [dbo].[Usuarios] ([UserName])
GO
ALTER TABLE [dbo].[Pagamentos] CHECK CONSTRAINT [FK_dbo.Pagamentos_dbo.Usuarios_UserName]
GO