using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortal.Models;
using System.IO;
using System.Data.Entity.Core.Objects;

namespace JobPortal.Controllers
{
    public class ApplyJobController : Controller
    {
        // GET: ApplyJob
        MVC_JobPortalEntities dbobj = new MVC_JobPortalEntities();
        public ActionResult ApplyJob_Load(int cid,int jid)
        {
            ObjectParameter op = new ObjectParameter("status", typeof(int));
            dbobj.sp_checkAppyExist(jid, Convert.ToInt32(Session["uid"]), op);
            int val = Convert.ToInt32(op.Value);
            if (val == 0)
            {
                TempData["cid"] = cid;
                TempData["jid"] = jid;
                var companyName = dbobj.CompanyRegs.Where(c => c.CId == cid).Select(c => c.Name).FirstOrDefault();
                Session["CompanyName"] = companyName.ToString();
                var JobName = dbobj.AddJobs.Where(c => c.JobId == jid).Select(c => c.JobName).FirstOrDefault();
                Session["JobName"] = JobName.ToString();

                return View();
            }
            else
            {
                return View("Already_Applied");
            }
        }
        public ActionResult Already_Applied()
        {
            return View();
        }
            public ActionResult ApplyJob_Click(ApplyJobCls clsobj, DisplayAllnSearch obj,HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file.ContentLength > 0)
                {
                    string fname = Path.GetFileName(file.FileName);
                    var s = Server.MapPath("~/FResume");
                    string pa = Path.Combine(s, fname);
                    file.SaveAs(pa);
                    var fullpath = Path.Combine("~\\FResume\\", fname);
                    clsobj.ApplyResume = fullpath;
                }
                int uid = Convert.ToInt32(Session["uid"]);
                int cid = Convert.ToInt32(TempData["cid"]);
                int jid = Convert.ToInt32(TempData["jid"]);
                dbobj.sp_applyJob(jid, cid, uid, clsobj.ApplyDate, clsobj.ApplyResume, "Available");
                clsobj.msg = "Applied Succesfully!";
                return View("ApplyJob_Load", clsobj);
            }
            return View("ApplyJob_Load",clsobj);
        }
    }
}