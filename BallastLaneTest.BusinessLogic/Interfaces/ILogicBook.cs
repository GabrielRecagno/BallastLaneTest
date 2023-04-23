using BallastLaneTest.Models;
using System.Data;

namespace BallastLaneTest.BusinessLogic.Interfaces
{
    public interface ILogicBook
    {
        Result CreateBook(Book book);
        Result<IEnumerable<Book>> GetAllBooks();
        Result<Book> GetBookById(int id);
        Result UpdateBook(Book book);
        Result DeleteBook(int id);
    }
}
