using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TerrificTrioCakes.Controllers
{
    public class AboutUs : Controller
    {
        // GET: AboutUs
        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}
