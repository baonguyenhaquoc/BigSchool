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
    public class CourseController : ApiController
    {
        [HttpGet]
        [Route("api/DeteleCourse")]
        public IHttpActionResult DeteleCourse(int id)
        {
            BigSchoolContext context = new BigSchoolContext();
            var userId = User.Identity.GetUserId();
            var course = context.Courses.Single(c => c.Id == id && c.LecturerId == userId);

            try
            {
                //var Attend = schoolContext.Attendances.Single(p => p.Attendee == userId && p.CourseId == id);
                //schoolContext.Attendances.Remove(Attend);
                context.Courses.Remove(course);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message.ToString());
            }
        }
    }
}
