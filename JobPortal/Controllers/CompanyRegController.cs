using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortal.Models;

namespace JobPortal.Controllers
{
    public class CompanyRegController : Controller
    {
        MVC_JobPortalEntities dbobj = new MVC_JobPortalEntities();
        // GET: CompanyReg
        public ActionResult Company_Load()
        {
            return View();
        }
        public ActionResult Company_Click(CompanyRegistration clsobj)
        {
            if (ModelState.IsValid)
            {
                var getmaxid = dbobj.sp_MaxIdLogin().FirstOrDefault();
                int _maxId = Convert.ToInt32(getmaxid);
                int regid = 0;
                if (_maxId == 0)
                {
                    regid = 1;
                }
                else
                {
                    regid = _maxId + 1;
                }
                dbobj.sp_CompanyReg(regid, clsobj.Name, clsobj.Address, clsobj.Email, clsobj.Phone, "Available");
                dbobj.sp_Login(regid, clsobj.Username, clsobj.Password, "Company");
                clsobj.Msg = "Registered Successfully!";
                return View("Company_Load", clsobj);
            }
            return View("Company_Load", clsobj);
        }
    }
}