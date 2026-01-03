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
            var contents = _context.Contents.
                        Include(x=>x.Lesson)
                            .ThenInclude(c=>c.Courses)
                        .ToList();


            return View(contents);
        }

        public IActionResult Login()
        {


            return View();
        }

        public IActionResult Details(string? id)
        {

            var detail = _context.Contents.
                 Include(x => x.Lesson)
                            .ThenInclude(c => c.Courses)
                .FirstOrDefault(x=> x.ContentId ==  id);
            if (detail == null)
                return NotFound();
            


            return View(detail);
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
