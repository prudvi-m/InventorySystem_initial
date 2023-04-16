using System;
using Microsoft.AspNetCore.Mvc;
using InventorySystem.Models;

namespace InventorySystem.Controllers
{
    public class HomeController : Controller
    {
        private Repository<Product> data { get; set; }
        public HomeController(InventorySystemContext ctx) => data = new Repository<Product>(ctx);

        public ViewResult Index()
        {
            // get a product at random - updated for SQLite
            Product random = null;
            while (random == null)
            {
                int bookID = new Random().Next(1, data.Count + 1);
                random = data.Get(bookID);
            }

            return View(random);
        }
    }
}