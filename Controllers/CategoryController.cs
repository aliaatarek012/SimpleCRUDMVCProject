using ITIFinalProject.DBContext;
using ITIFinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ITIFinalProject.Controllers
{
    public class CategoryController : Controller
    {

        /*----------------------------------------------------*/
        MyContext db = new MyContext();
        /*----------------------------------------------------*/
        // Index - List of All Categories
        [HttpGet]
        public IActionResult Index()
        {
            var _AllCategories = db.Category;

            return View(_AllCategories);            // => View Model
        }
        /*---------------------------------------------------------*/
        // View Details
        [HttpGet]
        public IActionResult ViewDetails(int id)
        {
            var _AllCategories = db.Category.Find(id);
            if (_AllCategories == null)
            {
                return RedirectToAction("Index");
            }
            return View(_AllCategories);
        }

        /*----------------------------------------------------*/
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag._Categories = new SelectList(db.Category, "CategoryId", "Name", "Description");
            return View();
        }

        /*----------------------------------------------------*/
        [HttpPost]
        public IActionResult Create(Category category)
        {
            ModelState.Remove("Category");
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "All Fields Required");
                ViewBag._Categories = new SelectList(db.Category, "CategoryId", "Name", "Description");
                return View();
            }
            db.Category.Add(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        /*---------------------------------------------------------*/
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var _AllCategories = db.Category.FirstOrDefault(C => C.CategoryId == id);
            if (_AllCategories == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag._Categories = new SelectList(db.Category, "CategoryId", "Name", "Description");
            return View(_AllCategories);
        }
        /*---------------------------------------------------------*/
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            ModelState.Remove("Category");
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "All Fields Required");
                ViewBag._Categories = new SelectList(db.Category, "CategoryId", "Name", "Description");
                return View();
            }
            db.Category.Update(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /*---------------------------------------------------------*/
        public IActionResult Delete(int id)
        {
            var _AllCategories = db.Category.FirstOrDefault(C => C.CategoryId == id);
            if (_AllCategories == null)
            {
                return RedirectToAction("Index");
            }
            db.Category.Remove(_AllCategories);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        /*---------------------------------------------------------*/


    }
}
