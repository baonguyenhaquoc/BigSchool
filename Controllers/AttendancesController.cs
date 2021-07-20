using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BigSchool.Models;
using Microsoft.AspNet.Identity;


namespace BigSchool.Controllers
{

    public class AttendancesController : ApiController
    {
        //[HttpPost]
        //public IHttpActionResult Attend(Course course)
        //{
        //    var userID = User.Identity.GetUserId();
        //    BigSchoolContext context = new BigSchoolContext();
        //    if (context.GetAttendances().Any(p => p.Attendee == userID && p.CourseId == course.Id))
        //    {
        //        return BadRequest("The attendance already exists !");
        //    }
        //    var attendance = new Attendace() { CourseId = course.Id, Attendee = User.Identity.GetUserId() };
        //    context.GetAttendances().Add(attendance);
        //    context.SaveChanges();
        //    return Ok();
        //}
        [HttpPost]
        public IHttpActionResult Attend(Course attendanceDto)
        {
            var userID = User.Identity.GetUserId();
            BigSchoolContext context = new BigSchoolContext();
            if (context.Attendaces.Any(p => p.Attendee == userID && p.CourseId == attendanceDto.Id))
            {
                return BadRequest("The attendance already exists !");
            }
            var attendance = new Attendance() { CourseId = attendanceDto.Id, Attendee = User.Identity.GetUserId() };
            context.Attendaces.Add(attendance);
            context.SaveChanges();
            return Ok();
        }
    }
}
