using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ssis.Dtos.Author;
using ssis.Dtos.Book;
using ssis.Models;

namespace ssis.Mappers
{
    public static class BookMappers
    {
        public static BookDto ToBookDto(this Book bookModel)
        {
            return new BookDto
            {
                BookId = bookModel.BookId,
                BookName = bookModel.BookName,
                SubjectId = bookModel.SubjectId,
                // Author = bookModel.Author.Select(a => a.ToAuthorDto()).ToList()
                Author = bookModel.Author?.Select(a => new AuthorDto
            {
                Id = a.Id,
                Name = a.Name
                // Avoid circular reference by not including Books here
            }).ToList()
            };
        }

        public static Book ToBookFromCreate(this CreateBookDto bookDto, int subjectId)
        {
            return new Book
            {
                BookName = bookDto.BookName,
                SubjectId = subjectId
            };
        }

    }
}