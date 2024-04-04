using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PetCareHub.Models;

namespace PetCareHub.Controllers
{
    public class VeteranDataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/VeteranData/ListVeterans
        [HttpGet]
        public IEnumerable<VeternDto> ListVeterans()
        {
            List<Veteran> veterans = db.Veterans.ToList();
            List<VeternDto> veternDtos = new List<VeternDto>();

            veterans.ForEach(v => veternDtos.Add(new VeternDto()
            {
                VeteranId = v.VeteranId,
                VeteranName = v.VeteranName,
                VeteranPlace = v.VeteranPlace,
                // Add other properties as needed
            }));
            return veternDtos;
        }

        // GET: api/VeteranData/FindVeteran/5
        [ResponseType(typeof(Veteran))]
        [HttpGet]
        public IHttpActionResult FindVeteran(int id)
        {
            Veteran veteran = db.Veterans.Find(id);
            VeternDto veteranDto = new VeternDto()
            {
                VeteranId = veteran.VeteranId,
                VeteranName = veteran.VeteranName,
                VeteranPlace = veteran.VeteranPlace,
                // Add other properties as needed
            };
            if (veteran == null)
            {
                return NotFound();
            }

            return Ok(veteranDto);
        }

        // POST: api/VeteranData/AddVeteran
        [ResponseType(typeof(Veteran))]
        [HttpPost]
        public IHttpActionResult AddVeteran(Veteran veteran)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Veterans.Add(veteran);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = veteran.VeteranId }, veteran);
        }

        // POST: api/VeteranData/UpdateVeteran/5
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult UpdateVeteran(int id, Veteran veteran)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != veteran.VeteranId)
            {
                return BadRequest();
            }

            db.Entry(veteran).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VeteranExists(id))
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

        // POST: api/VeteranData/DeleteVeteran/5
        [ResponseType(typeof(Veteran))]
        [HttpPost]
        public IHttpActionResult DeleteVeteran(int id)
        {
            Veteran veteran = db.Veterans.Find(id);
            if (veteran == null)
            {
                return NotFound();
            }

            db.Veterans.Remove(veteran);
            db.SaveChanges();

            return Ok(veteran);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VeteranExists(int id)
        {
            return db.Veterans.Count(e => e.VeteranId == id) > 0;
        }
    }
}
