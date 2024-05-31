using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortal.Models;
using System.Data;
using System.Data.SqlClient;

namespace JobPortal.Controllers
{
    public class ViewAppliedJobsController : Controller
    {
        // GET: ViewAppliedJobs
        MVC_JobPortalEntities dbobj = new MVC_JobPortalEntities();
        public ActionResult ViewAppliedJobs_Load(ViewAppliedJobs clsobj)
        {
            int uid = Convert.ToInt32(Session["uid"]);
            return View(GetAppliedJobs(clsobj, uid));
        }
        private ViewAppliedJobs GetAppliedJobs(ViewAppliedJobs clsobj, int uid)
        {
            using (var con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["test"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_viewAppliedJobs", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@uid", uid);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                var joblist = new ViewAppliedJobs();
                while (dr.Read())
                {
                    var jobcls = new JobList();
                    jobcls.ViewApplyId = Convert.ToInt32(dr["ApplyId"]);
                    jobcls.ViewJobId = Convert.ToInt32(dr["JobId"]);
                    jobcls.ViewCId = Convert.ToInt32(dr["CId"]);
                    jobcls.ViewUId = Convert.ToInt32(dr["UId"]);
                    jobcls.ViewDate = Convert.ToDateTime(dr["Date"]);
                    jobcls.ViewResume = dr["Resume"].ToString();
                    jobcls.ViewStatus = dr["ApplyStatus"].ToString();

                    var companyName = dbobj.CompanyRegs.Where(c => c.CId == jobcls.ViewCId).Select(c => c.Name).FirstOrDefault();
                    jobcls.ViewCompanyName = companyName;
                    var JobName = dbobj.AddJobs.Where(c => c.JobId == jobcls.ViewJobId).Select(c => c.JobName).FirstOrDefault();
                    jobcls.ViewJobName = JobName;
                    joblist.ViewJob.Add(jobcls);

                }
                con.Close();
                return joblist;
            }
        }
    }
}