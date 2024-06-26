using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ssis.Dtos.Book;
using ssis.Models;

namespace ssis.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetAllBooksAsync();
        Task<BookDto> GetBookByIdAsync(int id);
        Task<BookDto> CreateBookWithInfoAsync(string title, int subjectId);
        Task<BookInfoDto> GetBookInfoAsync(string title);
    }
}