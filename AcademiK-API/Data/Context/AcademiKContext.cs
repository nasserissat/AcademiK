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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Attendance>()
                .HasKey(x => new { x.StudentId, x.SubjectId });

            modelBuilder.Entity<Attendance>()
            .HasOne(a => a.Subject)
            .WithMany(a => a.Attendances)
            .HasForeignKey(a => a.SubjectId)
            .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Attendance>()
            .HasOne(a => a.Student)
            .WithMany(a => a.Attendances)
            .HasForeignKey(a => a.StudentId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Grade>()
           .HasOne(a => a.Student)
           .WithMany(a => a.Grades)
           .HasForeignKey(a => a.StudentId)
           .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Grade>()
          .HasOne(a => a.Subject)
          .WithMany(a => a.Grades)
          .HasForeignKey(a => a.SubjectId)
          .OnDelete(DeleteBehavior.Restrict);



        }


    }
}
