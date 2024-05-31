using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobPortal.Models
{
    public class UserProfile
    {
        public int userid { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public int age { get; set; }
        public string gender { get; set; }
        public long phone { get; set; }
        public string email { get; set; }
        public string state { get; set; }
        public string district { get; set; }
        public int pincode { get; set; }
        public string qualification { get; set; }
        public decimal cgpa { get; set; }
        public string skills { get; set; }
    }
}