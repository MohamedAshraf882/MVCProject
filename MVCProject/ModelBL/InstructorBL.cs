using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using MVCProject.Models;
using MVCProject.ModelView;

namespace MVCProject.ModelBL
{
    public class InstructorBL
    {
        private readonly AppDbContext _context;

        public InstructorBL(AppDbContext context)
        {
            _context = context;
        }

        public List<Instructor> GetAll()
        {
            var instructors=_context.Instructors.Include(i=>i.Department)
                .Include(i=>i.Course)
                .ToList();
            return instructors;
        }
        public Instructor GetById(int id)
        {
            var instructor = _context.Instructors
                .FirstOrDefault(i => i.Id == id);
            return instructor;
        }

        public Instructor AddInst(InstructorwithDepartment_Course_View VM)
        {
            Instructor inst = new Instructor
            {
                Name = VM.Name,
                Address = VM.Address,
                Image = VM.Image,
                Salary = VM.Salary,
                Dept_Id = VM.Dept_Id,
                Crs_Id = VM.Crs_Id,

            };

            _context.Instructors.Add(inst);
            _context.SaveChanges();
           return inst;
        }



    }
}
