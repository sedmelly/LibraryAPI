using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryCore.Entities;

namespace LibraryCore.Repositories
{
   /* class IAuthorRepository
    {


    }*/
   public interface IAuthorRepository
    {
        Task<IReadOnlyList<Author>> GetAllAsync();
        Task<Author> GetAuthorById(Guid id);
        Task<Author> AddAuthor(Author author);
        Task<Author> UpdateAuthor(Author author);
        Task<string> DeleteAuthor(Guid id);
    }
  
    
}
