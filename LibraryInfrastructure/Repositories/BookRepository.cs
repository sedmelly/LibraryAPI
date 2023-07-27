using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryCore.Entities;
using LibraryCore.Repositories;
using LibraryInfrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LibraryProject.Repositories
{
    public class BookRepository : IBookRepository
    {
        LibraryContext _context;

        public BookRepository(LibraryContext context)
        {

            _context = context;

        }

        public async Task<IReadOnlyList<Book>> GetAllAsync()
        {
            return _context.Books.ToList();
        }

        public async Task<List<Book>> GetBookByName(string bookName)
        {
            return _context.Books.Where(x => x.Name == bookName).ToList();

        }

        public async Task<Book> GetBookById(Guid id)
        {
            return await _context.Books.FindAsync(id);

        }

        public async Task<List<Book>> GetBooksInStock()
        {
            return _context.Books.Where(x => x.Stock > 0).ToList();
        }

        public async Task<Book> AddBook(Book book)
        {
            book.Id = Guid.NewGuid();

            await _context.AddAsync(book);
            await _context.SaveChangesAsync(); // değişiklikleri veri tabanına yansıtır.

            return book;
        }

        public async Task<Book> UpdateBook(Book book)
        {
            _context.Entry(book).State = EntityState.Modified;//update için sadece bunu yapsan da olur
            await _context.SaveChangesAsync();//değişiklikleri dbye yansıttık
            return book;
            //güncelle ve durumunu modified olarak işaretler

        }

        public async Task<string> DeleteBook(Guid id)
        {
            var book = await GetBookById(id);
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return id.ToString();

        }
    }

    


}