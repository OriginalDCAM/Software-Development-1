using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            try
            {
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Debug.WriteLine($"{e.Message}");
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
                Debug.WriteLine(e.Message);
            }
        }
    }
}