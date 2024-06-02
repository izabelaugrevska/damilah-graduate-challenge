using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ssis.Models
{
    public class Author
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }

        public int BookId { get; set; }

        public Book? Book { get; set; }

    }
}