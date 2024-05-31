using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ssis.Dtos.Book
{
    public class CreateBookDto
    {
        public string BookName { get; set; } = string.Empty;

        public string Author { get; set; } = string.Empty;
        
    }
}