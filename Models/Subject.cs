using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ssis.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int NumberOfWeeklyClasses { get; set; }
        public List<Book> LiteratureUsed { get; set; } = new List<Book>();
    }
}