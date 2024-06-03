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
        private readonly ILogger<SubjectService> _logger;

        public SubjectService(ISubjectRepository subjectRepo, ILogger<SubjectService> logger)
        {
            _subjectRepo = subjectRepo;
            _logger = logger;
        }

        public async Task CreateJsonSubjectAsync(CreateSubjectFromJsonDto subjectDto)
        {
            if (await SubjectExistsAsync(name: subjectDto.Name))
        {
            _logger.LogInformation($"Subject with name {subjectDto.Name} already exists. Skipping.");
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
                try {
                    _logger.LogInformation($"Creating subject: {subject.Name}");

                    await CreateJsonSubjectAsync(subject);
                    _logger.LogInformation($"Successfully created subject: {subject.Name}");
                }
                catch (Exception ex) {
                     _logger.LogError($"Failed to create subject: {subject.Name}. Error: {ex.Message}");

                }
            

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