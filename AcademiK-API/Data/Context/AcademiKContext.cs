using AcademiK_API.Models;
using Microsoft.EntityFrameworkCore;

namespace AcademiK_API.Data.Context
{
    public class AcademiKContext : DbContext
    {
        public AcademiKContext(DbContextOptions<AcademiKContext> options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; } 
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Attendance> Attendances { get; set; }

    }
}
