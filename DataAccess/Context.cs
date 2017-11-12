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
        public DbSet<Teacher> teachers { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<Subject> subjects { get; set; }
        public DbSet<Vehicle> vehicles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Teacher>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Teachers");
            });

            modelBuilder.Entity<Student>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Students");
            });

            modelBuilder.Entity<Student>()
                .HasMany<Subject>(s => s.Subjects)
                .WithMany(c => c.Students)
                .Map(cs =>
                {
                    cs.MapLeftKey("StudentReferenceId");
                    cs.MapRightKey("SubjectReferenceId");
                    cs.ToTable("StudentSubject");
                });

            modelBuilder.Entity<Teacher>()
                .HasMany<Subject>(s => s.Subjects)
                .WithMany(c => c.Teachers)
                .Map(cs =>
                {
                    cs.MapLeftKey("TeacherReferenceId");
                    cs.MapRightKey("SubjectReferenceId");
                    cs.ToTable("TeacherSubject");
                });
        }
    }
}
