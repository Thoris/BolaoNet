CREATE TABLE ApiMatchEvents
(
    Id INT IDENTITY PRIMARY KEY,
     
    ExternalId NVARCHAR(50) NULL,

    MatchKeyId INT NULL,

    EventType NVARCHAR(50) NOT NULL,

    TeamName NVARCHAR(100) NULL,

    TeamExternalId NVARCHAR(50) NULL,

    PlayerName NVARCHAR(200) NULL,

    AssistPlayerName NVARCHAR(200) NULL,

    Minute INT NULL,

    ExtraMinute INT NULL,
    IsPenalty BIT NULL,
    IsOwnGoal BIT NULL,

    Period NVARCHAR(20) NULL,

    IsHomeTeam BIT NULL,

    RawDescription NVARCHAR(MAX) NULL,

    CreatedAt DATETIME NOT NULL DEFAULT(GETDATE())
); 
GO

--ALTER TABLE [dbo].[ApiMatchEvents]   ADD  CONSTRAINT [FK_dbo.ApiMatchEvents_dbo.ApiWorldCupMatches_ExternalId] FOREIGN KEY([ExternalId])
--REFERENCES [dbo].[ApiWorldCupMatches] ([ExternalId])
--GO 
 

--ALTER TABLE [dbo].[ApiMatchEvents] CHECK CONSTRAINT [FK_dbo.ApiMatchEvents_dbo.ApiWorldCupMatches_ExternalId]
--GO


 

--CREATE INDEX IX_MatchEvent_Match
--ON ApiMatchEvents(ExternalId);

--CREATE INDEX IX_MatchEvent_Type
--ON ApiMatchEvents(EventType);