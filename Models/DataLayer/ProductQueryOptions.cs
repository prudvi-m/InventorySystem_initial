using System.Linq;

namespace InventorySystem.Models
{
    public class ProductQueryOptions : QueryOptions<Product>
    {
        public void SortFilter(ProductsGridBuilder builder)
        {
            if (builder.IsFilterByWarehouse) {
                Where = b => b.WarehouseId == builder.CurrentRoute.WarehouseFilter;
            }
            if (builder.IsFilterByPrice) {
                if (builder.CurrentRoute.PriceFilter == "under7")
                    Where = b => b.Price < 7;
                else if (builder.CurrentRoute.PriceFilter == "7to14")
                    Where = b => b.Price >= 7 && b.Price <= 14;
                else
                    Where = b => b.Price > 14;
            }

            if (builder.IsFilterByCategory) {
                Where = b => b.CategoryId == builder.CurrentRoute.CategoryFilter;
            }

            if (builder.IsSortByWarehouse) {
                OrderBy = b => b.Warehouse.Name;
            }
            else if (builder.IsSortByCategory) {
                OrderBy = b => b.Warehouse.Name;
            }
            else if (builder.IsSortByPrice) {
                OrderBy = b => b.Price;
            }
            else  {
                OrderBy = b => b.Name;
            }
        }
    }
}
