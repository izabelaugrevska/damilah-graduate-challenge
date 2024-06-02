using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ssis.Dtos.Author;

namespace ssis.Dtos.Book
{
    public class BookDto
    {
        public int BookId { get; set; }

        public int? SubjectId {get; set; }
        public string BookName { get; set; } = string.Empty;
        public List<AuthorDto> Author { get; set; }

    }
}