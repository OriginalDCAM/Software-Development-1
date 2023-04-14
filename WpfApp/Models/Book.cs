using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public BookType Genre { get; set; }
        public int AuthorId { get; set; } // Foreign key property
        public virtual Author Author { get; set; }
    }
}