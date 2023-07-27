using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryInfrastructure.Data
{
    public class LibraryContext:DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        //public DbSet<Id1> BookId { get; set; }
    }





}

