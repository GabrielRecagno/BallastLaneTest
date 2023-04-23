using BallastLaneTest.BusinessLogic.Interfaces;
using BallastLaneTest.Models;
using System.Data;
using BallastLaneTest.BusinessLogic.Helpers;
using BallastLaneTest.Data;
using BallastLaneTest.Data.Interfaces;

namespace BallastLaneTest.BusinessLogic.Logic
{
    internal class LogicBook : ILogicBook
    {
        //Singleton
        private static LogicBook instance = null;

        private IDataBook dataInstance;

        private LogicBook()
        {
            dataInstance = (new DataFactory()).getDataBook();
        }

        public static LogicBook getInstance()
        {
            if (instance == null)
                instance = new LogicBook();
            return instance;
        }

        //Operations

        public Result CreateBook(Book book)
        {
            #region Validate the Book object before creating it in the database

            if (string.IsNullOrEmpty(book.Title))
            {
                throw new ArgumentException("Book title cannot be null or empty.", nameof(book.Title));
            }

            if (string.IsNullOrEmpty(book.Author))
            {
                throw new ArgumentException("Book author cannot be null or empty.", nameof(book.Author));
            }

            // Check that the PublicationYear property is a valid year (i.e., between 1000 and the current year)
            if (book.PublicationYear < 1000 || book.PublicationYear > DateTime.Now.Year)
            {
                throw new ArgumentException("Book publication year must be between 1000 and the current year.", nameof(book.PublicationYear));
            }

            // Check that the ISBN property is a valid ISBN (10 or 13 digits)
            if (!LogicHelpers.IsValidIsbn(book.ISBN))
            {
                throw new ArgumentException("Book ISBN must be a valid 10- or 13-digit number with optional hyphens.", nameof(book.ISBN));
            }

            if (string.IsNullOrEmpty(book.Publisher))
            {
                throw new ArgumentException("Book publisher cannot be null or empty.", nameof(book.Publisher));
            }

            #endregion

            Result result;

            try
            {
                result = dataInstance.CreateBook(book);
            }
            catch (Exception ex)
            {
                result = new Result()
                {
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                };
            }

            return result;
        }

        public Result<IEnumerable<Book>> GetAllBooks()
        {
            Result<IEnumerable<Book>> result;

            try
            {
                result = dataInstance.GetAllBooks();
            }
            catch (Exception ex)
            {
                result = new Result<IEnumerable<Book>>
                {
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                };
            }
            return result;
        }

        public Result<Book> GetBookById(int id)
        {
            Result<Book> result;

            try
            {
                result = dataInstance.GetBookById(id);
            }
            catch (Exception ex)
            {
                result = new Result<Book>
                {
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                };
            }

            return result;
        }

        public Result UpdateBook(Book book)
        {
            #region Validate the Book object before creating it in the database

            if (string.IsNullOrEmpty(book.Title))
            {
                throw new ArgumentException("Book title cannot be null or empty.", nameof(book.Title));
            }

            if (string.IsNullOrEmpty(book.Author))
            {
                throw new ArgumentException("Book author cannot be null or empty.", nameof(book.Author));
            }

            // Check that the PublicationYear property is a valid year (i.e., between 1000 and the current year)
            if (book.PublicationYear < 1000 || book.PublicationYear > DateTime.Now.Year)
            {
                throw new ArgumentException("Book publication year must be between 1000 and the current year.", nameof(book.PublicationYear));
            }

            // Check that the ISBN property is a valid ISBN (10 or 13 digits)
            if (!LogicHelpers.IsValidIsbn(book.ISBN))
            {
                throw new ArgumentException("Book ISBN must be a valid 10- or 13-digit number with optional hyphens.", nameof(book.ISBN));
            }

            if (string.IsNullOrEmpty(book.Publisher))
            {
                throw new ArgumentException("Book publisher cannot be null or empty.", nameof(book.Publisher));
            }

            #endregion

            Result result;

            try
            {
                result = dataInstance.UpdateBook(book);
            }
            catch (Exception ex)
            {
                result = new Result()
                {
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                };
            }
            return result;
        }

        public Result DeleteBook(int id)
        {
            #region Validate params before creating it in the database

            if (id == 0)
            {
                throw new ArgumentException("Book Id cannot be null or empty.");
            }

            #endregion

            Result result;

            try
            {
                result = dataInstance.DeleteBook(id);
            }
            catch (Exception ex)
            {
                result = new Result()
                {
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                };
            }
            return result;
        }
    }
}

