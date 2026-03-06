
namespace MVCProject.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public double Salary { get; set; }
        public string Address { get; set; }

        public int Dept_Id { get; set; }
        public Department Department { get; set; }
        public int Crs_Id { get; set; }
        public Course Course { get; set; }

    }
}
