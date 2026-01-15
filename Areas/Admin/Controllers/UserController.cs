using E_LEARNING_SE_102_PROJECT.Data;
using E_LEARNING_SE_102_PROJECT.Models;
using E_LEARNING_SE_102_PROJECT.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace E_LEARNING_SE_102_PROJECT.Areas.Admin.Controllers
{
    [Area(SD.Admin)]
    public class UserController : Controller
    {

        private readonly ApplicationDbContext _context;
        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            var users = _context.AppUser.ToList();
            return View(users);
        }

        public IActionResult Upsert(string? id) 
        {
            if (id == null)
                return View();

            var obj = _context.AppUser
                .FirstOrDefault(x=>x.Id == id);
            if (obj == null)
                return NotFound();
        
            return View(obj);
        }
        [HttpPost]
        [ActionName("Upsert")]
        public IActionResult CreateAndUpdate(ApplicationUser user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            if(string.IsNullOrEmpty(user.Id))
            {
                user.EmailConfirmed = true;
                _context.AppUser.Add(user);
            }
            else
            {
                var obj = _context.AppUser.FirstOrDefault(x => x.Id == user.Id);
                if (obj == null) return NotFound();

                obj.FirstName = user.FirstName;
                obj.MiddleName = user.MiddleName;
                obj.LastName = user.LastName;
                obj.Email = user.Email;
                obj.PasswordHash = user.PasswordHash;

                _context.AppUser.Update(obj);
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
