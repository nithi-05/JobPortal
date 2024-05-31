using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using JobPortal.Models;
using System.Configuration;
using System.Data.Entity;

namespace JobPortal.Controllers
{
    public class DisplayAllJobsController : Controller
    {
        // GET: DisplayAllJobs
        MVC_JobPortalEntities dbobj = new MVC_JobPortalEntities();
        public ActionResult DisplayAllJob_Load()
        {
            return View(GetData());
        }
        private DisplayAllnSearch GetData()
        {
            var joblist = new DisplayAllnSearch();
            List<string> lst = new List<string>();
            var job = dbobj.AddJobs.ToList();
            foreach (var e in job)
            {
                var jobcls = new jsearch();
                jobcls.JobId = e.JobId;
                jobcls.CId = e.CId;
                jobcls.JobName = e.JobName;
                jobcls.Vacancy = e.Vacancy;
                jobcls.RequiredSkill = e.RequiredSkill;
                jobcls.Experience = e.Experience;
                jobcls.Qualification = e.Qualification;
                jobcls.Salary = e.Salary;
                jobcls.Location = e.Location;
                jobcls.StartDate = e.StartDate;
                jobcls.EndDate = e.EndDate;
                jobcls.JobStatus = e.JobStatus;
                var companyName = dbobj.CompanyRegs.Where(c => c.CId == jobcls.CId).Select(c => c.Name).FirstOrDefault();
                jobcls.CompanyName = companyName;
                joblist.selectjob.Add(jobcls);
                var s = jobcls.RequiredSkill;
                lst.Add(s);
                TempData["skill"] = String.Join(" ", lst);

            }

            return joblist;
        }
        public ActionResult SearchJob_Click(DisplayAllnSearch clsobj)
        {
            string qry = "";
            if (!string.IsNullOrWhiteSpace(clsobj.insertse.JobName))
            {
                qry += " and JobName like '%" + clsobj.insertse.JobName + "%'";
            }
            if (!string.IsNullOrWhiteSpace(clsobj.insertse.RequiredSkill))
            {
                qry += " and RequiredSkill like '%" + clsobj.insertse.RequiredSkill + "%'";
            }
            if (!string.IsNullOrWhiteSpace(clsobj.insertse.Location))
            {
                qry += " and Location like '%" + clsobj.insertse.Location + "%'";
            }
            return View("DisplayAllJob_Load", getdata1(clsobj, qry));
        }
        private DisplayAllnSearch getdata1(DisplayAllnSearch clsobj, string qry)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["test"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_check", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@qry", qry);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                var joblist = new DisplayAllnSearch();
                while (dr.Read())
                {
                    var jobcls = new jsearch();
                    jobcls.JobId = Convert.ToInt32(dr["JobId"].ToString());
                    jobcls.CId = Convert.ToInt32(dr["CId"].ToString());
                    jobcls.JobName = dr["JobName"].ToString();
                    jobcls.Vacancy = Convert.ToInt32(dr["Vacancy"].ToString());
                    jobcls.RequiredSkill = dr["RequiredSkill"].ToString();
                    jobcls.Experience = dr["Experience"].ToString();
                    jobcls.Qualification = dr["Qualification"].ToString();
                    jobcls.Salary = Convert.ToInt32(dr["Salary"].ToString());
                    jobcls.Location = dr["Location"].ToString();
                    jobcls.StartDate = Convert.ToDateTime(dr["StartDate"].ToString());
                    jobcls.EndDate = Convert.ToDateTime(dr["EndDate"].ToString());
                    jobcls.JobStatus = dr["JobStatus"].ToString();
                    var companyName = dbobj.CompanyRegs.Where(c => c.CId == jobcls.CId).Select(c => c.Name).FirstOrDefault();
                    jobcls.CompanyName = companyName;

                    joblist.selectjob.Add(jobcls);
                }
                con.Close();
                return joblist;
            }
        }
    }
}