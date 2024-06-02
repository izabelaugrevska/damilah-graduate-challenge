using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ssis.Dtos.Author;
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
                BookId = authorModel.BookId
            };
        }

        public static Author ToAuthorFromCreate(this CreateAuthorDto authorDto, int bookId)
        {
            return new Author
            {
                Name = authorDto.Name,
                LastName = authorDto.LastName,
                BookId = bookId
            };
        }
    }
}