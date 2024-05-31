using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobPortal.Models
{
    public class ViewAppliedJobs
    {
        public ViewAppliedJobs()
        {
            ViewJob = new List<JobList>();
        }
        public List<JobList> ViewJob { get; set; }
    }
    public class JobList
    { 
        public int ViewApplyId { get; set; }
        public int ViewJobId { get; set; }
        public int ViewCId { get; set; }
        public int ViewUId { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd MMMM yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ViewDate { get; set; }
        public string ViewResume { get; set; }
        public string ViewStatus { get; set; }
        public string ViewCompanyName { get; set; }
        public string ViewJobName { get; set; }
    }
}