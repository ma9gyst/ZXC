using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Domain.Core.Entities;
using Domain.Core.Entities.OpenDotaEntities;
using Infrastructure.Data.Entity_Framework.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace _1111.Controllers
{
    public class D2WebApiController : Controller
    {
        //private static readonly string _D2WebApiKey = "FBAA6EB0E7809A9010E7A5D0AE33EFB6";
        private readonly HeroRepositoryAsync _heroRepositoryAsync;

        public D2WebApiController(HeroRepositoryAsync heroRepositoryAsync)
        {
            _heroRepositoryAsync = heroRepositoryAsync;
        }

        public async Task<IActionResult> Index()
        {
            //string urlD2WebApi = "http://api.steampowered.com/IEconDOTA2_205790/GetHeroes/v1";


            //UriBuilder uriBuilder = new UriBuilder(urlOpenDota);
            //var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            //query["key"] = _D2WebApiKey;
            //query["match_id"] = "5554948179";
            //query["language"] = "en";
            //query["format"] = "json";
            //uriBuilder.Query = query.ToString();
            // urlOpenDota = uriBuilder.ToString();

            //await GetHeroes();

            return View(_heroRepositoryAsync.GetTable().ToList());
        }

        public async Task GetHeroes() 
        {
            await _heroRepositoryAsync.DeleteAllAsync();

            List<Hero> heroes;
            const string url = "https://api.opendota.com/api/heroes";
            
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(url))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    heroes = JsonConvert.DeserializeObject<List<Hero>>(apiResponse);
                }
            }

            foreach (var hero in heroes)
            {
                hero.Id = 0;
                hero.FormatedName = hero.Name.Replace("npc_dota_hero_", "").ToLower();
            }

            await _heroRepositoryAsync.WriteAll(heroes);
        }
    }
}
