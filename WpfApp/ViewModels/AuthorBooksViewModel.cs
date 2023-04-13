using System;
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

        private ObservableCollection<Author> _authorList { get; set; }

        public ObservableCollection<Author> AuthorList
        {
            get => _authorList;
            set
            {
                _authorList = value;
                OnPropertyChanged();
            }
        }
        
        private BookType[] _genreList = Enum.GetValues(typeof(BookType)).Cast<BookType>().ToArray();

        public BookType[] GenreList => _genreList;

        public ICommand CellEditEndingCommand { get; set; }

        public ObservableCollection<Book> AuthorBooks =>
            SelectedAuthor != null ? new ObservableCollection<Book>(SelectedAuthor?.Books) : null;


        public AuthorBooksViewModel()
        {
            CellEditEndingCommand = new RelayCommand(CellEditEnding);
            _context.Authors.Include(a => a.Books).Load();
            AuthorList = _context.Authors.Local.ToObservableCollection();
        }

        private void CellEditEnding(object obj)
        {
            Debug.WriteLine($"Saved the Changes: {AuthorList}");
            _context.SaveChanges();
        }
    }
}