using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace EntityFrameworkAssignment.Models
{
    public class SchoolDbContext:DbContext
    {
        public SchoolDbContext() :base("name=SchoolDbContext")
        {

        }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Assignment> Assignments { get; set; }
    }
}