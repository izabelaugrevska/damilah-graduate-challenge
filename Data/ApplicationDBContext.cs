using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ssis.Models;

namespace ssis.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Subject> Subjects { get; set; }
        
        public DbSet<Book> Books { get; set; }

    }
}