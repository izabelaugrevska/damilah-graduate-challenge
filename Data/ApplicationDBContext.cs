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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    // Seeding Authors

    // Seeding Subjects
    modelBuilder.Entity<Subject>().HasData(
        new Subject
        {
            Id = 1,
            Name = "Math",
            Description = "Basic Math",
            NumberOfWeeklyClasses = 5
        },
        new Subject
        {
            Id = 2,
            Name = "English",
            Description = "Basic English",
            NumberOfWeeklyClasses = 4
        },
        new Subject
        {
            Id = 3,
            Name = "Art",
            Description = "Basic Art",
            NumberOfWeeklyClasses = 3
        }
    );

    // Seeding Books
    modelBuilder.Entity<Book>().HasData(
        new Book { BookId = 1, BookName = "Math Book", SubjectId = 1 },
        new Book { BookId = 2, BookName = "English Book", SubjectId = 2 },
        new Book { BookId = 3, BookName = "Art Book", SubjectId = 3 }
    );

}

    }

    
}