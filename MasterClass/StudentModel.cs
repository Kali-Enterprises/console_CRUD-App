using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace MasterClass
{
    public class StudentModel
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name of Student is required !!!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Username of Student is required !!!")]
        public string UserName { get; set; }

        public string Email { get; set; }
        public int Age { get; set; }
    }
}
