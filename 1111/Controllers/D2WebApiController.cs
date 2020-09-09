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
using _1111.ViewModels;

namespace _1111.Controllers
{
    public class D2WebApiController : Controller
    {
        //private static readonly string _D2WebApiKey = "FBAA6EB0E7809A9010E7A5D0AE33EFB6";
        //private static readonly string _D2WebApiId = "205790";
        private readonly IHeroService _heroService;
        private readonly IAutoMapper _mapper;
        public D2WebApiController(IHeroService heroService, IAutoMapper mapper)
        {
            _heroService = heroService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            await GetHeroes();
            var res = await _heroService.GetAllAsync();
            return View(_mapper.Mapper.Map<List<HeroViewModel>>(res));
        }

        public async Task<IActionResult> HeroInfo(int id)
        {
            HeroInfoViewModel heroInfo = new HeroInfoViewModel() { Hero = await _heroService.GetHero(id) };
            return View(heroInfo);
        }

        public async Task GetHeroes()
        {
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
                hero.Id = 0;
                hero.FormattedName = hero.Name.Replace("npc_dota_hero_", "").ToLower();
            }

            await _heroService.CreateAllAsync(heroes);
        }
    }
}
