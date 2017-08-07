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
    public class LocationsController : ApiController
    {
        private SkillSetAzureContext db = new SkillSetAzureContext();

        // GET: api/Locations
        public IQueryable<SS_Locations> GetSS_Locations()
        {
            return db.SS_Locations.OrderBy(x => x.LocationDescr);
        }

        // GET: api/Locations/5
        [ResponseType(typeof(SS_Locations))]
        public async Task<IHttpActionResult> GetSS_Locations(int id)
        {
            SS_Locations sS_Locations = await db.SS_Locations.FindAsync(id);
            if (sS_Locations == null)
            {
                return NotFound();
            }

            return Ok(sS_Locations);
        }

        // PUT: api/Locations/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSS_Locations(int id, SS_Locations sS_Locations)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sS_Locations.LocationID)
            {
                return BadRequest();
            }

            db.Entry(sS_Locations).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SS_LocationsExists(id))
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

        // POST: api/Locations
        [ResponseType(typeof(SS_Locations))]
        public async Task<IHttpActionResult> PostSS_Locations(SS_Locations sS_Locations)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SS_Locations.Add(sS_Locations);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = sS_Locations.LocationID }, sS_Locations);
        }

        // DELETE: api/Locations/5
        [ResponseType(typeof(SS_Locations))]
        public async Task<IHttpActionResult> DeleteSS_Locations(int id)
        {
            SS_Locations sS_Locations = await db.SS_Locations.FindAsync(id);
            if (sS_Locations == null)
            {
                return NotFound();
            }

            db.SS_Locations.Remove(sS_Locations);
            await db.SaveChangesAsync();

            return Ok(sS_Locations);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SS_LocationsExists(int id)
        {
            return db.SS_Locations.Count(e => e.LocationID == id) > 0;
        }
    }
}