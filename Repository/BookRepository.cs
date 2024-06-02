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
    
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDBContext _context;
        public BookRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Book> CreateAsync(Book bookModel)
        {
            await _context.Books.AddAsync(bookModel);
            await _context.SaveChangesAsync();
            return bookModel;
        }

        public async Task<List<Book>> GetAllAsync()
        {
            return await _context.Books.Include(b => b.Author).ToListAsync();
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            return await _context.Books.Include(a => a.Author).FirstOrDefaultAsync(i => i.BookId == id);
        }

        public Task<bool> BookExists(int id)
        {
            return _context.Books.AnyAsync(b => b.BookId == id);
        }
    }
}