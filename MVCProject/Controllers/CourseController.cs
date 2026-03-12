using Microsoft.AspNetCore.Mvc;
using MVCProject.ModelBL;
using MVCProject.Models;

namespace MVCProject.Controllers
{
    public class CourseController : Controller
    {

        private readonly CourseBl _coursebl;
        public CourseController(CourseBl courseBl)
        {
            _coursebl = courseBl;
        }

        public IActionResult GetAllCourse()
        {
            var courses = _coursebl.GetAll();
            if (courses == null || courses.Count == 0)
            {
                return NotFound("No courses found");
            }
            return View("allcoursesview", courses);
        }

        public IActionResult GetCourseById(int id)
        {
         var course = _coursebl.GetById(id);
            if (course == null)
            {
                return NotFound($"Course with ID {id} not found");
            }
            return View("coursebyidview", course);

        }

    }
}
