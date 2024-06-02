using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ssis.Dtos.Author;
using ssis.Dtos.Book;
using ssis.Models;

namespace ssis.Mappers
{
    public static class AuthorMapper
    {
        public static AuthorDto ToAuthorDto(this Author authorModel)
        {
            return new AuthorDto
            {
                Id = authorModel.Id,
                Name = authorModel.Name,
                LastName = authorModel.LastName,
                Books = authorModel.Books?.Select(b => new BookDto
            {
                BookId = b.BookId,
                BookName = b.BookName,
                SubjectId = b.SubjectId
                // Avoid circular reference by not including Authors here
            }).ToList()
            };
        }

        public static Author ToAuthorFromCreate(this CreateAuthorDto authorDto)
        {
            return new Author
            {
                Name = authorDto.Name,
                LastName = authorDto.LastName,
               // BookId = bookId
            };
        }
    }
}