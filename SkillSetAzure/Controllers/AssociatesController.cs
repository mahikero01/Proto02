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
    public class AssociatesController : ApiController
    {
        private SkillSetAzureContext db = new SkillSetAzureContext();

        // GET: api/Associates
        public IQueryable<SS_Associates> GetSS_Associates()
        {
            return db.SS_Associates;
        }

        // GET: api/Associates/5
        [ResponseType(typeof(SS_Associates))]
        public async Task<IHttpActionResult> GetSS_Associates(int id)
        {
            SS_Associates sS_Associates = await db.SS_Associates.FindAsync(id);
            if (sS_Associates == null)
            {
                return NotFound();
            }

            return Ok(sS_Associates);
        }

        // PUT: api/Associates/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSS_Associates(int id, SS_Associates sS_Associates)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sS_Associates.AssociateID)
            {
                return BadRequest();
            }

            db.Entry(sS_Associates).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SS_AssociatesExists(id))
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

        // POST: api/Associates
        [ResponseType(typeof(SS_Associates))]
        public async Task<IHttpActionResult> PostSS_Associates(SS_Associates sS_Associates)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SS_Associates.Add(sS_Associates);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = sS_Associates.AssociateID }, sS_Associates);
        }

        // DELETE: api/Associates/5
        [ResponseType(typeof(SS_Associates))]
        public async Task<IHttpActionResult> DeleteSS_Associates(int id)
        {
            SS_Associates sS_Associates = await db.SS_Associates.FindAsync(id);
            if (sS_Associates == null)
            {
                return NotFound();
            }

            db.SS_Associates.Remove(sS_Associates);
            await db.SaveChangesAsync();

            return Ok(sS_Associates);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SS_AssociatesExists(int id)
        {
            return db.SS_Associates.Count(e => e.AssociateID == id) > 0;
        }
    }
}