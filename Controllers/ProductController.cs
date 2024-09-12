using ITIFinalProject.DBContext;
using ITIFinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ITIFinalProject.Controllers
{
    public class ProductController : Controller
    {

        /*----------------------------------------------------*/
        MyContext db = new MyContext();
        /*----------------------------------------------------*/

        // Index - List Of ALll Products

        [HttpGet]
        public IActionResult Index()
        {
            var allProducts = db.Product.Include(p => p.Category);
            return View(allProducts);      // View Model
        }
        /*----------------------------------------------------*/
        // ViewDetails
        [HttpGet]
        public IActionResult ViewDetails(int id)
        {
            var allProducts = db.Product.Include(p => p.Category).FirstOrDefault(p => p.CategoryId == id);
            if (allProducts == null)
            {
                return RedirectToAction("Index");

            }
            return View(allProducts);
        }
        /*----------------------------------------------------*/
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag._Categories = new SelectList(db.Category, "CategoryId", "Name");
            return View();
        }

        /*----------------------------------------------------*/
        [HttpPost]
        public IActionResult Create(Product product)
        {
            ModelState.Remove("Category");
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "All Fields Required");
                ViewBag._Categories = new SelectList(db.Category, "CategoryId", "Name");
                return View();
            }
            db.Product.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        /*---------------------------------------------------------*/
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var allProducts = db.Product.Include(p => p.Category).FirstOrDefault(p => p.CategoryId == id);
            if (allProducts == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag._Categories = new SelectList(db.Category, "CategoryId", "Name");
            return View(allProducts);
        }
        /*---------------------------------------------------------*/
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            ModelState.Remove("Category");
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "All Fields Required");
                ViewBag._Categories = new SelectList(db.Category, "CategoryId", "Name");
                return View();
            }
            db.Product.Update(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /*---------------------------------------------------------*/
        public IActionResult Delete(int id)
        {
            var allProducts = db.Product.Find(id);
            if (allProducts == null)
            {
                return RedirectToAction("Index");
            }
            db.Product.Remove(allProducts);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        /*---------------------------------------------------------*/



    }
}
