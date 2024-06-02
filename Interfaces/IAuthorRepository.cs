using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ssis.Models;

namespace ssis.Interfaces
{
    public interface IAuthorRepository
    {
        Task<List<Author>> GetAllAsync();
        Task<Author?> GetByIdAsync(int id);

        Task<Author> CreateAsync(Author authorModel);
    }
}