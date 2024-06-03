using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ssis.Dtos.Book;

namespace ssis.Dtos.Subject
{
    public class CreateSubjectFromJsonDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberOfWeeklyClasses { get; set; }
        public List<CreateBookFromJsonDto> LiteratureUsed { get; set; }
    }
}