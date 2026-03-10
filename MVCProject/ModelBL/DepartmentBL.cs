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










    }
}
