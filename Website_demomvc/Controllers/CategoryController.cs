using Microsoft.AspNetCore.Mvc;
using Website_demomvc.DTO;
using Website_demomvc.Models.Category;

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


        //PartialView List Category
        [HttpGet]
        public IActionResult ListCategory()
        {
            var list = _context.Categories.ToList();
            return PartialView("ListCategory", list);
        }


        [HttpGet]
        public IActionResult GetData(string searchName)
        {
            List<Category> results = null;
            if (!string.IsNullOrEmpty(searchName))
            {
                results = _context.Categories.Where(x => x.CatName.ToLower().Contains(searchName.Trim().ToLower())).ToList();
            }
            else
            {
                results = _context.Categories.ToList();
            }
            return Json(new
            {
                Data = results,
            });
        }

        [HttpPost]
        public JsonResult AddCategory(string name, string des)
        {
            try
            {
                var category = new Category();
                category.CatName = name;
                category.CatDescribe = des;
                category.CreatedDate = DateTime.Now;

                _context.Categories.Add(category);
                _context.SaveChanges();

                return Json(new { code = 200, msg ="Thêm mới thành công"});
            }
            catch(Exception ex)
            {
                return Json(new { code = 500, msg = "Thêm mới thất bại" });
            }
        }
    }
}
