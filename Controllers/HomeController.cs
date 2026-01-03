using E_LEARNING_SE_102_PROJECT.Data;
using E_LEARNING_SE_102_PROJECT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace E_LEARNING_SE_102_PROJECT.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context; 
        }

        public IActionResult Index()
        {
            var courses = _context.Courses
                .ToList();

            return View(courses);
        }

        public IActionResult Login()
        {


            return View();
        }

        public IActionResult Lesson(string? id)
        {

            var listOfContents = _context.Lessons.
                 Include(x => x.Courses)
                .Where(x=> x.CourseId ==  id).ToList();
            if (listOfContents == null)
                return NotFound();
            


            return View(listOfContents);
        }

        public IActionResult Details(string? id)
        {

            var contentOfLesson = _context.Contents.
                 Include(x => x.Lesson)
                            .ThenInclude(c => c.Courses)
                .FirstOrDefault(x=> x.LessonId ==  id);
            if (contentOfLesson == null)
                return NotFound();
            


            return View(contentOfLesson);
        }

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
