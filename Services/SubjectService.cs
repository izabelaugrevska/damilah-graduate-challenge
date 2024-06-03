using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ssis.Dtos.Subject;
using ssis.Interfaces;
using ssis.Mappers;
using ssis.Models;

namespace ssis.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepo;

        public SubjectService(ISubjectRepository subjectRepo)
        {
            _subjectRepo = subjectRepo;
        }

        public async Task CreateJsonSubjectAsync(CreateSubjectFromJsonDto subjectDto)
        {
            if (await SubjectExistsAsync(name: subjectDto.Name))
            {
                return;
            }
            var subject = new Subject
            {
                Name = subjectDto.Name,
                Description = subjectDto.Description,
                NumberOfWeeklyClasses = subjectDto.NumberOfWeeklyClasses,
                LiteratureUsed = subjectDto.LiteratureUsed?.ConvertAll(b => new Book
                {
                    BookName = b.BookName
                })
            };

            await _subjectRepo.CreateAsync(subject);
        }

        public async Task CreateSubjectsAsync(List<CreateSubjectFromJsonDto> subjects)
        {
            foreach (var subject in subjects)
            {

                await CreateJsonSubjectAsync(subject);

            }
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

        public async Task<bool> SubjectExistsAsync(int? subjectId = null, string name = null)
        {
            return await _subjectRepo.SubjectExists(subjectId, name);
        }
    }
}