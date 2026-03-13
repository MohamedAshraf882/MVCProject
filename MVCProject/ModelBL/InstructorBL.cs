using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.Ini;
using MVCProject.Models;
using MVCProject.ModelView;
using System.Reflection.Metadata.Ecma335;

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

        public List<Instructor> SearchByName(string name) 
        {
            if (string.IsNullOrEmpty(name))
            {
                return _context.Instructors.Include(i=>i.Course).Include(i=>i.Department).ToList();
            }

        var Insts= _context.Instructors.Include(i => i.Department)
                .Include(i => i.Course).Where(i=>i.Name.Contains(name))
                .OrderBy(i=>i.Name.IndexOf(name))
                .ThenBy(i=>i.Name)
                .ToList();
        return Insts;
        
        
        } 
        public Instructor Updateinst(InstructorwithDepartment_Course_View Vm)
        {

            var instruct = _context.Instructors.FirstOrDefault(i => i.Id == Vm.Id);

            instruct.Name = Vm.Name;
            instruct.Address = Vm.Address;
            instruct.Image = Vm.Image;
            instruct.Salary = Vm.Salary;
            instruct.Dept_Id = Vm.Dept_Id;
            instruct.Crs_Id = Vm.Crs_Id;
            
            _context.Instructors.Update(instruct);
            _context.SaveChanges();
            return instruct;
        }

        public void Deleteinst(int id)
        {
            var result= _context.Instructors.FirstOrDefault(i=>i.Id==id);

             _context.Remove(result);
            _context.SaveChanges();
          

        }


    }
}
