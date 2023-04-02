using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventorySystem.Models;

namespace InventorySystem.Controllers
{
    public class HomeController : Controller
    {
        private InventoryContext context;
        public HomeController(InventoryContext ctx) => context = ctx;

        public IActionResult Index(string id)
        {
            // load current filters and data needed for filter drop downs in ViewBag
            var filters = new Filters(id);
            ViewBag.Filters = filters;
            ViewBag.Categories = context.Categories.ToList();
            ViewBag.Warehouses = context.Warehouses.ToList();
            

            // get Product objects from database based on current filters
            IQueryable<Product> query = context.Products
                .Include(t => t.Category).Include(t => t.Warehouse);
            if (filters.HasCategory) {
                query = query.Where(t => t.CategoryId == filters.CategoryId);
            }
            if (filters.HasWarehouse) {
                query = query.Where(t => t.WarehouseId == filters.WarehouseId);
            }
            
            // var Products = query.OrderBy(t => t.WarehouseDate).ToList();
            return View(query);
        }

        public IActionResult Add()
        {
            ViewBag.Categories = context.Categories.ToList();
            ViewBag.Warehouses = context.Warehouses.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product Product)
        {
            if (ModelState.IsValid)
            {
                context.Products.Add(Product);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Categories = context.Categories.ToList();
                ViewBag.Warehouses = context.Warehouses.ToList();
                return View(Product);
            }
        }

        [HttpPost]
        public IActionResult Filter(string[] filter)
        {
            string id = string.Join('-', filter);
            return RedirectToAction("Index", new { ID = id });
        }

        [HttpPost]
        public IActionResult Edit([FromRoute]string id, Product selected)
        {
            if (selected.WarehouseId == null) {
                context.Products.Remove(selected);
            }
            else {
                string newWarehouseId = selected.WarehouseId;
                selected = context.Products.Find(selected.Id);
                selected.WarehouseId = newWarehouseId;
                context.Products.Update(selected);
            }
            context.SaveChanges();
            return RedirectToAction("Index", new { ID = id });
        }

        [HttpGet]
        public IActionResult Delete(int id) {
            var product = context.Products.Find(id);
            context.Products.Remove(product);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Categories = context.Categories.OrderBy(g => g.Name).ToList();
            ViewBag.Warehouses = context.Warehouses.OrderBy(g => g.Name).ToList();
            var product = context.Products.Find(id);
            ViewBag.Header = product.Name;
            return View(product);
        }


        [HttpPost]
        public IActionResult Update(Product Product)
        {
            if (ModelState.IsValid)
            {
                context.Products.Update(Product);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Categories = context.Categories.ToList();
                ViewBag.Warehouses = context.Warehouses.ToList();
                return View(Product);
            }
        }

    }
}