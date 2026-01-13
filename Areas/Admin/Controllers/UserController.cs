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

            var users = _context.Users.ToList();
            return View(users);
        }

        public IActionResult Upsert(ApplicationUser user)
        {
                    

            return View(user);
        }
    }
}
