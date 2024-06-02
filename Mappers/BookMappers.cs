using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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