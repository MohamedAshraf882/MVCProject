using Microsoft.EntityFrameworkCore;
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
       









    }
}
