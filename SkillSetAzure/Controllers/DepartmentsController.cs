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
    public class DepartmentsController : ApiController
    {
        private SkillSetAzureContext db = new SkillSetAzureContext();

        // GET: api/Departments
        public IQueryable<SS_Departments> GetSS_Departments()
        {
            return db.SS_Departments;
        }

        // GET: api/Departments/5
        [ResponseType(typeof(SS_Departments))]
        public async Task<IHttpActionResult> GetSS_Departments(short id)
        {
            SS_Departments sS_Departments = await db.SS_Departments.FindAsync(id);
            if (sS_Departments == null)
            {
                return NotFound();
            }

            return Ok(sS_Departments);
        }

        // PUT: api/Departments/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSS_Departments(short id, SS_Departments sS_Departments)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sS_Departments.DepartmentID)
            {
                return BadRequest();
            }

            db.Entry(sS_Departments).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SS_DepartmentsExists(id))
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

        // POST: api/Departments
        [ResponseType(typeof(SS_Departments))]
        public async Task<IHttpActionResult> PostSS_Departments(SS_Departments sS_Departments)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SS_Departments.Add(sS_Departments);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = sS_Departments.DepartmentID }, sS_Departments);
        }

        // DELETE: api/Departments/5
        [ResponseType(typeof(SS_Departments))]
        public async Task<IHttpActionResult> DeleteSS_Departments(short id)
        {
            SS_Departments sS_Departments = await db.SS_Departments.FindAsync(id);
            if (sS_Departments == null)
            {
                return NotFound();
            }

            db.SS_Departments.Remove(sS_Departments);
            await db.SaveChangesAsync();

            return Ok(sS_Departments);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SS_DepartmentsExists(short id)
        {
            return db.SS_Departments.Count(e => e.DepartmentID == id) > 0;
        }
    }
}