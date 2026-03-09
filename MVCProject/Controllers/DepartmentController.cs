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


        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAll()
        {
            var departments = _departmentBL.GetAllDepartments();
            if (departments == null || departments.Count == 0)
            {
                return NotFound("No departments found.");
            }
            return View("deptview", departments);
        }

        public IActionResult Details(int id)
        {
            var department = _departmentBL.details(id);
            if (department == null)
            {
                return NotFound($"Department with ID {id} not found.");
            }
            return View("deptdetails", department);
        }


        public IActionResult Add()
        {
            return View("Add");
        }

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
    }
}
