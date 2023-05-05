using OnlineBookstore.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineBookstore.API.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooks();
        Task<Book> GetBookById(int id);
        Task<Book> CreateBook(Book book);
        Task<bool> UpdateBook(Book book);
        Task<bool> DeleteBook(int id);
    }
}
