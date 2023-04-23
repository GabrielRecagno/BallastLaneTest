USE master;
GO

--Kill previous connections to DataBase
DECLARE @DatabaseName nvarchar(50)
SET @DatabaseName = N'BallastLaneTest'

DECLARE @SQL varchar(max)

SELECT @SQL = COALESCE(@SQL,'') + 'Kill ' + Convert(varchar, SPId) + ';'
FROM MASTER..SysProcesses
WHERE DBId = DB_ID(@DatabaseName) AND SPId <> @@SPId

EXEC(@SQL)

--DataBase Creation
IF EXISTS(SELECT * FROM sys.databases WHERE name = 'BallastLaneTest')
BEGIN
    DROP DATABASE BallastLaneTest
END
GO

CREATE DATABASE BallastLaneTest;
GO

USE BallastLaneTest;
GO

--Tables Creation
CREATE TABLE Users (
  Id INT IDENTITY(1,1) PRIMARY KEY,
  FirstName VARCHAR(255) NOT NULL,
  LastName VARCHAR(255) NOT NULL,
  Email VARCHAR(255) NOT NULL,
  LoginName VARCHAR(255) NOT NULL,
  Password VARCHAR(255) NOT NULL,
  CreatedDate DATETIME NOT NULL,
  Deleted bit NOT NULL DEFAULT 0
);

CREATE TABLE Books (
  Id INT IDENTITY(1,1) PRIMARY KEY,
  Title VARCHAR(255) NOT NULL,
  Author VARCHAR(255) NOT NULL,
  PublicationYear INT NOT NULL,
  ISBN VARCHAR(13) NOT NULL,
  Publisher VARCHAR(255) NOT NULL,
  Deleted bit NOT NULL DEFAULT 0
);