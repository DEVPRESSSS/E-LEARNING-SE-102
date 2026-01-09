using E_LEARNING_SE_102_PROJECT.Data;
using E_LEARNING_SE_102_PROJECT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace E_LEARNING_SE_102_PROJECT.Areas.Learner.Controllers
{
    [Area("Learner")]
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
            ViewBag.Courses = courses;
            return View(courses);
        }

        public IActionResult Login()
        {


            return View();
        }

        public IActionResult Lesson(string? courseId, string? lessonId)
        {
            List<Lesson> lessons;

            if (!string.IsNullOrEmpty(courseId))
            {
                lessons = _context.Lessons
                    .Include(l => l.Courses)
                    .Include(l => l.Contents)
                    .Where(l => l.CourseId == courseId)
                    .ToList();
            }
            else if (!string.IsNullOrEmpty(lessonId))
            {
                // If only lessonId is passed, find its course
                var lesson = _context.Lessons
                    .Include(l => l.Courses)
                    .Include(l => l.Contents)
                    .FirstOrDefault(l => l.LessonId == lessonId);

                if (lesson == null) return NotFound();

                courseId = lesson.CourseId;
                lessons = _context.Lessons
                    .Include(l => l.Courses)
                    .Include(l => l.Contents)
                    .Where(l => l.CourseId == courseId)
                    .ToList();
            }
            else
            {
                // No courseId or lessonId passed → pick first course automatically
                var firstLesson = _context.Lessons
                    .Include(l => l.Courses)
                    .Include(l => l.Contents)
                    .FirstOrDefault();

                if (firstLesson == null)
                    return NotFound("No lessons found.");

                courseId = firstLesson.CourseId;
                lessons = _context.Lessons
                    .Include(l => l.Courses)
                    .Include(l => l.Contents)
                    .Where(l => l.CourseId == courseId)
                    .ToList();
                lessonId = firstLesson.LessonId;
            }

            if (!lessons.Any())
                return View();

            // Determine selected lesson
            Lesson selectedLesson = lessons.FirstOrDefault(l => l.LessonId == lessonId) ?? lessons.First();

            ViewData["SelectedLesson"] = selectedLesson;

            return View(lessons);
        }

        public IActionResult Details(string? id)
        {

            var contentOfLesson = _context.Contents.
                 Include(x => x.Lesson)
                            .ThenInclude(c => c.Courses)
                .FirstOrDefault(x => x.LessonId == id);
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
