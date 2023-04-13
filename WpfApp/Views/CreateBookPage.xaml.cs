using System.Windows;
using System.Windows.Controls;
using WpfApp.ViewModels;

namespace WpfApp.Views
{
    public partial class CreateBookPage : Page
    {
        public CreateBookPage()
        {
            InitializeComponent();
            DataContext = new CreateBookViewModel();
        }

        private void NavigateToAllItems__(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ViewAuthorBooksPage());
        }
    }
}