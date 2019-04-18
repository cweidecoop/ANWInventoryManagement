using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ANWInventoryManagement.Models;
using ANWInventoryManagement.Data;

namespace ANWInventoryManagement.Controllers
{
    public class HomeController : Controller
    {
        private InventoryManagementDbContext _context;

        public HomeController(InventoryManagementDbContext dbContext)
        {
            _context = dbContext;
        }

        public IActionResult Index()
        {
            return Redirect("/Inventory");
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
