using ST_MVC_Day2.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ST_MVC_Day2.ViewModels
{
    public class AddEmployeeVM
    {
        public int ID { get; set; }
        [Required(ErrorMessage="*")]
        [StringLength(50,MinimumLength =3, ErrorMessage = "Name must be from 3 to 50 char")]
        public string? Name { get; set; }
        [Range(20,40, ErrorMessage = "Age must be between 20 to 40 years")]
        public int Age { get; set; }
        [Display(Name = "Net Salary")]
        public decimal Salary { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "you must give valid email")]
        [EmailAddress]
        public string? Email { get; set; }
        [DataType(DataType.Password, ErrorMessage = "At least one digit [0-9]\r\nAt least one lowercase character [a-z]\r\nAt least one uppercase character [A-Z]\r\nAt least 8 characters in length, but no more than 32.")]
        [RegularExpression("^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z]).{8,32}$")]
        public string? Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name="Confirm Password")]
        [RegularExpression("^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z]).{8,32}$")]
        [Compare("Password", ErrorMessage = "the password must be matched")]
        public string? ConfirmPassword { get; set; }

        [Display(Name = "Office")]
        [ForeignKey("Office")]
        [Required]
        public int Office_ID { get; set; }
        [ValidateNever]
        public SelectList? offices { get; set; } 

    }
}
