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
    public class SubjectRepository : ISubjectRepository
    {
        private readonly ApplicationDBContext _context;
        public SubjectRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Subject> CreateAsync(Subject subjectModel)
        {
            await _context.Subjects.AddAsync(subjectModel);
            await _context.SaveChangesAsync();
            return subjectModel;
        }

        public async Task<List<Subject>> GetAllAsync()
        {
           return await _context.Subjects.Include(b => b.LiteratureUsed).ToListAsync();
        }

        public async Task<Subject?> GetByIdAsync(int id)
        {
            return await _context.Subjects.Include(b => b.LiteratureUsed).FirstOrDefaultAsync(i => i.Id == id);
        }

        public Task<bool> SubjectExists(int id)
        {
            return _context.Subjects.AnyAsync(s => s.Id == id);
        }
    }
}