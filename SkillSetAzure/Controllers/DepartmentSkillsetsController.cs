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
    public class DepartmentSkillsetsController : ApiController
    {
        private SkillSetAzureContext db = new SkillSetAzureContext();

        // GET: api/DepartmentSkillsets
        public IQueryable<SS_DepartmentSkillsets> GetSS_DepartmentSkillsets()
        {
            return db.SS_DepartmentSkillsets;
        }

        // GET: api/DepartmentSkillsets/5
        [ResponseType(typeof(SS_DepartmentSkillsets))]
        public async Task<IHttpActionResult> GetSS_DepartmentSkillsets(int id)
        {
            SS_DepartmentSkillsets sS_DepartmentSkillsets = await db.SS_DepartmentSkillsets.FindAsync(id);
            if (sS_DepartmentSkillsets == null)
            {
                return NotFound();
            }

            return Ok(sS_DepartmentSkillsets);
        }

        // PUT: api/DepartmentSkillsets/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSS_DepartmentSkillsets(int id, SS_DepartmentSkillsets sS_DepartmentSkillsets)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sS_DepartmentSkillsets.DepartmentSkillsetID)
            {
                return BadRequest();
            }

            db.Entry(sS_DepartmentSkillsets).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SS_DepartmentSkillsetsExists(id))
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

        // POST: api/DepartmentSkillsets
        [ResponseType(typeof(SS_DepartmentSkillsets))]
        public async Task<IHttpActionResult> PostSS_DepartmentSkillsets(SS_DepartmentSkillsets sS_DepartmentSkillsets)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SS_DepartmentSkillsets.Add(sS_DepartmentSkillsets);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = sS_DepartmentSkillsets.DepartmentSkillsetID }, sS_DepartmentSkillsets);
        }

        // DELETE: api/DepartmentSkillsets/5
        [ResponseType(typeof(SS_DepartmentSkillsets))]
        public async Task<IHttpActionResult> DeleteSS_DepartmentSkillsets(int id)
        {
            SS_DepartmentSkillsets sS_DepartmentSkillsets = await db.SS_DepartmentSkillsets.FindAsync(id);
            if (sS_DepartmentSkillsets == null)
            {
                return NotFound();
            }

            db.SS_DepartmentSkillsets.Remove(sS_DepartmentSkillsets);
            await db.SaveChangesAsync();

            return Ok(sS_DepartmentSkillsets);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SS_DepartmentSkillsetsExists(int id)
        {
            return db.SS_DepartmentSkillsets.Count(e => e.DepartmentSkillsetID == id) > 0;
        }
    }
}