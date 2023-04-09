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
    }
}