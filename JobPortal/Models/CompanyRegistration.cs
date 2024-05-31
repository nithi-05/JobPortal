using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobPortal.Models
{
    public class CompanyRegistration
    {
        [Required(ErrorMessage ="Enter Company Name!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter Company Address!")]
        public string Address { get; set; }
        [EmailAddress(ErrorMessage ="Enter a Valid Email!")]
        [Required(ErrorMessage = "Enter Company Email!")]
        public string Email { get; set; }
        [RegularExpression(@"^(\d{10})$",ErrorMessage ="Enter a Valid Phone Number!")]
        [Required(ErrorMessage ="Enter Phone Number!")]
        public long Phone { get; set; }
        [Required(ErrorMessage ="Enter Username!")]
        public string Username { get; set; }
        [Required(ErrorMessage ="Enter Password!")]
        public string Password { get; set; }
        [Compare("Password",ErrorMessage ="Password Mismatch!")]
        public string ConfirmPassword { get; set; }
        public string Msg { get; set; }

    }
}