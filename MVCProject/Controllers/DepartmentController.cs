using Microsoft.AspNetCore.Mvc;
using MVCProject.ModelBL;

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
                return View("deptview",departments);
        }
        



    }
}
