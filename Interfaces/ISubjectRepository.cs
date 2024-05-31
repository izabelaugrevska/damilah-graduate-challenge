using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ssis.Models;

namespace ssis.Interfaces
{
    public interface ISubjectRepository
    {
        Task<List<Subject>> GetAllAsync();

        Task<Subject?> GetByIdAsync(int id);

        Task<Subject> CreateAsync(Subject subjectModel);
    }
}