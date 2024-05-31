using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortal.Models;

namespace JobPortal.Controllers
{
    public class AddJobsController : Controller
    {
        // GET: AddJobs
        MVC_JobPortalEntities dbobj = new MVC_JobPortalEntities();
        public ActionResult AddJob_Load()
        {
            return View();
        }
        public ActionResult AddJob_Click(AddJobs clsobj)
        {
            if (ModelState.IsValid)
            {
                int CId = Convert.ToInt32(Session["uid"]);
                dbobj.sp_addJobs(CId, clsobj.Add_JobName, clsobj.Add_Vacancy, clsobj.Add_RequiredSkill, clsobj.Add_Experience, clsobj.Add_Qualification,clsobj.Add_Salary, clsobj.Add_Location, clsobj.Add_StartDate, clsobj.Add_EndDate, "Available");
                clsobj.Msg = "Job Posted!";
                return View("AddJob_Load", clsobj);
            }
            return View("AddJob_Load", clsobj);
        }
    }
}