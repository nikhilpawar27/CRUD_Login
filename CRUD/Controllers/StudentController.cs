using CRUD.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Controllers
{
    public class StudentController : Controller
    {
        Db_TestEntities dbobj = new Db_TestEntities();
        public ActionResult Student(tbl_student obj)
        {
            
                return View(obj);
        }
        [HttpPost]
        public ActionResult AddStudent(tbl_student model)
        {
            tbl_student obj = new tbl_student();
            if (ModelState.IsValid)
            {
                
                obj.Id = model.Id;
                obj.Name = model.Name;
                obj.Fname = model.Fname;
                obj.Email = model.Email;
                obj.Mobile = model.Mobile;
                obj.Description = model.Description;
                if (model.Id == 0)
                {
                    dbobj.tbl_student.Add(obj);
                    dbobj.SaveChanges();
                    TempData["AlertMessage"] = "Student Added successfully";
                }
                else
                {
                    dbobj.Entry(obj).State = EntityState.Modified;
                    dbobj.SaveChanges();
                    TempData["AlertMessage"] = "Student Modified successfully";
                }           
          }
            ModelState.Clear();
            return View("Student");
        }

        public ActionResult StudentList()
        {
            var res = dbobj.tbl_student.ToList();
            return View(res);
        }
        public ActionResult Delete(int id)
        {
            var res = dbobj.tbl_student.Where(x => x.Id == id).First();
            dbobj.tbl_student.Remove(res);
            dbobj.SaveChanges();
            TempData["AlertMessage"] = "Student Delete successfully";
            var list = dbobj.tbl_student.ToList();       
            return View("StudentList",list);
           
        }








    }
}