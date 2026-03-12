using Microsoft.AspNetCore.Mvc;
using MVCProject.ModelBL;
using MVCProject.Models;
using MVCProject.ModelView;

namespace MVCProject.Controllers
{
    public class InstructorController : Controller
    {
        
        private readonly InstructorBL _instructorBL;
        private readonly DepartmentBL _departmentBL;
        private readonly CourseBl _coursebl;
        public InstructorController(InstructorBL instructorBL, DepartmentBL departmentBL,CourseBl courseBl)
        {
            _instructorBL = instructorBL;
            _departmentBL = departmentBL;
            _coursebl = courseBl;
        }
        [HttpGet]
        public IActionResult Index() 
        {
            var instructors = _instructorBL.GetAll();
              if (instructors == null || instructors.Count == 0)
              {
                return NotFound("No instructors found.");
              }
                return View("instructorview", instructors);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var instructor = _instructorBL.GetById(id);
            if (instructor == null)
            {
                return NotFound($"Instructor with ID {id} not found.");
            }
            return View("details", instructor);
        }

        [HttpGet]
        public IActionResult Create()
        {
            InstructorwithDepartment_Course_View Vm = new InstructorwithDepartment_Course_View
            {
                DeptList = _departmentBL.GetAllDepartments(),
                CrsList = _coursebl.GetAll()
            };
            return View("create", Vm);
        }
        [HttpPost]
        public IActionResult SaveCreate(InstructorwithDepartment_Course_View VM)
        {
            
            if(!ModelState.IsValid)
            {
                VM.DeptList=_departmentBL.GetAllDepartments();
                VM.CrsList=_coursebl.GetAll();
                return View("create",VM);
            }
           
           
            _instructorBL.AddInst(VM);
            return RedirectToAction("Index");

        }

       
    }
}
