using Microsoft.AspNetCore.Mvc;
using MVCProject.ModelBL;
using MVCProject.Models;

namespace MVCProject.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly DepartmentBL _departmentBL;
        public DepartmentController(DepartmentBL departmentBL)
        {
            _departmentBL = departmentBL;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var departments = _departmentBL.GetAllDepartments();
            if (departments == null || departments.Count == 0)
            {
                return NotFound("No departments found.");
            }
            return View("deptview", departments);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var department = _departmentBL.details(id);
            if (department == null)
            {
                return NotFound($"Department with ID {id} not found.");
            }
            return View("deptdetails", department);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View("Add");
        }

        [HttpPost]
        public IActionResult SaveAdd(Department dept)
        {
            if (dept == null || dept.Name == null || dept.Manger == null)
            {
                return View("Add", dept);
                
            }
            _departmentBL.Add(dept);
            //return View("deptview");
            return RedirectToAction("GetAll");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var department = _departmentBL.details(id);
            if (department == null)
            {
                return NotFound($"Department with ID {id} not found.");
            }

            return View("Edit",department);
        }

        [HttpPost]
       public IActionResult SaveEdit(Department dept)
        {
            if (dept ==null||dept.Name == null || dept.Manger == null)
            {
                return View("Edit", dept);
                
            }
           _departmentBL.Update(dept);
            //return View("deptview");
            return RedirectToAction("GetAll");
        }

    }
}
