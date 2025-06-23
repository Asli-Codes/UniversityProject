using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL.DataBaseEntities;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Students> Students { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<CourseEntrollment> CourseEntrollments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
                
                    modelBuilder.Entity<CourseEntrollment>()
                        .HasKey(ce =>  ce.EntrollmentId);

                    modelBuilder.Entity<CourseEntrollment>()
                        .HasOne(ce => ce.Student)
                        .WithMany(s => s.courseEntrollments)
                        .HasForeignKey(ce => ce.StudentId);

                    modelBuilder.Entity<CourseEntrollment>()
                        .HasOne(ce => ce.Course)
                        .WithMany(c => c.CourseEntrollments)
                        .HasForeignKey(ce => ce.CourseId);

                    base.OnModelCreating(modelBuilder);
            
        }
    }
}
