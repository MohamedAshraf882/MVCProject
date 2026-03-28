using System.ComponentModel.DataAnnotations;

namespace MVCProject.Models
{
    public class Department
    {
        public int Id { get; set; }
        [DataType(DataType.Text)]
        [Display(Name="Department Name")]
        [Required]
        [UniqueName]
        public string Name { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Manger Name")]
        public string Manger { get; set; }
        public List<Instructor> Instructors { get; set; }
        public List<Course> Courses { get; set; }
        public List<Trainee> Trainees { get; set; }
    }
}
