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
        public async Task<IEnumerable<HeroDto>> GetAllAsync()
        {
            return _mapper.Mapper.Map<List<HeroDto>>(await _repositoryAsync.ReadAllAsync());
        }

        public async Task CreateAllAsync(IEnumerable<HeroDto> heroesDto)
        {
            foreach (var hero in _mapper.Mapper.Map<List<Hero>>(heroesDto))
                await _repositoryAsync.CreateAsync(hero);
        }

        public async Task<Hero> GetHero(int id)
        {
            Hero hero = await _repositoryAsync.ReadAsync(id);

            if (hero.Matchups.Count == 0)
            {
                List<MatchupDto> matchups = new List<MatchupDto>();
                string url = $"https://api.opendota.com/api/heroes/{id}/matchups";

                using (var httpClient = new HttpClient())
                {
                    using var response = await httpClient.GetAsync(url);
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    matchups = JsonConvert.DeserializeObject<List<MatchupDto>>(apiResponse);
                }

                hero.Matchups = _mapper.Mapper.Map<List<Matchup>>(matchups);
                await _repositoryAsync.UpdateAsync(hero);
            }
            return _mapper.Mapper.Map<Hero>(hero);
        }
    }
}
