using Microsoft.AspNetCore.Cors.Infrastructure;

namespace MVCProject.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Hours { get; set; }
        public double Degree { get; set; }
        public double MinDegree { get; set; }
        public int Dept_Id { get; set; }
        public Department Department { get; set; }
        public List<Instructor> Instructors { get; set; }
        public List<CRSResult> CRSResults { get; set; }
    }
}
