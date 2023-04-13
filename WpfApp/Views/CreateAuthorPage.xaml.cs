using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfApp.Helpers;
using WpfApp.Models;
using WpfApp.ViewModels;

namespace WpfApp.Views
{
    public partial class CreateAuthorPage : Page
    {
        public CreateAuthorPage()
        {
            InitializeComponent();
            DataContext = new CreateAuthorViewModel();
        }

        private void NavigateToAllItems__(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ViewAuthorBooksPage());
        }
    }
}