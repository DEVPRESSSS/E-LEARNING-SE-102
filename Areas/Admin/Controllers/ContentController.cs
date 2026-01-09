using E_LEARNING_SE_102_PROJECT.Data;
using E_LEARNING_SE_102_PROJECT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace E_LEARNING_SE_102_PROJECT.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContentController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ContentController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var contents = _context.Contents.
                            Include(x => x.Lesson).
                            ToList();
            return View(contents);
        }

        public IActionResult Upsert(string? id)
        {

            ViewBag.LessonsList = _context.Lessons.Select(x => new SelectListItem
            {

                Value = x.LessonId,
                Text = x.Title

            }).ToList();

            if (id == null)
            {

                return View();
            }

            var obj = _context.Contents.FirstOrDefault(x => x.ContentId == id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ActionName("Upsert")]
        public IActionResult CreateAndUpdate(Contents content)
        {
            ViewBag.LessonsList = _context.Lessons.Select(x => new SelectListItem
            {
                Value = x.LessonId,
                Text = x.Title
            }).ToList();

            if (!ModelState.IsValid)
            {

                return View(content);
            }

            if (string.IsNullOrEmpty(content.ContentId))
            {
                content.ContentId = $"CNTNT-{Guid.NewGuid().ToString()[..6].ToUpper()}";
                content.UploadedAt = DateTime.Now;
                _context.Contents.Add(content);
            }
            else
            {
                var obj = _context.Contents.FirstOrDefault(x => x.ContentId == content.ContentId);
                if (obj == null) return NotFound();

                obj.Description = content.Description;
                obj.FilePath = content.FilePath;
                obj.FileType = content.FileType;
                obj.LessonId = content.LessonId;

            }

            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        //[HttpDelete]
        public IActionResult Delete(string? id)
        {

            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            //Find the ID
            var obj = _context.Contents.FirstOrDefault(x => x.ContentId == id);

            if (obj == null)
            {
                return BadRequest("No lesson id found");

            }
            if (ModelState.IsValid)
            {
                _context.Contents.Remove(obj);
            }
            _context.SaveChanges();
            return RedirectToAction($"Index");

        }
    }
}
