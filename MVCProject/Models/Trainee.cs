using Microsoft.AspNetCore.Cors.Infrastructure;

namespace MVCProject.Models
{
    public class Trainee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Image { get; set; }

        public string Address { get; set; }
        public string Grade { get; set; }
        public int Dept_Id { get; set; }
        public Department Department { get; set; }

        public List<CRSResult> CRSResults { get; set; }

    }
}
