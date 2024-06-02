﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ssis.Data;

#nullable disable

namespace ssis.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20240602125314_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AuthorBook", b =>
                {
                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("BooksBookId")
                        .HasColumnType("int");

                    b.HasKey("AuthorId", "BooksBookId");

                    b.HasIndex("BooksBookId");

                    b.ToTable("AuthorBook");

                    b.HasData(
                        new
                        {
                            AuthorId = 1,
                            BooksBookId = 1
                        },
                        new
                        {
                            AuthorId = 2,
                            BooksBookId = 1
                        },
                        new
                        {
                            AuthorId = 2,
                            BooksBookId = 2
                        },
                        new
                        {
                            AuthorId = 3,
                            BooksBookId = 2
                        },
                        new
                        {
                            AuthorId = 1,
                            BooksBookId = 3
                        },
                        new
                        {
                            AuthorId = 3,
                            BooksBookId = 3
                        });
                });

            modelBuilder.Entity("ssis.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Author");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BookId = 0,
                            LastName = "Last Name 1",
                            Name = "Author 1"
                        },
                        new
                        {
                            Id = 2,
                            BookId = 0,
                            LastName = "Last Name 2",
                            Name = "Author 2"
                        },
                        new
                        {
                            Id = 3,
                            BookId = 0,
                            LastName = "Last Name 3",
                            Name = "Author 3"
                        });
                });

            modelBuilder.Entity("ssis.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookId"));

                    b.Property<string>("BookName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SubjectId")
                        .HasColumnType("int");

                    b.HasKey("BookId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            BookName = "Math Book",
                            SubjectId = 1
                        },
                        new
                        {
                            BookId = 2,
                            BookName = "English Book",
                            SubjectId = 2
                        },
                        new
                        {
                            BookId = 3,
                            BookName = "Art Book",
                            SubjectId = 3
                        });
                });

            modelBuilder.Entity("ssis.Models.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfWeeklyClasses")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Subjects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Basic Math",
                            Name = "Math",
                            NumberOfWeeklyClasses = 5
                        },
                        new
                        {
                            Id = 2,
                            Description = "Basic English",
                            Name = "English",
                            NumberOfWeeklyClasses = 4
                        },
                        new
                        {
                            Id = 3,
                            Description = "Basic Art",
                            Name = "Art",
                            NumberOfWeeklyClasses = 3
                        });
                });

            modelBuilder.Entity("AuthorBook", b =>
                {
                    b.HasOne("ssis.Models.Author", null)
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ssis.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksBookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ssis.Models.Book", b =>
                {
                    b.HasOne("ssis.Models.Subject", "Subject")
                        .WithMany("LiteratureUsed")
                        .HasForeignKey("SubjectId");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("ssis.Models.Subject", b =>
                {
                    b.Navigation("LiteratureUsed");
                });
#pragma warning restore 612, 618
        }
    }
}
