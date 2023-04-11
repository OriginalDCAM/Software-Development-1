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
        private string _messageProperty { get; set; }

        public string MessageProperty
        {
            get => _messageProperty;
            set
            {
                _messageProperty = value;
                OnPropertyChanged();
            }
        }

        private string _messagePropertyColor { get; set; } = "Black";

        public string MessagePropertyColor
        {
            get => _messagePropertyColor;
            set
            {
                _messagePropertyColor = value;
                OnPropertyChanged();
            }
        }
        
        
        
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
                ValidateProperties();

                _context.Books.Add(new()
                {
                    Name = NameProperty,
                    Description = DescriptionProperty,
                    AuthorId = Id,
                    Genre = SelectedGenre
                });
                _context.SaveChanges();
                MessagePropertyColor = "Green";
                MessageProperty = "Boek is toegevoegd";

            }
            catch (Exception exception)
            {
                Trace.WriteLine(exception);
                MessagePropertyColor = "Red";
                Trace.WriteLine(MessagePropertyColor);
                MessageProperty = exception.Message;

            }
        }

        private void ValidateProperties()
        {
                if (NameProperty == null)
                {
                    throw new Exception("Naam veld is niet ingevuld!");
                }
                if (DescriptionProperty == null)
                { 
                    throw new Exception("Beschrijving veld niet ingevuld!");
                }
                if (Id == 0)
                {
                    throw new Exception($"Selecteer een auteur uit de lijst hierboven {Id}");
                }

        }
    }
}