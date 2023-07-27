using System;
using LibraryApplication.Mapper;
using LibraryApplication.Models;
using LibraryApplication.Services.Base;
using LibraryCore.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibraryCore.Repositories;
using System.Threading.Tasks;

namespace LibraryApplication.Services
{
	public class AuthorService:IAuthorService
	{

        IAuthorRepository _repository;
        public AuthorService(IAuthorRepository repository)
        {
            _repository = repository;
        }

        public async Task<IReadOnlyList<Author>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
        public async Task<Author> AddAuthor(BookModel bookModel)
        {
            var model = LibraryMapper.Mapper.Map<Author>(bookModel);
            //bookmodel objesini book objesine çeviriyor  nedeni veritabanı bookmodeli tanımıyor booku biliyor

            return await _repository.AddAuthor(model);

            //veri tabanına kaydetmek için repositoryye gidiyoruz.

        }

        public async Task<Author> UpdateAuthor(Author author)
        {
            return await _repository.UpdateAuthor(author);

        }//repositoryye atıyoruz 

        public async Task<string> DeleteAuthor(Guid authorId)
        {
            return await _repository.DeleteAuthor(authorId);


        }

        public Task<IReadOnlyList<Author>> GetAuthors()
        {
            throw new NotImplementedException();
        }

       
    }

    /*public AuthorService()
    {

    }*/
}


