using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ssis.Dtos.Subject;
using ssis.Interfaces;
using ssis.Mappers;

namespace ssis.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepo;
        public SubjectService(ISubjectRepository subjectRepo)
        {
            _subjectRepo = subjectRepo;
        }

        public async Task<SubjectDto> CreateSubjectAsync(CreateSubjectRequestDto subjectDto)
        {
            var subjectModel = subjectDto.ToSubjectFromCreateDTO();
            await _subjectRepo.CreateAsync(subjectModel);
            return subjectModel.ToSubjectDto();
        }

        public async Task<IEnumerable<SubjectDto>> GetAllSubjectsAsync()
        {
            var subjects = await _subjectRepo.GetAllAsync();
            
            return subjects.Select(s => s.ToSubjectDto());
        }

        public async Task<SubjectDto> GetSubjectByIdAsync(int id)
        {
            var subject = await _subjectRepo.GetByIdAsync(id);
            
            return subject?.ToSubjectDto();
        }

        public async Task<bool> SubjectExistsAsync(int subjectId)
        {
            return await _subjectRepo.SubjectExists(subjectId);
        }
    }
}