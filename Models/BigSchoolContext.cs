using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BigSchool.Models
{
    public partial class BigSchoolContext : DbContext
    {
        public BigSchoolContext()
            : base("name=BugSchool")
        {
        }

  
        //public virtual void SetAttendances(DbSet<Attendace> value)
        //{
        //    attendances = value;
        //}

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Attendance>Attendaces { get; set; }
        //public object Attendances { get; internal set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.Course)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);
        }

        public System.Data.Entity.DbSet<BigSchool.Models.Following> Followings { get; set; }
    }
}
