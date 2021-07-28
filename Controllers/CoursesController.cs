using BigSchool.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Linq;

namespace BigSchool.Controllers
{
    public class Courses : Controller
    {
        //public object Id { get; internal set; }

        // GET: Courses
        //public ActionResult Create()
        //{
        //    //get List category
        //    BigSchoolContext context = new BigSchoolContext();
        //    Course objCourse = new Course();
        //    objCourse.ListCategory = context.Categories.ToList();

        //    return View(objCourse);
        //}
        //[Authorize]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(Course objCourse)
        //{
        //    BigSchoolContext context = new BigSchoolContext();
        //    //ko xét valid LectureId
        //    ModelState.Remove("LecturerId");
        //    if (!ModelState.IsValid)
        //    {
        //        objCourse.ListCategory = context.Categories.ToList();
        //        return View("Create", objCourse);
        //    }

        //    //Lấy Login user id
        //    ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
        //    objCourse.LecturerId = user.Id;

        //    //add vào csdl
        //    context.Courses.Add(objCourse);
        //    context.SaveChanges();

        //    //Về home
        //    return RedirectToAction("Index", "Home");
        //}

        ////public ActionResult Attending()
        ////{
        ////    BigSchoolContext context = new BigSchoolContext();
        ////    ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
        ////    var listAtt = context.Attendaces.Where(p => p.Attendee == user.Id).ToList();
        ////    var course = new List<Course>();
        ////    foreach (Attendance temp in listAtt)
        ////    {
        ////        Course course1 = temp.Course;
        ////        course1.Name = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(course1.LecturerId).Name;
        ////        course.Add(course1);

        ////    }
        ////    return View(course);
        ////}

        ////public ActionResult Mine()
        ////{
        ////    BigSchoolContext context = new BigSchoolContext();
        ////    ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
        ////    var course = context.Courses.Where(c => c.LecturerId == user.Id && c.DateTime > DateTime.Now).ToList();
        ////    foreach (Course i in course)
        ////    {
        ////        i.Name = user.Name;
        ////    }
        ////    return View(course);
        ////}
        
    }
}