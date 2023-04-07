﻿using System.Collections.ObjectModel;

namespace WpfApp.Models
{
    public class Book 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public string Description {get; set; }
        public enum BookType 
        {
            Adventure,
            Classics,
            Crime,
            Fantasy,
            Horror,
            Humour,
            Mystery,
            Romance
        }
        public BookType Genre { get; set; }
        public int AuthorId { get; set; } // Foreign key property
        public virtual Author Author { get; set; }
    }
}