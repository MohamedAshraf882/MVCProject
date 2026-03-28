using Microsoft.AspNetCore.Mvc;
using MVCProject.ModelBL;
using MVCProject.Models;
using MVCProject.ModelView;

namespace MVCProject.Controllers
{
    public class CourseController : Controller
    {

        private readonly CourseBl _coursebl;
        private readonly DepartmentBL _departmentbl;
        public CourseController(CourseBl courseBl, DepartmentBL departmentbl)
        {
            _coursebl = courseBl;
            _departmentbl = departmentbl;
        }

        [HttpGet]
        public IActionResult GetAllCourse()
        {
            var courses = _coursebl.GetAll();
            if (courses == null || courses.Count == 0)
            {
                return NotFound("No courses found");
            }
            return View("allcoursesview", courses);
        }
        [HttpGet]
        public IActionResult GetCourseById(int id)
        {
         var course = _coursebl.GetById(id);
            if (course == null)
            {
                return NotFound($"Course with ID {id} not found");
            }
            return View("coursebyidview", course);

        }

        [HttpGet]
        public IActionResult AddCourse()
        {
            var VM = new Course_Department_VM {
                Deptlist = _departmentbl.GetAllDepartments()
            };
            return View("AddCourse",VM);
        }
        [HttpPost]
        public IActionResult SaveAdd(Course_Department_VM vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Deptlist= _departmentbl.GetAllDepartments(); 
                return View("AddCourse",vm);
            }
            _coursebl.AddCourse(vm);
            return RedirectToAction("GetAllCourse");

        }
        [HttpGet]
        public IActionResult SearchByName(string name)
        {
            
            
           var result= _coursebl.Search(name);
            return View("allcoursesview", result);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
           var crsfromdb= _coursebl.GetById(id);
            var departments= _departmentbl.GetAllDepartments();
            var VM = new Course_Department_VM
            {
                Id = crsfromdb.Id,
                Name = crsfromdb.Name,
                Hours = crsfromdb.Hours,
                Degree = crsfromdb.Degree,
                MinDegree = crsfromdb.MinDegree,
                Dept_Id = crsfromdb.Id,
                Deptlist = departments
            };
            return View("Edit", VM);
        }
        [HttpPost]
        public IActionResult SaveEdit(Course_Department_VM VM)
        {
            if (!ModelState.IsValid) 
            {
             VM.Deptlist=_departmentbl.GetAllDepartments();
                return View("Edit",VM);
                  
            }
            var result=_coursebl.Edit(VM);
            return RedirectToAction("GetAllCourse");

        }
        //[HttpPost]
        //public IActionResult Delete(int id)
        //{
        //    _coursebl.deletecourse(id);
        //    return RedirectToAction("GetAllCourse");
            
        //}


    }
}
