using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ssis.Dtos.Subject;
using ssis.Models;

namespace ssis.Mappers
{
    public static class SubjectMappers
    {
        public static SubjectDto ToSubjectDto(this Subject subjectModel)
        {
            return new SubjectDto
            {
                Id = subjectModel.Id,
                Name = subjectModel.Name,
                Description = subjectModel.Description,
                NumberOfWeeklyClasses = subjectModel.NumberOfWeeklyClasses
            };
        } 

        public static Subject ToSubjectFromCreateDTO(this CreateSubjectRequestDto subjectDto)
        {
            return new Subject
            {
                Name = subjectDto.Name,
                Description = subjectDto.Description,
                NumberOfWeeklyClasses = subjectDto.NumberOfWeeklyClasses
            };
        }
    }
}