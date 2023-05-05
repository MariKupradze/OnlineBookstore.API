using Microsoft.EntityFrameworkCore;
using OnlineBookstore.API.Context;
using OnlineBookstore.API.Models;


namespace OnlineBookstore.API.Interfaces
    {
        public interface IAuthorRepository
        {
            Task<IEnumerable<Author>> GetAuthors();
            Task<Author> GetAuthorById(int id);
            Task AddAuthor(Author author);
            Task UpdateAuthor(Author author);
            Task DeleteAuthor(int id);
        }
    }

