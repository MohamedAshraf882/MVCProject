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
            if (!ModelState.IsValid)
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
                return View("Edit", department);
            }

            return View("Edit",department);
        }

        [HttpPost]
       public IActionResult SaveEdit(Department dept)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", dept);
                
            }
           _departmentBL.Update(dept);
            //return View("deptview");
            return RedirectToAction("GetAll");
        }

        [HttpGet]
        public IActionResult SearchByName(string name) 
        {
        var dept=_departmentBL.Search(name);
            return View("deptview", dept);
        
        
        
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result=_departmentBL.delete(id);
            if (!result)
            {
                TempData["Error"] = "Department has instructors if you want delete it first delete instructors it have ";
            }

            return RedirectToAction("GetAll");


        }

    }
}
