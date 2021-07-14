using BigSchool.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace BigSchool.Controllers
{

    
    public class AttendancesController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Attend(Courses attendanceDto)
        {
            var userID = User.Identity.GetUserId();
            BigSchoolContext context = new BigSchoolContext();
            if (context.Attendances.Any(p => p.Attendee == userID && p.CourseID == attendanceDto.Id))
            {
                var attendance = new Attendance() { CourseID = attendanceDto.Id, Attendee = User.Identity.GetUserId() };
                context.Attendances.Add(attendance);
                context.SaveChanges();
                return Ok();
            }
            return BadRequest("The attendance alrady exists!");
        }
    }

    internal class Attendance
    {
        public Attendance()
        {
        }

        public object CourseID { get; set; }
        public string Attendee { get; set; }
    }
}
