using MVCProject.Models;

namespace MVCProject.ModelBL
{
    public class CourseBl
    {
        private readonly AppDbContext _context;
        public CourseBl(AppDbContext context)
        {
            _context = context;
        }
        public List<Course> GetAll()
        {
            var courses=_context.Courses.ToList();
            return courses;
        }

        public Course GetById(int id)
        {
            var course = _context.Courses.FirstOrDefault(c => c.Id == id);

            return course;

        }

    }
}
