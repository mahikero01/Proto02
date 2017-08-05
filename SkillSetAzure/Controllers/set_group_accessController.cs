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
    public class set_group_accessController : ApiController
    {
        private SkillSetAzureContext db = new SkillSetAzureContext();

        // GET: api/set_group_access
        public IQueryable<set_group_access> Getset_group_access()
        {
            return db.set_group_access;
        }

        // GET: api/set_group_access/5
        [ResponseType(typeof(set_group_access))]
        public async Task<IHttpActionResult> Getset_group_access(int id)
        {
            set_group_access set_group_access = await db.set_group_access.FindAsync(id);
            if (set_group_access == null)
            {
                return NotFound();
            }

            return Ok(set_group_access);
        }

        // PUT: api/set_group_access/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putset_group_access(int id, set_group_access set_group_access)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != set_group_access.Id)
            {
                return BadRequest();
            }

            db.Entry(set_group_access).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!set_group_accessExists(id))
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

        // POST: api/set_group_access
        [ResponseType(typeof(set_group_access))]
        public async Task<IHttpActionResult> Postset_group_access(set_group_access set_group_access)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.set_group_access.Add(set_group_access);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = set_group_access.Id }, set_group_access);
        }

        // DELETE: api/set_group_access/5
        [ResponseType(typeof(set_group_access))]
        public async Task<IHttpActionResult> Deleteset_group_access(int id)
        {
            set_group_access set_group_access = await db.set_group_access.FindAsync(id);
            if (set_group_access == null)
            {
                return NotFound();
            }

            db.set_group_access.Remove(set_group_access);
            await db.SaveChangesAsync();

            return Ok(set_group_access);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool set_group_accessExists(int id)
        {
            return db.set_group_access.Count(e => e.Id == id) > 0;
        }
    }
}