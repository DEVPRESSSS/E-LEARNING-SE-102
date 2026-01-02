using E_LEARNING_SE_102_PROJECT.Data;
using E_LEARNING_SE_102_PROJECT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace E_LEARNING_SE_102_PROJECT.Controllers
{
    public class LessonController : Controller
    {
        private readonly ApplicationDbContext _context;
        public LessonController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var lessonList = _context.Lessons.
                        Include(x=>x.Courses).ToList();

            return View(lessonList);
        }

        public IActionResult Upsert(string? id)
        {

            ViewBag.CoursesList = _context.Courses.Select(x => new SelectListItem
            {

                Value = x.CourseId,
                Text = x.Title

            }).ToList();

            if (id == null)
            {

                return View();
            }

            //var courses = new Courses();
            var obj = _context.Lessons.FirstOrDefault(x => x.LessonId == id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ActionName("Upsert")]
        public IActionResult CreateAndUpdate(Lesson lesson)
        {
            ViewBag.CoursesList = _context.Courses.Select(x => new SelectListItem
            {

                Value = x.CourseId,
                Text = x.Title

            }).ToList();

            if (ModelState.IsValid)
            {
                if (lesson.LessonId == null)
                {
                    lesson.LessonId = $"LESSON-{Guid.NewGuid().ToString().Substring(0, 6).ToUpper()}";
                    _context.Lessons.Add(lesson);
                }
                else
                {
                    var obj = _context.Lessons.FirstOrDefault(x => x.LessonId == lesson.LessonId);
                    if (obj == null)
                    {
                        return NotFound();
                    }
                    obj.Title = lesson.Title;
                    obj.Description = lesson.Description;
                    obj.CourseId = lesson.CourseId;

                    _context.Update(obj);

                }

                _context.SaveChanges();
                return RedirectToAction("Index");
            }
           
            return View(lesson);
        }

        //[HttpDelete]
        public IActionResult Delete(string? id)
        {

            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            //Find the ID
            var obj = _context.Lessons.FirstOrDefault(x => x.CourseId == id);

            if (obj == null)
            {
                return BadRequest("No lesson id found");

            }
            if (ModelState.IsValid)
            {
                _context.Lessons.Remove(obj);
            }
            _context.SaveChanges();
            return RedirectToAction($"Index");

        }

        //Get list of Courses
        public IActionResult GetCourses()
        {
           

            return View();
        }
    }
}
