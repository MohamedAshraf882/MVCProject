using MVCProject.Models;
using System.ComponentModel.DataAnnotations;

namespace MVCProject.ModelView
{
    public class InstructorwithDepartment_Course_View
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Name must be greater than 1 letter ")]
        [MaxLength(100, ErrorMessage = "Name must be less than 100 letter")]

        public string Name { get; set; }

       // [RegularExpression(@"\w+\.(jpg|png|jfif)", ErrorMessage = "Image must be jpg or png")]
        public string?Currentimage { get; set; }

       // [RegularExpression(@"\\.(jpg|png|jfif)", ErrorMessage = "Image must be (jpg,png,jfif")]
        public IFormFile? Image { get; set; }

        [Required]
        [Range(7000, 50000, ErrorMessage = "salary must be between 7000 and 50000")]
        public double Salary { get; set; }
        
        [Required]
        [RegularExpression("[a-zA-z]{3,25}")]
        public string Address { get; set; }

        [Required]
        [Display(Name="Department")]
        public int Dept_Id { get; set; }
        [Required]
        [Display(Name="Course")]

        public int Crs_Id { get; set; }

        public List<Course>? CrsList { get; set; }
        public List<Department>? DeptList { get; set; }

    }
}
