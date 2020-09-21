using Domain.Core.Entities;
using Domain.Interfaces.Base;
using Infrastructure.Data.DTO;
using Infrastructure.Data.Entity_Framework.Repository;
using Newtonsoft.Json;
using Services.Data.AutoMapper;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Services.Data
{
    public class HeroService : IHeroService
    {
        private readonly IRepositoryAsync<Hero> _repositoryAsync;
        private readonly IAutoMapper _mapper;
        public HeroService(IRepositoryAsync<Hero> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = new AutoMapper.AutoMapper();
        }
        public async Task InitializeTableHeroAsync()
        {
            if ((await _repositoryAsync.ReadAllAsync()).Count() == 0)
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
                    hero.FormattedName = hero.Name.Replace("npc_dota_hero_", "").ToLower();
                }

                foreach (var hero in _mapper.Mapper.Map<List<Hero>>(heroes))
                    await _repositoryAsync.CreateAsync(hero);
            }
            return;
        }

        public async Task<IEnumerable<HeroDto>> GetAllAsync()
        {
            return _mapper.Mapper.Map<List<HeroDto>>(await _repositoryAsync.ReadAllAsync());
        }

        public async Task<Hero> GetHeroAsync(int id)
        {
            return _mapper.Mapper.Map<Hero>(await _repositoryAsync.ReadAsync(id));
        }
    }
}
