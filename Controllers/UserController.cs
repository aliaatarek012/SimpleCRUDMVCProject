using ITIFinalProject.DBContext;
using ITIFinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ITIFinalProject.Controllers
{
    public class UserController : Controller
    {

        /*----------------------------------------------------*/
        MyContext db = new MyContext();


        /*----------------------------------------------------*/

        [HttpGet]
        public IActionResult Index()
        {
            var _Users = db.User;

            return View(_Users);            // => View Model
        }
        /*----------------------------------------------------*/

        [HttpGet]
        public IActionResult Register()
        {
            // This view will display the registration form
            ViewBag.Users = new SelectList(db.User, "UserId", "FirstName");
            return View();
        }

        /*----------------------------------------------------*/
        // Register - Handle the Form Submission
        [HttpPost]
        public IActionResult Register(User user)
        {

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "All Fields Are Required");
                ViewBag.Users = new SelectList(db.User, "UserId", "FirstName");
                return View(); 
            }

            db.User.Add(user);
            db.SaveChanges();  

            return RedirectToAction( "Login" , "User");
        }

        /*----------------------------------------------------*/
        [HttpGet]
        public IActionResult Login()
        {
            return View();  
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            
            // Check if the user exists in the database
            var _user = db.User.FirstOrDefault(u => u.Email == user.Email &&  u.Password == user.Password);

            if (_user == null || _user.Email != user.Email || _user.Password != user.Password)
            {
                ModelState.AddModelError("", "Invalid Email or password");
                return View();
            }
           
            return RedirectToAction("Index" , "Product"); 
        }




    }
}
