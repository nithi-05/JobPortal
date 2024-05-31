using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortal.Models;

namespace JobPortal.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        MVC_JobPortalEntities dbobj = new MVC_JobPortalEntities();
        public ActionResult UserHome()
        {
            var getdata = dbobj.sp_userProfile(Convert.ToInt32(Session["uid"])).FirstOrDefault();
            if (getdata != null)
            {
                return View(new UserProfile
                {
                    userid=getdata.UId,
                    name = getdata.Name,
                    age = getdata.Age,
                    address = getdata.Address,
                    gender = getdata.Gender,
                    email = getdata.Email,
                    phone = getdata.Phone,
                    state = getdata.State,
                    district = getdata.District,
                    cgpa = getdata.CGPA,
                    qualification = getdata.Qualification,
                    skills = getdata.Skills,
                    pincode = getdata.Pincode
                }
                );

            }
            else
            {
                return HttpNotFound();
            }
        }
        
    public ActionResult ProfileView()
        {
            int id = Convert.ToInt32(Session["uid"]);
            var getdata = dbobj.sp_userProfile(id).FirstOrDefault();
            return View(new UserProfile
            {
                name = getdata.Name,
                age = getdata.Age,
                address = getdata.Address,
                gender = getdata.Gender,
                email = getdata.Email,
                phone = getdata.Phone,
                state = getdata.State,
                district = getdata.District,
                cgpa = getdata.CGPA,
                qualification = getdata.Qualification,
                skills = getdata.Skills,
                pincode = getdata.Pincode
            }
            );
        }
        public ActionResult EditProfile()
        {
            var getdata = dbobj.sp_userProfile(Convert.ToInt32(Session["uid"])).FirstOrDefault();
            return View(new UserProfile
            {
                name = getdata.Name,
                age = getdata.Age,
                address = getdata.Address,
                gender = getdata.Gender,
                email = getdata.Email,
                phone = getdata.Phone,
                state = getdata.State,
                district = getdata.District,
                cgpa = getdata.CGPA,
                qualification = getdata.Qualification,
                skills = getdata.Skills,
                pincode = getdata.Pincode
            }
        );
        }

        public ActionResult Edit_Click(UserProfile obj)
        {
            dbobj.sp_profile_update(Convert.ToInt32(Session["uid"]), obj.name, obj.address, obj.age, obj.gender, obj.phone, obj.email, obj.district, obj.pincode, obj.cgpa, obj.skills);
            var getdata = dbobj.sp_userProfile(Convert.ToInt32(Session["uid"])).FirstOrDefault();
            return View("ProfileView", new UserProfile
            {
                name = getdata.Name,
                age = getdata.Age,
                address = getdata.Address,
                gender = getdata.Gender,
                email = getdata.Email,
                phone = getdata.Phone,
                state = getdata.State,
                district = getdata.District,
                cgpa = getdata.CGPA,
                qualification = getdata.Qualification,
                skills = getdata.Skills,
                pincode = getdata.Pincode
            }
            );
        }
        public ActionResult CompanyProfileView()
        {
            int id = Convert.ToInt32(Session["uid"]);
            var getdata = dbobj.sp_company_profile(id).FirstOrDefault();
            return View(new CompanyProfile
            {
                CompanyName=getdata.Name,
                CompanyAddress=getdata.Address,
                CompanyEmail=getdata.Email,
                CompanyPhone=getdata.Phone
            }
            );
        }
        public ActionResult CompanyHome()
        {
            int id = Convert.ToInt32(Session["uid"]);
            var getdata = dbobj.sp_company_profile(id).FirstOrDefault();
            return View(new CompanyProfile
            {
                CompanyName = getdata.Name,
                CompanyAddress = getdata.Address,
                CompanyEmail = getdata.Email,
                CompanyPhone = getdata.Phone
            }
            );
        }
    }
}