using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using IP_AmazonFreshIndia_Project.Models;
using Microsoft.AspNetCore.Http;



namespace IP_AmazonFreshIndia_Project.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IP_AmazonFreshIndia_ProjectUnitOfWork data;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ProductController(IP_AmazonFreshIndia_ProjectContext ctx, IWebHostEnvironment env)
        {
            data = new IP_AmazonFreshIndia_ProjectUnitOfWork(ctx);
            webHostEnvironment = env;
        }

        public ViewResult Index()
        {
            var search = new SearchData(TempData);
            search.Clear();

            return View();
        }

        [HttpPost]
        public RedirectToActionResult Search(SearchViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var search = new SearchData(TempData)
                {
                    SearchTerm = vm.SearchTerm,
                    Type = vm.Type
                };
                return RedirectToAction("Search");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ViewResult Search()
        {
            var search = new SearchData(TempData);

            if (search.HasSearchTerm)
            {
                var vm = new SearchViewModel
                {
                    SearchTerm = search.SearchTerm
                };

                var options = new QueryOptions<Product>
                {
                    Include = "Warehouse, ProductCategories.Category"
                };
                if (search.IsProduct)
                {
                    options.Where = b => b.Name.Contains(vm.SearchTerm);
                    vm.Header = $"Search results for product title '{vm.SearchTerm}'";
                }
                if (search.IsCategory)
                {
                    int index = vm.SearchTerm.LastIndexOf(' ');
                    if (index == -1)
                    {
                        options.Where = b => b.ProductCategories.Any(
                            ba => ba.Category.Name.Contains(vm.SearchTerm) ||
                            ba.Category.Name.Contains(vm.SearchTerm));
                    }
                    else
                    {
                        string first = vm.SearchTerm.Substring(0, index);
                        string last = vm.SearchTerm.Substring(index + 1);
                        options.Where = b => b.ProductCategories.Any(
                            ba => ba.Category.Name.Contains(first) &&
                            ba.Category.Name.Contains(last));
                    }
                    vm.Header = $"Search results for category '{vm.SearchTerm}'";
                }
                if (search.IsWarehouse)
                {
                    options.Where = b => b.WarehouseId.Contains(vm.SearchTerm);
                    vm.Header = $"Search results for warehouse ID '{vm.SearchTerm}'";
                }
                vm.Products = data.Products.List(options);
                return View("SearchResults", vm);
            }
            else
            {
                return View("Index");
            }
        }

        [HttpGet]
        public ViewResult Add(int id) => GetProduct(id, "Add");

        [HttpPost]
        public IActionResult Add(ProductViewModel vm, IFormFile updatedImage)
        {
            if (ModelState.IsValid)
            {

                if (updatedImage != null && updatedImage.Length > 0)
                {

                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(updatedImage.FileName);

                    var filePath = Path.Combine(webHostEnvironment.WebRootPath, "images/products", uniqueFileName);


                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        updatedImage.CopyTo(stream);
                    }


                    vm.Product.ProductImage = Path.Combine("/images/products", uniqueFileName);
                }
                vm.SelectedCategories = new int[] { vm.CategoryId != 0 ? vm.CategoryId : 1 };
                data.LoadNewProductCategories(vm.Product, vm.SelectedCategories);
                data.Products.Insert(vm.Product);
                data.Save();

                TempData["message"] = $"{vm.Product.Name} added to Products.";
                return RedirectToAction("Search");
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

                    string imageProduct = webHostEnvironment.WebRootPath + vm.Product.ProductImage;
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

        [HttpPost]
        public IActionResult Edit(ProductViewModel vm,IFormFile updatedImage, string existingFile)
        {
            if (ModelState.IsValid)
            {
                if(updatedImage != null && updatedImage.Length > 0) {

                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(updatedImage.FileName);

                    var filePath = Path.Combine(webHostEnvironment.WebRootPath, "images/products", uniqueFileName);


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
                return RedirectToAction("Search");
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
            return RedirectToAction("Search");
        }

   }
}