
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MVCProject.Models
{
    public class Instructor
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        [MinLength(2, ErrorMessage = "Name must be greater than 1 letter ")]
        [MaxLength(100,ErrorMessage ="Name must be less than 100 letter")]
        
        public string Name { get; set; }
        
        //[RegularExpression(@"\w+\.(jpg|png)",ErrorMessage ="Image must be jpg or png")]
        public string?Image { get; set; }

        [Required]
        [Range(7000,50000,ErrorMessage ="salary must be between 7000 and 50000")]
        public double Salary { get; set; }

        [Required]
        [RegularExpression("[a-zA-z]{3,25}")]
        public string Address { get; set; }

        public int Dept_Id { get; set; }
        public Department Department { get; set; }
        public int Crs_Id { get; set; }
        public Course Course { get; set; }

    }
}
