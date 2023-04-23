USE BallastLaneTest;
GO

--First Delete all previous versions that may exist
IF OBJECT_ID('CreateUser', 'P') IS NOT NULL
    DROP PROCEDURE CreateUser;
GO

IF OBJECT_ID('AuthenticateUser', 'P') IS NOT NULL
    DROP PROCEDURE AuthenticateUser;
GO

IF OBJECT_ID('CreateBook', 'P') IS NOT NULL
    DROP PROCEDURE CreateBook;
GO

IF OBJECT_ID('GetAllBooks', 'P') IS NOT NULL
    DROP PROCEDURE GetAllBooks;
GO

IF OBJECT_ID('GetBookById', 'P') IS NOT NULL
    DROP PROCEDURE GetBookById;
GO

IF OBJECT_ID('UpdateBook', 'P') IS NOT NULL
    DROP PROCEDURE UpdateBook;
GO

IF OBJECT_ID('DeleteBook', 'P') IS NOT NULL
    DROP PROCEDURE DeleteBook;
GO

--Creation of SPs for User creation and login
CREATE PROCEDURE CreateUser
    @FirstName VARCHAR(255),
    @LastName VARCHAR(255),
    @Email VARCHAR(255),
    @LoginName VARCHAR(255),
    @Password VARCHAR(255)
AS
BEGIN
    INSERT INTO Users (FirstName, LastName, Email, LoginName, Password, CreatedDate)
    VALUES (@FirstName, @LastName, @Email, @LoginName, @Password, GETDATE())
END
GO

CREATE PROCEDURE AuthenticateUser
    @LoginName VARCHAR(255),
    @Password VARCHAR(255)
AS
BEGIN
    SELECT FirstName, LastName, Email, LoginName FROM Users 
	WHERE LoginName = @LoginName AND Password = @Password AND Deleted = 0
END
GO

--Creation of SPs for CRUD operations on Book table
CREATE PROCEDURE CreateBook
    @Title VARCHAR(255),
    @Author VARCHAR(255),
    @PublicationYear INT,
    @ISBN VARCHAR(13),
    @Publisher VARCHAR(255)
AS
BEGIN
    INSERT INTO Books (Title, Author, PublicationYear, ISBN, Publisher, Deleted)
    VALUES (@Title, @Author, @PublicationYear, @ISBN, @Publisher, 0)
END
GO

CREATE PROCEDURE GetAllBooks
AS
BEGIN
    SELECT Id, Title, Author, PublicationYear, ISBN, Publisher FROM Books
	WHERE Deleted = 0;
END
GO

CREATE PROCEDURE GetBookById
    @Id INT
AS
BEGIN
    SELECT Id, Title, Author, PublicationYear, ISBN, Publisher FROM Books 
	WHERE Id = @Id AND Deleted = 0;
END
GO

CREATE PROCEDURE UpdateBook
    @Id INT,
    @Title VARCHAR(255),
    @Author VARCHAR(255),
    @PublicationYear INT,
    @ISBN VARCHAR(13),
    @Publisher VARCHAR(255)
AS
BEGIN
    UPDATE Books
    SET Title = @Title,
        Author = @Author,
        PublicationYear = @PublicationYear,
        ISBN = @ISBN,
        Publisher = @Publisher
    WHERE Id = @Id AND Deleted = 0;
END
GO

CREATE PROCEDURE DeleteBook
    @Id INT
AS
BEGIN
    UPDATE Books SET Deleted = 1 WHERE Id = @Id
END
GO