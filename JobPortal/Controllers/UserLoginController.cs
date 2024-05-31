using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortal.Models;

namespace JobPortal.Controllers
{
    public class UserLoginController : Controller
    {
        MVC_JobPortalEntities dbobj = new MVC_JobPortalEntities();
        // GET: UserLogin
        public ActionResult Login_PageLoad()
        {
            Session["uid"] = null;
            return View();
        }
       
        public ActionResult Login_Click(LoginCls clsobj)
        {
            if (ModelState.IsValid)
            {
                ObjectParameter op = new ObjectParameter("status", typeof(int));
                dbobj.sp_LoginCheck(clsobj.Username, clsobj.Password, op);
                int val = Convert.ToInt32(op.Value);
                if (val == 1)
                {
                    var uid = dbobj.sp_LogId(clsobj.Username, clsobj.Password).FirstOrDefault();
                    Session["uid"] = uid;
                    var logType = dbobj.sp_LogType(clsobj.Username, clsobj.Password).FirstOrDefault();
                    Session["type"] = logType;
                    if (logType == "User")
                    {
                        return RedirectToAction("UserHome","Profile");
                    }
                    else if (logType == "Company")
                    {
                        return RedirectToAction("CompanyHome","Profile");
                    }
                }
                else
                {
                    ModelState.Clear();
                    clsobj.Msg = "Invalid Login";
                    return View("Login_PageLoad", clsobj);
                }
            }
            return View("Login_PageLoad",clsobj);
        }
    }
}