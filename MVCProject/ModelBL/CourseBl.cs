using Microsoft.EntityFrameworkCore;
using MVCProject.Models;
using MVCProject.ModelView;
using System.Reflection.Metadata.Ecma335;

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
            var courses = _context.Courses.ToList();
            return courses;
        }

        public Course GetById(int id)
        {
            var course = _context.Courses.FirstOrDefault(c => c.Id == id);

            return course;

        }
        public Course AddCourse(Course_Department_VM VM)
        {
            var course = new Course
            {
                Name = VM.Name,
                Hours = VM.Hours,
                Degree = VM.Degree,
                MinDegree = VM.MinDegree,
                Dept_Id = VM.Dept_Id
            };
            _context.Courses.Add(course);
            _context.SaveChanges();
            return course;
        }

        public List<Course> Search(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return _context.Courses.Include(c => c.Department).ToList();
            }

            var result = _context.Courses.Include(c => c.Department).Where(c => c.Name.Contains(name)).OrderBy(c => c.Name.IndexOf(name))
                .ThenBy(c => c.Name)
                .ToList();
            return result;
        }

        public Course Edit(Course_Department_VM VM)
        {
            var course = _context.Courses.FirstOrDefault(c => c.Id == VM.Id);


            course.Name = VM.Name;
            course.Hours = VM.Hours;
            course.Degree = VM.Degree;
            course.MinDegree = VM.MinDegree;
            course.Dept_Id = VM.Dept_Id;

            _context.Courses.Update(course);
            _context.SaveChanges();
            return course;
        }
        //public void deletecourse(int id)
        //{

        //    var coure=_context.Courses.FirstOrDefault(c=>c.Id== id);
        //    _context.Remove(coure);
        //    _context.SaveChanges();
            


        //}
    }
        
    
}
