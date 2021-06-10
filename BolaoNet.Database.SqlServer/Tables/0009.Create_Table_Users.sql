
CREATE TABLE [dbo].[Usuarios](
	[UserName] [varchar](50) NOT NULL,
	[Password] [varchar](50) NULL,
	[PasswordFormat] [int] NOT NULL,
	[PasswordQuestion] [varchar](100) NULL,
	[PasswordAnswer] [varchar](50) NULL,
	[FullName] [varchar](250) NULL,
	[Email] [varchar](150) NULL,
	[BirthDate] [datetime] NULL,
	[Male] [bit] NULL,
	[CellPhone] [varchar](30) NULL,
	[PhoneNumber] [varchar](30) NULL,
	[CompanyPhone] [varchar](30) NULL,
	[City] [varchar](150) NULL,
	[Country] [varchar](50) NULL,
	[State] [varchar](20) NULL,
	[Street] [varchar](150) NULL,
	[StreetNumber] [int] NULL,
	[PostalCode] [varchar](20) NULL,
	[Marital] [int] NULL,
	[CPF] [varchar](20) NULL,
	[RG] [varchar](20) NULL,
	[MSN] [varchar](100) NULL,
	[Skype] [varchar](20) NULL,
	[IsLockedOut] [bit] NOT NULL,
	[IsApproved] [bit] NOT NULL,
	[LastActivityDate] [datetime] NULL,
	[LastLockoutDate] [datetime] NULL,
	[LastPasswordChangedDate] [datetime] NULL,
	[LastLoginDate] [datetime] NULL,
	[FailedPasswordAttemptCount] [int] NULL,
	[FailedPasswordAttemptWindowStart] [datetime] NULL,
	[FailedPasswordAnswerAttemptCount] [int] NULL,
	[FailedPasswordAnswerAttemptWindowStart] [datetime] NULL,
	[Comments] [varchar](255) NULL,
	[ActivateKey] [varchar](250) NULL,
	[ReceiveEmails] [bit] NOT NULL,
	[RequestedBy] [varchar](50) NULL,
	[RequestedDate] [datetime] NULL,
	[ApprovedBy] [varchar](50) NULL,
	[ApprovedDate] [datetime] NULL,
	[IsOnline] [bit] NOT NULL,
	[IsAdmin] [bit] NOT NULL,
	[CreatedBy] [varchar](25) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](25) NULL,
	[ModifiedDate] [datetime] NULL,
	[ActiveFlag] [smallint] NULL,
 CONSTRAINT [PK_dbo.Usuarios] PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


--ALTER TABLE [dbo].[Usuarios]  ADD CONSTRAINT FK_User_MaritalStatus_Id FOREIGN KEY([IdMaritalStatus])
--REFERENCES [dbo].[UserMaritalStatus] ([IdMaritalStatus])
--GO
