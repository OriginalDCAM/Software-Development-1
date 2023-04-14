using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using WpfApp.Helpers;
using WpfApp.Models;

namespace WpfApp.ViewModels
{
    public class CreateAuthorViewModel : ObservableObject, INotifyDataErrorInfo
    {
        private readonly DataContext _context = new();
        private string _nameProperty;

        public string NameProperty
        {
            get => _nameProperty;
            set
            {
                _nameProperty = value;
                OnPropertyChanged();
            }
        }

        private string _descriptionProperty;

        public string DescriptionProperty
        {
            get => _descriptionProperty;
            set
            {
                _descriptionProperty = value;
                OnPropertyChanged();
            }
        }

        private string _errorContent;

        public string ErrorContent
        {
            get => _errorContent;
            set
            {
                _errorContent = value;
                OnPropertyChanged();
            }
        }

        private string _successContent;

        public string SuccessContent
        {
            get => _successContent;
            set
            {
                _successContent = value;
                OnPropertyChanged();
            }
        }

        public ICommand CreateAuthorCommand { get; set; }

        public CreateAuthorViewModel()
        {
            CreateAuthorCommand = new RelayCommand(CreateAuthor);
        }

        // Deze roept eerst een method aan die properties valideert of ze aan de juiste regels houden
        private void CreateAuthor(object e)
        {
            ClearErrors(nameof(NameProperty));
            ValidateProperties();
            if (HasErrors) return;
            try
            {
                bool nameExists = _context.Authors.Any(a => a.Name == NameProperty);
                if (nameExists)
                {
                    throw new DbUpdateException("Er bestaat al een boek met dezelfde naam.");
                }
                _context.Authors.Add(new Author()
                {
                    Name = NameProperty,
                    Description = DescriptionProperty
                });
                _context.SaveChanges();
                SuccessContent = $"{NameProperty} successvol toegevoegd!";
               
            }
            catch (DbUpdateException exception)
            {
                Debug.Write("Works");
                AddError(nameof(NameProperty), $"{exception.Message}");
                ErrorContent = GetErrors(nameof(NameProperty))?.Cast<string>().FirstOrDefault() ?? "";
                SuccessContent = "";
                // Debug.WriteLine(exception);
            }

        }

        // Code voor valideren van properties 
        private readonly Dictionary<string, List<string>>
            _errorsByPropertyName = new();

        public bool HasErrors => _errorsByPropertyName.Any();

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            return _errorsByPropertyName.TryGetValue(propertyName, out var value) ? value : null;
        }

        private void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        private void ValidateProperties()
        {
            SuccessContent = "";
            ClearErrors(nameof(NameProperty));
            ClearErrors(nameof(DescriptionProperty));
            if (string.IsNullOrWhiteSpace(NameProperty))
                AddError(nameof(NameProperty), "Naam mag niet leeg zijn.");
            if (NameProperty == null || NameProperty?.Length <= 2)
                AddError(nameof(NameProperty), "Naam moet tenminsten 3 karaters bevatten!");
            if (NameProperty != null && NameProperty.Any(char.IsDigit))
                AddError(nameof(NameProperty), "Naam mag geen cijfers bevatten!");
            if (string.IsNullOrWhiteSpace(DescriptionProperty))
                AddError(nameof(DescriptionProperty), "Beschrijving mag niet leeg zijn");
            ErrorContent = GetErrors(nameof(NameProperty))?.Cast<string>().FirstOrDefault() ??
                           GetErrors(nameof(DescriptionProperty))?.Cast<string>().FirstOrDefault() ?? "";
        }

        private void AddError(string propertyName, string error)
        {
            if (!_errorsByPropertyName.ContainsKey(propertyName))
                _errorsByPropertyName[propertyName] = new List<string>();

            if (_errorsByPropertyName[propertyName].Contains(error)) return;
            _errorsByPropertyName[propertyName].Add(error);
            OnErrorsChanged(propertyName);
        }

        private void ClearErrors(string propertyName)
        {
            if (!_errorsByPropertyName.ContainsKey(propertyName)) return;
            _errorsByPropertyName.Remove(propertyName);
            OnErrorsChanged(propertyName);
        }
    }
}