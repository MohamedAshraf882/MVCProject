using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MVCProject.Models
{
    public class AppDbContext:DbContext

    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        
        
        //Data Source =.; Initial Catalog = Company; Integrated Security = True; Encrypt=False;Trust Server Certificate=True
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Instructor>()
                .HasOne(i => i.Department)
                .WithMany(d => d.Instructors)
                .HasForeignKey(i => i.Dept_Id);
            modelBuilder.Entity<Instructor>()
                .HasOne(i => i.Course)
                .WithMany(c => c.Instructors)
                .HasForeignKey(i => i.Crs_Id);
            modelBuilder.Entity<Course>()
                .HasOne(c => c.Department)
                .WithMany(d => d.Courses)
                .HasForeignKey(c => c.Dept_Id);
            modelBuilder.Entity<Trainee>()
                .HasOne(t => t.Department)
                .WithMany(d => d.Trainees)
                .HasForeignKey(t => t.Dept_Id);
            modelBuilder.Entity<CRSResult>()
                .HasOne(r => r.Trainee)
                .WithMany(t => t.CRSResults)
                .HasForeignKey(r => r.Trainee_Id);
            modelBuilder.Entity<CRSResult>()
                .HasOne(r => r.Course)
                .WithMany(c => c.CRSResults)
                .HasForeignKey(r => r.Crs_Id);
        }


       public  DbSet<Instructor> Instructors { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<CRSResult> CRSResults { get; set; }




    }
}
