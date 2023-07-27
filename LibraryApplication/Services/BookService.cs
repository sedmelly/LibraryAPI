using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApplication.Mapper;
using LibraryApplication.Models;
using LibraryApplication.Services.Base;
using LibraryCore.Entities;

namespace LibraryApplication.Services
{
    public class BookService : IBookService
    {

        IBookRepository _repository;

        public BookService(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<IReadOnlyList<Book>> GetBooks()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<IReadOnlyList<Book>> GetBooksByName(string bookName)
        {
            return await _repository.GetBookByName(bookName);
        }

        public async Task<IReadOnlyList<Book>> GetBooksInStock()
        {
            return await _repository.GetBooksInStock();
        }

        public async Task<Book> AddBook(BookModel bookModel)
        {
            var model = LibraryMapper.Mapper.Map<Book>(bookModel);
            //bookmodel objesini book objesine çeviriyor  nedeni veritabanı bookmodeli tanımıyor booku biliyor

            return await _repository.AddBook(model);

            //veri tabanına kaydetmek için repositoryye gidiyoruz.

        }

        public async Task<Book> UpdateBook(Book book)
        {
            return await _repository.UpdateBook(book);

        }//repositoryye atıyoruz 

        public async Task<string> DeleteBook(Guid bookId)
        {
            return await _repository.DeleteBook(bookId);


        }

    }

  



}

