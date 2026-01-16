using E_LEARNING_SE_102_PROJECT.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace E_LEARNING_SE_102_PROJECT.Areas.Learner.Controllers
{
    [Area(SD.Learner)]
    public class LessonController : Controller
    {
        public IActionResult ViewLesson()
        {
            return View();
        }
    }
}
