using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using WpfApp.Helpers;
using WpfApp.Models;

namespace WpfApp.ViewModels
{
    public class CreateBookViewModel : ObservableObject
    {
        private readonly DataContext _context = new();
        private string _nameProperty;
        private string _descriptionProperty;

        public string NameProperty
        {
            get => _nameProperty;
            set
            {
                _nameProperty = value;
                OnPropertyChanged();
            }
        }

        public string DescriptionProperty
        {
            get => _descriptionProperty;
            set
            {
                _descriptionProperty = value;
                OnPropertyChanged();
            }
        }

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


        private string _errorContent;

        public string ErrorContent
        {
            get => _errorContent;
            set
            {
                _errorContent = value;
                OnPropertyChanged();
            }
        }

        private string _successContent;

        public string SuccessContent
        {
            get => _successContent;
            set
            {
                _successContent = value;
                OnPropertyChanged();
            }
        }

        public int Id { get; set; }
        private BookType[] _genres = Enum.GetValues(typeof(BookType)).Cast<BookType>().ToArray();

        public BookType[] Genres => _genres;

        private BookType _selectedGenre;

        public BookType SelectedGenre
        {
            get => _selectedGenre;
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
            CreateBookCommand = new RelayCommand(CreateBook);
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

        public void CreateBook(object e)
        {
            ValidateProperties();
            if (HasErrors) return;
            try
            {
                var nameExists = _context.Books.Any(b => b.Name == NameProperty);

                if (nameExists) throw new DbUpdateException("Er bestaat al een boek met dezelfde naam.");
                _context.Books.Add(new Book
                {
                    Name = NameProperty,
                    Description = DescriptionProperty,
                    AuthorId = Id,
                    Genre = SelectedGenre
                });
                _context.SaveChangesAsync();
                SuccessContent = $"{NameProperty} succesvol toegevoegd!";
            }
            catch (Exception exception)
            {
                AddError(nameof(NameProperty), $"{exception.Message}");
                ErrorContent = GetErrors(nameof(NameProperty))?.Cast<string>().FirstOrDefault() ?? "";
                SuccessContent = "";
            }
        }

        // Code voor valideren van properties en error handling
        private readonly Dictionary<string, List<string>>
            _errorsByPropertyName = new();

        public bool HasErrors => _errorsByPropertyName.Any();

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            return _errorsByPropertyName.TryGetValue(propertyName, out var value) ? value : null;
        }

        private void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        private void ValidateProperties()
        {
            SuccessContent = "";
            ClearErrors(nameof(NameProperty));
            ClearErrors(nameof(DescriptionProperty));
            ClearErrors(nameof(Id));
            if (string.IsNullOrWhiteSpace(NameProperty))
                AddError(nameof(NameProperty), "Naam mag niet leeg zijn.");
            if (NameProperty == null || NameProperty?.Length <= 4)
                AddError(nameof(NameProperty), "Naam moet tenminsten 5 karaters bevatten!");
            if (string.IsNullOrWhiteSpace(DescriptionProperty))
                AddError(nameof(DescriptionProperty), "Beschrijving mag niet leeg zijn");
            if (Id == 0) 
                AddError(nameof(Id), "Selecteer een van de auteurs hierboven!");
            ErrorContent = GetErrors(nameof(NameProperty))?.Cast<string>().FirstOrDefault() ??
                           GetErrors(nameof(DescriptionProperty))?.Cast<string>().FirstOrDefault() ??
                           GetErrors(nameof(Id))?.Cast<string>().FirstOrDefault() ??
                           "";
        }

        private void AddError(string propertyName, string error)
        {
            if (!_errorsByPropertyName.ContainsKey(propertyName))
                _errorsByPropertyName[propertyName] = new List<string>();

            if (_errorsByPropertyName[propertyName].Contains(error)) return;
            _errorsByPropertyName[propertyName].Add(error);
            OnErrorsChanged(propertyName);
        }

        private void ClearErrors(string propertyName)
        {
            if (!_errorsByPropertyName.ContainsKey(propertyName)) return;
            _errorsByPropertyName.Remove(propertyName);
            OnErrorsChanged(propertyName);
        }
    }
}