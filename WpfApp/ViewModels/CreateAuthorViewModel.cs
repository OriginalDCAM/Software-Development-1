using System;
using System.Diagnostics;
using System.Windows.Input;
using WpfApp.Helpers;
using WpfApp.Models;

namespace WpfApp.ViewModels
{
    public class CreateAuthorViewModel : ObservableObject
    {
        
        private readonly DataContext _context = new DataContext();
        public string NameProperty { get; set; }
        public string DescriptionProperty { get; set; }
        private string _messageProperty { get; set; }

        public string MessageProperty
        {
            get => _messageProperty;
            set
            {
                _messageProperty = value;
                OnPropertyChanged();
            }
        }
        private string _messagePropertyColor { get; set; } = "Black";

        public string MessagePropertyColor
        {
            get => _messagePropertyColor;
            set
            {
                _messagePropertyColor = value;
                OnPropertyChanged();
            }
        }
        public ICommand CreateAuthorCommand { get; set; }
        public CreateAuthorViewModel()
        {
            CreateAuthorCommand = new RelayCommand(CreateAuthor);
        }
        void CreateAuthor(object e)
        {
            try
            {
                ValidateProperties();
                _context.Authors.Add(new Author()
            {
                Name = NameProperty,
                Description = DescriptionProperty
            });
            _context.SaveChanges();
                MessagePropertyColor = "Green";
                MessageProperty = "Auteur is toegevoegd";
                
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
                MessagePropertyColor = "Red";
                Debug.WriteLine(MessagePropertyColor);
                MessageProperty = exception.Message;
            }
        }

        private void ValidateProperties()
        {
            
            if (NameProperty == null)
            {
                throw new Exception("Naam veld is niet ingevuld!");
            }

            if (DescriptionProperty == null)
            {
                throw new Exception("Beschrijving veld niet ingevuld!");
            }
        }
    }
}