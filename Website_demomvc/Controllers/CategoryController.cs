using Microsoft.AspNetCore.Mvc;
using Website_demomvc.DTO;

namespace Website_demomvc.Controllers
{
    public class CategoryController : Controller
    {
        private readonly Website_demomvcDbContext _context;
        public CategoryController(Website_demomvcDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult GetData()
        {
            List<Category> listCategory = new List<Category>();
            listCategory = _context.Categories.ToList();
            return Json(new { data = listCategory, TotalItems = listCategory.Count });
        }
    }
}
