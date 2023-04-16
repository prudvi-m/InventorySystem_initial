using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InventorySystem.Models
{
    public partial class Product
    {
        public int BookId { get; set; }

        [Required(ErrorMessage = "Please enter a title.")]
        [StringLength(200)]
        public string Title { get; set; }

        [Range(0.0, 1000000.0, ErrorMessage = "Price must be more than 0.")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Please select a warehouse.")]
        public string GenreId { get; set; }

        public Warehouse Warehouse { get; set; }
        public ICollection<BookAuthor> BookCategories { get; set; }
    }
}
