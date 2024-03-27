using Microsoft.AspNetCore.Mvc;
using IP_AmazonFreshIndia_Project.Models;
using Microsoft.AspNetCore.Http;


namespace IP_AmazonFreshIndia_Project.Controllers
{
    public class ProductController : Controller
    {
        

        private IP_AmazonFreshIndia_ProjectUnitOfWork data { get; set; }
        public ProductController(IP_AmazonFreshIndia_ProjectContext ctx)
        {
            data = new IP_AmazonFreshIndia_ProjectUnitOfWork(ctx);
        }


        public RedirectToActionResult Index() => RedirectToAction("List");

        public ViewResult List(ProductsGridDTO values)
        {
            var builder = new ProductsGridBuilder(HttpContext.Session, values,
                defaultSortField: nameof(Product.Name));

            var options = new ProductQueryOptions
            {
                Include = "ProductCategories.Category, Warehouse",
                OrderByDirection = builder.CurrentRoute.SortDirection,
                PageNumber = builder.CurrentRoute.PageNumber,
                PageSize = builder.CurrentRoute.PageSize
            };
            options.SortFilter(builder);

            var vm = new ProductListViewModel
            {
                Products = data.Products.List(options),
                Categories = data.Categories.List(new QueryOptions<Category>
                {
                    OrderBy = a => a.Name
                }),
                Warehouses = data.Warehouses.List(new QueryOptions<Warehouse>
                {
                    OrderBy = g => g.Name
                }),
                CurrentRoute = builder.CurrentRoute,
                TotalPages = builder.GetTotalPages(data.Products.Count)
            };

            return View(vm);
        }

        public ViewResult Details(int id)
        {
            var product = data.Products.Get(new QueryOptions<Product>
            {
                Include = "ProductCategories.Category, Warehouse",
                Where = b => b.ProductId == id
            });
            return View(product);
        }



        [HttpPost]
        public RedirectToActionResult Filter(string[] filter, bool clear = false)
        {
            var builder = new ProductsGridBuilder(HttpContext.Session);

            if (clear)
            {
                builder.ClearFilterSegments();
            }
            else
            {
                var category = data.Categories.Get(filter[0].ToInt());
                builder.LoadFilterSegments(filter, category);
            }

            builder.SaveRouteSegments();
            return RedirectToAction("List", builder.CurrentRoute);
        }

    }
    
}