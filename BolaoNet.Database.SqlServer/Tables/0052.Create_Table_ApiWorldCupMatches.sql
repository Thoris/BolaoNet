CREATE TABLE ApiWorldCupMatches (
    Id INT IDENTITY PRIMARY KEY,
    ExternalId NVARCHAR(50) NULL,
    LeagueId INT NULL,
    Season NVARCHAR(10) NULL,
    MatchDate DATETIME NULL,
    HomeTeam NVARCHAR(100) NULL,
    AwayTeam NVARCHAR(100) NULL,
    HomeScore INT NULL,
    AwayScore INT NULL,
    Status NVARCHAR(30) NULL,
    Venue NVARCHAR(200) NULL, 

    HomeTeamId NVARCHAR(50) NULL,
    AwayTeamId NVARCHAR(50) NULL,

    HomeShots INT NULL,
    AwayShots INT NULL,

    HomePossession DECIMAL(5,2) NULL,
    AwayPossession DECIMAL(5,2) NULL,

    [Round] NVARCHAR(50) NULL,
    [Group] NVARCHAR(25) NULL,
    Ground NVARCHAR(100) NULL,

    LastSync DATETIME NULL
);