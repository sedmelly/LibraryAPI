using System;
using LibraryApplication.Services.Base;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;
using LibraryAPI.Properties;
using LibraryApplication.Models;
using System.Linq;
using LibraryCore.Entities;
using Author = LibraryCore.Entities.Author;
using System.Collections.Generic;


namespace LibraryAPI.Controllers
{
    //public class AuthorController
   // {
        [ApiController]
        [Route("[controller]/[action]")]

        public class AuthorController : ControllerBase
        {

            private IAuthorService _service;

            public AuthorController(IAuthorService service)
            {
                _service = service;


            }

            [HttpGet]
            public async Task<ActionResult<string>> GetAuthors()
            {
                var authors = await _service.GetAllAsync();

                return JsonConvert.SerializeObject(authors);
            }

        [HttpPost]
        public async Task<ActionResult<string>> AddAuthor([FromBody] BookModel bookModel)  //http bodyde göndermek için formbody kullanılır.
        {
            var author = await _service.AddAuthor(bookModel);

            return JsonConvert.SerializeObject(author);
        }

        [HttpPut]
        public async Task<ActionResult<string>> UpdateBook([FromBody] Author author)
        {
            var result = await _service.UpdateAuthor(author);
            return JsonConvert.SerializeObject(result);

            //jsona çerviriyoruz sonucu.
        }

        [HttpDelete("{bookId}")]
        public async Task<ActionResult<string>> DeleteAuthor(Guid authorId)
        {
            var id = await _service.DeleteAuthor(authorId); //servise gönderiyoruz idyi. bize silinen ıdyi veriyor.eşittirin sağını ilk önce yapıp soluna eşitliyor.
            return id;
        }

        /*public AuthorController()
        {
        }*/
    }
    }
//}
