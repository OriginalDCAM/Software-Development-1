using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WpfApp.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
       public string Description { get; set; }

       public virtual ICollection<Book> Books 
       { get; private set; } = new ObservableCollection<Book>();
    }
}