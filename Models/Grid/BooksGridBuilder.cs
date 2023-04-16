using Microsoft.AspNetCore.Http;

namespace InventorySystem.Models
{
    public class BooksGridBuilder : GridBuilder
    {
        public BooksGridBuilder(ISession sess) : base(sess) { }

        public BooksGridBuilder(ISession sess, BooksGridDTO values, 
            string defaultSortField) : base(sess, values, defaultSortField)
        {
            bool isInitial = values.Warehouse.IndexOf(FilterPrefix.Warehouse) == -1;
            routes.AuthorFilter = (isInitial) ? FilterPrefix.Category + values.Category : values.Category;
            routes.GenreFilter = (isInitial) ? FilterPrefix.Warehouse + values.Warehouse : values.Warehouse;
            routes.PriceFilter = (isInitial) ? FilterPrefix.Price + values.Price : values.Price;
        }

        public void LoadFilterSegments(string[] filter, Category author)
        {
            if (author == null) { 
                routes.AuthorFilter = FilterPrefix.Category + filter[0];
            } else {
                routes.AuthorFilter = FilterPrefix.Category + filter[0]
                    + "-" + author.FullName.Slug();
            }
            routes.GenreFilter = FilterPrefix.Warehouse + filter[1];
            routes.PriceFilter = FilterPrefix.Price + filter[2];
        }

        public void ClearFilterSegments() => routes.ClearFilters();

        string def = BooksGridDTO.DefaultFilter;   
        public bool IsFilterByAuthor => routes.AuthorFilter != def;
        public bool IsFilterByGenre => routes.GenreFilter != def;
        public bool IsFilterByPrice => routes.PriceFilter != def;

        public bool IsSortByGenre =>
            routes.SortField.EqualsNoCase(nameof(Warehouse));
        public bool IsSortByPrice =>
            routes.SortField.EqualsNoCase(nameof(Product.Price));
    }
}
