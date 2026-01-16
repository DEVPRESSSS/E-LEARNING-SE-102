using E_LEARNING_SE_102_PROJECT.Data;
using E_LEARNING_SE_102_PROJECT.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_LEARNING_SE_102_PROJECT.Areas.Learner.Controllers
{
    [Area(SD.Learner)]
    public class LessonController : Controller
    {
        private readonly ApplicationDbContext _context;
        public LessonController( ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult ViewLesson(string id)
        {
            if(id == null)
            {
                ModelState.AddModelError("", "No content id found");
                return View();
            }

            var obj = _context.Contents
                     .Include(x=>x.Lesson)
                    .FirstOrDefault(x=>x.ContentId == id);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
    }
}
