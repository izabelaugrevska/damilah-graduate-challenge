using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ssis.Dtos.Author
{
    public class AuthorDto
    {
         public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
         public int BookId { get; set; }

    }
}