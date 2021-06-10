CREATE TABLE [dbo].[Historico](
	[Nome] [varchar](150) NOT NULL,
	[Ano] [int] NOT NULL,
	[FinalTime1] [int] NOT NULL,
	[FinalTime2] [int] NOT NULL,
	[FinalPenaltis1] [int] NOT NULL,
	[FinalPenaltis2] [int] NOT NULL,
	[Sede] [varchar](250) NULL,
	[CreatedBy] [varchar](25) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](25) NULL,
	[ModifiedDate] [datetime] NULL,
	[ActiveFlag] [smallint] NULL,
	[NomeTimeCampeao_Nome] [varchar](150) NULL,
	[NomeTimeTerceiro_Nome] [varchar](150) NULL,
	[NomeTimeVice_Nome] [varchar](150) NULL,
 CONSTRAINT [PK_dbo.Historico] PRIMARY KEY CLUSTERED 
(
	[Nome] ASC,
	[Ano] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[Historico]   ADD  CONSTRAINT [FK_dbo.Historico_dbo.Times_NomeTimeCampeao_Nome] FOREIGN KEY([NomeTimeCampeao_Nome])
REFERENCES [dbo].[Times] ([Nome])
GO
ALTER TABLE [dbo].[Historico] CHECK CONSTRAINT [FK_dbo.Historico_dbo.Times_NomeTimeCampeao_Nome]
GO
ALTER TABLE [dbo].[Historico]   ADD  CONSTRAINT [FK_dbo.Historico_dbo.Times_NomeTimeTerceiro_Nome] FOREIGN KEY([NomeTimeTerceiro_Nome])
REFERENCES [dbo].[Times] ([Nome])
GO
ALTER TABLE [dbo].[Historico] CHECK CONSTRAINT [FK_dbo.Historico_dbo.Times_NomeTimeTerceiro_Nome]
GO
ALTER TABLE [dbo].[Historico]   ADD  CONSTRAINT [FK_dbo.Historico_dbo.Times_NomeTimeVice_Nome] FOREIGN KEY([NomeTimeVice_Nome])
REFERENCES [dbo].[Times] ([Nome])
GO
ALTER TABLE [dbo].[Historico] CHECK CONSTRAINT [FK_dbo.Historico_dbo.Times_NomeTimeVice_Nome]
GO