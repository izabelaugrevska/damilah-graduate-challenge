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
                },
                new Subject
                {
                    Id = 4,
                    Name = "French",
                    Description = "Begginer French",
                    NumberOfWeeklyClasses = 4
                },
                new Subject
                {
                    Id = 5,
                    Name = "Chemistry",
                    Description = "Basic Chemistry",
                    NumberOfWeeklyClasses = 5
                }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book { BookId = 1, BookName = "Basic technical mathematics with calculus", SubjectId = 1 },
                new Book { BookId = 2, BookName = "Essential Maths", SubjectId = 1 },
                new Book { BookId = 3, BookName = "The Great Gatsby", SubjectId = 2 },
                new Book { BookId = 4, BookName = "To Kill A Mockingbird", SubjectId = 2 },
                new Book { BookId = 5, BookName = "The Story Of Art", SubjectId = 3 },
                new Book { BookId = 6, BookName = "501 Essential French Verbs", SubjectId = 4 },
                new Book { BookId = 7, BookName = "Organic Chemistry", SubjectId = 5 }
            );

        }

    }


}