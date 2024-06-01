using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ssis.Dtos.Book;
using ssis.Interfaces;
using ssis.Mappers;
using ssis.Models;

namespace ssis.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepo;
        private readonly ISubjectRepository _subjectRepo;

        public BookService(IBookRepository bookRepo, ISubjectRepository subjectRepo)
        {
            _bookRepo = bookRepo;
            _subjectRepo = subjectRepo;
        }
        public async Task<BookDto> CreateBookAsync(int subjectId, CreateBookDto bookDto)
        {
            if (!await _subjectRepo.SubjectExists(subjectId))
            {
                throw new ArgumentException("Subject does not exist");
            }

            var bookModel = bookDto.ToBookFromCreate(subjectId);
            await _bookRepo.CreateAsync(bookModel);

            return bookModel.ToBookDto();
        }

        public async Task<IEnumerable<BookDto>> GetAllBooksAsync()
        {
            var books = await _bookRepo.GetAllAsync();
            return books.Select(b => b.ToBookDto());
        }

        public async Task<BookDto> GetBookByIdAsync(int id)
        {
            var book = await _bookRepo.GetByIdAsync(id);
            return book?.ToBookDto();
        }
    }
}