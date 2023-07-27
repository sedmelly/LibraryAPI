using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryCore.Entities;
using LibraryCore.Repositories;
using LibraryInfrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LibraryInfrastructure.Repositories
{
	public class AuthorRepository:IAuthorRepository
	{
        LibraryContext _context;
        public AuthorRepository(LibraryContext context)
		{

            _context = context;

        }

        public async Task<Author> AddAuthor(Author author)
        {
            author.Id = Guid.NewGuid();

            await _context.AddAsync(author);
            await _context.SaveChangesAsync(); 

            return author;
        }

        public async Task<string> DeleteAuthor(Guid id)
        {
            var author = await GetAuthorById(id);
            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();

            return id.ToString();
        }

        public async Task<IReadOnlyList<Author>> GetAllAsync()
        {
            return _context.Authors.ToList();
        }

        public async Task<Author> GetAuthorById(Guid id)
        {
            return await _context.Authors.FindAsync(id);
        }

        public async Task<Author> UpdateAuthor(Author author)
        {
            _context.Entry(author).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return author;
           
        }
    }
}

