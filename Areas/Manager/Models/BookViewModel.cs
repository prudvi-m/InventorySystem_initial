using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InventorySystem.Models
{
    public class BookViewModel : IValidatableObject
    {
        public Product Product { get; set; }
        public IEnumerable<Warehouse> Warehouses { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public int[] SelectedCategories { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext ctx) {
            if (SelectedCategories == null)
            {
                yield return new ValidationResult(
                  "Please select at least one author.",
                  new[] { nameof(SelectedCategories) });
            }
        }

    }
}
