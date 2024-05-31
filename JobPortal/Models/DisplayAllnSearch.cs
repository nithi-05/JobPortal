using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobPortal.Models
{
    public class DisplayAllnSearch
    {
        public DisplayAllnSearch()
        {
            selectjob = new List<jsearch>();
            insertse = new jsearch();
        }
        public jsearch insertse { get; set; }
        public List<jsearch> selectjob { get; set; }

    }
    public class jsearch
    {
        public int JobId { get; set; }
        public int CId { get; set; }
        public string JobName { get; set; }
        public int Vacancy { get; set; }
        public string RequiredSkill { get; set; }
        public string Experience { get; set; }
        public string Qualification { get; set; }
        public int Salary { get; set; }
        public string Location { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd MMMM yyyy}",ApplyFormatInEditMode=true)]
        public DateTime StartDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd MMMM yyyy}", ApplyFormatInEditMode = true)]

        public DateTime EndDate { get; set; }
        public string JobStatus { get; set; }
        public string CompanyName { get; set; }
    }
}