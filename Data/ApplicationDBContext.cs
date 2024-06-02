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

        public DbSet<Author> Author { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    // Seeding Authors
    modelBuilder.Entity<Author>().HasData(
        new Author { Id = 1, Name = "Author 1", LastName = "Last Name 1" },
        new Author { Id = 2, Name = "Author 2", LastName = "Last Name 2" },
        new Author { Id = 3, Name = "Author 3", LastName = "Last Name 3" }
    );

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

    // Seeding many-to-many relationships
    modelBuilder.Entity<Book>()
        .HasMany(b => b.Author)
        .WithMany(a => a.Books)
        .UsingEntity(j => j.HasData(
            new { BooksBookId = 1, AuthorId = 1 },
            new { BooksBookId = 1, AuthorId = 2 },
            new { BooksBookId = 2, AuthorId = 2 },
            new { BooksBookId = 2, AuthorId = 3 },
            new { BooksBookId = 3, AuthorId = 1 },
            new { BooksBookId = 3, AuthorId = 3 }
        ));
}

    }

    
}