using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WasteNotBE.Data;
using WasteNotBE.Models;
using WasteNotBE.Models.HomeViewModels;

namespace WasteNotBE.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Retrieve first 12 Items
        public IActionResult Index()
        {
            List<Item> Items = _context.Items
                .OrderByDescending(i => i.DateCreated) 
                .Take(12) 
                .ToList(); 

            HomeIndexViewModel ViewModel = new HomeIndexViewModel(); 
            ViewModel.ItemList = Items; 

            return View(ViewModel); 
        }


        public IActionResult Privacy()
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
