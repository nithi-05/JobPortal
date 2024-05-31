using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobPortal.Models
{
    public class ApplyJobCls
    {
        public int ApplyJobId { get; set; }
        public int ApplyCId { get; set; }
        public int ApplyUId { get; set; }
        [Required(ErrorMessage = "Enter Date")]
        public DateTime ApplyDate { get; set; }
        public string ApplyResume { get; set; }
        public string msg { get; set; }

    }
}