using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortal.Models;

namespace JobPortal.Controllers
{
    public class UserRegController : Controller
    {
        MVC_JobPortalEntities dbobj = new MVC_JobPortalEntities();
        // GET: UserReg
        public ActionResult User_Load()
        {
            List<stclass> stList = new List<stclass>
            {
                new stclass{sId=1,sName="Kerala"},
                 new stclass{sId=2,sName="Tamilnadu"},
                  new stclass{sId=3,sName="Kartanataka"},
                   new stclass{sId=4,sName="Goa"}
            };
            ViewBag.selstates = new SelectList(stList, "sId", "sName");
            UserRegistration user = new UserRegistration();
            user.MyFavoriteQual = getQualificationData();
            return View(user);
        }
        public List<CheckBoxListHelper> getQualificationData()
        {
            List<CheckBoxListHelper> sts = new List<CheckBoxListHelper>()
            {
                new CheckBoxListHelper{Value="SSLC",Text="SSLC",IsChecked=true},
                new CheckBoxListHelper{Value="PLUS TWO",Text="PLUS TWO",IsChecked=false},
                new CheckBoxListHelper{Value="BTech",Text="BTech",IsChecked=false},
                new CheckBoxListHelper{Value="MTech",Text="Mtech",IsChecked=false}
            };
            return sts;
        }
        public ActionResult User_Click(UserRegistration clsobj, FormCollection form)
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
                List<stclass> stList = new List<stclass>()
                {
                     new stclass{sId=1,sName="Kerala"},
                     new stclass{sId=2,sName="Tamilnadu"},
                     new stclass{sId=3,sName="Kartanataka"},
                     new stclass{sId=4,sName="Goa"}
                };
                int selectedId = Convert.ToInt32(form["Selstates"]);
                stclass SelectedItem = stList.FirstOrDefault(c => c.sId == selectedId);
                clsobj.sId = SelectedItem.sId;
                clsobj.sName = SelectedItem.sName;

                ViewBag.Selstates = new SelectList(stList, "sId", "sName");

                var quid = string.Join(",", clsobj.selectQual);
                clsobj.Qualification = quid;
                clsobj.MyFavoriteQual = getQualificationData();

                dbobj.sp_UserReg(regid, clsobj.Name, clsobj.Address, clsobj.Age, clsobj.Gender, clsobj.Phone, clsobj.Email, clsobj.sName, clsobj.District, clsobj.Pincode, clsobj.Qualification, clsobj.CGPA, clsobj.Skills, "Active");
                dbobj.sp_Login(regid, clsobj.Username, clsobj.Password, "User");
                clsobj.Msg = "Registered Succesfully!";
                return View("User_Load", clsobj);
            }
            else
            {
                List<stclass> stList = new List<stclass>()
                {
                    new stclass{sId=1,sName="Kerala"},
                     new stclass{sId=2,sName="Tamilnadu"},
                     new stclass{sId=3,sName="Kartanataka"},
                     new stclass{sId=4,sName="Goa"}
                };
                ViewBag.Selstates = new SelectList(stList, "sId", "sName");

                var quid = string.Join(",", clsobj.selectQual);
                clsobj.Qualification = quid;
                clsobj.MyFavoriteQual = getQualificationData();

                //return View("User_Load", clsobj);
            }
            return View("User_Load", clsobj);
        }
    }
}