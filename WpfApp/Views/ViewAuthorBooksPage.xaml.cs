using System.Windows.Controls;
using WpfApp.ViewModels;

namespace WpfApp.Views
{
    public partial class ViewAuthorBooksPage : Page
    {
        public ViewAuthorBooksPage()
        {
            InitializeComponent();
            DataContext = new AuthorBooksViewModel();
        }
    }
}