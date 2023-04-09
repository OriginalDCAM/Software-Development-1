using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WpfApp.Models;


namespace WpfApp.Helpers 
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        { 
        
            var authors = new List<Author>
            {
                new() { Id = 1, Name = "J.K. Rowling", Description = "British author" },
                new() { Id = 2,Name = "J.R.R. Tolkien", Description = "British author" },
                new() { Id = 3,Name = "George R.R. Martin", Description = "American author" },
                new() { Id = 4, Name = "Stephen King", Description = "American author" },
                new() { Id = 5, Name = "Agatha Christie", Description = "British author" },
                new() { Id = 6, Name = "Jane Austen", Description = "English novelist" },
                new() { Id = 7, Name = "Leo Tolstoy", Description = "Russian writer" },
                new() { Id = 8, Name = "Fyodor Dostoevsky", Description = "Russian novelist" }
            };

            var books = new List<Book>
            {
                new() { Id = 1,Name = "Harry Potter and the Philosopher's Stone", Description = "First book in the Harry Potter series", Genre = BookType.Fantasy, AuthorId = 1 },
                new() { Id = 2, Name = "The Lord of the Rings", Description = "Epic high-fantasy novel", Genre = BookType.Fantasy, AuthorId = 2 },
                new() { Id = 3, Name = "A Game of Thrones", Description = "First book in the A Song of Ice and Fire series", Genre = BookType.Fantasy, AuthorId = 3 },
                new() { Id = 4, Name = "The Shining", Description = "Horror novel", Genre = BookType.Horror, AuthorId = 4 },
                new() { Id = 5, Name = "Murder on the Orient Express", Description = "Detective novel", Genre = BookType.Mystery, AuthorId = 5 },
                new() { Id = 6, Name = "Pride and Prejudice", Description = "Novel of manners", Genre = BookType.Romance, AuthorId = 6 },
                new() { Id = 7, Name = "War and Peace", Description = "Historical novel", Genre = BookType.Classics, AuthorId = 7 },
                new() { Id = 8, Name = "Crime and Punishment", Description = "Psychological thriller", Genre = BookType.Crime, AuthorId = 8 },
                new() { Id = 9, Name = "Harry Potter and the Chambers of Secrets", Description = "Second book in the Harry Potter series", Genre = BookType.Fantasy, AuthorId = 1}
                
            };
            modelBuilder.Entity<Author>().HasData(authors);
            modelBuilder.Entity<Book>().HasData(books);
        }
    }
}