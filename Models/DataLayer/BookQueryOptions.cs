using System.Linq;

namespace InventorySystem.Models
{
    public class BookQueryOptions : QueryOptions<Product>
    {
        public void SortFilter(BooksGridBuilder builder)
        {
            if (builder.IsFilterByGenre) {
                Where = b => b.GenreId == builder.CurrentRoute.GenreFilter;
            }
            if (builder.IsFilterByPrice) {
                if (builder.CurrentRoute.PriceFilter == "under7")
                    Where = b => b.Price < 7;
                else if (builder.CurrentRoute.PriceFilter == "7to14")
                    Where = b => b.Price >= 7 && b.Price <= 14;
                else
                    Where = b => b.Price > 14;
            }
            if (builder.IsFilterByAuthor) {
                int id = builder.CurrentRoute.AuthorFilter.ToInt();
                if (id > 0)
                    Where = b => b.BookCategories.Any(ba => ba.Category.AuthorId == id);
            }

            if (builder.IsSortByGenre) {
                OrderBy = b => b.Warehouse.Name;
            }
            else if (builder.IsSortByPrice) {
                OrderBy = b => b.Price;
            }
            else  {
                OrderBy = b => b.Title;
            }
        }
    }
}
