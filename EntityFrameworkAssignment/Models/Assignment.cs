using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EntityFrameworkAssignment.Models
{
    public class Assignment
    {
        [Key]
        public int AssignmentID { get; set; }

        [Required]
        public string AssignmentName { get; set; }

        public Course Course { get; set; }

    }
}