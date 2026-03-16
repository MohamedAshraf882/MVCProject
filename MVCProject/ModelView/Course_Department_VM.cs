using MVCProject.Models;
using System.ComponentModel.DataAnnotations;

namespace MVCProject.ModelView
{
    public class Course_Department_VM
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Hours { get; set; }
        [Required]
        public double Degree { get; set; }
        [Required]
        public double MinDegree { get; set; }
        [Required]
        public int Dept_Id { get; set; }
        public List<Department>? Deptlist {  get; set; }












    }
}
