using Microsoft.AspNetCore.Mvc;
using InventorySystem.Models;

namespace InventorySystem.Controllers
{
    public class BookController : Controller
    {
        private InventorySystemUnitOfWork data { get; set; }
        public BookController(InventorySystemContext ctx) => data = new InventorySystemUnitOfWork(ctx);

        public RedirectToActionResult Index() => RedirectToAction("List");

        public ViewResult List(BooksGridDTO values)
        {
            var builder = new BooksGridBuilder(HttpContext.Session, values, 
                defaultSortField: nameof(Product.Title));

            var options = new BookQueryOptions {
                Include = "BookCategories.Category, Warehouse",
                OrderByDirection = builder.CurrentRoute.SortDirection,
                PageNumber = builder.CurrentRoute.PageNumber,
                PageSize = builder.CurrentRoute.PageSize
            };
            options.SortFilter(builder);

            var vm = new BookListViewModel {
                Products = data.Products.List(options),
                Categories = data.Categories.List(new QueryOptions<Category> {
                    OrderBy = a => a.FirstName }),
                Warehouses = data.Warehouses.List(new QueryOptions<Warehouse> {
                    OrderBy = g => g.Name }),
                CurrentRoute = builder.CurrentRoute,
                TotalPages = builder.GetTotalPages(data.Products.Count)
            };

            return View(vm);
        }

        public ViewResult Details(int id)
        {
            var product = data.Products.Get(new QueryOptions<Product> {
                Include = "BookCategories.Category, Warehouse",
                Where = b => b.BookId == id
            });
            return View(product);
        }

        [HttpPost]
        public RedirectToActionResult Filter(string[] filter, bool clear = false)
        {
            var builder = new BooksGridBuilder(HttpContext.Session);

            if (clear) {
                builder.ClearFilterSegments();
            }
            else {
                var author = data.Categories.Get(filter[0].ToInt());
                builder.LoadFilterSegments(filter, author);
            }

            builder.SaveRouteSegments();
            return RedirectToAction("List", builder.CurrentRoute);
        }
    }   
}