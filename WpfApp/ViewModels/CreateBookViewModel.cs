using System;
using System.Linq;
using WpfApp.Helpers;
using WpfApp.Models;

namespace WpfApp.ViewModels
{
    public class CreateBookViewModel : ObservableObject
    {
        public string NameProperty { get; set; }
        public string DescriptionProperty { get; set; }
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
        private string _pageName { get; set; }

        public string PageName
        {
            get => _pageName;
            set
            {
                if (_pageName == value) return;
                _pageName = value;
                OnPropertyChanged();
            }
        }

        public CreateBookViewModel()
        {
            PageName = "Test";
        }
    }
}