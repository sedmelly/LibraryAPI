using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApplication.Mapper;
using LibraryApplication.Models;
using LibraryCore.Entities;
namespace LibraryApplication.Services.Base
{
    public interface IBookService
    {
       

    }
}
public interface IBookService
{
    Task<IReadOnlyList<Book>> GetBooks();
    Task<IReadOnlyList<Book>> GetBooksInStock();
    Task<IReadOnlyList<Book>> GetBooksByName(string bookName);
    Task<Book> AddBook(BookModel book);
    Task<Book> UpdateBook(Book book);
    Task<string> DeleteBook(Guid bookId);

}

