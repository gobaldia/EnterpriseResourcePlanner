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
        public DbSet<Activity> activities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);   
            modelBuilder.Entity<Subject>().HasKey(s => s.SubjectOID);
            modelBuilder.Entity<Person>().HasKey(p => p.PersonOID);
            modelBuilder.Entity<Vehicle>().HasKey(p => p.VehicleOID);
            modelBuilder.Entity<Activity>().HasKey(a => a.ActivityOID);

            modelBuilder.Entity<Teacher>().ToTable("Teachers");
            modelBuilder.Entity<Student>().ToTable("Students");
        }
    }
}
