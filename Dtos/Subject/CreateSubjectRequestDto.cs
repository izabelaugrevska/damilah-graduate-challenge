using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ssis.Dtos.Subject
{
    public class CreateSubjectRequestDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int NumberOfWeeklyClasses { get; set; }
    }
}