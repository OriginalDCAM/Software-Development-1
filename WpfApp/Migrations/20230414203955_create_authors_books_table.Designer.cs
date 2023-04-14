﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WpfApp.Helpers;

namespace WpfApp.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230414203955_create_authors_books_table")]
    partial class create_authors_books_table
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("WpfApp.Models.Author", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "British author",
                            Name = "J.K. Rowling"
                        },
                        new
                        {
                            Id = 2,
                            Description = "British author",
                            Name = "J.R.R. Tolkien"
                        },
                        new
                        {
                            Id = 3,
                            Description = "American author",
                            Name = "George R.R. Martin"
                        },
                        new
                        {
                            Id = 4,
                            Description = "American author",
                            Name = "Stephen King"
                        },
                        new
                        {
                            Id = 5,
                            Description = "British author",
                            Name = "Agatha Christie"
                        },
                        new
                        {
                            Id = 6,
                            Description = "English novelist",
                            Name = "Jane Austen"
                        },
                        new
                        {
                            Id = 7,
                            Description = "Russian writer",
                            Name = "Leo Tolstoy"
                        },
                        new
                        {
                            Id = 8,
                            Description = "Russian novelist",
                            Name = "Fyodor Dostoevsky"
                        });
                });

            modelBuilder.Entity("WpfApp.Models.Book", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Genre")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            Description = "First book in the Harry Potter series",
                            Genre = 3,
                            Name = "Harry Potter and the Philosopher's Stone"
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 2,
                            Description = "Epic high-fantasy novel",
                            Genre = 3,
                            Name = "The Lord of the Rings"
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = 3,
                            Description = "First book in the A Song of Ice and Fire series",
                            Genre = 3,
                            Name = "A Game of Thrones"
                        },
                        new
                        {
                            Id = 4,
                            AuthorId = 4,
                            Description = "Horror novel",
                            Genre = 4,
                            Name = "The Shining"
                        },
                        new
                        {
                            Id = 5,
                            AuthorId = 5,
                            Description = "Detective novel",
                            Genre = 6,
                            Name = "Murder on the Orient Express"
                        },
                        new
                        {
                            Id = 6,
                            AuthorId = 6,
                            Description = "Novel of manners",
                            Genre = 7,
                            Name = "Pride and Prejudice"
                        },
                        new
                        {
                            Id = 7,
                            AuthorId = 7,
                            Description = "Historical novel",
                            Genre = 1,
                            Name = "War and Peace"
                        },
                        new
                        {
                            Id = 8,
                            AuthorId = 8,
                            Description = "Psychological thriller",
                            Genre = 2,
                            Name = "Crime and Punishment"
                        },
                        new
                        {
                            Id = 9,
                            AuthorId = 1,
                            Description = "Second book in the Harry Potter series",
                            Genre = 3,
                            Name = "Harry Potter and the Chambers of Secrets"
                        });
                });

            modelBuilder.Entity("WpfApp.Models.Book", b =>
                {
                    b.HasOne("WpfApp.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("WpfApp.Models.Author", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
