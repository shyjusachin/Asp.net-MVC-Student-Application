using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentMVCApp.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter Student name")]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }
        public List<string> Courses { get; set; }
    }
}
