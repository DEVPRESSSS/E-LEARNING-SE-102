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

        public IActionResult Upsert(string? id)
        {
            if(id == null)
            {
                return View();
            }
            
            //var courses = new Courses();
            var obj = _context.Courses.FirstOrDefault(x=>x.CourseId == id);
            if(obj == null)
            {
               return NotFound();
            }
            
            return View(obj);
        }

        [HttpPost]
        [ActionName("Upsert")]
        public IActionResult CreateAndUpdate(Courses course)
        {
            if (!ModelState.IsValid)
            {
                return View(course);
            }
            if(course.CourseId == null)
            {
                course.CourseId = $"COURSE-{Guid.NewGuid().ToString().Substring(0, 6).ToUpper()}";
                course.CreatedAt = DateTime.Now;
                _context.Courses.Add(course);
            }
            else
            {
                var obj = _context.Courses.FirstOrDefault(x=>x.CourseId== course.CourseId);
                if (obj == null) { 
                    return NotFound();
                }
                obj.Title = course.Title;
                _context.Update(obj);

            }
         
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        //[HttpDelete]
        public IActionResult Delete(string? id)
        {

            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            //Find the ID
            var obj = _context.Courses.FirstOrDefault(x => x.CourseId == id);

            if (obj == null)
            {
                return BadRequest("No  courses id found");

            }
            if (ModelState.IsValid)
            {
                _context.Courses.Remove(obj);
            }
            _context.SaveChanges();
            return RedirectToAction($"Index");

        }


    }
}
