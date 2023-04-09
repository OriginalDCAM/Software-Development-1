using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Security;
using System.Windows.Documents;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using WpfApp.Helpers;
using WpfApp.Models;

namespace WpfApp.ViewModels
{
    public class CreateBookViewModel : ObservableObject
    {
        private readonly DataContext _context = new DataContext();
        
        public string NameProperty { get; set; }
        public string DescriptionProperty { get; set; }
        public string TestValue { get; set; }
        
        public int Id {get; set; }
        private BookType[] _genres = Enum.GetValues(typeof(BookType)).Cast<BookType>().ToArray();
        public BookType[] Genres
        {
            get { return _genres; }
        }

        private BookType _selectedGenre;

        public BookType SelectedGenre
        {
            get { return _selectedGenre; }
            set
            {
                if (_selectedGenre == value) return;
                _selectedGenre = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Author> _authors;

        public ObservableCollection<Author> Authors
        {
            get => _authors;
            set
            {
                _authors = value;
                OnPropertyChanged();
            }
        }

        public ICommand CreateBookCommand { get; set; }
        
        public CreateBookViewModel()
        {
            _context.Database.EnsureCreated();
            _context.Authors.Load();
            InitializeCommands();
            
            Authors = _context.Authors.Local.ToObservableCollection();
        }

        public void InitializeCommands()
        {
            CreateBookCommand = new RelayCommand(CreateAuthor);
        }
        private string _searchQuery;

        public string SearchQuery
        {
            get => _searchQuery;
            set
            {
                if (_searchQuery == value) return;
                _searchQuery = value;
                OnPropertyChanged();
                SearchAuthors(_searchQuery);
            }
        }

        public void SearchAuthors(string searchQuery)
        {
            Debug.WriteLine($"SearchAuthor: {searchQuery}");
            if (string.IsNullOrEmpty(searchQuery))
            {
                Authors = _context.Authors.Local.ToObservableCollection();
            }
            else
            {
                var matchingAuthors = _context.Authors
                    .Where(a => a.Name.Contains(searchQuery))
                    .ToList();
                Authors = new ObservableCollection<Author>(matchingAuthors);
            }
        }

        public void CreateAuthor(object e)
        {
            try
            {
                _context.Books.Add(new()
                {
                    Name = NameProperty,
                    Description = DescriptionProperty,
                    AuthorId = Id,
                    Genre = SelectedGenre
                });
                _context.SaveChanges();
                Trace.WriteLine("Success");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }
    }
}