using LibraryAPI.Properties;
using LibraryApplication.Models;
using LibraryApplication.Services.Base;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using LibraryCore.Entities;
using System.Threading.Tasks;
using Book = LibraryCore.Entities.Book;
//using Book = LibraryAPI.Properties.Book;
//using JsonConverter = System.Text.Json.Serialization.JsonConverter;
//using LibraryCore.Entities;

namespace LibraryProject.Controllers //libraryapı.controllers
   
{
    [Route("api/[controller]/[action]")]
    public class BookController : ControllerBase
    {
        private IBookService _service;

        public BookController(IBookService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<string>> GetBooks()
        {
            var books = await _service.GetBooks();
            return JsonConvert.SerializeObject(books);
        }


        [HttpGet("{bookName}")]
        public async Task<ActionResult<string>> GetBookByName(string bookName)
        {
            var books = await _service.GetBooksByName(bookName);
            return JsonConvert.SerializeObject(books);
        }


        [HttpGet]
        public async Task<ActionResult<string>> GetBooksInStock()
        {
            return JsonConvert.SerializeObject(await _service.GetBooksInStock());
        }

        
        [HttpPost]
        public async Task<ActionResult<string>> AddBook([FromBody] BookModel bookModel)  //http bodyde göndermek için formbody kullanılır.
        {
            var book = await _service.AddBook(bookModel);

            return JsonConvert.SerializeObject(book);
        }

        [HttpPut]
        public async Task<ActionResult<string>> UpdateBook([FromBody] Book book)
        {
            var result = await _service.UpdateBook(book);
            return JsonConvert.SerializeObject(result);

            //jsona çerviriyoruz sonucu.
        }

        [HttpDelete("{bookId}")]
        public async Task<ActionResult<string>> DeleteBook(Guid bookId)
        {
            var id = await _service.DeleteBook(bookId); //servise gönderiyoruz idyi. bize silinen ıdyi veriyor.eşittirin sağını ilk önce yapıp soluna eşitliyor.
            return id;
        }


      /*  public async Task<IReadOnlyList<>> GetAllBooks()
        {

        }*/
    }
}
