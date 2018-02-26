using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EntityFrameworkAssignment.Models
{
    public class Course
    {
        [Key]
        public int CourseID  { get; set; }

        [Required]
        public string CourseName { get; set; }

        public List<Student> Students { get; set; }

        public List<Assignment> Assignments { get; set; }

        public List<Teacher> Teachers { get; set; }
    }   
    
}