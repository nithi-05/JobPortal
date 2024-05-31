using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobPortal.Models
{
    public class AddJobs
    {
        public int Add_CId { get; set; }
        [Required(ErrorMessage = "Enter Job Name")]
        public string Add_JobName { get; set; }
        [Required(ErrorMessage = "Enter no. of Vacancies")]
        public int Add_Vacancy { get; set; }
        [Required(ErrorMessage = "Enter Job Requirments")]
        public string Add_RequiredSkill { get; set; }
        [Required(ErrorMessage = "Enter Required Experience")]
        public string Add_Experience { get; set; }
        [Required(ErrorMessage = "Enter Required Qualifications")]
        public string Add_Qualification { get; set; }
        [Required(ErrorMessage = "Enter Salary")]
        public int Add_Salary { get; set; }
        [Required(ErrorMessage = "Enter Job Location")]
        public string Add_Location { get; set; }
        [Required(ErrorMessage = "Enter Start Date")]
        public DateTime Add_StartDate { get; set; }
        [Required(ErrorMessage = "Enter End Date")]
        public DateTime Add_EndDate { get; set; }
        public string Msg { get; set; }
    }
}