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
    public class AssociateDepartmentSkillsetsController : ApiController
    {
        private SkillSetAzureContext db = new SkillSetAzureContext();

        // GET: api/AssociateDepartmentSkillsets
        public IQueryable<SS_AssociateDepartmentSkillsets> GetSS_AssociateDepartmentSkillsets()
        {
            return db.SS_AssociateDepartmentSkillsets;
        }

        // GET: api/AssociateDepartmentSkillsets/5
        [ResponseType(typeof(SS_AssociateDepartmentSkillsets))]
        public async Task<IHttpActionResult> GetSS_AssociateDepartmentSkillsets(int id)
        {
            SS_AssociateDepartmentSkillsets sS_AssociateDepartmentSkillsets = await db.SS_AssociateDepartmentSkillsets.FindAsync(id);
            if (sS_AssociateDepartmentSkillsets == null)
            {
                return NotFound();
            }

            return Ok(sS_AssociateDepartmentSkillsets);
        }

        // PUT: api/AssociateDepartmentSkillsets/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSS_AssociateDepartmentSkillsets(int id, SS_AssociateDepartmentSkillsets sS_AssociateDepartmentSkillsets)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sS_AssociateDepartmentSkillsets.AssociateDepartmentSkillsetID)
            {
                return BadRequest();
            }

            db.Entry(sS_AssociateDepartmentSkillsets).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SS_AssociateDepartmentSkillsetsExists(id))
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

        // POST: api/AssociateDepartmentSkillsets
        [ResponseType(typeof(SS_AssociateDepartmentSkillsets))]
        public async Task<IHttpActionResult> PostSS_AssociateDepartmentSkillsets(SS_AssociateDepartmentSkillsets sS_AssociateDepartmentSkillsets)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SS_AssociateDepartmentSkillsets.Add(sS_AssociateDepartmentSkillsets);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = sS_AssociateDepartmentSkillsets.AssociateDepartmentSkillsetID }, sS_AssociateDepartmentSkillsets);
        }

        // DELETE: api/AssociateDepartmentSkillsets/5
        [ResponseType(typeof(SS_AssociateDepartmentSkillsets))]
        public async Task<IHttpActionResult> DeleteSS_AssociateDepartmentSkillsets(int id)
        {
            SS_AssociateDepartmentSkillsets sS_AssociateDepartmentSkillsets = await db.SS_AssociateDepartmentSkillsets.FindAsync(id);
            if (sS_AssociateDepartmentSkillsets == null)
            {
                return NotFound();
            }

            db.SS_AssociateDepartmentSkillsets.Remove(sS_AssociateDepartmentSkillsets);
            await db.SaveChangesAsync();

            return Ok(sS_AssociateDepartmentSkillsets);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SS_AssociateDepartmentSkillsetsExists(int id)
        {
            return db.SS_AssociateDepartmentSkillsets.Count(e => e.AssociateDepartmentSkillsetID == id) > 0;
        }
    }
}