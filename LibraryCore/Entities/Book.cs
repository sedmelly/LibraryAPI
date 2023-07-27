using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryCore.Entities.Base;

namespace LibraryCore.Entities
{
    public class Book : Entity
    {
        public Guid AuthorId { get; set; }
        public int Stock { get; set; }
        public new Guid Id { get; set; }
        public string Name { get; set; }
    }
}
