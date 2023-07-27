using System;
using LibraryCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryApplication.Mapper;
using LibraryApplication.Models;
using System.Linq;
using System.Text;


namespace LibraryApplication.Services.Base
{
    public interface IAuthorService
    {
        Task<IReadOnlyList<Author>> GetAllAsync();
        Task<IReadOnlyList<Author>> GetAuthors();
        Task<Author> AddAuthor(BookModel author);
        Task<Author> UpdateAuthor(Author author);
        Task<string> DeleteAuthor(Guid authorId);

    }


    /*public class IAuthorService
	{


        public IAuthorService()
		{
		}
    }*/
}

