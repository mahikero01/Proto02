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
    public class set_groupController : ApiController
    {
        private SkillSetAzureContext db = new SkillSetAzureContext();

        // GET: api/set_group
        public IQueryable<set_group> Getset_group()
        {
            return db.set_group;
        }

        // GET: api/set_group/5
        [ResponseType(typeof(set_group))]
        public async Task<IHttpActionResult> Getset_group(string id)
        {
            set_group set_group = await db.set_group.FindAsync(id);
            if (set_group == null)
            {
                return NotFound();
            }

            return Ok(set_group);
        }

        // PUT: api/set_group/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putset_group(string id, set_group set_group)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != set_group.grp_id)
            {
                return BadRequest();
            }

            db.Entry(set_group).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!set_groupExists(id))
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

        // POST: api/set_group
        [ResponseType(typeof(set_group))]
        public async Task<IHttpActionResult> Postset_group(set_group set_group)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.set_group.Add(set_group);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (set_groupExists(set_group.grp_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = set_group.grp_id }, set_group);
        }

        // DELETE: api/set_group/5
        [ResponseType(typeof(set_group))]
        public async Task<IHttpActionResult> Deleteset_group(string id)
        {
            set_group set_group = await db.set_group.FindAsync(id);
            if (set_group == null)
            {
                return NotFound();
            }

            db.set_group.Remove(set_group);
            await db.SaveChangesAsync();

            return Ok(set_group);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool set_groupExists(string id)
        {
            return db.set_group.Count(e => e.grp_id == id) > 0;
        }
    }
}