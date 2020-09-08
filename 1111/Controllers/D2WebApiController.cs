using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Services.Interfaces;
using _1111.Models;
using _1111.MapperProfile;
using Infrastructure.Data.DTO;

namespace _1111.Controllers
{
    public class D2WebApiController : Controller
    {
        //private static readonly string _D2WebApiKey = "FBAA6EB0E7809A9010E7A5D0AE33EFB6";
        //private static readonly string _D2WebApiId = "205790";
        readonly IHeroService heroService;
        readonly IAutoMapper mapper;
        public D2WebApiController(IHeroService heroService, IAutoMapper mapper)
        {
            this.heroService = heroService;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            //string urlD2WebApi = "http://api.steampowered.com/IEconDOTA2_/GetHeroes/v1";


            //UriBuilder uriBuilder = new UriBuilder(urlOpenDota);
            //var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            //query["key"] = _D2WebApiKey;
            //query["match_id"] = "5554948179";
            //query["language"] = "en";
            //query["format"] = "json";
            //uriBuilder.Query = query.ToString();
            // urlOpenDota = uriBuilder.ToString();

            await GetHeroes();

            var res = await heroService.GetAll();
            var heros = mapper.Mapper.Map<List<HeroViewModel>>(res);

            return View(heros);
        }

        //public async Task<IActionResult> HeroInfo(int id)
        //{
        //    List<MatchupDto> matchups = new List<MatchupDto>();
        //    string url = $"https://api.opendota.com/api/heroes/{id}/matchups";

        //    using (var httpClient = new HttpClient())
        //    {
        //        using var response = await httpClient.GetAsync(url);
        //        string apiResponse = await response.Content.ReadAsStringAsync();
        //        matchups = JsonConvert.DeserializeObject<List<MatchupDto>>(apiResponse);
        //    }

        //    ViewData["Matchups"] = matchups;
        //    return View(await _heroRepositoryAsync.ReadAsync(id));
        //}

        public async Task GetHeroes()
        {
            //await heroService.DeleteAll();

            List<HeroDto> heroes;
            string url = "https://api.opendota.com/api/heroes";

            using (var httpClient = new HttpClient())
            {
                using var response = await httpClient.GetAsync(url);
                string apiResponse = await response.Content.ReadAsStringAsync();
                heroes = JsonConvert.DeserializeObject<List<HeroDto>>(apiResponse);
            }

            foreach (var hero in heroes)
            {
                //List<Matchup> matchups = new List<Matchup>();
                //url = $"https://api.opendota.com/api/heroes/{hero.Id}/matchups";

                //using (var httpClient = new HttpClient())
                //{
                //    using var response = await httpClient.GetAsync(url);
                //    try
                //    {
                //        string apiResponse = await response.Content.ReadAsStringAsync();
                //        matchups = JsonConvert.DeserializeObject<List<Matchup>>(apiResponse);
                //    }
                //    catch (Exception ex) { Console.WriteLine(ex.Message + hero, ); };
                //}

                //hero.Matchups.AddRange(matchups);

                hero.Id = 0;
                hero.FormattedName = hero.Name.Replace("npc_dota_hero_", "").ToLower();
            }

            //await _heroRepositoryAsync.WriteAll(heroes);
        }
    }
}
