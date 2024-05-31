using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace JobPortal.Models
{
    public class stclass
    {
        public int sId { set; get; }
        public string sName { set; get; }
    }
    public class CheckBoxListHelper
    {
        public string Value { set; get; }
        public string Text { set; get; }
        public bool IsChecked { set; get; }
    }
    public class UserRegistration
    {
        public int sId { set; get; }
        public string sName { set; get; }
        public List<CheckBoxListHelper> MyFavoriteQual { get; set; }
        public string[] selectQual { set; get; }
        [Required(ErrorMessage = "Enter Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Enter Age")]
        public int Age { get; set; }
        public string Gender { get; set; }
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Enter a Valid Phone Number!")]
        [Required(ErrorMessage = "Enter Phone Number!")]
        public long Phone { get; set; }
        [EmailAddress(ErrorMessage = "Enter a Valid Email!")]
        [Required(ErrorMessage = "Enter Company Email!")]
        public string Email { get; set; }
        public string State { get; set; }
        [Required(ErrorMessage ="Enter District")]
        public string District { get; set; }
        [Required(ErrorMessage ="Enter Pincode")]
        public int Pincode { get; set; }
        public string Qualification { get; set; }
        [Required(ErrorMessage = "Enter CGPA")]
        public decimal CGPA { get; set; }
        [Required(ErrorMessage = "Enter Skills")]
        public string Skills { get; set; }
        [Required(ErrorMessage = "Enter Username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Enter Password")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Password Mismatch!")]
        public string ConfirmPassword { get; set; }
        public string Msg { get; set; }
    }
}