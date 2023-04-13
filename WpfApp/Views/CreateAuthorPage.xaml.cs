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
    }
}