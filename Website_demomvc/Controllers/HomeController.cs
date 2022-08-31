using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Website_demomvc.DTO;
using Website_demomvc.Models;

namespace Website_demomvc.Controllers
{
    //[Microsoft.AspNetCore.Authorization.Authorize]
    public class HomeController : Controller
    {

        private readonly Website_demomvcDbContext _context;

        public HomeController(Website_demomvcDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        //public JsonResult LoadData()
        //{
        //    List<Product> listProduct = new List<Product>();
        //    return Json( new {data = listProduct});
        //}

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