using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ssis.Models;

namespace ssis.Interfaces
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllAsync();
        Task<Book?> GetByIdAsync(int id);

        Task<Book> CreateAsync(Book bookModel);
        Task<bool> BookExists(int id);
    }
}