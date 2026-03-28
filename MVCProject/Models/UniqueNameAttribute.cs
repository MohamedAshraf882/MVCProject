using System.ComponentModel.DataAnnotations;

namespace MVCProject.Models
{
    public class UniqueNameAttribute:ValidationAttribute
    {
        //private readonly AppDbContext _context;
        //public UniqueNameAttribute(AppDbContext context)
        //{
        //    _context = context;
        //}
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return null;
            }
            string newname=value.ToString();

            AppDbContext _context = (AppDbContext)validationContext.GetService(typeof(AppDbContext));

           // AppDbContext context = new AppDbContext();
            Department Dept= _context.Departments.FirstOrDefault(d=>d.Name==newname);
            if(Dept!=null)
            {
                return new ValidationResult("Department name already Exists");
            }
            return ValidationResult.Success;




           // return base.IsValid(value, validationContext);
        }

    }
}
