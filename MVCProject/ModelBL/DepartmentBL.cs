using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MVCProject.Models;

namespace MVCProject.ModelBL
{
    
    public class DepartmentBL
    {
     
        private readonly AppDbContext _context;
    
            public DepartmentBL(AppDbContext context)
            {
                _context = context;
            }
    
            public List<Department> GetAllDepartments()
            {
                return _context.Departments.ToList();
            }
        public Department details(int id)
        {
            return _context.Departments.FirstOrDefault(d => d.Id == id);
        }

        public Department Add(Department dept)
        {
           
            
            _context.Departments.Add(dept);
            _context.SaveChanges();
            return dept;
        }
        public Department Update(Department dept)
        {
            var existingDept = _context.Departments.FirstOrDefault(d => d.Id == dept.Id);
            if (existingDept != null)
            {
                existingDept.Name = dept.Name;
                existingDept.Manger = dept.Manger;
                _context.SaveChanges();
            }
            return existingDept;
        }

        public List<Department> Search(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return _context.Departments.ToList();
            }
            var dept=_context.Departments
                .Where(d=>d.Name.Contains(name))
                .OrderBy(d=>d.Name.IndexOf(name))
                .ThenBy(d=>d.Name)
                .ToList();

            return dept;
        }

        public bool delete(int id)
        {
            var dept = _context.Departments.FirstOrDefault(d => d.Id == id);
            if (dept == null)
            {
                return false;
               
            }
            bool hasinstructor=_context.Instructors.Any(d => d.Dept_Id== id);
            if (hasinstructor) 
            {

                return false;
            
            }
            bool Hascourse=_context.Courses.Any(d => d.Dept_Id == id);
            if (Hascourse) 
            { 
            return false;
            }

            _context.Remove(dept);
            _context.SaveChanges();
            return true;

        }

    }
}
