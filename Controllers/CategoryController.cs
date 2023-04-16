using Microsoft.AspNetCore.Mvc;
using InventorySystem.Models;

namespace InventorySystem.Controllers
{
    public class CategoryController : Controller
    {
        private Repository<Category> data { get; set; }
        public CategoryController(InventorySystemContext ctx) => data = new Repository<Category>(ctx);

        public IActionResult Index() => RedirectToAction("List");

        // [HttpGet]
        public ViewResult List(GridDTO vals)
        {
            string defaultSort = nameof(Category.FirstName);
            var builder = new GridBuilder(HttpContext.Session, vals, defaultSort);
            builder.SaveRouteSegments();

            var options = new QueryOptions<Category> {
                Include = "ProductCategories.Product",
                PageNumber = builder.CurrentRoute.PageNumber,
                PageSize = builder.CurrentRoute.PageSize,
                OrderByDirection = builder.CurrentRoute.SortDirection
            };
            if (builder.CurrentRoute.SortField.EqualsNoCase(defaultSort))
                options.OrderBy = a => a.FirstName;
            else
                options.OrderBy = a => a.LastName;

            var vm = new AuthorListViewModel {
                Categories = data.List(options),
                CurrentRoute = builder.CurrentRoute,
                TotalPages = builder.GetTotalPages(data.Count)
            };

            return View(vm);
        }

        public IActionResult Details(int id)
        {
            var category = data.Get(new QueryOptions<Category> {
                Include = "ProductCategories.Product",
                Where = a => a.CategoryId == id
            });
            return View(category);
        }
    }
}