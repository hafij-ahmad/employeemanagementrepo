using EmployeeMangement.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMangement.ViewModel
{
    public class EmployeeCreateViewModel
    {
     
        [Required]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email format.")]
        [Display(Name = "Office Email")]
        public string Email { get; set; }
        [Required]
        public Dept? Department { get; set; }

       // public IFormFile Photo { get; set; }

       // vedieo 54 multiple photo selecred//
        public List<IFormFile> Photos { get; set; }

        //close 54//
    }
}
