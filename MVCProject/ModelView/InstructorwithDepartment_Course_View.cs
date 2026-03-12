using MVCProject.Models;
using System.ComponentModel.DataAnnotations;

namespace MVCProject.ModelView
{
    public class InstructorwithDepartment_Course_View
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public double Salary { get; set; }
        
        [Required]
        public string Address { get; set; }

        [Required]
        public int Dept_Id { get; set; }
        [Required]
        public int Crs_Id { get; set; }

        public List<Course>? CrsList { get; set; }
        public List<Department>? DeptList { get; set; }

    }
}
