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
    public class SkillsetsController : ApiController
    {
        private SkillSetAzureContext db = new SkillSetAzureContext();

        // GET: api/Skillsets
        public IQueryable<SS_Skillsets> GetSS_Skillsets()
        {
            return db.SS_Skillsets.OrderBy(x => x.SkillsetDescr);
        }

        // GET: api/Skillsets/5
        [ResponseType(typeof(SS_Skillsets))]
        public async Task<IHttpActionResult> GetSS_Skillsets(int id)
        {
            SS_Skillsets sS_Skillsets = await db.SS_Skillsets.FindAsync(id);
            if (sS_Skillsets == null)
            {
                return NotFound();
            }

            return Ok(sS_Skillsets);
        }

        // PUT: api/Skillsets/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSS_Skillsets(int id, SS_Skillsets sS_Skillsets)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sS_Skillsets.SkillsetID)
            {
                return BadRequest();
            }

            db.Entry(sS_Skillsets).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SS_SkillsetsExists(id))
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

        // POST: api/Skillsets
        [ResponseType(typeof(SS_Skillsets))]
        public async Task<IHttpActionResult> PostSS_Skillsets(SS_Skillsets sS_Skillsets)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SS_Skillsets.Add(sS_Skillsets);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = sS_Skillsets.SkillsetID }, sS_Skillsets);
        }

        // DELETE: api/Skillsets/5
        [ResponseType(typeof(SS_Skillsets))]
        public async Task<IHttpActionResult> DeleteSS_Skillsets(int id)
        {
            SS_Skillsets sS_Skillsets = await db.SS_Skillsets.FindAsync(id);
            if (sS_Skillsets == null)
            {
                return NotFound();
            }

            db.SS_Skillsets.Remove(sS_Skillsets);
            await db.SaveChangesAsync();

            return Ok(sS_Skillsets);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SS_SkillsetsExists(int id)
        {
            return db.SS_Skillsets.Count(e => e.SkillsetID == id) > 0;
        }
    }
}