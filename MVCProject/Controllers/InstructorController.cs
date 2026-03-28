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
                return View("instructorview",instructors);
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
            if (VM.Image != null)
            {
                var allowedextensions = new[]
                {
                    ".jpg",".png",".jfif"
                };
                var extension=Path.GetExtension(VM.Image.FileName).ToLower();
                if (!allowedextensions.Contains(extension))
                {
                    ModelState.AddModelError("Image", "Image must be (jpg,png,jfif)");
                }
                if (VM.Image.Length > 2 * 1024 * 1024)
                {
                    ModelState.AddModelError("Image", "Image Max size is 2MB");
                }

            }
            if (VM.Dept_Id == 0)
            {
                ModelState.AddModelError("Dept_Id", "Select Department");
            }
            if (VM.Crs_Id == 0)
            {
                ModelState.AddModelError("Crs_Id", "Select Course");
            }

            if (ModelState.IsValid)
            {
                 //if (VM.Dept_Id == 0)
                //{
                //    ModelState.AddModelError("Dept_Id", "Select Department");
                //}
                //if (VM.Crs_Id == 0)
                //{
                //    ModelState.AddModelError("Crs_Id", "Select Course");
                //}
                _instructorBL.AddInst(VM);
                return RedirectToAction("Index");
            }

            VM.DeptList = _departmentBL.GetAllDepartments();
            VM.CrsList = _coursebl.GetAll();
            return View("create", VM);
            

        }
        [HttpGet]
        public IActionResult SearchName(string name)
        {
            var result=_instructorBL.SearchByName(name);
           
                return View("instructorview", result);


        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var iNstFromD=_instructorBL.GetById(id);
            var Department = _departmentBL.GetAllDepartments();
            var Courses=_coursebl.GetAll();

            
            var VM = new InstructorwithDepartment_Course_View
            {
                Id=iNstFromD.Id,
                Name = iNstFromD.Name,
                Address = iNstFromD.Address,
                Currentimage=iNstFromD.Image,
                //Image = iNstFromD.Image,
                Salary = iNstFromD.Salary,
                Dept_Id = iNstFromD.Dept_Id,
                Crs_Id = iNstFromD.Crs_Id,
                DeptList = Department,
                CrsList = Courses,
               
        };
            return View("Edit", VM);   
        }
        [HttpPost]
        public IActionResult SaveEdit(InstructorwithDepartment_Course_View VM)
        {
            if (!ModelState.IsValid) 
            { 
             VM.DeptList=_departmentBL.GetAllDepartments();
             VM.CrsList=_coursebl.GetAll();
                return View("Edit", VM);
            }
            _instructorBL.Updateinst(VM); 
            return RedirectToAction("Index");
            
        }
        //public IActionResult Deleteinst(int id)
        //{
        //    var inst=_instructorBL.GetById(id);
        //    return View("instructorview", inst);



        //}

        [HttpPost]
        public IActionResult savedelete(int id) 
        {
            _instructorBL.Deleteinst(id);
            return RedirectToAction("Index");
        
        }
       
    }
}
