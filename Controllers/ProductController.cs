using Microsoft.AspNetCore.Mvc;
using IP_AmazonFreshIndia_Project.Models;
using Microsoft.AspNetCore.Hosting;
using System.Linq;
using System.IO;
using Microsoft.AspNetCore.Http;


namespace IP_AmazonFreshIndia_Project.Controllers
{
    public class ProductController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        private IP_AmazonFreshIndia_ProjectUnitOfWork data { get; set; }
        public ProductController(IP_AmazonFreshIndia_ProjectContext ctx, IWebHostEnvironment hostingEnvironment)
        {
            data = new IP_AmazonFreshIndia_ProjectUnitOfWork(ctx);
            _hostingEnvironment = hostingEnvironment;
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


        [HttpGet]
        public ViewResult Add(int id) => GetProduct(id, "Add");

        private ViewResult GetProduct(int id, string operation)
        {
            var product = new ProductViewModel();
            Load(product, operation, id);
            return View("Product", product);
        }
        private void Load(ProductViewModel vm, string op, int? id = null)
        {
            if (Operation.IsAdd(op))
            {
                vm.Product = new Product();
            }
            else
            {
                vm.Product = data.Products.Get(new QueryOptions<Product>
                {
                    Include = "ProductCategories.Category, Warehouse",
                    Where = b => b.ProductId == (id ?? vm.Product.ProductId)
                });

                // Check if ProductImage filename exists in the database model
                if (!string.IsNullOrEmpty(vm.Product.ProductImage))
                {
                    // // Construct the full path to the image file
                    // string imageProduct = Path.Combine(_hostingEnvironment.WebRootPath, "images", "product", vm.Product.ProductImage);
                    // if (File.Exists(imageProduct))
                    // {
                    //     using (FileStream fileStream = new FileStream(imageProduct, FileMode.Open, FileAccess.Read))
                    //     {
                    //         // Create a new instance of IFormFile and assign it to the view model's ProductImage property
                    //         vm.ProductImage = new FormFile(fileStream, 0, fileStream.Length, null, Path.GetFileName(imageProduct));
                    //     }
                    // }


                    string imageProduct = _hostingEnvironment.WebRootPath + vm.Product.ProductImage;
                    if (System.IO.File.Exists(imageProduct))
                    {
                        // Open the image file as a FileStream
                        using (FileStream fileStream = new FileStream(imageProduct, FileMode.Open, FileAccess.Read))
                        {
                            // Create a MemoryStream to store the file contents
                            using (MemoryStream memoryStream = new MemoryStream())
                            {
                                // Copy the file contents from FileStream to MemoryStream
                                fileStream.CopyTo(memoryStream);

                                // Set the position of the MemoryStream to the beginning
                                memoryStream.Position = 0;

                                // Create a new FormFile instance from the MemoryStream
                                vm.ProductImage = new FormFile(memoryStream, 0, memoryStream.Length, null, Path.GetFileName(imageProduct));
                            }
                        }
                    }
                }
            }

            vm.SelectedCategories = vm.Product.ProductCategories?.Select(
                ba => ba.Category.CategoryId).ToArray();
            vm.Categories = data.Categories.List(new QueryOptions<Category>
            {
                OrderBy = a => a.Name
            });
            vm.Warehouses = data.Warehouses.List(new QueryOptions<Warehouse>
            {
                OrderBy = g => g.Name
            });
        }

        [HttpGet]
        public ViewResult Edit(int id) => GetProduct(id, "Edit");

        [HttpPost]
        public IActionResult Edit(ProductViewModel vm)
        {
            if (ModelState.IsValid)
            {
                data.DeleteCurrentProductCategories(vm.Product);
                vm.SelectedCategories = new int[] { vm.CategoryId != 0 ? vm.CategoryId : 1 };
                data.LoadNewProductCategories(vm.Product, vm.SelectedCategories);
                data.Products.Update(vm.Product);
                data.Save();

                TempData["message"] = $"{vm.Product.Name} updated.";
                return RedirectToAction("List");
            }
            else
            {
                Load(vm, "Edit");
                return View("Product", vm);
            }
        }

        [HttpGet]
        public ViewResult Delete(int id) => GetProduct(id, "Delete");

        [HttpPost]
        public IActionResult Delete(ProductViewModel vm)
        {
            data.Products.Delete(vm.Product);
            data.Save();
            TempData["message"] = $"{vm.Product.Name} removed from Products.";
            return RedirectToAction("List");
        }
    }
}