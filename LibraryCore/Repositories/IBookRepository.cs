using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryCore.Entities;

namespace LibraryProject.Repositories
{
  

 }

    public interface IBookRepository
    {
        Task<IReadOnlyList<Book>> GetAllAsync();
        Task<List<Book>> GetBooksInStock();
        Task<List<Book>> GetBookByName(string bookName);
        Task<Book> GetBookById(Guid id);
        Task<Book> AddBook(Book book);
        Task<Book> UpdateBook(Book book);
        Task<string> DeleteBook(Guid id);

    }


