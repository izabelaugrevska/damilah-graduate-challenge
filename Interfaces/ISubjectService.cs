using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ssis.Dtos.Subject;

namespace ssis.Interfaces
{
    public interface ISubjectService
    {
        Task<IEnumerable<SubjectDto>> GetAllSubjectsAsync();
        Task<SubjectDto> GetSubjectByIdAsync(int id);
        Task<SubjectDto> CreateSubjectAsync(CreateSubjectRequestDto subjectDto);
        Task<bool> SubjectExistsAsync(int? subjectId = null, string name = null);
        Task CreateJsonSubjectAsync(CreateSubjectFromJsonDto subjectDto);
        Task CreateSubjectsAsync(List<CreateSubjectFromJsonDto> subjects);
    }
}