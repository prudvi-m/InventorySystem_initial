using Microsoft.AspNetCore.Mvc;
using IP_AmazonFreshIndia_Project.Models;
using Microsoft.AspNetCore.Hosting;
using System.Linq;
using System.IO;
using Microsoft.AspNetCore.Http;
using System;


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

        [HttpPost]
        public IActionResult Add(ProductViewModel vm)
        {
            if (ModelState.IsValid)
            {

                if (vm.ProductImage != null && vm.ProductImage.Length > 0)
                {

                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(vm.ProductImage.FileName);

                    var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "images/products", uniqueFileName);


                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        vm.ProductImage.CopyTo(stream);
                    }


                    vm.Product.ProductImage = Path.Combine("/images/products", uniqueFileName);
                }
                vm.SelectedCategories = new int[] { vm.CategoryId != 0 ? vm.CategoryId : 1 };
                data.LoadNewProductCategories(vm.Product, vm.SelectedCategories);
                data.Products.Insert(vm.Product);
                data.Save();

                TempData["message"] = $"{vm.Product.Name} added to Products.";
                return RedirectToAction("Index");
            }
            else
            {
                Load(vm, "Add");
                return View("Product", vm);
            }
        }


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
                        vm.Filename = vm.ProductImage.FileName;
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

        // public string getExistingFileName(int productId) => data.Products.Get(productId)?.ProductImage ?? "";

        [HttpPost]
        public IActionResult Edit(ProductViewModel vm,IFormFile updatedImage, string existingFile)
        {
            if (ModelState.IsValid)
            {
                if(updatedImage != null && updatedImage.Length > 0) {

                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(updatedImage.FileName);

                    var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "images/products", uniqueFileName);


                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        updatedImage.CopyTo(stream);
                    }
                    vm.Product.ProductImage = Path.Combine("/images/products", uniqueFileName);

                }
                else {
                    vm.Product.ProductImage = Path.Combine("/images/products", existingFile);
                }
                
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