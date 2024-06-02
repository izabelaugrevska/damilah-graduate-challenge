using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ssis.Data;
using ssis.Interfaces;
using ssis.Models;

namespace ssis.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationDBContext _context;
        public AuthorRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Author> CreateAsync(Author authorModel)
        {
            await _context.Author.AddAsync(authorModel);
            await _context.SaveChangesAsync();
            return authorModel;
        }

        public async Task<List<Author>> GetAllAsync()
        {
            return await _context.Author.Include(b => b.Books).ToListAsync();
            

        }

        public async Task<Author?> GetByIdAsync(int id)
        {
     
            return await _context.Author.Include(b => b.Books).FirstOrDefaultAsync(i => i.Id == id);

        }
    }
}