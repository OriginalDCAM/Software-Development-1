using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WpfApp.Helpers;
using WpfApp.Models;
using System.Windows.Input;

namespace WpfApp.ViewModels
{
    public class AuthorBooksViewModel : ObservableObject
    {
        private DataContext _context = new();
        private Author _selectedAuthor { get; set; }

        public Author SelectedAuthor
        {
            get => _selectedAuthor;
            set
            {
                _selectedAuthor = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(AuthorBooks));
            }
        }

        private ObservableCollection<Author> _editableData { get; set; }

        public ObservableCollection<Author> EditableData
        {
            get => _editableData;
            set
            {
                _editableData = value;
                OnPropertyChanged();
            }
        }

        public List<Author> backup { get; set; }

        private BookType[] _genreList = Enum.GetValues(typeof(BookType)).Cast<BookType>().ToArray();

        public BookType[] GenreList => _genreList;

        public ICommand SaveChangesCommand { get; set; }
        public ICommand RevertChangesCommand { get; set; }

        public ObservableCollection<Book> AuthorBooks =>
            SelectedAuthor != null ? new ObservableCollection<Book>(SelectedAuthor?.Books) : null;
        
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

        public AuthorBooksViewModel()
        {
            SaveChangesCommand = new RelayCommand(SaveChanges);
            RevertChangesCommand = new RelayCommand(RevertChanges);

            _context.Authors.Include(a => a.Books).Load();

            EditableData = _context.Authors.Local.ToObservableCollection();
            backup = _context.Authors.Local.ToObservableCollection().ToList();
        }

        private void SaveChanges(object obj)
        {
            ClearErrors("exception");
            try
            {
                _context.SaveChanges();
                SuccessContent = "Item Succesvol gewijzigd!";
            }
            catch (Exception e)
            {
                Debug.WriteLine($"{e.Message}");
                AddError("exception", $"Er is iets misgegaan probeer van pagina te veranderen :(");
                ErrorContent = GetErrors("exception")?.Cast<string>().FirstOrDefault() ?? "";
                SuccessContent = "";
            }
        }

        private void RevertChanges(object obj)
        {
            try
            {
                EditableData.Clear();
                foreach (var author in backup)
                {
                    EditableData.Add(author);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"{e.Message}");
                AddError(nameof(e), $"Er is iets misgegaan probeer van page te veranderen :(");
                ErrorContent = GetErrors(nameof(e))?.Cast<string>().FirstOrDefault() ?? "";
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