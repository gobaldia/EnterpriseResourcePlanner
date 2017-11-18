using CoreEntities.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Context : DbContext
    {
        public DbSet<Person> people { get; set; }
        public DbSet<Subject> subjects { get; set; }
        public DbSet<Vehicle> vehicles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);   
            modelBuilder.Entity<Subject>().HasKey(s => s.SubjectOID);
            modelBuilder.Entity<Person>().HasKey(p => p.PersonOID);
            modelBuilder.Entity<Vehicle>().HasKey(p => p.VehicleOID);

            modelBuilder.Entity<Teacher>().ToTable("Teachers");
            modelBuilder.Entity<Student>().ToTable("Students");

            //modelBuilder.Entity<Teacher>().Map(m =>
            //{
            //    m.MapInheritedProperties();
            //    m.ToTable("Teachers");
            //});

            //modelBuilder.Entity<Student>().Map(m =>
            //{
            //    m.MapInheritedProperties();
            //    m.ToTable("Students");
            //});

            //modelBuilder.Entity<Subject>()
            //    .HasMany<Student>(s => s.Students)
            //    .WithMany(c => c.Subjects)
            //    .Map(cs =>
            //    {
            //        cs.MapLeftKey("StudentReferenceId");
            //        cs.MapRightKey("SubjectReferenceId");
            //        cs.ToTable("Student_Subject");
            //    });

            //modelBuilder.Entity<Subject>()
            //    .HasMany<Teacher>(s => s.Teachers)
            //    .WithMany(c => c.Subjects)
            //    .Map(cs =>
            //    {
            //        cs.MapLeftKey("StudentRefId");
            //        cs.MapRightKey("CourseRefId");
            //        cs.ToTable("Subject_Teacher");
            //    });


            //modelBuilder.Entity<Teacher>()
            //    .HasMany<Subject>(s => s.Subjects)
            //    .WithMany(c => c.Teachers)
            //    .Map(cs =>
            //    {
            //        cs.MapLeftKey("TeacherReferenceId");
            //        cs.MapRightKey("SubjectReferenceId");
            //        cs.ToTable("Teacher_Subject");
            //    });
        }
    }
}
