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
        private readonly OpenLibraryService _openLibraryService;


        public BookService(IBookRepository bookRepo, OpenLibraryService openLibraryService)
        {
            _bookRepo = bookRepo;
            _openLibraryService = openLibraryService;
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

        public async Task<BookInfoDto> GetBookInfoAsync(string title)
        {
            return await _openLibraryService.GetBookInfoByTitleAsync(title);
        }

        public async Task<BookDto> CreateBookWithInfoAsync(string title, int subjectId)
        {
            var book = new Book
            {
                BookName = title,
                SubjectId = subjectId
            };
            await _bookRepo.CreateAsync(book);
            return book.ToBookDto();
        }
    }
}