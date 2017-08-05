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
    public class set_user_accessController : ApiController
    {
        private SkillSetAzureContext db = new SkillSetAzureContext();

        // GET: api/set_user_access
        public IQueryable<set_user_access> Getset_user_access()
        {
            return db.set_user_access;
        }

        // GET: api/set_user_access/5
        [ResponseType(typeof(set_user_access))]
        public async Task<IHttpActionResult> Getset_user_access(int id)
        {
            set_user_access set_user_access = await db.set_user_access.FindAsync(id);
            if (set_user_access == null)
            {
                return NotFound();
            }

            return Ok(set_user_access);
        }

        // PUT: api/set_user_access/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putset_user_access(int id, set_user_access set_user_access)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != set_user_access.Id)
            {
                return BadRequest();
            }

            db.Entry(set_user_access).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!set_user_accessExists(id))
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

        // POST: api/set_user_access
        [ResponseType(typeof(set_user_access))]
        public async Task<IHttpActionResult> Postset_user_access(set_user_access set_user_access)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.set_user_access.Add(set_user_access);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = set_user_access.Id }, set_user_access);
        }

        // DELETE: api/set_user_access/5
        [ResponseType(typeof(set_user_access))]
        public async Task<IHttpActionResult> Deleteset_user_access(int id)
        {
            set_user_access set_user_access = await db.set_user_access.FindAsync(id);
            if (set_user_access == null)
            {
                return NotFound();
            }

            db.set_user_access.Remove(set_user_access);
            await db.SaveChangesAsync();

            return Ok(set_user_access);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool set_user_accessExists(int id)
        {
            return db.set_user_access.Count(e => e.Id == id) > 0;
        }
    }
}