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

            var IdProperty = validationContext.ObjectType.GetProperty("Id");
            int id = 0;

            if (IdProperty != null)
            {
                id = (int)IdProperty.GetValue(validationContext.ObjectInstance);
            }


            AppDbContext _context = (AppDbContext)validationContext.GetService(typeof(AppDbContext));

           // AppDbContext context = new AppDbContext();
            bool Dept= _context.Departments.Any(d=>d.Name==newname&&d.Id!=id);
            if(Dept)
            {
                return new ValidationResult("Department name already Exists");
            }
            return ValidationResult.Success;




           // return base.IsValid(value, validationContext);
        }

    }
}
