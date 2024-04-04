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
    public class PetDataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/PetData/ListPets
        [HttpGet]
        public IEnumerable<PetDto> ListPets()
        {
            List < Pet >Pets= db.Pets.ToList();
            List <PetDto> PetDtos= new List<PetDto> ();

            Pets.ForEach(a => PetDtos.Add(new PetDto()
            {
                PetID=a.PetID,
                PetName=a.PetName,
                PetBreed=a.PetBreed,
                PetType=a.PetType,
                PetAge=a.PetAge,
                PetAdoptionStatus=a.PetAdoptionStatus
            }));
            return PetDtos;
        }

        // GET: api/PetData/FindPet/5
        [ResponseType(typeof(Pet))]
        [HttpGet]
        public IHttpActionResult FindPet(int id)
        {
            Pet Pet = db.Pets.Find(id);
            PetDto PetDto = new PetDto()
            {
                PetID = Pet.PetID,
                PetName = Pet.PetName,
                PetBreed = Pet.PetBreed,
                PetType = Pet.PetType,
                PetAge = Pet.PetAge,
                PetAdoptionStatus = Pet.PetAdoptionStatus,
                VeteranName = Pet.Veteran.VeteranName
            };
            if (Pet == null)
            {
                return NotFound();
            }

            return Ok(PetDto);
        }

        // Post: api/PetData/UpdatePet/5
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult UpdatePet(int id, Pet pet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pet.PetID)
            {
                return BadRequest();
            }

            db.Entry(pet).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetExists(id))
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

        // POST: api/PetData/AddPet
        [ResponseType(typeof(Pet))]
        [HttpPost]
        public IHttpActionResult AddPet(Pet pet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pets.Add(pet);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pet.PetID }, pet);
        }

        // DELETE: api/PetData/DeletePet/5
        [ResponseType(typeof(Pet))]
        [HttpPost]
        public IHttpActionResult DeletePet(int id)
        {
            Pet pet = db.Pets.Find(id);
            if (pet == null)
            {
                return NotFound();
            }

            db.Pets.Remove(pet);
            db.SaveChanges();

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PetExists(int id)
        {
            return db.Pets.Count(e => e.PetID == id) > 0;
        }
    }
}