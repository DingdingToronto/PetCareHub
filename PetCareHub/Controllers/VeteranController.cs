using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Web.Mvc;
using PetCareHub.Models;

namespace PetCareHub.Controllers
{
    public class VeteranController : Controller
    {
        // GET: Veteran/List
        public ActionResult List()
        {
            HttpClient client = new HttpClient();
            string url = "https://localhost:44382/api/veterandata/listveterans";
            HttpResponseMessage response = client.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                IEnumerable<Veteran> veterans = response.Content.ReadAsAsync<IEnumerable<Veteran>>().Result;
                return View(veterans);
            }
            else
            {
                // Log the error or handle it accordingly
                Debug.WriteLine("Failed to retrieve veterans. Status code: " + response.StatusCode);
                return View("Error");
            }
        }

        // GET: Veteran/Details/5
        public ActionResult Details(int id)
        {
            HttpClient client = new HttpClient();
            string url = $"https://localhost:44382/api/veterandata/findveteran/{id}";
            HttpResponseMessage response = client.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                Veteran veteran = response.Content.ReadAsAsync<Veteran>().Result;
                return View(veteran);
            }
            else
            {
                // Log the error or handle it accordingly
                Debug.WriteLine($"Failed to retrieve veteran with ID {id}. Status code: " + response.StatusCode);
                return View("Error");
            }
        }

        // GET: Veteran/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Veteran/Create
        [HttpPost]
        public ActionResult Create(Veteran veteran)
        {
            HttpClient client = new HttpClient();
            string url = "https://localhost:44382/api/veterandata/addveteran";
            HttpResponseMessage response = client.PostAsJsonAsync(url, veteran).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("List");
            }
            else
            {
                // Log the error or handle it accordingly
                Debug.WriteLine("Failed to create veteran. Status code: " + response.StatusCode);
                return View("Error");
            }
        }

        // Other actions...
    }
}
