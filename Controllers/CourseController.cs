using E_LEARNING_SE_102_PROJECT.Data;
using E_LEARNING_SE_102_PROJECT.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_LEARNING_SE_102_PROJECT.Controllers
{
    public class CourseController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CourseController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var list = _context.Courses.ToList();

            return View(list);
        }

        public IActionResult Upsert()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Upsert")]
        public IActionResult CreateAndUpdate(Courses course)
        {
            if (!ModelState.IsValid)
            {
                return View(course);
            }
            course.CourseId = $"COURSE-{Guid.NewGuid().ToString().Substring(0, 6).ToUpper()}";
            course.CreatedAt = DateTime.Now;
            _context.Courses.Add(course);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

    }
}
