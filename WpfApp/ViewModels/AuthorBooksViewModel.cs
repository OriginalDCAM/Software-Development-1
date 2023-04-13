using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using WpfApp.Helpers;
using WpfApp.Models;
using System.Linq;

namespace WpfApp.ViewModels
{
    public class AuthorBooksViewModel : ObservableObject
    {
        private DataContext _context = new DataContext();
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
        public ObservableCollection<Author> AuthorList { get; set; }

        public ObservableCollection<Book> AuthorBooks =>
                SelectedAuthor != null ? new ObservableCollection<Book>(SelectedAuthor?.Books) : null;


        public AuthorBooksViewModel()
        {
            _context.Authors.Include(a => a.Books).Load();
            AuthorList = _context.Authors.Local.ToObservableCollection();

        }
    }
}