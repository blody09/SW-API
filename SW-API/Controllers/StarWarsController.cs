using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SW_API.Models;

namespace SW_API.Controllers
{
    public class StarWarsController : Controller
    {
        public IActionResult Index() // add view
        {
            return View();
        }
        public async Task<IActionResult> GetPersonById(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://swapi.co/api/");
            //client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (compatible; GrandCircus/1.0)");

            var response = await client.GetAsync($"people/{id}");
            var person = await response.Content.ReadAsAsync<People>();

            return View(person);
        }


        public async Task<IActionResult> GetPlanetById(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://swapi.co/api/");
            //client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (compatible; GrandCircus/1.0)");

            var response = await client.GetAsync($"planets/{id}");
            var planet = await response.Content.ReadAsAsync<Planet>();

            return View(planet);
        }
    }
}