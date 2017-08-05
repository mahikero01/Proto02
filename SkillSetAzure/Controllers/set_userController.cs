using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using SkillSetAzure.Models;

namespace SkillSetAzure.Controllers
{
    public class set_userController : ApiController
    {
        private SkillSetAzureContext db = new SkillSetAzureContext();

        // GET: api/set_user
        public IQueryable<set_user> Getset_user()
        {
            return db.set_user;
        }

        // GET: api/set_user/5
        [ResponseType(typeof(set_user))]
        public async Task<IHttpActionResult> Getset_user(string id)
        {
            set_user set_user = await db.set_user.FindAsync(id);
            if (set_user == null)
            {
                return NotFound();
            }

            return Ok(set_user);
        }

        // PUT: api/set_user/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putset_user(string id, set_user set_user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != set_user.user_id)
            {
                return BadRequest();
            }

            db.Entry(set_user).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!set_userExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/set_user
        [ResponseType(typeof(set_user))]
        public async Task<IHttpActionResult> Postset_user(set_user set_user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.set_user.Add(set_user);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (set_userExists(set_user.user_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = set_user.user_id }, set_user);
        }

        // DELETE: api/set_user/5
        [ResponseType(typeof(set_user))]
        public async Task<IHttpActionResult> Deleteset_user(string id)
        {
            set_user set_user = await db.set_user.FindAsync(id);
            if (set_user == null)
            {
                return NotFound();
            }

            db.set_user.Remove(set_user);
            await db.SaveChangesAsync();

            return Ok(set_user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool set_userExists(string id)
        {
            return db.set_user.Count(e => e.user_id == id) > 0;
        }
    }
}