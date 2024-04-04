using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using PetCareHub.Models;

namespace PetCareHub.Controllers
{
    public class PetController : Controller
    {
        // GET: Pet
        public ActionResult List()
        {
            // retrive pet list
            //curl https://localhost:44382/api/petdata/listpets

            HttpClient client = new HttpClient(){};
            string url = "https://localhost:44382/api/petdata/listpets";
            HttpResponseMessage response=client.GetAsync(url).Result;
            Debug.WriteLine("The respose is");
            Debug.WriteLine(response.StatusCode);

            IEnumerable<Pet> pets = response.Content.ReadAsAsync<IEnumerable<Pet>>().Result;
            Debug.WriteLine("Number of pets:");
            Debug.WriteLine(pets.Count());

            return View(pets);
        }

        // GET: Pet/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pet/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pet/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pet/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pet/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pet/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pet/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
