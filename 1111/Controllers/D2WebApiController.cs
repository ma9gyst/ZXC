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
using Domain.Core.Entities;

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
            await _heroService.InitializeTableHeroAsync();
            var res = await _heroService.GetAllAsync();
            return View(_mapper.Mapper.Map<List<HeroViewModel>>(res));
        }

        public async Task<IActionResult> HeroInfo(int id)
        {
            Hero hero = await _heroService.GetHeroAsync(id);
            HeroInfoViewModel heroInfo = new HeroInfoViewModel() { Hero = hero };
            return View(heroInfo);
        }
    }
}
