using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EntityFrameworkAssignment.Models
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }

        [Required]
        public string StudentName { get; set; }

        public List<Student> GetStudentList { get; set; }

        public List<Course> Course { get; set; }

    }
}