using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TerrificTrioCakes.Models;
using TerrificTrioCakes.Models.DB;

namespace TerrificTrioCakes.Controllers
{
    public class HomeController : Controller
    {

        private readonly CakeShopContext _context;

        public HomeController(CakeShopContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var cakeShopContext = _context.Cakes.Where(ck=>ck.IsFeatured == true).Include(c => c.Categories);

            return View(await cakeShopContext.ToListAsync());
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