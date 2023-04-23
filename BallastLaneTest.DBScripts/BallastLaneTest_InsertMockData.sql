USE BallastLaneTest;
GO

--Insert Mock data for table Users
INSERT INTO Users (FirstName, LastName, Email, LoginName, Password, CreatedDate)
VALUES ('Gabriel', 'Recagno', 'recagnogabriel@gmail.com', 'grecagno', 'Password75', '2023-04-22 10:00:00');

--Insert Mock data for table Books
INSERT INTO Books (Title, Author, PublicationYear, ISBN, Publisher)
VALUES ('The Catcher in the Rye', 'J.D. Salinger', 1951, '0316769177', 'Little, Brown and Company');

INSERT INTO Books (Title, Author, PublicationYear, ISBN, Publisher)
VALUES ('To Kill a Mockingbird', 'Harper Lee', 1960, '0446310786', 'J. B. Lippincott & Co.');

INSERT INTO Books (Title, Author, PublicationYear, ISBN, Publisher)
VALUES ('1984', 'George Orwell', 1949, '0451524934', 'Secker & Warburg');