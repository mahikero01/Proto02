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
    public class set_moduleController : ApiController
    {
        private SkillSetAzureContext db = new SkillSetAzureContext();

        // GET: api/set_module
        public IQueryable<set_module> Getset_module()
        {
            return db.set_module;
        }

        // GET: api/set_module/5
        [ResponseType(typeof(set_module))]
        public async Task<IHttpActionResult> Getset_module(string id)
        {
            set_module set_module = await db.set_module.FindAsync(id);
            if (set_module == null)
            {
                return NotFound();
            }

            return Ok(set_module);
        }

        // PUT: api/set_module/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putset_module(string id, set_module set_module)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != set_module.mod_id)
            {
                return BadRequest();
            }

            db.Entry(set_module).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!set_moduleExists(id))
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

        // POST: api/set_module
        [ResponseType(typeof(set_module))]
        public async Task<IHttpActionResult> Postset_module(set_module set_module)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.set_module.Add(set_module);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (set_moduleExists(set_module.mod_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = set_module.mod_id }, set_module);
        }

        // DELETE: api/set_module/5
        [ResponseType(typeof(set_module))]
        public async Task<IHttpActionResult> Deleteset_module(string id)
        {
            set_module set_module = await db.set_module.FindAsync(id);
            if (set_module == null)
            {
                return NotFound();
            }

            db.set_module.Remove(set_module);
            await db.SaveChangesAsync();

            return Ok(set_module);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool set_moduleExists(string id)
        {
            return db.set_module.Count(e => e.mod_id == id) > 0;
        }
    }
}