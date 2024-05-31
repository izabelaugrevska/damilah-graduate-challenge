using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ssis.Models
{
    public class Book
    {
        public int BookId { get; set; }

        public int? SubjectId {get; set; }
        public Subject? Subject { get; set; }
        public string BookName { get; set; } = string.Empty;

        public string Author { get; set; } = string.Empty;
    }
}