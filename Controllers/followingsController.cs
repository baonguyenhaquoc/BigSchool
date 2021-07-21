using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BigSchool.Models;
using Microsoft.AspNet.Identity;

namespace BigSchool.Controllers
{
    public class followingsController : ApiController
    {
        //private BigSchoolContext db = new BigSchoolContext();

        //// GET: api/Followings
        //public IQueryable<Following> GetFollowings()
        //{
        //    return db.Followings;
        //}

        //// GET: api/Followings/5
        //[ResponseType(typeof(Following))]
        //public IHttpActionResult GetFollowing(string id)
        //{
        //    Following following = db.Followings.Find(id);
        //    if (following == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(following);
        //}

        //// PUT: api/Followings/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutFollowing(string id, Following following)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != following.FollowerId)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(following).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!FollowingExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/Followings
        //[ResponseType(typeof(Following))]
        //public IHttpActionResult PostFollowing(Following following)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Followings.Add(following);

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (FollowingExists(following.FollowerId))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtRoute("DefaultApi", new { id = following.FollowerId }, following);
        //}

        //// DELETE: api/Followings/5
        //[ResponseType(typeof(Following))]
        //public IHttpActionResult DeleteFollowing(string id)
        //{
        //    Following following = db.Followings.Find(id);
        //    if (following == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Followings.Remove(following);
        //    db.SaveChanges();

        //    return Ok(following);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool FollowingExists(string id)
        //{
        //    return db.Followings.Count(e => e.FollowerId == id) > 0;
        //}

        [HttpPost]
        public IHttpActionResult Follow(Following follow)
        {
            //user login là người theo dõi, follow.FolloweeId là người được theo dõi
            var userID = User.Identity.GetUserId();
            if (userID == null)
                return BadRequest("Please login first!");
            if (userID == follow.FolloweeId)
                return BadRequest("Can not follow myself!");
            BigSchoolContext context = new BigSchoolContext();
            //kiểm tra xem mã userID đã được theo dõi chưa
            Following find = context.Followings.FirstOrDefault(p => p.FollowerId ==
            userID && p.FolloweeId == follow.FolloweeId);
            if (find != null)
            {
                //return BadRequest("The already following exists!");
                context.Followings.Remove(context.Followings.SingleOrDefault(p =>
p.FollowerId == userID && p.FolloweeId == follow.FolloweeId));
                context.SaveChanges();
                return Ok("cancel");
            }
            //set object follow
            follow.FollowerId = userID;
            context.Followings.Add(follow);
            context.SaveChanges();
            return Ok();
        }
    }
}