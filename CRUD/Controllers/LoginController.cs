using CRUD.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Controllers
{
    public class LoginController : Controller
    {
        Db_TestEntities1 dbobj = new Db_TestEntities1();
        // GET: Login
        public ActionResult Login()
        {
            return View("Login");
        }
        public ActionResult checkLogin(tbl_login model)
        {
            using (var context = new Db_TestEntities1())
            {
                bool isValid = context.tbl_login.Any(x=>x.Email == model.Email && x.Password==model.Password);
                if(isValid)
                {
                    TempData["AlertMessage"] = "Login successfully";
                    return RedirectToAction("Student","Student");
                }
                ModelState.AddModelError("","Invalid Email and Password");
                return View("Login");
            }
               
        }

        public ActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddUser(tbl_login model)
        {
            tbl_login obj = new tbl_login();

            using (var con = new Db_TestEntities1())
            {
                bool isValid = con.tbl_login.Any(x => x.Email == model.Email);
                if (isValid)
                {
                    TempData["AlertMessage"] = "User Already created";
                    return View("Register");
                }
                else
                {

                    if (ModelState.IsValid)
                    {
                        //obj.Id = model.Id;
                        obj.Email = model.Email;
                        obj.Password = model.Password;
                        dbobj.tbl_login.Add(obj);
                        dbobj.SaveChanges();
                        TempData["AlertMessage"] = "User Created successfully";
                    }
                    ModelState.Clear();
                    return View("Login");
                }
            }

        } 
        
    }
}