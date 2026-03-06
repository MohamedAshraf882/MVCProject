namespace MVCProject.Models
{
    public class CRSResult
    {
        public int Id { get; set; }
        public double Degree { get; set; }
        public int Trainee_Id { get; set; }
        public Trainee Trainee { get; set; }
        public int Crs_Id { get; set; }
        public Course Course { get; set; }

    }
}
